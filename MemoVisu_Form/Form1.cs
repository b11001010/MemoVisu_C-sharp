using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace MemoVisu_Form
{
    public partial class Form1 : Form
    {
        int eax;
        int ebx;
        int ecx;
        int edx;
        int edi;
        int esi;
        int ebp;
        ArrayList eips = new ArrayList();
        ArrayList writeAddrs = new ArrayList();
        ArrayList readAddrs = new ArrayList();

        //階層管理
        Dictionary<int, int> layerMap = new Dictionary<int, int>();
        List<List<int>> writeList = new List<List<int>>();
        List<List<int>> readList = new List<List<int>>();

        int margin = 10;
        int intervalX = 0;       //ブロック同士の横の間隔
        int intervalY = 0;       //ブロック同士の縦の間隔
        int width = 3;          //ブロックの幅
        int height = 3;         //ブロックの高さ
        int row = 0x100;        //1行あたりのブロック数
        int offset = 0x3A0000;  //開始オフセット

        public Form1()
        {
            InitializeComponent();
        }

        //フォーム生成時
        private void Form1_Load(object sender, EventArgs e)
        {
            width_textBox.Text = width.ToString();
            height_textBox.Text = height.ToString();
            row_numericUpDown.Value = row;
            offset_textBox.Text = offset.ToString("X");
            filter_checkedListBox.SetItemChecked(0, true);
            filter_checkedListBox.SetItemChecked(1, true);
            filter_checkedListBox.SetItemChecked(2, true);
        }

        //「描画」ボタンクリック時
        private void button_paint_Click(object sender, EventArgs e)
        {

            int writeLayer = layer_listBox.SelectedIndex;
            int readLayer = readLayer_listBox.SelectedIndex;

            writeSize_label.Text = "書き込みサイズ: " + writeAddrs.Count;
            readSize_label.Text = "読み込みサイズ: " + readAddrs.Count;

            //メインのImageオブジェクトを作成する
            Bitmap mainImg = new Bitmap(row * width + margin*2, 10000);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(mainImg);

            int x, y;
            //グリッド描画
            for (int i = 0; i < 1000; i++)
            {
                int addr = 0x10000 * i;
                int pos = addr - offset;
                y = pos / row;
                y = y * (intervalY + height);
                Pen p;
                Font fnt;
                if(addr % 0x100000 == 0)
                {
                    p = new Pen(Color.FromArgb(0x7F, Color.Blue), 3);
                    fnt = new Font("MS UI Gothic", 15);
                }
                else
                {
                    p = new Pen(Color.FromArgb(0x3F, Color.Blue), 2);
                    fnt = new Font("MS UI Gothic", 10);
                }
                g.DrawLine(p, 0, y, row * width + margin*2, y);
                g.DrawString(addr.ToString("X"), fnt, Brushes.Black, 0, y);
                p.Dispose();
            }
            /*
            for (int i = 0; i < 100; i++)
            {
                int addr = 0x100000 * i;
                int pos = addr - offset;
                x = pos % row;
                y = pos / row;
                x = x * (margin_x + width);
                y = y * (margin_y + height);
                g.FillRectangle(new SolidBrush(Color.FromArgb(0x7F, Color.Blue)), x, y, row * width + margin*2, 3);
                //フォントオブジェクトの作成
                Font fnt = new Font("MS UI Gothic", 20);
                //文字列を位置(0,0)、青色で表示
                g.DrawString(addr.ToString("X"), fnt, Brushes.Black, x, y);
            }
            */

            //書き込みアドレス描画
            if (filter_checkedListBox.GetItemChecked(0) && writeLayer != -1)
            {
                //foreach (int addr in writeAddrs)      //階層化処理無し
                foreach (int addr in writeList[writeLayer])
                {
                    int pos = addr - offset;
                    x = pos % row;
                    y = pos / row;
                    x = x * (intervalX + width) + margin;
                    y = y * (intervalY +  height);
                    //塗りつぶされた長方形を描画する
                    Brush b = new SolidBrush(Color.FromArgb(0x7F, Color.Green));
                    g.FillRectangle(b, x, y, width, height);
                }
                
            }
            //読み込みアドレス描画
            if (filter_checkedListBox.GetItemChecked(1) && readLayer != -1)
            {
                //foreach (int addr in readAddrs)      //階層化処理無し
                foreach (int addr in readList[readLayer])
                {
                    int pos = addr - offset;
                    x = pos % row;
                    y = pos / row;
                    x = x * (intervalX + width) + margin;
                    y = y * (intervalY + height);
                    //塗りつぶされた長方形を描画する
                    Brush b = new SolidBrush(Color.FromArgb(0x7F, Color.Yellow));
                    g.FillRectangle(b, x, y, width, height);
                }
            }
            //実行描画
            if (filter_checkedListBox.GetItemChecked(2))
            {
                foreach (int eip in eips)
                {
                    int pos = eip - offset; //オフセット分を引く
                    x = pos % row;
                    y = pos / row;
                    x = x * (intervalX + width) + margin;
                    y = y * (intervalY + height);
                    //塗りつぶされた長方形を描画する
                    Brush b = new SolidBrush(Color.FromArgb(0x7F, Color.Red));
                    g.FillRectangle(b, x, y, width, height);
                }
            }

            //リソースを解放する
            g.Dispose();
            //作成した画像を表示する
            mainPictureBox.Image = mainImg;


            //縮小版のImageオブジェクトを作成する
            Bitmap scaleDownImg = new Bitmap(picture_map.Width, picture_map.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g2 = Graphics.FromImage(scaleDownImg);
            //画像のサイズを縮小して描画する
            g2.DrawImage(mainImg, 0, 0, picture_map.Width, picture_map.Height);
            //Graphicsオブジェクトのリソースを解放する
            g2.Dispose();
            //PictureBox1に表示する
            picture_map.Image = scaleDownImg;
        }

        //「ファイルを開く」ボタンをクリック
        private void file_open_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();
            
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "rtrace.txt";
            //はじめに表示されるフォルダを指定する
            ofd.InitialDirectory = @"";
            //[ファイルの種類]に表示される選択肢を指定する
            ofd.Filter = "テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに「テキストファイル」が選択されているようにする
            ofd.FilterIndex = 1;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき選択されたファイルを読み取り専用で開く
                Stream stream;
                stream = ofd.OpenFile();
                if (stream != null)
                {
                    //内容を読み込み
                    string line = "";
                    StreamReader sr = new StreamReader(stream);
                    while ((line = sr.ReadLine()) != null)
                    {
                        int eip;
                        try
                        {
                            //EIPをリストに格納
                            eip = Convert.ToInt32(line.Substring(0, 8), 16);
                            eips.Add(eip);
                        }
                        catch
                        {
                            continue;
                        }
                        try
                        {
                            //レジスタの値を更新
                            string[] lineArray = line.Split(';');
                            if (lineArray.Count() == 2)
                            {
                                foreach (String regString in lineArray[1].Split(','))
                                {
                                    String[] regStringArray = regString.Trim().Split('=');
                                    if ("EDI" == regStringArray[0])
                                    {
                                        edi = Convert.ToInt32(regStringArray[1], 16);
                                    }
                                    else if ("ESI" == regStringArray[0])
                                    {
                                        esi = Convert.ToInt32(regStringArray[1], 16);
                                    }
                                    else if ("EAX" == regStringArray[0])
                                    {
                                        eax = Convert.ToInt32(regStringArray[1], 16);
                                    }
                                    else if ("EBX" == regStringArray[0])
                                    {
                                        ebx = Convert.ToInt32(regStringArray[1], 16);
                                    }
                                    else if ("ECX" == regStringArray[0])
                                    {
                                        ecx = Convert.ToInt32(regStringArray[1], 16);
                                    }
                                    else if ("EDX" == regStringArray[0])
                                    {
                                        edx = Convert.ToInt32(regStringArray[1], 16);
                                    }
                                    else if ("EBP" == regStringArray[0])
                                    {
                                        ebp = Convert.ToInt32(regStringArray[1], 16);
                                    }
                                    else
                                    {
                                        throw new ArgumentException("不明なレジスタ: " + regStringArray[0]);
                                    }
                                }
                            }
                        }
                        catch (FormatException) {/* nothing */}

                        //正規表現でメモリアクセス命令を判別
                        Regex writeRegex = new Regex(@"(MOV|MOVS|STOS) (BYTE|WORD|DWORD) PTR ..:\[(..|...)\].*");   //書き込み
                        checkWriteCode(line, eip, writeRegex);
                        Regex readRegex = new Regex(@"(MOV|MOVS) .*,(BYTE|WORD|DWORD) PTR ..:\[(..|...)\]"); //読み込み
                        checkReadCode(line, readRegex);
                        readRegex = new Regex(@"(LODS) (BYTE|WORD|DWORD) PTR ..:\[(..|...)\]"); //読み込み
                        checkReadCode(line, readRegex);
                    }
                    //閉じる
                    sr.Close();
                    stream.Close();

                    //階層リストボックスを更新
                    layer_listBox.Items.Clear();
                    for (int i = 0; i < writeList.Count; i++)
                    {
                        layer_listBox.Items.Add(i);
                    }
                    layer_listBox.SetSelected(0, true);

                    readLayer_listBox.Items.Clear();
                    for (int i = 0; i < readList.Count; i++)
                    {
                        readLayer_listBox.Items.Add(i);
                    }
                    readLayer_listBox.SetSelected(0, true);
                }
            }
        }

        private void checkWriteCode(string line, int eip, Regex writeRegex)
        {
            Match writeMatch = writeRegex.Match(line);
            if (writeMatch.Success)
            {
                //書き込みサイズ取得
                int size = getSize(writeMatch.Groups[2].Value);

                //書き込み先アドレスを取得
                int dstAddr;
                dstAddr = getAddr(writeMatch.Groups[3].Value);
                writeAddrs.Add(dstAddr);

                //階層化処理
                //EIPで階層マップを検索
                if (layerMap.ContainsKey(eip))
                {
                    //存在する場合，書き込み先アドレスの階層レベルをEIPの階層レベル+1に設定
                    int newLayerLevel = layerMap[eip] + 1;
                    while (writeList.Count <= newLayerLevel)
                    {
                        writeList.Add(new List<int>());
                    }
                    int i = 0;
                    do
                    {
                        layerMap[dstAddr + i] = newLayerLevel;
                        writeList[newLayerLevel].Add(dstAddr + i);
                    } while (i < size);
                }
                else
                {
                    //存在しない場合，書き込み先アドレスの階層レベルを1に設定
                    while (writeList.Count <= 1)
                    {
                        writeList.Add(new List<int>());
                    }
                    int i = 0;
                    do
                    {
                        layerMap[dstAddr + i] = 1;
                        writeList[1].Add(dstAddr + i);
                        i++;
                    } while (i < size);
                }
            }
        }

        private void checkReadCode(string line, Regex readRegex)
        {
            Match readMatch = readRegex.Match(line);
            if (readMatch.Success)
            {
                //読み込みサイズ取得
                int size = getSize(readMatch.Groups[2].Value);

                //読み込み先アドレスを取得
                int srcAddr;
                srcAddr = getAddr(readMatch.Groups[3].Value);
                readAddrs.Add(srcAddr);

                //階層化処理
                int i = 0;
                do
                {
                    //読み込み先アドレスで階層マップを検索
                    if (layerMap.ContainsKey(srcAddr + i))
                    {
                        //存在する場合，読み込み先アドレスを該当階層レベル配列に追加
                        int layerLevel = layerMap[srcAddr + i];
                        while (readList.Count <= layerLevel)
                        {
                            readList.Add(new List<int>());
                        }
                        readList[layerLevel].Add(srcAddr + i);
                    }
                    else
                    {
                        //存在しない場合，読み込み先アドレスを階層レベル0配列に追加
                        if (readList.Count == 0)
                        {
                            readList.Add(new List<int>());
                        }
                        readList[0].Add(srcAddr + i);
                    }
                    i++;
                } while (i < size);
            }
        }

        private int getAddr(String addrString)
        {
            int addr;
            if (addrString == "ESI")
            {
                addr = esi;
            }
            else if (addrString == "EDI")
            {
                addr = edi;
            }
            else if (addrString == "EDX")
            {
                addr = edx;
            }
            else if (addrString == "EBX")
            {
                addr = ebx;
            }
            else
            {
                throw new ArgumentException("非対応のレジスタ: " + addrString);
            }
            return addr;
        }

        private static int getSize(String  sizeString)
        {
            int size;
            if (sizeString == "BYTE")
            {
                size = 1;
            }
            else if (sizeString == "WORD")
            {
                size = 2;
            }
            else if (sizeString == "DWORD")
            {
                size = 4;
            }
            else
            {
                throw new ArgumentException("不明なサイズ: " + sizeString);
            }
            return size;
        }

        //「折り返し幅」NumericUpDownの値の変更時
        private void row_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            row = Decimal.ToInt32(row_numericUpDown.Value);
        }

        //「offset」テキストボックスの値変更時
        private void offset_textBox_TextChanged(object sender, EventArgs e)
        {
            offset = Convert.ToInt32(offset_textBox.Text, 16);
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            int x = (e.Location.X - margin) / (width + intervalX);
            int y = e.Location.Y / (width + intervalY);
            int addr = y * row + x + offset;
            //int addr = (e.Location.Y + row) / (intervalY + height) + offset;
            point_textBox.Text = addr.ToString("X");
        }

        private void width_textBox_TextChanged(object sender, EventArgs e)
        {
            width = int.Parse(width_textBox.Text);
        }

        private void height_textBox_TextChanged(object sender, EventArgs e)
        {
            height = int.Parse(height_textBox.Text);
        }
        
    }
}

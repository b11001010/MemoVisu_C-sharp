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

namespace MemoVisu_Form
{
    public partial class Form1 : Form
    {

        int edi;

        ArrayList eips = new ArrayList();
        int margin_x = 0;
        int margin_y = 0;
        int height = 3;
        int width = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            width_textBox.Text = width.ToString();
            height_textBox.Text = height.ToString();
        }

        private void button_paint_Click(object sender, EventArgs e)
        {

            margin_textBox.Text = edi.ToString();

            int height = int.Parse(width_textBox.Text);
            int width = int.Parse(height_textBox.Text);

            //200x100サイズのImageオブジェクトを作成する
            Bitmap img = new Bitmap(266*width, 1000);

            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(img);

            int x, y;
            foreach (int eip in eips) {
                int pos = eip - 0x3C0000;	//オフセット
                x = pos % 0x100;
                y = pos / 0x100;
                x = x * margin_x + (x - 1) * width + 10;
                y = y * margin_y + (y - 1) * height;
                //塗りつぶされた長方形を描画する
                Brush b = new SolidBrush(Color.FromArgb(10, Color.Red));
                g.FillRectangle(b, x, y, width, height);
            }

            //リソースを解放する
            g.Dispose();

            mainPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            //作成した画像を表示する
            mainPictureBox.Image = img;


            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(picture_map.Width, picture_map.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g2 = Graphics.FromImage(canvas);
            
            //画像のサイズを2倍にしてcanvasに描画する
            g2.DrawImage(img, 0, 0, picture_map.Width, picture_map.Height);
            //Imageオブジェクトのリソースを解放する

            //Graphicsオブジェクトのリソースを解放する
            g2.Dispose();
            //PictureBox1に表示する
            picture_map.Image = canvas;
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
            //指定しないとすべてのファイルが表示される
            ofd.Filter =
                "テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに
            //「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 1;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイルを読み取り専用で開く
                Stream stream;
                stream = ofd.OpenFile();
                if (stream != null)
                {
                    //内容を読み込み、表示する
                    string line = "";
                    StreamReader sr = new StreamReader(stream);
                    while ((line = sr.ReadLine()) != null)
                    {
                        try
                        {
                            //EIPをリストに格納
                            string eipString = line.Substring(0, 8);
                            eips.Add(Convert.ToInt32(eipString, 16));

                            //レジスタの値を更新
                            string regString = line.Substring(line.Length - 12, 12);
                            if ("EDI" == regString.Substring(0,3))
                            {
                                edi = Convert.ToInt32(regString.Substring(regString.Length - 8, 8), 16);
                            }
                        }
                        catch {/* nothing */}
                    }
                    //閉じる
                    sr.Close();
                    stream.Close();
                }
            }
        }
    }
}

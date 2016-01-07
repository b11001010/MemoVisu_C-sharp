using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoVisu_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_paint_Click(object sender, EventArgs e)
        {
            //200x100サイズのImageオブジェクトを作成する
            Bitmap img = new Bitmap(500, 1000);

            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(img);

            //全体を黒で塗りつぶす
            g.FillRectangle(Brushes.Black, g.VisibleClipBounds);
            //黄色い扇形を描画する
            g.DrawPie(Pens.Yellow, 60, 10, 80, 80, 30, 300);

            //リソースを解放する
            g.Dispose();

            mainPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            //作成した画像を表示する
            mainPictureBox.Image = img;


            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(picture_map.Width, picture_map.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g2 = Graphics.FromImage(canvas);
            
            //画像のサイズを縮小してcanvasに描画する
            g2.DrawImage(img, 0, 0, picture_map.Width, picture_map.Height);
            //Imageオブジェクトのリソースを解放する

            //Graphicsオブジェクトのリソースを解放する
            g2.Dispose();
            //PictureBox1に表示する
            picture_map.Image = canvas;
        }
    }
}

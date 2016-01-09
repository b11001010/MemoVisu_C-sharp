namespace MemoVisu_Form
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.width_textBox = new System.Windows.Forms.TextBox();
            this.width_label = new System.Windows.Forms.Label();
            this.height_textBox = new System.Windows.Forms.TextBox();
            this.height_label = new System.Windows.Forms.Label();
            this.layer_listBox = new System.Windows.Forms.ListBox();
            this.button_paint = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.picture_map = new System.Windows.Forms.PictureBox();
            this.file_open = new System.Windows.Forms.Button();
            this.margin_textBox = new System.Windows.Forms.TextBox();
            this.row_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.row_label = new System.Windows.Forms.Label();
            this.offset_textBox = new System.Windows.Forms.TextBox();
            this.offset_label = new System.Windows.Forms.Label();
            this.writeSize_label = new System.Windows.Forms.Label();
            this.readSize_label = new System.Windows.Forms.Label();
            this.filter_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.readLayer_listBox = new System.Windows.Forms.ListBox();
            this.writeLayer_label = new System.Windows.Forms.Label();
            this.readLayer_label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.row_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // width_textBox
            // 
            this.width_textBox.Location = new System.Drawing.Point(257, 12);
            this.width_textBox.Name = "width_textBox";
            this.width_textBox.Size = new System.Drawing.Size(100, 19);
            this.width_textBox.TabIndex = 1;
            // 
            // width_label
            // 
            this.width_label.AutoSize = true;
            this.width_label.Location = new System.Drawing.Point(219, 15);
            this.width_label.Name = "width_label";
            this.width_label.Size = new System.Drawing.Size(32, 12);
            this.width_label.TabIndex = 2;
            this.width_label.Text = "width";
            // 
            // height_textBox
            // 
            this.height_textBox.Location = new System.Drawing.Point(257, 37);
            this.height_textBox.Name = "height_textBox";
            this.height_textBox.Size = new System.Drawing.Size(100, 19);
            this.height_textBox.TabIndex = 3;
            // 
            // height_label
            // 
            this.height_label.AutoSize = true;
            this.height_label.Location = new System.Drawing.Point(215, 41);
            this.height_label.Name = "height_label";
            this.height_label.Size = new System.Drawing.Size(36, 12);
            this.height_label.TabIndex = 4;
            this.height_label.Text = "height";
            // 
            // layer_listBox
            // 
            this.layer_listBox.FormattingEnabled = true;
            this.layer_listBox.ItemHeight = 12;
            this.layer_listBox.Location = new System.Drawing.Point(691, 31);
            this.layer_listBox.Name = "layer_listBox";
            this.layer_listBox.Size = new System.Drawing.Size(95, 100);
            this.layer_listBox.TabIndex = 5;
            // 
            // button_paint
            // 
            this.button_paint.Location = new System.Drawing.Point(12, 113);
            this.button_paint.Name = "button_paint";
            this.button_paint.Size = new System.Drawing.Size(75, 23);
            this.button_paint.TabIndex = 6;
            this.button_paint.Text = "描画";
            this.button_paint.UseVisualStyleBackColor = true;
            this.button_paint.Click += new System.EventHandler(this.button_paint_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.mainPictureBox);
            this.panel1.Location = new System.Drawing.Point(12, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 543);
            this.panel1.TabIndex = 7;
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(795, 540);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            // 
            // picture_map
            // 
            this.picture_map.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picture_map.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picture_map.Location = new System.Drawing.Point(835, 148);
            this.picture_map.Name = "picture_map";
            this.picture_map.Size = new System.Drawing.Size(52, 540);
            this.picture_map.TabIndex = 8;
            this.picture_map.TabStop = false;
            // 
            // file_open
            // 
            this.file_open.Location = new System.Drawing.Point(12, 12);
            this.file_open.Name = "file_open";
            this.file_open.Size = new System.Drawing.Size(75, 23);
            this.file_open.TabIndex = 9;
            this.file_open.Text = "ファイルを開く";
            this.file_open.UseVisualStyleBackColor = true;
            this.file_open.Click += new System.EventHandler(this.file_open_Click);
            // 
            // margin_textBox
            // 
            this.margin_textBox.Location = new System.Drawing.Point(257, 112);
            this.margin_textBox.Name = "margin_textBox";
            this.margin_textBox.Size = new System.Drawing.Size(100, 19);
            this.margin_textBox.TabIndex = 10;
            // 
            // row_numericUpDown
            // 
            this.row_numericUpDown.Location = new System.Drawing.Point(257, 87);
            this.row_numericUpDown.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.row_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.row_numericUpDown.Name = "row_numericUpDown";
            this.row_numericUpDown.Size = new System.Drawing.Size(100, 19);
            this.row_numericUpDown.TabIndex = 12;
            this.row_numericUpDown.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.row_numericUpDown.ValueChanged += new System.EventHandler(this.row_numericUpDown_ValueChanged);
            // 
            // row_label
            // 
            this.row_label.AutoSize = true;
            this.row_label.Location = new System.Drawing.Point(193, 90);
            this.row_label.Name = "row_label";
            this.row_label.Size = new System.Drawing.Size(58, 12);
            this.row_label.TabIndex = 13;
            this.row_label.Text = "折り返し幅";
            // 
            // offset_textBox
            // 
            this.offset_textBox.Location = new System.Drawing.Point(257, 62);
            this.offset_textBox.Name = "offset_textBox";
            this.offset_textBox.Size = new System.Drawing.Size(100, 19);
            this.offset_textBox.TabIndex = 14;
            this.offset_textBox.TextChanged += new System.EventHandler(this.offset_textBox_TextChanged);
            // 
            // offset_label
            // 
            this.offset_label.AutoSize = true;
            this.offset_label.Location = new System.Drawing.Point(216, 65);
            this.offset_label.Name = "offset_label";
            this.offset_label.Size = new System.Drawing.Size(35, 12);
            this.offset_label.TabIndex = 15;
            this.offset_label.Text = "offset";
            // 
            // writeSize_label
            // 
            this.writeSize_label.AutoSize = true;
            this.writeSize_label.Location = new System.Drawing.Point(547, 94);
            this.writeSize_label.Name = "writeSize_label";
            this.writeSize_label.Size = new System.Drawing.Size(80, 12);
            this.writeSize_label.TabIndex = 16;
            this.writeSize_label.Text = "書き込みサイズ:";
            // 
            // readSize_label
            // 
            this.readSize_label.AutoSize = true;
            this.readSize_label.Location = new System.Drawing.Point(547, 115);
            this.readSize_label.Name = "readSize_label";
            this.readSize_label.Size = new System.Drawing.Size(82, 12);
            this.readSize_label.TabIndex = 17;
            this.readSize_label.Text = "読み込みサイズ:";
            // 
            // filter_checkedListBox
            // 
            this.filter_checkedListBox.CheckOnClick = true;
            this.filter_checkedListBox.FormattingEnabled = true;
            this.filter_checkedListBox.Items.AddRange(new object[] {
            "書き込み",
            "読み込み",
            "実行"});
            this.filter_checkedListBox.Location = new System.Drawing.Point(363, 12);
            this.filter_checkedListBox.Name = "filter_checkedListBox";
            this.filter_checkedListBox.Size = new System.Drawing.Size(97, 46);
            this.filter_checkedListBox.TabIndex = 18;
            // 
            // readLayer_listBox
            // 
            this.readLayer_listBox.FormattingEnabled = true;
            this.readLayer_listBox.ItemHeight = 12;
            this.readLayer_listBox.Location = new System.Drawing.Point(792, 31);
            this.readLayer_listBox.Name = "readLayer_listBox";
            this.readLayer_listBox.Size = new System.Drawing.Size(95, 100);
            this.readLayer_listBox.TabIndex = 19;
            // 
            // writeLayer_label
            // 
            this.writeLayer_label.AutoSize = true;
            this.writeLayer_label.Location = new System.Drawing.Point(689, 16);
            this.writeLayer_label.Name = "writeLayer_label";
            this.writeLayer_label.Size = new System.Drawing.Size(73, 12);
            this.writeLayer_label.TabIndex = 20;
            this.writeLayer_label.Text = "書き込み階層";
            // 
            // readLayer_label
            // 
            this.readLayer_label.AutoSize = true;
            this.readLayer_label.Location = new System.Drawing.Point(790, 16);
            this.readLayer_label.Name = "readLayer_label";
            this.readLayer_label.Size = new System.Drawing.Size(75, 12);
            this.readLayer_label.TabIndex = 21;
            this.readLayer_label.Text = "読み込み階層";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 703);
            this.Controls.Add(this.readLayer_label);
            this.Controls.Add(this.writeLayer_label);
            this.Controls.Add(this.readLayer_listBox);
            this.Controls.Add(this.filter_checkedListBox);
            this.Controls.Add(this.readSize_label);
            this.Controls.Add(this.writeSize_label);
            this.Controls.Add(this.offset_label);
            this.Controls.Add(this.offset_textBox);
            this.Controls.Add(this.row_label);
            this.Controls.Add(this.row_numericUpDown);
            this.Controls.Add(this.margin_textBox);
            this.Controls.Add(this.file_open);
            this.Controls.Add(this.picture_map);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_paint);
            this.Controls.Add(this.layer_listBox);
            this.Controls.Add(this.height_label);
            this.Controls.Add(this.height_textBox);
            this.Controls.Add(this.width_label);
            this.Controls.Add(this.width_textBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.row_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox width_textBox;
        private System.Windows.Forms.Label width_label;
        private System.Windows.Forms.TextBox height_textBox;
        private System.Windows.Forms.Label height_label;
        private System.Windows.Forms.ListBox layer_listBox;
        private System.Windows.Forms.Button button_paint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.PictureBox picture_map;
        private System.Windows.Forms.Button file_open;
        private System.Windows.Forms.TextBox margin_textBox;
        private System.Windows.Forms.NumericUpDown row_numericUpDown;
        private System.Windows.Forms.Label row_label;
        private System.Windows.Forms.TextBox offset_textBox;
        private System.Windows.Forms.Label offset_label;
        private System.Windows.Forms.Label writeSize_label;
        private System.Windows.Forms.Label readSize_label;
        private System.Windows.Forms.CheckedListBox filter_checkedListBox;
        private System.Windows.Forms.ListBox readLayer_listBox;
        private System.Windows.Forms.Label writeLayer_label;
        private System.Windows.Forms.Label readLayer_label;
    }
}


namespace TextMorphing
{
    partial class SongPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_Artist = new System.Windows.Forms.Label();
            this.btn_Play = new System.Windows.Forms.PictureBox();
            this.btn_Stop = new System.Windows.Forms.PictureBox();
            this.btn_Shuffle = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Repeat = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_Prev = new System.Windows.Forms.PictureBox();
            this.btn_Next = new System.Windows.Forms.PictureBox();
            this.lbl_ct = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.col_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.btn_Play)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Stop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Shuffle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Repeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Prev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Next)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Title.Location = new System.Drawing.Point(184, 24);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(42, 16);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Title";
            // 
            // lbl_Artist
            // 
            this.lbl_Artist.AutoSize = true;
            this.lbl_Artist.Location = new System.Drawing.Point(185, 44);
            this.lbl_Artist.Name = "lbl_Artist";
            this.lbl_Artist.Size = new System.Drawing.Size(33, 12);
            this.lbl_Artist.TabIndex = 2;
            this.lbl_Artist.Text = "Artist";
            // 
            // btn_Play
            // 
            this.btn_Play.Image = global::TextMorphing.Properties.Resources.btn_play;
            this.btn_Play.Location = new System.Drawing.Point(56, 24);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(50, 50);
            this.btn_Play.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Play.TabIndex = 5;
            this.btn_Play.TabStop = false;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Image = global::TextMorphing.Properties.Resources.btn_end;
            this.btn_Stop.Location = new System.Drawing.Point(111, 34);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(40, 40);
            this.btn_Stop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Stop.TabIndex = 6;
            this.btn_Stop.TabStop = false;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Shuffle
            // 
            this.btn_Shuffle.Image = global::TextMorphing.Properties.Resources.btn_shuffle;
            this.btn_Shuffle.Location = new System.Drawing.Point(187, 103);
            this.btn_Shuffle.Name = "btn_Shuffle";
            this.btn_Shuffle.Size = new System.Drawing.Size(30, 22);
            this.btn_Shuffle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Shuffle.TabIndex = 7;
            this.btn_Shuffle.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(187, 71);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(184, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(265, 93);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(106, 45);
            this.trackBar2.TabIndex = 9;
            this.trackBar2.TickFrequency = 5;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar2.Value = 80;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TextMorphing.Properties.Resources.close;
            this.pictureBox1.Location = new System.Drawing.Point(355, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 531);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "검색";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "전체",
            "유튜브",
            "ZIP",
            "MP3"});
            this.comboBox1.Location = new System.Drawing.Point(12, 534);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 20);
            this.comboBox1.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 533);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 21);
            this.textBox1.TabIndex = 13;
            // 
            // btn_Repeat
            // 
            this.btn_Repeat.Image = global::TextMorphing.Properties.Resources.btn_line;
            this.btn_Repeat.Location = new System.Drawing.Point(229, 103);
            this.btn_Repeat.Name = "btn_Repeat";
            this.btn_Repeat.Size = new System.Drawing.Size(30, 22);
            this.btn_Repeat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Repeat.TabIndex = 15;
            this.btn_Repeat.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TextMorphing.Properties.Resources.btn_stop;
            this.pictureBox2.Location = new System.Drawing.Point(12, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btn_Prev
            // 
            this.btn_Prev.Image = global::TextMorphing.Properties.Resources.btn_before;
            this.btn_Prev.Location = new System.Drawing.Point(35, 84);
            this.btn_Prev.Name = "btn_Prev";
            this.btn_Prev.Size = new System.Drawing.Size(30, 30);
            this.btn_Prev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Prev.TabIndex = 17;
            this.btn_Prev.TabStop = false;
            this.btn_Prev.Click += new System.EventHandler(this.btn_Prev_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Image = global::TextMorphing.Properties.Resources.btn_latter;
            this.btn_Next.Location = new System.Drawing.Point(97, 84);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(30, 30);
            this.btn_Next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Next.TabIndex = 18;
            this.btn_Next.TabStop = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // lbl_ct
            // 
            this.lbl_ct.AutoSize = true;
            this.lbl_ct.Location = new System.Drawing.Point(284, 59);
            this.lbl_ct.Name = "lbl_ct";
            this.lbl_ct.Size = new System.Drawing.Size(33, 12);
            this.lbl_ct.TabIndex = 20;
            this.lbl_ct.Text = "00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "00:00";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_type,
            this.col_name,
            this.col_time,
            this.col_artist});
            this.listView1.Location = new System.Drawing.Point(12, 144);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(359, 376);
            this.listView1.TabIndex = 23;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // col_type
            // 
            this.col_type.Text = "분류";
            // 
            // col_name
            // 
            this.col_name.Text = "이름";
            // 
            // col_time
            // 
            this.col_time.Text = "시간";
            // 
            // col_artist
            // 
            this.col_artist.Text = "아티스트";
            // 
            // SongPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 562);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_ct);
            this.Controls.Add(this.btn_Shuffle);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_Prev);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btn_Repeat);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Play);
            this.Controls.Add(this.lbl_Artist);
            this.Controls.Add(this.lbl_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SongPlayer";
            this.Text = "SongPlayer";
            this.Load += new System.EventHandler(this.SongPlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Play)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Stop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Shuffle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Repeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Prev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Next)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_Artist;
        private System.Windows.Forms.PictureBox btn_Play;
        private System.Windows.Forms.PictureBox btn_Stop;
        private System.Windows.Forms.PictureBox btn_Shuffle;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox btn_Repeat;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox btn_Prev;
        private System.Windows.Forms.PictureBox btn_Next;
        private System.Windows.Forms.Label lbl_ct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader col_type;
        private System.Windows.Forms.ColumnHeader col_name;
        private System.Windows.Forms.ColumnHeader col_time;
        private System.Windows.Forms.ColumnHeader col_artist;
    }
}
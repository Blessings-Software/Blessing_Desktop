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
            this.pic_Album = new System.Windows.Forms.PictureBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_Artist = new System.Windows.Forms.Label();
            this.lbl_Album = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_Play = new System.Windows.Forms.PictureBox();
            this.btn_Stop = new System.Windows.Forms.PictureBox();
            this.btn_Shuffle = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Album)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Play)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Stop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Shuffle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Album
            // 
            this.pic_Album.Location = new System.Drawing.Point(12, 12);
            this.pic_Album.Name = "pic_Album";
            this.pic_Album.Size = new System.Drawing.Size(128, 128);
            this.pic_Album.TabIndex = 0;
            this.pic_Album.TabStop = false;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Title.Location = new System.Drawing.Point(146, 12);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(55, 16);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "label1";
            // 
            // lbl_Artist
            // 
            this.lbl_Artist.AutoSize = true;
            this.lbl_Artist.Location = new System.Drawing.Point(146, 39);
            this.lbl_Artist.Name = "lbl_Artist";
            this.lbl_Artist.Size = new System.Drawing.Size(38, 12);
            this.lbl_Artist.TabIndex = 2;
            this.lbl_Artist.Text = "label2";
            // 
            // lbl_Album
            // 
            this.lbl_Album.AutoSize = true;
            this.lbl_Album.Location = new System.Drawing.Point(147, 60);
            this.lbl_Album.Name = "lbl_Album";
            this.lbl_Album.Size = new System.Drawing.Size(38, 12);
            this.lbl_Album.TabIndex = 3;
            this.lbl_Album.Text = "label3";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 206);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(359, 316);
            this.listBox1.TabIndex = 4;
            // 
            // btn_Play
            // 
            this.btn_Play.Location = new System.Drawing.Point(316, 12);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(50, 50);
            this.btn_Play.TabIndex = 5;
            this.btn_Play.TabStop = false;
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(280, 12);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(30, 30);
            this.btn_Stop.TabIndex = 6;
            this.btn_Stop.TabStop = false;
            // 
            // btn_Shuffle
            // 
            this.btn_Shuffle.Location = new System.Drawing.Point(244, 12);
            this.btn_Shuffle.Name = "btn_Shuffle";
            this.btn_Shuffle.Size = new System.Drawing.Size(30, 30);
            this.btn_Shuffle.TabIndex = 7;
            this.btn_Shuffle.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 146);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(359, 45);
            this.trackBar1.TabIndex = 8;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(321, 68);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(45, 72);
            this.trackBar2.TabIndex = 9;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // SongPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 535);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.btn_Shuffle);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Play);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lbl_Album);
            this.Controls.Add(this.lbl_Artist);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.pic_Album);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SongPlayer";
            this.Text = "SongPlayer";
            this.Load += new System.EventHandler(this.SongPlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Album)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Play)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Stop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Shuffle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Album;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_Artist;
        private System.Windows.Forms.Label lbl_Album;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox btn_Play;
        private System.Windows.Forms.PictureBox btn_Stop;
        private System.Windows.Forms.PictureBox btn_Shuffle;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
    }
}
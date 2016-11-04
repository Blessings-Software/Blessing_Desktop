using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace TextMorphing
{
    public partial class SongPlayer : Form
    {
        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
        WMPLib.IWMPPlaylist playlist;
        WMPLib.IWMPMedia media;
        public SongPlayer()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }


        private void SongPlayer_Load(object sender, EventArgs e)
        {
            playlist = wplayer.playlistCollection.newPlaylist("myplaylist");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Play_Click(object sender, EventArgs e)
        {
            if(wplayer.URL != ""||wplayer.URL!=null)
            {
                wplayer.controls.play();
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            wplayer.controls.stop();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            wplayer.controls.pause();
        }

        private void btn_Prev_Click(object sender, EventArgs e)
        {
            wplayer.controls.previous();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            wplayer.controls.next();
        }
    }
}

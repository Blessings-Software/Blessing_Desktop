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
using Microsoft.Win32;
using System.Net;
using System.Diagnostics;
using TextMorphing;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;

namespace YoutubeWallpaper
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        //#########################################################################################################

        protected readonly string AppName = "YoutubeWallpaper";

        protected readonly string OptionFile = Path.Combine(Application.StartupPath, "Option.dat");
        protected Option m_option = new Option();

        protected Form_Wallpaper m_wallpaper = null;

        protected Form_Touchpad m_touchpad = null;

        protected bool m_wasAero = true;

        //#########################################################################################################

        protected void ApplyAeroPeek()
        {
            if (WinApi.IsCompositionEnabled(out m_wasAero)
                && m_wasAero == false)
            {
                WinApi.EnableComposition(WinApi.CompositionAction.DWM_EC_ENABLECOMPOSITION);
            }
            else
            {
                m_wasAero = true;
            }
        }

        protected void RestoreAeroPeek()
        {
            if (m_wasAero == false)
            {
                WinApi.EnableComposition(WinApi.CompositionAction.DWM_EC_DISABLECOMPOSITION);
            }
        }

        //#########################################################################################################
        /*
     


            return false;
        }
        */
        //#########################################################################################################

        protected void HideController()
        {
            this.Hide();

            this.notifyIcon_tray.Visible = true;
        }

        protected void ShowController()
        {
            this.notifyIcon_tray.Visible = false;

            this.Show();
        }

        protected void ShowTouchPad()
        {
            if (m_touchpad == null || m_touchpad.IsDisposed)
            {
                m_touchpad = new Form_Touchpad();
                m_touchpad.Show();
            }
            else
            {
                m_touchpad.WindowState = FormWindowState.Normal;
                m_touchpad.Activate();
            }

            m_touchpad.Target = m_wallpaper;
        }

        //#########################################################################################################

        protected void PlayWallpaper()
        {
            StopWallpaper();


            StringBuilder url = new StringBuilder(@"https://www.youtube.com/");

            if (m_option.IdType == Option.Type.OneVideo)
                url.Append(@"v/");
            else if (m_option.IdType == Option.Type.Playlist)
                url.Append(@"embed?listType=playlist&index=0&list=");

            url.Append(m_option.Id);

            url.Append(@"&autoplay=1&controls=0&showinfo=0&autohide=1&modestbranding=1&rel=0");

            // OneVideo는 구버전 플레이어만 loop를 지원하므로 그렇게하되
            // 실시간 동영상이면 그렇게하지 않는다.
            /*
            if (m_option.IdType == Option.Type.OneVideo
                && m_option.IsLive == false)
            {
                url.Append(@"&version=2");
            }
            */
            //url.Append("&vq=");
            /*
            string quality = "";
            switch (m_option.VideoQuality)
            {
                case Option.Quality.p240:
                    quality = "small";
                    break;

                case Option.Quality.p360:
                    quality = "medium";
                    break;

                case Option.Quality.p480:
                    quality = "large";
                    break;

                case Option.Quality.p720:
                    quality = "hd720";
                    break;

                case Option.Quality.p1080:
                    quality = "hd1080";
                    break;

                case Option.Quality.p1440:
                    quality = "hd1440";
                    break;
            }

           url.Append(quality);
           */
            
            m_wallpaper = new Form_Wallpaper(m_option.ScreenIndex);
            m_wallpaper.Volume = m_option.Volume;
            m_wallpaper.Show();

            if (m_touchpad != null)
            {
                m_touchpad.Target = m_wallpaper;
            }

            if (m_wallpaper.IsFixed)
            {
                m_wallpaper.Uri = url.ToString();
            }
            else
            {
               // MessageBox.Show("배경화면을 설정할 수 없습니다.", "Error!",
               //     MessageBoxButtons.OK, MessageBoxIcon.Error);

                //StopWallpaper();
            }
        }

        protected void StopWallpaper()
        {
            if (m_wallpaper != null)
            {
                m_wallpaper.Close();
                m_wallpaper.Dispose();
                m_wallpaper = null;
            }
        }

        protected void PauseWallpaper()
        {
            if (m_wallpaper != null)
            {
                m_wallpaper.Pause(); //100ms동안 멈춤
                //Timer가 100마다 돌면서 체크해주면 됨.
            }
        }

        protected void ResumeWallpaper()
        {
            if (m_wallpaper != null)
            {
                m_wallpaper.ResumeLayout();
            }
        }

        protected void MuteWallpaper()
        {
            this.trackBar_volume.Value = 0;

            if (m_wallpaper != null)
            {
                m_wallpaper.Volume = 0;
            }
        }

        protected void NextScreen()
        {
            if (m_wallpaper != null)
            {
                m_wallpaper.OwnerScreenIndex++;
                m_option.ScreenIndex = m_wallpaper.OwnerScreenIndex;

                if (m_wallpaper.IsFixed == false)
                {
                   // MessageBox.Show("배경화면을 설정할 수 없습니다.", "Error!",
                    //    MessageBoxButtons.OK, MessageBoxIcon.Error);


                   // StopWallpaper();
                }
            }
        }

        //#########################################################################################################

        protected void ApplyOptionToUI()
        {
            switch (m_option.IdType)
            {
                case Option.Type.OneVideo:
                    this.radioButton_type_one.Checked = true;
                    break;

                case Option.Type.Playlist:
                    this.radioButton_type_list.Checked = true;
                    break;
            }

            this.textBox_id.Text = m_option.Id;

            switch (m_option.VideoQuality)
            {
                case Option.Quality.p240:
                    this.radioButton_q_small.Checked = true;
                    break;

                case Option.Quality.p360:
                    this.radioButton_q_medium.Checked = true;
                    break;

                case Option.Quality.p480:
                    this.radioButton_q_large.Checked = true;
                    break;

                case Option.Quality.p720:
                    this.radioButton_q_720.Checked = true;
                    break;

                case Option.Quality.p1080:
                    this.radioButton_q_1080.Checked = true;
                    break;

                case Option.Quality.p1440:
                    this.radioButton_q_1440.Checked = true;
                    break;
            }

            this.trackBar_volume.Value = m_option.Volume;
            if (m_wallpaper != null)
                m_wallpaper.Volume = m_option.Volume;

            this.checkBox_isLive.Checked = m_option.IsLive;
        }

        protected void LoadOption()
        {
            if (File.Exists(OptionFile))
            {
                m_option.LoadFromFile(OptionFile);
            }

            ApplyOptionToUI();
        }

        protected void SaveOption()
        {
            if (this.radioButton_type_one.Checked)
                m_option.IdType = Option.Type.OneVideo;
            else if (this.radioButton_type_list.Checked)
                m_option.IdType = Option.Type.Playlist;

            m_option.Id = this.textBox_id.Text;

            if (this.radioButton_q_small.Checked)
                m_option.VideoQuality = Option.Quality.p240;
            else if (this.radioButton_q_medium.Checked)
                m_option.VideoQuality = Option.Quality.p480;
            else if (this.radioButton_q_large.Checked)
                m_option.VideoQuality = Option.Quality.p720;
            else if (this.radioButton_q_720.Checked)
                m_option.VideoQuality = Option.Quality.p720;
            else if (this.radioButton_q_1080.Checked)
                m_option.VideoQuality = Option.Quality.p1080;
            else if (this.radioButton_q_1440.Checked)
                m_option.VideoQuality = Option.Quality.p1440;

            m_option.Volume = this.trackBar_volume.Value;

            m_option.IsLive = this.checkBox_isLive.Checked;


            m_option.SaveToFile(OptionFile);
        }

        //#########################################################################################################

        private void Form_Main_Load(object sender, EventArgs e)
        {
           // ApplyAeroPeek();


           // Task.Factory.StartNew(CheckUpdate);


            LoadOption();//

            // 시작프로그램 여부 알아내기
            using (var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                this.ToolStripMenuItem_startup.Checked = (key.GetValue(AppName) != null);
            }

            // 시작프로그램으로 등록되어있다면 저장된 정보로 자동 실행
            if (this.ToolStripMenuItem_startup.Checked)
            {
                Task.Factory.StartNew(new Action(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        System.Threading.Thread.Sleep(2500);

                        HideController();
                    }));
                }));

                PlayWallpaper();
            }
        }

        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            RestoreAeroPeek();


            this.notifyIcon_tray.Visible = false;
        }

        //#########################################################################################################

        private void button_apply_Click(object sender, EventArgs e)
        {
            SaveOption();


            StopWallpaper();


            PlayWallpaper();
        }

        private void button_restore_Click(object sender, EventArgs e)
        {
            ApplyOptionToUI();
        }

        //#########################################################################################################

        private void ToolStripMenuItem_startup_Click(object sender, EventArgs e)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (this.ToolStripMenuItem_startup.Checked)
                {
                    key.SetValue(AppName, Application.ExecutablePath);
                }
                else
                {
                    key.DeleteValue(AppName, false);
                }

                MessageBox.Show("Success!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ToolStripMenuItem_hideController_Click(object sender, EventArgs e)
        {
            HideController();
        }

        private void ToolStripMenuItem_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //#########################################################################################################

        private void ToolStripMenuItem_openTouchpad_Click(object sender, EventArgs e)
        {
            ShowTouchPad();
        }

        private void ToolStripMenuItem_stopWallpaper_Click(object sender, EventArgs e)
        {
            StopWallpaper();
        }

        private void ToolStripMenuItem_mute_Click(object sender, EventArgs e)
        {
            MuteWallpaper();
        }

        private void ToolStripMenuItem_nextScreen_Click(object sender, EventArgs e)
        {
            NextScreen();
        }

        //#########################################################################################################

        private void ToolStripMenuItem_openBlog_Click(object sender, EventArgs e)
        {
            Process.Start(@"http://blog.naver.com/neurowhai/220810470139");
        }

        //#########################################################################################################

        private void notifyIcon_tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowController();
        }

        //#########################################################################################################

        private void ToolStripMenuItem_openController_Click(object sender, EventArgs e)
        {
            ShowController();
        }

        private void ToolStripMenuItem_openTouchpadInTray_Click(object sender, EventArgs e)
        {
            ShowTouchPad();
        }

        private void ToolStripMenuItem_stopWallpaperInTray_Click(object sender, EventArgs e)
        {
            StopWallpaper();
        }

        private void ToolStripMenuItem_muteInTray_Click(object sender, EventArgs e)
        {
            MuteWallpaper();
        }

        private void ToolStripMenuItem_exitInTray_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //#########################################################################################################

        private void trackBar_volume_Scroll(object sender, EventArgs e)
        {
            if (m_wallpaper != null)
            {
                m_wallpaper.Volume = this.trackBar_volume.Value;
            }
        }

        //#########################################################################################################

        private void radioButton_type_one_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox_isLive.Enabled = this.radioButton_type_one.Checked;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Clear();
                var youtube = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyDLZD-Gm08xZ9L9fplGMXdhF5CbLGDhv8c", // 키 지정
                    ApplicationName = "YoutubeSearch"
                });

                // Search용 Request 생성
                var request = youtube.Search.List("snippet");
                request.Q = textBox1.Text;  //ex: "양희은"
                request.MaxResults = 50;

                // Search용 Request 실행
                var result = await request.ExecuteAsync();

                // Search 결과를 리스트뷰에 담기
                foreach (var item in result.Items)
                {
                    if (item.Id.Kind == "youtube#video")
                    {
                        listView1.Items.Add(item.Id.VideoId.ToString(), item.Snippet.Title, 0);
                    }
                }
                YouTubeService ytservice = new YouTubeService();
                //var videoRequest = ytservice.Videos.List("snippet");
                /////videoRequest.Id = result.Items[0].Id.VideoId;
                //var response = videoRequest.Execute();
            }
            catch(Exception)
            {
                //throw new Exception();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    Console.WriteLine("Search Start");
                    string videoId = listView1.SelectedItems[0].Name;
                    //string youtubeUrl = "http://youtube.com/watch?v=" + videoId;
                    m_option.Id = videoId;
                    YoutubeSender.m_YoutubeId = videoId;
                    var req = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/youtube/v3/videos?id="+videoId+ "&part=contentDetails&key=AIzaSyDLZD-Gm08xZ9L9fplGMXdhF5CbLGDhv8c");
                    req.Method = "GET";
                    var res = (HttpWebResponse)req.GetResponse();
                    var res_str = new StreamReader(res.GetResponseStream()).ReadToEnd();
                    Console.WriteLine(res_str);
                    for (int i = listView1.SelectedItems[0].Index; i<listView1.Items.Count;i++)
                    {
                        YoutubeSender.m_YoutubeList[i] = listView1.Items[i].Name;
                    }
                    //MessageBox.Show(videoId);
                    textBox_id.Text = videoId;
                }
            }
            catch(Exception)
            {

            }
        }
        public bool m_wallpaperstopped = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (m_wallpaperstopped)
            {
               // timer1.Stop();
                m_wallpaperstopped = false;
                ResumeWallpaper();
            }
            else
            {
                //timer1.Start();
                 m_wallpaperstopped = true;
                m_wallpaper.Pause();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_wallpaperstopped)
            {
                m_wallpaperstopped = false;
                ResumeWallpaper();
            }
            else
            {
                m_wallpaperstopped = true;
                //PauseWallpaper();
                Thread.Sleep(100);
            }
        }
    }
}

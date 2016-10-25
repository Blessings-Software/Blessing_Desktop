using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeWallpaper;

namespace TextMorphing
{
    public partial class SearchForm : Form
    {

        protected Form_Wallpaper m_wallpaper = null;

        protected Form_Touchpad m_touchpad = null;
        public SearchForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // YouTubeService 객체 생성
            var youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAzrH0jMEcjFb7MFWxwFu9-tfAFUIx9dO8", // 키 지정
                ApplicationName = "My YouTube Search"
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
            var videoRequest = ytservice.Videos.List("snippet");
            videoRequest.Id = result.Items[0].Id.VideoId;
            var response = videoRequest.Execute();
            

        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // YouTube 비디오 Play를 위한 URL 생성 
                string videoId = listView1.SelectedItems[0].Name;
                string youtubeUrl = "http://youtube.com/watch?v=" + videoId;
                var youtube = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyAzrH0jMEcjFb7MFWxwFu9-tfAFUIx9dO8", // 키 지정
                    ApplicationName = "My YouTube Search"
                });
                var request = youtube.Search.List("contentDetails.definition");
                var result = await request.ExecuteAsync();
                MessageBox.Show(result.Items[0].Id.VideoId);
                // 디폴트 브라우져에서 실행
                YoutubeWallpaper.Form_Main f = new YoutubeWallpaper.Form_Main();
                Option o = new Option();
                o.Id = videoId;
                StringBuilder url = new StringBuilder(@"https://www.youtube.com/");
                url.Append(@"v/");
                url.Append(videoId);
                url.Append(@"&autoplay=1&loop=1&controls=0&showinfo=0&autohide=1&modestbranding=1&rel=0");
                url.Append("&vq=");
                url.Append("medium");
                m_wallpaper = new Form_Wallpaper(0);
                m_wallpaper.Volume = 20;
                m_wallpaper.Show();
                if (m_touchpad != null)
                {
                    m_touchpad.Target = m_wallpaper;
                }

                if (m_wallpaper.IsFixed)
                {
                    m_wallpaper.Uri = url.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TextMorphing
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = loginserver(2);
            if (result == 2)
            {
                MessageBox.Show("Login Succesful", "login", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error Occured", "login", MessageBoxButtons.OK);
            }
        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        public int loginserver(int status)
        {
            int result;
            switch (status)
            {
                case 1: //
                    HttpWebRequest register_request = (HttpWebRequest)WebRequest.Create("http://hansung.info:50000/register");
                    string postData = "username=" + "&id=ayh0729&password=1234";//JsonConvert.SerializeObject(u);
                    var data = Encoding.ASCII.GetBytes(postData);
                    register_request.Method = "POST";
                    register_request.ContentType = "application/x-www-form-urlencoded";

                    register_request.ContentLength = data.Length;
                    using (var stream = register_request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    var response = (HttpWebResponse)register_request.GetResponse();
                    string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    result = 1;
                    break;
                case 2:
                    try
                    {
                        HttpWebRequest login_request = (HttpWebRequest)WebRequest.Create("http://hansung.info:50000/login");
                        string login_postData = "id=" + textBox1.Text + "&password=" + textBox2.Text;//JsonConvert.SerializeObject(u);
                        var login_data = Encoding.ASCII.GetBytes(login_postData);
                        login_request.Method = "POST";
                        login_request.ContentType = "application/x-www-form-urlencoded";

                        login_request.ContentLength = login_data.Length;
                        using (var stream = login_request.GetRequestStream())
                        {
                            stream.Write(login_data, 0, login_data.Length);
                        }

                        var login_response = (HttpWebResponse)login_request.GetResponse();
                        var login_responseString = new StreamReader(login_response.GetResponseStream()).ReadToEnd();
                        //MessageBox.Show(login_responseString);
                        if (login_responseString.Contains("false"))
                        {
                            result = -1;
                        }
                        else
                        {
                            result = 2;
                        }
                    }
                    catch (WebException ex)
                    {
                        if (ex.Status == WebExceptionStatus.ProtocolError)
                        {
                            HttpWebResponse resp = ex.Response as HttpWebResponse;
                            if (resp != null && resp.StatusCode == HttpStatusCode.NotFound)
                            {
                                MessageBox.Show("Server is currentely down or server address changed.", "login error", MessageBoxButtons.OK);
                            }
                        }
                        result = -1;
                    }

                    break;
                case 3:
                    HttpWebRequest removerequest = (HttpWebRequest)WebRequest.Create("http://hansung.info:50000/remove");
                    result = 3;
                    break;
                default:
                    result = -1;
                    break;
            }

            return result;

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

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //textBox1.BackColor = Color.FromArgb(100, 0, 0, 0);
            //textBox2.BackColor = Color.FromArgb(0, 0, 0, 0);
            button1.FlatAppearance.BorderColor = Color.White;

            button1.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.BorderColor = Color.White;
            int hour = DateTime.Now.Hour;
            if (hour >= 22 || hour <= 4)
            {
                //밤에는 버튼 배경이 반투명한 흰색
                button1.BackColor = Color.FromArgb(100, 255, 255, 255);
                button2.BackColor = Color.FromArgb(100, 255, 255, 255);
                //밤일때
                Random r = new Random(unchecked((int)DateTime.Now.Ticks) + 1);
                int random = r.Next(1, 9);
                switch (random)
                {
                    case 1:
                        BackgroundImage = Properties.Resources.n1;
                        break;
                    case 2:
                        BackgroundImage = Properties.Resources.n2;
                        break;
                    case 3:
                        BackgroundImage = Properties.Resources.n3;
                        break;
                    case 4:
                        BackgroundImage = Properties.Resources.n4;
                        break;
                    case 5:
                        BackgroundImage = Properties.Resources.n5;
                        break;
                    case 6:
                        BackgroundImage = Properties.Resources.n6;
                        break;
                    case 7:
                        BackgroundImage = Properties.Resources.n7;
                        break;
                    case 8:
                        BackgroundImage = Properties.Resources.n8;
                        break;
                    case 9:
                        BackgroundImage = Properties.Resources.n9;
                        break;
                    default:
                        break;
                }

            }
            else
            { //낮
                //낮에는 버튼 배경이 반투명한 검정
                button1.BackColor = Color.FromArgb(100, 0, 0, 0);
                button2.BackColor = Color.FromArgb(100, 0, 0, 0);
                Random r = new Random();
                int random = r.Next(1, 9);
                switch (random)
                {
                    case 1:
                        BackgroundImage = Properties.Resources.b1;
                        break;
                    case 2:
                        BackgroundImage = Properties.Resources.b2;
                        break;
                    case 3:
                        BackgroundImage = Properties.Resources.b3;
                        break;
                    case 4:
                        BackgroundImage = Properties.Resources.b4;
                        break;
                    case 5:
                        BackgroundImage = Properties.Resources.b5;
                        break;
                    case 6:
                        BackgroundImage = Properties.Resources.b6;
                        break;
                    case 7:
                        BackgroundImage = Properties.Resources.b7;
                        break;
                    case 8:
                        BackgroundImage = Properties.Resources.b8;
                        break;
                    case 9:
                        BackgroundImage = Properties.Resources.b9;
                        break;
                    default:
                        break;
                }
                //낮일때
            }
        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            textBox1.BorderStyle = BorderStyle.None;
            Pen p = new Pen(Color.White);
            Graphics g = e.Graphics;
            int variance = 3;
            g.DrawRectangle(p, new Rectangle(textBox1.Location.X - variance, textBox1.Location.Y - variance, textBox1.Width + variance, textBox1.Height + variance));
            g.DrawRectangle(p, new Rectangle(textBox2.Location.X - variance, textBox2.Location.Y - variance, textBox2.Width + variance, textBox2.Height + variance));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRegister f = new FormRegister();
            f.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult d = new DialogResult();
            Application.Exit();
        }
    }
}

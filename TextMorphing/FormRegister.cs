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

namespace TextMorphing
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest register_request = (HttpWebRequest)WebRequest.Create("http://hansung.info:50000/register");
            string postData = "username=" + textBox1.Text + "&id=" + textBox2.Text + "&password=" + textBox3.Text;//JsonConvert.SerializeObject(u);
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

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace zdzhantai
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
      
        public string abc;
        static string path = Environment.CurrentDirectory.ToString();
        static string urlfilename = path + "url.txt";
        public Window1()
        {
            InitializeComponent();
            //zdSetting zds = new zdSetting();
            //zds.textEvent += new TextDelegateHander(getMessage);
            //MessageBox.Show(abc);
            //zds.Show();
            zdSetting zds = new zdSetting();
            this.abc = zds.serverurl;
            this.textChange.Text = abc;
            myRequest();

        }
        private void getMessage(string message) {
            //this.textChange.Text = message;
            this.abc = message;
        }

        public static void myRequest()
        {
            //string url = setting.serverUrl;
            string url = myfile.ReadFile(1);
            if (url.Equals("NULL") == true)
            {
                MessageBox.Show("请去设置页面设置服务器地址！！！");
            }
            else
            {
                WebRequest webrequest = WebRequest.Create(url);
                WebResponse webresponse = webrequest.GetResponse();
                webrequest.Timeout = 10000;
                Stream stream = webresponse.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string content = sr.ReadToEnd().ToString();
                webresponse.Close();

                webrequest.Abort();
                System.GC.Collect();
                MessageBox.Show(content);
            }
        }    
    }
}

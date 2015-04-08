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
            myRequest();

        }
      
        public static void myRequest()
        {
            //string url = setting.serverUrl;
            //string url = myfile.ReadFile(1);
            string url = Conf.getUrl();
            string content = "NULL";
            if (url.Equals("NULL") == true)
            {
                MessageBox.Show("请去设置页面设置服务器地址！！！");
            }
            else
            {
                try
                {
                    WebRequest webrequest = WebRequest.Create(url);                  
                    WebResponse webresponse = webrequest.GetResponse();
                    webrequest.Timeout = 10000;
                    Stream stream = webresponse.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    content = sr.ReadToEnd().ToString();
                    webresponse.Close();
                    webrequest.Abort();
                    System.GC.Collect();
                    MessageBox.Show(content);
                }
                catch (UriFormatException e)
                {
                    MessageBox.Show("您输入的地址不规范，请重新输入地址！");
                }
                catch (System.Net.WebException e) {
                    MessageBox.Show("您输入的地址不规范，请重新输入地址！");
                }
            }
        }    
    }
}

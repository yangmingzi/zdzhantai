using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Net;

namespace zdzhantai
{
    class connectServerl
    {
        public static void myRequest()
        {
            //string url = setting.serverUrl;
            //string url = myfile.ReadFile(1);
            string result = null;
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
                     string path = Environment.CurrentDirectory.ToString();       
                     string urlfilename  = path+"url.txt";
                     string userfilename = path+"name.txt";
                     string passfilename = path+"password.txt";
                    // myfile.CreateFile(userfilename);
                     result = content;
                     
                }
                catch (UriFormatException e)
                {
                    MessageBox.Show("您输入的地址不规范，请重新输入地址！");
                }
                catch (System.Net.WebException e)
                {
                    MessageBox.Show("您输入的地址不规范，请重新输入地址！");
                }
            }
        }

        public static string myRequest1()
        {
            //string url = setting.serverUrl;
            //string url = myfile.ReadFile(1);
            string result = null;
            string url = Conf.getUrl();
            string content = "NULL";
            if (url.Equals("NULL") == true)
            {
                //MessageBox.Show("请去设置页面设置服务器地址！！！");
                string s = "请去设置页面设置服务器地址！！！";
                return s;
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
                    content = sr.ReadToEnd().ToString().Trim();
                    webresponse.Close();
                    webrequest.Abort();
                    System.GC.Collect();
                    //MessageBox.Show(content);
                    string path = Environment.CurrentDirectory.ToString();
                    string urlfilename = path + "url.txt";
                    string userfilename = path + "name.txt";
                    string passfilename = path + "password.txt";
                    // myfile.CreateFile(userfilename);
                    result = content;
                    return result;
                    MessageBox.Show(result);
                    
                }
                catch (UriFormatException e)
                {
                    //MessageBox.Show("您输入的地址不规范，请重新输入地址！");
                    return result;
                }
                catch (System.Net.WebException e)
                {
                    //MessageBox.Show("您输入的地址不规范，请重新输入地址！");
                    return result;
                }
            }
        }    
    }
}

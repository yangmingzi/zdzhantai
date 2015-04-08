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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Data.SQLite;
using Dell;
using System.IO;
namespace zdzhantai
{
    /// <summary>
    /// zdSetting.xaml 的交互逻辑
    /// </summary>
    //public delegate void TextDelegateHander(string message);
    public partial class zdSetting : Window
    {       
        public string serverurl;
        public string comNumber;
        static string path = Environment.CurrentDirectory.ToString();      
        public zdSetting()
        {
            InitializeComponent();         
            textBtn.Click+=new RoutedEventHandler( Button_Click_1);               
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.texturl.Text != null)
            {
                serverurl = this.texturl.Text.ToString();
                Conf.setServerUrl(serverurl);
                Conf.getUrl();
                connectServerl.myRequest();
            }
            else { MessageBox.Show("请填写服务器地址！！"); }
            if (this.textcom.Text != null)
            {
                comNumber = this.textcom.Text.ToString();
                Conf.setCOM(comNumber);
            }
            else { MessageBox.Show("请填写COM口号！"); }
            this.Close();
        }

        private void comClick(object sender, RoutedEventArgs e)
        {
            if (this.textcom.Text != null)
            {
                comNumber = this.textcom.Text.ToString();
                Conf.setCOM(comNumber);
            }
            else { MessageBox.Show("请填写COM口号！"); }
            this.Close();
        }
    }
}

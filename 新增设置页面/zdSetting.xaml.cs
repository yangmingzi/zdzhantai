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
        //public event TextDelegateHander textEvent;
        public string serverurl;
        static string path = Environment.CurrentDirectory.ToString();
        static string urlfilename = path + "url.txt";
        static string userfilename = path + "name.txt";
        static string passfilename = path + "password.txt";
        public static string cmdChangeurlText = "UPDATE settingUse SET  url= values() WHERE ID=1";
        public zdSetting()
        {
            InitializeComponent();
            //serverurl = this.texturl.Text.ToString();
            textBtn.Click+=new RoutedEventHandler( Button_Click_1);               
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.texturl.Text != null) {
                serverurl = this.texturl.Text.ToString();
                myfile.WriteFile(urlfilename, serverurl);
                this.Close();
            }
        }
        //private void signUp_Click(object sender, RoutedEventArgs e)
        //{
        //    string name = this.idText.Text;
        //    string passsword = this.passwordText.Text;


        //}
    }
}

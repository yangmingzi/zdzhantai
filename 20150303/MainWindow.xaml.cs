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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Data.SQLite;
using Dell;
using System.IO;
namespace zdzhantai
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            initSqlite.initUpdateTable();
            initSqlite.initUsingTable();
            Update();         
            InitializeComponent();            
        }
      
         public static void  Update()
        {
            int j = updateSq.checkLastUpdate();
            Thread t = new Thread(updateSq.UpdateFromServer);
            t.Start();
        }
        private void Button_Click_image(object sender, RoutedEventArgs e)
        {
            img_play win = new img_play();
            win.changeIndex(Environment.CurrentDirectory.ToString() + "/Image");
            win.Show();
        }
        private void Button_Click_aboutZd(object sender, RoutedEventArgs e)
        {
            //about_cp win = new about_cp();
            img_play win = new img_play();
            win.changeIndex( Environment.CurrentDirectory.ToString() + "/zdimg");
            win.Show();
        }

       
        private void Button_Click_Close (object sender, RoutedEventArgs e)
        {
            this.Close();
        }
      

        private void Button_Click_trace(object sender, RoutedEventArgs e)
        {
            trace win = new trace();
            win.Show();
        }

    }
}

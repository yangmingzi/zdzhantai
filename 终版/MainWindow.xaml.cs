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
using System.Runtime.InteropServices;
using System.Timers;

namespace zdzhantai
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        public MainWindow()
        {
           
            initSqlite.initUpdateTable();
            initSqlite.initUsingTable();
            //initSqlite.initSettingTable();        
           // Update();
            //img_play.InitListFromTable();
            Conf.createConfTable();
            int a = Conf.getCloums();
            Conf.setServerUrl("http://10.108.158.5:8080/cpServerPro/interface.jsp?requestType=exhibition");
            //connectServerl.myRequest();
           // MessageBox.Show(Conf.getUrl());
            //this.timer1_Tick += new EventHandler<EventArgs>(timer1_Tick);
            //this.timer +=
            timer.Elapsed += new ElapsedEventHandler(timer1_Tick);
            timer.Interval = 1000;
            timer.Enabled = true;
            GC.KeepAlive(timer);
            InitializeComponent();
            //myfile.CreateFile("abc.txt");
            string s = connectServerl.myRequest1();
           // MessageBox.Show(s);
            string path = Environment.CurrentDirectory.ToString();           
            string userfilename = path+"name.txt";
            myfile.WriteFile(userfilename, s);

        }
        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public uint dwTime;
        }
        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        private static long GetLastInputTime()
        { 
            LASTINPUTINFO vLastInputInfo = new LASTINPUTINFO();
            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            if (!GetLastInputInfo(ref vLastInputInfo))
                return 0;
            long spanTime = Environment.TickCount - (long)vLastInputInfo.dwTime;

            return 
                Environment.TickCount - (long)vLastInputInfo.dwTime;

        }
        public void timer1_Tick(object sender, ElapsedEventArgs e)
        {
            long time = GetLastInputTime();
            if (time >= 5500 && time<=6500)
            {
                //MessageBox.Show("5 seconds no action");      
                //timer.Enabled = false;
                ThreadStart threadstart1 = showMedia;
                Thread thread = new Thread(threadstart1);
                thread.Start();
                //timer.Enabled = true;
            }
        }
        private void rightButtonClick(object sender, MouseEventArgs e)
        {
            zdSetting win = new zdSetting();
            win.Show();
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
            //win.changeIndex(Environment.CurrentDirectory.ToString() + "/Image");
            win.changeIndex("fileUpdate");
            win.Show();
        }
        private void Button_Click_aboutZd(object sender, RoutedEventArgs e)
        {          
            img_play win = new img_play();
           // win.changeIndex( Environment.CurrentDirectory.ToString() + "/Image");
            win.changeIndex("fileUsing");
            win.Show();
        }

       
        private void Button_Click_Close (object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void showMedia()
        {
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                Media win = new Media();
                win.Show();
            }));
        }
        private void Button_Click_trace(object sender, RoutedEventArgs e)
        {
            
            
            ////Media win = new Media();
            Window1 win = new Window1();
            win.Show();
            //showMedia();
        }

        private void seting_button_click(object sender, RoutedEventArgs e)
        {
            zdSetting win = new zdSetting();
            win.Show();
        }

    }
}

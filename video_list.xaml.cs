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
using System.Runtime.InteropServices;
using System.Windows.Threading;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace zdzhantai
{
    /// <summary>
    /// Window4.xaml 的交互逻辑
    /// </summary>
    public partial class Window4 : Window
    {
        private bool fullscreen = false;
        private DispatcherTimer DoubleClickTimer = new DispatcherTimer();
        ObservableCollection<MediaElement> mediaList;
        ObservableCollection<UserControl1> us_array;
        public Window4()
        {
            InitializeComponent();
            //this.listview1.View = ViewBase.Equals();
            //UserControl1 us11 = new UserControl1();
            //UserControl1 usl2 = new UserControl1();
            //UserControl1 usl3 = new UserControl1();
            //UserControl1 us14 = new UserControl1();
            //this.listview1.View = (System.Windows.Controls.ViewBase)View.LargeIcon;
            //this.Content = us1;
            //this.listview1.View = View.LargeIcon;
            //this.listview1.LargeImageList = 
            //this.listview1.BeginInit();
            //for (int i = 0; i < 10; i++)
            //{

            //this.listview1.Items.Add(us11);
            //this.listview1.Items.Add(usl2);
            //this.listview1.Items.Add(usl3);
            //this.listview1.Items.Add(us14);
            //}
            //this.listview1.EndInit();
            //us11.media.Play();        
            //usl2.media.Play();
            //usl3.media.Play();           
            //us14.media.Play();
          
            //InitMediaList();
            // Uri url1 = new Uri(mList[0].Substring(0));
            //this.media5.Source = url1;
            //this.media5 = mediaList[0];
            //this.media1.Source = (new Uri(mList[0].Substring(0)));
            //this.media2.Source = (new Uri(mList[1].Substring(0)));
            //this.media3.Source = (new Uri(mList[2].Substring(0)));
            //this.media1.Play();

            InitUsList();
            int j = us_array.Count();
            for (int i = 0; i < j; i++)
            {
                this.listview1.Items.Add(us_array[i]);
                us_array[i].media.Play();
                us_array[i].media.Pause();
            }
            
            
        }

        private void MediaPlayer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           
            if (!DoubleClickTimer.IsEnabled)
            {
                DoubleClickTimer.Start();
            }
            else
            {
                if (!fullscreen)
                {
                    this.WindowStyle = WindowStyle.None;
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    //this.WindowStyle = WindowStyle.SingleBorderWindow;
                    this.WindowState = WindowState.Normal;
                }

                fullscreen = !fullscreen;
            }

            //Window5 win = new Window5();
            //win.media5.Source = "";
            //win

        }
        [DllImport("user32.dll")]
        private static extern uint GetDoubleClickTime();

        List<string> mList = new List<string>();
        private void InitUsList()
        {
            mList = System.IO.Directory.GetFiles("D:/VSPROJECT/zdzhantai/zdzhantai/Video/").ToList();

            us_array = new ObservableCollection<UserControl1>();
            for (int i = 0; i < mList.Count; i++)
            {
                Uri url = new Uri(mList[i].Substring(0));
                
                UserControl1 us = new UserControl1();
                us.BeginInit();
                us.media.Source = url;
                us.EndInit();
                us_array.Add(us);
            }
        }
    }
}

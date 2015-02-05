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
using System.Timers;

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
        List<string> mList = new List<string>();
     
        Random random = new Random();  
        public Window4()
        {
            InitializeComponent();        
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitUsList();
            int video_num = mList.Count();
            for (int i = 0; i < video_num; i++)
            {
                int row = i / 2;
                int col = i % 2;
                if (col == 0)
                { 
                    RowDefinition row1 = new RowDefinition();
                    grid1.RowDefinitions.Add(row1);
                }               
                Grid.SetRow(us_array[i],row);
                Grid.SetColumn(us_array[i],col);
                grid1.Children.Add(us_array[i]);
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

       
        private void InitUsList()
        {
            mList = System.IO.Directory.GetFiles("D:/VSPROJECT/zdzhantai/zdzhantai/Video/").ToList();

            us_array = new ObservableCollection<UserControl1>();//必须先初始化
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

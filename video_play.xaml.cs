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


namespace zdzhantai
{
    /// <summary>
    /// Window5.xaml 的交互逻辑
    /// </summary>
    public partial class Window5 : Window
    {
        private bool fullscreen = false;
        private DispatcherTimer DoubleClickTimer = new DispatcherTimer();
      
        ObservableCollection<MediaElement> mediaList;
        StackPanel sp = new StackPanel();
        public Window5()
        {
            InitializeComponent();
            InitMediaList();
            Uri url1 = new Uri(mList[0].Substring(0));
            this.media5.Source = url1;
            //this.media5 = mediaList[0];
            this.media5.LoadedBehavior = MediaState.Manual;
            ////this.media5.UnloadedBehavior = MediaState.Manual;
            //this.media5.ScrubbingEnabled = true;
            this.media5.Play();
            this.media5.Pause();
            
            
            
            //this.media5.Play();
            DoubleClickTimer.Interval = TimeSpan.FromMilliseconds(GetDoubleClickTime());
            DoubleClickTimer.Tick += (s, e) => DoubleClickTimer.Stop();
        }

        private void MediaPlayer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.media5.Play();
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

        }
        [DllImport("user32.dll")]
        private static extern uint GetDoubleClickTime();
       
       
        private void Button_Click_Over(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_Play(object sender, System.Windows.RoutedEventArgs e)
        {
            this.media5.Play();
        }

        List<string> mList = new List<string>();
       
        private void InitMediaList()
        {
            mList = System.IO.Directory.GetFiles("D:/VSPROJECT/zdzhantai/zdzhantai/Video/").ToList();

            //mediaList = new ObservableCollection<MediaElement>();
            //for (int i = 0; i < mList.Count; i++)
            //{

            //    Uri url = new Uri(mList[i].Substring(0));
            //    MediaElement media = new MediaElement();
            //    media.BeginInit();
            //    media.Source = url;
            //    media.EndInit();
            //    mediaList.Add(media);
            //}
        }
    }
}

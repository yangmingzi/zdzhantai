using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace zdzhantai
{
    /// <summary>
    /// Media.xaml 的交互逻辑
    /// </summary>
    public partial class Media : Window
    {
        double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
        double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
        double x1= SystemParameters.PrimaryScreenWidth;//得到屏幕整体宽度
        double y1 = SystemParameters.PrimaryScreenHeight;//得到屏幕整体高度
        ObservableCollection<MediaElement> mediaList;
        List<string> list = new List<string>();
        List<Uri> uriList = new List<Uri>();
        int meNum = 0;
        public Media()
        {
            InitializeComponent();
            initUriList();
            //initMediaList();           
            this.Media1.Height = x1 * 2;
            this.Media1.Width = y1 * 2;
            this.Media1.Source = uriList[0]; ;
            this.Media1.LoadedBehavior = MediaState.Manual;
            this.Media1.Play();
            meNum += 1;
            //playMediaList();
        }

        private void mediaMouseClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void mediaTouchDown(object sender, TouchEventArgs e)
        {
            this.Close();
        }

        private void mediaKeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
        public void initUriList()
        {
            string root = Environment.CurrentDirectory.ToString();
            string mulu = root + "/Video";
            list = System.IO.Directory.GetFiles(mulu).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Uri url = new Uri(list[i].Substring(0));
                uriList.Add(url);
            }         
        }
        public void initMediaList()
        {                   
            mediaList = new ObservableCollection<MediaElement>();
            for (int i = 0; i < list.Count; i++)
            {
                Uri url = new Uri(list[i].Substring(0));
                MediaElement me = new MediaElement();
                me.BeginInit();
                me.Source = url;
                me.EndInit();              
                mediaList.Add(me);
            }         
        }

        //public void playMediaList()
        //{
        //    for (int i = 0; i <mediaList.Count(); i++)
        //    {
        //        //if(i==mediaList.Count())
        //        //{
        //        //    playMediaList();
        //        //}
        //        this.Media1 = mediaList[i];
        //        //this.Media1.Position = new TimeSpan(0);               
        //        this.Media1.LoadedBehavior = MediaState.Manual;
        //        this.Media1.Play(); 
                
        //    }
        //}
        private void MediaEnd(object sender, RoutedEventArgs e)
        {
            //注意此处循环逻辑。在上文一开始就将meNum置0，然后播放
            //然后加1，当第一次播放结束是触发这个函数
            //先播放，在改meNum值
            playSureMedia(meNum);
            if (meNum == uriList.Count()-1) { meNum = 0; }
            else{
                meNum += 1;           
            }           
        }

        public void playSureMedia(int meNum)
        {
            this.Media1.Source = uriList[meNum];
            this.Media1.Position = new TimeSpan(0);
            this.Media1.LoadedBehavior = MediaState.Manual;
            this.Media1.Play();
        }

    }
}

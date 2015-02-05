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
using System.Runtime.InteropServices;
using System.Windows.Threading;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace zdzhantai
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : System.Windows.Controls.UserControl
    {
        private bool fullscreen = false;
        private DispatcherTimer DoubleClickTimer = new DispatcherTimer();
        ObservableCollection<MediaElement> mediaList;
        public UserControl1()
        {
            InitializeComponent();
         
            //this.media.Play();
            //this.media.Pause();            
        }

        //public static readonly RoutedEvent  MediaClick =
        //  EventManager.RegisterRoutedEvent("MouseDoubleClick",
        //   RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<DateTime>), typeof(UserControl1));


        //protected virtual void MediaPlay()
        //{
        //    //RoutedPropertyChangedEventArgs<DateTime> arg =
        //    //    new RoutedPropertyChangedEventArgs<DateTime>(oldValue, newValue, TimeUpdatedEvent);
        //    //this.RaiseEvent(arg);
        //    this.meida.Play();
            
        //}
        //public string getTextValue() { }
        //public string text {
        //    get { return (string)this.getTextValue(TextProperty); }
        //    set { this.SetValue(TextProperty, value); }
        //}
        //public string mediaSource { }
        private void MediaPlayer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window5 win = new Window5();
            win.media5.Source = this.media.Source;
           
            win.Show();
            win.media5.Play();
            win.media5.Pause();
        }
      
    }
}

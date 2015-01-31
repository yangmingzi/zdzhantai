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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace zdzhantai
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        ObservableCollection<BitmapImage> bmList;
        int index = 0;
        BackgroundWorker bw = new BackgroundWorker();

        public Window1()
        {
            InitializeComponent();
            
            InitList();
            //CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
            //bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            btn1.Click += new RoutedEventHandler(Button_Click_1);
            btn2.Click += new RoutedEventHandler(Button_Click_2);
            btn3.Click += new RoutedEventHandler(Button_Click_3);
            btn4.Click += new RoutedEventHandler(Button_Click_4);
        }


        List<string> list = new List<string>();
      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                this.img1.Source = bmList[index];
            }
            else
            {
                index = bmList.Count - 1;
                this.img1.Source = bmList[index];
            }
            //this.img1.Source = bmList[0];
           
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (index <(bmList.Count))
            {
               
                this.img1.Source = bmList[index];
                index++;
            }
            else
            {
                index = 0;
                this.img1.Source = bmList[index];
            }
        }
       

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        bool flag = true;
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                bw.RunWorkerAsync();
                flag = false;
                (sender as Button).Content = "End";
            }
            else
            {
                flag = true;
                (sender as Button).Content = "Start";
            }
        }

        //void bw_DoWork(Object sender, DoWorkEventArgs e)
        //{
        //    while (!e.Cancel)
        //    {
        //        Button_Click_2(sender, new RoutedEventArgs());
        //        System.Threading.Thread.Sleep(2000);
        //        e.Cancel = flag;
        //    }
        //}
        public void InitList()
        {
            //list = System.IO.Directory.GetFiles(".../.../Image/").ToList();
            list = System.IO.Directory.GetFiles("D:/VSPROJECT/zdzhantai/zdzhantai/Image/").ToList();

            bmList = new ObservableCollection<BitmapImage>();
            for (int i = 0; i < list.Count; i++)
            {
                
                Uri url = new Uri(list[i].Substring(0));
                //MessageBox.Show(url.ToString());
                
                BitmapImage bmImg = new BitmapImage();
                bmImg.BeginInit();
                bmImg.UriSource = url;
                bmImg.EndInit();

                //bmImg.BeginInit();
                //Uri urd = new Uri("D:/VSPROJECT/zdzhantai/zdzhantai/Image/james1.jpg");
                //bmImg.UriSource = urd;
                //bmImg.EndInit();
                bmList.Add(bmImg);
                //this.img1.Source = bmImg;
            }
            //MessageBox.Show(list[0]);
            //MessageBox.Show(list[1]);
            //this.img1.Source = bmList[1];
        }

        //void CompositionTarget_Rendering(Object sender, EventArgs e)
        //{
        //    this.img1.Source = bmList[index];

        //    //this.img1.Width = this.img1.Source.Width;
        //    //this.img1.Height = this.img1.Source.Height;
        //}

    }
}

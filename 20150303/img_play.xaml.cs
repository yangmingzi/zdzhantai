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
    public partial class img_play : Window
    {
        public string mulu ;

        ObservableCollection<BitmapImage> bmList;
        int index = 0;

        public void changeIndex(String newIndex)
        {
            mulu = newIndex;
            InitList();
        }
        public img_play()
        {
            InitializeComponent();
            btn1.Click += new RoutedEventHandler(Button_Click_1);
            btn2.Click += new RoutedEventHandler(Button_Click_2);
            btn3.Click += new RoutedEventHandler(Button_Click_3);
        }

       
        List<string> list = new List<string>();
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                img_show(bmList[index]);
            }
            else
            {
                index = bmList.Count - 1;
                img_show(bmList[index]);
            }            
        }

        public void img_show(BitmapImage img)
        {
            this.Background = new ImageBrush(img);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (index <(bmList.Count))
            {                            
                img_show(bmList[index]);
                index++;
            }
            else
            {
                index = 0;
                img_show(bmList[index]);
            }
        }
       

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
      
      
       
        public void InitList()
        {
            list = System.IO.Directory.GetFiles(mulu).ToList();

            bmList = new ObservableCollection<BitmapImage>();
            for (int i = 0; i < list.Count; i++)
            {
                
                Uri url = new Uri(list[i].Substring(0));
                BitmapImage bmImg = new BitmapImage();
                bmImg.BeginInit();
                bmImg.UriSource = url;
                bmImg.EndInit();
                bmList.Add(bmImg);
            }
          
        }
    }
}

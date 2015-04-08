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
using System.Data.SQLite;
using Dell;
using System.Diagnostics;

namespace zdzhantai
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
   
    public partial class img_play : Window
    {
        public static string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
        public string mulu ;
        ObservableCollection<BitmapImage> bmList;
        ObservableCollection<BitmapImage> bmList1;
        int index = 0;
        public TouchPoint down;
        public TouchPoint up;
        public TouchPoint leave;
        public void changeIndex(String newIndex)
        {
            mulu = newIndex;
            //InitList();
            InitListFromTable(newIndex);
            //InitListFromFolder(newIndex);
        }
        public img_play()
        {
            InitializeComponent();
            btn3.Click += new RoutedEventHandler(Button_Click_3);
            this.TouchDown += new EventHandler<TouchEventArgs>(touchdown);          
            this.TouchLeave += new EventHandler<TouchEventArgs>(touchleave);
        }

       
        List<string> list = new List<string>();
        private void touchdown(object sender, TouchEventArgs e)
        {
            down = e.GetTouchPoint(this);
        }


        private void touchleave(object sender, TouchEventArgs e)
        {
            
            leave = e.GetTouchPoint(this);
            double downx = down.Position.X;
            double leaveX = leave.Position.X;
            if (downx - leaveX > 10) {
                leftPlayImage();
            }
            else if (downx - leaveX < -10)
            {
                rightPlayImage();
            }
            else {
                showText();
            }

        }

        public void leftPlayImage() {
            hiddenText();
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

        public void rightPlayImage() {
            hiddenText();
            if (index < (bmList.Count))
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

        public void showText()
        {
            this.text1.Visibility = Visibility.Visible;
        }
        public void hiddenText()
        {
            this.text1.Visibility = Visibility.Hidden;
        }

        public void img_show(BitmapImage img)
        {
            this.Background = new ImageBrush(img);
        }
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


        public  void InitListFromTable(string tableName)
        { 
            Ops op = new Ops(dbPath);
            string cmdQueryFront = "SELECT * FROM ";
            string cmdQueryBack = " WHERE state=1";
            string cmdQuery = cmdQueryFront + tableName + cmdQueryBack;
            SQLiteDataReader sdr = op.noChangeCommand(cmdQuery);
            List<string> list = new List<string>();
            
            while (sdr.Read())
            {
                int i1 = sdr.GetInt32(2);
                string s2 = sdr.GetString(3);
                list.Add(s2);
            }
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
       
        public void InitListFromFolder()
        {
            list = System.IO.Directory.GetFiles(mulu).ToList();

            bmList1 = new ObservableCollection<BitmapImage>();
            for (int i = 0; i < list.Count; i++)
            {
                
                Uri url = new Uri(list[i].Substring(0));
                BitmapImage bmImg = new BitmapImage();
                bmImg.BeginInit();
                bmImg.UriSource = url;
                bmImg.EndInit();
                bmList1.Add(bmImg);
            }         
        }          
    }
}



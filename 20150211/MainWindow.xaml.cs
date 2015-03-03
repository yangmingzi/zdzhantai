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
            win.Show();

        }
        private void Button_Click_aboutZd(object sender, RoutedEventArgs e)
        {
            about_cp win = new about_cp();
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

        //public static Ops bulidOp()
        //{
        //    string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
        //    Ops Op = new Ops(dbPath);
        //    return Op;
        //}
        //public static void UpdateFromServer()
        //{
        //    //string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
        //    string filePath;
        //    Ops Op = bulidOp();

        //    string cmdInsertText1 = "INSERT INTO fileUpdate VALUES(@type,@url,@filename,@filepath,@state)";
           

        //    //// 数组  【】    对象{}     值“”
        //    string json1 = "{type:'image',url:'http://i1.hoopchina.com.cn/blogfile/201501/08/BbsImg142070525332424_550*550.jpg'}";
        //    string json2 = "{type:'video',url:'http://i2.hoopchina.com.cn/blogfile/201411/27/BbsImg141707487288557_1271*988.jpg'}";
        //    //string json2 = "{type:'video',url:'http://v.youku.com/v_show/id_XODczMTA2OTc2.html'}";
        //    string json3 = "{type:'image',url:'http://i1.hoopchina.com.cn/blogfile/201304/09/136548593327743.jpg'}";
        //    string jsonString = "[" + json1 + "," + json2 + "," + json3 + "]";


        //    //Ops Op = new Ops(dbPath);

        //    StringBuilder sb = new StringBuilder();
        //    JArray array1 = (JArray)JsonConvert.DeserializeObject(jsonString);
        //    for (int i = 0; i < 3; ++i)
        //    {
        //        WebClient mywebclient = new WebClient();
        //        JObject jo = (JObject)array1[i];
        //        string url = jo["url"].ToString();
        //        string newfilename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
        //            + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + i + ".jpg";
        //        //下载很快，如果不在文件名加入i的话，会在一秒内下载完，使用时间当做文件名，最后就只剩一个文件。
        //        //string filePath = @"D:\VSPROJECT\WindowsFormsApplication3\" + newfilename;

        //        if (jo["type"].ToString().Equals("image"))
        //            filePath = @Environment.CurrentDirectory + "/Image/" + newfilename;
        //        else if (jo["type"].ToString().Equals("video"))
        //            filePath = @Environment.CurrentDirectory + "/Video/" + newfilename;
        //        else
        //            filePath = @"D:\";
        //        try
        //        {
        //            mywebclient.DownloadFile(url, filePath);
        //            SQLiteParameter[] Params1 = new SQLiteParameter[] {
        //                                                       new SQLiteParameter("@type", jo["type"]),
        //                                                       new SQLiteParameter("@url", jo["url"]),
        //                                                       new SQLiteParameter("@filename", newfilename),
        //                                                       new SQLiteParameter("@filepath", filePath),
        //                                                       new SQLiteParameter("@state", 1) };

        //            if (File.Exists(filePath))
        //            {
        //                Op.PrepareCommand(cmdInsertText1, Params1);
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.ToString());
        //        }
        //    }
           
        //    int j = updateSq.checkLastUpdate();

        //}

       
      

    }
}

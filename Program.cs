using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Data.SQLite;
using Dell;
using System.IO;

namespace zdExhibition1
{
    
    class Exh
    {
        static void UpdateFromServer() {


            Ops.initUpdateTable();
            Ops.initUsingTable();

            //string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            //string filePath;


            //string cmdInsertText1 = "INSERT INTO fileUpdate VALUES(@type,@url,@filename,@filepath,@state)";
            //string cmdInsertText = "INSERT INTO fileUpdate VALUES(@type,@url,@filename,@filepath)";
            //string cmdReadText = "SELECT * FROM worker";
            //string cmdDeleteText = "DELETE FROM worker WHERE (ID =(@id) OR name=(@name) OR sex =(@sex))";
            //string cmdQueryText = "SELECT  (@state) FROM fileUpdate";
            //string cmdCheckText = "UPDATE fileUpdate SET state = 1 WHERE filename = (@name)";

            //// 数组  【】    对象{}     值“”
            //string json1 = "{type:'image',url:'http://i1.hoopchina.com.cn/blogfile/201501/08/BbsImg142070525332424_550*550.jpg'}";
            //string json2 = "{type:'video',url:'http://i2.hoopchina.com.cn/blogfile/201411/27/BbsImg141707487288557_1271*988.jpg'}";
            ////string json2 = "{type:'video',url:'http://v.youku.com/v_show/id_XODczMTA2OTc2.html'}";
            //string json3 = "{type:'image',url:'http://i1.hoopchina.com.cn/blogfile/201304/09/136548593327743.jpg'}";
            //string jsonString = "[" + json1 + "," + json2 + "," + json3 + "]";


            //Ops Op = new Ops(dbPath);

            //StringBuilder sb = new StringBuilder();
            //JArray array1 = (JArray)JsonConvert.DeserializeObject(jsonString);
            //for (int i = 0; i < 3; ++i)
            //{
            //    WebClient mywebclient = new WebClient();
            //    JObject jo = (JObject)array1[i];
            //    string url = jo["url"].ToString();
            //    string newfilename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
            //        + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + i + ".jpg";
            //    //下载很快，如果不在文件名加入i的话，会在一秒内下载完，使用时间当做文件名，最后就只剩一个文件。
            //    //string filePath = @"D:\VSPROJECT\WindowsFormsApplication3\" + newfilename;

            //    if (jo["type"].ToString().Equals("image"))
            //        filePath = @"D:\VSPROJECT\zdExhibition1\image\" + newfilename;
            //    else if (jo["type"].ToString().Equals("video"))
            //        filePath = @"D:\VSPROJECT\zdExhibition1\video\" + newfilename;
            //    else
            //        filePath = @"D:\";
            //    try
            //    {
            //        mywebclient.DownloadFile(url, filePath);
            //        SQLiteParameter[] Params1 = new SQLiteParameter[] {
            //                                                   new SQLiteParameter("@type", jo["type"]),
            //                                                   new SQLiteParameter("@url", jo["url"]),
            //                                                   new SQLiteParameter("@filename", newfilename),
            //                                                   new SQLiteParameter("@filepath", filePath),
            //                                                   new SQLiteParameter("@state", 1) };

            //        if (File.Exists(filePath))
            //        {
            //            Op.PrepareCommand(cmdInsertText1, Params1);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //    }
            //}
            //Op.read(dbPath, "fileUpdate");
            //int j = Ops.checkLastUpdate();
            //Console.WriteLine("__________" + j + "______________");
            
        }
        static void Main(string[] args)
        {
           
            int j = Ops.checkLastUpdate();
            Console.WriteLine("__________"+j+"______________");
            Thread t = new Thread(UpdateFromServer);
            t.Start();
            Console.WriteLine("主线程正在运行");
            Console.ReadLine();
        }
    }
}



//SQLiteConnection conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置
//conn.Open();//打开数据库，若文件不存在会自动创建
//SQLiteCommand cmdCreateTable = new SQLiteCommand(cmdCreteText, conn);
//cmdCreateTable.ExecuteNonQuery();//如果表不存在，创建数据表
//conn.Close();  
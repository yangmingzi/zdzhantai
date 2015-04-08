using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Data.SQLite;
using Dell;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Data.SQLite;
using Dell;
using System.IO;

namespace zdzhantai
{
   
    class updateSq
    {
        static string  dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
        public static  string cmdQueryText = "SELECT  * FROM fileUpdate WHERE state<1";
        public static  string cmdDropText = "DROP TABLE fileUsing";
        public static  string cmdCopyText = "INSERT INTO fileUsing SELECT * FROM  fileUpdate";
        public static  string cmdInsertTableupdateText = "INSERT INTO fileUpdate VALUES(@type,@url,@filename,@filepath,@state)";
        //private static Ops Op;
        private static Ops Op = bulidOp();
        public  static Ops bulidOp()
        {
            Ops Op = new Ops(dbPath);           
            return Op;
        }       
        public static void UpdateFromServer()
        {
            string filePath;
            //Ops Op = bulidOp();
            //// 数组  【】    对象{}     值“”
            string json1 = "{type:'image',url:'http://i1.hoopchina.com.cn/blogfile/201501/08/BbsImg142070525332424_550*550.jpg'}";
            //string json2 = "{type:'video',url:'http://i2.hoopchina.com.cn/blogfile/201411/27/BbsImg141707487288557_1271*988.jpg'}";
            string json2 = "{type:'image',url:'http://p0.qhimg.com/dmsmty/70_70_100/t0152c6ddbb22a37797.png'}";
            string json3 = "{type:'image',url:'http://i1.hoopchina.com.cn/blogfile/201304/09/136548593327743.jpg'}";
            string jsonString = "[" + json1 + "," + json2 + "," + json3 + "]";

           // string jsonString = myfile.readname();
            StringBuilder sb = new StringBuilder();
            JArray array1 = (JArray)JsonConvert.DeserializeObject(jsonString);
            int le = array1.ToArray().Length;      
            for (int i = 0; i < le; ++i)
            {
                WebClient mywebclient = new WebClient();
                JObject jo = (JObject)array1[i];
                //string frontUrl = "http://10.108.158.5:8080/cpServerPro";
                //string backUrl = jo["url"].ToString();               
                //string url = frontUrl + backUrl;
                //string newfilename = backUrl;

                //Boolean b = backUrl.Equals("");
                //if (b) { continue; } 

                string url = jo["url"].ToString();
                Boolean isHave = urlSearch(url);
                if (isHave) { continue; }

                //if (backUrl.Equals("")) { continue; }
                string newfilename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
                    + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + i + ".jpg";
                //下载很快，如果不在文件名加入i的话，会在一秒内下载完，使用时间当做文件名，最后就只剩一个文件。
                //string filePath = @"D:\VSPROJECT\WindowsFormsApplication3\" + newfilename;
                if (jo["type"].ToString().Equals("image"))
                    filePath = @Environment.CurrentDirectory + "/Image/" + newfilename;
                else if (jo["type"].ToString().Equals("video"))
                    filePath = @Environment.CurrentDirectory + "/Video/" + newfilename;
                else
                    filePath = @"D:\";
                try
                {
                    
                    mywebclient.DownloadFile(url, filePath);
                    SQLiteParameter[] Params1 = new SQLiteParameter[] {
                                                               new SQLiteParameter("@type", jo["type"]),
                                                               new SQLiteParameter("@url", jo["url"]),
                                                               new SQLiteParameter("@filename", newfilename),
                                                               new SQLiteParameter("@filepath", filePath),
                                                               new SQLiteParameter("@state", 1) };

                    if (File.Exists(filePath))
                    {
                        Op.ChangeCommand(cmdInsertTableupdateText, Params1);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            int j = updateSq.checkLastUpdate();
        }

        //查找某一项
        public static Boolean isSearch(string url)
        {

            string frontCmd = "SELECT * FROM fileUsing WHERE url=";
            string cmd = frontCmd + "'" + url + "'";
            SQLiteDataReader sdr = Op.noChangeCommand(cmd);
            if (sdr.Read() == null)
                return false;
            else
                return true;
        }
        //
        public static  Boolean urlSearch(string url)
        {
            string cmdSRfront = "SELECT * From fileUsing WHERE url=";
            string cmdSr = cmdSRfront + "'" + url + "'";
            SQLiteDataReader sdrSearch = Op.noChangeCommand(cmdSr);
            Boolean b = sdrSearch.Read();
            return b;
        }
        public static int checkLastUpdate()
        {
            //Ops Op = bulidOp();
            string filePath = null;
            SQLiteConnection conn = Ops.buildConn();
            SQLiteDataReader sdr =Op.noChangeCommand(cmdQueryText);
            //Op.ChangeCommand(cmdQueryText,null);
            int i = 0;
            int j = 0;
            while (sdr.Read())
            {
                i++;
                string filenamestr = sdr.GetString(2);
                SQLiteCommand cmdChangeTable;
                if (sdr.GetString(0).Equals("image"))
                    filePath = @Environment.CurrentDirectory + "/Image/" + filenamestr;
                else if (sdr.GetString(0).Equals("video"))
                    filePath = @Environment.CurrentDirectory + "/Video/" + filenamestr;
                else
                    filePath = @"D:\";
                //写程序时要严格注意语法规则，可以节省不少时间
                string cmdUpdateText = "UPDATE fileUpdate SET state=1 WHERE filename =" + "'" + filenamestr + "'";
                if (File.Exists(filePath))
                {
                    Op.ChangeCommand(cmdUpdateText,null);                  
                    Console.WriteLine(j);
                }
                Console.WriteLine(sdr.GetString(1) + "  " + sdr.GetString(2));
            }

            if (i == 0)
            {
                Console.WriteLine(i);              
                Op.ChangeCommand(cmdDropText,null);
                initSqlite.initUsingTable();               
                Op.ChangeCommand(cmdCopyText,null);
            }
           
            conn.Close();
            return i;
        }
    }
}

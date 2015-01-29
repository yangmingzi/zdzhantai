
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Configuration;
using System.Collections;
using System.Data;
using System.IO;

namespace Dell{
    public class Ops
    {

        private SQLiteCommand command = new SQLiteCommand();
        private SQLiteConnection connection = null;

        public Ops() { }
       
        public Ops(string dbPath)
        {
            initCon(dbPath);
            judgeConn();
        }

        public void initCon(string dbPath)
        {
            connection = new SQLiteConnection(dbPath);
        }
        private Boolean judgeConn()
        {
            Boolean isOpen = true;
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    //initCon(dbPath);
                    connection.Open();

                }catch(Exception){
                    isOpen = false;
                }
            }
            return isOpen;            
        }
        public int PrepareCommand(string commandText, SQLiteParameter[] commandParameters)
        {
            int changedNo = 0;
            judgeConn();
            command.Connection = connection;
            command.CommandText = commandText;

            if (commandParameters != null)
            {
                command.Parameters.AddRange(commandParameters);
                changedNo = command.ExecuteNonQuery();
                
            }
            return changedNo;
        }

        public void read (string dbPath, string name)
        {

            //judgeConn();
            ////string sql1 = "select * from  " + name;
            ////string sql1 = "select rowid,*  from  worker" ;
            //string sql1 = "select *  from "+name;
            //SQLiteCommand cmdQ = new SQLiteCommand(sql1, connection);
            //SQLiteDataReader reader = cmdQ.ExecuteReader();
            //while (reader.Read())
            //    //Console.WriteLine( reader.GetInt64(0)+reader.GetString(1) + "  " + reader.GetString(2));
            //    Console.WriteLine(reader.GetString(1) + "  " + reader.GetString(2));
                
            //connection.Close();
            //Console.ReadLine();

        }
        //从服务器获取数据，查看是否需要更新 
        public static void isNeedUpdate()
        {
            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            SQLiteConnection conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置
            conn.Open();//打开数据库，若文件不存在会自动创建

        }
        //检查上一次是否全部更新完成
        public static int  checkLastUpdate()
        {
            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            string filePath = null;
            SQLiteConnection conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置
            conn.Open();//打开数据库，若文件不存在会自动创建
            string cmdQueryText = "SELECT  * FROM fileUpdate WHERE state<1";
            SQLiteCommand cmdQueryTable = new SQLiteCommand(cmdQueryText, conn);
            //int i = cmdQueryTable.ExecuteNonQuery();
            SQLiteDataReader sdr = cmdQueryTable.ExecuteReader();
            int i = 0;
            int j = 0;
            while (sdr.Read())
            {
                i++;
                string filenamestr = sdr.GetString(2);
                SQLiteCommand cmdChangeTable;
                if(sdr.GetString(0).Equals("image"))
                    filePath = @"D:\VSPROJECT\zdExhibition1\image\" + filenamestr;
                else if (sdr.GetString(0).Equals("video"))
                    filePath = @"D:\VSPROJECT\zdExhibition1\video\" + filenamestr;
                else
                    filePath = @"D:\";
                //写程序时要严格注意语法规则，可以节省不少时间
                string CmdUpdateText = "UPDATE fileUpdate SET state=1 WHERE filename ="+"'"+filenamestr+"'";
                if (File.Exists(filePath))
                {
                    cmdChangeTable = new SQLiteCommand(CmdUpdateText, conn);
                    j=Convert.ToInt32(cmdChangeTable.ExecuteNonQuery());
                    Console.WriteLine(j);
                }
                Console.WriteLine(sdr.GetString(1)+"  "+sdr.GetString(2));
            }
        

            if (i == 0)
            {
                Console.WriteLine(i);
                string cmdDropText = "DROP TABLE fileUsing";
                SQLiteCommand cmdDropTable;
                cmdDropTable = new SQLiteCommand(cmdDropText, conn);
                int u = cmdDropTable.ExecuteNonQuery();
                initUsingTable();
                string cmdCopyText = "INSERT INTO fileUsing SELECT * FROM  fileUpdate";
                SQLiteCommand cmdCopyTable;
                cmdCopyTable = new SQLiteCommand(cmdCopyText, conn);
                int q = cmdCopyTable.ExecuteNonQuery();
            }
            conn.Close();
            return i;        
        }
       //初始化FileUpdate表
        public static void initUpdateTable()
        {
            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            string cmdCreteText = "CREATE TABLE IF NOT EXISTS fileUpdate(type varchar(30),url varchar(1000),filename varcharo(30),filepath varchar(1000),state integer)";
            //string cmdCreteText = "CREATE TABLE IF NOT EXISTS fileUpdate(type varchar(30),url varchar(1000),filename varcharo(30),filepath varchar(1000))";
            SQLiteConnection conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置
            conn.Open();//打开数据库，若文件不存在会自动创建
            SQLiteCommand cmdCreateTable = new SQLiteCommand(cmdCreteText, conn);
            cmdCreateTable.ExecuteNonQuery();//如果表不存在，创建数据表
            conn.Close();
        }
        //初始化FileUSing表
        public static void initUsingTable()
        {
            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            string cmdCreteText1 = "CREATE TABLE IF NOT EXISTS fileUsing(type varchar(30),url varchar(1000),filename varcharo(30),filepath varchar(1000),state integer)";
            SQLiteConnection conn1 = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置
            conn1.Open();//打开数据库，若文件不存在会自动创建
            SQLiteCommand cmdCreateTable1 = new SQLiteCommand(cmdCreteText1, conn1);
            cmdCreateTable1.ExecuteNonQuery();//如果表不存在，创建数据表
            conn1.Close();
        }
    }

}
//public class Ops
//{

//    public SQLiteCommand  command = new SQLiteCommand();
//    public string dbPath;  

//         public Ops(){}

//         public Ops(string dbPath) {
//             SQLiteConnection connection = null;
//             connection = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置
//             connection.Open();//打开数据库，若文件不存在会自动创建
         
//         }

//         public void PrepareCommand(string dbPath, string commandText, SQLiteParameter[] commandParameters)
//            {
//            SQLiteConnection connection =new SQLiteConnection(dbPath);          
//            connection.Open();
//            command.Connection = connection;          
//            command.CommandText = commandText;

//            if (commandParameters != null)
//            {
//                command.Parameters.AddRange(commandParameters);
//                command.ExecuteNonQuery();
//            }         
//            if (connection.State != ConnectionState.Open)
//                connection.Open();
//            }
         
//           public  void read(string dbPath,string name)
//             {
//                 SQLiteConnection conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
//                 conn.Open();
//                 string sql1 = "select * from "+name;                
//                 SQLiteCommand cmdQ = new SQLiteCommand(sql1, conn);
//                 SQLiteDataReader reader = cmdQ.ExecuteReader();
//                 while (reader.Read())
//                     Console.WriteLine(reader.GetInt32(0) + "" + reader.GetString(1) + "" + reader.GetString(2));
//                 conn.Close();
//                 Console.ReadLine();
//             }
	
//}


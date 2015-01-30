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
      
         //初始化connection      
        public static SQLiteConnection buildConn()
        {
            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            SQLiteConnection conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置
            conn.Open();//打开数据库，若文件不存在会自动创建
            return conn;
        }
        //从服务器获取数据，查看是否需要更新 
        public static void isNeedUpdate()
        {
            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            SQLiteConnection conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置
            conn.Open();//打开数据库，若文件不存在会自动创建

        }
        //抽象改变了表数据的命令函数
        public static void ChangeCommand(string cmdText, SQLiteConnection conn)
        {
            int changedNo = 0;
            SQLiteCommand command = new SQLiteCommand(cmdText, conn);
            changedNo = command.ExecuteNonQuery();
        }
        //检查上一次是否全部更新完成
        public static int  checkLastUpdate()
        {
            string filePath = null;
            SQLiteConnection conn = buildConn();
            string cmdQueryText = "SELECT  * FROM fileUpdate WHERE state<1";
            SQLiteCommand cmdQueryTable = new SQLiteCommand(cmdQueryText, conn);
            //int i = cmdQueryTable.ExecuteNonQuery();
            SQLiteDataReader sdr = cmdQueryTable.ExecuteReader();
            ChangeCommand(cmdQueryText, conn);
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
                string cmdUpdateText = "UPDATE fileUpdate SET state=1 WHERE filename ="+"'"+filenamestr+"'";
                if (File.Exists(filePath))
                {
                    ChangeCommand(cmdUpdateText,conn);
                    Console.WriteLine(j);
                }
                Console.WriteLine(sdr.GetString(1)+"  "+sdr.GetString(2));
            }
        

            if (i == 0)
            {
                Console.WriteLine(i);
                string cmdDropText = "DROP TABLE fileUsing";
                ChangeCommand(cmdDropText, conn);
                initUsingTable();
                string cmdCopyText = "INSERT INTO fileUsing SELECT * FROM  fileUpdate";
                ChangeCommand(cmdCopyText, conn);
            }
            conn.Close();
            return i;        
        }
       //初始化FileUpdate表
        public static void initUpdateTable()
        {
            string cmdCreteText = "CREATE TABLE IF NOT EXISTS fileUpdate(type varchar(30),url varchar(1000),filename varcharo(30),filepath varchar(1000),state integer)";
            SQLiteConnection conn = buildConn();
            ChangeCommand(cmdCreteText,conn);
            conn.Close();
        }
        //初始化FileUSing表
        public static void initUsingTable()
        {
            string cmdCreteText1 = "CREATE TABLE IF NOT EXISTS fileUsing(type varchar(30),url varchar(1000),filename varcharo(30),filepath varchar(1000),state integer)";
            SQLiteConnection conn1 = buildConn();
            ChangeCommand(cmdCreteText1,conn1);
            conn1.Close();
        }
    }

}

//public void read (string dbPath, string name)
//{

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

//}

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


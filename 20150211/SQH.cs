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
        //抽象改变了表数据的命令函数
        public static  void  ChangeCommand(string cmdText, SQLiteConnection conn)
        {
            int changedNo = 0;
            SQLiteCommand command = new SQLiteCommand(cmdText, conn);
            changedNo = command.ExecuteNonQuery();
        }
        //抽象为改变表数据的命令函数
        public static SQLiteDataReader noChangeCommand(string  cmdText, SQLiteConnection conn)
        {
             SQLiteCommand command = new SQLiteCommand(cmdText, conn);
             SQLiteDataReader sdr = command.ExecuteReader();
             return sdr;
        }
      
    }

}


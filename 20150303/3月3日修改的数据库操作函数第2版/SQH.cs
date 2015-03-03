using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Configuration;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;



namespace Dell{
    public class Ops
    {
        public static string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
        private SQLiteCommand command = new SQLiteCommand();
        private SQLiteConnection connection = null;

        public Ops() { }
       
        public  Ops(string dbPath)
        {
            initCon(dbPath);
            Boolean b = judgeConn();
            if( b == false)
            {
                MessageBox.Show("数据库开启失败！");
            }
        }

        //建立connection      
        public static SQLiteConnection buildConn()
        {
            SQLiteConnection conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置
            conn.Open();//打开数据库，若文件不存在会自动创建
            return conn;
        }

        public  void initCon(string dbPath)
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
        //抽象改变表数据的命令执行函数
        public int ChangeCommand(string commandText, SQLiteParameter[] commandParameters)
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
            else
            {
                changedNo = command.ExecuteNonQuery();
            }
            return changedNo;
        }
        //抽象出不改变表数据的函数
        public SQLiteDataReader noChangeCommand(string commandText)
        {
            
            judgeConn();
            //command.Connection = connection;
            //command.CommandText = commandText;
            SQLiteCommand command = new SQLiteCommand(commandText, connection);
            SQLiteDataReader sdr = command.ExecuteReader();   
            return sdr;
        }
     
    }

}


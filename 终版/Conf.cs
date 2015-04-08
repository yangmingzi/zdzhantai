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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Data.SQLite;
using Dell;
using System.Threading;

namespace zdzhantai
{
    
    class Conf
    {
        public static string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
        public static string cmdCreateConfTable = 
            "CREATE TABLE IF NOT EXISTS tableConf(type varchar(30),val varchar(30))";
      
        public static void createConfTable()
        {
            Ops Op = new Ops(dbPath);           
            Op.ChangeCommand(cmdCreateConfTable, null);           
        }
        public static int getCloums()
        {
            string cmd = "SELECT type FROM tableConf";
            Ops Op = new Ops(dbPath);
            SQLiteDataReader sdr=Op.noChangeCommand(cmd);
            int i = 0;
            
            while (sdr.Read()) { i++;}
            if (i == 0)
            {
                string cmdInsertC1 = "INSERT INTO tableConf(type,val) VALUES ('url','null')";
                string cmdInsertC2 = "INSERT INTO tableConf(type,val) VALUES ('com','null')";
                Op.ChangeCommand(cmdInsertC1, null);
                Op.ChangeCommand(cmdInsertC2, null);
                int a = i;
                return i;
            }
            else
            {
                return i;
            }           
        }
        public static void setServerUrl(string value)
        {
            string str1 = "UPDATE tableConf SET val=";
            string str2 = "WHERE type = 'url'";
            string cmdUpdateConfTable = str1 + "'" + value + "'" + str2;
            Ops Op = new Ops(dbPath);
            Op.ChangeCommand(cmdUpdateConfTable, null);
        }
        public static void setCOM(string value)
        {
            string str1 = "UPDATE tableConf SET val=";
            string str2 = "WHERE type = 'com'";
            string cmdUpdateConfTable = str1 +"'" +value+"'" + str2;
            Ops Op = new Ops(dbPath);
            Op.ChangeCommand(cmdUpdateConfTable, null);
        }

        public static string getUrl()
        {
            string result = null;
      
            string cmdGetUrl = "SELECT * FROM tableConf WHERE type='url' ";
            Ops Op = new Ops(dbPath);
            SQLiteDataReader sdr = Op.noChangeCommand(cmdGetUrl);
            while (sdr.Read())
            {
                result = sdr.GetString(1);
            }
            return result;       
        }
        public static string getCOM()
        {
            string result = null;
            string cmdGetCOM = "SELECT * FROM tableConf WHERE type='com' ";
            Ops Op = new Ops(dbPath);
            SQLiteDataReader sdr = Op.noChangeCommand(cmdGetCOM);
            while (sdr.Read())
            {
                result = sdr.GetString(1);
            }
            return result;       
        }
    }
}

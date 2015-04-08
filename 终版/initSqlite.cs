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

namespace zdzhantai
{
    class initSqlite
    {
        public static string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
        public static string cmdCreateUpdatetableText = 
            "CREATE TABLE IF NOT EXISTS fileUpdate(type varchar(30),url varchar(1000),filename varcharo(30),filepath varchar(1000),state integer)";
        public static string cmdCreateUsingtableText = "CREATE TABLE IF NOT EXISTS fileUsing(type varchar(30),url varchar(1000),filename varcharo(30),filepath varchar(1000),state integer)";
        //public static string cmdCreteSettingtableText = "CREATE TABLE IF NOT EXISTS settingUse(ID integer,url vvarchar(1000),userName varchar(100),passWord varchar(100))";
        public static string cmdCreteSettingtableText = "CREATE TABLE IF NOT EXISTS settingUse(url vvarchar(1000),userName varchar(100),passWord varchar(100))";
        
        //public static string getCreateText(string tableName) {
        //    string before = "CREATE TABLE IF NOT EXISTS";
        //    string behind = "(type varchar(30),url varchar(1000),filename varcharo(30),filepath varchar(1000),state integer)";
        //    string cmdCreateText = before + "tableName" + behind;
        //    return cmdCreateText;
        //}
        public static void initUpdateTable()
        {
            Ops Op = new Ops(dbPath);
            //string cmdCreateUpdatetableText = getCreateText("fileUpdate");    
            Op.ChangeCommand(cmdCreateUpdatetableText,null);           
        }

        public static void initUsingTable()
        {
            Ops Op = new Ops(dbPath);
            //string cmdCreateUsingtableText = getCreateText("fileUsing");
            Op.ChangeCommand(cmdCreateUsingtableText, null);
        }
        //public static void initSettingTable() {
        //    Ops Op = new Ops(dbPath);
        //    Op.ChangeCommand(cmdCreteSettingtableText, null);
        //}
    }
}

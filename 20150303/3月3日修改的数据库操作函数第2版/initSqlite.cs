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
        public static string cmdCreteUpdatetableText = "CREATE TABLE IF NOT EXISTS fileUpdate(type varchar(30),url varchar(1000),filename varcharo(30),filepath varchar(1000),state integer)";
        public static string cmdCreteUsingtableText = "CREATE TABLE IF NOT EXISTS fileUsing(type varchar(30),url varchar(1000),filename varcharo(30),filepath varchar(1000),state integer)";
       
        public static void initUpdateTable()
        {
            Ops Op = new Ops(dbPath);                        
            Op.ChangeCommand(cmdCreteUpdatetableText,null);           
        }

        public static void initUsingTable()
        {
            Ops Op = new Ops(dbPath);                       
            Op.ChangeCommand(cmdCreteUsingtableText, null);
        }
    }
}

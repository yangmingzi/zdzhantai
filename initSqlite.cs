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
        public static Ops bulidOp()
        {
            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            Ops Op = new Ops(dbPath);
            return Op;
        }
        public static void initUpdateTable()
        {
            Ops Op = bulidOp();
            string cmdCreteText = "CREATE TABLE IF NOT EXISTS fileUpdate(type varchar(30),url varchar(1000),filename varcharo(30),filepath varchar(1000),state integer)";
            SQLiteConnection conn = Ops.buildConn();
            //Op.PrepareCommand(cmdCreteText, null);
            Ops.ChangeCommand(cmdCreteText,conn);
            conn.Close();
        }

        public static void initUsingTable()
        {
            Ops Op = bulidOp();
            string cmdCreteText = "CREATE TABLE IF NOT EXISTS fileUsing(type varchar(30),url varchar(1000),filename varcharo(30),filepath varchar(1000),state integer)";
            SQLiteConnection conn = Ops.buildConn();
            //Op.PrepareCommand(cmdCreteText, null);
            Ops.ChangeCommand(cmdCreteText, conn);
            conn.Close();
        }
    }
}

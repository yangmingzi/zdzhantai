using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Data.SQLite;
using Dell;
using System.IO;

namespace zdzhantai
{
    class myfile
    {
        //File serverurlFile = new File(Environment.CurrentDirectory.ToString()+"/");
        static string path = Environment.CurrentDirectory.ToString();       
        static string urlfilename  = path+"url.txt";
        static string userfilename = path+"name.txt";
        static string passfilename = path+"password.txt";
        //string json = "[{url:'https://www.baidu.com/',username:'zdzt',password:'123456'}]";
        //FileStream fs = File.Create(path+urlfilename); 
        //StringBuilder sb = new StringBuilder();
        //JArray array = (JArray)JsonConvert.DeserializeObject(json);
        public static void CreateFile(string filename)
        {
            FileStream fs = File.Create(filename);
        }
        public static string ReadFile(int a)
        {
           string typeInt = "";
           //switch(a){
           //    case 1:read(urlfilename);break;
           //    case 2:read(userfilename);break;
           //    case 3:read(passfilename);break;
           //    default: return ad;break;
           //}
           //return ad;
            if (a == 1) {
                typeInt = read(urlfilename); return typeInt;
            }else if(a==2){
                typeInt = read(userfilename); return typeInt;
            }
            else if (a == 3)
            {
                typeInt = read(passfilename); return typeInt;
            }
            else {
                typeInt = "NULL"; return typeInt;
            }
        }

        public static string readname() {
            StreamReader sr = File.OpenText(userfilename);
            string content = "";
            if (File.Exists(userfilename) == true)
            {
                content = sr.ReadLine();
            }
            return content;
        }
        public static string read(string filename)
        {
            StreamReader sr = File.OpenText(filename);
            string content = "";
            if (File.Exists(filename) == true)
            {
                content = sr.ReadLine();
            }
            return content;
        }
        public static void WriteFile( string filename,string content)
        {
            StreamWriter streamWriter = File.CreateText(filename);
            streamWriter.WriteLine(content);
            streamWriter.Close();
        }

    }
   
}

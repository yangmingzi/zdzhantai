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
        
        FileStream fs = File.Create(path+urlfilename);


        public static void CreateFile(string filename)
        {
            FileStream fs = File.Create(filename);
        }
        public static string ReadFile(int a)
        {
           string ad = "";
           //switch(a){
           //    case 1:read(urlfilename);break;
           //    case 2:read(userfilename);break;
           //    case 3:read(passfilename);break;
           //    default: return ad;break;
           //}
           //return ad;
            if (a == 1) {
                ad = read(urlfilename); return ad;
            }else if(a==2){
                ad = read(userfilename); return ad;
            }
            else if (a == 3)
            {
                ad = read(passfilename); return ad;
            }
            else {
                ad = "NULL"; return ad;
            }
        }
        public static string read(string filename)
        {
            StreamReader sr = File.OpenText(filename);
            string s = "";
            if (File.Exists(filename) == true)
            {
                s = sr.ReadLine();
            }
            return s;
        }
        public static void WriteFile( string filename,string content)
        {
            StreamWriter sw = File.CreateText(filename);
            sw.WriteLine(content);
            sw.Close();
        }

    }
   
}

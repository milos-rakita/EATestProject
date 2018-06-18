using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Helpers
{
    public class LogHelpers
    {
        //log file - Global declaration
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;

        
        //create file witch can store the log information
        public static void CreateLogFile()
        {

            string dir = @"D:\QATest\";
            if (Directory.Exists(dir))
            {
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }

        }

        
        //create method which can write text in tlog filr
        public static void Write(string logMesage)
        {
            _streamw.Write(" {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamw.WriteLine("    {0}", logMesage);
            _streamw.Flush();
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;

namespace WorkDemoAPI.Data
{
    public static class Logger
    {
        private static string sFilename;

        public static void Init(string filename)
        {
            sFilename = filename;
        }

        public static void Write(string msg)
        {
            using (StreamWriter file = new StreamWriter(sFilename, append: true))
            {
                file.Write($"[{DateTime.Now.ToString("HH::mm::ss")}]: ");
                file.WriteLine(msg);
            }
        }
    }
}
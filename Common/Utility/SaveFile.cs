using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Common.Utility
{
   public class SaveFile
    {
       public static void WriteBytes(byte[] data, string filePath)
       {

       }
        public static void WriteText(string text,string filePath)
        {
            StreamWriter streamWriter = new System.IO.StreamWriter(filePath);
            streamWriter.WriteLine(text);
            streamWriter.Close();
        }
        public static void AppendText(string text, string filePath)
        {
            if(!File.Exists(filePath))
            {
                using (StreamWriter streamWriter = File.AppendText(filePath))
                {
                    streamWriter.WriteLine(text);
                    streamWriter.Close();
                }	
            }
            else
            {
                WriteText(text, filePath);
            }
        }
    }
}

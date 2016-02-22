using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Common.Utility;

namespace Common.Config
{
    class Config
    {
        public static int GetIntValue(string valueName, string fileName, string filePath)
        {
        
            try{
                  string[] text;
            int value = 0;
            text = ReadFile.ReadTextArray(string.Format(@"{0}\{1}",filePath,fileName));
                foreach(string line in text)
                {
                if(line.Contains(valueName))
                {
                    char[] delimiters = new char[] { '\r', '\n' };
                    string[] splitText = line.Split(delimiters,StringSplitOptions.RemoveEmptyEntries);
                    value = int.Parse(splitText[1]);
    
                }

                }
                return value;
            }
            catch
            {
                throw new Exception(string.Format("Missing Value {0} In File{1}",valueName,fileName));
            }
        }
        public static string GetStringValue(string valueName, string fileName, string filePath)
        {
        
            try{
                  string[] text;
            string value = "";
            text = ReadFile.ReadTextArray(string.Format(@"{0}\{1}",filePath,fileName));
                foreach(string line in text)
                {
                if(line.Contains(valueName))
                {
                    char[] delimiters = new char[] { '\r', '\n' };
                    string[] splitText = line.Split(delimiters,StringSplitOptions.RemoveEmptyEntries);
                    value =splitText[1];
    
                }

                }
                return value;
            }
            catch
            {
                throw new Exception(string.Format("Missing Value {0} In File{1}",valueName,fileName));
            }
        }
        public static bool GetBoolValue(string valueName, string fileName, string filePath)
        {
        
            try{
                  string[] text;
            bool value = false;
            text = ReadFile.ReadTextArray(string.Format(@"{0}\{1}",filePath,fileName));
                foreach(string line in text)
                {
                if(line.Contains(valueName))
                {
                    char[] delimiters = new char[] { '\r', '\n' };
                    string[] splitText = line.Split(delimiters,StringSplitOptions.RemoveEmptyEntries);
                    value = bool.Parse(splitText[1]);
    
                }

                }
                return value;
            }
            catch
            {
                throw new Exception(string.Format("Missing Value {0} In File{1}",valueName,fileName));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Common.Utility
{
    class ReadFile
    {


        public static byte[] ReadByte(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;
                buffer = new byte[length];
                int count;
                int sum = 0;


                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;
            }
            catch
            {
                throw new Exception(string.Format("Can't Read File \n\r {0}", filePath));
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

        public static string ReadText(string filePath)
        {
            string text;
            try
            {
                using (var streamReader = new StreamReader(filePath, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }
                return text;
            }
            catch
            {
                throw new Exception(string.Format("Can't Read File \n\r {0}",filePath));
            }
        }
        public static string[] ReadTextArray(string filePath)
        {
            string[] text;
            try
            {
                using (var streamReader = File.OpenText(filePath))
                {
                    text = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                }
                return text;
            }
            catch
            {
                throw new Exception(string.Format("Can't Read File \n\r {0}", filePath));
            }
        }
    }
}
    


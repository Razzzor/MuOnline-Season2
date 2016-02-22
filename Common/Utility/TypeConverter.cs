using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Common.Utility
{
    public class TypeConverter
    {
        public static int CountCharsInString(string value)
        {
            try
            {
                int result = 0;
                foreach (char c in value)
                {
                    result++;
                }
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static char[] StringToCharArray(string text)
        {
            try
            {

                return text.ToCharArray();

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static char[] ByteArrayToCharArray(byte[] data)
        {
            try
            {

                return Encoding.ASCII.GetString(data).ToCharArray();

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static byte[] ByteArrayToCharArray(char[] data)
        {
            try
            {

                return Encoding.ASCII.GetBytes(data);

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static string ByteArrayToHexString(byte[] data)
        {
            try
            {
                return BitConverter.ToString(data).Replace("-", " ");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static string ByteArrayToString(byte[] data)
        {
            try
            {
                return System.Text.Encoding.ASCII.GetString(data).TrimEnd('\0');
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static byte[] StringToByteArray(string text, int limitBytes)
        {
            try
            {

                char[] stringCharArray = StringToCharArray(text);
                if (stringCharArray.Length.Equals(0))
                {
                    throw new Exception("Failed");
                }
                byte[] charArrayBytes = new byte[limitBytes];
                for (int i = 0; i < limitBytes; i++)
                {
                    if (i < stringCharArray.Length)
                    {
                        charArrayBytes[i] = CharToByte(stringCharArray[i]);
                    }
                    else
                    {
                        charArrayBytes[i] = 0x00;
                    }
                }
                return charArrayBytes;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static byte CharToByte(char value)
        {
            try
            {

                return Convert.ToByte(value);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static byte[] StringToByteArray(string data)
        {
            try
            {

                return Encoding.UTF8.GetBytes(data);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public static byte[] Xor(byte[] value)
        {
            try
            {
                var xorKey = new byte[] { 0xA4, 0x9F, 0xD8, 0xB3, 0xF6, 0x8E, 0x39, 0xC2, 0x2D, 0xE0, 0x61, 0x75, 0x5C, 0x4B, 0x1A, 0x07 };
                var bytesXOR = new byte[value.Count()];
                byte count = 0;
                for (long i = 0; i < value.Count(); i++)
                {
                    if (count == xorKey.Count())
                        count = 0;
                    bytesXOR[i] = (byte)(value[i] ^ xorKey[count]);
                    count++;
                }
                return bytesXOR;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static byte[] HexStringToByteArray(string hexText)
        {
            try
            {
                return Enumerable.Range(0, hexText.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hexText.Substring(x, 2), 16)).ToArray();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static string ToHexString(byte data)
        {
            try
            {
                return data.ToString("X");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static string ToHexString(uint value)
        {
            try
            {
                return value.ToString("X");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static int ToInteger(string text)
        {
            try
            {

                var result = Convert.ToInt64(text, 0x10);
                return (int)result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static byte[] IntegerToLittleEndian2ByteArray(int value)
        {
            try
            {
                byte[] result = new byte[2];
                
                result[0] = ((byte)(value & 0xFF));
                result[1] = ((byte)(value >> 8));

                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static byte[] IntegerToLittleEndian4ByteArray(int value)
        {
            try
            {
                byte[] result = new byte[4];

                result[0] = ((byte)(value & 0xFF));
                result[1] = ((byte)(value >> 32));
                result[2] = ((byte)(value >> 16));
                result[3] = ((byte)(value >> 8));

                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static byte[] IntegerToBigEndian2ByteArray(int value)
        {
            try
            {
                byte[] result = new byte[2];

                result[0] = ((byte)(value >> 8));
                result[1] = ((byte)(value & 0xFF));
                

                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static byte[] IntegerToBigEndian4ByteArray(int value)
        {
            try
            {
                byte[] result = new byte[2];

                result[0] = ((byte)(value >> 8));
                result[2] = ((byte)(value >> 16));
                result[2] = ((byte)(value >> 32));
                result[3] = ((byte)(value & 0xFF));


                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static byte[] ObjectToByteArray(Object obj)
        {
            try
            {
                if (obj == null)
                    return null;
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    binaryFormatter.Serialize(memoryStream, obj);
                    return memoryStream.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static Object ByteArrayToObject(byte[] data)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                memoryStream.Write(data, 0, data.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);
                Object obj = (Object)binaryFormatter.Deserialize(memoryStream);
                return obj;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }

}


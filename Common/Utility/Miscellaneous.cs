using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Common.Utility
{
    public static class Miscellaneous
    {
       
       
        //###########################################################################################################################################################
        public static byte[] TrimNullByteInDataArray(byte[] data)
        {
            bool dataFound = false;
            byte[] NewData = data.Reverse().SkipWhile(point =>
            {
                if (dataFound) return false;
                if (point == 0x00) return true; else { dataFound = true; return false; }
            }).Reverse().ToArray();
            return NewData;
        }
       
        //###########################################################################################################################################################
        public static IEnumerable<T> EnumerateFrom<T>(this T[] data, int start)
        {
            if (data == null)
            {
                throw new ArgumentNullException("EnumerateFrom<T>");
            }

            return Enumerate<T>(data, start, data.Length);
        }
        //###########################################################################################################################################################
        public static IEnumerable<T> Enumerate<T>(this T[] data, int start, int count)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Enumerate<T>");
            }

            for (int i = 0; i < count; i++)
                yield return data[start + i];
        }
        //###########################################################################################################################################################
        
        
        public static string CpuUsage()
        {
            PerformanceCounter performanceCpuCounter = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName);
            return string.Format("Cpu Usage {0} %", Convert.ToInt32(performanceCpuCounter.NextValue()).ToString());
        }
        public static string RamUsage()
        {
           PerformanceCounter performanceRamCounter = new PerformanceCounter("Process", "Working Set", Process.GetCurrentProcess().ProcessName);
            return string.Format("Ram Usage {0} Mb", Convert.ToInt32(performanceRamCounter.NextValue()).ToString());
        }
        //###########################################################################################################################################################
        
        public static Type[] GetTypesInNamespace(Assembly assembly, string namespaceText)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, namespaceText, StringComparison.Ordinal)).ToArray();

        }

        //###########################################################################################################################################################
        public static string IpAddressToString(IPEndPoint ipAddress)
        {
            return Regex.Match(ipAddress.ToString(), "([0-9]+).([0-9]+).([0-9]+).([0-9]+)").Value;
        }
        //###########################################################################################################################################################
    }
}

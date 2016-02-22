using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace Common.Utility
{
    public class Logger
    {
       
        public static void Info(string log)
        {
            OnLoggerSend(new LoggerEventArgs(log, Color.Black));
        }
        public static void Info(string format, params string[] value)
        {
            OnLoggerSend(new LoggerEventArgs(string.Format(format, value), Color.Black));
        }
        public static void Trace(string log)
        {
            OnLoggerSend(new LoggerEventArgs(log,Color.Green));
        }
        public static void Trace(string format, params string[] value)
        {
            OnLoggerSend(new LoggerEventArgs(string.Format(format,value),Color.Green));
        }
        public static void Trace(System.Net.Sockets.SocketException e, string p)
        {
            
        }

        public static void Trace(Exception e, string p)
        {
          
        }
        public static void Warn(string log, Type type)
        {
            OnLoggerSend(new LoggerEventArgs(log, Color.Yellow));
        }

        public static void Warn(string log)
        {
            OnLoggerSend(new LoggerEventArgs(log, Color.Yellow));
        }

        public static void Warn(string format, params string[] value)
        {
            OnLoggerSend(new LoggerEventArgs(string.Format(format, value), Color.Yellow));
        }
        internal static void Warn(string p, Exception ex)
        {
           
        }
        public static void Error(string log)
        {
            OnLoggerSend(new LoggerEventArgs(log, Color.Red));
        }

        public static void Error(string format, params string[] value)
        {
            OnLoggerSend(new LoggerEventArgs(string.Format(format, value), Color.Red));
        }

        public static void Error(Exception e, string p)
        {
           
        }
        internal static void Error(string p, Exception ex)
        {
            
        }

        private static void OnLoggerSend(LoggerEventArgs e)
        {
            var handler = LoggerSend;
            if (handler != null) handler( e);
        }
        public  delegate void LoggerEventHandler( LoggerEventArgs e);


        public static event LoggerEventHandler LoggerSend;




        

        
    }
    public class LoggerEventArgs : EventArgs
    {
        public string log { get; private set; }
        public Color color { get; private set; }
        public LoggerEventArgs(string log ,Color color)
        {
            if (log == null)
                throw new ArgumentNullException("connection");
            this.log = log;
            this.color = color;
        }

    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace Game
{
    public class Define
    {

        public static string databaseHost = "127.0.0.1";
        public static string databasePort = "3306";
        public static string databaseName = "muonline";
        public static string databaseLogin = "root";
        public static string databasePassword = "";
        public static string autor = "Razzor";
        public static string gameVersion = "1.0.0.0";
        public static int port = 55901;
        public static IPAddress ipAddress = IPAddress.Parse("192.168.2.1");
        public static int clientsCount = 10;
        public static string mainVersion = "1.04.04";
        public static string mainSerial = "k1Pk2jcET48mxL3b";

        public static int passwordByteLenght = 10;
        public static int loginByteLenght = 10;

        public static int season = 2;

        public static int mgLevelRequired = 230;
        public static int dlLevelRequired = 250;
        public static string GetTitle()
        {
            return string.Format("Game ver: {0} by {1} ", gameVersion, autor);
        }
    }
}

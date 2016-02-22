using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utility
{
   public class TimeHelper
    {
       public static long GetCurrentMilliseconds()
       {
           return (long)(DateTime.UtcNow - StaticDate).TotalMilliseconds;
       }
       private static readonly DateTime StaticDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }
}

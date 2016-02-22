using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Database.GameOperation;

namespace Database.GameOperation
{
   public class GameOperations
    {
       public static Dictionary<int, Type> opCodes = new Dictionary<int, Type>();
       public static void Init()
       {
           opCodes.Add(1, typeof(AccountVerify)); 
       }
    }
}

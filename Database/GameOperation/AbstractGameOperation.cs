using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.GameOperation
{
   public abstract class AbstractGameOperation
    {
       public abstract void Execute(byte[] data);
    }
}

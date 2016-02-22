using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utility
{
   public class DatabseSavable : Attribute
    {
       private bool isSavable;
       public bool IsSavable
       {
           get
           { return isSavable; }
        }
       public DatabseSavable(bool isSavable)
       {
           this.isSavable = isSavable;
       }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common.Utility;

namespace Common.Calculations
{
    public class ExpTabele : Singleton<ExpTabele>
    {
        private Dictionary<int, int> ExpTabeleList;
        public ExpTabele()
        {
            ExpTabeleList = new Dictionary<int, int>();
            Initialize();
        }
        private void Initialize()
        {
            int level = 1;
            ExpTabeleList.Add(0, 0);
            for (int i = 1; i < Define.maxPlayerLevel + 1; i++)
            {
                ExpTabeleList.Add(i, (((i + 9) * i) * i) * 10);
                if (i > 255)
                {
                    ExpTabeleList[i] += ((((level + 9) * level) * level) * 1000);
                    level++;
                }
            }
        }
        public int GetCurrentExperience(int level)
        {

            return ExpTabeleList[level - 1];
           
        }
         public int GetCurrentNextExperience(int level)
        {

            return ExpTabeleList[level];
        }
    }
}

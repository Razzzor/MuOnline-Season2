using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Utility;
using Common.Enums;
namespace Common.Calculations
{
    public class Stats : Singleton<Stats>
    {
        //public int GetStamina(int race, int Strength,int Dexterity,int Vitality,int Energy)
        //{
        //    switch (race)
        //    {
        //        //case Race.DARK_WIZARD:
        //        //    return ((float)((Strength * 0.2) + (Dexterity * 0.4) + (Vitality * 0.3) + (Energy * 0.2)) + this->GetStamminaAdd());
        //        //    break;
        //        //case Race.DARK_KNIGHT:
        //        //    return ((float)((Strength * 0.15) + (Dexterity * 0.2) + (Vitality * 0.3) + (Energy * 1.0)) + this->GetStamminaAdd());
        //        //    break;
        //        //case Race.FAIRY_ELF:
        //        //    return ((float)((Strength * 0.3) + (Dexterity * 0.2) + (Vitality * 0.3) + (Energy * 0.2)) + this->GetStamminaAdd());
        //        //    break;
        //        //case Race.MAGIC_GLADIATOR:
        //        //    return ((float)((Strength * 0.2) + (Dexterity * 0.25) + (Vitality * 0.3) + (Energy * 0.15)) + this->GetStamminaAdd());
        //        //    break;
        //        // case Race.DARK_LORD:
        //        //    return ((float)((Strength * 0.3) + (Dexterity * 0.2) + (Vitality * 0.1) + (Energy * 0.15) + (Leadership * 0.3)) + this->GetStamminaAdd());
        //        //    break;
                
        //    }
        //}
        public int GetMaxLife(int level, Race  race, int vitaly)
        {
            return level;
            switch (race)
            {
                case Race.DARK_WIZARD:
                    return 60 + (level * 1) + (vitaly * 2);
                    
                case Race.DARK_KNIGHT:
                    return 110 + (level * 2) + (vitaly * 3);
                    
                case Race.FAIRY_ELF:
                    return 80 + (level * 1) + (vitaly * 2);
                    
               case Race.MAGIC_GLADIATOR:
                    return 110 + (level * 1) + (vitaly * 2);
                    
               case Race.DARK_LORD:
                    return 110 + (level * 1) + (vitaly * 1);
                    
            }
        }

        public int GetMaxMana(int level, Race race, int energy)
        {
            return level;
            switch (race)
            {
                case Race.DARK_WIZARD:
                    return 60 + (level * 2) + (energy * 2);
                    
                case Race.DARK_KNIGHT:
                    return 20 + ((int)((level * 0.5) + (energy * 2)));
                    
                case Race.FAIRY_ELF:
                    return 30 + ((int)((level * 1.5) + (energy * 1.5)));
                   
                case Race.MAGIC_GLADIATOR:
                    return 60 + (level * 1) + (energy * 2);
                   
                case Race.DARK_LORD:
                    return 60 + (level * 1) + (energy * 2);
                    
            }
        }

         //switch (race)
         //   {
         //       case Race.DARK_WIZARD:
         //           break;
         //       case Race.DARK_KNIGHT:
         //           break;
         //       case Race.FAIRY_ELF:
         //           break;
         //      case Race.MAGIC_GLADIATOR:
         //           break;
         //      case Race.DARK_LORD:
         //           break;
         //   }
    }
}

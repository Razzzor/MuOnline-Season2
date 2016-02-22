using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common.Calculations;
using Common.Model;
using Common.Enums;

namespace Common.Database
{
    public class TemplateDefaultPlayer
    {
        //public static Player Create(string name, int race, int accountIndex, int slot)
        //{
        //    Player player = new Player();
        //    player.accountIndex = accountIndex;
        //    player.slot = slot;
        //    player.playerIndex = 6;
        //    player.name = name;
        //    player.level = 1;
        //    player.race = race;
        //    ExpTabele expTabele = ExpTabele.Instance;
        //    player.experience = expTabele.GetCurrentExperience(player.level);
        //    player.experienceNext = expTabele.GetCurrentNextExperience(player.level);

        //    player.money = 0;
            

        //    player.playersKillCount = 0;
        //    player.playersKillLevel = 0;
        //    player.playersKillTime = 0;
        //    player.authority = 0;
        //    Position position;
        //    switch (race)
        //    {
        //        case (int)Race.DARK_WIZARD:
        //            {
        //                player.strength = 15;
        //                player.agility = 18;
        //                player.vitality = 18;
        //                player.energy = 30;
        //                player.command = 0;
        //                position = new Position(0, 141, 133, 0);
        //                player.position = position;
        //                break;
        //            }

        //        case (int)Race.DARK_KNIGHT:
        //            {
        //                player.strength = 25;
        //                player.agility = 20;
        //                player.vitality = 28;
        //                player.energy = 10;
        //                player.command = 0;
        //                position = new Position(0, 141, 133, 0);
        //                player.position = position;
        //                break;
        //            }
        //        case (int)Race.FAIRY_ELF:
        //            {
        //                player.strength = 20;
        //                player.agility = 25;
        //                player.vitality = 22;
        //                player.energy = 30;
        //                player.command = 0;
        //                position = new Position(2, 177, 119, 0);
        //                player.position = position;

        //                break;
        //            }
        //        case (int)Race.MAGIC_GLADIATOR:
        //            {
        //                player.agility = 26;
        //                player.vitality = 26;
        //                player.energy = 26;
        //                player.command = 1;
        //                position = new Position(0, 141, 133, 0);
        //                player.position = position;
        //                break;
        //            }
        //        case (int)Race.DARK_LORD:
        //            {
        //                player.strength = 1;
        //                player.agility = 20;
        //                player.vitality = 26;
        //                player.energy = 15;
        //                player.command = 25;
        //                position = new Position(0, 141, 133, 0);
        //                player.position = position;
        //                break;
        //            }
        //    }
        //            Stats stat = Stats.Instance;
        //            int life = stat.GetMaxLife(player.level, (Race)race, player.vitality);
        //            int mana = stat.GetMaxMana(player.level, (Race)race, player.energy);
        //            player.lifeStats = new LifeStats(life, life, mana, mana);                         
            
        //    return player;
        //}
    }
}

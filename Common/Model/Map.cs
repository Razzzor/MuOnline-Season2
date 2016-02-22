using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Utility;
namespace Common.Model
{
    public enum MapIndex
    {
        LORENCIA = 0,
        DUNGEON = 1,
        DEVIAS = 2,
        NORIA = 3,
        LOSTTOWER = 4,
        RESERVED = 5,
        ARENA = 6,
        ATLANS = 7,
        TARKAN = 8,
        DEVILSQUARE = 9,
        ICARUS = 10,
        BLOODCASTLE1 = 11,
        BLOODCASTLE2 = 12,
        BLOODCASTLE3 = 13,
        BLOODCASTLE4 = 14,
        BLOODCASTLE5 = 15,
        BLOODCASTLE6 = 16,
        BLOODCASTLE7 = 17,
        CHAOSCASTLE1 = 18,
        CHAOSCASTLE2 = 19,
        CHAOSCASTLE3 = 20,
        CHAOSCASTLE4 = 21,
        CHAOSCASTLE5 = 22,
        CHAOSCASTLE6 = 23,
        KALIMA1 = 24,
        KALIMA2 = 25,
        KALIMA3 = 26,
        KALIMA4 = 27,
        KALIMA5 = 28,
        KALIMA6 = 29,
        CASTLESIEGE = 30,
        CASTLEHUNTZONE = 31,
        DEVILSQUARE2 = 32,
        AIDA = 33,
        CRYWOLF = 34,
        EMPTY = 35,
        KALIMA7 = 36,
        KANTURU1 = 37,
        KANTURU2 = 38,
        KANTURU3 = 39,
        ILLUSIONTEMPLE1 = 45,
        ILLUSIONTEMPLE2 = 46,
        ILLUSIONTEMPLE3 = 47,
        ILLUSIONTEMPLE4 = 48,
        ILLUSIONTEMPLE5 = 49,
        ILLUSIONTEMPLE6 = 50,
        ELBELAND = 51,
        BLOODCASTLE8 = 52,
        CHAOSCASTLE7 = 53,
        SWAMPOFCALMNESS = 56,
        RAKLION = 57,
        HATCHERY = 58,
        SANTANAVILLAGE = 62,
        VULCANUS = 63,
        DUELARENA = 64,
        LORENMARKET = 79,
    };

   
    public class Map
    {
        

        public int mapIndex;
       
        public List<Player> players = new List<Player>();
        public List<Npc> npcs = new List<Npc>();
        public List<Item> items = new List<Item>();
        public object CreaturesLock = new object();

        public virtual void Release()
        {
            try
            {
                for (int i = 0; i < npcs.Count; i++)
                    npcs[i].Release();

                npcs.Clear();
            }
            catch (Exception ex)
            {
                Logger.Error("MapInstance: Dispose", ex);
            }
            try
            {
                for (int i = 0; i < items.Count; i++)
                    items[i].Release();

                items.Clear();
            }
            catch (Exception ex)
            {
                Logger.Error("MapInstance: Dispose", ex);
            }
        }
    }
}

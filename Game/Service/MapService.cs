using System;
using System.Collections.Generic;


using Common.Model;
using Common.Utility;
namespace Game.Service
{
   public class MapService : Singleton<MapService>
    {
       

        public static Dictionary<int, Map> Maps = new Dictionary<int, Map>();
        public static object MapLock = new object();
        int[] mapsIndex = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28,29, 30, 31, 32, 33, 34, 36, 37, 38, 39 };
       

      

        public void Action()
        {
           
        }

        public void Init()
        {
          

            foreach(int index in mapsIndex)
            {
                Map map = new Map();
                map.mapIndex = index;
                Maps.Add(index, map);
            }
          
        }

        public void SpawnMap(Map instance)
        {
         

            if (!Maps.ContainsKey(instance.mapIndex))
                Maps.Add(instance.mapIndex, instance);

         

        }

        public void SpawnObject(Creature obj, Map map)
        {
            var creature = obj as Creature;
            if (creature != null)
            {
                lock (map.CreaturesLock)
                {
                    if (obj is Npc)
                        map.npcs.Add((Npc) obj);
                    else if (obj is Player)
                        map.players.Add((Player) obj);
                   
                       
                    else if (obj is Item)
                        map.items.Add((Item) obj);
                    
                }

                creature.map = map;
            }
        }

        public void DespawnObject(Creature obj)
        {
            var creature = obj as Creature;
            if (creature != null)
            {
                lock (creature.map.CreaturesLock)
                {
                    if (creature is Npc)
                    {
                        creature.map.npcs.Remove((Npc) obj);
                        creature.visiblePlayers.Each(player =>
                                                         {
                                                             player.visibleNpcs.Remove((Npc) obj);
                                                             
                                                         });
                    }
                    else if (creature is Player)
                    {
                        creature.map.players.Remove((Player) obj);
                        creature.visiblePlayers.Each(player =>
                                                         {
                                                             player.visiblePlayers.Remove((Player) obj);
                                                             
                                                         });
                    }
                   
                    else if (creature is Item)
                    {
                        creature.map.items.Remove((Item) obj);
                        creature.visiblePlayers.Each(player =>
                                                         {
                                                             player.visibleItems.Remove((Item) obj);
                                                             
                                                         });
                    }
                  
                }

                if (!(creature is Player))
                    creature.Release();
            }
        }

        public void PlayerEnterWorld(Player player)
        {
            if (!Maps.ContainsKey(player.mapIndex))
            {
                return;
            }
               
            Map instance = Maps[player.mapIndex];

           


            SpawnObject(player, instance);

           
        }

        public void CreateDrop(Npc npc, Player player)
        {
            
        }

        public void PickUpItem(Player player, Item item)
        {
           
        }

        public void PlayerLeaveWorld(Player player)
        {
           
            
           DespawnObject(player);

            player.map = null;

           
        }

       
      

        

        private void DestructInstance(Map map)
        {
            map.Release();
            Maps.Remove(map.mapIndex);
        }

        
    }
}

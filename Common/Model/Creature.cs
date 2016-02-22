using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Common.Model
{
   public class Creature : DefaultObject
    {
       
       public List<Player> visiblePlayers = new List<Player>();
       public List<Npc> visibleNpcs = new List<Npc>();
       public List<Item> visibleItems = new List<Item>();
       
       public Map map;
       public Ai ai;
       
       [DataMember(Name = "Name")]
       public string name;
       [DataMember(Name = "Level")]
       public int level;
       [DataMember(Name = "MapIndex")]
       public int mapIndex;
       [DataMember(Name = "MapDirection")]
       public int mapDirection;
       [DataMember(Name = "MapPositionX")]
       public int mapPositionX;
       [DataMember(Name = "MapPositionY")]
       public int mapPositionY;
       [DataMember(Name = "Life")]
       public int life;
       [DataMember(Name = "LifeMax")]
       public int lifeMax;
       [DataMember(Name = "Mana")]
       public int mana;
       [DataMember(Name = "ManaMax")]
       public int manaMax;
     
       
       public override void Release()
       {
           visiblePlayers = null;
           visibleNpcs = null;
           visibleItems = null;
          
           map = null;
       }
    }
}

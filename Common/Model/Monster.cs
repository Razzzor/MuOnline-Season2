using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
  public class Monster : Creature
    {
   public int  index;
		public string name;
		
		
		public int	magicDefense;
		public int	attackSuccessRate;
		public int	defenseSuccessRate;
		public int	attackSpeed;
		public int	attackType;
		public int	attackRange;
		public int  viewRange;
		public int	moveRange;
		public int	moveSpeed;
		public int	respawnTime;
		public int	itemDropRate;
		public int	maxItemDropLevel;
		public int	moneyDropRate;	
		public int	windProtect;
		public int	poisonProtect;
		public int	iceProtect;
		public int	electricProtect;
		public int	fireProtect;
		public int	minDamage;
		public int	maxDamage;
        public int  defense;
    }
}

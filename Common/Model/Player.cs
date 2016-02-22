using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Common.Network;
using Common.Crypt;

namespace Common.Model
{

    
   public class Player : Creature
    {
       public SocketClient networkClient;
        
       [DataMember(Name = "AccountIndex")]
        public int accountIndex;
       [DataMember(Name = "PlayerIndex")]
       public int index;
        [DataMember(Name = "Slot")]
        public int slot;
       
        [DataMember(Name = "LevelUpPoints")]
        public int levelUpPoints;
        [DataMember(Name = "Race")]
        public int race;
        [DataMember(Name = "Experience")]
        public int experience;
        [DataMember(Name = "ExperienceNext")]
        public int experienceNext;
        [DataMember(Name = "Strength")]
        public int strength;
        [DataMember(Name = "Agility")]
        public int agility;
        [DataMember(Name = "Vitality")]
        public int vitality;
        [DataMember(Name = "Energy")]
        public int energy;
        [DataMember(Name = "Command")]
        public int command;
        [DataMember(Name = "Money")]
        public int money;

       

        public int ag;
        public int agMax;
        public int sd;
        public int sdMax;
        
        [DataMember(Name = "Authority")]
        public int authority;
     
        public int fruitAddPoint = 0;
      
        public int fruitMaxAddPoint = 0;
        
        public int fruitMinusPoint = 0;
        
        public int fruitMaxMinusPoint = 0;
       
        [DataMember(Name = "PlayersKillCount")]
        public int playersKillCount;
        [DataMember(Name = "PlayerKillLevel")]
	    public int playerKillLevel;
        [DataMember(Name = "PlayerKillTime")]
	    public int playerKillTime;
        public bool isBanned ;
        public Storage inventory;
        public Storage warehouse;
        public Party party;
        public Guild guild;
        public Duel duel;
       
       public void Send(byte[] data)
        {
           byte[] encryptData;
           CryptProcess.EncryptAsServer(data,out encryptData, 0);
           networkClient.Send(encryptData);
        }
    }
}

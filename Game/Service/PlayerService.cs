using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

using Common.Enums;
using Common.Model;
using Common.Utility;
using Common.Database;

using Game.Packet.Server;

namespace Game.Service
{
   public class PlayerService : Singleton<PlayerService>
    {
        public static List<Player> playersOnline = new List<Player>();

        public List<Player> GetOnline()
        {
            return playersOnline;
        }

        public void PlayerRegisterViewportObject(Player player,Creature creature)
        {
            if(creature is Player)
            {
                player.visiblePlayers.Each(p => player.Send(new SpPlayerViewport().Execute(p as Player)));
                Player otherPlayer = creature as Player;
                creature.visiblePlayers.Each(p => otherPlayer.Send(new SpPlayerViewport().Execute(p as Player)));
            }
        }

        public void PlayerDisposeViewportObject(Player creature)
        {
            if (creature is Player)
            {

            }
        }

        public void PlayerEnterWorld(Player player)
        {
            playersOnline.Add(player);
            
            
        }

        public void PlayerEndGame(Player player)
        {
          

            playersOnline.Remove(player);
        }



       public Player GetPlayerByName(string playerName)
        {
            try
            {
                return playersOnline.First(player => player.name == playerName);
            }
            catch
            {
                
            }
            return null;
        }
        public CheckNameResult CheckName(string name)
        {
            if (name.Length < 2)
                return CheckNameResult.MinimumLengthIs2;

            if (name.Length > 10)
                return CheckNameResult.MaximumLengthIs16;

            for (int i = 0; i < name.Length; i++)
                if (name[i] == ' ')
                    return CheckNameResult.YouCantUseSpacesInCharacterName;

            if (!Regex.IsMatch(name, "^[a-z]+$", RegexOptions.IgnoreCase))
                return CheckNameResult.UnavaliableLatter;

            if (DatabaseOperations.CheckPlayersNameAvailable(name.ToLower())) 
                return CheckNameResult.ThisSsNotAcceptableCharacterName;

            return CheckNameResult.Ok;
        }

        
       public Player CreatePlayer(User user, string playerName,int race)
        {
            int slot = DatabaseOperations.GetNewPlayerEmptySlot(user.account.index);
            Player player = new Player();// = TemplateDefaultPlayer.Create(playerName,race,user.account.accountIndex,slot);
                               

           
            return player;
        }

        public int GetOnlinePlayersCount()
        {
            return playersOnline.Count;
        }
        public List<Player> GetOnlinePlayers()
        {
            return playersOnline;
        }
        public void Send(byte[] data)
        {
            playersOnline.Each(x => x.Send(data));
        }

        public void PlayerMoved(Player player, int x1, int y1, int x2, int y2 ,int direction)
        {
            player.mapPositionX = x1;
            player.mapPositionY = y1;
         
            player.mapDirection = direction;

            
        }

         public bool IsPlayerOnline(Player player)
        {
            return playersOnline.Contains(player);
        }


        

        
        

     

       

      

       
    }
}
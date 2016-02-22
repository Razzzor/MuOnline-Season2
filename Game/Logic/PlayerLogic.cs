using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common.Model;
using Common.Database;
using Game.Service;
using Common.Enums;
using Game.Packet.Server;
namespace Game.Logic
{
   public class PlayerLogic
    {
       public static void AccountPlayerList(User user)
       {
           FeedbackService.Instance.SendPlayersList(user);
       }
       public static void PlayerEnterWorld(User user, string playerName)
       {
           int playerIndex = DatabaseOperations.GetPlayerIndexByName(playerName);
           Player player = DatabaseOperations.GetObject<Player>(playerIndex);

           if (player == null)
               return;

           user.player = player;
           player.networkClient = user.networkClient;
           user.account.online = true;

           
          
           MapService.Instance.PlayerEnterWorld(player);
           PlayerService.Instance.PlayerEnterWorld(player);
         
          

           PartyService.Instance.UpdateParty(player);
          
           FeedbackService.Instance.PlayerEnterWorld(player);
       }
       public static void PlayerEndGame(Player player)
       {
           if (player == null) return;

           PlayerService.Instance.PlayerEndGame(player);
           MapService.Instance.PlayerLeaveWorld(player);
         

           PartyService.Instance.UpdateParty(player);

           
       }
       
       public static void CreatePlayer(User user,string playerName,int race)
       {
           if (DatabaseOperations.GetAccountPlayersCount(user.account.index) >= 5 || PlayerService.Instance.CheckName(playerName) != CheckNameResult.Ok)
           {
               FeedbackService.Instance.SendCreatePlayerFailResult(user,playerName);
               return;
           }

           Player player = PlayerService.Instance.CreatePlayer(user, playerName,race);
           DatabaseOperations.SaveObject(player);

           FeedbackService.Instance.SendCreatePlayerSuccessResult(user);

           DatabaseOperations.SaveObject(player);
       }
       public static void DeletePlayer(User user, string secureNumber, string playerName)
       {
           if (!user.account.securityNumber.Equals(secureNumber))
           {
             FeedbackService.Instance.SendDeletePlayerFailNumber(user);
               return;
           }
           int playerIndex = DatabaseOperations.GetPlayerIndexByName(playerName);
           Player player = DatabaseOperations.GetObject<Player>(playerIndex);
           if (player.guild != null)
           {
               FeedbackService.Instance.SendDeletePlayerFailGuild(user);
               return;
           }
           if (player.isBanned)
           {
               FeedbackService.Instance.SendDeletePlayerFailBanned(user);
               return;
           }
           DatabaseOperations.RemovePlayer(playerIndex);
           FeedbackService.Instance.SendDeletePlayerSuccessResult(user);
       }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common.Model;
using Common.Utility;
using Game.Packet.Server;

namespace Game.Service
{
    public class FeedbackService : Singleton<FeedbackService>
    {
        public void PlayerEnterWorld(Player player)
        {
            player.Send(new SpPlayerEnterWorld().Execute(player));
        }
        public void SendDeletePlayerSuccessResult(User user)
        {
            user.Send(new SpPlayerDeleteSuccess().Execute());
        }
        public void SendDeletePlayerFailGuild(User user)
        {
            user.Send(new SpPlayerDeleteGuildBlock().Execute());
        }
        public void SendDeletePlayerFailNumber(User user)
        {
             user.Send(new SpPlayerDeleteInvalidNumber().Execute());
        }
        public void SendDeletePlayerFailBanned(User user)
        {
            user.Send(new SpPlayerDeleteBanned().Execute());
        }
        public void SendCreatePlayerSuccessResult(User user)
        {

            user.Send(new SpPlayerCreateSuccess().Execute(user.player));
            
        }
        public void SendCreatePlayerFailResult(User user,string playerName)
        {

            user.Send(new SpPlayerCreateFail().Execute(playerName));

        }
        public void SendPlayersList(User user)
        {
            user.Send(new SpPlayersList().Execute(user.account.index));
        }
    }
}

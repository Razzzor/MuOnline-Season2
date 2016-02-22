using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Packet;
using Common.Model;
using Common.Utility;

using Game.Network;
using Game.Packet.Server;
using Game.Logic;

namespace Game.Packet.Client
{


    public class RpMove : PacketReader
    {
        public override void Execute(User user)
        {

          
            byte opCode = ReadByte();
            byte sizeCode = ReadByte();
            byte headCode = ReadByte(); 
            int positionX= ReadByte();
            int positionY = ReadByte();
          
            user.player.mapPositionX = positionX;
            user.player.mapPositionY = positionY;
          //  user.player.visiblePlayers.Each(p => p.Send(new SpPlayerViewport().Execute(p)));
          //  user.account.Send(new PlayerMapJoinAnswer().Execute(player));
            return;
        }
    }
}

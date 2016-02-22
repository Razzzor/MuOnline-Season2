using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Packet;
using Common.Model;
using Common.Database;

using Game.Network;
using Game.Logic;
using Game.Packet.Server;

namespace Game.Packet.Client
{


    public class RpPlayerDelete : PacketReader
    {
        public override void Execute(User user)
        {

            byte opCode = ReadByte();
            byte sizeCode = ReadByte();
            byte headCode = ReadByte(); 
            byte subCode = ReadByte(); 
            string playerName = ReadString( 10);
            string secureNumber = ReadString( 7);
            PlayerLogic.DeletePlayer(user,secureNumber, playerName);
            return;
        }
    }
}

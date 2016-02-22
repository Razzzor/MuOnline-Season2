using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Packet;
using Common.Model;


using Game.Network;
using Game.Packet.Server;

namespace Game.Packet.Client
{


    public class RpTradeResponse : PacketReader
    {
        public override void Execute(User user)
        {


            byte opCode = ReadByte();
            byte sizeCode = ReadByte();
            byte headCode = ReadByte();


            int Response = ReadByte();
            string Id = ReadString(10);
            int level = ReadInt16();
            int guildNumber = ReadInt32();


            return;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Packet;
using Common.Model;
using Common.Database;

using Game.Network;
using Game.Packet.Server;
using Game.Logic;

namespace Game.Packet.Client
{


    public class RpPlayerEnterWorld : PacketReader
    {
        public override void Execute(User user)
        {
            byte opCode = ReadByte();
            int sizeCode = ReadByte();
            byte headCode = ReadByte();
            byte subCode = ReadByte(); 
            string playerName = ReadString(10);
            PlayerLogic.PlayerEnterWorld(user, playerName);
           
           
           
            return;
        }
    }
}

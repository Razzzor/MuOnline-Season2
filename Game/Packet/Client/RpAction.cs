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
   
    
    public class RpAction : PacketReader
    {
        public override void Execute(User user)
        {

           
            byte opCode = ReadByte();
            byte sizeCode = ReadByte();
            byte headCode = ReadByte(); 
            int dir = ReadByte();
            int actionNumber = ReadByte();
           // int targetIndex = packetReader.ReadInt16();
           
            return;
        }
    }
}

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
   
    [PacketOperationAttribute(headCode: 0x1B)]
    public class RpMagicAttackCancel : AbstractPacketOperation
    {
        public override void Execute(User user, PacketReader packetReader)
        {

          
            byte opCode = packetReader.ReadByte();
            byte sizeCode = packetReader.ReadByte();
            byte headCode = packetReader.ReadByte(); 
            int magicNumber= packetReader.ReadByte();
            int number = packetReader.ReadInt16();
          
            return;
        }
    }
}

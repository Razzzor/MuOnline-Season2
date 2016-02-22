using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Model;
using Common.Packet;
using Common.Utility;

namespace Game.Packet.Server
{
   public class SubscriptionTimeOverAnswer
    {
       public byte[] Execute(User user)
       {
           PacketWriter packetWriter = new PacketWriter();
           packetWriter.WriteByte(0xC1);//opCode
           packetWriter.WriteByte(0x05);//sizeCode
           packetWriter.WriteByte(0xF1);//headCode
           packetWriter.WriteByte(0x01);//subcode
           packetWriter.WriteByte(0x0B);//result


           return packetWriter.Compile();
       }
    }
}

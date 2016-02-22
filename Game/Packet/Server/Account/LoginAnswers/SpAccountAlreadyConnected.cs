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
    public class SpAccountAlreadyConnected : PacketWriter
    {
        public byte[] Execute(User user)
        {
           
            WriteByte(0xC1);//opCode
            WriteByte(0x05);//sizeCode
            WriteByte(0xF1);//headCode
            WriteByte(0x01);//subcode
            WriteByte(0x03);//result


            return Compile();
        }
    }
}

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
    public class SpPlayerDeleteBanned : PacketWriter
    {
        public byte[] Execute()
        {
          
           
            WriteByte(0xC1);//opCode
            WriteByte(0x05);//sizeCode
            WriteByte(0xF3);//headCode
            WriteByte(0x02);//subcode
            WriteByte(0x00);//result

            return Compile();
        }
    }
}

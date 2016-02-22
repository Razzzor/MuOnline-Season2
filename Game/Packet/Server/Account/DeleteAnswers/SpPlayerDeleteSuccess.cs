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
    public class SpPlayerDeleteSuccess : PacketWriter
    {
        public byte[] Execute()
        {
            
           // C1 05 F3 02 01 
            WriteByte(0xC1);//opCode
            WriteByte(0x05);//sizeCode
            WriteByte(0xF3);//headCode
            WriteByte(0x02);//subcode
            WriteByte(0x01);//result

          
            return Compile();
        }
    }
}

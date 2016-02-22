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
    public class SpPlayerCreateFail : PacketWriter
    {
        public byte[] Execute(string playerName)
        {
        
            WriteByte(0xC1);//opCode
            WriteByte(0x2C);//sizeCode
            WriteByte(0xF3);//headCode
            WriteByte(0x01);//subcode
            WriteByte(0x00);//result
            WriteString(playerName, 10);
            WriteByte(0 );//slot
            WriteInt16(0);//slot
            WriteByte(0);
            WriteByte(0);
            for (int i = 0; i < 24; i++)
            {
                WriteByte(0x00);
            }
                return Compile();
        }
    }
}

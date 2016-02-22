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
    public class SpPlayerCreateSuccess : PacketWriter
    {
        public byte[] Execute(Player playerNew)
        {
            
            WriteByte(0xC1);//opCode
            WriteByte(0x2C);//sizeCode
            WriteByte(0xF3);//headCode
            WriteByte(0x01);//subcode
            WriteByte(0x01);//result
            WriteString(playerNew.name, 10);
            WriteByte(playerNew.slot );//slot
            WriteInt16(playerNew.level);//slot
           
            WriteByte(playerNew.race << 1);
            WriteByte(playerNew.authority);
            for (int i = 0; i < 24; i++)
            {
               WriteByte(0xFF);
            }
                return Compile();
        }
    }
}

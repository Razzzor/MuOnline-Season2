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
    public class SpSetItemDuration : PacketWriter 
    {

      
        public byte[] Execute(Player player)
        {

            WriteByte(0xC1);
            WriteByte(0x18); //(size)
            WriteByte(0x2A); //head
            WriteByte(0x05);//ItemPosition
            WriteByte(0x05);//Duration
            WriteByte(0x05); //flag
            return Compile();
        }
    }
}

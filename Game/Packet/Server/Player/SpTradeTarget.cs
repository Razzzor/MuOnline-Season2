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
    public class SpTradeTarget : PacketWriter 
    {

      
        public byte[] Execute(string playerSenderName)
        {
            
            WriteByte(0xC1);
            WriteByte(0x0D); //(size)
            WriteByte(0x36); //head
            WriteString(playerSenderName, 10);
            return Compile();
        }
    }
}

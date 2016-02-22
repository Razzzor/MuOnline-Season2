
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
   public class SpWelcomeNotice : PacketWriter
    {
       public byte[] Execute(User user)
       {
           
           WriteByte(0xC1);//opCode
           WriteByte(0xFF);
           WriteByte(0x0D);//type
           WriteByte(0x01);//loop count
           WriteByte(0x0B);//loopdelay
           WriteByte(0x00);//unk
           WriteInt32(0x0B);//Color
           WriteByte(0x0B);//Speed
           string text = "fdsfdsfds";
           WriteString(text, 241);
            WriteByte(0x00);//null terminate
           return Compile();
       }
    }
}

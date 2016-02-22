using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using Common.Model;
using Common.Packet;
using Common.Utility;

namespace Game.Packet.Server
{
    public class SpSendClientVersion : PacketWriter
    {
        public byte[] Execute(User user)
        {
            
            WriteByte(0xC1);//opCode
            WriteByte(0x0C);//sizeCode
            WriteByte(0xF1);//headCode
            WriteByte(0x00);//subcode
            WriteByte(0x01);//result
            WriteByte(0x24);
            WriteByte(0xB9);
            char[] delimiters = new char[] { '.' };
            string[] trimVersionByDots = Define.mainVersion.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in trimVersionByDots)
            {
                WriteBytes(TypeConverter.StringToByteArray(part));
            }

      
           
            return Compile();
        }
    }
}

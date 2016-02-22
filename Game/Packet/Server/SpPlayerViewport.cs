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
    public class SpPlayerViewport : PacketWriter
    {
        

        public byte[] Execute(Player player)
        {
            int playersCount = 1;
            byte[] sample = new byte[] { 0x01, 0x00, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0xF8, 0x00, 0x00, 0x00, 0xCF, 0xFF, 0xFF, 0x00, 0x00 };
            WriteByte(0xC2);
            WriteByte(0x00);
            WriteByte(0x31);
            WriteByte(0x12); //headcode
            WriteByte(playersCount);
            WriteInt16(player.index);
            WriteByte(player.mapPositionX);
            WriteByte(player.mapPositionY);
            WriteByte(player.race << 1);
            WriteBytes(sample);
            WriteInt32(0);
            WriteByte(0x00);
            WriteByte(0x00);
            WriteString(player.name, 10);
            WriteByte(player.mapPositionX);
            WriteByte(player.mapPositionY);
            byte directionAndPlayerKillerLevel = (byte)((player.mapDirection << 4) | player.playerKillLevel);
            WriteByte(directionAndPlayerKillerLevel);
            WriteByte(0x00);
            WriteByte(0x00);
            WriteByte(0x00);
            return Compile();
        }
    }
   
}

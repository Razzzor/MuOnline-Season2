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

    public class SpPlayerEnterWorld : PacketWriter
    {

        public byte[] Execute(Player player)
        {
          
            WriteByte(0xC3);//opCode
            WriteByte(0x3A);//sizeCode
            WriteByte(0xF3);//headCode
            WriteByte(0x03);//subcode

            WriteByte(player.mapPositionX);
            WriteByte(player.mapPositionY);
            WriteByte(player.mapIndex);
            WriteByte(player.mapDirection);
            WriteInt32(player.experience);
            WriteInt32(player.experienceNext);
            WriteInt16(player.levelUpPoints);
            WriteInt16(player.strength);
            WriteInt16(player.agility);
            WriteInt16(player.vitality);
            WriteInt16(player.energy);
            WriteInt16(player.life);
            WriteInt16(player.lifeMax);
            WriteInt16(player.mana);
            WriteInt16(player.manaMax);
            WriteInt16(player.ag);
            WriteInt16(player.agMax);
            WriteInt16(player.sd);
            WriteInt16(player.sdMax);
            WriteInt32(player.money);
            WriteByte(player.playerKillLevel);
            WriteByte(player.authority);
            WriteInt16(player.fruitAddPoint);
            WriteInt16(player.fruitMaxAddPoint);
            WriteInt16(player.command);
            WriteInt16(player.fruitMinusPoint);
            WriteInt16(player.fruitMaxMinusPoint);
            return Compile();
        }
    }
}
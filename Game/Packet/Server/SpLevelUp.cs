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
    public class SpLevelUp : PacketWriter 
    {

      
        public byte[] Execute(Player player)
        {
            
            WriteByte(0xC1);//opCode
           

            //WriteByte( 0xC1);
            //WriteByte( 0x18); //(size)
            //WriteByte(0xF3); //head
            //WriteByte(0x05); //sub
            //WriteInt16(player.level); //(level [unsigned char])
            //WriteInt16(player.levelUpPoints); //(level up points [unsigned short])
            //WriteInt16(player.lifeMax); //(max hp [unsigned short])
            //WriteInt16(player.manaMax); //(max mp [unsigned short])
            //WriteInt16(player.sdMax); //(max shield(sd) [unsigned short])
            //WriteInt16(player.agMax); //(?? max stamina ?? [unsigned short])
            ///*writeSh(0); //(?? Add points ?? [short])
            //writeSh(0); //(?? Max Add points ?? [short])
            //writeSh(0); //(?? Minus points ?? [short])
            //writeSh(0); //(?? Max Minus points ?? [short])*/
            //WriteInt32(player.experience);
            //WriteInt32(player.experienceNext);
            return Compile();
        }
    }
}

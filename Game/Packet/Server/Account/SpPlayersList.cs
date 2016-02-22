using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Common.Model;
using Common.Packet;
using Common.Utility;
using Common.Database;

namespace Game.Packet.Server
{
    public class SpPlayersList : PacketWriter
    {
   
        public byte[] noEquippedItems = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0xF8, 0x00, 0x00, 0xF0, 0xFF, 0xFF, 0xFF, 0x00, 0x00 };
        public byte[] Execute(int accountIndex)
        {

            List<Player> players = DatabaseOperations.GetAccountPlayers(accountIndex);
            int size = 7 + (players.Count * 34);
            WriteByte(0xC1);//opCode
            WriteByte(size);//sizeCode
            WriteByte(0xF3);//headCode
            WriteByte(0x00);//subcode
            int highestAccountPlayerLevel = DatabaseOperations.GetHighestAcountPlayerLevel(accountIndex);
            int availableRaces = 2;
            if(highestAccountPlayerLevel >= Define.mgLevelRequired)
            {
                availableRaces = 3;
            }
            if (highestAccountPlayerLevel >= Define.dlLevelRequired)
            {
                availableRaces = 4;
            }
            WriteByte(availableRaces);// availableRaces
            WriteByte(0x00);
            
            WriteByte(players.Count);//characterList.size

            for (int i = 0; i < players.Count; ++i)
            {
                WriteByte(players[i].slot);
                WriteString(players[i].name, 10);
                WriteByte(0x00);//??

                WriteInt16(players[i].level);

                WriteByte(players[i].authority);
                WriteByte(players[i].race << 1);

                if (players[i].inventory==null)
                {
                    WriteBytes(noEquippedItems);
                }
                if (players[i].guild==null)
                {
                   WriteByte(0xFF); // guild status.
                }
            }
            return Compile();
        }
    }
}

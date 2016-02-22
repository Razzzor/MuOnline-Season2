using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common.Packet;
using Common.Model;
using Game.Logic;
using Game.Network;
using Game.Packet.Server;

namespace Game.Packet.Client
{


    public class RpPlayerCreate : PacketReader
    {
           public override void Execute(User user)
           {

               byte opCode = ReadByte();
               byte sizeCode = ReadByte();
               byte headCode = ReadByte(); 
               byte subCode = ReadByte(); 
               string playerName = ReadString(10);
               int playerRace = ReadByte();
               PlayerLogic.CreatePlayer( user,playerName, playerRace );
               
             
           }
    }

}

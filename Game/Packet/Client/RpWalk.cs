using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Packet;
using Common.Model;


using Game.Network;
using Game.Packet.Server;
using Common.Utility;

namespace Game.Packet.Client
{
   
    
    public class RpWalk : PacketReader
    {
        public override void Execute(User user)
        {

             short[] stepDirections = new short[] { -1, -1, 0, -1, 1, -1, 1, 0,
			1, 1, 0, 1, -1, 1, -1, 0 };
            byte opCode = ReadByte();
            byte sizeCode = ReadByte();
            byte headCode = ReadByte(); 
            int positionX= ReadByte();
            int positionY = ReadByte();
            byte value = ReadByte();
            int headingDirection = (value >> 4) & 0x0F ;
            int stepsCount = value & 0x0F;
            byte[] data = Content;
           
            
            short stepDirection = 0;
            for (int i = 0; i < stepsCount; i++)
            {
                if ((i & 1) == 0)
                {
                    stepDirection = (short)((data[6 + i / 2] >> 4) & 0x0F);
                }
                else
                {
                    stepDirection = (short)(data[6 + i / 2] & 0x0F);
                }
                positionX += stepDirections[stepDirection * 2];
                positionY += stepDirections[stepDirection * 2 + 1];
            }
            user.player.mapPositionX = positionX;
            user.player.mapPositionY = positionY;
            user.player.mapDirection = headingDirection;
            user.player.visiblePlayers.Each(p => p.Send(new SpPlayerViewport().Execute(user.player)));
          //  user.account.Send(new PlayerMapJoinAnswer().Execute(player));
            return;
        }
    }
}

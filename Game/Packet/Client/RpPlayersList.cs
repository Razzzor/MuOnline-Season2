using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Packet;
using Common.Model;

using Game.Logic;
using Game.Packet.Server;

namespace Game.Packet.Client
{


    public class RpPlayersList : PacketReader
    {
        public override void Execute(User user)
        {
            PlayerLogic.AccountPlayerList(user);
            return;
        }
    }
}

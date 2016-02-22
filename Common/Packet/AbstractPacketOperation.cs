using System;
using System.IO;
using System.Text;

using Common.Model;


namespace Common.Packet
{
    public abstract class AbstractPacketOperation 
    {
        public AbstractPacketOperation()
        {

        }
        public abstract void Execute(User user, PacketReader packetReader);
       

    }
}
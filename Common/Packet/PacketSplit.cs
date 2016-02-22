using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Common.Packet
{
   public class PacketSplit
    {
        public static Queue<byte[]> SplitMessage(byte[] data)
        {
            Queue<byte[]> splitPackets = new Queue<byte[]>();

            if (data[0].Equals(0xC1) || data[0].Equals(0xC2) || data[0].Equals(0xC3) || data[0].Equals(0xC4))
            {
                for (int i = 0; i < data.Length; )
                {
                    if (data[i].Equals(0xC1) || data[i].Equals(0xC2) || data[i].Equals(0xC3) || data[i].Equals(0xC4))
                    {
                        if (data[i].Equals(0xC1) || data[i].Equals(0xC3))
                        {
                            int SizePacket = data[i + 1];
                            if (data.Length - i >= SizePacket)
                            {
                                byte[] Packet = new byte[SizePacket];
                                Array.Copy(data, i, Packet, 0, Packet.Length);
                                splitPackets.Enqueue(Packet);
                                i += SizePacket;
                            }
                            else
                            {
                                if (splitPackets.Count > 0) { return splitPackets; }
                                else { return null; }
                            }
                        }
                        else
                        {
                            int SizePacket = data[i + 1] * 0x100 + data[i + 2];
                            if (data.Length - i >= SizePacket)
                            {
                                byte[] Packet = new byte[SizePacket];
                                Array.Copy(data, i, Packet, 0, Packet.Length);
                                splitPackets.Enqueue(Packet);
                                i += SizePacket;
                            }
                            else
                            {
                                if (splitPackets.Count > 0) { return splitPackets; }
                                else { return null; }
                            }
                        }

                    }
                    else
                    {
                        if (splitPackets.Count > 0) { return splitPackets; }
                        else { return null; }
                    }
                }
                return splitPackets;
            }
            else
            {
                return null;
            }
        }
    }
}


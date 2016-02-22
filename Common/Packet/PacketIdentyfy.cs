using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Packet
{
   public class PacketIdentyfy
    {

        public static bool IsStartWithHeader(byte[] data)
        {
            if (data[0] == 0xC1 || data[0] == 0xC3 || data[0] == 0xC2 || data[0] == 0xC4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsValidPacket(byte[] data)
        {
            if (!IsStartWithHeader(data))
            {
                return false;
            }
            int size = GetSize(data);
            if (size != 0 && size > data.Length || size > data.Length)
            {
                return false;
            }
            return true;
        }

        public static int GetHeaderSize(byte[] data)
        {
            if (data[0] == 0xC1 || data[0] == 0xC3) return 2;
            if (data[0] == 0xC2 || data[0] == 0xC4) return 3;
            return 0;
        }
        public static int GetSize(byte[] data)
        {
           
            return GetPacketSize(data);
        }
        public static byte GetHeadCode(byte[] data)
        { 
            int headerSize = GetHeaderSize(data);
            return data[headerSize];
        }
        public static byte GetSubCode(byte[] data)
        {
            int headerSize = GetHeaderSize(data);
            return data[headerSize + 1];
        }
        public static int GetPacketSize(byte[] data)
        {
            if (data[0] == 0xC1 || data[0] == 0xC3) return data[1]; ;
            if (data[0] == 0xC2 || data[0] == 0xC4) return (ushort)(data[1] * 0x100 + data[2]);
            return 0;
        }
    }
}

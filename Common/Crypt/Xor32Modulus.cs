using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Crypt
{
    public static class Xor32Modulus
    {

        //##############################################################################################################################
        private static readonly byte[] loginKeys = new byte[] { 0xFC, 0xCF, 0xAB };
        //##############################################################################################################################
        public static void EncDecLogin(ref byte[] Buffer, int BufferIndex, int Length)
        {
            for (int i = 0; i < Length; ++i)
                Buffer[BufferIndex + i] ^= loginKeys[i % 3];
        }
        //##############################################################################################################################



        //##############################################################################################################################
        public static void InitKeys(bool isOldKeys)
        {
            if (isOldKeys) { c1C2Keys = oldXorKeys; }
            else { c1C2Keys = newXorKeys; }

        }
        private static byte[] c1C2Keys = new byte[32];
        //##############################################################################################################################
        private static readonly byte[] oldXorKeys = new byte[]
        {
			0xE7, 0x6D, 0x3A, 0x89, 0xBC, 0xB2, 0x9F, 0x73,
			0x23, 0xA8, 0xFE, 0xB6, 0x49, 0x5D, 0x39, 0x5D,
			0x8A, 0xCB, 0x63, 0x8D, 0xEA, 0x7D, 0x2B, 0x5F,
			0xC3, 0xB1, 0xE9, 0x83, 0x29, 0x51, 0xE8, 0x56
		};
        //##############################################################################################################################
        private static readonly byte[] newXorKeys = new byte[]
        {
              0xAB, 0x11, 0xCD, 0xFE, 0x18, 0x23, 0xC5, 0xA3,
              0xCA, 0x33, 0xC1, 0xCC, 0x66, 0x67, 0x21, 0xF3,
              0x32, 0x12, 0x15, 0x35, 0x29, 0xFF, 0xFE, 0x1D,
              0x44, 0xEF, 0xCD, 0x41, 0x26, 0x3C, 0x4E, 0x4D
        };
        //##############################################################################################################################
        public static void EncXor32(byte[] buffer, int bufferIndex, int length, int headerSize)
        {
            for (int p = 1; p < length; ++p)
                buffer[bufferIndex + p] ^= (byte)(buffer[bufferIndex + p - 1] ^ c1C2Keys[(p + headerSize) % 32]);
        }
        //##############################################################################################################################
        public static void DecXor32(byte[] buffer, int bufferIndex, int length, int headerSize)
        {
            --length;
            for (int p = length; p > 0; --p)
                buffer[bufferIndex + p] ^= (byte)(buffer[bufferIndex + p - 1] ^ c1C2Keys[(p + headerSize) % 32]);
        }
        //##############################################################################################################################
    }
}

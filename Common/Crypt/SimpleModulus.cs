using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Common.Crypt
{
    public static class SimpleModulus
    {
        public static void InitCryptSite(bool IsServer)
        {
            if (IsServer) { decryptKeys = serverDecryptKeys; encryptKeys = serverEncryptKeys; }
            else { decryptKeys = clientDecryptKeys; encryptKeys = clientEncryptKeys; }
        }
        //#####################################################################################################################################################
        private static uint[] decryptKeys = new uint[12];
        private static uint[] encryptKeys = new uint[12];
        private static readonly uint[] clientDecryptKeys = new uint[] { 73326, 109989, 98843, 171058, 18035, 30340, 24701, 11141, 62004, 64409, 35374, 64599 };
        private static readonly uint[] clientEncryptKeys = new uint[] { 128079, 164742, 70235, 106898, 23489, 11911, 19816, 13647, 48413, 46165, 15171, 37433 };
        private static readonly uint[] serverDecryptKeys = new uint[] { 128079, 164742, 70235, 106898, 31544, 2047, 57011, 10183, 48413, 46165, 15171, 37433 };
        private static readonly uint[] serverEncryptKeys = new uint[] { 73326, 109989, 98843, 171058, 13169, 19036, 35482, 29587, 62004, 64409, 35374, 64599 };
    
        //#####################################################################################################################################################
        public static int Encrypt(byte[] dest, int destIndex, byte[] src, int srcIndex, int size)
        {
            int iOriSize;
            int iTempSize2;
            int iTempSize = size;
            int iDec = ((size + 7) / 8);
            size = (iDec + iDec * 4) * 2 + iDec;
            if (dest != null)
            {
                iOriSize = iTempSize;
                for (int i = 0; i < iTempSize; i += 8, iOriSize -= 8, destIndex += 11)
                {
                    iTempSize2 = iOriSize;
                    if (iOriSize >= 8) { iTempSize2 = 8; }
                    EncryptBlock(dest, destIndex, src, srcIndex + i, (uint)iTempSize2, encryptKeys);
                }
            }
            return size;
        }
        //#####################################################################################################################################################
        public static int Decrypt(byte[] dest, int destIndex, byte[] src, int srcIndex, int size)
        {
            int result = 0;
            int decLen = 0;
            if (dest == null)
            {
                return size * 8 / 11;
            }
            if (size > 0)
            {
                while (decLen < size)
                {
                    int TempResult = DecryptBlock(dest, destIndex, src, srcIndex, decryptKeys);
                    if (result < 0)
                    {
                        return result;
                    }
                    result += TempResult;
                    decLen += 11;
                    srcIndex += 11;
                    destIndex += 8;
                }
            }
            return result;
        }
        //#####################################################################################################################################################
        private static void ShiftRight(byte[] buffer, int bufferIndex, uint len, uint shift)
        {
            if (shift == 0) return;
            for (int i = 1; i < len; ++i)
            {
                buffer[bufferIndex] = (byte)((buffer[bufferIndex] << (int)shift) | (buffer[bufferIndex + 1] >> (8 - (int)shift)));
                ++bufferIndex;
            }
            buffer[bufferIndex] <<= (int)shift;
        }
        //#####################################################################################################################################################
        private static void ShiftLeft(byte[] buffer, int bufferIndex, uint len, uint shift)
        {
            if (shift == 0) return;
            bufferIndex += (int)len - 1;
            for (int i = 1; i < len; ++i)
            {
                buffer[bufferIndex] = (byte)((buffer[bufferIndex] >> (int)shift) | (buffer[bufferIndex - 1] << (8 - (int)shift)));
                --bufferIndex;
            }
            buffer[bufferIndex] >>= (int)shift;
        }
        //#####################################################################################################################################################
        private static int AddBits(byte[] dest, int destIndex, uint destBitPos, byte[] src, int srcIndex, uint bitSourcePos, uint bitLen)
        {
            uint tempBufferLen = ((((bitLen + bitSourcePos) - 1) / 8) + (1 - (bitSourcePos / 8)));
            byte[] tempBuffer = new byte[20];////
            Array.Copy(src, srcIndex + bitSourcePos / 8, tempBuffer, 0, tempBufferLen);
            uint SourceBufferBitLen = (bitLen + bitSourcePos) & 0x7;
            if (SourceBufferBitLen != 0) tempBuffer[tempBufferLen - 1] &= (byte)(0xFF << (8 - (int)SourceBufferBitLen));
            bitSourcePos &= 0x7;
            ShiftRight(tempBuffer, 0, tempBufferLen, bitSourcePos);
            ShiftLeft(tempBuffer, 0, tempBufferLen + 1, destBitPos & 0x7);
            if ((destBitPos & 0x7) > bitSourcePos)
                ++tempBufferLen;
            if (tempBufferLen > 0)
                for (int i = 0; i < tempBufferLen; ++i)
                    dest[destIndex + i + (destBitPos / 8)] |= tempBuffer[i];
            return (int)(bitLen + destBitPos);
        }
        //#####################################################################################################################################################
        private static void EncryptBlock(byte[] dest, int destIndex, byte[] src, int srcIndex, uint size, uint[] keys)
        {
            byte[] encValue = new byte[2];
            encValue[0] = (byte)size;
            encValue[0] ^= 0x3D;
            encValue[1] = 0xF8;
            for (int k = 0; k < size; ++k)
                encValue[1] ^= src[srcIndex + k];
            encValue[0] ^= encValue[1];
            AddBits(dest, destIndex, 0x48, encValue, 0, 0x00, 0x10);
            uint[] encBuffer = new uint[4];
            ushort[] cryptbuf = new ushort[4];
            for (int i = 0; i < size; i += 2)
            {
                cryptbuf[i / 2] = (ushort)(src[srcIndex + i]);
                if (i + 1 < size)
                    cryptbuf[i / 2] += (ushort)(src[srcIndex + i + 1] * 0x100);
            }

            encBuffer[0] = ((keys[8] ^ (cryptbuf[0])) * keys[4]) % keys[0];
            encBuffer[1] = ((keys[9] ^ (cryptbuf[1] ^ (encBuffer[0] & 0xFFFF))) * keys[5]) % keys[1];
            encBuffer[2] = ((keys[10] ^ (cryptbuf[2] ^ (encBuffer[1] & 0xFFFF))) * keys[6]) % keys[2];
            encBuffer[3] = ((keys[11] ^ (cryptbuf[3] ^ (encBuffer[2] & 0xFFFF))) * keys[7]) % keys[3];
            uint[] ring_backup = encBuffer.ToArray();
            //for (int i = 2; i >= 0; i--)
            //{
            //    EncBuffer[i] = EncBuffer[i] ^ Keys[i + 8] ^ (EncBuffer[i + 1] & 0xFFFF);
            //}
            encBuffer[2] = encBuffer[2] ^ keys[10] ^ (ring_backup[3] & 0xFFFF);
            encBuffer[1] = encBuffer[1] ^ keys[9] ^ (ring_backup[2] & 0xFFFF);
            encBuffer[0] = encBuffer[0] ^ keys[8] ^ (ring_backup[1] & 0xFFFF);
            byte[] subring = new byte[16];
            for (int i = 0; i < 4; i++)
            {
                subring[i * 4] = (byte)(encBuffer[i] % 0x100);
                subring[i * 4 + 1] = (byte)(encBuffer[i] / 0x100);
                subring[i * 4 + 2] = (byte)(encBuffer[i] / 0x10000);
                subring[i * 4 + 3] = (byte)(encBuffer[i] / 0x1000000);
            }
            AddBits(dest, destIndex, 0x00, subring, 0, 0x00, 0x10);
            AddBits(dest, destIndex, 0x10, subring, 0, 0x16, 0x02);
            AddBits(dest, destIndex, 0x12, subring, 4, 0x00, 0x10);
            AddBits(dest, destIndex, 0x22, subring, 4, 0x16, 0x02);
            AddBits(dest, destIndex, 0x24, subring, 8, 0x00, 0x10);
            AddBits(dest, destIndex, 0x34, subring, 8, 0x16, 0x02);
            AddBits(dest, destIndex, 0x36, subring, 12, 0x00, 0x10);
            AddBits(dest, destIndex, 0x46, subring, 12, 0x16, 0x02);
        }
        //#####################################################################################################################################################
        private static int DecryptBlock(byte[] dest, int destIndex, byte[] src, int srcIndex, uint[] keys)
        {
            uint[] temp = new uint[] { 0x00000000, 0x00000000, 0x00000000, 0x00000000 };
            byte[] decBuffer = new byte[16];
            AddBits(decBuffer, 0, 0x00, src, srcIndex, 0x00, 0x10);
            AddBits(decBuffer, 0, 0x16, src, srcIndex, 0x10, 0x02);
            AddBits(decBuffer, 4, 0x00, src, srcIndex, 0x12, 0x10);
            AddBits(decBuffer, 4, 0x16, src, srcIndex, 0x22, 0x02);
            AddBits(decBuffer, 8, 0x00, src, srcIndex, 0x24, 0x10);
            AddBits(decBuffer, 8, 0x16, src, srcIndex, 0x34, 0x02);
            AddBits(decBuffer, 12, 0x00, src, srcIndex, 0x36, 0x10);
            AddBits(decBuffer, 12, 0x16, src, srcIndex, 0x46, 0x02);

            for (int i = 0; i < 4; i++)
                temp[i] = (uint)(decBuffer[i * 4] + decBuffer[i * 4 + 1] * 0x100 + decBuffer[i * 4 + 2] * 0x10000 + decBuffer[i * 4 + 3] * 0x1000000);
            temp[2] = temp[2] ^ keys[10] ^ (temp[3] & 0xFFFF);
            temp[1] = temp[1] ^ keys[9] ^ (temp[2] & 0xFFFF);
            temp[0] = temp[0] ^ keys[8] ^ (temp[1] & 0xFFFF);

            ushort[] temp1 = new ushort[4];
            temp1[0] = (ushort)(keys[8] ^ ((temp[0] * keys[4]) % keys[0]));
            temp1[1] = (ushort)(keys[9] ^ ((temp[1] * keys[5]) % keys[1]) ^ (temp[0] & 0xFFFF));
            temp1[2] = (ushort)(keys[10] ^ ((temp[2] * keys[6]) % keys[2]) ^ (temp[1] & 0xFFFF));
            temp1[3] = (ushort)(keys[11] ^ ((temp[3] * keys[7]) % keys[3]) ^ (temp[2] & 0xFFFF));

            dest[destIndex] = (byte)(temp1[0] % 0x100);
            dest[destIndex + 1] = (byte)(temp1[0] / 0x100);
            dest[destIndex + 2] = (byte)(temp1[1] % 0x100);
            dest[destIndex + 3] = (byte)(temp1[1] / 0x100);
            dest[destIndex + 4] = (byte)(temp1[2] % 0x100);
            dest[destIndex + 5] = (byte)(temp1[2] / 0x100);
            dest[destIndex + 6] = (byte)(temp1[3] % 0x100);
            dest[destIndex + 7] = (byte)(temp1[3] / 0x100);

            byte[] finale = new byte[] { 0x00, 0x00 };
            AddBits(finale, 0, 0, src, srcIndex, 0x48, 0x10);
            finale[0] ^= finale[1];
            finale[0] ^= 0x3D;
            byte checkSum = 0xF8;
            for (int k = 0; k < 8; ++k)
                checkSum ^= (byte)(dest[destIndex + k]);
            if (checkSum == finale[1])
                return finale[0];
            return -1;
        }
        //#####################################################################################################################################################






        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        public enum ReadEncfileResult { InvalidPath, FileCorrupted, Success }
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        static readonly uint[] xorError = new uint[] { 0x9F81BD7C, 0x56E2933D, 0x3ED2732A, 0xBF9583F2 };
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        static readonly uint[] saveLoadXor = new uint[] { 0x3F08A79B, 0xE25CC287, 0x93D27AB9, 0x20DEA7BF };
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        static ReadEncfileResult ReadEncfile(string filePath, uint[] saveTo)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            if (fileStream == null) return ReadEncfileResult.InvalidPath;
            long size = fileStream.Seek(0, SeekOrigin.End);
            if (size != 54) return ReadEncfileResult.FileCorrupted;

            fileStream.Seek(6, SeekOrigin.Begin);
            uint[] buf = new uint[4];
            BinaryReader binaryReader = new BinaryReader(fileStream);

            for (int i = 0; i < 4; i++) buf[i] = binaryReader.ReadUInt32();
            saveTo[0] = buf[0] ^ saveLoadXor[0];
            saveTo[1] = buf[1] ^ saveLoadXor[1];
            saveTo[2] = buf[2] ^ saveLoadXor[2];
            saveTo[3] = buf[3] ^ saveLoadXor[3];
            for (int i = 0; i < 4; i++) buf[i] = binaryReader.ReadUInt32();
            saveTo[4] = buf[0] ^ saveLoadXor[0];
            saveTo[5] = buf[1] ^ saveLoadXor[1];
            saveTo[6] = buf[2] ^ saveLoadXor[2];
            saveTo[7] = buf[3] ^ saveLoadXor[3];
            for (int i = 0; i < 4; i++) buf[i] = binaryReader.ReadUInt32();
            saveTo[8] = buf[0] ^ saveLoadXor[0];
            saveTo[9] = buf[1] ^ saveLoadXor[1];
            saveTo[10] = buf[2] ^ saveLoadXor[2];
            saveTo[11] = buf[3] ^ saveLoadXor[3];
            fileStream.Close();
            binaryReader.Close();
            return ReadEncfileResult.Success;
        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        public static void LoadKeys()
        {
            ReadEncfileResult result;
            result = ReadEncfile("Enc1.dat", clientDecryptKeys);
            if (result != ReadEncfileResult.Success) throw new Exception(result.ToString());
            result = ReadEncfile("Enc2.dat", clientEncryptKeys);
            if (result != ReadEncfileResult.Success) throw new Exception(result.ToString());
            result = ReadEncfile("Dec1.dat", serverDecryptKeys);
            if (result != ReadEncfileResult.Success) throw new Exception(result.ToString());
            result = ReadEncfile("Dec2.dat", serverEncryptKeys);
            if (result != ReadEncfileResult.Success) throw new Exception(result.ToString());
        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Crypt
{
    public static class CryptProcess
    {
        //###########################################################################################################################################################
        public static bool DecodeC3C4(byte[] Src, out byte[] Dest, out int Counter)
        {
            if (Src[0].Equals(0xC3) || Src[0].Equals(0xC4))
            {

                if (Src[0].Equals(0xC3))
                {
                    int Size = Src[1];
                    byte[] TempDest = new byte[(((Size - 2 / 11) * 8) + 2 - 1)];
                    int Result = SimpleModulus.Decrypt(TempDest, 1, Src, 2, Src.Length - 2);
                    byte[] ReturnDest = new byte[Result + 1];
                    Array.Copy(TempDest, ReturnDest, ReturnDest.Length);
                    Counter = TempDest[1];
                    ReturnDest[0] = 0xC3;
                    ReturnDest[1] = (byte)(Result + 1);
                    Dest = ReturnDest;
                    return true;
                }
                else
                {
                    int Size = (Src[1] * 256) + Src[2];
                    byte[] TempDest = new byte[(((Size - 3 / 11) * 8) + 3 - 1)];
                    int Result = SimpleModulus.Decrypt(TempDest, 2, Src, 3, Src.Length - 3);
                    byte[] ReturnDest = new byte[Result + 2];
                    Array.Copy(TempDest, ReturnDest, ReturnDest.Length);
                    Counter = TempDest[1];
                    ReturnDest[0] = 0xC4;
                    ReturnDest[1] = (byte)((Result + 2 & ~0x00FF) >> 8);
                    ReturnDest[2] = (byte)(Result + 2 & ~0xFF00);
                    // ReturnDest[1] = (byte)(Result + 2);
                    Dest = ReturnDest;
                    return true;
                }
            }
            else
            {
                Counter = -1;
                Dest = null;
                return false;
            }
        }
        //###########################################################################################################################################################
        public static bool EncodeC3C4(byte[] Src, out byte[] Dest, int Counter)
        {
            if (Src[0].Equals(0xC3) || Src[0].Equals(0xC4))
            {
                {
                    if (Src[0].Equals(0xC3))
                    {
                        int Size = Src.Length;
                        byte[] TempDest = new byte[(((Size - 2 / 11) * 8) + 2 - 1)];
                        Src[1] = (byte)Counter;
                        int Result = SimpleModulus.Encrypt(TempDest, 2, Src, 1, Src.Length - 1);
                        byte[] ReturnDest = new byte[Result + 2];
                        Array.Copy(TempDest, ReturnDest, ReturnDest.Length);
                        ReturnDest[1] = (byte)(Result + 2);
                        ReturnDest[0] = 0xC3;

                        Dest = ReturnDest;
                        return true;
                    }
                    else
                    {
                        int Size = (Src[1] * 256) + Src[2];
                        byte[] TempDest = new byte[(((Size - 3 / 11) * 8) + 3 - 1)];

                        Src[2] = (byte)Counter;
                        int Result = SimpleModulus.Encrypt(TempDest, 3, Src, 2, Src.Length - 2);
                        byte[] ReturnDest = new byte[Result + 3];
                        Array.Copy(TempDest, ReturnDest, ReturnDest.Length);

                        ReturnDest[0] = 0xC4;
                        ReturnDest[1] = (byte)((Result + 2 & ~0x00FF) >> 8);
                        ReturnDest[2] = (byte)(Result + 2 & ~0xFF00);

                        Dest = ReturnDest;
                        return true;
                    }
                }
            }
            else
            {
                Counter = -1;
                Dest = null;
                return false;
            }
        }
        //###########################################################################################################################################################
        public static bool DecodeC1C2(byte[] Src, out byte[] Dest)
        {
            if (Src[0].Equals(0xC1) || Src[0].Equals(0xC3))
            {
                byte[] TempBuffer = Src;
                Xor32Modulus.DecXor32(TempBuffer, 2, TempBuffer.Length - 2, 2);
                Dest = TempBuffer;
                return true;
            }
            else if (Src[0].Equals(0xC2) || Src[0].Equals(0xC4))
            {
                byte[] TempBuffer = Src;
                Xor32Modulus.DecXor32(TempBuffer, 3, TempBuffer.Length - 3, 3);
                Dest = TempBuffer;
                return true;
            }
            else
            {
                Dest = null;
                return false;
            }
        }
        //###########################################################################################################################################################
        public static bool EncodeC1C2(byte[] Src, out byte[] Dest)
        {
            if (Src[0].Equals(0xC1) || Src[0].Equals(0xC3))
            {
                byte[] TempBuffer = Src;
                Xor32Modulus.EncXor32(TempBuffer, 2, TempBuffer.Length - 2, 2);
                Dest = TempBuffer;
                return true;
            }
            else if (Src[0].Equals(0xC2) || Src[0].Equals(0xC4))
            {
                byte[] TempBuffer = Src;
                Xor32Modulus.EncXor32(TempBuffer, 3, TempBuffer.Length - 3, 3);
                Dest = TempBuffer;
                return true;
            }
            else
            {
                Dest = null;
                return false;
            }
        }
        //###########################################################################################################################################################
        public static bool DecryptAsServer(byte[] Src, out byte[] Dest, out int Counter)
        {
            if (Src[0].Equals(0xC3) || Src[0].Equals(0xC4))
            {
                byte[] TempDest;
                SimpleModulus.InitCryptSite(true);
                if (DecodeC3C4(Src, out TempDest, out Counter))
                {
                    
                    byte[] TempDest2;
                    if (DecodeC1C2(TempDest, out TempDest2))
                    {
                       
                        Dest = TempDest2;
                        return true;
                    }
                }
                Dest = null;
                return false;
            }
            else if (Src[0].Equals(0xC1) || Src[0].Equals(0xC2))
            {
                byte[] TempDest2;
                if (DecodeC1C2(Src, out TempDest2))
                {
                    Counter = -1;
                    Dest = TempDest2;
                    return true;
                }
                Counter = -1;
                Dest = null;
                return false;
            }
            else
            {
                Counter = -1;
                Dest = null;
                return false;
            }
        }
        public static bool EncryptAsServer(byte[] Src, out byte[] Dest, int Counter)
        {
            if (Src[0].Equals(0xC3) || Src[0].Equals(0xC4))
            {
                byte[] TempDest;
                SimpleModulus.InitCryptSite(true);
                if (EncodeC3C4(Src, out TempDest, Counter))
                {

                    Dest = TempDest;
                    return true;

                }
                Dest = null;
                return false;
            }
            else if (Src[0].Equals(0xC1) || Src[0].Equals(0xC2))
            {

                Counter = -1;
                Dest = Src;
                return true;
            }
            else
            {
                Counter = -1;
                Dest = null;
                return false;
            }
        }
        public static bool DecryptAsClient(byte[] Src, out byte[] Dest, out int Counter)
        {
            if (Src[0].Equals(0xC3) || Src[0].Equals(0xC4))
            {
                byte[] TempDest;
                SimpleModulus.InitCryptSite(false);
                if (DecodeC3C4(Src, out TempDest, out Counter))
                {

                    Dest = TempDest;
                    return true;

                }
                Dest = null;
                return false;
            }
            else if (Src[0].Equals(0xC1) || Src[0].Equals(0xC2))
            {
                Counter = -1;
                Dest = Src;
                return true;
            }
            else
            {
                Counter = -1;
                Dest = null;
                return false;
            }
        }
        public static bool EncryptAsClient(byte[] Src, out byte[] Dest, int Counter)
        {
            if (Src[0].Equals(0xC3) || Src[0].Equals(0xC4))
            {
                byte[] TempDest;

                if (EncodeC1C2(Src, out TempDest))
                {
                    byte[] TempDest2;
                    SimpleModulus.InitCryptSite(false);
                    if (EncodeC3C4(TempDest, out TempDest2, Counter))
                    {

                        Dest = TempDest2;
                        return true;
                    }
                }
                Dest = null;
                return false;
            }
            else if (Src[0].Equals(0xC1) || Src[0].Equals(0xC2))
            {
                byte[] TempDest2;
                if (EncodeC1C2(Src, out TempDest2))
                {
                    Counter = -1;
                    Dest = TempDest2;
                    return true;
                }
                Counter = -1;
                Dest = null;
                return false;
            }
            else
            {
                Counter = -1;
                Dest = null;
                return false;
            }
        }
    }
    //###########################################################################################################################################################
}



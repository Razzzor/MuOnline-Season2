using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Common.Model;

using Common.Utility;

namespace Common.Packet
{
   public abstract class PacketReader
    {
        
        private BinaryReader binaryReader;
        private MemoryStream memoryStream;

       
        public void Process(byte[] packetData, User user)
        {
            
            memoryStream = new MemoryStream(packetData);
            binaryReader = new BinaryReader(memoryStream);
            try
            {
                Execute(user);
            }
            catch (Exception exception)
            {
               throw  exception;
            }
        }
        public abstract void Execute(User user);
        public long Lenght
        {
            get
            {
              return  memoryStream.Length;
            }
            
            
        }
        public byte[] Content
        {
            get
            {
                return memoryStream.ToArray();
            }


        }
        public long Position
        {
            get
            {
                return memoryStream.Position;
            }
            set
            {
                memoryStream.Position = (long)value;
            }
        }

        public void ShiftPosition(int value)
        {
            try
            {
                memoryStream.Position += (long)value;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int ReadInt32()
        {
            try
            {
                return binaryReader.ReadInt32();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        
        public byte ReadByte()
        {
            try
            {
                return binaryReader.ReadByte();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public int ReadInt16()
        {
            try
            {
                return binaryReader.ReadInt16() & 0xFFFF;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public uint ReadUInt32()
        {
            try
            {
                return binaryReader.ReadUInt32();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public double ReadDouble()
        {
            try
            {
                return binaryReader.ReadDouble();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public float ReadFloat()
        {
            try
            {
                return binaryReader.ReadSingle();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public long ReadInt64()
        {
            try
            {
                return binaryReader.ReadInt64();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
       
       
        
        public byte[] ReadBytes(int length)
        {
            byte[] result = new byte[length];
            try
            {
               return binaryReader.ReadBytes(length);
               
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public byte[] ReadBytes(int readPosition,int length)
        {
            byte[] result = new byte[length];
            try
            {
                Position = readPosition;
                return binaryReader.ReadBytes(length);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        
       public string ReadString(int lenght)
        {
            try
            {

                byte[] bytes = ReadBytes((int)Position, lenght);


                string result = System.Text.Encoding.ASCII.GetString(bytes).TrimEnd('\0');

                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

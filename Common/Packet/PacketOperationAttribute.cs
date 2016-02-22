using System;
using System.Collections.Generic;
using System.Reflection;

namespace Common.Packet
{
    [AttributeUsage(AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class PacketOperationAttribute : Attribute
    {
        public byte HeadCode { get; private set; }
        public byte SubCode { get; private set; }
        public int Lenght { get; private set; }

        public PacketOperationAttribute(byte headCode, byte subCode, int lenght)
        {
            this.HeadCode = headCode;
            this.SubCode = subCode;
            this.Lenght = lenght;
        }
        public PacketOperationAttribute(byte headCode, int lenght)
        {
            this.HeadCode = headCode;
            this.Lenght = lenght;
        }
        public PacketOperationAttribute(byte headCode, byte subCode)
        {
            this.HeadCode = headCode;
            this.SubCode = subCode;
            
        }
        public PacketOperationAttribute(byte headCode)
        {
            this.HeadCode = headCode;
            

        }
    }
   
}

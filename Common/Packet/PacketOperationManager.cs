using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;



namespace Common.Packet
{
    public static class PacketOperationManager
    {
        public static Dictionary<Type, PacketOperationAttribute> providedPacketsOperations = new Dictionary<Type, PacketOperationAttribute>();
       

        static PacketOperationManager()
        {
            foreach (Type PacketType in Assembly.GetEntryAssembly().GetTypes())
            {
                if (PacketType.GetCustomAttributes(typeof(PacketOperationAttribute), true).Length.Equals(3))
                    continue;
                ReadPacketAttribute(PacketType);
            }
        }

        public static Type GetPacketOperationTypeByHeadCodeLenght(byte headCode, int lenght)
        {
            return (from pair in providedPacketsOperations let PacketOperationAttribute = pair.Value where PacketOperationAttribute.HeadCode == headCode select pair.Key).FirstOrDefault();
        }
        public static Type GetPacketOperationTypeByHeadCode(byte headCode)
        {
            return (from pair in providedPacketsOperations let PacketAttribute = pair.Value where PacketAttribute.HeadCode == headCode select pair.Key).FirstOrDefault();
        }

        public static Type GetPacketOperationTypeByHeadSubCode(byte headCode,byte subCode)
        {
            return (from pair in providedPacketsOperations let PacketOperationAttribute = pair.Value where PacketOperationAttribute.HeadCode == headCode && PacketOperationAttribute.SubCode == subCode select pair.Key).FirstOrDefault();
        }

        public static Type GetPacketOperationTypeByHeadSubCodeLenght(byte headCode, byte subCode,int lenght)
        {
            return (from pair in providedPacketsOperations let PacketOperationAttribute = pair.Value where PacketOperationAttribute.HeadCode == headCode && PacketOperationAttribute.SubCode == subCode && PacketOperationAttribute.Lenght == lenght select pair.Key).FirstOrDefault();
        }
        private static void ReadPacketAttribute(Type PacketType)
        {
            object[] attributes = PacketType.GetCustomAttributes(typeof(PacketOperationAttribute), true); 
            if (attributes.Length == 0) return;

            providedPacketsOperations.Add(PacketType, (PacketOperationAttribute)attributes[0]);

           
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Common.Network;
using Common.Crypt;
using Common.Database;

namespace Common.Model
{
    
    public class Account
    {
        [DataMember(Name = "AccountIndex")]
        public int index;
        [DataMember(Name = "Login")]
        public string login;
        [DataMember(Name = "Password")]
        public string password;
        [DataMember(Name = "SecurityNumber")]
        public string securityNumber;
        [DataMember(Name = "Online")]
        public bool online;
        [DataMember(Name = "Banned")]
        public bool banned;
        [DataMember(Name = "LastIpAddress")]
        public int lastIpAddress;

        public Storage AccountWarehouse;
       
        public SocketClient networkClient;
        

        
        
        
        public void Send(byte[] data)
        {
            byte[] encryptData;
            CryptProcess.EncryptAsServer(data, out encryptData, 0);
            networkClient.Send(encryptData);
        }
    }
}

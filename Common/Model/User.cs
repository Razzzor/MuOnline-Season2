using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Crypt;

using Common.Network;

namespace Common.Model
{
    public class User
    {
       
        public SocketClient networkClient;
        public Account account;
        public Player player;
        public User(SocketClient networkClient)
        {
            this.networkClient = networkClient;
            this.account = null;
            this.player = null;
        }
        public void Send(byte[] data)
        {
            byte[] encryptData;
            CryptProcess.EncryptAsServer(data, out encryptData, 0);
            networkClient.Send(encryptData);
        }
    }
}

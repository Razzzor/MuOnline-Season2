using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Database;
using Common.Network;
using Common.Utility;
using Common.Model;

using Game.Packet.Server;

namespace Game.Network
{
    public class UserManager : Singleton<UserManager>
    {
        
        public int UserCount
        {
            get
            {
                return userList.Count;
            }
        }
        private SocketServer socketServer = SocketServer.Instance;
        
        private List<User> userList;
        protected object connectionLock = new object();
        public UserManager()
        {
           userList = new List<User>();
          
           socketServer.ClientConnected += (sender, e) => CreateNewUser( e.networkClient);
           socketServer.ClientDisconnected += (sender, e) => RemoveUser(e.networkClient);
     
        }
        private void CreateNewUser(SocketClient socketClient)
        {
            lock (connectionLock)
            {
                User user = new User(socketClient);
                user.networkClient.Send(new SpSendClientVersion().Execute(user));
                userList.Add(user);
            }
           
        }
        public User GetUserByNetworkClient(SocketClient socketClient)
        {
            lock (connectionLock)
            {
                foreach (User user in userList)
                {
                    if (user.networkClient.Equals(socketClient))
                    {
                        return user;
                    }
                }
            }
            throw new Exception(string.Format("Not Initialized User: {0}",socketClient.ToString()));
        }
        private void RemoveUser(SocketClient socketClient)
        {
            lock (connectionLock)
            {
                for (int i = 0; i < userList.Count; i++ )
                {
                    if (userList[i].networkClient.Equals(socketClient))
                    {
                        if(userList[i].player != null)
                        {
                            DatabaseOperations.SaveObject(userList[i].player);
                            Logger.Info("[UserManager] Player Saved:{0}", userList[i].player.name);
                            userList[i].player = null;

                        }
                        if(userList[i].account != null)
                        {
                            DatabaseOperations.SaveObject(userList[i].account);
                            Logger.Info("[UserManager] Account Saved:{0}", userList[i].account.login);
                            DatabaseOperations.SetAccountIsOffline(userList[i].account);
                            userList[i].player = null;
                        }
                        userList.Remove(userList[i]);
                    }
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

using Common.Utility;

namespace Common.Network
{
    public class SocketServer : Singleton<SocketServer>
    {

        public bool IsListening
        {
            get
            {
                return isListening;
            }
        }
        public int Port
        {
            get
            {
                return port;
            }

        }
        private int port;
        private IPAddress ipAddress;
        
        private bool isInitialized = false;
        private bool isListening = false;
        public void Initialize(int port, IPAddress ipAddress)
        {
           
            this.port = port;
            this.ipAddress = ipAddress;
            
            isInitialized = true;
            Logger.Info("[SocketServer]Initialize To Port:{0} IpAddress:{1} ",port.ToString(),ipAddress.ToString());
        }
        protected Socket serverSocket;
        protected Dictionary<Socket, SocketClient> connections = new Dictionary<Socket, SocketClient>();
        protected object connectionLock = new object();

        public delegate void ClientEventHandler(object sender, SocketClientEventArgs e);
        public delegate void ClientDataEventHandler(object sender, SocketClientDataEventArgs e);

        public event ClientEventHandler ClientConnected;
        public event ClientEventHandler ClientDisconnected;
        public event ClientDataEventHandler DataReceived;
        public event ClientDataEventHandler DataSent;

        public virtual void Listen()
        {
            if (!isInitialized)
            {
                throw new ObjectDisposedException(this.GetType().Name, "Not Initialised Param");
            }


            if (IsListening)
            {
                Logger.Warn("[SocketServer] Server Allready Listening. Action Terminated");
                return;
            }


            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, true);
            }
            catch (SocketException e)
            {
                Logger.Error(e, "Listen");
            }
            serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);


            serverSocket.Bind(new IPEndPoint(ipAddress, port));



            serverSocket.Listen(10);
            isListening = true;


            serverSocket.BeginAccept(AcceptCallback, null);
            Logger.Info("[SocketServer]Started Listen ");
        }

        private void AcceptCallback(IAsyncResult iAsyncResult)
        {
            try
            {
                var socket = serverSocket.EndAccept(iAsyncResult);
                var socketClient = new SocketClient(this, socket);

                lock (connectionLock) connections[socket] = socketClient;

                OnClientConnection(new SocketClientEventArgs(socketClient));
                Logger.Info("[SocketServer] New Cliet Connected: {0}", socketClient.ToString());
                socketClient.BeginReceive(ReceiveCallback, socketClient);
                serverSocket.BeginAccept(AcceptCallback, null);
            }
            catch (Exception e)
            {
                Logger.Error(e, "AcceptCallback");
            }
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            var client = result.AsyncState as SocketClient;
            if (client == null) return;

            try
            {
                var bytesRecv = client.EndReceive(result);

                if (bytesRecv > 0)
                {
                    OnDataReceived(new SocketClientDataEventArgs(client, client.RecvBuffer));
                    

                    if (client.IsConnected) client.BeginReceive(ReceiveCallback, client);
                    else RemoveConnection(client, true);
                }
                else RemoveConnection(client, true);
            }
            catch (SocketException)
            {
                RemoveConnection(client, true);
            }
            catch (Exception e)
            {
                RemoveConnection(client, true);
            }
        }

        public virtual int Send(SocketClient networkClient, byte[] data, SocketFlags flags)
        {
            if (networkClient == null)
            {
                throw new ArgumentNullException("Connection Null");
            }
            if (data == null)
            {
                throw new ArgumentNullException("Data Null");
            }

            var buffer = data.ToArray();

            return Send(networkClient, buffer, 0, buffer.Length, SocketFlags.None);
        }

        public virtual int Send(SocketClient socketClient, byte[] data, int start, int count, SocketFlags flags)
        {
            if (socketClient == null)
            {
                throw new ArgumentNullException("Connection Null");
            }
            if (data == null)
            {
                throw new ArgumentNullException("Data Null");
            }

            var totalBytesSent = 0;
            var bytesRemaining = data.Length;

            try
            {
                while (bytesRemaining > 0)
                {
                    var bytesSent = socketClient.Socket.Send(data, totalBytesSent, bytesRemaining, flags);
                    if (bytesSent > 0)
                        OnDataSent(new SocketClientDataEventArgs(socketClient, data));


                    bytesRemaining -= bytesSent;
                    totalBytesSent += bytesSent;
                }
            }
            catch (SocketException)
            {
                RemoveConnection(socketClient, true);
            }
            catch (Exception e)
            {
                Logger.Error(e, "Send");
            }

            return totalBytesSent;
        }



        public IEnumerable<SocketClient> GetClients()
        {
            lock (connectionLock)
                foreach (SocketClient networkClient in connections.Values)
                    yield return networkClient;
        }



        protected virtual void OnClientConnection(SocketClientEventArgs e)
        {
            var handler = ClientConnected;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnClientDisconnect(SocketClientEventArgs e)
        {
            var handler = ClientDisconnected;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnDataReceived(SocketClientDataEventArgs e)
        {
            var handler = DataReceived;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnDataSent(SocketClientDataEventArgs e)
        {
            var handler = DataSent;
            if (handler != null) handler(this, e);
        }



        public virtual void DisconnectAll()
        {
            lock (connectionLock)
            {
                foreach (var connection in connections.Values.Cast<SocketClient>().Where(client => client.IsConnected))
                {

                    connection.Socket.Disconnect(false);
                    OnClientDisconnect(new SocketClientEventArgs(connection));
                }

                connections.Clear();
            }
        }

        public virtual void Disconnect(SocketClient connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("Connection");
            }
            if (!connection.IsConnected)
            {
                return;
            }

            connection.Socket.Disconnect(false);
            RemoveConnection(connection, true);
        }

        private void RemoveConnection(SocketClient socketClient, bool raiseEvent)
        {

            lock (connectionLock)
            { 
               
                if (connections.Remove(socketClient.Socket) && raiseEvent)
                { 
                    OnClientDisconnect(new SocketClientEventArgs(socketClient));
                }
                Logger.Info("[SocketServer]  Cliet Disconnected: {0}", socketClient.ToString());
            }
        }

        public virtual void Shutdown()
        {



            if (!IsListening)
            {
                return;
            }


            if (serverSocket != null)
            {
                serverSocket.Close();
            }

            serverSocket = null;
            isListening = false;
        }

    }
}


using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

using Common.Packet;


namespace Common.Network
{
    public sealed class SocketClient 
    {
        



        private readonly SocketServer networkServer;
        private readonly Socket socket;
        private readonly byte[] recvBuffer = new byte[bufferSize];
        public static readonly int bufferSize = 2*1024; 

        public Dictionary<uint, uint> Services { get; private set; }

        public bool IsConnected
        {
            get { return socket.Connected; }
        }

        public IPEndPoint RemoteEndPoint
        {
            get { return socket.RemoteEndPoint as IPEndPoint; }
        }

        public IPEndPoint LocalEndPoint
        {
            get { return socket.LocalEndPoint as IPEndPoint; }
        }

        public byte[] RecvBuffer
        {
            get { return recvBuffer; }
        }

        public Socket Socket
        {
            get { return socket; }
        }

        public SocketClient(SocketServer server, Socket socket)
        {
            if (server == null) 
            { 
                throw new ArgumentNullException("server");
            }
            if (socket == null) 
            {
                throw new ArgumentNullException("socket");
            }

            this.networkServer = server;
            this.socket = socket;
            
        }
        
     

        public IAsyncResult BeginReceive(AsyncCallback callback, object state)
        {
            return socket.BeginReceive(recvBuffer, 0, bufferSize, SocketFlags.None, callback, state);
        }

        public int EndReceive(IAsyncResult result)
        {
            return socket.EndReceive(result);
        }

      

        public int Send(PacketWriter packetSend)
        {
            if (packetSend == null) throw new ArgumentNullException("packet");
            return Send(packetSend.Compile());
        }

        

       

        public int Send(byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            return Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        public int Send(byte[] buffer, SocketFlags flags)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            return Send(buffer, 0, buffer.Length, flags);
        }

        public int Send(byte[] buffer, int start, int count)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            return Send(buffer, start, count, SocketFlags.None);
        }

        public int Send(byte[] buffer, int start, int count, SocketFlags flags)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            return networkServer.Send(this, buffer, start, count, flags);
        }

        

        public void Disconnect()
        {
            if (this.IsConnected)
                networkServer.Disconnect(this);
        }

        public override string ToString()
        {
            if (socket.RemoteEndPoint != null)
                return socket.RemoteEndPoint.ToString();
            else
                return "Not Connected";
        }
    }
}

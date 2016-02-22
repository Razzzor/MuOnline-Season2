using System;

namespace Common.Network
{    
    public class SocketClientEventArgs : EventArgs
    {
        public SocketClient networkClient { get; private set; }

        public SocketClientEventArgs(SocketClient networkClient)
        {
            if (networkClient == null)
                throw new ArgumentNullException("Client");
            this.networkClient = networkClient;
        }

        public override string ToString()
        {
            return networkClient.RemoteEndPoint != null
                ? networkClient.RemoteEndPoint.ToString()
                : "Not Connected";
        }
    }
}


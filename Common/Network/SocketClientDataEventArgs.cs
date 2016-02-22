using System.Collections.Generic;
using System.Linq;

namespace Common.Network
{
    public sealed class SocketClientDataEventArgs : SocketClientEventArgs
    {
        public byte[] data { get; private set; }

        public SocketClientDataEventArgs(SocketClient networkClient, byte[] data)
            : base(networkClient)
        {
            this.data = data ?? new byte[0];
        }

        public override string ToString()
        {
            return networkClient.RemoteEndPoint != null
                ? string.Format("{0}: {1} Bytes", networkClient.RemoteEndPoint, data.Count())
                : string.Format("Not Connected: {0} Bytes", data.Count());
        }
    }
}


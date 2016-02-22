using System.Collections.Generic;
using System.Linq;

namespace Common.Network
{
    public sealed class PipeMessageEventArgs
    {
        public byte[] data { get; private set; }

        public string pipeName { get; private set; }

        
        public PipeMessageEventArgs(byte[] data, string pipeName)
        {
            this.data = data;
            this.pipeName = pipeName;

        }
        public override string ToString()
        {

            return string.Format("{0}: {1} Bytes", pipeName, data.Count());
                
        }
    }
}

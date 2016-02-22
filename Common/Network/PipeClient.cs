using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;


namespace Common.Network
{
  public  class PipeClient
    {
        public void Send(byte[] data, string pipeName, int TimeOut = 1000)
        {
            try
            {
                NamedPipeClientStream pipeStream = new NamedPipeClientStream
                   (".", pipeName, PipeDirection.Out, PipeOptions.Asynchronous);

              
                pipeStream.Connect(TimeOut);
               

                
                pipeStream.BeginWrite
                (data, 0, data.Length, new AsyncCallback(AsyncSend), pipeStream);
            }
            catch (TimeoutException timeoutException)
            {
              
            }
        }

        private void AsyncSend(IAsyncResult iAsyncResult)
        {
            try
            {

                NamedPipeClientStream pipeStream = (NamedPipeClientStream)iAsyncResult.AsyncState;


                pipeStream.EndWrite(iAsyncResult);
                pipeStream.Flush();
                pipeStream.Close();
                pipeStream.Dispose();
            }
            catch (Exception exception)
            {
            
            }
        }
    }
}

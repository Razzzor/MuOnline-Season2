using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO.Pipes;

namespace Common.Network
{

   public class PipeServer
    {
        

        public delegate void NetworkPipeMessageEventHandler(PipeMessageEventArgs e);


        public event NetworkPipeMessageEventHandler MessageRecived;
        protected virtual void OnMessageRecived(PipeMessageEventArgs e)
        {
            var handler = MessageRecived;
            if (handler != null) handler(e);
        }
        private string pipeName;

        public void Listen(string pipeName)
        {
            try
            {
                
                this.pipeName = pipeName;
                
                NamedPipeServerStream pipeServer = new NamedPipeServerStream(pipeName,
                   PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

               
                pipeServer.BeginWaitForConnection
                (new AsyncCallback(WaitForConnectionCallBack), pipeServer);
            }
            catch (Exception exeptionon)
            {
                throw exeptionon;
            }
        }

        private void WaitForConnectionCallBack(IAsyncResult iAsyncResult)
        {
            try
            {
               
                NamedPipeServerStream pipeServer = (NamedPipeServerStream)iAsyncResult.AsyncState;
               
                pipeServer.EndWaitForConnection(iAsyncResult);

                byte[] buffer = new byte[1024];

              
                pipeServer.Read(buffer, 0, 1024);

                
                OnMessageRecived(new PipeMessageEventArgs(buffer,pipeName));

              
                pipeServer.Close();
                pipeServer = null;
                pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.In,
                   1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

              
                pipeServer.BeginWaitForConnection(
                   new AsyncCallback(WaitForConnectionCallBack), pipeServer);
            }
            catch
            {
                return;
            }
        }
    }
}

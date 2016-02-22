using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Network;
using Common.Packet;
using System.Threading;

namespace Database.GameOperation
{
   public class GameConnection
    {
       readonly string serverPipeName = "DatabeseSend";
       readonly string clientPipeName = "DatabeseRecv";
       NetworkPipeServer networkPipeServer;
       NetworkPipeClient networkPipeClient;
       public GameConnection()
       {
           networkPipeServer = new NetworkPipeServer();
           networkPipeServer.MessageRecived += (e) => ExecuteRequest(e.data);
           networkPipeServer.Listen("DatabeseRecv");
           networkPipeClient = new NetworkPipeClient();
       }
       public void ExecuteRequest(byte[] data)
       {
           PacketReader packetReader = new PacketReader(data);
           int userIndex = packetReader.ReadInt32();
           int opCode = packetReader.ReadInt32();
           int lenght = packetReader.ReadInt32();
           if (!GameOperations.opCodes.ContainsKey(opCode))
           {
               throw new Exception("Missing GameOperation Code");
           }
           if(lenght > 16)
           { 
           byte[] contentData = packetReader.ReadBytes(lenght - 16);
           new Thread(new ThreadStart(delegate() { ((AbstractGameOperation)Activator.CreateInstance(GameOperations.opCodes[opCode])).Execute(contentData); })).Start();
           }
       }
       public void SendAnswer(int userIndex,byte[] data)
       {
           int fakeLenght = 1;
           PacketWriter packetWriter = new PacketWriter();
           packetWriter.WriteInt(userIndex);
           packetWriter.WriteInt(fakeLenght);
           packetWriter.WriteBytes(data);
           long lenght = packetWriter.Lenght;
           packetWriter.Position = 4;
           packetWriter.WriteInt((int)lenght);
           networkPipeClient.Send(packetWriter.Compile(), serverPipeName);
       }
    }
}

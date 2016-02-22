//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Common.Network;
//using System.Threading.Tasks;

//using Common.Utility;
//using Common.Packet;
//using System.Timers;

//namespace Game.Network
//{
//    public class DatabaseConnection : Singleton<DatabaseConnection>
//    {
//       readonly string serverPipeName = "DatabeseRecv";
//       readonly string clientPipeName = "DatabeseSend";
//       Dictionary<int, byte[]> requestList;
//       NetworkPipeServer networkPipeServer;
//       NetworkPipeClient networkPipeClient;
//       public DatabaseConnection()
//       {
//           requestList = new Dictionary<int,byte[]>();
//           networkPipeServer = new NetworkPipeServer();
//           networkPipeServer.MessageRecived += (e) => AddRequestToList(e.data);
//           networkPipeServer.Listen("DatabeseRecv");
//           networkPipeClient = new NetworkPipeClient();
//       }
//       public void SendRequest(int userIndex,int opCode, byte[] data)
//        {
//            int fakeLenght = 1;
//            PacketWriter packetWriter = new PacketWriter();
//            packetWriter.WriteInt(userIndex);
//            packetWriter.WriteInt(opCode);
//            packetWriter.WriteInt(fakeLenght);
//            packetWriter.WriteBytes(data);

//            long lenght = packetWriter.Lenght;
           
//            packetWriter.Position = 8;
//            packetWriter.WriteInt((int)lenght);
//            networkPipeClient.Send(packetWriter.Compile(), serverPipeName);
//        }
//       public void SendRequest(int userIndex, int opCode)
//       {
//           int fakeLenght = 1;
//           PacketWriter packetWriter = new PacketWriter();
//           packetWriter.WriteInt(userIndex);
//           packetWriter.WriteInt(opCode);
//           packetWriter.WriteInt(fakeLenght);
//           long lenght = packetWriter.Lenght ;
//           packetWriter.Position = 8;
//           packetWriter.WriteInt((int)lenght);
//           networkPipeClient.Send(packetWriter.Compile(), serverPipeName);
//       }
//       void AddRequestToList(byte[] data)
//       {
//           PacketReader packetReader = new PacketReader(data);
//           int userIndex = packetReader.ReadInt32();
//           int lenght = packetReader.ReadInt32();
//           byte[] trueData = packetReader.ReadBytes(lenght - 8);
//           requestList.Add(userIndex, trueData);
           
//       }
//       public byte[] ReciveRequest(int userIndex)
//       {
//           Timer timer = new Timer(5000);
//           timer.Elapsed += delegate { requestList.ContainsKey(userIndex); };
//           timer.AutoReset = false;
//           timer.Start();         
//           byte[] result = requestList[userIndex];
//           requestList.Remove(userIndex);
//          return result;
//       }
//    }
//}

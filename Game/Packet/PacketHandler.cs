using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Common.Network;
using Common.Utility;
using Common.Crypt;

using Game.Packet;
using Game.Network;
using Common.Packet;
using Common.Model;
using System.IO;

namespace Game.Packet
{
    public class PacketHandler : Singleton<PacketHandler>
    {
        SocketServer networkSerer;
        Logger logger;
        UserManager clientMenager;
        public PacketHandler()
        {
            networkSerer = SocketServer.Instance;
           
            clientMenager = UserManager.Instance;
            networkSerer.DataReceived += (sender, e) => ParsePacket(e);
        }

        private void ParsePacket(SocketClientDataEventArgs e)
        {
            try
            {


                byte[] decryptedData = e.data;
                if (!PacketIdentyfy.IsStartWithHeader(decryptedData))
                {
                    return;
                }
                User user = clientMenager.GetUserByNetworkClient(e.networkClient);




                Queue<byte[]> packets = PacketSplit.SplitMessage(decryptedData);
                if (packets.Count > 1)
                {

                }
                foreach (byte[] packet in packets)
                {

                    PacketIdentyfy.IsValidPacket(packet);
                    byte[] encryptedData;
                    int counter;
                    CryptProcess.DecryptAsServer(packet, out encryptedData, out counter);
                    if (encryptedData == null || counter == null)
                    {
                        throw new Exception("ParsePacket: Null Crypt Data");
                    }

                    byte headCode = PacketIdentyfy.GetHeadCode(encryptedData);




                    if (headCode.Equals(0xF1))
                    {
                        byte subCode = PacketIdentyfy.GetSubCode(encryptedData);

                        if (OpCodes.RecvF1.ContainsKey(subCode))
                        {
                            Logger.Trace("[PacketHandler] Processed Paket HeadCode:{0} SubCode:{1} Operation:{2}", headCode.ToString("X2"), subCode.ToString("X2"), OpCodes.RecvF1[subCode].Name);
                            ((PacketReader)Activator.CreateInstance(OpCodes.RecvF1[subCode])).Process(encryptedData, user);
                        }
                        else
                        {
                            Logger.Trace("[PacketHandler] Unknown Packet HeadCode:{0} SubCode:{1}", headCode.ToString("X2"), subCode.ToString("X2"));
                            SaveFile.AppendText(TypeConverter.ByteArrayToHexString(encryptedData), string.Format(@"{0}\\UnkownPackets.txt", Directory.GetCurrentDirectory()));
                        }
                    }
                    else if (headCode.Equals(0xF3))
                    {
                        byte subCode = PacketIdentyfy.GetSubCode(encryptedData);

                        if (OpCodes.RecvF3.ContainsKey(subCode))
                        {

                            ((PacketReader)Activator.CreateInstance(OpCodes.RecvF3[subCode])).Process(encryptedData, user);
                            Logger.Trace("[PacketHandler] Processed Paket HeadCode:{0} SubCode:{1} Operation:{2}", headCode.ToString("X2"), subCode.ToString("X2"), OpCodes.RecvF3[subCode].Name);
                        }
                        else
                        {
                            Logger.Trace("[PacketHandler] Unknown Packet HeadCode:{0} SubCode:{1}", headCode.ToString(), subCode.ToString());
                            SaveFile.AppendText(TypeConverter.ByteArrayToHexString(encryptedData), string.Format(@"{0}\\UnkownPackets.txt", Directory.GetCurrentDirectory()));
                        }
                    }
                    else
                    {

                        if (OpCodes.Recv.ContainsKey(headCode))
                        {
                            ((PacketReader)Activator.CreateInstance(OpCodes.Recv[headCode])).Process(encryptedData, user);
                            Logger.Trace("[PacketHandler] Processed Paket HeadCode:{0} Operation:{1}", headCode.ToString("X2"), OpCodes.Recv[headCode].Name);
                        }
                        else
                        {
                            Logger.Error("[PacketHandler] Unknown Packet HeadCode:{0}", headCode.ToString("X2"));
                            SaveFile.AppendText(TypeConverter.ByteArrayToHexString(encryptedData), string.Format(@"{0}\\UnkownPackets.txt", Directory.GetCurrentDirectory()));
                            return;
                        }
                    }



                }
            }


            catch (Exception exeption)
            {
                Logger.Error("[PacketHandler] {0}", exeption.Message);
            }
        }
    }
}

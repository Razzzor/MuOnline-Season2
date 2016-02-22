

using System.Text;
using System.Threading.Tasks;
using Common.Packet;
using Common.Model;

using Game.Network;
using Game.Packet.Server;

namespace Game.Packet.Client
{


    public class RpChatWisper : PacketReader
    {
        public override void Execute(User user)
        {

            byte opCode = ReadByte();
            int sizeCode = ReadByte();
            byte headCode = ReadByte(); 
            
            string playerName = ReadString(10);
            int textSize = sizeCode - 14;
            string wisperText = ReadString(textSize);
            //user.account.RemovePlayer(playerName);
            //user.networkClient.Send(new CharacterDeleteAnswer().Execute(user));
            //return;
        }
    }
}
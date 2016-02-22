
 
  
using System.Text;
using System.Threading.Tasks;
using Common.Packet;
using Common.Model;

using Game.Network;
using Game.Packet.Server;

namespace Game.Packet.Client
{
   public enum LogoutType
   {
       CLOSE_GAME = 0,
       SELECT_CARACTER = 1,
       SERVER_LIST = 2
   };

   public class RpLogout : PacketReader
    {
           public override void Execute(User user)
           {

               byte opCode = ReadByte();
               byte sizeCode = ReadByte();
               byte headCode = ReadByte();
               byte subCode = ReadByte(); 

               int typeLogout = ReadByte(); 
               switch(typeLogout)
               {
                   case (int)LogoutType.CLOSE_GAME:
                      break;
                   case (int)LogoutType.SELECT_CARACTER:
                       break;
                   case (int)LogoutType.SERVER_LIST:
                       break;
               }
               //user.account.Send(new CharacterDeleteAnswer().Execute(user));
           }
    }

}

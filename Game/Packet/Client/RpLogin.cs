using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


using Common.Packet;
using Common.Model;
using Common.Utility;
using Common.Crypt;

using Game.Network;
using Game.Packet.Server;
using Common.Database;

namespace Game.Packet.Client
{
    public class RpLogin : PacketReader
    {
        
       
        public override void Execute(User user)
        {


            byte opCode = ReadByte();
            byte sizeCode = ReadByte();
            byte headCode = ReadByte(); ;
            byte subCode = ReadByte(); ;
            byte[] loginEncrypted = ReadBytes(10);
            byte[] passwordEncrypted = ReadBytes(10);
            Xor32Modulus.EncDecLogin(ref loginEncrypted, 0, loginEncrypted.Length);
            Xor32Modulus.EncDecLogin(ref passwordEncrypted, 0, passwordEncrypted.Length);
            string login = TypeConverter.ByteArrayToString(loginEncrypted);
            string password = TypeConverter.ByteArrayToString(passwordEncrypted); ;

            uint tickCount = ReadUInt32() ;
            string clientVersion = ReadString(5); 
            string clientSerial = ReadString(16);
            if(!clientVersion.Equals(Define.mainVersion.Replace(".","")))
            {
                user.networkClient.Send(new SpNewVersionRequired().Execute(user));
                return;
            }
            if (!clientSerial.Equals(Define.mainSerial))
            {
                user.networkClient.Send(new SpNewVersionRequired().Execute(user));
                return;
            }
            if(UserManager.Instance.UserCount > Define.clientsCount)
            {
                user.networkClient.Send(new SpServerOverloaded().Execute(user));
                return;
            }
            AccountStatus accountStatus = DatabaseOperations.VerifyAccount(login, password);
            if (accountStatus.Equals(AccountStatus.ACCOUNT_ALLREADY_CONNECTED))
            {
                user.networkClient.Send(new SpAccountAlreadyConnected().Execute(user));
                return;
            }
            else if (accountStatus.Equals(AccountStatus.AUTHENTICATION_ACCEPTED))
            {
                int accountIndex = DatabaseOperations.GetAccountIndexByLogin(login);
                user.account = DatabaseOperations.GetObject<Account>(accountIndex);
                DatabaseOperations.SetAccountIsOnline(user.account);
                user.networkClient.Send(new SpAuthenticationAccepted().Execute(user));
                return;
            }
            else if (accountStatus.Equals(AccountStatus.BLOKED_ACCOUNT))
            {
                user.networkClient.Send(new SpAccountBlocked().Execute(user));
                return;
            }
            else if (accountStatus.Equals(AccountStatus.INVALID_ACCOUNT))
            {
                user.networkClient.Send(new SpAccountInvalid().Execute(user));
                return;
            }
            else if (accountStatus.Equals(AccountStatus.INVALID_PASSWORD))
            {
                user.networkClient.Send(new SpInvalidPassword().Execute(user));
                return;
            }
            user.networkClient.Send(new SpOnlyPlayersAge15().Execute(user));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Packet.Client;

namespace Game.Packet
{
    public class OpCodes
    {
        public static Dictionary<byte, Type> Recv = new Dictionary<byte, Type>();
        public static Dictionary<byte, Type> RecvF1 = new Dictionary<byte, Type>();
        public static Dictionary<byte, Type> RecvF3 = new Dictionary<byte, Type>();
        public static void Init()
        {
           
            RecvF1.Add(0x01, typeof(RpLogin));
            RecvF1.Add(0x02, typeof(RpLogout));
            RecvF1.Add(0x03, typeof(RpHackCheck));

            RecvF3.Add(0x00, typeof(RpPlayersList));
            RecvF3.Add(0x01, typeof(RpPlayerCreate));
            RecvF3.Add(0x02, typeof(RpPlayerDelete));
            RecvF3.Add(0x03, typeof(RpPlayerEnterWorld));
            RecvF3.Add(0x06, typeof(RpLevelUpPointAdd));
            RecvF3.Add(0x12, typeof(RpMoveDataLoadingOK));
            RecvF3.Add(0x30, typeof(RpMoveDataLoadingOK));





            
            Recv.Add(0x00, typeof(RpChatNormal));
            Recv.Add(0x01, typeof(RpChatRecive));
            Recv.Add(0x02, typeof(RpChatWisper));
            Recv.Add(0x03, typeof(RpCheckMain));
            Recv.Add(0x0E, typeof(RpClientLive));
            Recv.Add(0xDF, typeof(RpMove));
            Recv.Add(0xD3, typeof(RpWalk));
            Recv.Add(0xDC, typeof(RpAttack));
            Recv.Add(0x18, typeof(RpAction));
            Recv.Add(0x19, typeof(RpMagicAttack));
            Recv.Add(0x1B, typeof(RpMagicAttackCancel));
            Recv.Add(0x1C, typeof(RpTeleport));
            Recv.Add(0xB0, typeof(RpTargetTeleport));
            Recv.Add(0xD7, typeof(RpBeattackRecive));
            Recv.Add(0x1E, typeof(RpDurationMagicRecive));
            Recv.Add(0x22, typeof(RpItemGet));
            Recv.Add(0x23, typeof(RpItemThrow));
            Recv.Add(0x24, typeof(RpItemMove));
            Recv.Add(0x26, typeof(RpItemUse));
            Recv.Add(0x30, typeof(RpTalk));
            Recv.Add(0x31, typeof(RpCloseWindow));
            Recv.Add(0x32, typeof(RpItemBuy));
            Recv.Add(0x33, typeof(RpItemSell));
            Recv.Add(0x34, typeof(RpDurationRepair));
            Recv.Add(0x36, typeof(RpTradeRequest));
            Recv.Add(0x37, typeof(RpTradeResponse));
            Recv.Add(0x3A, typeof(RpTradeMoney));
            Recv.Add(0x3C, typeof(RpTradeOkButton));
            Recv.Add(0x3D, typeof(RpTradeCancelButton));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;

using Common.Model;
using Common.Utility;
using Common.Packet;

using MySql.Data;
using MySql.Data.MySqlClient;

using Database.MySqlOperation;

namespace Database.GameOperation
{
    public class AccountVerify : AbstractGameOperation
    {
        public override void Execute(byte[] data)
        {
            PacketReader packetReader = new PacketReader(data);
            string login = TypeConverter.ByteArrayToString(packetReader.ReadBytes(10));
            string password = TypeConverter.ByteArrayToString(packetReader.ReadBytes(10));
            MySqlDataReader mySqlDataReader = MySqlDatabaseConnection.Instance.Query("SELECT Number FROM account WHERE Login=\"{0}\" AND Password = \"{1}\";", login, password);
            if (!mySqlDataReader.HasRows)
            {

            }


        }

    }
}


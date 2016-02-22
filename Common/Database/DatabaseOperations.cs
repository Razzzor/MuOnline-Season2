using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common.Utility;
using Common.Model;
using Common.Network;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Common.Database
{
    enum LOGINRESULT
    {
        LOGINRESULT_INVALIDPASSWORD,
        LOGINRESULT_GRANTED,
        LOGINRESULT_INVALIDACCOUNT,
        LOGINRESULT_ALREADYCONNECTED,
        LOGINRESULT_SERVERFULL,
        LOGINRESULT_ACCOUNTBLOCKED,
        LOGINRESULT_INVALIDVERSION,
        LOGINRESULT_ERROR,
        LOGINRESULT_TOOMUCHTRIES,
        LOGINRESULT_NOCHARGEINFO,
        LOGINRESULT_SUBSCRIPTIONOVER,
        LOGINRESULT_SUBSCRIPTIONOVER2,
        LOGINRESULT_IPSUBSCRIPTIONOVER,
        LOGINRESULT_IPSUBSCRIPTIONOVER2,
        LOGINRESULT_CONNECTIONERROR1,
        LOGINRESULT_CONNECTIONERROR2,
        LOGINRESULT_CONNECTIONERROR3,
        LOGINRESULT_TOOYOUNG,
    };
    public enum AccountStatus
    {
        INVALID_PASSWORD,
        AUTHENTICATION_ACCEPTED,
        INVALID_ACCOUNT,
        ACCOUNT_ALLREADY_CONNECTED,
        BLOKED_ACCOUNT,
    };
    public class DatabaseOperations
    {

     
       
        

        public static  AccountStatus VerifyAccount(string login,string password)
        {
            MySqlDataReader mySqlDataReader = MySqlDatabaseConnection.Query("SELECT Password,Banned,Online FROM Account WHERE Login=\"{0}\" ;", login);
            if (!mySqlDataReader.HasRows)
            {
                return AccountStatus.INVALID_ACCOUNT;
            }
            mySqlDataReader.Read();
            string queryPassword = mySqlDataReader.GetString("Password");
            if(!password.Equals(queryPassword))
            {
                return AccountStatus.INVALID_PASSWORD;
            }
            bool isBanned = mySqlDataReader.GetBoolean("Banned");
            if (isBanned)
            {
                return AccountStatus.BLOKED_ACCOUNT;
            }
            bool isOnline = mySqlDataReader.GetBoolean("Online");
            if (isOnline)
            {
                return AccountStatus.ACCOUNT_ALLREADY_CONNECTED;
            }
            return AccountStatus.AUTHENTICATION_ACCEPTED;
        }
        
        public static string ConstructUpdateQuery(string tabeleName,Dictionary<string,string> queryParams,string whereName ,string whereValue)
        {
            string query = string.Format("UPDATE {0} SET ",tabeleName);
            foreach (KeyValuePair<string, string> pair in queryParams)
            {
                query += string.Format( " {0} = \"{1}\",", pair.Key,pair.Value);
            }
            query = query.Remove(query.Length - 1);
            query += string.Format(" WHERE {0} = \"{1}\" ", whereName, whereValue);
            return query;
        }
        public static string ConstructInsertQuery(string tabeleName, Dictionary<string, string> queryParams)
        {
            string query = string.Format("INSERT INTO  {0} ( ", tabeleName);
            foreach (KeyValuePair<string, string> pair in queryParams)
            {
                query += string.Format("  {0},", pair.Key);
            }
            query = query.Remove(query.Length - 1);
            query += ")  VALUES (";
            foreach (KeyValuePair<string, string> pair in queryParams)
            {
                query += string.Format(" \"{0}\",", pair.Value);
            }
            query = query.Remove(query.Length - 1);
            query += ")";
            return query;
        }
        
        public static int GetHighestAcountPlayerLevel(int accountIndex)
        {
             List<Player> players = GetAccountPlayers(accountIndex);
            if (players.Count.Equals(0))
            {
                return 1;
            }
            else
            {
                int level = 1;
                foreach (Player player in players)
                {
                    if (player.level > level)
                    {
                        level = player.level;
                    }
                    

                }
                return level;
            }
        }
        public static int GetNewPlayerEmptySlot(int accountIndex)
        {
            MySqlDataReader mySqlDataReader = MySqlDatabaseConnection.Query(
                "SELECT Slot FROM Player WHERE AccountIndex=\"{0}\"", accountIndex.ToString());
            if (!mySqlDataReader.HasRows)
            {
                return 0;
            }
            int slot = 0;
            List<int> slots = new List<int>();
           while( mySqlDataReader.Read())
           {
                slots.Add(mySqlDataReader.GetInt32("Slot")); 
           }
            if(slots.Count > 5)
            {
                throw new Exception("More Than 5 Slots");
            }
            if(slots.Count.Equals(0))
            {
                return slot;
            }
           for(int i = 0; i < 5;i++)
           {
             if(!slots.Contains(i))
             {
                 return i;
             }
           }
            throw new Exception("Trying To Get Slot With 5 Slots Busy");
        }
        public static  bool CheckAccountIsOnline(Account account)
        {
             MySqlDataReader mySqlDataReader = MySqlDatabaseConnection.Query(
                "SELECT IsOnline FROM Account WHERE Login=\"{0}\"", account.login);

             mySqlDataReader.Read();
             return mySqlDataReader.GetBoolean("Online");
        }
        public static  void ResetAccountsIsOnline()
        {
            MySqlDatabaseConnection.Query("UPDATE Account SET Online = 0 WHERE Online = 1");
        }
        public static void SetAccountIsOnline(Account account)
        {
            MySqlDatabaseConnection.Query("UPDATE Account SET Online = 1 WHERE Login=\"{0}\"", account.login);
             
        }
        public static void SetAccountIsOffline(Account account)
        {
            MySqlDatabaseConnection.Query("UPDATE Account SET Online = 0 WHERE Login=\"{0}\"", account.login);

        }
        public static bool CheckPlayerNameAvailable(string playerName)
        {
            MySqlDataReader mySqlDataReader = MySqlDatabaseConnection.Query("SELECT Name FROM Player WHERE Name=\"{0}\"", playerName);

            return mySqlDataReader.HasRows;

        }
        public static Player CreateNewPlayer(string name, int race, int accountIndex)
        {


            Player player = new Player(); ;//= TemplateDefaultPlayer.Create(name, race, accountIndex, GetNewPlayerEmptySlot(accountIndex));

            SaveObject(player);
            return player;
        }
        public static bool CheckPlayerExist(Player player)
        {
            MySqlDataReader mySqlDataReader = MySqlDatabaseConnection.Query("SELECT Name FROM Player WHERE Name=\"{0}\"", player.name);
            
           return mySqlDataReader.HasRows;
            
        }
        public static bool CheckAccountExist(Account account)
        {
            MySqlDataReader mySqlDataReader = MySqlDatabaseConnection.Query("SELECT Login FROM Account WHERE Login=\"{0}\"", account.login);

            return mySqlDataReader.HasRows;

        }
        public static int GetPlayerIndexByName(string playerName)
        {
            MySqlDataReader mySqlDataReader = MySqlDatabaseConnection.Query(
                "SELECT PlayerIndex FROM Player WHERE Name=\"{0}\"", playerName);

            mySqlDataReader.Read();
            return mySqlDataReader.GetInt32("PlayerIndex");
        }
        public static int GetAccountIndexByLogin(string playerName)
        {
            MySqlDataReader mySqlDataReader = MySqlDatabaseConnection.Query(
                "SELECT AccountIndex FROM Account WHERE Login=\"{0}\"", playerName);

            mySqlDataReader.Read();
            return mySqlDataReader.GetInt32("AccountIndex");
        }
        public static void RemovePlayer(int playerIndex)
        {
            MySqlDatabaseConnection.Query("DELETE FROM Player WHERE PlayerIndex=\"{0}\"", playerIndex.ToString());
        }
        public static void RemovePlayer(string playerName)
        {
            MySqlDatabaseConnection.Query("DELETE FROM Player WHERE Name=\"{0}\"", playerName);
        }
        public static void RemovePlayer(Player player)
        {
            MySqlDatabaseConnection.Query("DELETE FROM Player WHERE Name=\"{0}\"", player.name.ToString());
        }
        public static T GetObject<T>(int index)
        {
            var obj = Activator.CreateInstance(typeof(T));
            MySqlDataReader mySqlDataReader = null;
            if (typeof(T).Equals(typeof(Player)))
            {
                mySqlDataReader = MySqlDatabaseConnection.Query("SELECT * FROM Player WHERE PlayerIndex=\"{0}\"", index.ToString());
            }
            if (typeof(T).Equals(typeof(Account)))
            {
                mySqlDataReader = MySqlDatabaseConnection.Query("SELECT * FROM Account WHERE AccountIndex=\"{0}\"", index.ToString());
            }
            mySqlDataReader.Read();
            var fields = obj.GetType().GetFields();

            foreach (var field in obj.GetType().GetFields())
            {
                var attrs = field.GetCustomAttributes(typeof(System.Runtime.Serialization.DataMemberAttribute), true) as System.Runtime.Serialization.DataMemberAttribute[];

                if (attrs.Length == 0)
                {
                    continue;
                }

                var fieldID = attrs[0].Name;
                var fieldType = field.FieldType;

                field.SetValue(obj, mySqlDataReader.GetValue(mySqlDataReader.GetOrdinal(fieldID)));
            }

            return (T)obj;
        }
        public static void SaveObject(object objectType)
        {
           

            var fields = objectType.GetType().GetFields();
            Dictionary<string, string> paramsList = new Dictionary<string, string>();
            foreach (var field in fields)
            {
                var attrs = field.GetCustomAttributes(typeof(System.Runtime.Serialization.DataMemberAttribute), true) as System.Runtime.Serialization.DataMemberAttribute[];

                if (attrs.Length == 0)
                {
                    continue;
                }

                var fieldName = attrs[0].Name;
                var fieldType = field.FieldType;
                if (field.GetValue(objectType) == null)
                {
                    if (fieldType.Equals(typeof(string)))
                    {
                        paramsList.Add(fieldName, string.Empty);
                    }
                    if (fieldType.Equals(typeof(int)))
                    {
                        paramsList.Add(fieldName, "0");
                    }
                }
                else
                {
                    paramsList.Add(fieldName, field.GetValue(objectType).ToString());
                }
            }
            if (objectType is Account)
            {
                Account account = (Account) objectType;
                MySqlDatabaseConnection.Query(ConstructUpdateQuery("Account", paramsList, "AccountIndex",account.index.ToString()));
            }
            if (objectType is Player)
            {
                Player player = (Player)objectType;
                if (CheckPlayerExist(player))
                {
                    MySqlDatabaseConnection.Query(ConstructUpdateQuery("Player", paramsList, "PlayerIndex", player.index.ToString()));
                }
                else
                {
                    MySqlDatabaseConnection.Query(ConstructInsertQuery("Player", paramsList));
                }
            }

        }
       
       
       
        public static bool CheckPlayersNameAvailable(string playerName)
        {
            MySqlDataReader mySqlDataReader = MySqlDatabaseConnection.Query(
               "SELECT PlayerIndex FROM Player WHERE Name=\"{0}\" ;", playerName);
            if (mySqlDataReader.HasRows)
            {
                return false;
            }
            
            return true;
        }
        public static int GetAccountPlayersCount(int accountIndex)
        {
            MySqlDataReader mySqlDataReader = MySqlDatabaseConnection.Query(
               "SELECT PlayerIndex FROM Player WHERE AccountIndex=\"{0}\" ;", accountIndex.ToString());
            int counter = 0;
            if (!mySqlDataReader.HasRows)
            {
                return counter;
            }
            while (mySqlDataReader.Read())
            {
                counter++;
            }
            return counter;
        }
        public static List<Player> GetAccountPlayers(int accountIndex)
        {
            MySqlDataReader mySqlDataReader = MySqlDatabaseConnection.Query(
                "SELECT PlayerIndex FROM Player WHERE AccountIndex=\"{0}\" ;", accountIndex.ToString());
            List<Player> playersList = new List<Player>(5);
            if (!mySqlDataReader.HasRows)
            {
                return  playersList;
            }
            
            while (mySqlDataReader.Read())
            {
                
               
                playersList.Add( GetObject<Player>(mySqlDataReader.GetInt32("PlayerIndex")));
            }
            return playersList;
        }

    }
}

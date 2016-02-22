using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

using Common.Utility;

namespace Common.Database
{
    public class MySqlDatabaseConnection 
    {
        
        private static string host;
        private static string port;
        private static string databaseName;
        private static string login;
        private static string password;

        public static string ConnectionString
        {
            get { return string.Format("Server={0}; Port={1}; UserID={2}; Password={3}", host, port, login, password); }

        }
        public static bool Initialize(string dbHost, string dbPort, string dbName, string dbLogin, string dbPassword)
        {

            try
            {
                host = dbHost;
                port = dbPort;
                databaseName = dbName;
                login = dbLogin;
                password = dbPassword;
                Logger.Info("[Databaase] Initialize Connection With - Host:{0} Port:{1} DatabaseName:{2} Login:{3} Password:{4}", host,port,databaseName,login,password);
                CheckConnection();
               return CheckDatabaseExist();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static bool CheckConnection()
        {

            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
                mySqlConnection.Open();
                mySqlConnection.Close();
                Logger.Info("[Databaase]Connection Ok");
                return true;
            }
            catch (Exception exception)
            {
                Logger.Info("[Databaase]Connection Failed");
                return false;
            }
        }
        public static bool CheckDatabaseExist()
        {
            try
            {

                MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
                mySqlConnection.Open();
                mySqlConnection.ChangeDatabase(databaseName);
                mySqlConnection.Close();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
        public static bool CreateDatabase(string databaseName)
        {
            try
            {

                MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
                mySqlConnection.Open();
                string Query = string.Format("CREATE DATABASE IF NOT EXISTS {0}", databaseName);
                MySqlCommand SqlCommand = new MySqlCommand(Query, mySqlConnection);
                SqlCommand.ExecuteNonQuery();
                mySqlConnection.ChangeDatabase(databaseName);
                mySqlConnection.Close();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

     
        public static MySqlDataReader Query(string queryString, params string[] values)
        {
            return Query(string.Format(queryString, values));
        }
        public static void SelectDatabase(MySqlConnection SqlConnection)
        {
           SqlConnection.ChangeDatabase(databaseName);
        }
        public static MySqlDataReader Query(string queryString)
        {
            try
            {
                MySqlConnection SqlConnection = new MySqlConnection(ConnectionString);
               
                SqlConnection.Open();
                SelectDatabase(SqlConnection);
                MySqlCommand SqlCommand = new MySqlCommand(queryString, SqlConnection);
               // SqlCommand.ExecuteNonQuery();
                return SqlCommand.ExecuteReader();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
    }
}

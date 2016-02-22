using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

using Common.Utility;

namespace Database.MySqlOperation
{
    public class MySqlDatabaseConnection : Singleton< MySqlDatabaseConnection>
    {
        private string host;
        private string port;
        private string databaseName;
        private string login;
        private string password;


        public string ConnectionString
        {
            get { return string.Format("Server={0}; Port={1}; UserID={2}; Password={3}", host, port, login, password); }

        }
        public MySqlDatabaseConnection(string host, string port, string databaseName, string login, string password)
        {

            try
            {
                this.host = host;
                this.port = port;
                this.databaseName = databaseName;
                this.login = login;
                this.password = password;

                CheckDatabaseExist();
            }
            catch (Exception exception)
            {

            }
        }
        public bool CheckConnection()
        {

            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
                mySqlConnection.Open();
                mySqlConnection.Close();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
        public bool CheckDatabaseExist()
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
        public bool CreateDatabase(string databaseName)
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

        public bool RestoreTabeles(string folderPath)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
                mySqlConnection.Open();
                List<string> queryList = QueryReader.GetTableQueryFiles(folderPath);
                foreach (string query in queryList)
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                    mySqlCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
        public MySqlDataReader Query(string queryString, params string[] values)
        {
            return Query(string.Format(queryString, values));
        }
     
        public MySqlDataReader Query(string queryString)
        {
            try
            {
                MySqlConnection SqlConnection = new MySqlConnection(ConnectionString);
                SqlConnection.Open();
                MySqlCommand SqlCommand = new MySqlCommand(queryString, SqlConnection);
                SqlCommand.ExecuteNonQuery();
                return SqlCommand.ExecuteReader();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
    }
}

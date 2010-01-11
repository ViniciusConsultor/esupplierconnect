using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace eProcurement_DAL
{
    /// <summary>
    /// The DataManager class is the singleton instance
    /// </summary>
    public sealed class DataManager
    {
        private const string CONNECTION_NAME = "eProcurement.ConnectionString";
        private const string ENCRYPTED_PWD = "DB_KEY";

        // singleton instances
        private static volatile string _connectionString;
       
        // lock objects, each singleton has own to prevent deadlock
        private static object _connectionStringLock = new Object();

        private DataManager()
        { }

        /// <summary>The application connection string read from web.confiQueryg or app.config</summary>		
        /// <example>
        /// Add the following key to the "connectionStrings" section of your config:
        /// <code><![CDATA[
        /// <configuration>
        /// 	<connectionStrings>
        /// 		<add name="eProcurement.ConnectionString" 
        /// 			connectionString="Data Source=(local);Initial Catalog=DATABASE;Integrated Security=True"
        /// 			providerName="System.Data.SqlClient" />
        /// 	</connectionStrings>
        /// </configuration>
        /// ]]></code>
        /// </example>
        internal static string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                {
                    lock (_connectionStringLock)
                    {
                        if (_connectionString == null)
                            _connectionString = GetDefaultConnectionString();
                    }
                }
                return _connectionString;
            }
        }

        private static string GetDefaultConnectionString()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[CONNECTION_NAME];
            if (settings == null)
            {
                string message = string.Format("Could not find the connection string '{0}' in the configuration file.  " +
                       "Please add an entry to connectionStrings section named '{0}'.", CONNECTION_NAME);
                throw new Exception(message);
            }

            string connectString = settings.ConnectionString;

            String dbKey =ConfigurationManager.AppSettings[ENCRYPTED_PWD].ToString();
            if (!string.IsNullOrEmpty(dbKey)) 
            {
                SqlConnectionStringBuilder csb =
                    new SqlConnectionStringBuilder(connectString);
                csb.Password = Encryption.Decrypt(dbKey);
                connectString = csb.ConnectionString;
            }
            return connectString;
        }

        public static EpTransaction BeginTransaction()
        {
            EpTransaction epTransaction = new EpTransaction();
            return epTransaction;
        }

        public static SqlConnection GetConnection()
        {

            SqlConnection connection = new SqlConnection(DataManager.ConnectionString);
            return connection;
        }

        public static string EscapeSQL(string str)
        {
            string strReturn = string.Empty;
            if (!string.IsNullOrEmpty(str))
                strReturn = str.Replace("'", "''");
            return strReturn;
        }
    }
}

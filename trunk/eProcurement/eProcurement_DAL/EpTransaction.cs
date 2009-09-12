using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;


namespace eProcurement_DAL
{
    public class EpTransaction
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        internal EpTransaction() 
        {
            connection = new SqlConnection(DataManager.ConnectionString);
            if (this.connection.State != System.Data.ConnectionState.Open)
            {
                this.connection.Open();
            }
            this.transaction = this.connection.BeginTransaction();
        }

        public SqlConnection GetSqlConnection() 
        {
            return this.connection;
        }

        public SqlTransaction GetSqlTransaction()
        {
            return this.transaction;
        }

        public void Commit()
        {
            if (this.transaction != null)
                this.transaction.Commit();
            if (this.connection.State == System.Data.ConnectionState.Open)
                this.connection.Close();
        }

        public void Rollback()
        {
            if (this.transaction != null)
                this.transaction.Rollback();
            if (this.connection.State == System.Data.ConnectionState.Open)
                this.connection.Close();
        }

        public void Dispose()
        {
            if (this.transaction != null)
                this.transaction.Dispose();
            if (this.connection.State == System.Data.ConnectionState.Open)
                this.connection.Close();

        }
    }
}

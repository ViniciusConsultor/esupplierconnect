using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace eProcurement_DAL
{
    public class PurchaseHeaderTextDAO
    {
        #region RetrieveAll
        public static Collection<PurchaseHeaderText> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public static Collection<PurchaseHeaderText> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public static Collection<PurchaseHeaderText> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public static Collection<PurchaseHeaderText> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public static Collection<PurchaseHeaderText> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public static Collection<PurchaseHeaderText> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public static Collection<PurchaseHeaderText> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public static Collection<PurchaseHeaderText> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion
        #region RetrieveByKey
        public static PurchaseHeaderText RetrieveByKey(string orderNumber, string textSequence)
        {
            return RetrieveByKey(null, orderNumber, textSequence);
        }

        public static PurchaseHeaderText RetrieveByKey(EpTransaction epTran, string orderNumber, string textSequence)
        {
            PurchaseHeaderText entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(orderNumber) + "' ";
            whereClause += "AND TXTITM='" + DataManager.EscapeSQL(textSequence) + "'";

            Collection<PurchaseHeaderText> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
         #endregion

        #region Insert
        public static void Insert(PurchaseHeaderText entity)
        {
            Insert(null, entity);
        }

        public static void Insert(EpTransaction epTran, PurchaseHeaderText entity)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.Text;

            //set connection
            SqlConnection connection;
            if (epTran == null)
                connection = DataManager.GetConnection();
            else
                connection = epTran.GetSqlConnection();
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            cm.Connection = connection;

            //set transaction
            if (epTran != null)
                cm.Transaction = epTran.GetSqlTransaction();

            //Check whether record exists
            PurchaseHeaderText checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.TextSequence);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO purhtxt ([EBELN],[TXTITM],[LTXT]) VALUES(@EBELN,@TXTITM,@LTXT)";
            SqlParameter p1 = new SqlParameter("@LTXT", SqlDbType.NVarChar, 255);
            cm.Parameters.Add(p1);
            p1.Value = entity.LongText;
            SqlParameter p3 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.OrderNumber;
            SqlParameter p4 = new SqlParameter("@TXTITM", SqlDbType.Char, 5);
            cm.Parameters.Add(p4);
            p4.Value = entity.TextSequence;
            cm.ExecuteNonQuery();
            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public static void Update(PurchaseHeaderText entity)
        {
            Update(null, entity);
        }

        public static void Update(EpTransaction epTran, PurchaseHeaderText entity)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.Text;

            //set connection
            SqlConnection connection;
            if (epTran == null)
                connection = DataManager.GetConnection();
            else
                connection = epTran.GetSqlConnection();
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            cm.Connection = connection;

            //set transaction
            if (epTran != null)
                cm.Transaction = epTran.GetSqlTransaction();

            //Check whether record exists
            PurchaseHeaderText checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.TextSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE purhtxt SET LTXT=@LTXT WHERE EBELN=@EBELN AND TXTITM=@TXTITM";
            SqlParameter p1 = new SqlParameter("@LTXT", SqlDbType.NVarChar, 255);
            cm.Parameters.Add(p1);
            p1.Value = entity.LongText;
            SqlParameter p3 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.OrderNumber;
            SqlParameter p4 = new SqlParameter("@TXTITM", SqlDbType.Char, 5);
            cm.Parameters.Add(p4);
            p4.Value = entity.TextSequence;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public static void Delete(PurchaseHeaderText entity)
        {
            Delete(null, entity);
        }

        public static void Delete(EpTransaction epTran, PurchaseHeaderText entity)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.Text;

            //set connection
            SqlConnection connection;
            if (epTran == null)
                connection = DataManager.GetConnection();
            else
                connection = epTran.GetSqlConnection();
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            cm.Connection = connection;

            //set transaction
            if (epTran != null)
                cm.Transaction = epTran.GetSqlTransaction();

            //Check whether record exists
            PurchaseHeaderText checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.TextSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }
            //Update 
            cm.CommandText = "DELETE FROM purhtxt WHERE EBELN=@EBELN AND TXTITM=@TXTITM";
            SqlParameter p3 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.OrderNumber;
            SqlParameter p4 = new SqlParameter("@TXTITM", SqlDbType.Char, 5);
            cm.Parameters.Add(p4);
            p4.Value = entity.TextSequence;
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<PurchaseHeaderText> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<PurchaseHeaderText> entities = new Collection<PurchaseHeaderText>();

            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.Text;

            //set connection
            SqlConnection connection;
            if (epTran == null)
                connection = DataManager.GetConnection();
            else
                connection = epTran.GetSqlConnection();
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            cm.Connection = connection;

            //set transaction
            if (epTran != null)
                cm.Transaction = epTran.GetSqlTransaction();

            //Retrieve Data
            string selectCommand = "SELECT [EBELN],[TXTITM],[LTXT] FROM purhtxt";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseHeaderText entity = new PurchaseHeaderText();
                entity.OrderNumber = rd["EBELN"].ToString();
                entity.TextSequence = rd["TXTITM"].ToString();
                entity.LongText = rd["LTXT"].ToString();
                entities.Add(entity);

            }
            // close reader
            rd.Close();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();

            return entities;
        }
        #endregion
    }
}

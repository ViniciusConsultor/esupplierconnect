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
    public class PurchaseOrderHeaderTextDAO
    {
        #region RetrieveAll
        public static Collection<PurchaseOrderHeaderText> RetrieveAll() 
        {
            return Retrieve(null, "", "");
        }

        public static Collection<PurchaseOrderHeaderText> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public static Collection<PurchaseOrderHeaderText> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public static Collection<PurchaseOrderHeaderText> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public static Collection<PurchaseOrderHeaderText> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public static Collection<PurchaseOrderHeaderText> RetrieveByQuery(string whereClause,string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public static Collection<PurchaseOrderHeaderText> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public static Collection<PurchaseOrderHeaderText> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public static PurchaseOrderHeaderText RetrieveByKey(string orderNumber, string textSerialNumber)
        {
            return RetrieveByKey(null, orderNumber, textSerialNumber);
        }

        public static PurchaseOrderHeaderText RetrieveByKey(EpTransaction epTran, string orderNumber, string textSerialNumber)
        {
            PurchaseOrderHeaderText entity =null; 
            string whereClause=" EBELN='" + DataManager.EscapeSQL(orderNumber)+ "' " ;
            whereClause += "AND TXTITM='" + DataManager.EscapeSQL(textSerialNumber) + "'";

            Collection<PurchaseOrderHeaderText> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public static void Insert(PurchaseOrderHeaderText entity)
        {
            Insert(null, entity);
        }

        public static void Insert(EpTransaction epTran, PurchaseOrderHeaderText entity)
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
            PurchaseOrderHeaderText checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.TextSerialNumber);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO puhtxt ([EBELN],[TXTITM],[LTXT],[RECSTS]) VALUES(@EBELN,@TXTITM,@LTXT,@RECSTS)";
            SqlParameter p1 = new SqlParameter("@LTXT", SqlDbType.NVarChar, 255);
            cm.Parameters.Add(p1);
            p1.Value = entity.LongText;
            SqlParameter p2 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p2);
            p2.Value = entity.RecordStatus;
            SqlParameter p3 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.OrderNumber;
            SqlParameter p4 = new SqlParameter("@TXTITM", SqlDbType.Char, 5);
            cm.Parameters.Add(p4);
            p4.Value = entity.TextSerialNumber;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public static void Update(PurchaseOrderHeaderText entity)
        {
            Update(null, entity);
        }

        public static void Update(EpTransaction epTran,PurchaseOrderHeaderText entity)
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
            PurchaseOrderHeaderText checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.TextSerialNumber);
            if (checkEntity == null) 
            {
                throw new Exception("Record doesn't exist."); 
            }

            //Update 
            cm.CommandText = "UPDATE puhtxt SET LTXT=@LTXT,RECSTS=@RECSTS WHERE EBELN=@EBELN AND TXTITM=@TXTITM";
            SqlParameter p1 = new SqlParameter("@LTXT", SqlDbType.NVarChar, 255);
            cm.Parameters.Add(p1);
            p1.Value = entity.LongText;
            SqlParameter p2 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p2);
            p2.Value = entity.RecordStatus;
            SqlParameter p3 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.OrderNumber;
            SqlParameter p4 = new SqlParameter("@TXTITM", SqlDbType.Char, 5);
            cm.Parameters.Add(p4);
            p4.Value = entity.TextSerialNumber;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public static void Delete(PurchaseOrderHeaderText entity)
        {
            Delete(null, entity);
        }

        public static void Delete(EpTransaction epTran, PurchaseOrderHeaderText entity)
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
            PurchaseOrderHeaderText checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.TextSerialNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM puhtxt WHERE EBELN=@EBELN AND TXTITM=@TXTITM";
            SqlParameter p3 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.OrderNumber;
            SqlParameter p4 = new SqlParameter("@TXTITM", SqlDbType.Char, 5);
            cm.Parameters.Add(p4);
            p4.Value = entity.TextSerialNumber;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<PurchaseOrderHeaderText> Retrieve(EpTransaction epTran,string whereClause,string sortClaues) 
        {
            Collection<PurchaseOrderHeaderText> entities = new Collection<PurchaseOrderHeaderText>();

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
            string selectCommand = "SELECT [EBELN],[TXTITM],[LTXT],[RECSTS] FROM puhtxt";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseOrderHeaderText entity = new PurchaseOrderHeaderText();
                entity.OrderNumber = rd["EBELN"].ToString();
                entity.TextSerialNumber = rd["TXTITM"].ToString();
                entity.LongText = rd["LTXT"].ToString();
                entity.RecordStatus = rd["RECSTS"].ToString();
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

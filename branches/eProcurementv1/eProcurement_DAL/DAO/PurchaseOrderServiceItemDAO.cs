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
    public class PurchaseOrderServiceItemDAO
    {
        #region RetrieveAll
        public static Collection<PurchaseOrderServiceItem> RetrieveAll() 
        {
            return Retrieve(null, "", "");
        }

        public static Collection<PurchaseOrderServiceItem> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public static Collection<PurchaseOrderServiceItem> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public static Collection<PurchaseOrderServiceItem> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public static Collection<PurchaseOrderServiceItem> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public static Collection<PurchaseOrderServiceItem> RetrieveByQuery(string whereClause,string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public static Collection<PurchaseOrderServiceItem> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public static Collection<PurchaseOrderServiceItem> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public static PurchaseOrderServiceItem RetrieveByKey(string orderNumber, string ItemSequenceNumber, string ServiceLineNumber)
        {
            return RetrieveByKey(null, orderNumber, ItemSequenceNumber, ServiceLineNumber);
        }

        public static PurchaseOrderServiceItem RetrieveByKey(EpTransaction epTran, string orderNumber, string ItemSequenceNumber, string ServiceLineNumber)
        {
            PurchaseOrderServiceItem entity =null; 
            string whereClause=" EBELN='" + DataManager.EscapeSQL(orderNumber)+ "' " ;
            whereClause += "AND EBELP='" + DataManager.EscapeSQL(ItemSequenceNumber) + "' ";
            whereClause += "AND LBLN1='" + DataManager.EscapeSQL(ServiceLineNumber) + "'";

            Collection<PurchaseOrderServiceItem> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public static void Insert(PurchaseOrderServiceItem entity)
        {
            Insert(null, entity);
        }

        public static void Insert(EpTransaction epTran, PurchaseOrderServiceItem entity)
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
            PurchaseOrderServiceItem checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequenceNumber, entity.ServiceLineNumber);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO PURSRV ([EBELN],[EBELP],[LBLN1],[KTEXT1], [MENGE], [PREIS], [RECSTS]) VALUES(@EBELN,@EBELP, @LBLN1, @KTEXT1, @MENGE, @PREIS, @RECSTS)";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;
            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequenceNumber;
            SqlParameter p3 = new SqlParameter("@LBLN1", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.ServiceLineNumber;
            SqlParameter p4 = new SqlParameter("@KTEXT1", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p4);
            p4.Value = entity.ServiceDescription;
            SqlParameter p5 = new SqlParameter("@MENGE", SqlDbType.Decimal,13);
            cm.Parameters.Add(p5);
            if (entity.ServiceQuantity.HasValue)
                p5.Value = entity.ServiceQuantity.Value;
            else
                p5.Value = DBNull.Value;

            SqlParameter p6 = new SqlParameter("@PREIS", SqlDbType.Decimal,11);
            cm.Parameters.Add(p6);
            if (entity.ServicePrice.HasValue)
                p6.Value = entity.ServicePrice.Value;
            else
                p6.Value = DBNull.Value;

            SqlParameter p7 = new SqlParameter("@RECSTS", SqlDbType.Char,1);
            cm.Parameters.Add(p7);
            p7.Value = entity.RecordStatus;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public static void Update(PurchaseOrderServiceItem entity)
        {
            Update(null, entity);
        }

        public static void Update(EpTransaction epTran,PurchaseOrderServiceItem entity)
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
            PurchaseOrderServiceItem checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequenceNumber,entity.ServiceLineNumber);
            if (checkEntity == null) 
            {
                throw new Exception("Record doesn't exist."); 
            }

            //Update 
            cm.CommandText = "UPDATE PURSRV SET KTEXT1=@LTEXT1,MENGE=@MENGE,PREIS=@PREIS,RECSTS=@RECSTS WHERE EBELN=@EBELN AND EBELP=@EBELP AND LBLN1=@LBLN1";
            SqlParameter p1 = new SqlParameter("@KTEXT1", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p1);
            p1.Value = entity.ServiceDescription;
            SqlParameter p2 = new SqlParameter("@MENGE", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p2);
            if (entity.ServiceQuantity.HasValue)
                p2.Value = entity.ServiceQuantity.Value;
            else
                p2.Value = DBNull.Value;

            SqlParameter p3 = new SqlParameter("@PREIS", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p3);
            if (entity.ServicePrice.HasValue)
                p3.Value = entity.ServicePrice.Value;
            else
                p3.Value = DBNull.Value;

            SqlParameter p4 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p4);
            p4.Value = entity.RecordStatus;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public static void Delete(PurchaseOrderServiceItem entity)
        {
            Delete(null, entity);
        }

        public static void Delete(EpTransaction epTran, PurchaseOrderServiceItem entity)
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
            PurchaseOrderServiceItem checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequenceNumber,entity.ServiceLineNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM PURSRV WHERE EBELN=@EBELN AND EBELP=@EBELP AND LBLN1=@LBLN1";
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;
            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequenceNumber;
            SqlParameter p3 = new SqlParameter("@LBLN1", SqlDbType.Char,10);
            cm.Parameters.Add(p3);
            p3.Value = entity.ServiceLineNumber;
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<PurchaseOrderServiceItem> Retrieve(EpTransaction epTran,string whereClause,string sortClaues) 
        {
            Collection<PurchaseOrderServiceItem> entities = new Collection<PurchaseOrderServiceItem>();

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
            string selectCommand = "SELECT [EBELN],[EBELP],[LBLN1],[KTEXT1],[MENGE],[PREIS],[RECSTS] FROM PURSRV";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseOrderServiceItem entity = new PurchaseOrderServiceItem();
                entity.OrderNumber = rd["EBELN"].ToString();
                entity.ItemSequenceNumber = rd["EBELP"].ToString();
                entity.ServiceLineNumber = rd["LBLN1"].ToString();
                entity.ServiceDescription = rd["KTEXT1"].ToString();

                if (rd.IsDBNull(4))
                    entity.ServiceQuantity = null;
                else
                    entity.ServiceQuantity = Convert.ToDecimal(rd["MENGE"].ToString());

                if (rd.IsDBNull(5))
                    entity.ServicePrice = null;
                else
                    entity.ServicePrice = Convert.ToDecimal(rd["PREIS"].ToString());

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

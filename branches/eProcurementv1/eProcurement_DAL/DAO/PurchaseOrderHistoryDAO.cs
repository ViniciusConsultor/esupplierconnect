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
    public class PurchaseOrderHistoryDAO
    {
        #region RetrieveAll
        public static Collection<PurchaseOrderHistory> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public static Collection<PurchaseOrderHistory> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public static Collection<PurchaseOrderHistory> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public static Collection<PurchaseOrderHistory> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public static Collection<PurchaseOrderHistory> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public static Collection<PurchaseOrderHistory> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public static Collection<PurchaseOrderHistory> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public static Collection<PurchaseOrderHistory> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public static PurchaseOrderHistory RetrieveByKey(string orderNumber, string itemSequence, string materialDocument)
        {
            return RetrieveByKey(null, orderNumber, itemSequence, materialDocument);
        }

        public static PurchaseOrderHistory RetrieveByKey(EpTransaction epTran, string orderNumber, string itemSequence, string materialDocument)
        {
            PurchaseOrderHistory entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(orderNumber) + "' ";
            whereClause += "AND EBELP='" + DataManager.EscapeSQL(itemSequence) + "' ";
            whereClause += "AND DOCNO='" + DataManager.EscapeSQL(materialDocument) + "' ";

            Collection<PurchaseOrderHistory> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public static void Insert(PurchaseOrderHistory entity)
        {
            Insert(null, entity);
        }

        public static void Insert(EpTransaction epTran, PurchaseOrderHistory entity)
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
            PurchaseOrderHistory checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.DocumentNumber);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO PURHIST ([EBELN],[EBELP],[TRTYP],[DOCNO],[ITEMNO],[MVTTYP],[AEDAT],[TRNQTY],[MEINS],[TRNAMT],[WAERS],[REFNO],[REFSRL],[INVVAL],[MATNR],[WERKS]) VALUES(@EBELN,@EBELP,@TRTYP,@DOCNO,@ITEMNO,@MVTTYP,@AEDAT,@TRNQTY,@MEINS,@TRNAMT,@WAERS,@REFNO,@REFSRL,@INVVAL,@MATNR,@WERKS)";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;

            SqlParameter p3 = new SqlParameter("@TRTYP", SqlDbType.Char, 2);
            cm.Parameters.Add(p3);
            p3.Value = entity.TransactionType;

            SqlParameter p4 = new SqlParameter("@DOCNO", SqlDbType.Char, 10);
            cm.Parameters.Add(p4);
            p4.Value = entity.DocumentNumber;

            SqlParameter p5 = new SqlParameter("@ITEMNO", SqlDbType.Char, 4);
            cm.Parameters.Add(p5);
            p5.Value = entity.DocumentSerial;

            SqlParameter p6 = new SqlParameter("@MVTTYP", SqlDbType.Char, 3);
            cm.Parameters.Add(p6);
            p6.Value = entity.MovementType;

            SqlParameter p7 = new SqlParameter("@AEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p7);
            if (entity.PostingDate.HasValue)
                p7.Value = entity.PostingDate;
            else
                p7.Value = DBNull.Value;

            SqlParameter p8 = new SqlParameter("@TRNQTY", SqlDbType.Decimal, 8);
            cm.Parameters.Add(p8);
            if (entity.TransactionQuantity.HasValue)
                p8.Value = entity.TransactionQuantity;
            else
                p8.Value = DBNull.Value;

            SqlParameter p9 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p9);
            p9.Value = entity.UnitOfMeasure;

            SqlParameter p10 = new SqlParameter("@TRNAMT", SqlDbType.Decimal, 9);
            cm.Parameters.Add(p10);
            if (entity.TransactionAmount.HasValue)
                p10.Value = entity.TransactionAmount;
            else
                p10.Value = DBNull.Value;

            SqlParameter p11 = new SqlParameter("@WAERS", SqlDbType.Char, 3);
            cm.Parameters.Add(p11);
            p11.Value = entity.CurrencyId;

            SqlParameter p12 = new SqlParameter("@REFNO", SqlDbType.Char, 12);
            cm.Parameters.Add(p12);
            p12.Value = entity.ReferenceNumber;

            SqlParameter p13 = new SqlParameter("@REFSRL", SqlDbType.Char, 10);
            cm.Parameters.Add(p13);
            p13.Value = entity.ReferenceSerial;

            SqlParameter p14 = new SqlParameter("@INVVAL", SqlDbType.Decimal, 5);
            cm.Parameters.Add(p14);
            if (entity.InvoiceValue.HasValue)
                p14.Value = entity.InvoiceValue;
            else
                p14.Value = DBNull.Value;

            SqlParameter p15 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p15);
            p15.Value = entity.MaterialNumber;

            SqlParameter p16 = new SqlParameter("@WERKS", SqlDbType.Char, 4);
            cm.Parameters.Add(p16);
            p16.Value = entity.Plant;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public static void Update(PurchaseOrderHistory entity)
        {
            Update(null, entity);
        }

        public static void Update(EpTransaction epTran, PurchaseOrderHistory entity)
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
            PurchaseOrderHistory checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.DocumentNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE PURHIST SET [EBELN]=@EBELN,[EBELP]=@EBELP,[TRTYP]=@TRTYP,[DOCNO]=@DOCNO,[ITEMNO]=@ITEMNO,[MVTTYP]=@MVTTYP,[AEDAT]=@AEDAT,[TRNQTY]=@TRNQTY,[MEINS]=@MEINS,[TRNAMT]=@TRNAMT,[WAERS]=@WAERS,[REFNO]=@REFNO,[REFSRL]=@REFSRL,[INVVAL]=@INVVAL,[MATNR]=@MATNR,[WERKS]=@WERKS WHERE EBELN=@EBELN AND EBELP=@EBELP AND DOCNO=@DOCNO";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.VarChar, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;

            SqlParameter p3 = new SqlParameter("@TRTYP", SqlDbType.VarChar, 2);
            cm.Parameters.Add(p3);
            p3.Value = entity.TransactionType;

            SqlParameter p4 = new SqlParameter("@DOCNO", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p4);
            p4.Value = entity.DocumentNumber;

            SqlParameter p5 = new SqlParameter("@ITEMNO", SqlDbType.VarChar, 4);
            cm.Parameters.Add(p5);
            p5.Value = entity.DocumentSerial;

            SqlParameter p6 = new SqlParameter("@MVTTYP", SqlDbType.VarChar, 3);
            cm.Parameters.Add(p6);
            p6.Value = entity.MovementType;

            SqlParameter p7 = new SqlParameter("@AEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p7);
            if (entity.PostingDate.HasValue)
                p7.Value = entity.PostingDate;
            else
                p7.Value = DBNull.Value;

            SqlParameter p8 = new SqlParameter("@TRNQTY", SqlDbType.Decimal, 8);
            cm.Parameters.Add(p8);
            if (entity.TransactionQuantity.HasValue)
                p8.Value = entity.TransactionQuantity;
            else
                p8.Value = DBNull.Value;

            SqlParameter p9 = new SqlParameter("@MEINS", SqlDbType.VarChar, 3);
            cm.Parameters.Add(p9);
            p9.Value = entity.UnitOfMeasure;

            SqlParameter p10 = new SqlParameter("@TRNAMT", SqlDbType.Decimal, 8);
            cm.Parameters.Add(p10);
            if (entity.TransactionAmount.HasValue)
                p10.Value = entity.TransactionAmount;
            else
                p10.Value = DBNull.Value;

            SqlParameter p11 = new SqlParameter("@WAERS", SqlDbType.VarChar, 3);
            cm.Parameters.Add(p11);
            p11.Value = entity.CurrencyId;

            SqlParameter p12 = new SqlParameter("@REFNO", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p12);
            p12.Value = entity.ReferenceNumber;

            SqlParameter p13 = new SqlParameter("@REFSRL", SqlDbType.VarChar, 5);
            cm.Parameters.Add(p13);
            p13.Value = entity.ReferenceSerial;

            SqlParameter p14 = new SqlParameter("@INVVAL", SqlDbType.Decimal, 8);
            cm.Parameters.Add(p14);
            if (entity.InvoiceValue.HasValue)
                p14.Value = entity.InvoiceValue;
            else
                p14.Value = DBNull.Value;

            SqlParameter p15 = new SqlParameter("@MATNR", SqlDbType.VarChar, 18);
            cm.Parameters.Add(p13);
            p13.Value = entity.MaterialNumber;

            SqlParameter p16 = new SqlParameter("@WERKS", SqlDbType.VarChar, 4);
            cm.Parameters.Add(p13);
            p13.Value = entity.Plant;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public static void Delete(PurchaseOrderHistory entity)
        {
            Delete(null, entity);
        }

        public static void Delete(EpTransaction epTran, PurchaseOrderHistory entity)
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
            PurchaseOrderHistory checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.DocumentNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM PURHIST WHERE EBELN=@EBELN AND EBELP=@EBELP AND DOCNO=@DOCNO";
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;

            SqlParameter p3 = new SqlParameter("@DOCNO", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.DocumentNumber;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<PurchaseOrderHistory> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<PurchaseOrderHistory> entities = new Collection<PurchaseOrderHistory>();

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
            string selectCommand = "SELECT [EBELN],[EBELP],[TRTYP],[DOCNO],[ITEMNO],[MVTTYP],[AEDAT],[TRNQTY],[MEINS],[TRNAMT],[WAERS],[REFNO],[REFSRL],[INVVAL],[MATNR],[WERKS] FROM PURHIST";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseOrderHistory entity = new PurchaseOrderHistory();
                entity.MaterialNumber = rd["EBELN"].ToString();
                entity.ItemSequence = rd["EBELP"].ToString();
                entity.TransactionType = rd["TRTYP"].ToString();
                entity.DocumentNumber = rd["DOCNO"].ToString();
                entity.DocumentSerial = rd["ITEMNO"].ToString();
                entity.MovementType = rd["MVTTYP"].ToString();

                if (rd.IsDBNull(6))
                    entity.PostingDate = null;
                else
                    entity.PostingDate= Convert.ToInt64(rd["AEDAT"]);

                if (rd.IsDBNull(7))
                    entity.TransactionQuantity = null;
                else
                    entity.TransactionQuantity = Convert.ToDecimal(rd["TRNQTY"]);

                entity.UnitOfMeasure = rd["MEINS"].ToString();

                if (rd.IsDBNull(9))
                    entity.TransactionQuantity = null;
                else
                    entity.TransactionQuantity = Convert.ToDecimal(rd["TRNAMT"]);

                entity.UnitOfMeasure = rd["WAERS"].ToString();
                entity.ReferenceNumber = rd["REFNO"].ToString();
                entity.ReferenceSerial = rd["REFSRL"].ToString();

                if (rd.IsDBNull(13))
                    entity.InvoiceValue = null;
                else
                    entity.InvoiceValue = Convert.ToDecimal(rd["INVVAL"]);

                entity.MaterialNumber = rd["MATNR"].ToString();
                entity.Plant = rd["WERKS"].ToString();

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

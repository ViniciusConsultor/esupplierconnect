using System;
using System.Collections.Generic;
using System.Collections.ObjectModel ;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace eProcurement_DAL
{
    public class PurchaseOrderHeaderDAO
    {
        #region RetrieveAll
        public static Collection<PurchaseOrderHeader> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public static Collection<PurchaseOrderHeader> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public static Collection<PurchaseOrderHeader> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public static Collection<PurchaseOrderHeader> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public static Collection<PurchaseOrderHeader> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public static Collection<PurchaseOrderHeader> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public static Collection<PurchaseOrderHeader> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public static Collection<PurchaseOrderHeader> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public static PurchaseOrderHeader RetrieveByKey(string orderNumber)
        {
            return RetrieveByKey(null, orderNumber);
        }

        public static PurchaseOrderHeader RetrieveByKey(EpTransaction epTran, string orderNumber)
        {
            PurchaseOrderHeader entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(orderNumber) + "' ";

            Collection<PurchaseOrderHeader> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public static void Insert(PurchaseOrderHeader entity)
        {
            Insert(null, entity);
        }

        public static void Insert(EpTransaction epTran, PurchaseOrderHeader entity)
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
            PurchaseOrderHeader checkEntity = RetrieveByKey(epTran, entity.OrderNumber);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO purhdr ([EBELN],[LIFNR],[BEDAT],[AMTPR],[GSTPR],[WAERS],[ZTERM],[BUYER],[AD_TLNMBR],[VERKF],[ADRNR_TXT],[REMARK],[STAT],[RECSTS],[ACKSTS]) VALUES(@EBELN,@LIFNR,@BEDAT,@AMTPR,@GSTPR,@WAERS,@ZTERM,@BUYER,@AD_TLNMBR,@VERKF,@ADRNR_TXT,@REMARK,@STAT,@RECSTS,@ACKSTS)";
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;
            SqlParameter p2 = new SqlParameter("@LIFNR", SqlDbType.Char, 10);
            cm.Parameters.Add(p2);
            p2.Value = entity.SupplierID;
            SqlParameter p3 = new SqlParameter("@BEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p3);
            if (entity.OrderDate.HasValue)
                p3.Value = entity.OrderDate;
            else
                p3.Value = DBNull.Value;
            SqlParameter p4 = new SqlParameter("@AMTPR", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p4);
            if (entity.OrderAmount.HasValue)
                p4.Value = entity.OrderAmount;
            else
                p4.Value = DBNull.Value;
            SqlParameter p5 = new SqlParameter("@GSTPR", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p5);
            if (entity.GstAmount.HasValue)
                p5.Value = entity.GstAmount;
            else
                p5.Value = DBNull.Value;
            SqlParameter p6 = new SqlParameter("@WAERS", SqlDbType.Char, 5);
            cm.Parameters.Add(p6);
            p6.Value = entity.CurrencyCode;
            SqlParameter p7 = new SqlParameter("@ZTERM", SqlDbType.Char, 4);
            cm.Parameters.Add(p7);
            p7.Value = entity.PaymentTerms;
            SqlParameter p8 = new SqlParameter("@BUYER", SqlDbType.VarChar, 31);
            cm.Parameters.Add(p8);
            p8.Value = entity.BuyerName;
            SqlParameter p9 = new SqlParameter("@AD_TLNMBR", SqlDbType.VarChar, 30);
            cm.Parameters.Add(p9);
            p9.Value = entity.AddressNumber;
            SqlParameter p10 = new SqlParameter("@VERKF", SqlDbType.VarChar, 30);
            cm.Parameters.Add(p10);
            p10.Value = entity.SalesPerson;
            SqlParameter p11 = new SqlParameter("@ADRNR_TXT", SqlDbType.VarChar, 80);
            cm.Parameters.Add(p11);
            p11.Value = entity.ShipmentAddress;
            SqlParameter p12 = new SqlParameter("@REMARK", SqlDbType.VarChar, 60);
            cm.Parameters.Add(p12);
            p12.Value = entity.Remarks;
            SqlParameter p13 = new SqlParameter("@STAT", SqlDbType.Char, 3);
            cm.Parameters.Add(p13);
            p13.Value = entity.OrderStatus;
            SqlParameter p14 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p14);
            p14.Value = entity.RecordStatus;
            SqlParameter p15 = new SqlParameter("@ACKSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p15);
            p15.Value = entity.AcknowledgeStatus;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public static void Update(PurchaseOrderHeader entity)
        {
            Update(null, entity);
        }

        public static void Update(EpTransaction epTran, PurchaseOrderHeader entity)
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
            PurchaseOrderHeader checkEntity = RetrieveByKey(epTran, entity.OrderNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE purhdr SET LIFNR=@LIFNR,BEDAT=@BEDAT,AMTPR=@AMTPR,GSTPR=@GSTPR,WAERS=@WAERS,ZTERM=@ZTERM,BUYER=@BUYER,AD_TLNMBR=@AD_TLNMBR,VERKF=@VERKF,ADRNR_TXT=@ADRNR_TXT,REMARK=@REMARK,STAT=@STAT,RECSTS=@RECSTS,ACKSTS=@ACKSTS WHERE EBELN=@EBELN";
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;
            SqlParameter p2 = new SqlParameter("@LIFNR", SqlDbType.Char, 10);
            cm.Parameters.Add(p2);
            p2.Value = entity.SupplierID;
            SqlParameter p3 = new SqlParameter("@BEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p3);
            if (entity.OrderDate.HasValue)
                p3.Value = entity.OrderDate;
            else
                p3.Value = DBNull.Value;
            SqlParameter p4 = new SqlParameter("@AMTPR", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p4);
            if (entity.OrderAmount.HasValue)
                p4.Value = entity.OrderAmount;
            else
                p4.Value = DBNull.Value;
            SqlParameter p5 = new SqlParameter("@GSTPR", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p5);
            if (entity.GstAmount.HasValue)
                p5.Value = entity.GstAmount;
            else
                p5.Value = DBNull.Value;
            SqlParameter p6 = new SqlParameter("@WAERS", SqlDbType.Char, 5);
            cm.Parameters.Add(p6);
            p6.Value = entity.CurrencyCode;
            SqlParameter p7 = new SqlParameter("@ZTERM", SqlDbType.Char, 4);
            cm.Parameters.Add(p7);
            p7.Value = entity.PaymentTerms;
            SqlParameter p8 = new SqlParameter("@BUYER", SqlDbType.VarChar, 31);
            cm.Parameters.Add(p8);
            p8.Value = entity.BuyerName;
            SqlParameter p9 = new SqlParameter("@AD_TLNMBR", SqlDbType.VarChar, 30);
            cm.Parameters.Add(p9);
            p9.Value = entity.AddressNumber;
            SqlParameter p10 = new SqlParameter("@VERKF", SqlDbType.VarChar, 30);
            cm.Parameters.Add(p10);
            p10.Value = entity.SalesPerson;
            SqlParameter p11 = new SqlParameter("@ADRNR_TXT", SqlDbType.VarChar, 80);
            cm.Parameters.Add(p11);
            p11.Value = entity.ShipmentAddress;
            SqlParameter p12 = new SqlParameter("@REMARK", SqlDbType.VarChar, 60);
            cm.Parameters.Add(p12);
            p12.Value = entity.Remarks;
            SqlParameter p13 = new SqlParameter("@STAT", SqlDbType.Char, 3);
            cm.Parameters.Add(p13);
            p13.Value = entity.OrderStatus;
            SqlParameter p14 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p14);
            p14.Value = entity.RecordStatus;
            SqlParameter p15 = new SqlParameter("@ACKSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p15);
            p15.Value = entity.AcknowledgeStatus;
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public static void Delete(PurchaseOrderHeader entity)
        {
            Delete(null, entity);
        }

        public static void Delete(EpTransaction epTran, PurchaseOrderHeader entity)
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
            PurchaseOrderHeader checkEntity = RetrieveByKey(epTran, entity.OrderNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM purhdr WHERE EBELN=@EBELN";
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<PurchaseOrderHeader> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<PurchaseOrderHeader> entities = new Collection<PurchaseOrderHeader>();

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
            string selectCommand = "SELECT [EBELN],[LIFNR],[BEDAT],[AMTPR],[GSTPR],[WAERS],[ZTERM],[BUYER],[AD_TLNMBR],[VERKF],[ADRNR_TXT],[REMARK],[STAT],[RECSTS],[ACKSTS] FROM purhdr";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseOrderHeader entity = new PurchaseOrderHeader();
                entity.OrderNumber = rd["EBELN"].ToString();
                entity.SupplierID = rd["LIFNR"].ToString();

                if (rd.IsDBNull(2))
                    entity.OrderDate = null;
                else
                    entity.OrderDate = Convert.ToInt64(rd["BEDAT"]);

                if (rd.IsDBNull(3))
                    entity.OrderAmount = null;
                else
                    entity.OrderAmount = Convert.ToInt64(rd["AMTPR"]);

                if (rd.IsDBNull(3))
                    entity.GstAmount = null;
                else
                    entity.GstAmount = Convert.ToInt64(rd["GSTPR"]);

                
                entity.CurrencyCode = rd["WAERS"].ToString();
                entity.PaymentTerms = rd["ZTERM"].ToString();
                entity.BuyerName = rd["BUYER"].ToString();
                entity.AddressNumber = rd["AD_TLNMBR"].ToString();
                entity.SalesPerson = rd["VERKF"].ToString();
                entity.ShipmentAddress = rd["ADRNR_TXT"].ToString();
                entity.Remarks = rd["REMARK"].ToString();
                entity.OrderStatus = rd["STAT"].ToString();
                entity.RecordStatus = rd["RECSTS"].ToString();
                entity.AcknowledgeStatus = rd["ACKSTS"].ToString();
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

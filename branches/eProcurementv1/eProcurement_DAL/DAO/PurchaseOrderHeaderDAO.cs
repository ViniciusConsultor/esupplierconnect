//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Ma hongyu
// Created Date : 18/09/2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class enables to provide methods for accessing database table [purhdr]  
//       -Insert, Delete Update and Retrieve.
//	  
// Revision History:
//    1.0:
//      Author  : Ma hongyu
//      Date    : 18/09/2009   
//      Comments: Created class 
//    
// Copyright 2008-2010 ISS/Fujitec
//------------------------------------------------------------------------------

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
    ///<summary>Data Access Object - Database table [puitxt]</summary>
    public class PurchaseOrderHeaderDAO : IPurchaseOrderHeaderDAO
    {
        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object
        /// </returns>
        public override Collection<PurchaseOrderHeader> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object 
        /// </returns>
        public override Collection<PurchaseOrderHeader> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object
        /// </returns>
        public override Collection<PurchaseOrderHeader> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object 
        /// </returns>
        public override Collection<PurchaseOrderHeader> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object 
        /// </returns>
        public override Collection<PurchaseOrderHeader> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object 
        /// </returns>
        public override Collection<PurchaseOrderHeader> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object 
        /// </returns>
        public override Collection<PurchaseOrderHeader> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object 
        /// </returns>
        public override Collection<PurchaseOrderHeader> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="orderNumber">Order Number: puitxt.EBELN</param>
        /// <returns>
        /// PurchaseOrderHeader Object
        /// </returns>
        public override PurchaseOrderHeader RetrieveByKey(string orderNumber)
        {
            return RetrieveByKey(null, orderNumber);
        }

        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="orderNumber">Order Number: puitxt.EBELN</param>
        /// <returns>
        /// PurchaseOrderHeader Object
        /// </returns>
        public override PurchaseOrderHeader RetrieveByKey(EpTransaction epTran, string orderNumber)
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
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="PurchaseOrderHeader">PurchaseOrderHeader Object</param>
        public override void Insert(PurchaseOrderHeader entity)
        {
            Insert(null, entity);
        }

        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderHeader">PurchaseOrderHeader Object</param>
        public override void Insert(EpTransaction epTran, PurchaseOrderHeader entity)
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
            cm.CommandText = "INSERT INTO purhdr ([EBELN],[LIFNR],[BEDAT],[AMTPR],[GSTPR],[WAERS],[ZTERM],[BUYER],[AD_TLNMBR],[VERKF],[ADRNR_TXT],[REMARK],[STAT],[RECSTS],[ACKSTS],[ACKBY],[TELPHN]) VALUES(@EBELN,@LIFNR,@BEDAT,@AMTPR,@GSTPR,@WAERS,@ZTERM,@BUYER,@AD_TLNMBR,@VERKF,@ADRNR_TXT,@REMARK,@STAT,@RECSTS,@ACKSTS,@ACKBY,@TELPHN)";
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;
            SqlParameter p2 = new SqlParameter("@LIFNR", SqlDbType.Char, 10);
            cm.Parameters.Add(p2);
            p2.Value = entity.SupplierId;
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
            SqlParameter p16 = new SqlParameter("@ACKBY", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p16);
            p16.Value = entity.AcknowledgeBy;
            SqlParameter p17 = new SqlParameter("@TELPHN", SqlDbType.VarChar, 20);
            cm.Parameters.Add(p17);
            p17.Value = entity.BuyerPhone;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseOrderHeader">PurchaseOrderHeader Object</param>
        public override void Update(PurchaseOrderHeader entity)
        {
            Update(null, entity);
        }

        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderHeader">PurchaseOrderHeader Object</param>
        public override void Update(EpTransaction epTran, PurchaseOrderHeader entity)
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
            cm.CommandText = "UPDATE purhdr SET LIFNR=@LIFNR,BEDAT=@BEDAT,AMTPR=@AMTPR,GSTPR=@GSTPR,WAERS=@WAERS,ZTERM=@ZTERM,BUYER=@BUYER,AD_TLNMBR=@AD_TLNMBR,VERKF=@VERKF,ADRNR_TXT=@ADRNR_TXT,REMARK=@REMARK,STAT=@STAT,RECSTS=@RECSTS,ACKSTS=@ACKSTS,[ACKBY]=@ACKBY,[TELPHN]=@TELPHN WHERE EBELN=@EBELN";
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;
            SqlParameter p2 = new SqlParameter("@LIFNR", SqlDbType.Char, 10);
            cm.Parameters.Add(p2);
            p2.Value = entity.SupplierId;
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
            SqlParameter p16 = new SqlParameter("@ACKBY", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p16);
            p16.Value = entity.AcknowledgeBy;
            SqlParameter p17 = new SqlParameter("@TELPHN", SqlDbType.VarChar, 20);
            cm.Parameters.Add(p17);
            p17.Value = entity.BuyerPhone;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseOrderHeader">PurchaseOrderHeader Object</param>
        public override void Delete(PurchaseOrderHeader entity)
        {
            Delete(null, entity);
        }

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderHeader">PurchaseOrderHeader Object</param>
        public override void Delete(EpTransaction epTran, PurchaseOrderHeader entity)
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
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object 
        /// </returns>
        private  Collection<PurchaseOrderHeader> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
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
            string selectCommand = "SELECT [EBELN],[LIFNR],[BEDAT],[AMTPR],[GSTPR],[WAERS],[ZTERM],[BUYER],[AD_TLNMBR],[VERKF],[ADRNR_TXT],[REMARK],[STAT],[RECSTS],[ACKSTS],[ACKBY],[TELPHN] FROM purhdr";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseOrderHeader entity = new PurchaseOrderHeader();
                entity.OrderNumber = rd["EBELN"].ToString();
                entity.SupplierId = rd["LIFNR"].ToString();

                if (rd.IsDBNull(2))
                    entity.OrderDate = null;
                else
                    entity.OrderDate = Convert.ToInt64(rd["BEDAT"]);

                if (rd.IsDBNull(3))
                    entity.OrderAmount = null;
                else
                    entity.OrderAmount = Convert.ToDecimal(rd["AMTPR"]);

                if (rd.IsDBNull(4))
                    entity.GstAmount = null;
                else
                    entity.GstAmount = Convert.ToDecimal(rd["GSTPR"]);

                
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
                entity.AcknowledgeBy = rd["ACKBY"].ToString();
                entity.BuyerPhone = rd["TELPHN"].ToString();
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

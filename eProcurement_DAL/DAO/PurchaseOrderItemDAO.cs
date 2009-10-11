//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : HNIN
// Created Date : 20/09/2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class enables to provide methods for accessing database table [puitxt]  
//       -Insert, Delete Update and Retrieve.
//	  
// Revision History:
//    1.0:
//      Author  : HNIN
//      Date    : 20/09/2009   
//      Comments: Created class 
//    
// Copyright 2008-2010 ISS/Fujitec
//------------------------------------------------------------------------------

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
    ///<summary>Data Access Object - Database table [PURDTL]</summary> 
    public class PurchaseOrderItemDAO
    {
        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of PurchaseOrderItem Object
        /// </returns>
        public static Collection<PurchaseOrderItem> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }
        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderItem Object 
        /// </returns>
        public static Collection<PurchaseOrderItem> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of PurchaseOrderItem Object
        /// </returns>
        public static Collection<PurchaseOrderItem> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }
        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderItem Object 
        /// </returns>
        public static Collection<PurchaseOrderItem> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderItem Object 
        /// </returns>
        public static Collection<PurchaseOrderItem> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public static Collection<PurchaseOrderItem> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public static Collection<PurchaseOrderItem> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public static Collection<PurchaseOrderItem> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion
        
        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="orderNumber">Order Number: PURDTL.EBELN</param>
        /// <param name="itemSequence">purchase Item Sequence Number : PURDTL.EBELP</param>
        /// <returns>
        /// PurchaseOrderItem Object
        /// </returns>
        public static PurchaseOrderItem RetrieveByKey(string orderNumber, string SequenceNO)
        {
            return RetrieveByKey(null, orderNumber, SequenceNO);
        }
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="orderNumber">Order Number: PURDTL.EBELN</param>
        /// <param name="itemSequence">purchase Item Sequence Number : PURDTL.EBELP</param>
        /// <returns>
        /// PurchaseOrderItem Object
        /// </returns>
        public static PurchaseOrderItem RetrieveByKey(EpTransaction epTran, string orderNumber, string SequenceNO)
        {
            PurchaseOrderItem entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(orderNumber) + "' ";
            whereClause += "AND EBELP='" + DataManager.EscapeSQL(SequenceNO) + "'";
            
            Collection<PurchaseOrderItem> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="PurchaseItemText">PurchaseOrderItem Object</param>
        /// 
        public static void Insert(PurchaseOrderItem entity)
        {
            Insert(null, entity);
        }
        
        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseItemText">PurchaseOrderItem Object</param>
        public static void Insert(EpTransaction epTran, PurchaseOrderItem entity)
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
            PurchaseOrderItem checkEntity = RetrieveByKey(epTran, entity.PurchaseOrderNumber, entity.PurchaseItemSequenceNumber);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO PURDTL ([EBELN],[EBELP],[PSTYP],[MATNR],[TXZ01],[BISMT],[MENGE],[PEINH],[MEINS],[NETPR],[REMARK],[WEMNG],[TEXT80],[AUFNR],[LGORT_D],[ASFNR],[STS2],[RECSTS],[ACKSTS]) VALUES(@EBELN, @EBELP, @PSTYP, @MATNR, @TXZ01,@BISMT, @MENGE, @PEINH, @MEINS , @NETPR, @REMARK, @WEMNG, @TEXT80, @AUFNR, @LGORT_D, @ASFNR, @STS2, @RECSTS, @ACKSTS)";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.PurchaseOrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.PurchaseItemSequenceNumber;

            SqlParameter p3 = new SqlParameter("@PSTYP", SqlDbType.Char, 1);
            cm.Parameters.Add(p3);
            p3.Value = entity.PurchaseOrderType;

            SqlParameter p4 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p4);
            p4.Value = entity.MaterialNumber;

            SqlParameter p5 = new SqlParameter("@TXZ01", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p5);
            p5.Value = entity.ShortText;

            SqlParameter p6 = new SqlParameter("@BISMT", SqlDbType.Char, 18);
            cm.Parameters.Add(p6);
            p6.Value = entity.OldMaterialNumber;

            SqlParameter p7 = new SqlParameter("@MENGE", SqlDbType.Decimal,13);
            cm.Parameters.Add(p7);
            if (entity.OrderQuantity.HasValue)
                p7.Value = entity.OrderQuantity.Value;
            else
                p7.Value = DBNull.Value;

            SqlParameter p8 = new SqlParameter("@PEINH", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p8);
            if (entity.PricePerUnit.HasValue)
                p8.Value = entity.PricePerUnit.Value;
            else
                p7.Value = DBNull.Value;

            SqlParameter p9 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p9);
            p9.Value = entity.UnitofMeasure;

            SqlParameter p10 = new SqlParameter("@NETPR", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p10);
            if (entity.NetPrice.HasValue)
                p10.Value = entity.NetPrice.Value;
            else
                p10.Value = DBNull.Value;            

            SqlParameter p11 = new SqlParameter("@REMARK", SqlDbType.VarChar, 60);
            cm.Parameters.Add(p11);
            p11.Value = entity.Remarks;

            SqlParameter p12 = new SqlParameter("@WEMNG", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p12);
            if (entity.DeliveredQuantity.HasValue)
                p12.Value = entity.DeliveredQuantity.Value;
            else
                p12.Value = DBNull.Value;    

            SqlParameter p13 = new SqlParameter("@TEXT80", SqlDbType.VarChar, 80);
            cm.Parameters.Add(p13);
            p13.Value = entity.LongTextDescription;

            SqlParameter p14 = new SqlParameter("@AUFNR", SqlDbType.VarChar, 12);
            cm.Parameters.Add(p14);
            p14.Value = entity.OrderNumber;

            SqlParameter p15 = new SqlParameter("@LGORT_D", SqlDbType.Char, 4);
            cm.Parameters.Add(p15);
            p15.Value = entity.StorageLocation;

            SqlParameter p16 = new SqlParameter("@ASFNR", SqlDbType.Char, 3);
            cm.Parameters.Add(p16);
            p16.Value = entity.ItemStatus;

            SqlParameter p17 = new SqlParameter("@STS2", SqlDbType.Char, 1);
            cm.Parameters.Add(p17);
            p17.Value = entity.DeletionStatusIndicator;

            SqlParameter p18 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p18);
            p18.Value = entity.RecordStatus;

            SqlParameter p19 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p19);
            p19.Value = entity.RecordStatus;

            SqlParameter p20 = new SqlParameter("@ACKSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p20);
            p20.Value = entity.AcknowledgementStatus;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseItemText">PurchaseOrderItem Object</param>
        public static void Update(PurchaseOrderItem entity)
        {
            Update(null, entity);
        }
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseItemText">PurchaseOrderItem Object</param>
        public static void Update(EpTransaction epTran, PurchaseOrderItem entity)
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
            PurchaseOrderItem checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.PurchaseItemSequenceNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 

            cm.CommandText = "UPDATE PURDTL SET [PSTYP] = @PSTYP, [MATNR] = @MATNR,[TXZ01] = @TXZ01,[BISMT]=@BISMT ,[MENGE] = @MENGE,[PEINH] = @PEINH, [MEINS] = @MEINS ,[NETPR] = @NETPR ,[REMARK] = @REMARK ,[WEMNG] = @WEMNG , [TEXT80] = @TEXT80 ,[AUFNR] = @AUFNR, [LGORT_D] = @LGORT_D ,[ASFNR] = @ASFNR ,[STS2] = @STS2 ,[RECSTS] = @RECSTS ,[ACKSTS] = @ACKSTS  WHERE [EBELN] = @EBELN AND [EBELP] = @EBELP ";

            SqlParameter p1 = new SqlParameter("@PSTYP", SqlDbType.Char, 1);
            cm.Parameters.Add(p1);
            p1.Value = entity.PurchaseOrderType;

            SqlParameter p2 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p2);
            p2.Value = entity.MaterialNumber;

            SqlParameter p3 = new SqlParameter("@TXZ01", SqlDbType.Char, 40);
            cm.Parameters.Add(p3);
            p3.Value = entity.ShortText;

            SqlParameter p4 = new SqlParameter("@BISMT", SqlDbType.Char, 18);
            cm.Parameters.Add(p4);
            p4.Value = entity.OldMaterialNumber;

            SqlParameter p5 = new SqlParameter("@MENGE", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p5);
            if (entity.OrderQuantity.HasValue)
                p5.Value = entity.OrderQuantity.Value;
            else
                p5.Value = DBNull.Value;

            SqlParameter p6 = new SqlParameter("@PEINH", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p6);
            if (entity.PricePerUnit.HasValue)
                p6.Value = entity.PricePerUnit.Value;
            else
                p6.Value = DBNull.Value;

            SqlParameter p7 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p7);
            p7.Value = entity.UnitofMeasure;

            SqlParameter p8 = new SqlParameter("@NETPR", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p8);
            if (entity.NetPrice.HasValue)
                p8.Value = entity.NetPrice.Value;
            else
                p8.Value = DBNull.Value;

            SqlParameter p9 = new SqlParameter("@REMARK", SqlDbType.VarChar, 60);
            cm.Parameters.Add(p9);
            p9.Value = entity.Remarks;

            SqlParameter p10 = new SqlParameter("@WEMNG", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p10);
            if (entity.DeliveredQuantity.HasValue)
                p10.Value = entity.DeliveredQuantity.Value;
            else
                p10.Value = DBNull.Value;

            SqlParameter p11 = new SqlParameter("@TEXT80", SqlDbType.VarChar, 80);
            cm.Parameters.Add(p11);
            p11.Value = entity.LongTextDescription;

            SqlParameter p12 = new SqlParameter("@AUFNR", SqlDbType.VarChar, 12);
            cm.Parameters.Add(p12);
            p12.Value = entity.OrderNumber;

            SqlParameter p13 = new SqlParameter("@LGORT_D", SqlDbType.Char, 4);
            cm.Parameters.Add(p13);
            p13.Value = entity.StorageLocation;

            SqlParameter p14 = new SqlParameter("@ASFNR", SqlDbType.Char, 3);
            cm.Parameters.Add(p14);
            p14.Value = entity.ItemStatus;

            SqlParameter p15 = new SqlParameter("@STS2", SqlDbType.Char, 1);
            cm.Parameters.Add(p15);
            p15.Value = entity.DeletionStatusIndicator;

            SqlParameter p16 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p16);
            p16.Value = entity.RecordStatus;

            SqlParameter p17 = new SqlParameter("@ACKSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p17);
            p17.Value = entity.AcknowledgementStatus;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseItemText">PurchaseOrderItem Object</param>
        public static void Delete(PurchaseOrderItem entity)
        {
            Delete(null, entity);
        }

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseItemText">PurchaseOrderItem Object</param>
        public static void Delete(EpTransaction epTran, PurchaseOrderItem entity)
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
            PurchaseOrderItem checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.PurchaseItemSequenceNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM PURDTL WHERE EBELN=@EBELN AND EBELP=@EBELP";
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;
            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.PurchaseItemSequenceNumber;

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
        /// Collection of PurchaseOrderItem Object 
        /// </returns>
        private static Collection<PurchaseOrderItem> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<PurchaseOrderItem> entities = new Collection<PurchaseOrderItem>();

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
            string selectCommand = "SELECT [EBELN],[EBELP],[PSTYP],[MATNR],[TXZ01],[BISMT],[MENGE],[PEINH],[MEINS],[NETPR],[REMARK],[WEMNG],[TEXT80],[AUFNR],[LGORT_D],[ASFNR],[STS2],[RECSTS],[ACKSTS] FROM purdtl";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseOrderItem entity = new PurchaseOrderItem();
                entity.PurchaseOrderNumber = rd["EBELN"].ToString();
                entity.PurchaseItemSequenceNumber = rd["EBELP"].ToString();
                entity.PurchaseOrderType = rd["PSTYP"].ToString();
                entity.MaterialNumber = rd["MATNR"].ToString();
                entity.ShortText = rd["TXZ01"].ToString();
                entity.OldMaterialNumber = rd["BISMT"].ToString();

                if (rd.IsDBNull(6))
                    entity.OrderQuantity = null;
                else
                    entity.OrderQuantity = Convert.ToDecimal(rd["MENGE"].ToString());

                if (rd.IsDBNull(7))
                    entity.PricePerUnit = null;
                else
                    entity.PricePerUnit = Convert.ToDecimal(rd["PEINH"].ToString());

                entity.UnitofMeasure = rd["MEINS"].ToString();

                if (rd.IsDBNull(8))
                    entity.NetPrice = null;
                else
                    entity.NetPrice = Convert.ToDecimal(rd["NETPR"].ToString());

                entity.Remarks = rd["REMARK"].ToString();

                if (rd.IsDBNull(9))
                    entity.DeliveredQuantity = null;
                else
                    entity.DeliveredQuantity = Convert.ToDecimal(rd["WEMNG"].ToString());

                entity.LongTextDescription = rd["TEXT80"].ToString();
                entity.OrderNumber = rd["AUFNR"].ToString();
                entity.StorageLocation = rd["LGORT_D"].ToString();
                entity.ItemStatus = rd["ASFNR"].ToString();
                entity.DeletionStatusIndicator = rd["STS2"].ToString();
                entity.RecordStatus = rd["RECSTS"].ToString();
                entity.AcknowledgementStatus = rd["ACKSTS"].ToString();

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

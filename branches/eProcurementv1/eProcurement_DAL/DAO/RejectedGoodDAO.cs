//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Ei Ei Thu
// Created Date : 19/09/2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class enables to provide methods for accessing database table [rejection]  
//       -Insert, Delete Update and Retrieve.
//	  
// Revision History:
//    1.0:
//      Author  : Ei Ei Thu
//      Date    : 19/09/2009   
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
    ///<summary>Data Access Object - Database table [rejection]</summary>
    class RejectedGoodDAO : IRejectedGoodDAO
    {
        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of RejectedGood Object
        /// </returns>
        public override Collection<RejectedGood> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of RejectedGood Object 
        /// </returns>
        public override Collection<RejectedGood> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of RejectedGood Object
        /// </returns>
        public override Collection<RejectedGood> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of RejectedGood Object 
        /// </returns>
        public override Collection<RejectedGood> RetrieveAll(EpTransaction epTran, string sortClaues)
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
        /// Collection of RejectedGood Object 
        /// </returns>
        public override Collection<RejectedGood> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of RejectedGood Object 
        /// </returns>
        public override Collection<RejectedGood> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of RejectedGood Object 
        /// </returns>
        public override Collection<RejectedGood> RetrieveByQuery(EpTransaction epTran, string whereClause)
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
        /// Collection of RejectedGood Object 
        /// </returns>
        public override Collection<RejectedGood> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="orderNumber">Order Number: rejection.EBELN</param>
        /// <returns>
        /// RejectedGood Object
        /// </returns>
        public override RejectedGood RetrieveByKey(string orderNumber, string itemSequence, string documentNumber)
        {
            return RetrieveByKey(null, orderNumber,itemSequence,documentNumber);
        }

        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="orderNumber">Order Number: rejection.EBELN</param>
        /// <returns>
        /// RejectedGood Object
        /// </returns>
        public override RejectedGood RetrieveByKey(EpTransaction epTran, string orderNumber, string itemSequence, string documentNumber)
        {
            RejectedGood entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(orderNumber) + "' ";
            whereClause += "AND EBELP='" + DataManager.EscapeSQL(itemSequence) + "'";
            whereClause += "AND DOCNO='" + DataManager.EscapeSQL(documentNumber) + "'";

            Collection<RejectedGood> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
         #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="RejectedGood">RejectedGood Object</param>
        /// 
        public override void Insert(RejectedGood entity)
        {
            Insert(null, entity);
        }

        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="Rejection">RejectedGood Object</param>
        public override void Insert(EpTransaction epTran, RejectedGood entity)
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
            RejectedGood checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.DocumentNumber);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO REJECTION ([EBELN],[EBELP],[DOCNO],[ITEMNO],[MATNR],[TRNQTY],[MEINS],[REFNO],[AEDAT],[ACKSTS]) VALUES(@EBELN, @EBELP, @DOCNO, @ITEMNO, @MATNR,@TRNQTY, @MEINS, @REFNO, @AEDAT , @ACKSTS)";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;

            SqlParameter p3 = new SqlParameter("@DOCNO", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.DocumentNumber;

            SqlParameter p4 = new SqlParameter("@ITEMNO", SqlDbType.Char, 5);
            cm.Parameters.Add(p4);
            p4.Value = entity.DocumentSerial;

            SqlParameter p5 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p5);
            p5.Value = entity.MaterialNumber;

            SqlParameter p6 = new SqlParameter("@TRNQTY", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p6);
            if (entity.RejectQuantity.HasValue)
                p6.Value = entity.RejectQuantity.Value;
            else
                p6.Value = DBNull.Value;        

            SqlParameter p7 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p7);
            p7.Value = entity.UnitofMeasure;

            SqlParameter p8 = new SqlParameter("@REFNO", SqlDbType.Char, 10);
            cm.Parameters.Add(p8);
            p8.Value = entity.ReferenceNumber;

            SqlParameter p9 = new SqlParameter("@AEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p9);
            if (entity.RejectDate.HasValue)
                p9.Value = entity.RejectDate;
            else
                p9.Value = DBNull.Value;

            SqlParameter p10 = new SqlParameter("@ACKSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p10);
            p10.Value = entity.AcknowledgeStatus;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="Rejection">RejectedGood Object</param>
        public override void Update(RejectedGood entity)
        {
            Update(null, entity);
        }
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="Rejection">RejectedGood Object</param>
        public override void Update(EpTransaction epTran, RejectedGood entity)
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
            RejectedGood checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence,entity.DocumentNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 

            cm.CommandText = "UPDATE REJECTION SET [ITEMNO] = @ITEMNO, [MATNR] = @MATNR,[TRNQTY] = @TRNQTY,[MEINS]=@MEINS ,[REFNO] = @REFNO,[AEDAT] = @AEDAT, [ACKSTS] = @ACKSTS  WHERE [EBELN] = @EBELN AND [EBELP] = @EBELP AND [DOCNO]=@DOCNO";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;

            SqlParameter p3 = new SqlParameter("@DOCNO", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.DocumentNumber;

            SqlParameter p4 = new SqlParameter("@ITEMNO", SqlDbType.Char, 5);
            cm.Parameters.Add(p4);
            p4.Value = entity.DocumentSerial;

            SqlParameter p5 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p5);
            p5.Value = entity.MaterialNumber;

            SqlParameter p6 = new SqlParameter("@TRNQTY", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p6);
            if (entity.RejectQuantity.HasValue)
                p6.Value = entity.RejectQuantity.Value;
            else
                p6.Value = DBNull.Value;

            SqlParameter p7 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p7);
            p7.Value = entity.UnitofMeasure;

            SqlParameter p8 = new SqlParameter("@REFNO", SqlDbType.Char, 10);
            cm.Parameters.Add(p8);
            p8.Value = entity.ReferenceNumber;

            SqlParameter p9 = new SqlParameter("@AEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p9);
            if (entity.RejectDate.HasValue)
                p9.Value = entity.RejectDate;
            else
                p9.Value = DBNull.Value;

            SqlParameter p10 = new SqlParameter("@ACKSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p10);
            p10.Value = entity.AcknowledgeStatus;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="Rejection">RejectedGood Object</param>
        public override void Delete(RejectedGood entity)
        {
            Delete(null, entity);
        }

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="Rejection">RejectedGood Object</param>
        public override void Delete(EpTransaction epTran, RejectedGood entity)
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
            RejectedGood checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.DocumentNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM REJECTION WHERE EBELN=@EBELN AND EBELP=@EBELP AND DOCNO=@DOCNO";
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
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of RejectedGood Object 
        /// </returns>
        private Collection<RejectedGood> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<RejectedGood> entities = new Collection<PurchaseOrderItem>();

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
            string selectCommand = "SELECT [EBELN],[EBELP],[DOCNO],[ITEMNO],[MATNR],[TRNQTY],[MEINS],[REFNO],[AEDAT],[ACKSTS] FROM rejection";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                RejectedGood entity = new RejectedGood();
                entity.OrderNumber = rd["EBELN"].ToString();
                entity.ItemSequence = rd["EBELP"].ToString();
                entity.DocumentNumber = rd["DOCNO"].ToString();
                entity.DocumentSerial = rd["ITEMNO"].ToString();
                entity.MaterialNumber = rd["MATNR"].ToString();
               
                if (rd.IsDBNull(5))
                    entity.RejectQuantity = null;
                else
                    entity.RejectQuantity = Convert.ToDecimal(rd["TRNQTY"].ToString());

                entity.UnitofMeasure = rd["MEINS"].ToString();
                entity.ReferenceNumber = rd["REFNO"].ToString();

                if (rd.IsDBNull(8))
                    entity.RejectDate = null;
                else
                    entity.RejectDate = Convert.ToInt64(rd["AEDAT"]);
                
                entity.AcknowledgeStatus  = rd["ACKSTS"].ToString();

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

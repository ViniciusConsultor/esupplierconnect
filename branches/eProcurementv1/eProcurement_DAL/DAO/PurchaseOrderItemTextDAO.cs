//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Ma hongyu
// Created Date : 18/09/2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class enables to provide methods for accessing database table [puitxt]  
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
using System.Collections.ObjectModel;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace eProcurement_DAL
{
    ///<summary>Data Access Object - Database table [puitxt]</summary>
    public class PurchaseOrderItemTextDAO
    {
        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of PurchaseOrderItemText Object
        /// </returns>
        public static Collection<PurchaseOrderItemText> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderItemText Object 
        /// </returns>
        public static Collection<PurchaseOrderItemText> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of PurchaseOrderItemText Object
        /// </returns>
        public static Collection<PurchaseOrderItemText> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderItemText Object 
        /// </returns>
        public static Collection<PurchaseOrderItemText> RetrieveAll(EpTransaction epTran, string sortClaues)
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
        /// Collection of PurchaseOrderItemText Object 
        /// </returns>
        public static Collection<PurchaseOrderItemText> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderItemText Object 
        /// </returns>
        public static Collection<PurchaseOrderItemText> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderItemText Object 
        /// </returns>
        public static Collection<PurchaseOrderItemText> RetrieveByQuery(EpTransaction epTran, string whereClause)
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
        /// Collection of PurchaseOrderItemText Object 
        /// </returns>
        public static Collection<PurchaseOrderItemText> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="orderNumber">Order Number: puitxt.EBELN</param>
        /// <param name="itemSequenceNumber">Item Sequence: puitxt.EBELP</param>
        /// <param name="textSerialNumber">Text Sequence: puitxt.TXTITM</param>
        /// <returns>
        /// PurchaseOrderItemText Object
        /// </returns>
        public static PurchaseOrderItemText RetrieveByKey(string orderNumber, string itemSequenceNumber, string textSerialNumber)
        {
            return RetrieveByKey(null, orderNumber,itemSequenceNumber,textSerialNumber);
        }

        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="orderNumber">Order Number: puitxt.EBELN</param>
        /// <param name="itemSequenceNumber">Item Sequence: puitxt.EBELP</param>
        /// <param name="textSerialNumber">Text Sequence: puitxt.TXTITM</param>
        /// <returns>
        /// PurchaseOrderItemText Object
        /// </returns>
        public static PurchaseOrderItemText RetrieveByKey(EpTransaction epTran, string orderNumber, string itemSequenceNumber, string textSerialNumber)
        {
            PurchaseOrderItemText entity =null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(orderNumber) + "' ";
            whereClause += "AND EBELP='" + DataManager.EscapeSQL(itemSequenceNumber) + "' ";
            whereClause += "AND TXTITM='" + DataManager.EscapeSQL(textSerialNumber) + "'";

            Collection<PurchaseOrderItemText> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="PurchaseOrderItemText">PurchaseOrderItemText Object</param>
        public static void Insert(PurchaseOrderItemText entity)
        {
            Insert(null, entity);
        }

        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderItemText">PurchaseOrderItemText Object</param>
        public static void Insert(EpTransaction epTran, PurchaseOrderItemText entity)
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
            PurchaseOrderItemText checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequenceNumber, entity.TextSerialNumber);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO puitxt ([EBELN],[EBELP],[TXTITM],[LTXT],[RECSTS]) VALUES(@EBELN,@EBELP,@TXTITM,@LTXT,@RECSTS)";
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
            SqlParameter p5 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p5);
            p5.Value = entity.ItemSequenceNumber;
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseOrderItemText">PurchaseOrderItemText Object</param>
        public static void Update(PurchaseOrderItemText entity)
        {
            Update(null, entity);
        }

        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderItemText">PurchaseOrderItemText Object</param>
        public static void Update(EpTransaction epTran, PurchaseOrderItemText entity)
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
            PurchaseOrderItemText checkEntity = RetrieveByKey(epTran, entity.OrderNumber,entity.ItemSequenceNumber,entity.TextSerialNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE puitxt SET LTXT=@LTXT,RECSTS=@RECSTS WHERE EBELN=@EBELN AND EBELP=@EBELP AND TXTITM=@TXTITM";
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
            SqlParameter p5 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p5);
            p5.Value = entity.ItemSequenceNumber;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseOrderItemText">PurchaseOrderItemText Object</param>
        public static void Delete(PurchaseOrderItemText entity)
        {
            Delete(null, entity);
        }

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderItemText">PurchaseOrderItemText Object</param>
        public static void Delete(EpTransaction epTran, PurchaseOrderItemText entity)
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
            PurchaseOrderItemText checkEntity = RetrieveByKey(epTran, entity.OrderNumber,entity.ItemSequenceNumber,entity.TextSerialNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM puitxt WHERE EBELN=@EBELN AND EBELP=@EBELP AND TXTITM=@TXTITM";
            SqlParameter p3 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.OrderNumber;
            SqlParameter p4 = new SqlParameter("@TXTITM", SqlDbType.Char, 5);
            cm.Parameters.Add(p4);
            p4.Value = entity.TextSerialNumber;
            SqlParameter p5 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p5);
            p5.Value = entity.ItemSequenceNumber;

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
        /// Collection of PurchaseOrderItemText Object 
        /// </returns>
        private static Collection<PurchaseOrderItemText> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<PurchaseOrderItemText> entities = new Collection<PurchaseOrderItemText>();

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
            string selectCommand = "SELECT [EBELN],[EBELP],[TXTITM],[LTXT],[RECSTS] FROM puitxt";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseOrderItemText entity = new PurchaseOrderItemText();
                entity.OrderNumber = rd["EBELN"].ToString();
                entity.ItemSequenceNumber = rd["EBELP"].ToString();
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

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
    public class PurchaseItemTextDAO : IPurchaseItemTextDAO
    {
        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of PurchaseItemText Object
        /// </returns>
        public override Collection<PurchaseItemText> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseItemText Object 
        /// </returns>
        public override Collection<PurchaseItemText> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of PurchaseItemText Object
        /// </returns>
        public override Collection<PurchaseItemText> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseItemText Object 
        /// </returns>
        public override Collection<PurchaseItemText> RetrieveAll(EpTransaction epTran, string sortClaues)
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
        /// Collection of PurchaseItemText Object 
        /// </returns>
        public override Collection<PurchaseItemText> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseItemText Object 
        /// </returns>
        public override Collection<PurchaseItemText> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of PurchaseItemText Object 
        /// </returns>
        public override Collection<PurchaseItemText> RetrieveByQuery(EpTransaction epTran, string whereClause)
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
        /// Collection of PurchaseItemText Object 
        /// </returns>
        public override Collection<PurchaseItemText> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="orderNumber">Order Number: puitxt.EBELN</param>
        /// <param name="itemSequence">Item Sequence: puitxt.EBELP</param>
        /// <param name="textSequence">Text Sequence: puitxt.TXTITM</param>
        /// <returns>
        /// PurchaseItemText Object
        /// </returns>
        public override PurchaseItemText RetrieveByKey(string orderNumber, string itemSequence, string textSequence)
        {
            return RetrieveByKey(null, orderNumber, itemSequence, textSequence);
        }

        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="orderNumber">Order Number: puitxt.EBELN</param>
        /// <param name="itemSequence">Item Sequence: puitxt.EBELP</param>
        /// <param name="textSequence">Text Sequence: puitxt.TXTITM</param>
        /// <returns>
        /// PurchaseItemText Object
        /// </returns>
        public override PurchaseItemText RetrieveByKey(EpTransaction epTran, string orderNumber, string itemSequence, string textSequence)
        {
            PurchaseItemText entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(orderNumber) + "' ";
            whereClause += "AND EBELP='" + DataManager.EscapeSQL(itemSequence) + "' ";
            whereClause += "AND TXTITM='" + DataManager.EscapeSQL(textSequence) + "'";

            Collection<PurchaseItemText> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="PurchaseItemText">PurchaseItemText Object</param>
        public override void Insert(PurchaseItemText entity)
        {
            Insert(null, entity);
        }

        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseItemText">PurchaseItemText Object</param>
        public override void Insert(EpTransaction epTran, PurchaseItemText entity)
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
            PurchaseItemText checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.TextSequence);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO puitxt ([EBELN],[EBELP],[TXTITM],[LTXT]) VALUES(@EBELN,@EBELP,@TXTITM,@LTXT)";
            SqlParameter p1 = new SqlParameter("@LTXT", SqlDbType.NVarChar, 255);
            cm.Parameters.Add(p1);
            p1.Value = entity.LongText;
            SqlParameter p3 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.OrderNumber;
            SqlParameter p4 = new SqlParameter("@TXTITM", SqlDbType.Char, 5);
            cm.Parameters.Add(p4);
            p4.Value = entity.TextSequence;
            SqlParameter p5 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p5);
            p5.Value = entity.ItemSequence;
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseItemText">PurchaseItemText Object</param>
        public override void Update(PurchaseItemText entity)
        {
            Update(null, entity);
        }

        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseItemText">PurchaseItemText Object</param>
        public override void Update(EpTransaction epTran, PurchaseItemText entity)
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
            PurchaseItemText checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.TextSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE puitxt SET LTXT=@LTXT,WHERE EBELN=@EBELN AND EBELP=@EBELP AND TXTITM=@TXTITM";
            SqlParameter p1 = new SqlParameter("@LTXT", SqlDbType.NVarChar, 255);
            cm.Parameters.Add(p1);
            p1.Value = entity.LongText;
            SqlParameter p3 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.OrderNumber;
            SqlParameter p4 = new SqlParameter("@TXTITM", SqlDbType.Char, 5);
            cm.Parameters.Add(p4);
            p4.Value = entity.TextSequence;
            SqlParameter p5 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p5);
            p5.Value = entity.ItemSequence;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseItemText">PurchaseItemText Object</param>
        public override void Delete(PurchaseItemText entity)
        {
            Delete(null, entity);
        }

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseItemText">PurchaseItemText Object</param>
        public override void Delete(EpTransaction epTran, PurchaseItemText entity)
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
            PurchaseItemText checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.TextSequence);
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
            p4.Value = entity.TextSequence;
            SqlParameter p5 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p5);
            p5.Value = entity.ItemSequence;

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
        /// Collection of PurchaseItemText Object 
        /// </returns>
        private  Collection<PurchaseItemText> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<PurchaseItemText> entities = new Collection<PurchaseItemText>();

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
            string selectCommand = "SELECT [EBELN],[EBELP],[TXTITM],[LTXT] FROM puitxt";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseItemText entity = new PurchaseItemText();
                entity.OrderNumber = rd["EBELN"].ToString();
                entity.ItemSequence = rd["EBELP"].ToString();
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

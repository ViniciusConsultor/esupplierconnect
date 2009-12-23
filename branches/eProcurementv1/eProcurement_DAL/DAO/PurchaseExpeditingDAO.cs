//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Ma hongyu
// Created Date : 18/09/2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class enables to provide methods for accessing database table [purexpedite]  
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
    ///<summary>Data Access Object - Database table [purexpedite]</summary>
    public class PurchaseExpeditingDAO : IPurchaseExpeditingDAO
    {
        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of PurchaseExpediting Object
        /// </returns>
        public override Collection<PurchaseExpediting> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseExpediting Object 
        /// </returns>
        public override Collection<PurchaseExpediting> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of PurchaseExpediting Object
        /// </returns>
        public override Collection<PurchaseExpediting> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseExpediting Object 
        /// </returns>
        public override Collection<PurchaseExpediting> RetrieveAll(EpTransaction epTran, string sortClaues)
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
        /// Collection of PurchaseExpediting Object 
        /// </returns>
        public override Collection<PurchaseExpediting> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseExpediting Object 
        /// </returns>
        public override Collection<PurchaseExpediting> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of PurchaseExpediting Object 
        /// </returns>
        public override Collection<PurchaseExpediting> RetrieveByQuery(EpTransaction epTran, string whereClause)
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
        /// Collection of PurchaseExpediting Object 
        /// </returns>
        public override Collection<PurchaseExpediting> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
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
        /// PurchaseExpediting Object
        /// </returns>
        public override PurchaseExpediting RetrieveByKey(string orderNumber, string itemSequence, string scheduleSequence)
        {
            return RetrieveByKey(null, orderNumber, itemSequence, scheduleSequence);
        }

        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="orderNumber">Order Number: puitxt.EBELN</param>
        /// <returns>
        /// PurchaseExpediting Object
        /// </returns>
        public override PurchaseExpediting RetrieveByKey(EpTransaction epTran, string orderNumber, string itemSequence, string scheduleSequence)
        {
            PurchaseExpediting entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(orderNumber) + "' ";
            whereClause += "AND EBELP='" + DataManager.EscapeSQL(itemSequence) + "' ";
            whereClause += "AND ETENR='" + DataManager.EscapeSQL(scheduleSequence) + "'";

            Collection<PurchaseExpediting> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="PurchaseExpediting">PurchaseExpediting Object</param>
        public override void Insert(PurchaseExpediting entity)
        {
            Insert(null, entity);
        }

        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseExpediting">PurchaseExpediting Object</param>
        public override void Insert(EpTransaction epTran, PurchaseExpediting entity)
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
            PurchaseExpediting checkEntity = RetrieveByKey(epTran, entity.OrderNumber,entity.ItemSequence,entity.ScheduleSequence);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO purexpedite ([EBELN],[EBELP],[ETENR],[MATNR],[EXPDT],[WEMNG],[VBELN],[PRMDT1],[PRMDT2],[RECSTS]) VALUES(@EBELN,@EBELP,@ETENR,@MATNR,@EXPDT,@WEMNG,@VBELN,@PRMDT1,@PRMDT2,@RECSTS])";
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;

            SqlParameter p3 = new SqlParameter("@ETENR", SqlDbType.Char, 4);
            cm.Parameters.Add(p3);
            p3.Value = entity.ScheduleSequence;

            SqlParameter p4 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p4);
            p4.Value = entity.MaterialNumber;

            SqlParameter p5 = new SqlParameter("@EXPDT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p5);
            if (entity.ExpeditDate.HasValue)
                p5.Value = entity.ExpeditDate;
            else
                p5.Value = DBNull.Value;

            SqlParameter p6 = new SqlParameter("@WEMNG", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p6);
            if (entity.ExpediteQuantity.HasValue)
                p6.Value = entity.ExpediteQuantity;
            else
                p6.Value = DBNull.Value;

            SqlParameter p7 = new SqlParameter("@VBELN", SqlDbType.Char, 3);
            cm.Parameters.Add(p7);
            p7.Value = entity.UnitMeasure;

            SqlParameter p8 = new SqlParameter("@PRMDT1", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p8);
            if (entity.PromiseDate1.HasValue)
                p8.Value = entity.PromiseDate1;
            else
                p8.Value = DBNull.Value;

            SqlParameter p9 = new SqlParameter("@PRMDT2", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p9);
            if (entity.PromiseDate2.HasValue)
                p9.Value = entity.PromiseDate2;
            else
                p9.Value = DBNull.Value;

            SqlParameter p10 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p10);
            p10.Value = entity.RecordStatus;
          
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseExpediting">PurchaseExpediting Object</param>
        public override void Update(PurchaseExpediting entity)
        {
            Update(null, entity);
        }

        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseExpediting">PurchaseExpediting Object</param>
        public override void Update(EpTransaction epTran, PurchaseExpediting entity)
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
            PurchaseExpediting checkEntity = RetrieveByKey(epTran, entity.OrderNumber,entity.ItemSequence,entity.ScheduleSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE purexpedite SET MATNR=@MATNR,EXPDT=@EXPDT,WEMNG=@WEMNG,VBELN=@VBELN,PRMDT1=@PRMDT1,PRMDT2=@PRMDT2,RECSTS=@RECSTS WHERE EBELN=@EBELN AND EBELP=@EBELP AND ETENR=@ETENR";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;

            SqlParameter p3 = new SqlParameter("@ETENR", SqlDbType.Char, 4);
            cm.Parameters.Add(p3);
            p3.Value = entity.ScheduleSequence;

            SqlParameter p4 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p4);
            p4.Value = entity.MaterialNumber;

            SqlParameter p5 = new SqlParameter("@EXPDT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p5);
            if (entity.ExpeditDate.HasValue)
                p5.Value = entity.ExpeditDate;
            else
                p5.Value = DBNull.Value;

            SqlParameter p6 = new SqlParameter("@WEMNG", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p6);
            if (entity.ExpediteQuantity.HasValue)
                p6.Value = entity.ExpediteQuantity;
            else
                p6.Value = DBNull.Value;

            SqlParameter p7 = new SqlParameter("@VBELN", SqlDbType.Char, 3);
            cm.Parameters.Add(p7);
            p7.Value = entity.UnitMeasure;

            SqlParameter p8 = new SqlParameter("@PRMDT1", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p8);
            if (entity.PromiseDate1.HasValue)
                p8.Value = entity.PromiseDate1;
            else
                p8.Value = DBNull.Value;

            SqlParameter p9 = new SqlParameter("@PRMDT2", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p9);
            if (entity.PromiseDate2.HasValue)
                p9.Value = entity.PromiseDate2;
            else
                p9.Value = DBNull.Value;

            SqlParameter p10 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p10);
            p10.Value = entity.RecordStatus;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseExpediting">PurchaseExpediting Object</param>
        public override void Delete(PurchaseExpediting entity)
        {
            Delete(null, entity);
        }

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseExpediting">PurchaseExpediting Object</param>
        public override void Delete(EpTransaction epTran, PurchaseExpediting entity)
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
            PurchaseExpediting checkEntity = RetrieveByKey(epTran, entity.OrderNumber,entity.ItemSequence, entity.ScheduleSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM purexpedite WHERE EBELN=@EBELN AND EBELP=@EBELP AND ETENR=@ETENR";
            
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;

            SqlParameter p3 = new SqlParameter("@ETENR", SqlDbType.Char, 4);
            cm.Parameters.Add(p3);
            p3.Value = entity.ScheduleSequence;

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
        /// Collection of PurchaseExpediting Object 
        /// </returns>
        private  Collection<PurchaseExpediting> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<PurchaseExpediting> entities = new Collection<PurchaseExpediting>();

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
            string selectCommand = "SELECT [EBELN],[EBELP],[ETENR],[MATNR],[EXPDT],[WEMNG],[VBELN],[PRMDT1],[PRMDT2],[RECSTS] FROM purexpedite";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseExpediting entity = new PurchaseExpediting();
                entity.OrderNumber = rd["EBELN"].ToString();
                entity.ItemSequence = rd["EBELP"].ToString();
                entity.ScheduleSequence = rd["ETENR"].ToString();
                entity.MaterialNumber = rd["MATNR"].ToString();

                if (rd.IsDBNull(4))
                    entity.ExpeditDate = null;
                else
                    entity.ExpeditDate = Convert.ToInt64(rd["EXPDT"]);

                if (rd.IsDBNull(5))
                    entity.ExpediteQuantity = null;
                else
                    entity.ExpediteQuantity = Convert.ToDecimal(rd["AMTPR"]);

                entity.UnitMeasure = rd["VBELN"].ToString();

                if (rd.IsDBNull(7))
                    entity.PromiseDate1 = null;
                else
                    entity.PromiseDate1 = Convert.ToInt64(rd["PRMDT1"]);

                if (rd.IsDBNull(8))
                    entity.PromiseDate2 = null;
                else
                    entity.PromiseDate2 = Convert.ToInt64(rd["PRMDT2"]);

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

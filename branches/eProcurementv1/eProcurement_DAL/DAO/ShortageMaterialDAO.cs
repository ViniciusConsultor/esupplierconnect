//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Vinss, Rajendran Vinoth Prabu
// Created Date : 11 Oct 2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class enables to provide methods for accessing database table [mtlstock]  
//       -Insert, Delete Update and Retrieve.
//	  
// Revision History:
//    1.0:
//      Author  : Vinss
//      Date    : 11 Oct 2009
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

namespace eProcurement_DAL.DAO
{
     ///<summary>Data Access Object - Database table [mtlshortage]</summary>
    public class ShortageMaterialDAO : IShortageMaterialDAO
    {

        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of Shortage Material Object
        /// </returns>
        public override Collection<ShortageMaterial> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Shortage Materail Object 
        /// </returns>
        public override Collection<ShortageMaterial> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of Shortage Material Object
        /// </returns>
        public override Collection<ShortageMaterial> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Shortage Material Object 
        /// </returns>
        public override Collection<ShortageMaterial> RetrieveAll(EpTransaction epTran, string sortClaues)
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
        /// Collection of Shortage Material Object 
        /// </returns>
        public override Collection<ShortageMaterial> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Shortage Material Object 
        /// </returns>
        public override Collection<ShortageMaterial> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of Shortage Material Object 
        /// </returns>
        public override Collection<ShortageMaterial> RetrieveByQuery(EpTransaction epTran, string whereClause)
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
        /// Collection of Shortage Material Object 
        /// </returns>
        public override Collection<ShortageMaterial> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="materialNumber">Material Number: mtlshortage.MATNR</param>
        /// <returns>
        /// Shortage Material Object
        /// </returns>
        public override ShortageMaterial RetrieveByKey(string materialNumber)
        {
            return RetrieveByKey(null, materialNumber);
        }

        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="materialNumber">Material Number: mtlstock.MATNR</param>
        /// <returns>
        /// Shortage Material Object
        /// </returns>
        public override ShortageMaterial RetrieveByKey(EpTransaction epTran, string materialNumber)
        {
            ShortageMaterial entity = null;
            string whereClause = " MATNR='" + DataManager.EscapeSQL(materialNumber) + "' ";
            
            Collection<ShortageMaterial> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="ShortageMaterial">Shortage Material Object</param>
        public override void Insert(ShortageMaterial entity)
        {
            Insert(null, entity);
        }

        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="ShortageMaterial">Shortage Material</param>
        public override void Insert(EpTransaction epTran, ShortageMaterial entity)
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
            ShortageMaterial checkEntity = RetrieveByKey(epTran, entity.MaterialNumber);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO mtlshortage ([MATNR],[WERKS],[MENGE]) VALUES(@MATNR,@WERKS,@MENGE)";
            SqlParameter p1 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p1);
            p1.Value = entity.MaterialNumber;

            SqlParameter p2 = new SqlParameter("@WERKS", SqlDbType.Char, 4);
            cm.Parameters.Add(p2);
            p2.Value = entity.Plant;

            SqlParameter p3 = new SqlParameter("@MENGE", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p3);
            if (entity.ShortageQuantity.HasValue)
                p3.Value = entity.ShortageQuantity;
            else
                p3.Value = DBNull.Value;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="Shortage Material">Shortage Material Object</param>
        public override void Update(ShortageMaterial entity)
        {
            Update(null, entity);
        }

        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="ShortageMaterial">ShortageMaterial Object</param>
        public override void Update(EpTransaction epTran, ShortageMaterial entity)
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
            ShortageMaterial checkEntity = RetrieveByKey(epTran, entity.MaterialNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE mtlshortage WERKS=@WERKS,MENGE=@MENGE WHERE MATNR=@MATNR";

            SqlParameter p1 = new SqlParameter("@WERKS", SqlDbType.Char, 4);
            cm.Parameters.Add(p1);
            p1.Value = entity.Plant;

            SqlParameter p2 = new SqlParameter("@MENGE", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p2);
            if (entity.ShortageQuantity.HasValue)
                p2.Value = entity.ShortageQuantity;
            else
                p2.Value = DBNull.Value;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="ShortageMaterial">Shortage Material Object</param>
        public override void Delete(ShortageMaterial entity)
        {
            Delete(null, entity);
        }

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="ShortageMAterial">Shortage Material Object</param>
        public override void Delete(EpTransaction epTran, ShortageMaterial entity)
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
            ShortageMaterial checkEntity = RetrieveByKey(epTran, entity.MaterialNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM mtlshortage WHERE MATNR=@MATNR";
            SqlParameter p1 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p1);
            p1.Value = entity.MaterialNumber;            

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
        /// Collection of Shortage Material Object 
        /// </returns>
        private static Collection<ShortageMaterial> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<ShortageMaterial> entities = new Collection<ShortageMaterial>();

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
            string selectCommand = "SELECT [MATNR],[WERKS],[MENGE] FROM mtlshortage";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                ShortageMaterial entity = new ShortageMaterial();
                entity.MaterialNumber = rd["MATNR"].ToString();
                entity.Plant = rd["WERKS"].ToString();

             

                if (rd.IsDBNull(2))
                    entity.ShortageQuantity = null;
                else
                    entity.ShortageQuantity = Convert.ToDecimal(rd["MENGE"].ToString());

               

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

//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Vinss, Rajendran Vinoth Prabu
// Created Date : 11 Oct 2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class enables to provide methods for accessing database table [mtlshortage]  
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

namespace eProcurement_DAL
{
    ///<summary>Data Access Object - Database table [mtlstock]</summary>
    public class MaterialStockDAO : IMaterialStockDAO
    {

        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of Material Stock Object
        /// </returns>
        public override Collection<MaterialStock> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Materail Stock Object 
        /// </returns>
        public override Collection<MaterialStock> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of Material Stock Object
        /// </returns>
        public override Collection<MaterialStock> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Material Stock Object 
        /// </returns>
        public override Collection<MaterialStock> RetrieveAll(EpTransaction epTran, string sortClaues)
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
        /// Collection of Material Stock Object 
        /// </returns>
        public override Collection<MaterialStock> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Material Stock Object 
        /// </returns>
        public override Collection<MaterialStock> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of Material Stock Object 
        /// </returns>
        public override Collection<MaterialStock> RetrieveByQuery(EpTransaction epTran, string whereClause)
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
        /// Collection of Material Stock Object 
        /// </returns>
        public override Collection<MaterialStock> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="materialNumber">Material Number: mtlstock.MATNR</param>
        /// <param name="plant">Plant : mtlstock.WERKS</param>
        /// <returns>
        /// Material Stock Object
        /// </returns>
        public override MaterialStock RetrieveByKey(string materialNumber,string plant)
        {
            return RetrieveByKey(null, materialNumber, plant);
        }

        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="materialNumber">Material Number: mtlstock.MATNR</param>
        /// <param name="plant">Plant : mtlstock.WERKS</param>
        /// <returns>
        /// Material Stock Object
        /// </returns>
        public override MaterialStock RetrieveByKey(EpTransaction epTran, string materialNumber,string plant)
        {
            MaterialStock entity = null;
            string whereClause = " MATNR='" + DataManager.EscapeSQL(materialNumber) + "' ";
            whereClause += "AND WERKS='" + DataManager.EscapeSQL(plant) + "' ";

            Collection<MaterialStock> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="materialStock">Material Stock Object</param>
        public override void Insert(MaterialStock entity)
        {
            Insert(null, entity);
        }

        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="MaterialStock">Material Stock Object</param>
        public override void Insert(EpTransaction epTran, MaterialStock entity)
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
            MaterialStock checkEntity = RetrieveByKey(epTran, entity.MaterialNumber,entity.Plant);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO mtlstock ([MATNR],[WERKS],[MAKTX],[LABST],[QINSP],[MEINS]) VALUES(@MATNR,@WERKS,@MAKTX,@LABST,@QINSP,@MEINS)";
            SqlParameter p1 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p1);
            p1.Value = entity.MaterialNumber;

            SqlParameter p2 = new SqlParameter("@WERKS", SqlDbType.Char, 4);
            cm.Parameters.Add(p2);
            p2.Value = entity.Plant;

            SqlParameter p3 = new SqlParameter("@MAKTX", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p3);
            p3.Value = entity.MaterialDescription;

            SqlParameter p4 = new SqlParameter("@LABST", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p4);
            if (entity.UnrestrictedStock.HasValue)
            p4.Value = entity.UnrestrictedStock;
            else
            p4.Value = DBNull.Value;

            SqlParameter p5 = new SqlParameter("@QINSP", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p5);
            if(entity.InspectionStock.HasValue)
            p5.Value = entity.InspectionStock;
            else
            p5.Value=DBNull.Value;

            SqlParameter p6 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p6);
            p6.Value = entity.UnitOfMeasure;

               
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="MaterialStock">Material Stock Object</param>
        public override void Update(MaterialStock entity)
        {
            Update(null, entity);
        }

        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="MaterialStock">MaterialStock Object</param>
        public override void Update(EpTransaction epTran, MaterialStock entity)
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
            MaterialStock checkEntity = RetrieveByKey(epTran, entity.MaterialNumber,entity.Plant);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE mtlstock MAKTX=@MAKTX,LABST=@LABST,QINSP=@QINSP,MEINS=@MEINS WHERE MATNR=@MATNR AND WERKS=@WERKS";

            SqlParameter p1 = new SqlParameter("@MAKTX", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p1);
            p1.Value = entity.MaterialDescription;

            SqlParameter p2 = new SqlParameter("@LABST", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p2);
            if (entity.UnrestrictedStock.HasValue)
                p2.Value = entity.UnrestrictedStock;
            else
                p2.Value = DBNull.Value;

            SqlParameter p3 = new SqlParameter("@QINSP", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p3);
            if (entity.InspectionStock.HasValue)
                p3.Value = entity.InspectionStock;
            else
                p3.Value = DBNull.Value;

            SqlParameter p4 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p4);
            p4.Value = entity.UnitOfMeasure;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="MaterialStock">Material Stock Object</param>
        public override void Delete(MaterialStock entity)
        {
            Delete(null, entity);
        }

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="MaterialStock">Material Stock Object</param>
        public override void Delete(EpTransaction epTran, MaterialStock entity)
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
            MaterialStock checkEntity = RetrieveByKey(epTran, entity.MaterialNumber,entity.Plant);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM mtlstock WHERE MATNR=@MATNR AND WERKS=@WERKS";
            SqlParameter p1 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p1);
            p1.Value = entity.MaterialNumber;

            SqlParameter p2 = new SqlParameter("@WERKS", SqlDbType.Char, 4);
            cm.Parameters.Add(p2);
            p2.Value = entity.Plant;

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
        /// Collection of Material Stock Object 
        /// </returns>
        private static Collection<MaterialStock> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<MaterialStock> entities = new Collection<MaterialStock>();

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
            string selectCommand = "SELECT [MATNR],[WERKS],[MAKTX],[LABST],[QINSP],[MEINS] FROM mtlstock";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                MaterialStock entity = new MaterialStock();
                entity.MaterialNumber = rd["MATNR"].ToString();
                entity.Plant = rd["WERKS"].ToString();

                if (rd.IsDBNull(2))
                    entity.MaterialDescription = null;
                else
                    entity.MaterialDescription = rd["MAKTX"].ToString();

                if (rd.IsDBNull(3))
                    entity.UnrestrictedStock = null;
                else
                    entity.UnrestrictedStock = System.Convert.ToDecimal(rd["LABST"].ToString());

                if (rd.IsDBNull(4))
                    entity.InspectionStock = null;
                else
                    entity.InspectionStock = Convert.ToDecimal(rd["QINSP"].ToString());

                if(rd.IsDBNull(5))
                    entity.UnitOfMeasure = null;
                else
                    entity.UnitOfMeasure= rd["MEINS"].ToString();
             
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

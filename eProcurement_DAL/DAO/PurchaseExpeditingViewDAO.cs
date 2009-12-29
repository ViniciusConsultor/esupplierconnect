//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Ma hongyu
// Created Date : 28/12/2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class enables to provide methods for Retrieve records form [purexpedite] and [purhdr]  
//       -Retrieve.
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
    public class PurchaseExpeditingViewDAO : IPurchaseExpeditingViewDAO
    {
        #region RetrieveByQuery
        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of PurchaseExpeditingView Object 
        /// </returns>
        public override Collection<PurchaseExpeditingView> RetrieveByQuery(string whereClause)
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
        public override Collection<PurchaseExpeditingView> RetrieveByQuery(string whereClause, string sortClaues)
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
        public override Collection<PurchaseExpeditingView> RetrieveByQuery(EpTransaction epTran, string whereClause)
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
        public override Collection<PurchaseExpeditingView> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region private methods
        /// Retrieve list of record in a specified sort order from database tables for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseExpeditingView Object 
        /// </returns>
        private Collection<PurchaseExpeditingView> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<PurchaseExpeditingView> entities = new Collection<PurchaseExpeditingView>();

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
            string selectCommand = "SELECT e.[EBELN],e.[EBELP],e.[ETENR],e.[MATNR],e.[EXPDT],e.[WEMNG],e.[VBELN],e.[PRMDT1],e.[PRMDT2],e.[RECSTS]";
            selectCommand += ",h.LIFNR ";
            selectCommand += " FROM purexpedite e inner join purhdr h on e.EBELN=h.EBELN ";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseExpeditingView entity = new PurchaseExpeditingView();
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
                    entity.ExpediteQuantity = Convert.ToDecimal(rd["WEMNG"].ToString());

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
                entity.SupplierId = rd["LIFNR"].ToString();

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

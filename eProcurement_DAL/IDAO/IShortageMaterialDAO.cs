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
    public abstract class IShortageMaterialDAO
    {

        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of Shortage Material Object
        /// </returns>
        public abstract Collection<ShortageMaterial> RetrieveAll();

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Shortage Materail Object 
        /// </returns>
        public abstract Collection<ShortageMaterial> RetrieveAll(string sortClaues);

        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of Shortage Material Object
        /// </returns>
        public abstract Collection<ShortageMaterial> RetrieveAll(EpTransaction epTran);

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Shortage Material Object 
        /// </returns>
        public abstract Collection<ShortageMaterial> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of Shortage Material Object 
        /// </returns>
        public abstract Collection<ShortageMaterial> RetrieveByQuery(string whereClause);

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Shortage Material Object 
        /// </returns>
        public abstract Collection<ShortageMaterial> RetrieveByQuery(string whereClause, string sortClaues);

        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of Shortage Material Object 
        /// </returns>
        public abstract Collection<ShortageMaterial> RetrieveByQuery(EpTransaction epTran, string whereClause);

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Shortage Material Object 
        /// </returns>
        public abstract Collection<ShortageMaterial> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="materialNumber">Material Number: mtlshortage.MATNR</param>
        /// <returns>
        /// Shortage Material Object
        /// </returns>
        public abstract ShortageMaterial RetrieveByKey(string materialNumber);

        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="materialNumber">Material Number: mtlstock.MATNR</param>
        /// <returns>
        /// Shortage Material Object
        /// </returns>
        public abstract ShortageMaterial RetrieveByKey(EpTransaction epTran, string materialNumber);
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="ShortageMaterial">Shortage Material Object</param>
        public abstract void Insert(ShortageMaterial entity);

        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="ShortageMaterial">Shortage Material</param>
        public abstract void Insert(EpTransaction epTran, ShortageMaterial entity);
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="Shortage Material">Shortage Material Object</param>
        public abstract void Update(ShortageMaterial entity);

        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="ShortageMaterial">ShortageMaterial Object</param>
        public abstract void Update(EpTransaction epTran, ShortageMaterial entity);
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="ShortageMaterial">Shortage Material Object</param>
        public abstract void Delete(ShortageMaterial entity);

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="ShortageMAterial">Shortage Material Object</param>
        public abstract void Delete(EpTransaction epTran, ShortageMaterial entity);
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace eProcurement_DAL
///<summary>Entity Object (Purchase Order Item Schedule) - Database table [PURSCH]</summary>
{
    public abstract class IPurchaseOrderItemScheduleDAO
    {
        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of PurchaseOrderItemSchedule Object
        /// </returns>
        public abstract Collection<PurchaseOrderItemSchedule> RetrieveAll();
        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderItemSchedule Object 
        /// </returns>
        public abstract Collection<PurchaseOrderItemSchedule> RetrieveAll(string sortClaues);
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of PurchaseOrderItemSchedule Object
        /// </returns>
        public abstract Collection<PurchaseOrderItemSchedule> RetrieveAll(EpTransaction epTran);
        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderItemSchedule Object 
        /// </returns>
        public abstract Collection<PurchaseOrderItemSchedule> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderItemSchedule Object 
        /// </returns>
        public abstract Collection<PurchaseOrderItemSchedule> RetrieveByQuery(string whereClause);

        public abstract Collection<PurchaseOrderItemSchedule> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<PurchaseOrderItemSchedule> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<PurchaseOrderItemSchedule> RetrieveByQuery
            (EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="orderNumber">Order Number: PURSCH.EBELN</param>
        /// <param name="itemSequence">purchase Item Sequence Number : PURSCH.EBELP</param>
        /// <returns>
        /// PurchaseOrderItemSchedule Object
        /// </returns>
        public abstract PurchaseOrderItemSchedule RetrieveByKey
            (string orderNumber, string ItemSequenceNO, string ScheduleSequenceNo);
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="orderNumber">Order Number: PURSCH.EBELN</param>
        /// <param name="itemSequence">purchase Item Sequence Number : PURSCH.EBELP</param>
        /// <returns>
        /// PurchaseOrderItemSchedule Object
        /// </returns>
        public abstract PurchaseOrderItemSchedule RetrieveByKey
            (EpTransaction epTran, string orderNumber, string ItemSequenceNO, string ScheduleSequenceNo);
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="PurchaseOrderItemSchedule">PurchaseOrderItemSchedule Object</param>
        /// 
        public abstract void Insert(PurchaseOrderItemSchedule entity);
        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderItemSchedule">PurchaseOrderItemSchedule Object</param>
        public abstract void Insert(EpTransaction epTran, PurchaseOrderItemSchedule entity);
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseOrderItemSchedule">PurchaseOrderItemSchedule Object</param>
        public abstract void Update(PurchaseOrderItemSchedule entity);
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderItemSchedule">PurchaseOrderItemSchedule Object</param>
        public abstract void Update(EpTransaction epTran, PurchaseOrderItemSchedule entity);
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseOrderItemSchedule">PurchaseOrderItemSchedule Object</param>
        public abstract void Delete(PurchaseOrderItemSchedule entity);
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderItemSchedule">PurchaseOrderItemSchedule Object</param>
        public abstract void Delete(EpTransaction epTran, PurchaseOrderItemSchedule entity);
        #endregion

    }

}
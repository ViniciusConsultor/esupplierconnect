using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace eProcurement_DAL
///<summary>Entity Object (Purchase Order Service Item) - Database table [PURSCH]</summary>
{
    public abstract class IPurchaseOrderServiceItemDAO
    {
        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of PurchaseOrderServiceItem Object
        /// </returns>
        public abstract Collection<PurchaseOrderServiceItem> RetrieveAll();
        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderServiceItem Object 
        /// </returns>
        public abstract Collection<PurchaseOrderServiceItem> RetrieveAll(string sortClaues);
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of PurchaseOrderServiceItem Object
        /// </returns>
        public abstract Collection<PurchaseOrderServiceItem> RetrieveAll(EpTransaction epTran);
        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderServiceItem Object 
        /// </returns>
        public abstract Collection<PurchaseOrderServiceItem> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderServiceItem Object 
        /// </returns>
        public abstract Collection<PurchaseOrderServiceItem> RetrieveByQuery(string whereClause);

        public abstract Collection<PurchaseOrderServiceItem> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<PurchaseOrderServiceItem> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<PurchaseOrderServiceItem> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="orderNumber">Order Number: PURSRV.EBELN</param>
        /// <param name="itemSequence">purchase Item Sequence Number : PURSRV.EBELP</param>
        /// <returns>
        /// PurchaseOrderServiceItem Object
        /// </returns>
        public abstract PurchaseOrderServiceItem RetrieveByKey(string orderNumber, string ItemSequenceNumber, string ServiceLineNumber);
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="orderNumber">Order Number: PURSRV.EBELN</param>
        /// <param name="itemSequence">purchase Item Sequence Number : PURSRV.EBELP</param>
        /// <returns>
        /// PurchaseOrderServiceItem Object
        /// </returns>
        public abstract PurchaseOrderServiceItem RetrieveByKey(EpTransaction epTran, string orderNumber, string ItemSequenceNumber, string ServiceLineNumber);
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="PurchaseOrderItemSchedule">PurchaseOrderServiceItem Object</param>
        /// 
        public abstract void Insert(PurchaseOrderServiceItem entity);
        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderItemSchedule">PurchaseOrderServiceItem Object</param>
        public abstract void Insert(EpTransaction epTran, PurchaseOrderServiceItem entity);
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseOrderItemSchedule">PurchaseOrderServiceItem Object</param>
        public abstract void Update(PurchaseOrderServiceItem entity);
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderItemSchedule">PurchaseOrderServiceItem Object</param>
        public abstract void Update(EpTransaction epTran, PurchaseOrderServiceItem entity);
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseOrderServiceItem">PurchaseOrderItemSchedule Object</param>
        public abstract void Delete(PurchaseOrderServiceItem entity);
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderItemSchedule">PurchaseOrderService Object</param>
        public abstract void Delete(EpTransaction epTran, PurchaseOrderServiceItem entity);
        #endregion

    }
}

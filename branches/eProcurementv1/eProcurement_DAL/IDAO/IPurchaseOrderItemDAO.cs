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
    ///<summary>Data Access Object - Database table [PURDTL]</summary> 
    public abstract class IPurchaseOrderItemDAO
    {
        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of PurchaseOrderItem Object
        /// </returns>
        public abstract Collection<PurchaseOrderItem> RetrieveAll();
        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderItem Object 
        /// </returns>
        public abstract Collection<PurchaseOrderItem> RetrieveAll(string sortClaues);
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of PurchaseOrderItem Object
        /// </returns>
        public abstract Collection<PurchaseOrderItem> RetrieveAll(EpTransaction epTran);
        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderItem Object 
        /// </returns>
        public abstract Collection<PurchaseOrderItem> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderItem Object 
        /// </returns>
        public abstract Collection<PurchaseOrderItem> RetrieveByQuery(string whereClause);

        public abstract Collection<PurchaseOrderItem> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<PurchaseOrderItem> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<PurchaseOrderItem> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="orderNumber">Order Number: PURDTL.EBELN</param>
        /// <param name="itemSequence">purchase Item Sequence Number : PURDTL.EBELP</param>
        /// <returns>
        /// PurchaseOrderItem Object
        /// </returns>
        public abstract PurchaseOrderItem RetrieveByKey(string orderNumber, string SequenceNO);
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="orderNumber">Order Number: PURDTL.EBELN</param>
        /// <param name="itemSequence">purchase Item Sequence Number : PURDTL.EBELP</param>
        /// <returns>
        /// PurchaseOrderItem Object
        /// </returns>
        public abstract PurchaseOrderItem RetrieveByKey(EpTransaction epTran, string orderNumber, string SequenceNO);
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="PurchaseOrderItem">PurchaseOrderItem Object</param>
        /// 
        public abstract void Insert(PurchaseOrderItem entity);

        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderItem">PurchaseOrderItem Object</param>
        public abstract void Insert(EpTransaction epTran, PurchaseOrderItem entity);
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseOrderItem">PurchaseOrderItem Object</param>
        public abstract void Update(PurchaseOrderItem entity);
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderItem">PurchaseOrderItem Object</param>
        public abstract void Update(EpTransaction epTran, PurchaseOrderItem entity);
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseOrderItem">PurchaseOrderItem Object</param>
        public abstract void Delete(PurchaseOrderItem entity);

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderItem">PurchaseOrderItem Object</param>
        public abstract void Delete(EpTransaction epTran, PurchaseOrderItem entity);
        #endregion

    }

}

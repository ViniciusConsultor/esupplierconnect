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
    public abstract class IPurchaseOrderHeaderDAO
    {
        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object
        /// </returns>
        public abstract Collection<PurchaseOrderHeader> RetrieveAll();

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object 
        /// </returns>
        public abstract Collection<PurchaseOrderHeader> RetrieveAll(string sortClaues);

        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object
        /// </returns>
        public abstract Collection<PurchaseOrderHeader> RetrieveAll(EpTransaction epTran);

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object 
        /// </returns>
        public abstract Collection<PurchaseOrderHeader> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object 
        /// </returns>
        public abstract Collection<PurchaseOrderHeader> RetrieveByQuery(string whereClause);

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object 
        /// </returns>
        public abstract Collection<PurchaseOrderHeader> RetrieveByQuery(string whereClause, string sortClaues);

        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object 
        /// </returns>
        public abstract Collection<PurchaseOrderHeader> RetrieveByQuery(EpTransaction epTran, string whereClause);

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseOrderHeader Object 
        /// </returns>
        public abstract Collection<PurchaseOrderHeader> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="orderNumber">Order Number: puitxt.EBELN</param>
        /// <returns>
        /// PurchaseOrderHeader Object
        /// </returns>
        public abstract PurchaseOrderHeader RetrieveByKey(string orderNumber);

        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="orderNumber">Order Number: puitxt.EBELN</param>
        /// <returns>
        /// PurchaseOrderHeader Object
        /// </returns>
        public abstract PurchaseOrderHeader RetrieveByKey(EpTransaction epTran, string orderNumber);
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="PurchaseOrderHeader">PurchaseOrderHeader Object</param>
        public abstract void Insert(PurchaseOrderHeader entity);

        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderHeader">PurchaseOrderHeader Object</param>
        public abstract void Insert(EpTransaction epTran, PurchaseOrderHeader entity);
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseOrderHeader">PurchaseOrderHeader Object</param>
        public abstract void Update(PurchaseOrderHeader entity);

        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderHeader">PurchaseOrderHeader Object</param>
        public abstract void Update(EpTransaction epTran, PurchaseOrderHeader entity);
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseOrderHeader">PurchaseOrderHeader Object</param>
        public abstract void Delete(PurchaseOrderHeader entity);

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseOrderHeader">PurchaseOrderHeader Object</param>
        public abstract void Delete(EpTransaction epTran, PurchaseOrderHeader entity);
        #endregion
    }
}

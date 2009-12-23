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
    public abstract class IPurchaseItemTextDAO
    {
        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of PurchaseItemText Object
        /// </returns>
        public abstract Collection<PurchaseItemText> RetrieveAll();

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseItemText Object 
        /// </returns>
        public abstract Collection<PurchaseItemText> RetrieveAll(string sortClaues);

        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of PurchaseItemText Object
        /// </returns>
        public abstract Collection<PurchaseItemText> RetrieveAll(EpTransaction epTran);

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseItemText Object 
        /// </returns>
        public abstract Collection<PurchaseItemText> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of PurchaseItemText Object 
        /// </returns>
        public abstract Collection<PurchaseItemText> RetrieveByQuery(string whereClause);

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseItemText Object 
        /// </returns>
        public abstract Collection<PurchaseItemText> RetrieveByQuery(string whereClause, string sortClaues);

        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of PurchaseItemText Object 
        /// </returns>
        public abstract Collection<PurchaseItemText> RetrieveByQuery(EpTransaction epTran, string whereClause);

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of PurchaseItemText Object 
        /// </returns>
        public abstract Collection<PurchaseItemText> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
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
        public abstract PurchaseItemText RetrieveByKey(string orderNumber, string itemSequence, string textSequence);

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
        public abstract PurchaseItemText RetrieveByKey(EpTransaction epTran, string orderNumber, string itemSequence, string textSequence);
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="PurchaseItemText">PurchaseItemText Object</param>
        public abstract void Insert(PurchaseItemText entity);

        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseItemText">PurchaseItemText Object</param>
        public abstract void Insert(EpTransaction epTran, PurchaseItemText entity);
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseItemText">PurchaseItemText Object</param>
        public abstract void Update(PurchaseItemText entity);

        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseItemText">PurchaseItemText Object</param>
        public abstract void Update(EpTransaction epTran, PurchaseItemText entity);
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseItemText">PurchaseItemText Object</param>
        public abstract void Delete(PurchaseItemText entity);

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseItemText">PurchaseItemText Object</param>
        public abstract void Delete(EpTransaction epTran, PurchaseItemText entity);
        #endregion

    }
}

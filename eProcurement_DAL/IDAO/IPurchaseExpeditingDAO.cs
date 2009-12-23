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
    public abstract class IPurchaseExpeditingDAO
    {
        #region RetrieveAll
        public abstract Collection<PurchaseExpediting> RetrieveAll();
        public abstract Collection<PurchaseExpediting> RetrieveAll(string sortClaues);
        public abstract Collection<PurchaseExpediting> RetrieveAll(EpTransaction epTran);
        public abstract Collection<PurchaseExpediting> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<PurchaseExpediting> RetrieveByQuery(string whereClause);

        public abstract Collection<PurchaseExpediting> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<PurchaseExpediting> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<PurchaseExpediting> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="orderNumber">Order Number: puitxt.EBELN</param>
        /// <returns>
        /// PurchaseExpediting Object
        /// </returns>
        public abstract PurchaseExpediting RetrieveByKey(string orderNumber, string itemSequence, string scheduleSequence);
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="orderNumber">Order Number: puitxt.EBELN</param>
        /// <returns>
        /// PurchaseExpediting Object
        /// </returns>
        public abstract PurchaseExpediting RetrieveByKey(EpTransaction epTran, string orderNumber, string itemSequence, string scheduleSequence);
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="PurchaseExpediting">PurchaseExpediting Object</param>
        public abstract void Insert(PurchaseExpediting entity);

        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseExpediting">PurchaseExpediting Object</param>
        public abstract void Insert(EpTransaction epTran, PurchaseExpediting entity);
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseExpediting">PurchaseExpediting Object</param>
        public abstract void Update(PurchaseExpediting entity);

        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseExpediting">PurchaseExpediting Object</param>
        public abstract void Update(EpTransaction epTran, PurchaseExpediting entity);
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="PurchaseExpediting">PurchaseExpediting Object</param>
        public abstract void Delete(PurchaseExpediting entity);

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="PurchaseExpediting">PurchaseExpediting Object</param>
        public abstract void Delete(EpTransaction epTran, PurchaseExpediting entity);
        #endregion
    }
}

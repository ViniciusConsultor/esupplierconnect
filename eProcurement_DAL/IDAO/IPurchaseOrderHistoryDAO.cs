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
    public abstract class IPurchaseOrderHistoryDAO
    {
        #region RetrieveAll
        public abstract Collection<PurchaseOrderHistory> RetrieveAll();

        public abstract Collection<PurchaseOrderHistory> RetrieveAll(string sortClaues);

        public abstract Collection<PurchaseOrderHistory> RetrieveAll(EpTransaction epTran);

        public abstract Collection<PurchaseOrderHistory> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<PurchaseOrderHistory> RetrieveByQuery(string whereClause);

        public abstract Collection<PurchaseOrderHistory> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<PurchaseOrderHistory> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<PurchaseOrderHistory> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract PurchaseOrderHistory RetrieveByKey(string orderNumber, string itemSequence, string materialDocument);

        public abstract PurchaseOrderHistory RetrieveByKey(EpTransaction epTran, string orderNumber, string itemSequence, string materialDocument);
        #endregion

        #region Insert
        public abstract void Insert(PurchaseOrderHistory entity);

        public abstract void Insert(EpTransaction epTran, PurchaseOrderHistory entity);
        #endregion

        #region Update
        public abstract void Update(PurchaseOrderHistory entity);

        public abstract void Update(EpTransaction epTran, PurchaseOrderHistory entity);
        #endregion

        #region Delete
        public abstract void Delete(PurchaseOrderHistory entity);

        public abstract void Delete(EpTransaction epTran, PurchaseOrderHistory entity);
        #endregion
    }
}

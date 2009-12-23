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
    public abstract class IPurchaseServiceTaskDAO
    {
        #region RetrieveAll
        public abstract Collection<PurchaseServiceTask> RetrieveAll();

        public abstract Collection<PurchaseServiceTask> RetrieveAll(string sortClaues);

        public abstract Collection<PurchaseServiceTask> RetrieveAll(EpTransaction epTran);

        public abstract Collection<PurchaseServiceTask> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<PurchaseServiceTask> RetrieveByQuery(string whereClause);

        public abstract Collection<PurchaseServiceTask> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<PurchaseServiceTask> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<PurchaseServiceTask> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract PurchaseServiceTask RetrieveByKey(string ServiceItem, string ServiceSequence);

        public abstract PurchaseServiceTask RetrieveByKey(EpTransaction epTran, string ServiceItem, string ServiceSequence);
        #endregion

        #region Insert
        public abstract void Insert(PurchaseServiceTask entity);

        public abstract void Insert(EpTransaction epTran, PurchaseServiceTask entity);
        #endregion

        #region Update
        public abstract void Update(PurchaseServiceTask entity);

        public abstract void Update(EpTransaction epTran, PurchaseServiceTask entity);
        #endregion

        #region Delete
        public abstract void Delete(PurchaseServiceTask entity);

        public abstract void Delete(EpTransaction epTran, PurchaseServiceTask entity);
        #endregion

    }

}

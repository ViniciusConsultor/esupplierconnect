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
    public abstract class IPurchaseGroupDAO
    {
        #region RetrieveAll

        public abstract Collection<PurchaseGroup> RetrieveAll();

        public abstract Collection<PurchaseGroup> RetrieveAll(string sortClaues);

        public abstract Collection<PurchaseGroup> RetrieveAll(EpTransaction epTran);

        public abstract Collection<PurchaseGroup> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<PurchaseGroup> RetrieveByQuery(string whereClause);

        public abstract Collection<PurchaseGroup> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<PurchaseGroup> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<PurchaseGroup> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract PurchaseGroup RetrieveByKey(string purchaseGroup, string UserId);
        public abstract PurchaseGroup RetrieveByKey(EpTransaction epTran, string purchaseGroup, string UserId);
        #endregion

        #region Insert
        public abstract void Insert(PurchaseGroup entity);

        public abstract void Insert(EpTransaction epTran, PurchaseGroup entity);
        #endregion

        #region Update
        public abstract void Update(PurchaseGroup entity);

        public abstract void Update(EpTransaction epTran, PurchaseGroup entity);

        #endregion

        #region Delete
        public abstract void Delete(PurchaseGroup entity);

        public abstract void Delete(EpTransaction epTran, PurchaseGroup entity);
        #endregion
    }
}

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
    public abstract class IPurchaseHeaderTextDAO
    {
        #region RetrieveAll
        public abstract Collection<PurchaseHeaderText> RetrieveAll();

        public abstract Collection<PurchaseHeaderText> RetrieveAll(string sortClaues);

        public abstract Collection<PurchaseHeaderText> RetrieveAll(EpTransaction epTran);

        public abstract Collection<PurchaseHeaderText> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<PurchaseHeaderText> RetrieveByQuery(string whereClause);

        public abstract Collection<PurchaseHeaderText> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<PurchaseHeaderText> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<PurchaseHeaderText> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract PurchaseHeaderText RetrieveByKey(string orderNumber, string textSequence);

        public abstract PurchaseHeaderText RetrieveByKey(EpTransaction epTran, string orderNumber, string textSequence);
        #endregion

        #region Insert
        public abstract void Insert(PurchaseHeaderText entity);

        public abstract void Insert(EpTransaction epTran, PurchaseHeaderText entity);
        #endregion

        #region Update
        public abstract void Update(PurchaseHeaderText entity);

        public abstract void Update(EpTransaction epTran, PurchaseHeaderText entity);
        #endregion

        #region Delete
        public abstract void Delete(PurchaseHeaderText entity);

        public abstract void Delete(EpTransaction epTran, PurchaseHeaderText entity);
        #endregion

    }
}

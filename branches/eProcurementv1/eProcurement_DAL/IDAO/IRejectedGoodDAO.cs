using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;


namespace eProcurement_DAL
{
    public abstract class IRejectedGoodDAO
    {
        #region RetrieveAll
        public abstract Collection<RejectedGood> RetrieveAll();

        public abstract Collection<RejectedGood> RetrieveAll(string sortClaues);

        public abstract Collection<RejectedGood> RetrieveAll(EpTransaction epTran);

        public abstract Collection<RejectedGood> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<RejectedGood> RetrieveByQuery(string whereClause);

        public abstract Collection<RejectedGood> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<RejectedGood> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<RejectedGood> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract RejectedGood RetrieveByKey(string orderNumber,string itemSequence, string documentNumber);

        public abstract RejectedGood RetrieveByKey(EpTransaction epTran, string orderNumber, string itemSequence, string documentNumber);
        #endregion

        #region Insert
        public abstract void Insert(RejectedGood entity);

        public abstract void Insert(EpTransaction epTran, RejectedGood entity);
        #endregion

        #region Update
        public abstract void Update(RejectedGood entity);

        public abstract void Update(EpTransaction epTran, RejectedGood entity);
        #endregion

        #region Delete
        public abstract void Delete(RejectedGood entity);

        public abstract void Delete(EpTransaction epTran, RejectedGood entity);
        #endregion

    }
}

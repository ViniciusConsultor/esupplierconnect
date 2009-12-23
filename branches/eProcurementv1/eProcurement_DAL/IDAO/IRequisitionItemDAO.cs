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
    public abstract class IRequisitionItemDAO
    {
        #region RetrieveAll
        public abstract Collection<RequisitionItem> RetrieveAll();

        public abstract Collection<RequisitionItem> RetrieveAll(string sortClaues);

        public abstract Collection<RequisitionItem> RetrieveAll(EpTransaction epTran);

        public abstract Collection<RequisitionItem> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<RequisitionItem> RetrieveByQuery(string whereClause);

        public abstract Collection<RequisitionItem> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<RequisitionItem> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<RequisitionItem> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract RequisitionItem RetrieveByKey(string requisitionNumber, string itemSequence);

        public abstract RequisitionItem RetrieveByKey(EpTransaction epTran, string requisitionNumber, string itemSequence);
        #endregion

        #region Insert
        public abstract void Insert(RequisitionItem entity);

        public abstract void Insert(EpTransaction epTran, RequisitionItem entity);
        #endregion

        #region Update
        public abstract void Update(RequisitionItem entity);

        public abstract void Update(EpTransaction epTran, RequisitionItem entity);
        #endregion

        #region Delete
        public abstract void Delete(RequisitionItem entity);

        public abstract void Delete(EpTransaction epTran, RequisitionItem entity);
        #endregion

    }
}

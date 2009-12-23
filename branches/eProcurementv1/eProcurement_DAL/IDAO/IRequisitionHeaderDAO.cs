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
    public abstract class IRequisitionHeaderDAO
    {
        #region RetrieveAll
        public abstract Collection<RequisitionHeader> RetrieveAll();

        public abstract Collection<RequisitionHeader> RetrieveAll(string sortClaues);

        public abstract Collection<RequisitionHeader> RetrieveAll(EpTransaction epTran);

        public abstract Collection<RequisitionHeader> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<RequisitionHeader> RetrieveByQuery(string whereClause);

        public abstract Collection<RequisitionHeader> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<RequisitionHeader> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<RequisitionHeader> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract RequisitionHeader RetrieveByKey(string RequisitionNumber);

        public abstract RequisitionHeader RetrieveByKey(EpTransaction epTran, string RequisitionNumber);
        #endregion

        #region Insert
        public abstract void Insert(RequisitionHeader entity);

        public abstract void Insert(EpTransaction epTran, RequisitionHeader entity);
        #endregion

        #region Update
        public abstract void Update(RequisitionHeader entity);

        public abstract void Update(EpTransaction epTran, RequisitionHeader entity);
        #endregion

        #region Delete
        public abstract void Delete(RequisitionHeader entity);

        public abstract void Delete(EpTransaction epTran, RequisitionHeader entity);
        #endregion
    }
}

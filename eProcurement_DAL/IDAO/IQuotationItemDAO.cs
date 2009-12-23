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
    public abstract class IQuotationItemDAO
    {
        #region RetrieveAll
        public abstract Collection<QuotationItem> RetrieveAll();

        public abstract Collection<QuotationItem> RetrieveAll(string sortClause);

        public abstract Collection<QuotationItem> RetrieveAll(EpTransaction epTran);

        public abstract Collection<QuotationItem> RetrieveAll(EpTransaction epTran, string sortClause);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<QuotationItem> RetrieveByQuery(string whereClause);

        public abstract Collection<QuotationItem> RetrieveByQuery(string whereClause, string sortClause);

        public abstract Collection<QuotationItem> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<QuotationItem> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClause);
        #endregion

        #region RetrieveByKey
        public abstract QuotationItem RetrieveByKey(string RequestNumber, string RequestSequence);

        public abstract QuotationItem RetrieveByKey(EpTransaction epTran, string RequestNumber, string RequestSequence);
        #endregion

        #region Insert
        public abstract void Insert(QuotationItem entity);

        public abstract void Insert(EpTransaction epTran, QuotationItem entity);
        #endregion

        #region Update
        public abstract void Update(QuotationItem entity);

        public abstract void Update(EpTransaction epTran, QuotationItem entity);
        #endregion

        #region Delete
        public abstract void Delete(QuotationItem entity);

        public abstract void Delete(EpTransaction epTran, QuotationItem entity);
        #endregion
    }
}

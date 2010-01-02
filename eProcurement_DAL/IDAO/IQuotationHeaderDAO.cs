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
    public abstract class IQuotationHeaderDAO
    {
        #region RetrieveAll
        public abstract Collection<QuotationHeader> RetrieveAll();

        public abstract Collection<QuotationHeader> RetrieveAll(string sortClause);

        public abstract Collection<QuotationHeader> RetrieveAll(EpTransaction epTran);

        public abstract Collection<QuotationHeader> RetrieveAll(EpTransaction epTran, string sortClause);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<QuotationHeader> RetrieveByQuery(string whereClause);

        public abstract Collection<QuotationHeader> RetrieveByQuery(string whereClause, string sortClause);

        public abstract Collection<QuotationHeader> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<QuotationHeader> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClause);
        #endregion

        #region RetrieveByKey
        public abstract QuotationHeader RetrieveByKey(string RequestNumber);

        public abstract QuotationHeader RetrieveByKey(EpTransaction epTran, string RequestNumber);
        #endregion

        #region Insert
        public abstract void Insert(QuotationHeader entity);

        public abstract void Insert(EpTransaction epTran, QuotationHeader entity);
        #endregion

        public abstract string GetResqNo(EpTransaction epTran);
        
        #region Update
        public abstract void Update(QuotationHeader entity);

        public abstract void Update(EpTransaction epTran, QuotationHeader entity);
        #endregion

        #region Delete
        public abstract void Delete(QuotationHeader entity);

        public abstract void Delete(EpTransaction epTran, QuotationHeader entity);
        #endregion
    }
}
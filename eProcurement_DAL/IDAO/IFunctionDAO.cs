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
    public abstract class IFunctionDAO
    {
        #region RetrieveAll

        public abstract Collection<Function> RetrieveAll();

        public abstract Collection<Function> RetrieveAll(string sortClaues);

        public abstract Collection<Function> RetrieveAll(EpTransaction epTran);

        public abstract Collection<Function> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<Function> RetrieveByQuery(string whereClause);

        public abstract Collection<Function> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<Function> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<Function> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract Function RetrieveByKey(string functionId);

        public abstract Function RetrieveByKey(EpTransaction epTran, string functionId);

        #endregion

        #region Insert
        public abstract void Insert(Function entity);

        public abstract void Insert(EpTransaction epTran, Function entity);
        #endregion

        #region Update
        public abstract void Update(Function entity);

        public abstract void Update(EpTransaction epTran, Function entity);

        #endregion

        #region Delete
        public abstract void Delete(Function entity);

        public abstract void Delete(EpTransaction epTran, Function entity);
        #endregion
    }
}


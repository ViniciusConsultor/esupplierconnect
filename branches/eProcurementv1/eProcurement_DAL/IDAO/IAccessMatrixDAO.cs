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
    public abstract class IAccessMatrixDAO
    {
        #region RetrieveAll

        public abstract Collection<AccessMatrix> RetrieveAll();

        public abstract Collection<AccessMatrix> RetrieveAll(string sortClaues);

        public abstract Collection<AccessMatrix> RetrieveAll(EpTransaction epTran);

        public abstract Collection<AccessMatrix> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<AccessMatrix> RetrieveByQuery(string whereClause);

        public abstract Collection<AccessMatrix> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<AccessMatrix> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<AccessMatrix> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract AccessMatrix RetrieveByKey(string userRole, string profileType, string functionId);
        public abstract AccessMatrix RetrieveByKey(EpTransaction epTran, string userRole, string profileType, string functionId);
        #endregion

        #region Insert
        public abstract void Insert(AccessMatrix entity);

        public abstract void Insert(EpTransaction epTran, AccessMatrix entity);
        #endregion

        #region Update
        public abstract void Update(AccessMatrix entity);

        public abstract void Update(EpTransaction epTran, AccessMatrix entity);

        #endregion

        #region Delete
        public abstract void Delete(AccessMatrix entity);

        public abstract void Delete(EpTransaction epTran, AccessMatrix entity);
        #endregion
    }
}


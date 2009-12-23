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
    public abstract class ISupplierDAO
    {
        #region RetrieveAll
        public abstract Collection<Supplier> RetrieveAll();

        public abstract Collection<Supplier> RetrieveAll(string sortClaues);

        public abstract Collection<Supplier> RetrieveAll(EpTransaction epTran);

        public abstract Collection<Supplier> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<Supplier> RetrieveByQuery(string whereClause);

        public abstract Collection<Supplier> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<Supplier> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<Supplier> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract Supplier RetrieveByKey(string supplierID);

        public abstract Supplier RetrieveByKey(EpTransaction epTran, string supplierID);
        #endregion

        #region Insert
        public abstract void Insert(Supplier entity);

        public abstract void Insert(EpTransaction epTran, Supplier entity);
        #endregion

        #region Update
        public abstract void Update(Supplier entity);

        public abstract void Update(EpTransaction epTran, Supplier entity);
        #endregion

        #region Delete
        public abstract void Delete(Supplier entity);

        public abstract void Delete(EpTransaction epTran, Supplier entity);
        #endregion

    }
}

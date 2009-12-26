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
    public abstract class IContractItemDAO
    {
        #region RetrieveAll
        public abstract Collection<ContractItem> RetrieveAll();

        public abstract Collection<ContractItem> RetrieveAll(string sortClaues);

        public abstract Collection<ContractItem> RetrieveAll(EpTransaction epTran);

        public abstract Collection<ContractItem> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<ContractItem> RetrieveByQuery(string whereClause);

        public abstract Collection<ContractItem> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<ContractItem> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<ContractItem> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract ContractItem RetrieveByKey(string contractNumber, string contractItemSequence);

        public abstract ContractItem RetrieveByKey(EpTransaction epTran, string contractNumber, string contractItemSequence);
        #endregion

        #region Insert
        public abstract void Insert(ContractItem entity);

        public abstract void Insert(EpTransaction epTran, ContractItem entity);
        #endregion

        #region Update
        public abstract void Update(ContractItem entity);

        public abstract void Update(EpTransaction epTran, ContractItem entity);
        #endregion

        #region Delete
        public abstract void Delete(ContractItem entity);

        public abstract void Delete(EpTransaction epTran, ContractItem entity);
        #endregion

    }
}

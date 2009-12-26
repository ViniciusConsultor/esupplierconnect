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
    public abstract class IContractHeaderDAO
    {
        #region RetrieveAll
        public abstract Collection<ContractHeader> RetrieveAll();

        public abstract Collection<ContractHeader> RetrieveAll(string sortClaues);

        public abstract Collection<ContractHeader> RetrieveAll(EpTransaction epTran);

        public abstract Collection<ContractHeader> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<ContractHeader> RetrieveByQuery(string whereClause);

        public abstract Collection<ContractHeader> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<ContractHeader> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<ContractHeader> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract ContractHeader RetrieveByKey(string ContractNumber);

        public abstract ContractHeader RetrieveByKey(EpTransaction epTran, string ContractNumber);
        #endregion

        #region Insert
        public abstract void Insert(ContractHeader entity);

        public abstract void Insert(EpTransaction epTran, ContractHeader entity);
        #endregion

        #region Update
        public abstract void Update(ContractHeader entity);

        public abstract void Update(EpTransaction epTran, ContractHeader entity);
        #endregion

        #region Delete
        public abstract void Delete(ContractHeader entity);

        public abstract void Delete(EpTransaction epTran, ContractHeader entity);
        #endregion

    }
}

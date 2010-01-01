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
    public abstract class ISubcontractorMaterialDAO
    {
        #region RetrieveAll
        public abstract Collection<SubcontractorMaterial> RetrieveAll();

        public abstract Collection<SubcontractorMaterial> RetrieveAll(string sortClaues);

        public abstract Collection<SubcontractorMaterial> RetrieveAll(EpTransaction epTran);

        public abstract Collection<SubcontractorMaterial> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion
        #region RetrieveByQuery
        public abstract Collection<SubcontractorMaterial> RetrieveByQuery(string whereClause);

        public abstract Collection<SubcontractorMaterial> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<SubcontractorMaterial> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<SubcontractorMaterial> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion
        #region RetrieveByKey
        public abstract SubcontractorMaterial RetrieveByKey(string orderNumber, string ItemSequence, string ComponentSequence, string Material);

        public abstract SubcontractorMaterial RetrieveByKey(EpTransaction epTran, string orderNumber, string ItemSequence, string ComponentSequence, string Material);
        #endregion
        #region Insert
        public abstract void Insert(SubcontractorMaterial entity);

        public abstract void Insert(EpTransaction epTran, SubcontractorMaterial entity);
        #endregion

        #region Update
        public abstract void Update(SubcontractorMaterial entity);

        public abstract void Update(EpTransaction epTran, SubcontractorMaterial entity);
        #endregion
        #region Delete
        public abstract void Delete(SubcontractorMaterial entity);

        public abstract void Delete(EpTransaction epTran, SubcontractorMaterial entity);
        #endregion
    }
}

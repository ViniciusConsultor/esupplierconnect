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
    public abstract class IMaterialRequirementDAO
    {
        #region RetrieveAll
        public abstract  Collection<MaterialRequirement> RetrieveAll();
        public abstract  Collection<MaterialRequirement> RetrieveAll(string sortClaues);
        public abstract  Collection<MaterialRequirement> RetrieveAll(EpTransaction epTran);
        public abstract  Collection<MaterialRequirement> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract  Collection<MaterialRequirement> RetrieveByQuery(string whereClause);
        public abstract  Collection<MaterialRequirement> RetrieveByQuery(string whereClause, string sortClaues);
        public abstract  Collection<MaterialRequirement> RetrieveByQuery(EpTransaction epTran, string whereClause);
        public abstract  Collection<MaterialRequirement> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract  MaterialRequirement RetrieveByKey(string materialNumber, string plant, long requiredDate);
        public abstract  MaterialRequirement RetrieveByKey(EpTransaction epTran, string materialNumber, string plant, long requiredDate);
        #endregion

        #region Insert
        public abstract  void Insert(MaterialRequirement entity);
        public abstract  void Insert(EpTransaction epTran, MaterialRequirement entity);
        #endregion

        #region Update
        public abstract  void Update(MaterialRequirement entity);
        public abstract  void Update(EpTransaction epTran, MaterialRequirement entity);
        #endregion

        #region Delete
        public abstract  void Delete(MaterialRequirement entity);
        public abstract  void Delete(EpTransaction epTran, MaterialRequirement entity);
        public abstract void DeleteAll(EpTransaction epTrans);
        #endregion

    }
}

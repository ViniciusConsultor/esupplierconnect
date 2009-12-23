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
    public abstract class IUserDAO
    {
        #region RetrieveAll
        public abstract Collection<User> RetrieveAll();

        public abstract Collection<User> RetrieveAll(string sortClaues);

        public abstract Collection<User> RetrieveAll(EpTransaction epTran);

        public abstract Collection<User> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<User> RetrieveByQuery(string whereClause);

        public abstract Collection<User> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<User> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<User> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract User RetrieveByKey(string userID);

        public abstract User RetrieveByKey(EpTransaction epTran, string userID);
        #endregion

        #region Insert
        public abstract void Insert(User entity);

        public abstract void Insert(EpTransaction epTran, User entity);
        #endregion

        #region Update
        public abstract void Update(User entity);

        public abstract void Update(EpTransaction epTran, User entity);
        #endregion

        #region Delete
        public abstract void Delete(User entity);
        
        public abstract void Delete(EpTransaction epTran, User entity);
        #endregion

    }
}

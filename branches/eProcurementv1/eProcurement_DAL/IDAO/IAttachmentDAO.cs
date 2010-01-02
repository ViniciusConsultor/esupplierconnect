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
    public abstract class IAttachmentDAO
    {
        #region RetrieveAll

        public abstract Collection<Attachment> RetrieveAll();

        public abstract Collection<Attachment> RetrieveAll(string sortClaues);

        public abstract Collection<Attachment> RetrieveAll(EpTransaction epTran);

        public abstract Collection<Attachment> RetrieveAll(EpTransaction epTran, string sortClaues);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<Attachment> RetrieveByQuery(string whereClause);

        public abstract Collection<Attachment> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<Attachment> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<Attachment> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion

        #region RetrieveByKey
        public abstract Attachment RetrieveByKey(Guid attachmentId);
        public abstract Attachment RetrieveByKey(EpTransaction epTran, Guid attachmentId);
        #endregion

        #region Insert
        public abstract void Insert(Attachment entity);

        public abstract void Insert(EpTransaction epTran, Attachment entity);
        #endregion

        #region Update
        public abstract void Update(Attachment entity);

        public abstract void Update(EpTransaction epTran, Attachment entity);

        #endregion

        #region Delete
        public abstract void Delete(Attachment entity);

        public abstract void Delete(EpTransaction epTran, Attachment entity);
        #endregion
    }
}

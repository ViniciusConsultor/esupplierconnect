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
    public abstract class IDeliveryOrderDAO
    {
        #region RetrieveAll
        public abstract Collection<DeliveryOrder> RetrieveAll();

        public abstract Collection<DeliveryOrder> RetrieveAll(string sortClause);

        public abstract Collection<DeliveryOrder> RetrieveAll(EpTransaction epTran);

        public abstract Collection<DeliveryOrder> RetrieveAll(EpTransaction epTran, string sortClause);
        #endregion

        #region RetrieveByQuery
        public abstract Collection<DeliveryOrder> RetrieveByQuery(string whereClause);

        public abstract Collection<DeliveryOrder> RetrieveByQuery(string whereClause, string sortClause);

        public abstract Collection<DeliveryOrder> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<DeliveryOrder> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClause);
        #endregion

        #region RetrieveByKey
        public abstract DeliveryOrder RetrieveByKey(string OrderNumber, string ItemSequence, string DeliveryNumber);

        public abstract DeliveryOrder RetrieveByKey(EpTransaction epTran, string OrderNumber, string ItemSequence, string DeliveryNumber);
        #endregion

        #region Insert
        public abstract void Insert(DeliveryOrder entity);

        public abstract void Insert(EpTransaction epTran, DeliveryOrder entity);
        #endregion

        #region Update
        public abstract void Update(DeliveryOrder entity);

        public abstract void Update(EpTransaction epTran, DeliveryOrder entity);
        #endregion

        #region Delete
        public abstract void Delete(DeliveryOrder entity);

        public abstract void Delete(EpTransaction epTran, DeliveryOrder entity);
        #endregion
    }
}

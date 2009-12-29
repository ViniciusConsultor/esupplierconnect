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
    ///<summary>Data Access Object - Database table [purexpedite] and [purhdr]  </summary>
    public abstract class IPurchaseExpeditingViewDAO
    {
        #region RetrieveByQuery
        public abstract Collection<PurchaseExpeditingView> RetrieveByQuery(string whereClause);

        public abstract Collection<PurchaseExpeditingView> RetrieveByQuery(string whereClause, string sortClaues);

        public abstract Collection<PurchaseExpeditingView> RetrieveByQuery(EpTransaction epTran, string whereClause);

        public abstract Collection<PurchaseExpeditingView> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues);
        #endregion
    }
}

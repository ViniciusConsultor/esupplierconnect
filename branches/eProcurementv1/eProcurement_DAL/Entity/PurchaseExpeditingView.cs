using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace eProcurement_DAL
{
    public class PurchaseExpeditingView : PurchaseExpediting
    {
        ///<summary>Database mapping to column purhdr.LIFNR</summary>
        string supplierId;
        public string SupplierId
        {
            get { return supplierId; }
            set { supplierId = value; }
        }
    }
}

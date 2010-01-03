using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class PurchaseGroup
    {
        string purchaseGroup;
        public string PurGroup
        {
            get { return purchaseGroup; }
            set { purchaseGroup = value; }
        }

        string userId;
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}

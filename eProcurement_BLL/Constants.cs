using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_BLL
{
    public class POAckStatus
    {
        public const string PendingAcknowledge = "N";
        public const string Acknowledged = "Y";
    }

    public class SystemMessageType
    {
        public const string Information = "I";
        public const string Warning = "W";
        public const string Error = "E";
        public const string Fatal = "F";
    }

    #region User Management Constants

    public class SessionKey
    {
        public const string LOGIN_USER = "LOGIN_USER";
    }

    public class UserType
    {
        public const string Buyer = "B";
        public const string Supplier = "S";
        public const string WarehouseUser = "H";
    }

    #endregion

}

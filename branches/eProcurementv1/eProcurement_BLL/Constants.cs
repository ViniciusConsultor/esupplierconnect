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

    public class ProfileType
    {
        public const string Buyer = "Buyer";
        public const string Supplier = "Supplier";
        public const string WarehouseUser = "WHUser";
    }

    public class UserRole
    {
        public const string Administrator = "Administrator";
        public const string Viewer = "Viewer";
        public const string Operator = "Operator";
    }
   
    #endregion

}

using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_BLL
{
    public class POAckStatus
    {
        public const string Yes = "Y";
        public const string No = "N";
    }

    public class PORecStatus
    {
        public const string Accept = "A";
        public const string Reject1 = "1";
        public const string Reject2 = "2";
    }

    public class POStatus
    {
        public const string Delete = "D";
        public const string Complete = "C";
    }

    public class ExpediteStatus
    {
        public const string Expedite = "E";
        public const string Acknowledge = "K";
        public const string Accept = "A";
        public const string Reject = "R";
        public const string New = "";

        public static string GetDesc(string status)
        {
            string sCompare = "";
            if (!string.IsNullOrEmpty(status)) sCompare = status.Trim();

            switch (sCompare)
            {
                case Expedite:
                    return "Expedited";
                case Acknowledge:
                    return "Acknowledged";
                case Accept:
                    return "Accepted";
                case Reject:
                    return "Rejected";
                default:
                    return "-";
            }
        }
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
        public const string OrderNumber = "ORDER_NO";
        public const string OrderItemSeqNumber = "ORDER_ITEM_SEQ_NUMBER";
        public const string OrderScheduleSeq = "ORDER_SCHEDULE_SEQ";
    }

    public class ProfileType
    {
        public const string Buyer = "Buyer";
        public const string Supplier = "Supplier";
        public const string WarehouseUser = "WHUser";
        public const string System = "System";
    }

    public class UserRole
    {
        public const string Administrator = "Administrator";
        public const string Viewer = "Viewer";
        public const string Operator = "Operator";
    }

    public class UserStatus
    {
        public const string Active = "A";
        public const string Void = "V";
    }
   
    #endregion

}

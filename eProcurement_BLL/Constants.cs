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

    public class RejAckStatus
    {
        public const string Yes = "Y";
        public const string No = "N";
    }

    public class QuotationStatus
    {
        public const string Request = "R";
        public const string Acknowledge = "K";
        public const string Accept = "A";
        public const string Reject = "R";
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

    public class ContractAckStatus
    {
        public const string Yes = "Y";
        public const string No = "N";
    }

    public class NotificationMessage
    {
        public const string buyerSender    = "Raymond Khoo";
        public const string buyerRecepient = "Raymond Khoo";
        public const string buyerEmail     = "chetan@fujitecsg.com";

        public const string OrderCreate = "POCRT";	            //	Purchase Order Create
        public const string OrderUpdate = "POUPD";              //	Purchase Order Update
        public const string OrderExpedite = "POEXP";            //	Purchase Order Expedite
        public const string OrderAcknowledged = "POACK";        //	Purchase Order Acknowledged
        public const string ExpediteAcknowledged = "POEAC";     //	Purchase Order Exepdite Acknowledged
        public const string OrderAckFirstReject = "PAREJ";      //	Purchase Order Ack First Time Rejection
        public const string ExpediteAckFirstReject = "EAREJ";   //	Purchase Order Expediting Ack First Time Rejection
        public const string ContractCreate = "CNCRT";           //	Contract Create
        public const string ContractUpdate = "CNUPD";           //	Contract Update
        public const string RFQCreate = "RQCRT";                //	RFQ  Create
        public const string RFQUpdate = "RQUPD";                //	RFQ Update
        public const string RejectionCreate = "PAREJ";          //  Goods Rejection
        public const string VendorCreate = "VNCRT";             // Vendor Creation
        public const string VendorUpdate = "VNUPD";             // Vendor Update

    }



    #region User Management Constants

    public class SessionKey
    {
        public const string LOGIN_USER = "LOGIN_USER";
        public const string OrderNumber = "ORDER_NO";
        public const string ContractNumber = "CONTRACT_NO";
        public const string OrderItemSeqNumber = "ORDER_ITEM_SEQ_NUMBER";
        public const string OrderScheduleSeq = "ORDER_SCHEDULE_SEQ";
        public const string DELIVERY_ORDER_COLLECTION = "DELIVERY_ORDER_COLLECTION";
        public const string RequestNumber = "REQUEST_NUMBER";
        
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

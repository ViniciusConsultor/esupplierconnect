//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Vinss, Rajendran Vinoth Prabu
// Created Date : 11 Oct 2009
// NUS ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class contains field mapping to database table [NOTIFICATION].
//	  
// Revision History:
//    1.0:
//      Author  : Vinss
//      Date    : 11 Oct 2009
//      Comments: Created class 
//    
// Copyright 2008-2010 ISS/Fujitec
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    ///<summary>Entity Object (Notification) - Database table [NOTIFICATION]</summary>
    [Serializable]
    public class Notification
    {
        ///<summary>Database mapping to column NOTIFICATION.NOTIFID</summary>
        string notificationId;
        public string NotificationId
        {
            get { return notificationId; }
            set { notificationId = value; }
        }

        ///<summary>Database mapping to column NOTIFICATION.NOTIFTYPE</summary>
        string notificationType;
        public string NotificationType
        {
            get { return notificationType; }
            set { notificationType = value; }
        }

        ///<summary>Database mapping to column NOTIFICATION.NOTIFDATE</summary> 
        long notificationDate;
        public long NotificationDate
        {
            get { return notificationDate; }
            set { notificationDate = value; }
        }

        ///<summary>Database mapping to column NOTIFICATION.REFNUM</summary>
        string referenceNumber;
        public string ReferenceNumber
        {
            get { return referenceNumber; }
            set { referenceNumber = value; }
        }

        ///<summary>Database mapping to column NOTIFICATION.REFSEQ</summary>
        string referenceSequence;
        public string ReferenceSequence
        {
            get { return referenceSequence; }
            set { referenceSequence = value; }
        }

        ///<summary>Database mapping to column NOTIFICATION.MESSAGE</summary>
        string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        ///<summary>Database mapping to column NOTIFICATION.SENDER</summary>
        string sender;
        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        
        ///<summary>Database mapping to column NOTIFICATION.RECIPIENT</summary>
        string recipient;
        public string Recipient
        {
            get { return recipient; }
            set { recipient = value; }
        }

        ///<summary>Database mapping to column NOTIFICATION.EMAIL</summary>
        string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        ///<summary>Database mapping to column NOTIFICATION.STATUS</summary>
        string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }


    }
}

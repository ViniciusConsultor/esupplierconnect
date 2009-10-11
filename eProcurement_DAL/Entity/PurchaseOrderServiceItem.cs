//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : HNIN
// Created Date : 20/09/2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class contains field mapping to database table [PURSRV].
//	  
// Revision History:
//    1.0:
//      Author  : HNIN
//      Date    : 20/09/2009   
//      Comments: Created class 
//    
// Copyright 2008-2010 ISS/Fujitec
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    ///<summary>Entity Object (Purchase Order Item) - Database table [PURSRV]</summary>
    [Serializable]
    public class PurchaseOrderServiceItem
    {
        string orderNumber;
        ///<summary>Database mapping to column PURSRV.EBELN</summary>
        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        string itemSequenceNumber;
        ///<summary>Database mapping to column PURSRV.EBELP</summary>
        public string ItemSequenceNumber
        {
            get { return itemSequenceNumber; }
            set { itemSequenceNumber = value; }
        }

        string serviceLineNumber;
        ///<summary>Database mapping to column PURSRV.LBLN1</summary>
        public string ServiceLineNumber
        {
            get { return serviceLineNumber; }
            set { serviceLineNumber = value; }
        }

        string serviceDescription;
        ///<summary>Database mapping to column PURSRV.KTEXT1</summary>
        public string ServiceDescription
        {
            get { return serviceDescription; }
            set { serviceDescription = value; }
        }

        Nullable<decimal> serviceQuantity;
        ///<summary>Database mapping to column PURSRV.MENGE</summary>
        public Nullable<decimal> ServiceQuantity
        {
            get { return serviceQuantity; }
            set { serviceQuantity = value; }
        }

        Nullable<decimal> servicePrice;
        ///<summary>Database mapping to column PURSRV.PREIS</summary>
        public Nullable<decimal> ServicePrice
        {
            get { return servicePrice; }
            set { servicePrice = value; }
        }

        string recordStatus;
        ///<summary>Database mapping to column PURSRV.RECSTS</summary>
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }

    }
}

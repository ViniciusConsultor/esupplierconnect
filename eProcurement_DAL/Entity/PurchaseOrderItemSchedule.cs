//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : HNIN
// Created Date : 20/09/2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class contains field mapping to database table [PURSCH].
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
    ///<summary>Entity Object (Purchase Order Item Schedule) - Database table [PURSCH]</summary>
    [Serializable]
    public class PurchaseOrderItemSchedule
    {
        string purchaseOrderNumber;
        ///<summary>Database mapping to column PURSCH.EBELN</summary>
        public string PurchaseOrderNumber
        {
            get { return purchaseOrderNumber; }
            set { purchaseOrderNumber = value; }
        }

        string purchaseOrderItemSequence;
        ///<summary>Database mapping to column PURSCH.EBELP</summary>
        public string PurchaseOrderItemSequence
        {
            get { return purchaseOrderItemSequence; }
            set { purchaseOrderItemSequence = value; }
        }

        string materialNumber;
        ///<summary>Database mapping to column PURSCH.MATNR</summary>
        public string MaterialNumber
        {
            get { return materialNumber; }
            set { materialNumber = value; }
        }

        string purchaseOrderScheduleSequence;
        ///<summary>Database mapping to column PURSCH.ETENR</summary>
        public string PurchaseOrderScheduleSequence
        {
            get { return purchaseOrderScheduleSequence; }
            set { purchaseOrderScheduleSequence = value; }
        }

        Nullable<long> orderItemScheduleDate;
        ///<summary>Database mapping to column PURSCH.SLFDAT</summary>
        public Nullable<long> OrderItemScheduleDate
        {
            get { return orderItemScheduleDate; }
            set { orderItemScheduleDate = value; }
        }

        Nullable<decimal> deliveryScheduleQuantity;
        ///<summary>Database mapping to column PURSCH.MENGE</summary>
        public Nullable<decimal> DeliveryScheduleQuantity
        {
            get { return deliveryScheduleQuantity; }
            set { deliveryScheduleQuantity = value; }
        }

        Nullable<long> deliveryDate;
        ///<summary>Database mapping to column PURSCH.EINDT</summary>
        public Nullable<long> DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        Nullable<decimal> deliveredQuantity;
        ///<summary>Database mapping to column PURSCH.WEMNG</summary>
        public Nullable<decimal> DeliveredQuantity
        {
            get { return deliveredQuantity; }
            set { deliveredQuantity = value; }
        }

        Nullable<long> acknowledgementDate;
        ///<summary>Database mapping to column PURSCH.ACKDT</summary>
        public Nullable<long> AcknowledgementDate
        {
            get { return acknowledgementDate; }
            set { acknowledgementDate = value; }
        }

        string recordStatus;
        ///<summary>Database mapping to column PURSCH.RECSTS</summary>
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }

        Nullable<long> expeditingPromiseDate;
        ///<summary>Database mapping to column PURSCH.PRMDT</summary>
        public Nullable<long> ExpeditingPromiseDate
        {
            get { return expeditingPromiseDate; }
            set { expeditingPromiseDate = value; }
        }

        
    }
}

//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : HNIN
// Created Date : 20/09/2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class contains field mapping to database table [PURDTL].
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
    ///<summary>Entity Object (Purchase Order Item) - Database table [PURDTL]</summary>
    [Serializable]
    public class PurchaseOrderItem
    {
        string purchaseOrderNumber;
        ///<summary>Database mapping to column PURDTL.EBELN</summary>
        public string PurchaseOrderNumber
        {
            get { return purchaseOrderNumber; }
            set { purchaseOrderNumber = value; }
        }

        string purchaseItemSequenceNumber;
        ///<summary>Database mapping to column PURDTL.EBELP</summary>
        public string PurchaseItemSequenceNumber
        {
            get { return purchaseItemSequenceNumber; }
            set { purchaseItemSequenceNumber = value; }
        }

        string materialNumber;
        ///<summary>Database mapping to column PURDTL.MATNR</summary>
        public string MaterialNumber
        {
            get { return materialNumber; }
            set { materialNumber = value; }
        }

        string purchaseOrderType;
        ///<summary>Database mapping to column PURDTL.PSTYP</summary>
        public string PurchaseOrderType
        {
            get { return purchaseOrderType; }
            set { purchaseOrderType = value; }
        }


        string shortText;
        ///<summary>Database mapping to column PURDTL.TXZ01</summary>
        public string ShortText
        {
            get { return shortText; }
            set { shortText = value; }
        }

        string oldMaterialNumber;
        ///<summary>Database mapping to column PURDTL.BISMT</summary>
        public string OldMaterialNumber
        {
            get { return oldMaterialNumber; }
            set { oldMaterialNumber = value; }
        }

        Nullable<decimal> orderQuantity;
        ///<summary>Database mapping to column PURDTL.MENGE</summary>
        public Nullable<decimal> OrderQuantity
        {
            get { return orderQuantity; }
            set { orderQuantity = value; }
        }

        Nullable<decimal> pricePerUnit;
        ///<summary>Database mapping to column PURDTL.PEINH</summary>
        public Nullable<decimal> PricePerUnit
        {
            get { return pricePerUnit; }
            set { pricePerUnit = value; }
        }

        string unitofMeasure;
        ///<summary>Database mapping to column PURDTL.MEINS</summary>
        public string UnitofMeasure
        {
            get { return unitofMeasure; }
            set { unitofMeasure = value; }
        }

        Nullable<decimal> netPrice;
        ///<summary>Database mapping to column PURDTL.NETPR</summary>
        public Nullable<decimal> NetPrice
        {
            get { return netPrice; }
            set { netPrice = value; }
        }

        string remarks;
        ///<summary>Database mapping to column PURDTL.REMARK</summary>
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        Nullable<decimal> deliveredQuantity;
        ///<summary>Database mapping to column PURDTL.WEMNG</summary>
        public Nullable<decimal> DeliveredQuantity
        {
            get { return deliveredQuantity; }
            set { deliveredQuantity = value; }
        }

        string longTextDescription;
        ///<summary>Database mapping to column PURDTL.TEXT80</summary>
        public string LongTextDescription
        {
            get { return longTextDescription; }
            set { longTextDescription = value; }
        }

        string orderNumber;
        ///<summary>Database mapping to column PURDTL.AUFNR</summary>
        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        string storageLocation;
        ///<summary>Database mapping to column PURDTL.LGORT_D</summary>
        public string StorageLocation
        {
            get { return storageLocation; }
            set { storageLocation = value; }
        }

        string itemStatus;
        ///<summary>Database mapping to column PURDTL.ASFNR</summary>
        public string ItemStatus
        {
            get { return itemStatus; }
            set { itemStatus = value; }
        }

        string deletionStatusIndicator;
        ///<summary>Database mapping to column PURDTL.STS2</summary>
        public string DeletionStatusIndicator
        {
            get { return deletionStatusIndicator; }
            set { deletionStatusIndicator = value; }
        }

        string recordStatus;
        ///<summary>Database mapping to column PURDTL.RECSTS</summary>
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }

        string acknowledgementStatus;
        ///<summary>Database mapping to column PURDTL.ACKSTS</summary>
        public string AcknowledgementStatus
        {
            get { return acknowledgementStatus; }
            set { acknowledgementStatus = value; }
        }
    }
}

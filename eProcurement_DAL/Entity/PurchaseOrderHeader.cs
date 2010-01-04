//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Ma hongyu
// Created Date : 18/09/2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class contains field mapping to database table [purhdr].
//	  
// Revision History:
//    1.0:
//      Author  : Ma hongyu
//      Date    : 18/09/2009   
//      Comments: Created class 
//    
// Copyright 2008-2010 ISS/Fujitec
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    ///<summary>Entity Object (Purchase Order Header) - Database table [purhdr]</summary>
    [Serializable]
    public class PurchaseOrderHeader
    {
        ///<summary>Database mapping to column purhdr.EBELN</summary>
        string orderNumber;
        public string OrderNumber
        {
            get{ return orderNumber;}
            set{ orderNumber = value;}
        }

        ///<summary>Database mapping to column purhdr.BSTYP</summary>
        string orderType;
        public string OrderType
        {
            get { return orderType; }
            set { orderType = value; }
        }

        ///<summary>Database mapping to column purhdr.BSART</summary>
        string orderCategory;
        public string OrderCategory
        {
            get { return orderCategory; }
            set { orderCategory = value; }
        }

        ///<summary>Database mapping to column purhdr.LIFNR</summary>
        string supplierId;
        public string SupplierId
        {
            get { return supplierId; }
            set { supplierId = value; }
        }

        ///<summary>Database mapping to column purhdr.BEDAT</summary>
        Nullable<long> orderDate;
        public Nullable<long> OrderDate 
        {
            get { return orderDate;}
            set { orderDate = value;}
        }

        ///<summary>Database mapping to column purhdr.AMTPR</summary>
        Nullable<decimal> orderAmount;
        public Nullable<decimal> OrderAmount
        {
            get { return orderAmount; }
            set { orderAmount = value; }
        }

        ///<summary>Database mapping to column purhdr.GSTPR</summary>
        Nullable<decimal> gstAmount;
        public Nullable<decimal> GstAmount
        {
            get { return gstAmount; }
            set { gstAmount = value; }
        }

        ///<summary>Database mapping to column purhdr.WAERS</summary>
        string currencyCode;
        public string CurrencyCode
        {
            get { return currencyCode; }
            set { currencyCode = value; }
        }

        ///<summary>Database mapping to column purhdr.ZTERM</summary>
        string paymentTerms;
        public string PaymentTerms
        {
            get { return paymentTerms; }
            set { paymentTerms = value; }
        }

        ///<summary>Database mapping to column purhdr.BUYER</summary>
        string buyerName;
        public string BuyerName
        {
            get { return buyerName; }
            set { buyerName = value; }
        }

        ///<summary>Database mapping to column purhdr.AD_TLNMBR</summary>
        string addressNumber;
        public string AddressNumber
        {
            get { return addressNumber; }
            set { addressNumber = value; }
        }

        ///<summary>Database mapping to column purhdr.VERKF</summary>
        string salesPerson;
        public string SalesPerson
        {
            get { return salesPerson; }
            set { salesPerson = value; }
        }

        ///<summary>Database mapping to column purhdr.ADRNR_TXT</summary>
        string shipmentAddress;
        public string ShipmentAddress
        {
            get { return shipmentAddress; }
            set { shipmentAddress = value; }
        }

        ///<summary>Database mapping to column purhdr.REMARK</summary>
        string remarks;
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        ///<summary>Database mapping to column purhdr.STAT</summary>
        string orderStatus;
        public string OrderStatus
        {
            get { return orderStatus; }
            set { orderStatus = value; }
        }

        ///<summary>Database mapping to column purhdr.RECSTS</summary>
        string recordStatus;
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }

        ///<summary>Database mapping to column purhdr.ACKSTS</summary>
        string acknowledgeStatus;
        public string AcknowledgeStatus
        {
            get { return acknowledgeStatus; }
            set { acknowledgeStatus = value; }
        }

        ///<summary>Database mapping to column purhdr.ACKBY</summary>
        string acknowledgeBy;
        public string AcknowledgeBy
        {
            get { return acknowledgeBy; }
            set { acknowledgeBy = value; }
        }

        ///<summary>Database mapping to column purhdr.TELPHN</summary>
        string buyerPhone;
        public string BuyerPhone
        {
            get { return buyerPhone; }
            set { buyerPhone = value; }
        }

        ///<summary>Database mapping to column purhdr.CREATEBY</summary>
        string createby;
        public string CreateBy
        {
            get { return createby; }
            set { createby = value; }
        }

        ///<summary>Database mapping to column purhdr.EKGRP</summary>
        string purchaseGroup;
        public string PurchaseGroup
        {
            get { return purchaseGroup; }
            set { purchaseGroup = value; }
        }

        ///<summary>Database mapping to column purhdr.EKORG</summary>
        string purchaseOrg;
        public string PurchaseOrg
        {
            get { return purchaseOrg; }
            set { purchaseOrg = value; }
        }

    }
}

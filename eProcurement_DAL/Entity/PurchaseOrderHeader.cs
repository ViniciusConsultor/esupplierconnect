using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class PurchaseOrderHeader
    {
        string orderNumber;
        public string OrderNumber
        {
            get{ return orderNumber;}
            set{ orderNumber = value;}
        }

        string supplierID;
        public string SupplierID
        {
            get { return supplierID;}
            set { supplierID = value;}
        }

        Nullable<long> orderDate;
        public Nullable<long> OrderDate 
        {
            get { return orderDate;}
            set { orderDate = value;}
        }

        Nullable<decimal> orderAmount;
        public Nullable<decimal> OrderAmount
        {
            get { return orderAmount; }
            set { orderAmount = value; }
        }

        Nullable<decimal> gstAmount;
        public Nullable<decimal> GstAmount
        {
            get { return gstAmount; }
            set { gstAmount = value; }
        }

        string currencyCode;
        public string CurrencyCode
        {
            get { return currencyCode; }
            set { currencyCode = value; }
        }

        string paymentTerms;
        public string PaymentTerms
        {
            get { return paymentTerms; }
            set { paymentTerms = value; }
        }

        string buyerName;
        public string BuyerName
        {
            get { return buyerName; }
            set { buyerName = value; }
        }

        string addressNumber;
        public string AddressNumber
        {
            get { return addressNumber; }
            set { addressNumber = value; }
        }

        string salesPerson;
        public string SalesPerson
        {
            get { return salesPerson; }
            set { salesPerson = value; }
        }

        string shipmentAddress;
        public string ShipmentAddress
        {
            get { return shipmentAddress; }
            set { shipmentAddress = value; }
        }

        string remarks;
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        string orderStatus;
        public string OrderStatus
        {
            get { return orderStatus; }
            set { orderStatus = value; }
        }

        string recordStatus;
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }

        string acknowledgeStatus;
        public string AcknowledgeStatus
        {
            get { return acknowledgeStatus; }
            set { acknowledgeStatus = value; }
        }
    }
}

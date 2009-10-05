using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class PurchaseOrderHistory
    {
        string orderNumber;
        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        string itemSequence;
        public string ItemSequence
        {
            get { return itemSequence; }
            set { itemSequence = value; }
        }

        string transactionType;
        public string TransactionType
        {
            get { return transactionType; }
            set { transactionType = value; }
        }

        string documentNumber;
        public string DocumentNumber
        {
            get { return documentNumber; }
            set { documentNumber = value; }
        }

        string documentSerial;
        public string DocumentSerial
        {
            get { return documentSerial; }
            set { documentSerial = value; }
        }

        string movementType;
        public string MovementType
        {
            get { return movementType; }
            set { movementType = value; }
        }

        Nullable<long> postingDate;
        public Nullable<long> PostingDate
        {
            get { return postingDate; }
            set { postingDate = value; }
        }

        Nullable<decimal> transactionQuantity;
        public Nullable<decimal> TransactionQuantity
        {
            get { return transactionQuantity; }
            set { transactionQuantity = value; }
        }

        string unitOfMeasure;
        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }

        Nullable<decimal> transactionAmount;
        public Nullable<decimal> TransactionAmount
        {
            get { return transactionAmount; }
            set { transactionAmount = value; }
        }

        string currencyId;
        public string CurrencyId
        {
            get { return currencyId; }
            set { currencyId = value; }
        }

        string referenceNumber;
        public string ReferenceNumber
        {
            get { return referenceNumber; }
            set { referenceNumber = value; }
        }

        string referenceSerial;
        public string ReferenceSerial
        {
            get { return referenceSerial; }
            set { referenceSerial = value; }
        }

        Nullable<decimal> invoiceValue;
        public Nullable<decimal> InvoiceValue
        {
            get { return invoiceValue; }
            set { invoiceValue = value; }
        }

        string materialNumber;
        public string MaterialNumber
        {
            get { return materialNumber; }
            set { materialNumber = value; }
        }

        string plant;
        public string Plant
        {
            get { return plant; }
            set { plant = value; }
        }
    }
}

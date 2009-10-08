using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class RequisitionItem
    {
        string requisitionNumber;
        public string RequisitionNumber
        {
            get { return requisitionNumber; }
            set { requisitionNumber = value; }
        }

        string itemSequence;
        public string ItemSequence
        {
            get { return itemSequence; }
            set { itemSequence = value; }
        }

        string purchasingGroup;
        public string PurchasingGroup
        {
            get { return purchasingGroup; }
            set { purchasingGroup = value; }
        }

        string materialNumber;
        public string MaterialNumber
        {
            get { return materialNumber; }
            set { materialNumber = value; }
        }

        string materialDescription;
        public string MaterialDescription
        {
            get { return materialDescription; }
            set { materialDescription = value; }
        }

        string plant;
        public string Plant
        {
            get { return plant; }
            set { plant = value; }
        }

        Nullable<decimal> requiredQuantity;
        public Nullable<decimal> RequiredQuantity
        {
            get { return requiredQuantity; }
            set { requiredQuantity = value; }
        }

        string unitOfMeasure;
        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }

        Nullable<long> requiredDate;
        public Nullable<long> RequiredDate
        {
            get { return requiredDate; }
            set { requiredDate = value; }
        }

        Nullable<decimal> estimatedPrice;
        public Nullable<decimal> EstimatedPrice
        {
            get { return estimatedPrice; }
            set { estimatedPrice = value; }
        }

        Nullable<decimal> unitPrice;
        public Nullable<decimal> UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        string orderNumber;
        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        string sequenceNumber;
        public string SequenceNumber
        {
            get { return sequenceNumber; }
            set { sequenceNumber = value; }
        }

        Nullable<long> orderDate;
        public Nullable<long> OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        string currencyId;
        public string CurrencyId
        {
            get { return currencyId; }
            set { currencyId = value; }
        }


        Nullable<decimal> totalValue;
        public Nullable<decimal> TotalValue
        {
            get { return totalValue; }
            set { totalValue = value; }
        }
    }
}


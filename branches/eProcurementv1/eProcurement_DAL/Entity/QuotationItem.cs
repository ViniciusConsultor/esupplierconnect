using System;
using System.Collections.Generic;
using System.Text;


namespace eProcurement_DAL
{
    [Serializable]
    public class QuotationItem
    {
        string requestNumber;
        public string RequestNumber
        {
            get { return requestNumber; }
            set { requestNumber = value; }
        }

        string requestSequence;
        public string RequestSequence
        {
            get { return requestSequence; }
            set { requestSequence = value; }
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

        string unitMeasure;
        public string UnitMeasure
        {
            get { return unitMeasure; }
            set { unitMeasure = value; }
        }

        Nullable<decimal> netPrice;
        public Nullable<decimal> NetPrice
        {
            get { return netPrice; }
            set { netPrice = value; }
        }

        Nullable<decimal> priceUnit;
        public Nullable<decimal> PriceUnit
        {
            get { return priceUnit; }
            set { priceUnit = value; }
        }

        Nullable<decimal> netValue;
        public Nullable<decimal> NetValue
        {
            get { return netValue; }
            set { netValue = value; }
        }

        string recordStatus;
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }
        
    }
}
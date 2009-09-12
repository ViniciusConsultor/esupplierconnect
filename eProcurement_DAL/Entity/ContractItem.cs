using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class ContractItem
    {
        string contractNumber;
        public string ContractNumber
        {
            get { return contractNumber; }
            set { contractNumber = value; }
        }

        string contractItemSequence;
        public string ContractItemSequence
        {
            get { return contractItemSequence; }
            set { contractItemSequence = value; }
        }

        string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
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

        string materialGroup;
        public string MaterialGroup
        {
            get { return materialGroup; }
            set { materialGroup = value; }
        }

        Nullable<decimal> targetQuantity;
        public Nullable<decimal> TargetQuantity
        {
            get { return targetQuantity; }
            set { targetQuantity = value; }
        }

        string unitOfMeasure;
        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }

        Nullable<decimal> unitPrice;
        public Nullable<decimal> UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        Nullable<decimal> pricePerUnit;
        public Nullable<decimal> PricePerUnit
        {
            get { return pricePerUnit; }
            set { pricePerUnit = value; }
        }

        Nullable<decimal> netValue;
        public Nullable<decimal> NetValue
        {
            get { return netValue; }
            set { netValue = value; }
        }

        string rFQNumber;
        public string RFQNumber
        {
            get { return rFQNumber; }
            set { rFQNumber = value; }
        }

        string requisitionNumber;
        public string RequisitionNumber
        {
            get { return requisitionNumber; }
            set { requisitionNumber = value; }
        }

        string requisitioner;
        public string Requisitioner
        {
            get { return requisitioner; }
            set { requisitioner = value; }
        }
    }
}

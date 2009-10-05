using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class PurchaseServiceTask
    {
        string sheetNumber;
        public string SheetNumber
        {
            get { return sheetNumber; }
            set { sheetNumber = value; }
        }

        string sheetSequence;
        public string SheetSequence
        {
            get { return sheetSequence; }
            set { sheetSequence = value; }
        }

        string serviceMaterial;
        public string ServiceMaterial
        {
            get { return serviceMaterial; }
            set { serviceMaterial = value; }
        }

        Nullable<decimal> serviceQuantity;
        public Nullable<decimal> ServiceQuantity
        {
            get { return serviceQuantity; }
            set { serviceQuantity = value; }
        }

        string unitOfMeasure;
        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }

        Nullable<decimal> servicePrice;
        public Nullable<decimal> ServicePrice
        {
            get { return servicePrice; }
            set { servicePrice = value; }
        }

        string serviceText;
        public string ServiceText
        {
            get { return serviceText; }
            set { serviceText = value; }
        }
    }
}

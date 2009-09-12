using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class PurchaseOrderSubcontractComponent
    {
        string orderNumber;
        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        string itemSequenceNumber;
        public string ItemSequenceNumber
        {
            get { return itemSequenceNumber; }
            set { itemSequenceNumber = value; }
        }

        string componentSequenceNumber;
        public string ComponentSequenceNumber
        {
            get { return componentSequenceNumber; }
            set { componentSequenceNumber = value; }
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

        Nullable<decimal> componentQuantity;
        public Nullable<decimal> ComponentQuantity
        {
            get { return componentQuantity; }
            set { componentQuantity = value; }
        }

        string unitOfMeasure;
        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }

        string itemStatus;
        public string ItemStatus
        {
            get { return itemStatus; }
            set { itemStatus = value; }
        }

        string recordStatus;
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }
    }
}

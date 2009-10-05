using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class SubcontractorMaterial
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

        string componentSequence;
        public string ComponentSequence
        {
            get { return componentSequence; }
            set { componentSequence = value; }
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

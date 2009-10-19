using System;
using System.Collections.Generic;
using System.Text;


namespace eProcurement_DAL
{
    [Serializable]
    public class DeliveryOrder
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

        string materialNumber;
        public string MaterialNumber
        {
            get { return materialNumber; }
            set { materialNumber = value; }
        }

        string deliveryNumber;
        public string DeliveryNumber
        {
            get { return deliveryNumber; }
            set { deliveryNumber = value; }
        }

        Nullable<long> deliveryDate;
        public Nullable<long> DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        Nullable<decimal> deliveryQuantity;
        public Nullable<decimal> DeliveryQuantity
        {
            get { return deliveryQuantity; }
            set { deliveryQuantity = value; }
        }

        string recordStatus;
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }

    }
}
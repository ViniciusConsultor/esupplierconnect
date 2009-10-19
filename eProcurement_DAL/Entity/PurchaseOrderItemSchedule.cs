using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class PurchaseOrderItemSchedule
    {
        string purchaseOrderNumber;
        public string PurchaseOrderNumber
        {
            get { return purchaseOrderNumber; }
            set { purchaseOrderNumber = value; }
        }

        string purchaseOrderItemSequence;
        public string PurchaseOrderItemSequence
        {
            get { return purchaseOrderItemSequence; }
            set { purchaseOrderItemSequence = value; }
        }

        string materialNumber;
        public string MaterialNumber
        {
            get { return materialNumber; }
            set { materialNumber = value; }
        }

        string purchaseOrderScheduleSequence;
        public string PurchaseOrderScheduleSequence
        {
            get { return purchaseOrderScheduleSequence; }
            set { purchaseOrderScheduleSequence = value; }
        }

        Nullable<long> orderItemScheduleDate;
        public Nullable<long> OrderItemScheduleDate
        {
            get { return orderItemScheduleDate; }
            set { orderItemScheduleDate = value; }
        }

        Nullable<decimal> deliveryScheduleQuantity;
        public Nullable<decimal> DeliveryScheduleQuantity
        {
            get { return deliveryScheduleQuantity; }
            set { deliveryScheduleQuantity = value; }
        }

        Nullable<long> deliveryDate;
        public Nullable<long> DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        Nullable<decimal> deliveredQuantity;
        public Nullable<decimal> DeliveredQuantity
        {
            get { return deliveredQuantity; }
            set { deliveredQuantity = value; }
        }

        Nullable<long> acknowledgementDate;
        public Nullable<long> AcknowledgementDate
        {
            get { return acknowledgementDate; }
            set { acknowledgementDate = value; }
        }

        string recordStatus;
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }

        Nullable<long> expeditingPromiseDate;
        public Nullable<long> ExpeditingPromiseDate
        {
            get { return expeditingPromiseDate; }
            set { expeditingPromiseDate = value; }
        }

        
    }
}

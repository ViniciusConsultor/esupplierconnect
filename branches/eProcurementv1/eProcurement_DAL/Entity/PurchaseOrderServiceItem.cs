using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class PurchaseOrderServiceItem
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

        string serviceLineNumber;
        public string ServiceLineNumber
        {
            get { return serviceLineNumber; }
            set { serviceLineNumber = value; }
        }

        string serviceDescription;
        public string ServiceDescription
        {
            get { return serviceDescription; }
            set { serviceDescription = value; }
        }

        Nullable<decimal> serviceQuantity;
        public Nullable<decimal> ServiceQuantity
        {
            get { return serviceQuantity; }
            set { serviceQuantity = value; }
        }

        Nullable<decimal> servicePrice;
        public Nullable<decimal> ServicePrice
        {
            get { return servicePrice; }
            set { servicePrice = value; }
        }

        string recordStatus;
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }

    }
}

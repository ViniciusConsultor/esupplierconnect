using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class PurchaseOrderItem
    {
        string purchaseOrderNumber;
        public string PurchaseOrderNumber
        {
            get { return purchaseOrderNumber; }
            set { purchaseOrderNumber = value; }
        }

        string purchaseItemSequenceNumber;
        public string PurchaseItemSequenceNumber
        {
            get { return purchaseItemSequenceNumber; }
            set { purchaseItemSequenceNumber = value; }
        }

        string materialNumber;
        public string MaterialNumber
        {
            get { return materialNumber; }
            set { materialNumber = value; }
        }

        string purchaseOrderType;
        public string PurchaseOrderType
        {
            get { return purchaseOrderType; }
            set { purchaseOrderType = value; }
        }


        string shortText;
        public string ShortText
        {
            get { return shortText; }
            set { shortText = value; }
        }

        string oldMaterialNumber;
        public string OldMaterialNumber
        {
            get { return oldMaterialNumber; }
            set { oldMaterialNumber = value; }
        }

        Nullable<decimal> orderQuantity;
        public Nullable<decimal> OrderQuantity
        {
            get { return orderQuantity; }
            set { orderQuantity = value; }
        }

        Nullable<decimal> pricePerUnit;
        public Nullable<decimal> PricePerUnit
        {
            get { return pricePerUnit; }
            set { pricePerUnit = value; }
        }

        string unitofMeasure;
        public string UnitofMeasure
        {
            get { return unitofMeasure; }
            set { unitofMeasure = value; }
        }

        Nullable<decimal> netPrice;
        public Nullable<decimal> NetPrice
        {
            get { return netPrice; }
            set { netPrice = value; }
        }

        string remarks;
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        Nullable<decimal> deliveredQuantity;
        public Nullable<decimal> DeliveredQuantity
        {
            get { return deliveredQuantity; }
            set { deliveredQuantity = value; }
        }

        string longTextDescription;
        public string LongTextDescription
        {
            get { return longTextDescription; }
            set { longTextDescription = value; }
        }

        string orderNumber;
        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        string storageLocation;
        public string StorageLocation
        {
            get { return storageLocation; }
            set { storageLocation = value; }
        }

        string itemStatus;
        public string ItemStatus
        {
            get { return itemStatus; }
            set { itemStatus = value; }
        }

        string deletionStatusIndicator;
        public string DeletionStatusIndicator
        {
            get { return deletionStatusIndicator; }
            set { deletionStatusIndicator = value; }
        }

        string recordStatus;
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }

        string acknowledgementStatus;
        public string AcknowledgementStatus
        {
            get { return acknowledgementStatus; }
            set { acknowledgementStatus = value; }
        }
    }
}

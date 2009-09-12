using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class PurchaseOrderHeaderText
    {
        string orderNumber;
        public string OrderNumber
        {
            get { return orderNumber; }
            set{orderNumber = value;}
        }

        string textSerialNumber;
        public string TextSerialNumber
        {
            get { return textSerialNumber; }
            set { textSerialNumber = value; }
        }

        string longText;
        public string LongText
        {
            get { return longText; }
            set { longText = value; }
        }

        string recordStatus;
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }
    }
}

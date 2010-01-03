using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class PurchaseHeaderText
    {
        string orderNumber;
        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        string textSequence;
        public string TextSequence
        {
            get { return textSequence; }
            set { textSequence = value; }
        }

        string longText;
        public string LongText
        {
            get { return longText; }
            set { longText = value; }
        }
    }
}

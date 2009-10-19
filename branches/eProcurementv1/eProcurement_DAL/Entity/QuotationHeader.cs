using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class QuotationHeader
    {
        string requestNumber;
        public string RequestNumber
        {
            get { return requestNumber; }
            set { requestNumber = value; }
        }

        string supplierId;
        public string SupplierId
        {
            get { return supplierId; }
            set { supplierId = value; }
        }

        Nullable<long> expiryDate;
        public Nullable<long> ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        string quotationNumber;
        public string QuotationNumber
        {
            get { return quotationNumber; }
            set { quotationNumber = value; }
        }

        Nullable<long> quotationDate;
        public Nullable<long> QuotationDate
        {
            get { return quotationDate; }
            set { quotationDate = value; }
        }

        string recordStatus;
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }
       
    }
}

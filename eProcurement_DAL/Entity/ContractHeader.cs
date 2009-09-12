using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class ContractHeader
    {
        string contractNumber;
        public string ContractNumber
        {
            get { return contractNumber; }
            set { contractNumber = value; }
        }

        Nullable<long> contractDate;
        public Nullable<long> ContractDate
        {
            get { return contractDate; }
            set { contractDate = value; }
        }

        string contractCategory;
        public string ContractCategory
        {
            get { return contractCategory; }
            set { contractCategory = value; }
        }

        string documentType;
        public string DocumentType
        {
            get { return documentType; }
            set { documentType = value; }
        }

        string createdBy;
        public string CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        string supplierId;
        public string SupplierId
        {
            get { return supplierId; }
            set { supplierId = value; }
        }

        string paymentTerms;
        public string PaymentTerms
        {
            get { return paymentTerms; }
            set { paymentTerms = value; }
        }

        string purchasingGroup;
        public string PurchasingGroup
        {
            get { return purchasingGroup; }
            set { purchasingGroup = value; }
        }

        string currency;
        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        Nullable<decimal> exchangeRate;
        public Nullable<decimal> ExchangeRate
        {
            get { return exchangeRate; }
            set { exchangeRate = value; }
        }

        Nullable<long> validityStart;
        public Nullable<long> ValidityStart
        {
            get { return validityStart; }
            set { validityStart = value; }
        }

        Nullable<long> validityEnd;
        public Nullable<long> ValidityEnd
        {
            get { return validityEnd; }
            set { validityEnd = value; }
        }

        string salesContactPerson;
        public string SalesContactPerson
        {
            get { return salesContactPerson; }
            set { salesContactPerson = value; }
        }

        string telephone;
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        Nullable<decimal> contractValue;
        public Nullable<decimal> ContractValue
        {
            get { return contractValue; }
            set { contractValue = value; }
        }

        string internalReference;
        public string InternalReference 
        {
            get { return internalReference; }
            set { internalReference = value; }
        }
    }
}

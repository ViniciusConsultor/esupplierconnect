using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class Supplier
    {
        string supplierID;
        public string SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }

        string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        string supplierName;
        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }

        string supplierAddress;
        public string SupplierAddress
        {
            get { return supplierAddress; }
            set { supplierAddress = value; }
        }

        string postalCode;
        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        string country;
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        string region;
        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        string countryCode;
        public string CountryCode
        {
            get { return countryCode; }
            set { countryCode = value; }
        }

        string telephone1;
        public string Telephone1
        {
            get { return telephone1; }
            set { telephone1 = value; }
        }

        string telephone2;
        public string Telephone2
        {
            get { return telephone2; }
            set { telephone2 = value; }
        }

        string sprEQ;
        public string SPREQ
        {
            get { return sprEQ; }
            set { sprEQ = value; }
        }

        string faxNo;
        public string FaxNo
        {
            get { return faxNo; }
            set { faxNo = value; }
        }

        string emailID;
        public string EmailID
        {
            get { return emailID; }
            set { emailID = value; }
        }

        string recordStatus;
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }
    }
}


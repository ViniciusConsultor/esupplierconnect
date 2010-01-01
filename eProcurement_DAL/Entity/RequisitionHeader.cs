using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class RequisitionHeader
    {
        string requisitionNumber;
        public string RequisitionNumber
        {
            get { return requisitionNumber; }
            set { requisitionNumber = value; }
        }

        string documentType;
        public string DocumentType
        {
            get { return documentType; }
            set { documentType = value; }
        }


        string requisitionCategory;
        public string RequisitionCategory
        {
            get { return requisitionCategory; }
            set { requisitionCategory = value; }
        }

   
        Nullable<long> requisitionDate;
        public Nullable<long> RequisitionDate
        {
            get { return requisitionDate; }
            set { requisitionDate = value; }
        }

        string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        string releaseStatus;
        public string ReleaseStatus
        {
            get { return releaseStatus; }
            set { releaseStatus = value; }
        }

        Nullable<long> releaseDate;
        public Nullable<long> ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        string createBy;
        public string CreateBy
        {
            get { return createBy; }
            set { createBy = value; }
        }
        
    }
}


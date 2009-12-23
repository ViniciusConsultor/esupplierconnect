using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class User
    {
        string userId;
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        string userPassword;
        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }

        string userRole;
        public string UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }

        string userEmail;
        public string UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }

        string updatedBy;
        public string UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        Nullable<long> updatedDate;
        public Nullable<long> UpdatedDate
        {
            get { return updatedDate; }
            set { updatedDate = value; }
        }

        string userStatus;
        public string UserStatus
        {
            get { return userStatus; }
            set { userStatus = value; }
        }

        string supplierID;
        public string SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }

        string profileType;
        public string ProfileType
        {
            get { return profileType; }
            set { profileType = value; }
        }


    }
}

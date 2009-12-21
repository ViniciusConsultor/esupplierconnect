using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL.UserManagement
{
    /// <summary>
    /// The login user object is stored in session.
    /// </summary>
    [Serializable]
    public class LoginUserVO
    {
        private string _userId;
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _emailAddr;
        public string EmailAddr
        {
            get { return _emailAddr; }
            set { _emailAddr = value; }
        }

        private System.DateTime _lastLoginDateTime;
        public System.DateTime LastLoginDateTime
        {
            get { return _lastLoginDateTime; }
            set { _lastLoginDateTime = value; }
        }

        private string _userType;
        public string UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        private string _supplierId;
        public string SupplierId
        {
            get { return _supplierId; }
            set { _supplierId = value; }
        }

        private string _role;
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        private Collection<string> _buyerGrpList;
        public Collection<string> BuyerGrpList
        {
            get { return _buyerGrpList; }
            set { _buyerGrpList = value; }
        }

        private Collection<string> _funcList;
        public Collection<string> FuncList
        {
            get { return _funcList; }
            set { _funcList = value; }
        }
    }
}

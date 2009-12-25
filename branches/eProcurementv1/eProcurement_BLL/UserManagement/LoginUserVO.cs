using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;

using System.Xml;

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

        private string _profileType;
        public string ProfileType
        {
            get { return _profileType; }
            set { _profileType = value; }
        }

        private string _supplierId;
        public string SupplierId
        {
            get { return _supplierId; }
            set { _supplierId = value; }
        }

        private string _supplierName;
        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }

        private string _supplierAddr;
        public string SupplierAddr
        {
            get { return _supplierAddr; }
            set { _supplierAddr = value; }
        }

        private string _role;
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        private Collection<string> _purchaseGrpList;
        public Collection<string> PurchaseGrpList
        {
            get { return _purchaseGrpList; }
            set { _purchaseGrpList = value; }
        }

        private Collection<string> _funcList;
        public Collection<string> FuncList
        {
            get { return _funcList; }
            set { _funcList = value; }
        }

        private XmlDocument _menuXML = null;
        public XmlDocument MenuXML
        {
            get { return _menuXML; }
            set { _menuXML = value; }
        }
    }
}
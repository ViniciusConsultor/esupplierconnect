using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class AccessMatrix
    {
        string userRole;
        public string UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }

        string profileType;
        public string ProfileType
        {
            get { return profileType; }
            set { profileType = value; }
        }

        string functionId;
        public string FunctionID
        {
            get { return functionId; }
            set { functionId = value; }
        }

    }
}

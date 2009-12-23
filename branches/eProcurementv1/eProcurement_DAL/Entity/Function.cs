using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class Function
    {
        string functionId;
        public string FunctionID
        {
            get { return functionId; }
            set { functionId = value; }
        }

        string functionName;
        public string FunctionName
        {
            get { return functionName; }
            set { functionName = value; }
        }
    }
}

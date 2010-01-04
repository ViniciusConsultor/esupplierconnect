using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace eProcurement_DAL
{
    public abstract class IExecuteCommandDAO
    {
        public abstract void ExpeditePurchase(EpTransaction epTran);
    }
}

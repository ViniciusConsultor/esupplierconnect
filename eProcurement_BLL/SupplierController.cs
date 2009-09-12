using System;
using System.Collections.Generic;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL
{
    public class SupplierController
    {
        public static Supplier GetSupplier(string supplierId) 
        {
            return SupplierDAO.RetrieveByKey(supplierId);
        }

    }
}

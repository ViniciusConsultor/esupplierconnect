using System;
using System.Collections.Generic;
using System.Text;
using eProcurement_DAL;

using eProcurement_BLL.UserManagement; 

namespace eProcurement_BLL
{
    public class SupplierController
    {
        MainController mainController = null;
        public SupplierController(MainController mainController) 
        {
            this.mainController = mainController;
        }
        
        public Supplier GetSupplier(string supplierId) 
        {
            return mainController.GetDAOCreator().CreateSupplierDAO().RetrieveByKey(supplierId);
        }

    }
}

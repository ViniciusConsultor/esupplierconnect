using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; 
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

        public Collection<Supplier> GetSupplierList(string supplierId,string supplierName)
        {
            try
            {
                string whereCluase = "";
                string orderCluase = "";
                whereCluase = " LIFNR like '" + Utility.EscapeSQL(supplierId) + "'";
                whereCluase += " AND [NAME] like '" + Utility.EscapeSQL(supplierName) + "' ";

                orderCluase = " LIFNR asc ";
                return this.mainController.GetDAOCreator().CreateSupplierDAO().RetrieveByQuery(whereCluase, orderCluase);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }
        public Collection<Supplier> GetSupplierList()
        {
            try
            {
                string whereCluase = "";
                string orderCluase = "";
                whereCluase = "";               

                orderCluase = " LIFNR asc ";
                return this.mainController.GetDAOCreator().CreateSupplierDAO().RetrieveByQuery(whereCluase, orderCluase);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public string GetSupplierEmailAddr(string supplierId)
        {
            try
            {
                string emailAddr = "";

                Supplier supplier = mainController.GetDAOCreator().CreateSupplierDAO().RetrieveByKey(supplierId);
                if (supplier != null) 
                {
                    emailAddr = supplier.EmailID;
                }

                return emailAddr;
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

    }
}

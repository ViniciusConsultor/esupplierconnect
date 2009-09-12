using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; 
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL
{
    public class PurchaseOrderController
    {
        public static Collection<PurchaseOrderHeaderText> SearchPurchaseOrder() 
        {
            try
            {
                return PurchaseOrderHeaderTextDAO.RetrieveByQuery("");   
            }
            catch (Exception ex) 
            {
                Utility.ExceptionLog(ex); 
                throw (ex);
            }
        }
    }
}

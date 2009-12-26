using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; 
using System.Text;
using eProcurement_DAL;
using eProcurement_BLL.UserManagement; 

namespace eProcurement_BLL
{

    public class QuotationController
    {
        MainController mainController = null;
        public QuotationController(MainController mainController) 
        {
            this.mainController = mainController;
        }

        public QuotationItem GetQuotation(string QuotationId, string RequestSeq) 
        {
          return mainController.GetDAOCreator().CreateQuotationItemDAO().RetrieveByKey(QuotationId,RequestSeq);           
        }
                
        public Collection<QuotationItem> GetQuotationList(string MaterialNo)
        {
            try
            {
                string whereCluase = "";                
                whereCluase = " MATNR like '" + Utility.EscapeSQL(MaterialNo) + "'";
                //orderCluase = " BANFN asc ";
                return this.mainController.GetDAOCreator().CreateQuotationItemDAO().RetrieveByQuery(whereCluase);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

    }
    
}

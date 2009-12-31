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

        public Collection<QuotationHeader> GetQuotationHeaderList(string quotationNumber, Nullable<long> quotationFromDate, Nullable<long> quotationToDate, Nullable<long> expiryFromDate, Nullable<long> expiryToDate, string requestNumber, string supplierId)
        {
            try
            {
                string whereCluase = "";
                string orderCluase = "";

                whereCluase = " 1=1";

                //if (string.Compare(loginUser.ProfileType.Trim(), ProfileType.Supplier, true) == 0)
                //{
                //    whereCluase += " AND TRIM(LTRIM(LIFNR)) = '" + this.mainController.GetLoginUserVO().SupplierId.Trim() + "'";
                //}

                //if (string.Compare(mainController.GetLoginUserVO().ProfileType, ProfileType.Buyer, true) == 0)
                //{
                //    //pending filter by purchase group
                //}

                if (supplierId != "")
                {
                    whereCluase += " AND RTRIM(LTRIM(LIFNR))='" + Utility.EscapeSQL(supplierId.Trim()) + "' ";
                }  
                if (quotationNumber.Trim() != "")
                {
                    whereCluase += " AND RTRIM(LTRIM(ANGNR)) like '" + Utility.EscapeSQL(quotationNumber.Trim()) + "' ";
                }
                if (requestNumber != "")
                {
                    whereCluase += " AND RTRIM(LTRIM(EBELN)) like '" + Utility.EscapeSQL(requestNumber.Trim()) + "' ";
                }
                if (quotationFromDate.HasValue)
                {
                    whereCluase += " AND KDATB >= " + quotationFromDate.Value;
                }
                if (quotationToDate.HasValue)
                {
                    whereCluase += " AND KDATB <= " + quotationToDate.Value;
                }
                if (expiryFromDate.HasValue)
                {
                    whereCluase += " AND ANGDT >= " + expiryFromDate.Value;
                }
                if (expiryToDate.HasValue)
                {
                    whereCluase += " AND ANGDT <= " + expiryToDate.Value;
                }

                orderCluase = " ANGNR ASC ";
                return this.mainController.GetDAOCreator().CreateQuotationHeaderDAO().RetrieveByQuery(whereCluase, orderCluase);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

    }
    
}

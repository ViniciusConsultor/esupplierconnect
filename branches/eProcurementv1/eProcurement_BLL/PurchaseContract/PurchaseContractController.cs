using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL.PurchaseContract
{
    public class PurchaseContractController
    {
        MainController mainController = null;
        public PurchaseContractController(MainController mainController) 
        {
            this.mainController = mainController;
        }

        public ContractHeader GetContractHeader(string contractNumber)
        {
            return mainController.GetDAOCreator().CreateContractHeaderDAO().RetrieveByKey(contractNumber);
        }

        public Collection<ContractItem> GetPurchaseContractItems(string contractNumber)
        {
            try
            {
                string whereClause = " EBELN='" + Utility.EscapeSQL(contractNumber) + "' ";
                string orderClause = " EBELP asc ";

                return mainController.GetDAOCreator().CreateContractItemDAO() 
                    .RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Collection<ContractHeader> SearchPurchaseContract(string contractNumber, Nullable<long> contractFromDate, Nullable<long> contractToDate, Nullable<long> expiryFromDate, Nullable<long> expiryToDate,string supplierId,string status)
        {
            try
            {
                string whereClause = "";
                string orderClause = "";
                whereClause = " 1=1 ";
                if (contractNumber != "")
                {
                    contractNumber += " AND EBELN like '" + Utility.EscapeSQL(contractNumber) + "' ";
                }
                if (supplierId != "")
                {
                    whereClause += " AND LIFNR like '" + Utility.EscapeSQL(supplierId) + "' ";
                }
                if (contractFromDate.HasValue)
                {
                    whereClause += " AND BEDAT >= " + contractFromDate.Value;
                }
                if (contractToDate.HasValue)
                {
                    whereClause += " AND BEDAT <= " + contractToDate.Value;
                }
                if (expiryFromDate.HasValue)
                {
                    whereClause += " AND KDATE >= " + expiryFromDate.Value;
                }
                if (expiryToDate.HasValue)
                {
                    whereClause += " AND KDATE <= " + expiryToDate.Value;
                }
                if (status != "")
                {
                    whereClause += " AND ACKSTS like '" + Utility.EscapeSQL(status) + "' ";
                }
                
                orderClause = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreateContractHeaderDAO().RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }
    }
}
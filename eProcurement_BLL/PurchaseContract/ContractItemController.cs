using System;
using System.Collections.Generic;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL.PurchaseContract
{
    public class ContractItemController
    {
        MainController mainController = null;
        public ContractItemController(MainController mainController) 
        {
            this.mainController = mainController;
        }

        public ContractItem GetPurchaseOrderItem(string contractNumber,string contractItemSeq)
        {
            try
            {
                return mainController.GetDAOCreator().CreateContractItemDAO()
                    .RetrieveByKey(contractNumber, contractItemSeq);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }
        public Collection<ContractItem> GetPurchaseOrderItems(string contractNumber)
        {
            try
            {
                string whereClause = " EBELN='" + Utility.EscapeSQL(contractNumber) + "' ";
                whereClause += " AND isnull(STS2,'')<>'D' ";
                string orderClause = " EBELP asc ";

                return mainController.GetDAOCreator().
                    CreateContractItemDAO().RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

    }
}

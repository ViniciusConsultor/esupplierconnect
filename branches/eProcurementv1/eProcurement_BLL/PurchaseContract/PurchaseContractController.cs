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

        public void AcknowledgePurchaseContract(Collection<ContractHeader> expeditings)
        {
            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {
                    foreach (ContractHeader vo in contheader)
                    {
                        ContractHeader contheader = mainController.GetDAOCreator().CreateContractHeaderDAO()
                            .RetrieveByKey(vo.ContractNumber);
                        if (contheader == null)
                        {
                            throw new Exception(string.Format("Purchase contract record doesn't exist. Contract Number:{0}.",
                                vo.ContractNumber));
                        }

                        if (string.Compare(contheader.AcknowledgeStatus, ContractAckStatus.Yes, true) != 0)
                        {
                            throw new Exception(string.Format("Purchase contract record has already been updated by other user. Contract Number:{0}.",
                                vo.ContractNumber));
                        }

                        //bool isFirst = true;
                        //if (vo.PromiseDate2.HasValue)
                        //    isFirst = false;

                        contheader.AcknowledgeStatus = ContractAckStatus.Yes;
                        
                        mainController.GetDAOCreator().CreateContractHeaderDAO()
                                .Update(tran, contheader);
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw (ex);
                }
                finally
                {
                    tran.Dispose();
                }
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

    }
}

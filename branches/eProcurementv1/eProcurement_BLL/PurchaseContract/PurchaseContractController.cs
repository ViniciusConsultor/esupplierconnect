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

                if (string.Compare(mainController.GetLoginUserVO().ProfileType, ProfileType.Supplier, true) == 0)
                {
                    whereClause += " LIFNR = '" + this.mainController.GetLoginUserVO().SupplierId + "'";
                }

                if (string.Compare(mainController.GetLoginUserVO().ProfileType, ProfileType.Buyer, true) == 0)
                {
                    whereClause = " USERID = '" + Utility.EscapeSQL(mainController.GetLoginUserVO().UserId) + "'";
                    Collection<PurchaseGroup> groups = mainController.GetDAOCreator().CreatePurchaseGroupDAO().RetrieveByQuery(whereClause);
                    string whereClauseSub = "";
                    foreach (PurchaseGroup group in groups)
                    {
                        if (whereClauseSub == "")
                        {
                            whereClauseSub += "(";
                        }
                        else
                        {
                            whereClauseSub += " or ";
                        }
                        whereClauseSub += "EKGRP='" + Utility.EscapeSQL(group.PurGroup.Trim()) + "'";
                    }
                    if (whereClauseSub != "")
                        whereClauseSub += ") ";
                    else
                        whereClauseSub = " 1=2 ";

                    whereClause =  whereClauseSub;
                }

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
                    whereClause += " AND ISNULL(ACKSTS,'N') like '" + Utility.EscapeSQL(status) + "' ";
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

        public void AcknowledgePurchaseContract(string contractNumber)
        {
            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {
                   
                    ContractHeader contheader = mainController.GetDAOCreator().CreateContractHeaderDAO()
                        .RetrieveByKey(contractNumber);
                    if (contheader == null)
                    {
                        throw new Exception(string.Format("Purchase contract record doesn't exist. Contract Number:{0}.",
                            contractNumber));
                    }

                    if (string.Compare(contheader.AcknowledgeStatus, ContractAckStatus.Yes, true) != 0)
                    {
                        throw new Exception(string.Format("Purchase contract record has already been updated by other user. Contract Number:{0}.",
                            contractNumber));
                    }

                    contheader.AcknowledgeStatus = ContractAckStatus.Yes;
                    
                    mainController.GetDAOCreator().CreateContractHeaderDAO()
                            .Update(tran, contheader);

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

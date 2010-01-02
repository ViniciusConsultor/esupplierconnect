using System;
using System.Collections.Generic;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL.PurchaseContract
{
    public class ContractHeaderController
    {
         MainController mainController = null;
        public ContractHeaderController(MainController mainController) 
        {
            this.mainController = mainController;
        }

        public ContractHeader GetContractHeader(string orderNumber)
        {
            return mainController.GetDAOCreator().CreateContractHeaderDAO().RetrieveByKey(contractNumber);
        }

        public Collection<ContractHeader> GetPendingAckContractList(string contractNumber, Nullable<long> contractfromDate, Nullable<long> contracttoDate, Nullable<long> expiryfromDate, Nullable<long> expirytoDate)
        {
            try
            {
                string whereCluase = "";
                string orderCluase = "";
                whereCluase = " LIFNR = '" + this.mainController.GetLoginUserVO().SupplierId + "'";
                whereCluase += " AND isnull(ACKSTS,'') = '" + ContractAckStatus.No + "' ";
                //whereCluase += " AND isnull(STAT,'') <> '" + POStatus.Delete + "' ";
                if (orderNumber != "")
                {
                    whereCluase += " AND EBELN like '" + Utility.EscapeSQL(contractNumber) + "' ";
                }
               
                if (fromDate.HasValue)
                {
                    whereCluase += " AND BEDAT >= " + contractfromDate.Value;
                }
                if (toDate.HasValue)
                {
                    whereCluase += " AND BEDAT <= " + contracttoDate.Value;
                }

                orderCluase = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreateContractHeaderDAO().RetrieveByQuery(whereCluase, orderCluase);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }
        public Collection<PurchaseOrderHeader> GetPendingConfirmContractList(string contractNumber, Nullable<long> contractfromDate, Nullable<long> contracttoDate, Nullable<long> expiryfromDate, Nullable<long> expirytoDate, string supplierId)
        {
            try
            {
                string whereCluase = "";
                string orderCluase = "";
                whereCluase = " isnull(ACKSTS,'') = '" + ContractAckStatus.Yes + "' ";

                //pending filter by purchase group


                if (orderNumber != "")
                {
                    whereCluase += " AND EBELN like '" + Utility.EscapeSQL(contractNumber) + "' ";
                }
                
                if (supplierId != "")
                {
                    whereCluase += " AND LIFNR like '" + Utility.EscapeSQL(supplierId) + "' ";
                }
                if (contractfromDate.HasValue)
                {
                    whereCluase += " AND BEDAT >= " + contractfromDate.Value;
                }
                if (contracttoDate.HasValue)
                {
                    whereCluase += " AND BEDAT <= " + contracttoDate.Value;
                }
                if (expiryfromDate.HasValue)
                {
                    whereCluase += " AND KDATB >= " + expiryfromDate.Value;
                }
                if (expirytoDate.HasValue)
                {
                    whereCluase += " AND KDATE <= " + expirytoDate.Value;
                }
                orderCluase = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreateContractHeaderDAO().RetrieveByQuery(whereCluase, orderCluase);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }
        public Collection<ContractHeader> EnquiryContractList(string contractNumber, Nullable<long> contractfromDate, Nullable<long> contracttoDate, Nullable<long> expiryfromDate, Nullable<long> expirytoDate, string supplierId, string status)
        {
            try
            {
                string whereCluase = "";
                string orderCluase = "";

                //whereCluase = " isnull(STAT,'') <> '" + POStatus.Delete + "' ";

                if (string.Compare(mainController.GetLoginUserVO().ProfileType, ProfileType.Supplier, true) == 0)
                {
                    whereCluase += " AND LIFNR = '" + this.mainController.GetLoginUserVO().SupplierId + "'";
                }

                if (string.Compare(mainController.GetLoginUserVO().ProfileType, ProfileType.Buyer, true) == 0)
                {
                    //pending filter by purchase group
                }

                if (status != "")
                {
                    //Pending Acknowledgement
                    if (string.Compare(status, "PA", true) == 0)
                    {
                        whereCluase += " AND isnull(ACKSTS,'') = '" + ContractAckStatus.No + "' ";
                    }

                    //Pending Confirm Order Acknowledgement
                    if (string.Compare(status, "PC", true) == 0)
                    {
                        whereCluase += " AND isnull(ACKSTS,'') = '" + ContractAckStatus.Yes + "' ";
                        //whereCluase += " AND isnull(RECSTS,'') <> '" + PORecStatus.Accept + "' ";
                        //whereCluase += " AND isnull(RECSTS,'') <> '" + PORecStatus.Reject2 + "' ";
                    }

                    //Accepted
                    //if (string.Compare(status, "AC", true) == 0)
                    //{
                    //    whereCluase += " AND isnull(ACKSTS,'') = '" + ContractAckStatus.Yes + "' ";
                    //    whereCluase += " AND isnull(RECSTS,'') = '" + PORecStatus.Accept + "' ";
                    //}

                    //Accepted
                    //if (string.Compare(status, "RE", true) == 0)
                    //{
                    //    //whereCluase += " AND isnull(ACKSTS,'') = '" + POAckStatus.Yes + "' ";
                    //    whereCluase += " AND isnull(RECSTS,'') = '" + PORecStatus.Reject2 + "' ";
                    //}

                }

                if (contractNumber != "")
                {
                    whereCluase += " AND EBELN like '" + Utility.EscapeSQL(contractNumber) + "' ";
                }
                //if (buyerName != "")
                //{
                //    whereCluase += " AND BUYER like '" + Utility.EscapeSQL(buyerName) + "' ";
                //}
                if (supplierId != "")
                {
                    whereCluase += " AND LIFNR like '" + Utility.EscapeSQL(supplierId) + "' ";
                }
                if (contractfromDate.HasValue)
                {
                    whereCluase += " AND BEDAT >= " + contractfromDate.Value;
                }
                if (contracttoDate.HasValue)
                {
                    whereCluase += " AND BEDAT <= " + contracttoDate.Value;
                }
                if (expiryfromDate.HasValue)
                {
                    whereCluase += " AND BEDAT >= " + expiryfromDate.Value;
                }
                if (expirytoDate.HasValue)
                {
                    whereCluase += " AND BEDAT <= " + expirytoDate.Value;
                }

                orderCluase = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreateContractHeaderDAO().RetrieveByQuery(whereCluase, orderCluase);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public void AcknowledgePurchaseContract(Collection<ContractItem> contractitem)
        {
            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {
                    string orderNumber = schedules[0].PurchaseOrderNumber;
                    string itemSeq = "";
                    string scheduleSeq = "";

                    PurchaseOrderHeader header = mainController.GetDAOCreator().CreateContractHeaderDAO()
                        .RetrieveByKey(tran, contractNumber);

                    //Check whether the order has already been acknowledged 
                    if (string.Compare(header.AcknowledgeStatus, ContractAckStatus.Yes, true) == 0)
                    {
                        throw new Exception("The contract has already been acknowledged by other user.");
                    }

                    //Update Order header
                    header.AcknowledgeStatus = ContractAckStatus.Yes;
                    //header.RecordStatus = "";
                    mainController.GetDAOCreator().CreateContractHeaderDAO().Update(tran, header);

                    //Update Order Item
                    foreach (PurchaseOrderItemSchedule schedule in schedules)
                    //{
                    //    scheduleSeq = schedule.PurchaseOrderScheduleSequence;

                    //    //Update Order Item
                    //    if (string.Compare(itemSeq, schedule.PurchaseOrderItemSequence, false) != 0)
                    //    {
                    //        PurchaseOrderItem item = mainController.GetDAOCreator().CreatePurchaseOrderItemDAO()
                    //            .RetrieveByKey(tran, orderNumber, schedule.PurchaseOrderItemSequence);
                    //        item.AcknowledgementStatus = POAckStatus.Yes;
                    //        mainController.GetDAOCreator().CreatePurchaseOrderItemDAO().Update(tran, item);
                    //        itemSeq = schedule.PurchaseOrderItemSequence;
                    //    }

                    //    //Update Order Item Schedule
                    //    scheduleSeq = schedule.PurchaseOrderScheduleSequence;
                    //    PurchaseOrderItemSchedule scheduleUpdt = mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO()
                    //        .RetrieveByKey(tran, orderNumber, schedule.PurchaseOrderItemSequence, scheduleSeq);
                    //    scheduleUpdt.AcknowledgementDate = schedule.AcknowledgementDate;
                    //    mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO()
                    //        .Update(tran, scheduleUpdt);

                    //}
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL.PurchaseOrder
{
    public class OrderHeaderController
    {
        MainController mainController = null;
        public OrderHeaderController(MainController mainController) 
        {
            this.mainController = mainController;
        }

        public PurchaseOrderHeader GetPurchaseOrderHeader(string orderNumber)
        {
            return mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().RetrieveByKey(orderNumber);
        }

        public Collection<PurchaseHeaderText> GetPurchaseOrderHeaderText(string orderNumber)
        {
            try
            {
                string whereClause = " EBELN='" + Utility.EscapeSQL(orderNumber) + "' ";
                whereClause += " AND isnull(RECSTS,'')<>'D' ";
                string orderClause = " TXTITM asc ";
                return mainController.GetDAOCreator().
                    CreatePurchaseHeaderTextDAO().RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Collection<PurchaseOrderHeader> GetPendingAckPOList(string orderNumber, Nullable<long> fromDate, Nullable<long> toDate,string buyerName)
        {
            try
            {
                string whereCluase = "";
                string orderCluase = "";
                whereCluase = " LIFNR = '" + this.mainController.GetLoginUserVO().SupplierId + "'";
                whereCluase += " AND isnull(ACKSTS,'') = '" + POAckStatus.No + "' ";
                whereCluase += " AND isnull(STAT,'') <> '" + POStatus.Delete + "' ";
                if (orderNumber != "")
                {
                    whereCluase += " AND EBELN like '" + Utility.EscapeSQL(orderNumber) + "' ";
                }
                if (buyerName != "")
                {
                    whereCluase += " AND BUYER like '" + Utility.EscapeSQL(buyerName) + "' ";
                }  
                if (fromDate.HasValue)
                {
                    whereCluase += " AND BEDAT >= " + fromDate.Value;
                }
                if (toDate.HasValue)
                {
                    whereCluase += " AND BEDAT <= " + toDate.Value;
                }

                orderCluase = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().RetrieveByQuery(whereCluase, orderCluase);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Collection<PurchaseOrderHeader> GetPendingConfirmPOList(string orderNumber, Nullable<long> fromDate, Nullable<long> toDate, string buyerName, string supplierId)
        {
            try
            {
                string whereCluase = "";
                string orderCluase = "";
                whereCluase = " isnull(ACKSTS,'') = '" + POAckStatus.Yes + "' ";
                whereCluase += " AND isnull(RECSTS,'') <> '" + PORecStatus.Accept + "' ";
                whereCluase += " AND isnull(STAT,'') <> '" + POStatus.Delete + "' ";

                //pending filter by purchase group


                if (orderNumber != "")
                {
                    whereCluase += " AND EBELN like '" + Utility.EscapeSQL(orderNumber) + "' ";
                }
                if (buyerName != "")
                {
                    whereCluase += " AND BUYER like '" + Utility.EscapeSQL(buyerName) + "' ";
                } 
                if (supplierId != "")
                {
                    whereCluase += " AND LIFNR like '" + Utility.EscapeSQL(supplierId) + "' ";
                }
                if (fromDate.HasValue)
                {
                    whereCluase += " AND BEDAT >= " + fromDate.Value;
                }
                if (toDate.HasValue)
                {
                    whereCluase += " AND BEDAT <= " + toDate.Value;
                }

                orderCluase = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().RetrieveByQuery(whereCluase, orderCluase);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Collection<PurchaseOrderHeader> EnquiryPOList(string orderNumber, Nullable<long> fromDate, Nullable<long> toDate, string buyerName, string supplierId,string status)
        {
            try
            {
                string whereCluase = "";
                string orderCluase = "";

                whereCluase = " isnull(STAT,'') <> '" + POStatus.Delete + "' ";

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
                        whereCluase += " AND isnull(ACKSTS,'') = '" + POAckStatus.No + "' ";
                    }

                    //Pending Confirm Order Acknowledgement
                    if (string.Compare(status, "PC", true) == 0)
                    {
                        whereCluase += " AND isnull(ACKSTS,'') = '" + POAckStatus.Yes + "' ";
                        whereCluase += " AND isnull(RECSTS,'') <> '" + PORecStatus.Accept + "' ";
                    }

                    //Accepted
                    if (string.Compare(status, "AC", true) == 0)
                    {
                        whereCluase += " AND isnull(ACKSTS,'') = '" + POAckStatus.Yes + "' ";
                        whereCluase += " AND isnull(RECSTS,'') = '" + PORecStatus.Accept + "' ";
                    }

                    //Accepted
                    if (string.Compare(status, "RE", true) == 0)
                    {
                        //whereCluase += " AND isnull(ACKSTS,'') = '" + POAckStatus.Yes + "' ";
                        whereCluase += " AND isnull(RECSTS,'') = '" + PORecStatus.Reject + "' ";
                    }
                   
                }

                if (orderNumber != "")
                {
                    whereCluase += " AND EBELN like '" + Utility.EscapeSQL(orderNumber) + "' ";
                }
                if (buyerName != "")
                {
                    whereCluase += " AND BUYER like '" + Utility.EscapeSQL(buyerName) + "' ";
                }
                if (supplierId != "")
                {
                    whereCluase += " AND LIFNR like '" + Utility.EscapeSQL(supplierId) + "' ";
                }
                if (fromDate.HasValue)
                {
                    whereCluase += " AND BEDAT >= " + fromDate.Value;
                }
                if (toDate.HasValue)
                {
                    whereCluase += " AND BEDAT <= " + toDate.Value;
                }

                orderCluase = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().RetrieveByQuery(whereCluase, orderCluase);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public void AcknowledgePurchaseOrder(Collection<PurchaseOrderItemSchedule> schedules) 
        {
          try
          {
              EpTransaction tran = DataManager.BeginTransaction();
              try
              {
                  string orderNumber = schedules[0].PurchaseOrderNumber;
                  string itemSeq = "";
                  string scheduleSeq = "";

                  PurchaseOrderHeader header = mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO()
                      .RetrieveByKey(tran,orderNumber);

                  //Check whether the order has already been acknowledged 
                  if (string.Compare(header.AcknowledgeStatus, POAckStatus.Yes, true) == 0) 
                  {
                      throw new Exception("The order has already been acknowledged by other user."); 
                  }

                  //Update Order header
                  header.AcknowledgeStatus = POAckStatus.Yes;
                  header.RecordStatus = "";
                  mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().Update(tran, header);

                  //Update Order Item
                  foreach (PurchaseOrderItemSchedule schedule in schedules) 
                  {
                      scheduleSeq = schedule.PurchaseOrderScheduleSequence;

                      //Update Order Item
                      if (string.Compare(itemSeq, schedule.PurchaseOrderItemSequence, false) != 0) 
                      {
                          PurchaseOrderItem item = mainController.GetDAOCreator().CreatePurchaseOrderItemDAO()
                              .RetrieveByKey(tran, orderNumber, schedule.PurchaseOrderItemSequence);
                          item.AcknowledgementStatus = POAckStatus.Yes;
                          mainController.GetDAOCreator().CreatePurchaseOrderItemDAO().Update(tran, item);
                          itemSeq = schedule.PurchaseOrderItemSequence;
                      }

                      //Update Order Item Schedule
                      scheduleSeq = schedule.PurchaseOrderScheduleSequence;
                      PurchaseOrderItemSchedule scheduleUpdt = mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO()
                          .RetrieveByKey(tran, orderNumber, schedule.PurchaseOrderItemSequence, scheduleSeq);
                      scheduleUpdt.AcknowledgementDate = schedule.AcknowledgementDate;
                      mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO()
                          .Update(tran, scheduleUpdt);

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

        public void ConfirmOrderAcknowledgement(string orderNumber,bool accept)
        {
            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {

                    PurchaseOrderHeader header = mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO()
                        .RetrieveByKey(tran, orderNumber);

                    //Check whether the order has already been acknowledged 
                    if (!string.IsNullOrEmpty(header.RecordStatus.Trim()))
                    {
                        throw new Exception("The order has already been accepted or rejected by other user.");
                    }

                    //Update Order header
                    header.AcknowledgeStatus = POAckStatus.No;
                    if (accept)
                        header.RecordStatus = PORecStatus.Accept;
                    else 
                    {
                        header.AcknowledgeStatus = POAckStatus.No;
                        header.RecordStatus = PORecStatus.Reject;
                    }

                    mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().Update(tran, header);

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

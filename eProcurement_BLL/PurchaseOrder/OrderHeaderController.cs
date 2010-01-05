using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;
using eProcurement_BLL.Notification;

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
                string whereClause = "";
                string orderClause = "";
                whereClause = " LIFNR = '" + this.mainController.GetLoginUserVO().SupplierId + "'";
                whereClause += " AND isnull(ACKSTS,'') = '" + POAckStatus.No + "' ";
                whereClause += " AND isnull(LOEKZ,'') <> '" + POStatus.Delete + "' ";
                whereClause += " AND isnull(LOEKZ,'') <> '" + POStatus.Complete + "' ";
                if (orderNumber != "")
                {
                    whereClause += " AND EBELN like '" + Utility.EscapeSQL(orderNumber) + "' ";
                }
                if (buyerName != "")
                {
                    whereClause += " AND BUYER like '" + Utility.EscapeSQL(buyerName) + "' ";
                }  
                if (fromDate.HasValue)
                {
                    whereClause += " AND BEDAT >= " + fromDate.Value;
                }
                if (toDate.HasValue)
                {
                    whereClause += " AND BEDAT <= " + toDate.Value;
                }

                orderClause = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Collection<PurchaseOrderHeader> GetPendingAckByBuyerPOList(string orderNumber, Nullable<long> fromDate, Nullable<long> toDate, string buyerName, string supplierId)
        {
            try
            {
                string whereClause = "";
                string orderClause = "";

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

                whereClause = whereClauseSub;

                whereClause += " AND isnull(ACKSTS,'') = '" + POAckStatus.No + "' ";
                whereClause += " AND isnull(LOEKZ,'') <> '" + POStatus.Delete + "' ";
                whereClause += " AND isnull(LOEKZ,'') <> '" + POStatus.Complete + "' ";


                if (supplierId != "")
                {
                    whereClause += " AND LIFNR like '" + Utility.EscapeSQL(supplierId) + "' ";
                }
                if (orderNumber != "")
                {
                    whereClause += " AND EBELN like '" + Utility.EscapeSQL(orderNumber) + "' ";
                }
                if (buyerName != "")
                {
                    whereClause += " AND BUYER like '" + Utility.EscapeSQL(buyerName) + "' ";
                }  
                if (fromDate.HasValue)
                {
                    whereClause += " AND BEDAT >= " + fromDate.Value;
                }
                if (toDate.HasValue)
                {
                    whereClause += " AND BEDAT <= " + toDate.Value;
                }

                orderClause = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().RetrieveByQuery(whereClause, orderClause);
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
                string whereClause = "";
                string orderClause = "";

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

                whereClause = whereClauseSub;

                whereClause += " AND isnull(ACKSTS,'') = '" + POAckStatus.Yes + "' ";
                whereClause += " AND isnull(RECSTS,'') <> '" + PORecStatus.Accept + "' ";
                whereClause += " AND isnull(LOEKZ,'') <> '" + POStatus.Delete + "' ";
                whereClause += " AND isnull(LOEKZ,'') <> '" + POStatus.Complete + "' ";

                if (orderNumber != "")
                {
                    whereClause += " AND EBELN like '" + Utility.EscapeSQL(orderNumber) + "' ";
                }
                if (!string.IsNullOrEmpty(buyerName))
                {
                    whereClause += " AND BUYER like '" + Utility.EscapeSQL(buyerName) + "' ";
                } 
                if (!string.IsNullOrEmpty(supplierId))
                {
                    whereClause += " AND LIFNR like '" + Utility.EscapeSQL(supplierId) + "' ";
                }
                if (fromDate.HasValue)
                {
                    whereClause += " AND BEDAT >= " + fromDate.Value;
                }
                if (toDate.HasValue)
                {
                    whereClause += " AND BEDAT <= " + toDate.Value;
                }

                orderClause = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().RetrieveByQuery(whereClause, orderClause);
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
                string whereClause = "";
                string orderClause = "";

                if (string.Compare(mainController.GetLoginUserVO().ProfileType, ProfileType.Supplier, true) == 0) 
                {
                    whereClause = " LIFNR = '" + this.mainController.GetLoginUserVO().SupplierId + "'";
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

                    whereClause = whereClauseSub;
                }

                whereClause += " AND isnull(LOEKZ,'') <> '" + POStatus.Delete + "' ";

                if (status != "")
                {
                    //Pending Acknowledgement
                    if (string.Compare(status, "PA", true) == 0) 
                    {
                        whereClause += " AND isnull(ACKSTS,'') = '" + POAckStatus.No + "' ";
                    }

                    //Pending Confirm Order Acknowledgement
                    if (string.Compare(status, "PC", true) == 0)
                    {
                        whereClause += " AND isnull(ACKSTS,'') = '" + POAckStatus.Yes + "' ";
                        whereClause += " AND isnull(RECSTS,'') <> '" + PORecStatus.Accept + "' ";
                        whereClause += " AND isnull(RECSTS,'') <> '" + PORecStatus.Reject2 + "' ";
                    }

                    //Accepted
                    if (string.Compare(status, "AC", true) == 0)
                    {
                        whereClause += " AND isnull(ACKSTS,'') = '" + POAckStatus.Yes + "' ";
                        whereClause += " AND isnull(RECSTS,'') = '" + PORecStatus.Accept + "' ";
                    }

                    //Reject
                    if (string.Compare(status, "RE", true) == 0)
                    {
                        //whereClause += " AND isnull(ACKSTS,'') = '" + POAckStatus.Yes + "' ";
                        whereClause += " AND isnull(RECSTS,'') = '" + PORecStatus.Reject2 + "' ";
                    }

                    //Complete
                    if (string.Compare(status, "CP", true) == 0)
                    {
                        //whereClause += " AND isnull(ACKSTS,'') = '" + POAckStatus.Yes + "' ";
                        whereClause += " AND isnull(LOEKZ,'') = '" + POStatus.Complete + "' ";
                    }
                   
                }

                if (orderNumber != "")
                {
                    whereClause += " AND EBELN like '" + Utility.EscapeSQL(orderNumber) + "' ";
                }
                if (buyerName != "")
                {
                    whereClause += " AND BUYER like '" + Utility.EscapeSQL(buyerName) + "' ";
                }
                if (supplierId != "")
                {
                    whereClause += " AND LIFNR like '" + Utility.EscapeSQL(supplierId) + "' ";
                }
                if (fromDate.HasValue)
                {
                    whereClause += " AND BEDAT >= " + fromDate.Value;
                }
                if (toDate.HasValue)
                {
                    whereClause += " AND BEDAT <= " + toDate.Value;
                }

                orderClause = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().RetrieveByQuery(whereClause, orderClause);
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
                  header.AcknowledgeBy  = mainController.GetLoginUserVO().UserId;
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

                  //Send Notificatio
                  Collection<string> buyerEmailList = mainController.GetUserController().GetBuyerEmailAddrs(header.PurchaseGroup);
                  if (buyerEmailList.Count == 0)
                      buyerEmailList.Add(NotificationMessage.buyerEmail);
                  foreach (string email in buyerEmailList) 
                  {
                      eProcurement_DAL.Notification notification = new eProcurement_DAL.Notification();
                      notification.NotificationType = NotificationMessage.OrderAcknowledged;
                      notification.NotificationDate = Utility.GetStoredDateValue(DateTime.Now);
                      notification.ReferenceNumber = header.OrderNumber;
                      notification.ReferenceSequence = "";

                      string sDate = "";
                      if (header.OrderDate.HasValue)
                          sDate = Utility.GetShortDate(Utility.GetDateTimeFormStoredValue(header.OrderDate.Value)); 
                      notification.Message = string.Format("Order Number:{0} Dated: {1} has been Acknowledged please accept or reject the acknowledgement.",
                            header.OrderNumber, sDate);
                     
                      notification.Sender = header.SupplierId;
                      notification.Recipient = NotificationMessage.buyerRecepient;
                      notification.Email = email.Trim();
                      notification.Status = "0";
                      mainController.GetNotificationController().InsertEmailNotification(tran,notification);  
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

        public void AcknowledgePurchaseOrderByBuyer(Collection<PurchaseOrderItemSchedule> schedules) 
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
                  header.RecordStatus = PORecStatus.Accept;
                  header.AcknowledgeBy = mainController.GetLoginUserVO().UserId;
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
        
        public int ConfirmOrderAcknowledgement(string orderNumber,bool accept)
        {
            try
            {
                int iReturn = 0;
                
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {

                    PurchaseOrderHeader header = mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO()
                        .RetrieveByKey(tran, orderNumber);

                    //Check whether the order has already been acknowledged 
                    if (string.Compare(header.RecordStatus.Trim(),PORecStatus.Accept,true)==0 ||
                        string.Compare(header.RecordStatus.Trim(),PORecStatus.Reject2,true)==0)
                    {
                        throw new Exception("The order has already been accepted or rejected by other user.");
                    }

                    //Update Order header
                    if (accept)
                    {
                        header.RecordStatus = PORecStatus.Accept;
                        iReturn=1;
                    }
                    else 
                    {
                        if (string.Compare(header.RecordStatus, PORecStatus.Reject1, true) == 0)
                        {
                            header.RecordStatus = PORecStatus.Reject2;
                            iReturn = 2;
                        }
                        else 
                        {
                            header.AcknowledgeStatus = POAckStatus.No;
                            header.RecordStatus = PORecStatus.Reject1;
                            iReturn = 3;

                            //Send Notificatio
                            string email = mainController.GetSupplierController().GetSupplierEmailAddr(header.SupplierId);
                            if (!string.IsNullOrEmpty(email)) 
                            {
                                eProcurement_DAL.Notification notification = new eProcurement_DAL.Notification();
                                notification.NotificationType = NotificationMessage.OrderAckFirstReject;
                                notification.NotificationDate = Utility.GetStoredDateValue(DateTime.Now);
                                notification.ReferenceNumber = header.OrderNumber;
                                notification.ReferenceSequence = "";

                                string sDate = "";
                                if (header.OrderDate.HasValue)
                                    sDate = Utility.GetShortDate(Utility.GetDateTimeFormStoredValue(header.OrderDate.Value)); 
                                notification.Message = string.Format("Order Number:{0} Dated: {1} acknowledgement has been rejected by Fujitec Buyer: {2}.",
                                      header.OrderNumber, sDate, mainController.GetLoginUserVO().UserName);

                                notification.Sender = mainController.GetLoginUserVO().UserName;
                                notification.Recipient = header.SupplierId;
                                notification.Email = email.Trim();
                                notification.Status = "0";
                                mainController.GetNotificationController().InsertEmailNotification(tran, notification);
                            }
                        } 
                    }

                    mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().Update(tran, header);

                    tran.Commit();
                    return iReturn;
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

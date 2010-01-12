using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; 
using System.Text;
using eProcurement_DAL;
using eProcurement_BLL.UserManagement;
using eProcurement_BLL.Notification;

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

        public Collection<QuotationHeader> GetQuotationHeader(string quotationNumber)
        {
            try
            {
                string whereCluase = "";
                string orderCluase = "";

                whereCluase = " 1=1";

                //if (string.Compare(loginUser.ProfileType.Trim(), ProfileType.Supplier, true) == 0)
                //{
                 //   whereCluase += " AND TRIM(LTRIM(LIFNR)) = '" + this.mainController.GetLoginUserVO().SupplierId.Trim() + "'";
                //}

              // if (supplierId != "")
                //{
                   // whereCluase += " AND RTRIM(LTRIM(LIFNR))='" + Utility.EscapeSQL(supplierId.Trim()) + "' ";
               // }
                if (quotationNumber.Trim() != "")
                {
                    whereCluase += " AND RTRIM(LTRIM(ANGNR)) like '" + Utility.EscapeSQL(quotationNumber.Trim()) + "' ";
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

        public int SubmitQuotation(string quotationNumber, bool status)
        {
            try
            {
                int iReturn = 0;

                EpTransaction tran = DataManager.BeginTransaction();
                try
                {

                    QuotationHeader header = mainController.GetDAOCreator().CreateQuotationHeaderDAO()
                        .RetrieveByKey(tran, quotationNumber);

                    //Check whether the quotation has already been acknowledged 
                    if (string.Compare(header.RecordStatus.Trim(), QuotationStatus.Accept, true) == 0 ||
                        string.Compare(header.RecordStatus.Trim(), QuotationStatus.Reject, true) == 0 ||
                        string.Compare(header.RecordStatus.Trim(), QuotationStatus.Acknowledge , true) == 0)

                    {
                        throw new Exception("The quotation has already been acknowledged or accepted or rejected by other user.");
                    }

                    //Update Quotation header
                   // if (acknowledge)
                   // {
                      //  header.RecordStatus = QuotationStatus.Acknowledge;
                       // iReturn = 1;
                    //}
                    //else
                    //if (accept)
                    //{
                     //   header.RecordStatus = QuotationStatus.Accept;
                      //  iReturn = 2;
                    //}
                    else
                    {
                        if (string.Compare(header.RecordStatus, QuotationStatus.Reject, true) == 0)
                        {
                            header.RecordStatus = QuotationStatus.Reject;
                            iReturn = 3;
                        }
                        else
                        {
                           // header.RecordStatus = QuotationStatus.No;
                        
                        }
                    }

                    mainController.GetDAOCreator().CreateQuotationHeaderDAO().Update(tran, header);

                    //Send Notificatio
                    Collection<string> buyerEmailList = new Collection<string>();
                    User user = mainController.GetDAOCreator().CreateUserDAO().RetrieveByKey(header.BuyerID);
                    if (user != null) 
                    {
                        if (!string.IsNullOrEmpty(user.UserEmail)) 
                        {
                            buyerEmailList.Add(user.UserEmail); 
                        } 
                    }
                    
                    if (buyerEmailList.Count == 0)
                        buyerEmailList.Add(NotificationMessage.buyerEmail);
                    foreach (string email in buyerEmailList)
                    {
                        eProcurement_DAL.Notification notification = new eProcurement_DAL.Notification();
                        notification.NotificationType = NotificationMessage.RFQUpdate;
                        notification.NotificationDate = Utility.GetStoredDateValue(DateTime.Now);
                        notification.ReferenceNumber = header.RequestNumber;
                        notification.ReferenceSequence = "";

                        string sDate = "";
                        if (header.QuotationExpiryDate.HasValue)
                            sDate = Utility.GetShortDate(Utility.GetDateTimeFormStoredValue(header.QuotationExpiryDate.Value));
                        notification.Message = string.Format("Request for Quotation:{0} Dated: {1} created please provide your quotation.",
                              header.RequestNumber, sDate);

                        notification.Sender = header.SupplierId;
                        notification.Recipient = NotificationMessage.buyerRecepient;
                        notification.Email = email.Trim();
                        notification.Status = "0";
                        mainController.GetNotificationController().InsertEmailNotification(tran, notification);
                    }

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

        public void CreateQuotationRequest(QuotationHeader quotationHeader, Collection<QuotationItem> quotationItems,Collection<Guid> attachmentIds ) 
        {
            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {
                    //Insert Quotation Header
                    mainController.GetDAOCreator().CreateQuotationHeaderDAO().Insert(tran, quotationHeader);

                    //Update Quotation Item
                    foreach (QuotationItem item in quotationItems) 
                    {
                        mainController.GetDAOCreator().CreateQuotationItemDAO().Insert(tran, item);
                    }
                    
                    //update Attachments
                    foreach (Guid attId in attachmentIds) 
                    {
                        Attachment att = mainController.GetDAOCreator().CreateAttachmentDAO(true).RetrieveByKey(tran, attId); 
                        if (att != null) 
                        {
                            att.RfqNumber = quotationItems[0].RequisitionNumber;
                            mainController.GetDAOCreator().CreateAttachmentDAO(true).Update(tran, att);
                        }
                    }

                    //Send Notificatio
                    string email = mainController.GetSupplierController().GetSupplierEmailAddr(quotationHeader.SupplierId);
                    if (!string.IsNullOrEmpty(email))
                    {
                        eProcurement_DAL.Notification notification = new eProcurement_DAL.Notification();
                        notification.NotificationType = NotificationMessage.RFQCreate;
                        notification.NotificationDate = Utility.GetStoredDateValue(DateTime.Now);
                        notification.ReferenceNumber = quotationHeader.RequestNumber;
                        notification.ReferenceSequence = "";

                        string sDate = "";
                        if (quotationHeader.ExpiryDate.HasValue)
                            sDate = Utility.GetShortDate(Utility.GetDateTimeFormStoredValue(quotationHeader.ExpiryDate.Value));
                        notification.Message = string.Format("Request for Quotation:{0}  Dated: {1} created please provide your quotation.",
                              quotationHeader.RequestNumber, sDate);
                        notification.Sender = this.mainController.GetLoginUserVO().UserName;
                        notification.Recipient = quotationHeader.SupplierId;
                        notification.Email = email.Trim();
                        notification.Status = "0";
                        mainController.GetNotificationController().InsertEmailNotification(tran, notification);
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

        public Collection<QuotationHeader> GetPendingProcessQuotationList(string supplierId)
        {
            try
            {
                string whereClause = "";
                string orderClause = "";
                //whereClause = " LIFNR = '" + this.mainController.GetLoginUserVO().SupplierId + "'";
                whereClause = " LIFNR = '" + supplierId + "'";
                
                whereClause += " AND isnull(RECSTS,'') = '" + QuotationStatus.Request + "' ";

                //if (orderNumber != "")
                //{
                //    whereClause += " AND EBELN like '" + Utility.EscapeSQL(orderNumber) + "' ";
                //}
                //if (itemSequence != "")
                //{
                //    whereClause += " AND EBELP like '" + Utility.EscapeSQL(itemSequence) + "' ";
                //}
                //if (documentNumber != "")
                //{
                //    whereClause += " AND DOCNO like '" + Utility.EscapeSQL(documentNumber) + "' ";
                //}
                //if (materialNumber != "")
                //{
                //    whereClause += " AND MATNR like '" + Utility.EscapeSQL(materialNumber) + "' ";
                //}

                //whereClause += " AND EBELN IN (SELECT EBELN FROM PURHDR WHERE LIFNR = '" + this.mainController.GetLoginUserVO().SupplierId + "')";
                orderClause = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreateQuotationHeaderDAO().RetrieveByQuery (whereClause, orderClause);
                //return this.mainController.GetDAOCreator().CreateDeliveryOrderDAO().RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);

            }
        }

    }
    
}

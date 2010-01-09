using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using SAPInterface;
using SAP.Connector;
using eProcurement_DAL;
using eProcurement_BLL;
using eProcurement_BLL.Notification;

namespace eProcurement_SAP
{
    public class InterfaceOrderController
    {
        private ZORDER_HDRTable     orderHeader;
        private ZORDER_ITMTable     orderItem;
        private ZORDER_SCHTable     orderSchedule;
        private ZORDER_COMPTable    orderComponent;
        private ZORDER_SRVTable     orderService;
        private ZORDER_SRVTSKTable  serviceTask;
        private ZORDER_HDRTXTTable  headerText;
        private ZORDER_ITMTXTTable  itemText;
        private ZORDER_HISTORYTable orderHistory;
        private ZORDER_CLOSETable   orderClose;

        private string aMsgstr = "";
        private int aRecCount = 0;
        private int aCount = 0;
        private InterfaceForm aForm;
        private MainController mainController;
        private Collection<Notification> notificationCollection;

        public InterfaceOrderController(InterfaceForm aForm, MainController mainController)
        {
            this.aForm = aForm;
            this.mainController = mainController;
        }

        public void GetPurchaseOrder()
        {
            RetrievePurchaseOrder retrieveOrder;
            notificationCollection = new Collection<Notification>();
            try
            {
                retrieveOrder = new RetrievePurchaseOrder();

                aForm.getLabel().Text = "Retrieval of Purchase Order Data  in Progress ....";
                aForm.getLabel().Refresh();

                retrieveOrder.GetPurchaseDetails();
                orderHeader    = retrieveOrder.GetOrderHeader();
                orderItem      = retrieveOrder.GetOrderItem();
                orderSchedule  = retrieveOrder.GetOrderSchedule();
                orderComponent = retrieveOrder.GetOrderComponent();
                orderService   = retrieveOrder.GetOrderService();
                serviceTask    = retrieveOrder.GetServiceTask();
                headerText     = retrieveOrder.GetOrderHeaderText();
                itemText       = retrieveOrder.GetOrderItemText();

                aForm.getLabel().Text = "Update of Purchase Order Data  in Progress ....";
                aForm.getLabel().Refresh();

                this.UpdatePurchaseOrder();
                this.RemoveOrderDetails();

                aForm.getLabel().Text = "Update of Purchase Order Data Completed";
                aForm.getLabel().Refresh();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public void GetPurchaseHistory()
        {
            RetrievePurchaseOrder retrieveOrder;
            try
            {
                retrieveOrder = new RetrievePurchaseOrder();

                aForm.getLabel().Text = "Retrieval of Purchase Order History Data  in Progress ....";
                aForm.getLabel().Refresh();

                retrieveOrder.GetPurchaseHistoryDetails();
                orderHistory = retrieveOrder.GetOrderHistory();
                orderClose = retrieveOrder.GetOrderClosed();

                aForm.getLabel().Text = "Update of Purchase Order History Data  in Progress ....";
                aForm.getLabel().Refresh();

                this.UpdatePurchaseHistory();
                retrieveOrder.UpdateHistoryControlDate();

                aForm.getLabel().Text = "Update of Purchase Order History Data Completed";
                aForm.getLabel().Refresh();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }

        }

        private void UpdatePurchaseOrder()
        {
           int wstep;

           try
           {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {
                    //---------------------------------------
                    // Get Purchase Order Header Details
                    //---------------------------------------
                    aRecCount = orderHeader.Count;
                    wstep = 10;
                    this.setParameters();
                    
                    foreach (ZORDER_HDR ordobj in orderHeader)
                    {
                        PurchaseOrderHeader pohdr = new PurchaseOrderHeader();
                        pohdr.OrderNumber = ordobj.Ebeln;
                        pohdr.OrderType = ordobj.Bstyp;
                        pohdr.OrderCategory = ordobj.Bsart;
                        pohdr.SupplierId = ordobj.Lifnr;
                        pohdr.OrderDate = Convert.ToInt64(ordobj.Bedat);
                        pohdr.PurchaseGroup = ordobj.Ekgrp;
                        pohdr.PurchaseOrg = ordobj.Ekorg;
                        pohdr.OrderAmount = Convert.ToDecimal(ordobj.Amtpr);
                        pohdr.GstAmount = Convert.ToDecimal(ordobj.Gstam);
                        pohdr.CurrencyCode = ordobj.Waers;
                        pohdr.PaymentTerms = ordobj.Zterm;
                        pohdr.BuyerName = ordobj.Buyer;
                        pohdr.BuyerPhone = ordobj.Telf1;
                        pohdr.CreateBy = ordobj.Ernam;
                        pohdr.AddressNumber = ordobj.Phone;
                        pohdr.SalesPerson = ordobj.Verkf;
                        pohdr.ShipmentAddress = ordobj.Laddr;
                        pohdr.Remarks = ordobj.Txt01;
                        pohdr.OrderStatus = ordobj.Loekz;
                        pohdr.AcknowledgeStatus = "N";
                        pohdr.RecordStatus = "";
                        pohdr.AcknowledgeBy = "";
                        pohdr.PurchaseGroup = ordobj.Ekgrp;
                        pohdr.PurchaseOrg = ordobj.Ekorg;

                        Notification notification = new Notification();
                        
                        if (mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().RetrieveByKey(tran, ordobj.Ebeln) != null)
                        {
                            mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().Update(tran, pohdr);
                            notification.NotificationType = NotificationMessage.OrderUpdate;
                            aMsgstr = "Order Number : " + ordobj.Ebeln + "Dated : " + ordobj.Bedat + " has been Amended please acknowledge";
                        }
                        else
                        {
                            mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().Insert(tran, pohdr);
                            notification.NotificationType = NotificationMessage.OrderCreate;
                            aMsgstr = "Please Acknowlegde Order Number: " + ordobj.Ebeln + "Dated : " + ordobj.Bedat;
                        }
                        notification.NotificationId = 0;
                        notification.NotificationDate = Convert.ToInt64(System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString().PadLeft(2, '0') + System.DateTime.Now.Day.ToString().PadLeft(2, '0'));
                        notification.ReferenceNumber = ordobj.Ebeln;
                        notification.ReferenceSequence = "";
                        notification.Recipient = ordobj.Lifnr;
                        notification.Sender = NotificationMessage.buyerSender;
                        notification.Message = aMsgstr;
                        notification.Email = mainController.GetSupplierController().GetSupplierEmailAddr(ordobj.Lifnr); ;
                        if (notification.Email == "")
                        {
                            notification.Email = NotificationMessage.buyerEmail;
                        }
                        notification.Status = "0";
                        notificationCollection.Add(notification);

                        aCount++;
                        aForm.getTextBox().Text = aCount.ToString();

                        aForm.getProgressBar().Increment(wstep);
                    }

                    //------------------------------------------
                    // Get Purchase Order Item Details
                    //------------------------------------------

                    aRecCount = orderItem.Count;
                    aCount = 0;
                    wstep = 10;
                    this.setParameters();

                    foreach (ZORDER_ITM itmobj in orderItem)
                    {
                        PurchaseOrderItem poitm = new PurchaseOrderItem();
                        poitm.PurchaseOrderNumber = itmobj.Ebeln;
                        poitm.PurchaseItemSequenceNumber = itmobj.Ebelp;
                        poitm.PurchaseOrderType = itmobj.Pstyp;
                        poitm.MaterialNumber = itmobj.Matnr;
                        poitm.ShortText = itmobj.Txz01;
                        poitm.OldMaterialNumber = itmobj.Bismt;
                        poitm.OrderQuantity = Convert.ToDecimal(itmobj.Menge);
                        poitm.PricePerUnit = Convert.ToDecimal(itmobj.Peinh);
                        poitm.UnitofMeasure = itmobj.Meins;
                        poitm.NetPrice = Convert.ToDecimal(itmobj.Netpr);
                        poitm.NetValue = Convert.ToDecimal(itmobj.Netwr);
                        poitm.Remarks = itmobj.Txt01;
                        poitm.DeliveredQuantity = Convert.ToDecimal(itmobj.Wemng);
                        poitm.CostCenter = itmobj.Kostl;
                        poitm.LongTextDescription = itmobj.Ktext;
                        poitm.OrderNumber = itmobj.Aufnr;
                        poitm.StorageLocation = itmobj.Lgort;
                        poitm.DeletionStatusIndicator = itmobj.Loekz;
                        poitm.AcknowledgementStatus = "N";
                        poitm.ItemStatus = "";
                        poitm.RecordStatus = "";

                        if (mainController.GetDAOCreator().CreatePurchaseOrderItemDAO().RetrieveByKey(tran, itmobj.Ebeln, itmobj.Ebelp) != null)
                            mainController.GetDAOCreator().CreatePurchaseOrderItemDAO().Update(tran, poitm);
                        else
                            mainController.GetDAOCreator().CreatePurchaseOrderItemDAO().Insert(tran, poitm);

                        aMsgstr = aMsgstr + itmobj.Ebeln + ", ";
                        aForm.getProgressBar().Increment(wstep);
                        aCount++;
                        aForm.getTextBox().Text = aCount.ToString();
                    }

                    //-------------------------------------------
                    // Get Purchase Order Schedule Details
                    //-------------------------------------------

                    aRecCount = orderSchedule.Count;
                    aCount = 0;
                    wstep = 10;
                    this.setParameters();
                    
                    foreach (ZORDER_SCH schobj in orderSchedule)
                    {
                        try
                        {
                            PurchaseOrderItemSchedule posch = new PurchaseOrderItemSchedule();
                            posch.PurchaseOrderNumber = schobj.Ebeln;
                            posch.PurchaseOrderItemSequence = schobj.Ebelp;
                            posch.MaterialNumber = schobj.Matnr;
                            posch.PurchaseOrderScheduleSequence = schobj.Etenr;
                            posch.DeliveryScheduleQuantity = Convert.ToDecimal(schobj.Menge);
                            posch.OrderItemScheduleDate = Convert.ToInt64(schobj.Slfdt.Replace(" ", "0"));
                            posch.DeliveryDate = Convert.ToInt64(schobj.Eindt);
                            posch.DeliveredQuantity = Convert.ToDecimal(schobj.Wemng);
                            posch.AcknowledgementDate = 0;
                            posch.ExpeditingPromiseDate = 0;
                            posch.RecordStatus = "";
                            if (mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO().RetrieveByKey(tran, schobj.Ebeln, schobj.Ebelp, schobj.Etenr) != null)
                                mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO().Update(tran, posch);
                            else
                                mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO().Insert(tran, posch);

                            aMsgstr = aMsgstr + schobj.Ebeln + ", ";
                            aForm.getProgressBar().Increment(wstep);
                            aCount++;
                            aForm.getTextBox().Text = aCount.ToString();
                        }
                        catch (Exception ex)
                        {
                            string wstr = ex.Message;
                        }
                    }

                    //-------------------------------------------
                    // Get Purchase Order Components Details
                    //-------------------------------------------

                    aRecCount = orderComponent.Count;
                    aCount = 0;
                    wstep = 10;
                    this.setParameters();

                    foreach (ZORDER_COMP cmpobj in orderComponent)
                    {
                        SubcontractorMaterial pocmp = new SubcontractorMaterial();
                        pocmp.OrderNumber = cmpobj.Ebeln;
                        pocmp.ItemSequence = cmpobj.Ebelp;
                        pocmp.ComponentSequence = cmpobj.Compl;
                        pocmp.MaterialNumber = cmpobj.Matnr;
                        pocmp.MaterialDescription = cmpobj.Maktx;
                        pocmp.ComponentQuantity = cmpobj.Bdmng;
                        pocmp.UnitOfMeasure = cmpobj.Meins;
                        pocmp.RecordStatus = "";
                        pocmp.ItemStatus = "";

                        if (cmpobj.Ebeln != "") 
                        {
                        if (mainController.GetDAOCreator().CreateSubcontractorMaterialDAO().RetrieveByKey(tran, cmpobj.Ebeln, cmpobj.Ebelp, cmpobj.Compl, cmpobj.Matnr) != null)
                            mainController.GetDAOCreator().CreateSubcontractorMaterialDAO().Update(tran, pocmp);
                        else
                            mainController.GetDAOCreator().CreateSubcontractorMaterialDAO().Insert(tran, pocmp);
                        }

                        aMsgstr = aMsgstr + cmpobj.Ebeln + ", ";
                        aForm.getProgressBar().Increment(wstep);
                        aCount++;
                        aForm.getTextBox().Text = aCount.ToString();
                    }

                    //-------------------------------------------
                    // Get Purchase Order Service Item Details
                    //-------------------------------------------

                    aRecCount = orderService.Count;
                    aCount = 0;
                    wstep = 10;
                    this.setParameters();

                    foreach (ZORDER_SRV srvobj in orderService)
                    {
                        PurchaseOrderServiceItem posrv = new PurchaseOrderServiceItem();
                        posrv.OrderNumber = srvobj.Ebeln;
                        posrv.ItemSequenceNumber = srvobj.Ebelp;
                        posrv.ServiceLineNumber = srvobj.Lblni;
                        posrv.ServiceDescription = srvobj.Ktext1;
                        posrv.ServiceQuantity = srvobj.Menge;
                        posrv.ServicePrice = srvobj.Preis;
                        posrv.ServiceValue = srvobj.Brtwr;
                        posrv.RecordStatus = "";
                        if (mainController.GetDAOCreator().CreatePurchaseOrderServiceItemDAO().RetrieveByKey(tran, srvobj.Ebeln, srvobj.Ebelp, srvobj.Lblni) != null)
                            mainController.GetDAOCreator().CreatePurchaseOrderServiceItemDAO().Update(tran, posrv);
                        else
                            mainController.GetDAOCreator().CreatePurchaseOrderServiceItemDAO().Insert(tran, posrv);

                        aMsgstr = aMsgstr + srvobj.Ebeln + ", ";
                        aForm.getProgressBar().Increment(wstep);
                        aCount++;
                        aForm.getTextBox().Text = aCount.ToString();

                    }

                    //-------------------------------------------
                    // Get Service Task Details
                    //-------------------------------------------

                    aRecCount = serviceTask.Count;
                    aCount = 0;
                    wstep = 10;
                    this.setParameters();

                    foreach (ZORDER_SRVTSK tskobj in serviceTask)
                    {
                        PurchaseServiceTask srvtsk = new PurchaseServiceTask();
                        srvtsk.SheetNumber = tskobj.Lblni;
                        srvtsk.SheetSequence = tskobj.Extrow;
                        srvtsk.ServiceMaterial = tskobj.Srvpos;
                        srvtsk.ServiceText = tskobj.Ktext1;
                        srvtsk.ServiceQuantity = tskobj.Mengev;
                        srvtsk.ServicePrice = tskobj.Sbrtwr;
                        srvtsk.UnitOfMeasure = tskobj.Meins;

                        if (tskobj.Lblni != "")
                        {
                            if (mainController.GetDAOCreator().CreatePurchaseServiceTaskDAO().RetrieveByKey(tran, tskobj.Lblni, tskobj.Extrow) != null)
                                mainController.GetDAOCreator().CreatePurchaseServiceTaskDAO().Update(tran, srvtsk);
                            else
                                mainController.GetDAOCreator().CreatePurchaseServiceTaskDAO().Insert(tran, srvtsk);
                        }

                        aMsgstr = aMsgstr + tskobj.Lblni + ", " + tskobj.Extrow + ", " + tskobj.Srvpos;
                        aForm.getProgressBar().Increment(wstep);
                        aCount++;
                        aForm.getTextBox().Text = aCount.ToString();

                    }

                    //-------------------------------------------
                    // Get Purchase Order Header Text Details
                    //-------------------------------------------

                    aRecCount = headerText.Count;
                    aCount = 0;
                    wstep = 10;
                    this.setParameters();

                    foreach (ZORDER_HDRTXT hdrtxt in headerText)
                    {
                        PurchaseHeaderText pohtxt = new PurchaseHeaderText();
                        pohtxt.OrderNumber = hdrtxt.Ebeln;
                        pohtxt.TextSequence = hdrtxt.Txtitm;
                        pohtxt.LongText = hdrtxt.Ltxt;

                        if (mainController.GetDAOCreator().CreatePurchaseHeaderTextDAO().RetrieveByKey(tran, hdrtxt.Ebeln, hdrtxt.Txtitm) != null)
                            mainController.GetDAOCreator().CreatePurchaseHeaderTextDAO().Update(tran, pohtxt);
                        else
                            mainController.GetDAOCreator().CreatePurchaseHeaderTextDAO().Insert(tran, pohtxt);

                        aMsgstr = aMsgstr + hdrtxt.Ebeln + ", " ;
                        aForm.getProgressBar().Increment(wstep);
                        aCount++;
                        aForm.getTextBox().Text = aCount.ToString();

                    }

                    //-------------------------------------------
                    // Get Purchase Order Item Text Details
                    //-------------------------------------------

                    aRecCount = itemText.Count;
                    aCount = 0;
                    wstep = 10;
                    this.setParameters();

                    foreach (ZORDER_ITMTXT itmtxt in itemText)
                    {
                        PurchaseItemText poitxt = new PurchaseItemText();
                        poitxt.OrderNumber = itmtxt.Ebeln;
                        poitxt.ItemSequence = itmtxt.Ebelp;
                        poitxt.TextSequence = itmtxt.Txtitm;
                        poitxt.LongText = itmtxt.Ltxt;

                        if (mainController.GetDAOCreator().CreatePurchaseItemTextDAO().RetrieveByKey(tran, itmtxt.Ebeln, itmtxt.Ebelp, itmtxt.Txtitm) != null)
                            mainController.GetDAOCreator().CreatePurchaseItemTextDAO().Update(tran, poitxt);
                        else
                            mainController.GetDAOCreator().CreatePurchaseItemTextDAO().Insert(tran, poitxt);

                        aMsgstr = aMsgstr + itmtxt.Ebeln + ", " + itmtxt.Ebelp + ", " + itmtxt.Txtitm;
                        aForm.getProgressBar().Increment(wstep);
                        aCount++;
                        aForm.getTextBox().Text = aCount.ToString();
                    }

                    tran.Commit();
                    this.ProcessNotification(notificationCollection);
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

        private void UpdatePurchaseHistory()
        {
            int wstep;
            EpTransaction tran = DataManager.BeginTransaction();
            try
            {
                //---------------------------------------
                // Get Purchase Order History Details
                //---------------------------------------

                aRecCount = orderHistory.Count;
                aCount = 0;
                wstep = 10;
                this.setParameters();
                foreach (ZORDER_HISTORY hstobj in orderHistory)
                {
                    PurchaseOrderHistory pohst = new PurchaseOrderHistory();
                    pohst.OrderNumber = hstobj.Ebeln;
                    pohst.ItemSequence = hstobj.Ebelp;
                    pohst.DocumentNumber = hstobj.Belnr;
                    pohst.DocumentSerial = hstobj.Buzei;
                    pohst.CurrencyId = hstobj.Waers;
                    pohst.Plant = hstobj.Werks;
                    pohst.MovementType = hstobj.Bwart;
                    pohst.MaterialNumber = hstobj.Matnr;
                    pohst.InvoiceValue = hstobj.Wrbtr;
                    pohst.TransactionAmount = hstobj.Dmbtr;
                    pohst.TransactionQuantity = hstobj.Menge;
                    pohst.TransactionType = hstobj.Bewtp;
                    pohst.UnitOfMeasure = hstobj.Meins;
                    pohst.ReferenceNumber = hstobj.Xblnr;
                    pohst.Indicator = hstobj.Shkzg;
                    pohst.PostingDate = Convert.ToInt64(hstobj.Budat);

                    if (mainController.GetDAOCreator().CreatePurchaseOrderHistoryDAO().RetrieveByKey(tran, hstobj.Ebeln, hstobj.Ebelp, hstobj.Belnr) != null)
                    {
                        mainController.GetDAOCreator().CreatePurchaseOrderHistoryDAO().Update(tran, pohst);
                    }
                    else
                    {
                        mainController.GetDAOCreator().CreatePurchaseOrderHistoryDAO().Insert(tran, pohst);
                    }
                    aForm.getProgressBar().Increment(wstep);
                    aCount++;
                    aForm.getTextBox().Text = aCount.ToString();
                }

                //---------------------------------------
                // Get Purchase Order Completion Details
                //---------------------------------------

                aRecCount = orderClose.Count;
                aCount = 0;
                wstep = 10;
                this.setParameters();
                
                PurchaseOrderHeader pohdr;
                PurchaseOrderItem poitm;

                foreach (ZORDER_CLOSE clsobj in orderClose)
                {
                    pohdr = mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().RetrieveByKey(tran, clsobj.Ebeln);
                    if ( pohdr != null)
                    {
                        if (clsobj.Posts != "Z")
                        {
                            pohdr.OrderStatus = clsobj.Posts;
                            mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().Update(tran, pohdr);
                        }
                    }

                    poitm = mainController.GetDAOCreator().CreatePurchaseOrderItemDAO().RetrieveByKey(tran, clsobj.Ebeln, clsobj.Ebelp);
                    if (poitm != null)
                    {
                        if (clsobj.Itsts != "Z")
                        {
                            poitm.DeletionStatusIndicator = clsobj.Itsts;
                            mainController.GetDAOCreator().CreatePurchaseOrderItemDAO().Update(tran, poitm);
                        }
                    }
                    aForm.getProgressBar().Increment(wstep);
                    aCount++;
                    aForm.getTextBox().Text = aCount.ToString();
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                Utility.ExceptionLog(ex);
                throw (ex);
            }
            finally
            {
                tran.Dispose();
            }
        }

        public DataTable GetOrderHeader()
        {
            if (orderHeader != null)
                return orderHeader.ToADODataTable();
            else
                return null;
        }

        public DataTable GetOrderItem()
        {
            if (orderItem != null)
                return orderItem.ToADODataTable();
            else
                return null;
        }

        public DataTable GetOrderSchedule()
        {
            if (orderSchedule != null)
                return orderSchedule.ToADODataTable();
            else
                return null;
        }

        public DataTable GetOrderComponent()
        {
            if (orderComponent != null)
                return orderComponent.ToADODataTable();
            else
                return null;
        }

        public DataTable GetOrderService()
        {
            if (orderService != null)
                return orderService.ToADODataTable();
            else
                return null;
        }

        public DataTable GetServiceTask()
        {
            if (serviceTask != null)
                return serviceTask.ToADODataTable();
            else
                return null;
        }

        public DataTable GetHeaderText()
        {
            if (headerText != null)
                return headerText.ToADODataTable();
            else
                return null;
        }

        public DataTable GetItemText()
        {
            if (itemText != null)
                return itemText.ToADODataTable();
            else
                return null;
        }

        public DataTable GetHistory()
        {
            if (orderHistory != null)
                return orderHistory.ToADODataTable();
            else
                return null;
        }

        private void setParameters()
        {
            aForm.getProgressBar().Step = 0;
            aForm.getProgressBar().Value = 1;
            aForm.getProgressBar().Maximum = aRecCount;
            aForm.getProgressBar().Minimum = 1;
        }

        private void RemoveOrderDetails()
        {
            ClearPurchaseData clearPurchaseData;
            try
            {
                clearPurchaseData = new ClearPurchaseData();
                clearPurchaseData.ClearPurchaseOrderData();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void ProcessNotification(Collection<Notification> pNotification)
        {
            try
            {
                foreach (Notification wNotification in pNotification)
                {
                    NotificationController notificationControl = new NotificationController(mainController);
                    notificationControl.InsertEmailNotification(wNotification);
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

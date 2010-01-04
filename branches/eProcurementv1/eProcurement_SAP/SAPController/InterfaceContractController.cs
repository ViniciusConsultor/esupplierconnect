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
    public class InterfaceContractController
    {
        private ZCONTRACT_HDRTable contractHeader;
        private ZCONTRACT_ITMTable contractItem;

        private string aMsgstr = "";
        private int aRecCount = 0;

        private InterfaceForm aForm;
        private MainController mainController;
        private Collection<Notification> notificationCollection;

        public InterfaceContractController(InterfaceForm aForm, MainController mainController)
        {
            this.aForm = aForm;
            this.mainController = mainController;
        }

        public void GetPurchaseContract()
        {
            RetrieveContract   retrieveContract;

            try
            {
                retrieveContract = new RetrieveContract();

                aForm.getLabel().Text = "Retrieval of Purchase Contract Data  in Progress ....";
                aForm.getLabel().Refresh();

                retrieveContract.GetContractDetails();
                contractHeader = retrieveContract.GetContractHeader();
                contractItem   = retrieveContract.GetContractItem();

                aForm.getLabel().Text = "Update of Purchase Contract Data  in Progress ....";
                aForm.getLabel().Refresh();
                
                this.UpdateContract();
                this.RemoveContractDetails();
                
                aForm.getLabel().Text = "Update of Purchase Contract Data Completed";
                aForm.getLabel().Refresh();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        private void UpdateContract ()
        {
            int wstep;

            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {
                    //---------------------------------------
                    // Get Contract Header Details
                    //---------------------------------------
                    aRecCount = contractHeader.Count;
                    wstep = 10;
                    this.setParameters();

                    foreach (ZCONTRACT_HDR conhdr in contractHeader)
                    {
                        ContractHeader chdr = new ContractHeader();
                        chdr.ContractNumber = conhdr.Ebeln;
                        chdr.ContractDate = Convert.ToInt64(conhdr.Bedat);
                        chdr.ContractCategory = conhdr.Bstyp;
                        chdr.DocumentType = conhdr.Bsart;
                        chdr.ContractValue = conhdr.Ktwrt;
                        chdr.CreatedBy = conhdr.Ernam;
                        chdr.Currency = conhdr.Waers;
                        chdr.ExchangeRate = conhdr.Wkurs;
                        chdr.InternalReference = "";
                        chdr.PaymentTerms = conhdr.Zterm;
                        chdr.PurchasingGroup = conhdr.Ekgrp;
                        chdr.SalesContactPerson = conhdr.Verkf;
                        chdr.SupplierId = conhdr.Lifnr;
                        chdr.Telephone = conhdr.Telf1;
                        chdr.ValidityEnd = Convert.ToInt64(conhdr.Kdate);
                        chdr.ValidityStart = Convert.ToInt64(conhdr.Kdatb);
                        chdr.AcknowledgeStatus = "N";

                        Notification notification = new Notification();

                        if (mainController.GetDAOCreator().CreateContractHeaderDAO().RetrieveByKey(tran, conhdr.Ebeln) != null)
                        {
                            mainController.GetDAOCreator().CreateContractHeaderDAO().Update(tran, chdr);
                            notification.NotificationType = NotificationMessage.ContractUpdate;
                            aMsgstr = "ContractNumber : " + conhdr.Ebeln + "Dated : " + conhdr.Bedat + " has been Amended please acknowledge";
                        }
                        else
                        {
                            mainController.GetDAOCreator().CreateContractHeaderDAO().Insert(tran, chdr);
                            notification.NotificationType = NotificationMessage.ContractCreate;
                            aMsgstr = "Please Acknowlegde Contract Number: " + conhdr.Ebeln + "Dated : " + conhdr.Bedat;
                        }

                        notification.NotificationId = 0;
                        notification.NotificationDate = Convert.ToInt64(System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString().PadLeft(2, '0') + System.DateTime.Now.Day.ToString().PadLeft(2, '0'));
                        notification.ReferenceNumber = conhdr.Lifnr;
                        notification.ReferenceSequence = "";
                        notification.Recipient = conhdr.Lifnr;
                        notification.Sender = NotificationMessage.buyerSender;
                        notification.Message = aMsgstr;
                        notification.Email = mainController.GetSupplierController().GetSupplierEmailAddr(conhdr.Lifnr); ;
                        if (notification.Email == "")
                        {
                            notification.Email = NotificationMessage.buyerEmail;
                        }
                        notification.Status = "0";
                        notificationCollection.Add(notification);

                        aForm.getProgressBar().Increment(wstep);
                    }

                    //---------------------------------------
                    // Get Contract Item Details
                    //---------------------------------------

                    aRecCount = contractHeader.Count;
                    wstep = 10; 
                    this.setParameters();
 
                    foreach (ZCONTRACT_ITM conitm in contractItem)
                    {
                        ContractItem itm = new ContractItem();
                        itm.ContractNumber = conitm.Ebeln;
                        itm.ContractItemSequence = conitm.Ebelp;
                        itm.Description = conitm.Txz01;
                        itm.MaterialGroup = conitm.Matkl;
                        itm.MaterialNumber = conitm.Matnr;
                        itm.NetValue = conitm.Brtwr;
                        itm.Plant = conitm.Werks;
                        itm.PricePerUnit = conitm.Peinh;
                        itm.Requisitioner = conitm.Afnam;
                        itm.RequisitionNumber = conitm.Banfn;
                        itm.RFQNumber = conitm.Anfnr;
                        itm.TargetQuantity = conitm.Ktmng;
                        itm.UnitOfMeasure = conitm.Meins;
                        itm.UnitPrice = conitm.Netpr;

                        if (mainController.GetDAOCreator().CreateContractItemDAO().RetrieveByKey(tran, conitm.Ebeln, conitm.Ebelp) != null)
                            mainController.GetDAOCreator().CreateContractItemDAO().Update(tran, itm);  
                        else
                            mainController.GetDAOCreator().CreateContractItemDAO().Insert(tran, itm);

                        aMsgstr = aMsgstr + conitm.Ebeln + ", ";
                        aForm.getProgressBar().Increment(wstep);
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

                this.RemoveContractDetails();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public DataTable GetContractHeader()
        {
            if (contractHeader != null)
                return contractHeader.ToADODataTable();
            else
                return null;
        }

        public DataTable GetContractItem()
        {
            if (contractItem != null)
                return contractItem.ToADODataTable();
            else
                return null;
        }

        private void setParameters()
        {
            aForm.getProgressBar().Step = 0;
            aForm.getProgressBar().Maximum = aRecCount;
            aForm.getProgressBar().Minimum = 1;
        }

        private void RemoveContractDetails()
        {
            ClearPurchaseData clearPurchaseData;
            try
            {
                clearPurchaseData = new ClearPurchaseData();
                clearPurchaseData.ClearContractData();
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

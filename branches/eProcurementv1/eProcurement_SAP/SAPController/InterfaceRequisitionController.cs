using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAPInterface;
using SAP.Connector;
using eProcurement_DAL;
using eProcurement_BLL;


namespace eProcurement_SAP
{
    public class InterfaceRequisitionController
    {
        private ZREQN_HDRTable requisitionHeader;
        private ZREQN_ITMTable requisitionItem;
        
        private string aMsgstr = "";
        private int aRecCount = 0;
        private int aCount = 0;
        private InterfaceForm aForm;
        private MainController mainController;


        public InterfaceRequisitionController(InterfaceForm aForm, MainController mainController)
        {
            this.aForm = aForm;
            this.mainController = mainController;
        }

        public void GetRequisition()
        {
            RetrieveRequisition retrieveRequisition;

            try
            {
                retrieveRequisition = new RetrieveRequisition();

                aForm.getLabel().Text = "Retrieval of Purchase Requisition Data  in Progress ....";
                aForm.getLabel().Refresh();

                retrieveRequisition.GetRequisitionDetails();
                requisitionHeader = retrieveRequisition.GetRequisitionHeader();
                requisitionItem = retrieveRequisition.GetRequisitionItem();

                aForm.getLabel().Text = "Update of Purchase Requisition Data  in Progress ....";
                aForm.getLabel().Refresh();
                
                this.UpdateRequisition();
                //this.RemoveRequisitionDetails();
                
                aForm.getLabel().Text = "Update of Purchase Requisition Data Completed";
                aForm.getLabel().Refresh();
            }
            catch (Exception ex)
            {
                if (ex.Message == "RECORDNOTFOUND")
                {
                    aForm.getLabel().Text = "No Records for Update...";
                }
                else
                {
                    aForm.getLabel().Text = "Error while Updating... Please check the Log";
                }
                aForm.getLabel().Refresh();
                Utility.ExceptionLog(ex);
                Utility.EscapeSQL(aMsgstr);
                throw (ex);
            }
        }

        private void UpdateRequisition()
        {
            int wstep;

            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {

                    //---------------------------------------
                    // Get Requisition Header Details
                    //---------------------------------------

                    aRecCount = requisitionHeader.Count;
                    wstep = 10;
                    this.setParameters();

                    foreach (ZREQN_HDR reqhdr in requisitionHeader)
                    {
                        RequisitionHeader rhdr = new RequisitionHeader();
                        rhdr.RequisitionNumber = reqhdr.Banfn;
                        rhdr.RequisitionDate = Convert.ToInt64(reqhdr.Badat);
                        rhdr.RequisitionCategory = reqhdr.Bstyp;
                        rhdr.DocumentType = reqhdr.Bsart;
                        rhdr.Status = reqhdr.Statu;
                        rhdr.ReleaseStatus = reqhdr.Frgzu;
                        rhdr.ReleaseDate = Convert.ToInt64(reqhdr.Frgdt);
                        rhdr.CreateBy = reqhdr.Ernam;

                        aMsgstr = "Requisition No: " + reqhdr.Banfn;

                        if (mainController.GetDAOCreator().CreateRequisitionHeaderDAO().RetrieveByKey(tran, reqhdr.Banfn) != null)
                            mainController.GetDAOCreator().CreateRequisitionHeaderDAO().Update(tran, rhdr);
                        else
                            mainController.GetDAOCreator().CreateRequisitionHeaderDAO().Insert(tran, rhdr);

                        aForm.getProgressBar().Increment(wstep);
                        aCount++;
                        aForm.getTextBox().Text = aCount.ToString();
                        aForm.getTextBox().Refresh();
                    }

                    //---------------------------------------
                    // Get Requisition Item Details
                    //---------------------------------------

                    aRecCount = requisitionItem.Count;
                    aCount = 0;
                    wstep = 10;
                    this.setParameters();

                    foreach (ZREQN_ITM reqitm in requisitionItem)
                    {
                        RequisitionItem ritm = new RequisitionItem();
                        ritm.RequisitionNumber = reqitm.Banfn;
                        ritm.ItemSequence = reqitm.Bnfpo;
                        ritm.PurchasingGroup = reqitm.Ekgrp;
                        ritm.PurchaseOrg = reqitm.Ekorg;
                        ritm.MaterialNumber = reqitm.Matnr;
                        ritm.MaterialDescription = reqitm.Txz01;
                        ritm.Plant = reqitm.Werks;
                        ritm.RequiredQuantity = reqitm.Menge;
                        ritm.UnitOfMeasure = reqitm.Meins;
                        ritm.RequiredDate = Convert.ToInt64(reqitm.Lfdat);
                        ritm.EstimatedPrice = reqitm.Preis;
                        ritm.UnitPrice = reqitm.Peinh;
                        ritm.OrderNumber = reqitm.Ebeln;
                        ritm.SequenceNumber = reqitm.Ebelp;
                        ritm.OrderDate = Convert.ToInt64(reqitm.Bedat);
                        ritm.CurrencyId = reqitm.Waers;
                        ritm.TotalValue = reqitm.Rlwrt;
                        ritm.Requestor = reqitm.Afnam;
                        ritm.FixedVendor = reqitm.Flief;
                        ritm.Status = reqitm.Loekz;

                        aMsgstr = "Requisition Item : " + reqitm.Banfn + ", " + reqitm.Bnfpo;

                        if (mainController.GetDAOCreator().CreateRequisitionItemDAO().RetrieveByKey(tran, reqitm.Banfn, reqitm.Bnfpo) != null)
                            mainController.GetDAOCreator().CreateRequisitionItemDAO().Update(tran, ritm);
                        else
                            mainController.GetDAOCreator().CreateRequisitionItemDAO().Insert(tran, ritm);

                        aForm.getProgressBar().Increment(wstep);
                        aCount++;
                        aForm.getTextBox().Text = aCount.ToString();
                        aForm.getTextBox().Refresh();
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

        public DataTable GetRequisitionHeader()
        {
            if (requisitionHeader != null)
                return requisitionHeader.ToADODataTable();
            else
                return null;
        }

        public DataTable GetRequisitionItem()
        {
            if (requisitionItem != null)
                return requisitionItem.ToADODataTable();
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

        private void RemoveRequisitionDetails()
        {
            ClearPurchaseData clearPurchaseData;
            try
            {
                clearPurchaseData = new ClearPurchaseData();
                clearPurchaseData.ClearRequisitionData();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}

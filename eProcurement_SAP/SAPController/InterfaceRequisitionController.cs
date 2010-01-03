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
                this.RemoveRequisitionDetails();
                
                aForm.getLabel().Text = "Update of Purchase Requisition Data Completed";
                aForm.getLabel().Refresh();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
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

                        if (mainController.GetDAOCreator().CreateRequisitionHeaderDAO().RetrieveByKey(tran, reqhdr.Banfn) != null)
                            mainController.GetDAOCreator().CreateRequisitionHeaderDAO().Update(tran, rhdr);
                        else
                            mainController.GetDAOCreator().CreateRequisitionHeaderDAO().Insert(tran, rhdr);

                        aMsgstr = aMsgstr + reqhdr.Banfn + ", ";
                        aForm.getProgressBar().Increment(wstep);
                    }

                    //---------------------------------------
                    // Get Requisition Item Details
                    //---------------------------------------

                    aRecCount = requisitionItem.Count;
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

                        if (mainController.GetDAOCreator().CreateRequisitionItemDAO().RetrieveByKey(tran, reqitm.Banfn, reqitm.Bnfpo) != null)
                            mainController.GetDAOCreator().CreateRequisitionItemDAO().Update(tran, ritm);
                        else
                            mainController.GetDAOCreator().CreateRequisitionItemDAO().Insert(tran, ritm);

                        aMsgstr = aMsgstr + reqitm.Banfn + ", " + reqitm.Bnfpo;
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

                this.RemoveRequisitionDetails();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public DataTable GetRequisitionHeader()
        {
            return requisitionHeader.ToADODataTable();
        }

        public DataTable GetRequisitionItem()
        {
            return requisitionItem.ToADODataTable();
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

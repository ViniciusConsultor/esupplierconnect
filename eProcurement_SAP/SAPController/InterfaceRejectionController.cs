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
    public class InterfaceRejectionController
    {
        private ZORDER_REJECTTable orderRejection;

        private string aMsgstr = "";
        private int aRecCount = 0;
        private InterfaceForm aForm;
        private MainController mainController;
        private Notif

        public InterfaceRejectionController(InterfaceForm aForm, MainController mainController)
        {
            this.aForm = aForm;
            this.mainController = mainController;
        }

        public void GetRejectionGoods()
        {
            RetrieveGoodsRejection retrieveRejection;

            try
            {
                retrieveRejection = new RetrieveGoodsRejection();

                aForm.getLabel().Text = "Retrieval of Goods Rejection Data in Progress ....";
                aForm.getLabel().Refresh();

                retrieveRejection.GetRejectionDetails();
                orderRejection = retrieveRejection.GetOrderRejection();

                aForm.getLabel().Text = "Update of Goods Rejection Data in Progress ....";
                aForm.getLabel().Refresh();

                this.UpdateRejection();

                aForm.getLabel().Text = "Update of Goods Rejection Data Completed ";
                aForm.getLabel().Refresh();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        private void UpdateRejection()
        {
            int wstep;

            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {

                    //---------------------------------------
                    // Get Rejection Details
                    //---------------------------------------

                    aRecCount = orderRejection.Count;
                    wstep = 10;
                    this.setParameters();

                    foreach (ZORDER_REJECT rejobj in orderRejection)
                    {
                        RejectedGood rejgood = new RejectedGood();
                        rejgood.OrderNumber  = rejobj.Ebeln;
                        rejgood.ItemSequence = rejobj.Ebelp;
                        rejgood.DocumentNumber = rejobj.Mblnr;
                        rejgood.MaterialNumber = rejobj.Matnr;
                        rejgood.ReferenceNumber = rejobj.Xblnr;
                        rejgood.RejectDate = Convert.ToInt64(rejobj.Budat);
                        rejgood.RejectQuantity = rejobj.Menge;
                        rejgood.AcknowledgeStatus = "";
                        rejgood.UnitofMeasure = rejobj.Meins;
                        rejgood.Location = rejobj.Lgort;
                        rejgood.Plant = rejobj.Werks;
                        if (mainController.GetDAOCreator().CreateRejectedGoodDAO().RetrieveByKey(tran, rejobj.Ebeln, rejobj.Ebelp, rejobj.Mblnr) != null)
                            mainController.GetDAOCreator().CreateRejectedGoodDAO().Update(tran, rejgood);
                        else
                            mainController.GetDAOCreator().CreateRejectedGoodDAO().Insert(tran, rejgood);

                        aMsgstr = aMsgstr + rejobj.Ebeln + ", " + rejobj.Ebelp + ", " + rejobj.Mblnr;
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
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public DataTable GetRejection()
        {
            return orderRejection.ToADODataTable();
        }

        private void setParameters()
        {
            aForm.getProgressBar().Step = 0;
            aForm.getProgressBar().Value = 1;
            aForm.getProgressBar().Maximum = aRecCount;
            aForm.getProgressBar().Minimum = 1;
        }

    }
}

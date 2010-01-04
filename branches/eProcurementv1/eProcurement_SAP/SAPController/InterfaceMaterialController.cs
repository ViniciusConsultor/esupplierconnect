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
    public class InterfaceMaterialController
    {
        private ZMATL_STOCKTable materialStock;

        private string aMsgstr = "";
        private int aRecCount = 0;
        private InterfaceForm aForm;
        private MainController mainController;

        public InterfaceMaterialController(InterfaceForm aForm, MainController mainController)
        {
            this.aForm = aForm;
            this.mainController = mainController;
        }

        public void GetMaterialStock()
        {
            RetrieveMaterialStock retrieveMaterial;

            try
            {
                retrieveMaterial = new RetrieveMaterialStock();

                aForm.getLabel().Text = "Retrieval of Material Data  in Progress ....";
                aForm.getLabel().Refresh();

                retrieveMaterial.GetMaterialDetails();
                materialStock = retrieveMaterial.GetMaterialStock();

                aForm.getLabel().Text = "Update of Material Data  in Progress ....";
                aForm.getLabel().Refresh();

                this.UpdateMaterial();

                aForm.getLabel().Text = "Update of Material Stock Data Completed ";
                aForm.getLabel().Refresh();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        private void UpdateMaterial()
        {
            int wstep;

            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {

                    //---------------------------------------
                    // Get Material Stock Details
                    //---------------------------------------
                    
                    aRecCount = materialStock.Count;
                    wstep = 10;
                    this.setParameters();

                    foreach (ZMATL_STOCK mtlobj in materialStock)
                    {
                        MaterialStock mtlstk = new MaterialStock();
                        mtlstk.MaterialNumber = mtlobj.Matnr;
                        mtlstk.MaterialDescription = mtlobj.Maktx.Replace("'", "");
                        mtlstk.Plant = mtlobj.Werks;
                        mtlstk.UnrestrictedStock = mtlobj.Labst;
                        mtlstk.InspectionStock = mtlobj.Insme;
                        mtlstk.UnitOfMeasure = mtlobj.Meins;

                        if (mainController.GetDAOCreator().CreateMaterialStockDAO().RetrieveByKey(tran, mtlobj.Matnr, mtlobj.Werks) != null)
                            mainController.GetDAOCreator().CreateMaterialStockDAO().Update(tran, mtlstk);
                        else
                            mainController.GetDAOCreator().CreateMaterialStockDAO().Insert(tran, mtlstk);

                        aMsgstr = aMsgstr + mtlobj.Matnr + ", " + mtlobj.Werks;
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

        public DataTable GetMaterial()
        {
            if (materialStock != null)
                return materialStock.ToADODataTable();
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
    }
}

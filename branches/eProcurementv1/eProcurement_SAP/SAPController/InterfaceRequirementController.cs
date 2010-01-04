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
    public class InterfaceRequirementController
    {
        private ZMATL_REQUIRETable requirement;

        private string aMsgstr = "";
        private InterfaceForm aForm;
        private int aRecCount = 0;
        private MainController mainController;

        public InterfaceRequirementController(InterfaceForm aForm, MainController mainController)
        {
            this.aForm = aForm;
            this.mainController = mainController;
        }

        public void GetMaterialRequirement()
        {
            RetrieveMaterialRequirement retrieveRequirement;

            try
            {
                retrieveRequirement = new RetrieveMaterialRequirement();

                aForm.getLabel().Text = "Retrieval of Material Requirement Data  in Progress ....";
                aForm.getLabel().Refresh();

                retrieveRequirement.GetRequirementDetails();
                requirement = retrieveRequirement.GetMaterialRequirement();

                aForm.getLabel().Text = "Update of Material Requirement Data  in Progress ....";
                aForm.getLabel().Refresh();

                this.UpdateRequirement();

                aForm.getLabel().Text = "Update of Material Requirement Data Completed";
                aForm.getLabel().Refresh();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        private void UpdateRequirement()
        {
            int wstep;

            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {

                    //---------------------------------------
                    // Get Material Requirement Details
                    //---------------------------------------

                    aRecCount = requirement.Count;
                    wstep = 10;
                    this.setParameters();

                    foreach (ZMATL_REQUIRE reqobj in requirement)
                    {
                        MaterialRequirement mtlreq = new MaterialRequirement();
                        mtlreq.MaterialNumber = reqobj.Matnr;
                        mtlreq.Plant = reqobj.Werks;
                        mtlreq.RequiredDate = Convert.ToInt64(reqobj.Bdter);
                        mtlreq.RequiredQuantity = reqobj.Bdmng;
                        mtlreq.UnitOfMeasure = reqobj.Meins;

                        if (mainController.GetDAOCreator().CreateMaterialRequirementDAO().RetrieveByKey(tran, reqobj.Matnr, reqobj.Werks, Convert.ToInt64(reqobj.Bdter)) != null)
                            mainController.GetDAOCreator().CreateMaterialRequirementDAO().Update(tran, mtlreq);
                        else
                            mainController.GetDAOCreator().CreateMaterialRequirementDAO().Insert(tran, mtlreq);

                        aMsgstr = aMsgstr + reqobj.Matnr + ", " + reqobj.Werks + ", " + reqobj.Bdter;
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

        public DataTable GetRequirement()
        {
            if (requirement != null)
                return requirement.ToADODataTable();
            else
                return null;
        }

        private void setParameters()
        {
            aForm.getProgressBar().Value = 1;
            aForm.getProgressBar().Step = 0;
            aForm.getProgressBar().Maximum = aRecCount;
            aForm.getProgressBar().Minimum = 1;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;
using eProcurement_BLL.UserManagement;

namespace eProcurement_BLL
{

    public class RequisitionController
    {
        MainController mainController = null;
        public RequisitionController(MainController mainController) 
        {
            this.mainController = mainController;
        }

        public RequisitionItem GetRequisition(string RequisitionNO, string RequisitionSeq) 
        {
            return mainController.GetDAOCreator().CreateRequisitionItemDAO().RetrieveByKey(RequisitionNO, RequisitionSeq);           
        }

        public Collection<RequisitionItem> GetRequisitionList(string MaterialNo, string RequisitionNo)
        {
            try
            {
                string whereCluase = "";

                whereCluase = " MATNR like '" + Utility.EscapeSQL(MaterialNo) + "%' AND EBELN like '" + RequisitionNo + "%'" ;

                //orderCluase = " BANFN asc ";
                return this.mainController.GetDAOCreator().CreateRequisitionItemDAO().RetrieveByQuery(whereCluase);
                

            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }
        public Collection<RequisitionItem> GetRequisitionList(string RequisitionNo)
        {
            try
            {
                string whereCluase = "";

                whereCluase = " EBELN like '" + RequisitionNo + "%'";

                //orderCluase = " BANFN asc ";
                return this.mainController.GetDAOCreator().CreateRequisitionItemDAO().RetrieveByQuery(whereCluase);


            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

    }
}

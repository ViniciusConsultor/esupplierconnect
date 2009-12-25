using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL.PurchaseOrder
{
    public class OrderItemController
    {
        MainController mainController = null;
        public OrderItemController(MainController mainController) 
        {
            this.mainController = mainController;
        }

        public PurchaseOrderItem GetPurchaseOrderItem(string orderNumber,string itemSeq)
        {
            try
            {
                return mainController.GetDAOCreator().CreatePurchaseOrderItemDAO()
                    .RetrieveByKey(orderNumber, itemSeq);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Collection<PurchaseOrderItem> GetPurchaseOrderItems(string orderNumber)
        {
            try
            {
                string whereClause = " EBELN='" + Utility.EscapeSQL(orderNumber) + "' ";
                whereClause += " AND isnull(STS2,'')<>'D' ";
                string orderClause = " EBELP asc ";

                return mainController.GetDAOCreator().
                    CreatePurchaseOrderItemDAO().RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Collection<PurchaseOrderItemSchedule> GetPurchaseOrderItemSchedules(string orderNumber, string itemSeq)
        {
            try
            {
                string whereClause = " EBELN='" + Utility.EscapeSQL(orderNumber) + "' ";
                whereClause += " AND EBELP='" + Utility.EscapeSQL(itemSeq) + "' ";
                whereClause += " AND isnull(RECSTS,'')<>'D' ";
                string orderClause = " ETENR asc ";

                return mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO()
                    .RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Collection<PurchaseItemText> GetPurchaseItemTexts(string orderNumber, string itemSeq)
        {
            try
            {
                string whereClause = " EBELN='" + Utility.EscapeSQL(orderNumber) + "' ";
                whereClause += " AND EBELP='" + Utility.EscapeSQL(itemSeq) + "' ";
                whereClause += " AND isnull(RECSTS,'')<>'D' ";
                string orderClause = " TXTITM asc ";

                return mainController.GetDAOCreator().
                    CreatePurchaseItemTextDAO().RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Collection<SubcontractorMaterial> GetPurchaseOrderSubcontractComponents(string orderNumber, string itemSeq)
        {
            try
            {
                string whereClause = " EBELN='" + Utility.EscapeSQL(orderNumber) + "' ";
                whereClause += " AND EBELP='" + Utility.EscapeSQL(itemSeq) + "' ";
                whereClause += " AND isnull(STS,'')<>'D' ";
                string orderClause = " COMPL asc ";

                return mainController.GetDAOCreator().CreateSubcontractorMaterialDAO()
                    .RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Collection<PurchaseOrderServiceItem> GetPurchaseOrderServiceItems(string orderNumber, string itemSeq)
        {
            try
            {
                string whereClause = " EBELN='" + Utility.EscapeSQL(orderNumber) + "' ";
                whereClause += " AND EBELP='" + Utility.EscapeSQL(itemSeq) + "' ";
                whereClause += " AND isnull(RECSTS,'')<>'D' ";
                string orderClause = " LBLN1 asc ";

                return mainController.GetDAOCreator().
                    CreatePurchaseOrderServiceItemDAO().RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }    
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL.Delivery
{
    public class DeliveryController
    {
         MainController mainController = null;
        public DeliveryController(MainController mainController) 
        {
            this.mainController = mainController;
        }

        public RejectedGood GetRejectedGood(string orderNumber,string itemSequence, string documentNumber)
        {
            return mainController.GetDAOCreator().CreateDeliveryOrderDAO().RetrieveByKey(orderNumber,itemSequence,documentNumber);
        }

        public Collection<RejectedGood> EnquirePendingAckPOList(string orderNumber, string itemSequence, string documentNumber, string materialNumber)
        {
            try
            {
                string whereClause = "";
                string orderClause = "";
                //whereClause = " LIFNR = '" + this.mainController.GetLoginUserVO().SupplierId + "'";
                whereClause += " AND isnull(EBELN,'') = '" + RejAckStatus.No + "' ";

                if (orderNumber != "")
                {
                    whereClause += " AND EBELN like '" + Utility.EscapeSQL(orderNumber) + "' ";
                }
                if (itemSequence != "")
                {
                    whereClause += " AND EBELP like '" + Utility.EscapeSQL(itemSequence) + "' ";
                }
                if (documentNumber != "")
                {
                    whereClause += " AND DOCNO like '" + Utility.EscapeSQL(documentNumber) + "' ";
                }
                if (materialNumber != "")
                {
                    whereClause += " AND MATNR like '" + Utility.EscapeSQL(materialNumber) + "' ";
                }
                orderClause = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreateDeliveryOrderDAO().RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);

            }
        }

        public void AcknowledgeRejectedGood(Collection<RejectedGood> rejgood)
        {
            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {
                    foreach (RejectedGood vo in rejgood)
                    {
                        RejectedGood rejgood = mainController.GetDAOCreator().CreateDeliveryOrderDAO()
                            .RetrieveByKey(vo.OrderNumber, vo.ItemSequence, vo.DocumentNumber);
                        if (rejgood == null)
                        {
                            throw new Exception(string.Format("Rejected Good record doesn't exist. Order Number:{0}, Item Sequence:{1}, Document Number:{2}.",
                                vo.OrderNumber, vo.ItemSequence, vo.DocumentNumber));
                        }

                        if (string.Compare(expediting.RecordStatus, ExpediteStatus.Expedite, true) != 0)
                        {
                            throw new Exception(string.Format("Purchase expediting record has already been updated by other user. Order Number:{0}, Item Sequence:{1}, Schedule Sequence:{2}.",
                                vo.OrderNumber, vo.ItemSequence, vo.DocumentNumber));
                        }

                        rejgood.AcknowledgeStatus = RejAckStatus.Yes;
                       
                        mainController.GetDAOCreator().CreateDeliveryOrderDAO()
                                .Update(tran, expediting);
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
        //public RejectedGood GetPendingAcknowledgeGoodsRejectionList(string QuotationId, string RequestSeq) 
        //{
        //  return mainController.GetDAOCreator().CreateQuotationItemDAO().RetrieveByKey(QuotationId,RequestSeq);           
        //}

        //public Collection<QuotationItem> GetPendingAcknowledgeGoodsRejectionList(string MaterialNo)
        //{
        //    try
        //    {
        //        string whereCluase = "";                
        //        whereCluase = " MATNR like '" + Utility.EscapeSQL(MaterialNo) + "'";
        //        //orderCluase = " BANFN asc ";
        //        return this.mainController.GetDAOCreator().CreateQuotationItemDAO().RetrieveByQuery(whereCluase);
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.ExceptionLog(ex);
        //        throw (ex);
        //    }
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL.PurchaseOrder
{
    public class PurchaseExpeditingController
    {
        MainController mainController = null;
        public PurchaseExpeditingController(MainController mainController) 
        {
            this.mainController = mainController;
        }

        public Collection<PurchaseExpeditingVO> GetPurchaseExpeditingList(string materialNumber)
        {
            try
            {
                Collection<PurchaseExpeditingVO> vos = new Collection<PurchaseExpeditingVO>();

                string whereClause = " MATNR='" + Utility.EscapeSQL(materialNumber) + "' ";
                string orderClause = " EBELN asc, EBELP asc, ETENR asc ";

                Collection<PurchaseExpediting> items = mainController.GetDAOCreator().CreatePurchaseExpeditingDAO()
                    .RetrieveByQuery(whereClause, orderClause);

                foreach (PurchaseExpediting item in items)
                {
                    PurchaseExpeditingVO vo = new PurchaseExpeditingVO();
                    vo.ExpeditDate = item.ExpeditDate;
                    vo.ExpediteQuantity = item.ExpediteQuantity;
                    vo.ItemSequence = item.ItemSequence;
                    vo.MaterialNumber = item.MaterialNumber;
                    vo.OrderNumber = item.OrderNumber;
                    vo.PromiseDate1 = item.PromiseDate1;
                    vo.PromiseDate2 = item.PromiseDate2;
                    vo.RecordStatus = item.RecordStatus;
                    vo.ScheduleSequence = item.ScheduleSequence;
                    vo.UnitMeasure = item.UnitMeasure;

                    PurchaseOrderItemSchedule schedule = mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO()
                        .RetrieveByKey(item.OrderNumber, item.ItemSequence, item.ScheduleSequence);
                    if (schedule != null)
                    {
                        vo.DeliveryScheduleQuantity = schedule.DeliveryScheduleQuantity;
                        vo.OrderItemScheduleDate = schedule.OrderItemScheduleDate;
                    }
                    vos.Add(vo);
                }

                return vos;

            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }
        
        public void CreatePurchaseExpediting(Collection<PurchaseExpediting> expeditings)
        {
            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {
                    foreach (PurchaseExpediting vo in expeditings)
                    {
                        PurchaseExpediting expediting = mainController.GetDAOCreator().CreatePurchaseExpeditingDAO()
                            .RetrieveByKey(vo.OrderNumber, vo.ItemSequence, vo.ScheduleSequence);
                        if(expediting==null)
                        {
                            throw new Exception(string.Format("Purchase expediting record doesn't exist. Order Number:{0}, Item Sequence:{1}, Schedule Sequence:{2}.",
                                vo.OrderNumber, vo.ItemSequence, vo.ScheduleSequence)); 
                        }

                        if (string.Compare(expediting.RecordStatus, ExpediteStatus.Accept, true) == 0 ||
                            string.Compare(expediting.RecordStatus, ExpediteStatus.Reject, true) == 0 ||
                            string.Compare(expediting.RecordStatus, ExpediteStatus.Acknowledge, true) == 0 ||
                            string.Compare(expediting.RecordStatus, ExpediteStatus.Expedite, true) == 0)
                        {
                            throw new Exception(string.Format("Purchase expediting record has already been expedited by other user. Order Number:{0}, Item Sequence:{1}, Schedule Sequence:{2}.",
                                vo.OrderNumber, vo.ItemSequence, vo.ScheduleSequence)); 
                        }    
                        
                        expediting.ExpediteQuantity = vo.ExpediteQuantity;
                        expediting.ExpeditDate = vo.ExpeditDate;
                        expediting.RecordStatus = ExpediteStatus.Expedite;
                        mainController.GetDAOCreator().CreatePurchaseExpeditingDAO()
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

        public void AcknowledgePurchaseExpediting(Collection<PurchaseExpediting> expeditings)
        {
            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {
                    foreach (PurchaseExpediting vo in expeditings)
                    {
                        PurchaseExpediting expediting = mainController.GetDAOCreator().CreatePurchaseExpeditingDAO()
                            .RetrieveByKey(vo.OrderNumber, vo.ItemSequence, vo.ScheduleSequence);
                        if (expediting == null)
                        {
                            throw new Exception(string.Format("Purchase expediting record doesn't exist. Order Number:{0}, Item Sequence:{1}, Schedule Sequence:{2}.",
                                vo.OrderNumber, vo.ItemSequence, vo.ScheduleSequence));
                        }

                        if (string.Compare(expediting.RecordStatus, ExpediteStatus.Expedite, true) != 0)
                        {
                            throw new Exception(string.Format("Purchase expediting record has already been updated by other user. Order Number:{0}, Item Sequence:{1}, Schedule Sequence:{2}.",
                                vo.OrderNumber, vo.ItemSequence, vo.ScheduleSequence));
                        }

                        bool isFirst = true;
                        if (vo.PromiseDate2.HasValue)
                            isFirst = false;

                        expediting.RecordStatus = ExpediteStatus.Acknowledge; 
                        if (isFirst)
                            expediting.PromiseDate1 = vo.PromiseDate1;
                        else
                            expediting.PromiseDate2 = vo.PromiseDate2;

                        mainController.GetDAOCreator().CreatePurchaseExpeditingDAO()
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

        public void ConfirmExpeditingAcknowledgement(Collection<PurchaseExpediting> expeditings)
        {
            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {
                    foreach (PurchaseExpediting vo in expeditings)
                    {
                        PurchaseExpediting expediting = mainController.GetDAOCreator().CreatePurchaseExpeditingDAO()
                            .RetrieveByKey(vo.OrderNumber, vo.ItemSequence, vo.ScheduleSequence);
                        if (expediting == null)
                        {
                            throw new Exception(string.Format("Purchase expediting record doesn't exist. Order Number:{0}, Item Sequence:{1}, Schedule Sequence:{2}.",
                                vo.OrderNumber, vo.ItemSequence, vo.ScheduleSequence));
                        }

                        if (string.Compare(expediting.RecordStatus, ExpediteStatus.Acknowledge, true) != 0)
                        {
                            throw new Exception(string.Format("Purchase expediting record has already been updated by other user. Order Number:{0}, Item Sequence:{1}, Schedule Sequence:{2}.",
                                vo.OrderNumber, vo.ItemSequence, vo.ScheduleSequence));
                        }

                        //Accept
                        if (string.Compare(vo.RecordStatus, ExpediteStatus.Accept, true) == 0) 
                        {
                            expediting.RecordStatus = ExpediteStatus.Accept;
                            mainController.GetDAOCreator().CreatePurchaseExpeditingDAO()
                                .Update(tran, expediting);

                            //update PURSCH (Purchase Order Item Schedule)
                            PurchaseOrderItemSchedule schedule = mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO()
                            .RetrieveByKey(vo.OrderNumber, vo.ItemSequence, vo.ScheduleSequence);
                            if (schedule != null) 
                            {
                                schedule.ExpeditingPromiseDate = expediting.PromiseDate2.HasValue ? 
                                    expediting.PromiseDate2.Value : expediting.PromiseDate1.Value;
                                mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO()
                                    .Update(tran, schedule);
                            }
                        }

                        //Reject
                        if (string.Compare(vo.RecordStatus, ExpediteStatus.Reject, true) == 0)
                        {
                            //2nd rejection
                            if (expediting.PromiseDate2.HasValue)
                            {
                                expediting.RecordStatus = ExpediteStatus.Reject;
                                mainController.GetDAOCreator().CreatePurchaseExpeditingDAO()
                                    .Update(tran, expediting);
                            }
                            else //ask from 2nd acknowledgement 
                            {
                                expediting.RecordStatus = ExpediteStatus.Expedite;
                                mainController.GetDAOCreator().CreatePurchaseExpeditingDAO()
                                    .Update(tran, expediting);

                            }
                        }    
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

        public Collection<PurchaseOrderHeader> GetPendingExpeditingAcknowledgePOList()
        {
            try
            {
                Collection<PurchaseOrderHeader> orders = new Collection<PurchaseOrderHeader>(); 
                
                string whereCluase = "";
                string orderCluase = "";
                whereCluase = " LIFNR = '" + this.mainController.GetLoginUserVO().SupplierId + "' ";
                whereCluase += " AND isnull(e.RECSTS,'') = '" + ExpediteStatus.Expedite + "' ";

                Collection<PurchaseExpeditingView> epvs = this.mainController.GetDAOCreator().CreatePurchaseExpeditingViewDAO()
                    .RetrieveByQuery(whereCluase);

                if (epvs.Count == 0)
                    return orders;

                whereCluase = "";
                foreach (PurchaseExpeditingView epv in epvs)
                {
                    if (whereCluase == "")
                    {
                        whereCluase += "(";
                    }
                    else
                    {
                        whereCluase += " or ";
                    }
                    whereCluase += "EBELN='" + Utility.EscapeSQL(epv.OrderNumber.Trim()) + "'";
                }
                if (whereCluase != "") whereCluase += ")";

                orderCluase = " EBELN asc ";
                orders = this.mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().RetrieveByQuery(whereCluase, orderCluase);
                return orders;
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Collection<PurchaseOrderItem> GetExpeditingOrderItems(string orderNumber)
        {
            try
            {
                Collection<PurchaseOrderItem> items = new Collection<PurchaseOrderItem>();

                string whereClause = "";
                string orderClause = "";

                whereClause = " EBELN = '" + Utility.EscapeSQL(orderNumber) + "' ";
                whereClause += " AND isnull(RECSTS,'') = '" + ExpediteStatus.Expedite + "' ";

                Collection<PurchaseExpediting> eps = this.mainController.GetDAOCreator().CreatePurchaseExpeditingDAO()
                   .RetrieveByQuery(whereClause);

                if (eps.Count == 0)
                    return items;

                whereClause = "";
                foreach (PurchaseExpediting ep in eps)
                {
                    if (whereClause == "")
                    {
                        whereClause += "(";
                    }
                    else
                    {
                        whereClause += " or ";
                    }
                    whereClause += "EBELP='" + Utility.EscapeSQL(ep.ItemSequence.Trim()) + "'";
                }
                if (whereClause != "") whereClause += ")";


                whereClause += " AND EBELN='" + Utility.EscapeSQL(orderNumber) + "' ";
                orderClause = " EBELP asc ";

                items= mainController.GetDAOCreator().
                    CreatePurchaseOrderItemDAO().RetrieveByQuery(whereClause, orderClause);
                return items;
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Collection<PurchaseExpeditingVO> GetExpeditingOrderItemSchedules(string orderNumber, string itemSeq)
        {
            try
            {
                Collection<PurchaseExpeditingVO> vos = new Collection<PurchaseExpeditingVO>();

                string whereCluase = "";
                string orderCluase = "";

                whereCluase = " EBELN = '" + Utility.EscapeSQL(orderNumber) + "' ";
                whereCluase += " AND EBELP = '" + Utility.EscapeSQL(itemSeq) + "' ";
                whereCluase += " AND isnull(RECSTS,'') = '" + ExpediteStatus.Expedite + "' ";

                orderCluase = " ETENR asc ";

                Collection<PurchaseExpediting> eps = this.mainController.GetDAOCreator().CreatePurchaseExpeditingDAO()
                   .RetrieveByQuery(whereCluase, orderCluase);

                if (eps.Count == 0)
                    return vos;

                foreach (PurchaseExpediting ep in eps)
                {
                    PurchaseExpeditingVO vo = new PurchaseExpeditingVO();
                    vo.ExpeditDate = ep.ExpeditDate;
                    vo.ExpediteQuantity = ep.ExpediteQuantity;
                    vo.ItemSequence = ep.ItemSequence;
                    vo.MaterialNumber = ep.MaterialNumber;
                    vo.OrderNumber = ep.OrderNumber;
                    vo.PromiseDate1 = ep.PromiseDate1;
                    vo.PromiseDate2 = ep.PromiseDate2;
                    vo.RecordStatus = ep.RecordStatus;
                    vo.ScheduleSequence = ep.ScheduleSequence;
                    vo.UnitMeasure = ep.UnitMeasure;

                    PurchaseOrderItemSchedule schedule = mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO()
                        .RetrieveByKey(ep.OrderNumber, ep.ItemSequence, ep.ScheduleSequence);
                    if (schedule != null)
                    {
                        vo.DeliveryScheduleQuantity = schedule.DeliveryScheduleQuantity;
                        vo.OrderItemScheduleDate = schedule.OrderItemScheduleDate;
                        vo.DeliveredQuantity = schedule.DeliveredQuantity;
                        vo.DeliveryDate = schedule.DeliveryDate; 
                    }
                    vos.Add(vo);
                }

                return vos;
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }
    }
}

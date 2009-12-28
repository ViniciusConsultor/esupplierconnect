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
                        
                        if(string.Compare(expediting.RecordStatus,ExpediteStatus.New,true)!=0)
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

    }
}

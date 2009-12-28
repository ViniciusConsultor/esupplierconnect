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
                    string orderNumber = "";
                    string itemSeq = "";
                    string scheduleSeq = "";

                    foreach (PurchaseExpediting vo in expeditings)
                    {
                        PurchaseExpediting expediting = mainController.GetDAOCreator().CreatePurchaseExpeditingDAO()
                            .RetrieveByKey(vo.OrderNumber, vo.ItemSequence, vo.ScheduleSequence);
                        if(expediting==null)
                        {
                            throw new Exception(string.Format("Order schedule record doesn't exist. Order Number:{0}, Item Sequence:{1}, Schedule Sequence:{2}.",
                                vo.OrderNumber, vo.ItemSequence, vo.ScheduleSequence)); 
                        }
                        
                        if(string.Compare(expediting.RecordStatus,ExpediteStatus.New,true)!=0)
                        {
                            throw new Exception(string.Format("Order schedule record has already been expedited by other user. Order Number:{0}, Item Sequence:{1}, Schedule Sequence:{2}.",
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



    }
}

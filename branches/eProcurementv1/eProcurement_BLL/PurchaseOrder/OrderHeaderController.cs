using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL.PurchaseOrder
{
    public class OrderHeaderController
    {
        MainController mainController = null;
        public OrderHeaderController(MainController mainController) 
        {
            this.mainController = mainController;
        }

        public Collection<PurchaseOrderHeader> GetPendingAckPOList(string orderNumber, Nullable<long> fromDate, Nullable<long> toDate,string buyerName)
        {
            try
            {
                string whereCluase = "";
                string orderCluase = "";
                whereCluase = " LIFNR = '" + this.mainController.GetLoginUserVO().SupplierId + "'";
                whereCluase += " AND isnull(ACKSTS,'') = '" + POAckStatus.No + "' ";
                whereCluase += " AND isnull(STAT,'') <> '" + POStatus.Delete + "' ";
                if (orderNumber != "")
                {
                    whereCluase += " AND EBELN like '" + Utility.EscapeSQL(orderNumber) + "' ";
                }
                if (buyerName != "")
                {
                    whereCluase += " AND BUYER like '" + Utility.EscapeSQL(buyerName) + "' ";
                }  
                if (fromDate.HasValue)
                {
                    whereCluase += " AND BEDAT >= " + fromDate.Value;
                }
                if (toDate.HasValue)
                {
                    whereCluase += " AND BEDAT <= " + toDate.Value;
                }

                orderCluase = " EBELN asc ";
                return this.mainController.GetDAOCreator().CreatePurchaseOrderHeaderDAO().RetrieveByQuery(whereCluase, orderCluase);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }


        
        /*
      public static Collection<PurchaseOrderHeader> GetPendingAckPOList(string orderNumber,DateTime startDate,DateTime endDate,string status)
      {
          try
          {
              string whereCluase = "";
              string orderCluase = "";
              whereCluase = " ACKSTS = '" + POAckStatus.PendingAcknowledge + "'";
              if (orderNumber != "") 
              {
                  whereCluase += " AND EBELN = '" + Utility.EscapeSQL(orderNumber) + "' ";
              }
              if (startDate != DateTime.MinValue)
              {
                  whereCluase += " AND BEDAT >= " + Utility.GetStoredDateValue(startDate);
              }
              if (endDate != DateTime.MinValue)
              {
                  whereCluase += " AND BEDAT <= " + Utility.GetStoredDateValue(endDate);
              }
                
              orderCluase = " EBELN asc ";
              return PurchaseOrderHeaderDAO.RetrieveByQuery(whereCluase, orderCluase);
          }
          catch (Exception ex)
          {
              Utility.ExceptionLog(ex);
              throw (ex);
          }
      }

      public static Collection<PurchaseOrderHeaderText> GetPurchaseOrderHeaderText(string orderNumber)
      {
          try
          {
              string whereCluase = "";
              string orderCluase = "";
              whereCluase = " EBELN = '" + Utility.EscapeSQL(orderNumber) + "'";
              orderCluase = " TXTITM asc ";
              return PurchaseOrderHeaderTextDAO.RetrieveByQuery(whereCluase, orderCluase);
          }
          catch (Exception ex)
          {
              Utility.ExceptionLog(ex);
              throw (ex);
          }
      }

      public static void AcknowledgePurchaseOrder(PurchaseOrderHeader header,Collection<PurchaseOrderItemSchedule> schedules) 
      {
          try
          {
              EpTransaction tran = DataManager.BeginTransaction();
              try
              {
                  PurchaseOrderHeaderDAO.Update(tran, header);

                  foreach (PurchaseOrderItemSchedule schedule in schedules)
                  {
                      PurchaseOrderItemScheduleDAO.Update(tran, schedule);
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
       * */
    }
}

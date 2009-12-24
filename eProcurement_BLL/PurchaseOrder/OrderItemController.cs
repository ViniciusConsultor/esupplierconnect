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

        
        /*
       public static Collection<PurchaseOrderItem> GetPurchaseOrderItems(string orderNumber)
       {
           try
           {
               string whereCluase = "";
               string orderCluase = "";
               whereCluase = " EBELN = '" + Utility.EscapeSQL(orderNumber) + "'";
               orderCluase = " EBELP asc ";
               return PurchaseOrderItemDAO.RetrieveByQuery(whereCluase, orderCluase);
           }
           catch (Exception ex)
           {
               Utility.ExceptionLog(ex);
               throw (ex);
           }
       }

       public static Collection<PurchaseOrderItemSchedule> GetPurchaseOrderScheduleItems(string orderNumber, string ItemSequenceNo)
       {
           try
           {
               string whereCluase = "";
               string orderCluase = "";
               whereCluase = " EBELN = '" + Utility.EscapeSQL(orderNumber) + "' AND EBELP='" + Utility.EscapeSQL(ItemSequenceNo) + "' ";
               orderCluase = " ETENR asc ";
               return PurchaseOrderItemScheduleDAO.RetrieveByQuery(whereCluase, orderCluase);
           }
           catch (Exception ex)
           {
               Utility.ExceptionLog(ex);
               throw (ex);
           }
       }

       public static Collection<PurchaseItemText> GetPurchaseItemTexts(string orderNumber, string ItemSequenceNo)
       {
           try
           {
               string whereCluase = "";
               string orderCluase = "";
               whereCluase = " EBELN = '" + Utility.EscapeSQL(orderNumber) + "' AND EBELP='" + Utility.EscapeSQL(ItemSequenceNo) + "' ";
               orderCluase = " TXTITM asc ";
               return PurchaseItemTextDAO.RetrieveByQuery(whereCluase, orderCluase);
           }
           catch (Exception ex)
           {
               Utility.ExceptionLog(ex);
               throw (ex);
           }
       }

       public static Collection<PurchaseOrderSubcontractComponent> GetPurchaseOrderSubcontractComponents(string orderNumber, string ItemSequenceNo)
       {
           try
           {
               string whereCluase = "";
               string orderCluase = "";
               whereCluase = " EBELN = '" + Utility.EscapeSQL(orderNumber) + "' AND EBELP='" + Utility.EscapeSQL(ItemSequenceNo) + "' ";
               orderCluase = " COMPL asc ";
               return PurchaseOrderSubcontractComponentDAO.RetrieveByQuery(whereCluase, orderCluase);
           }
           catch (Exception ex)
           {
               Utility.ExceptionLog(ex);
               throw (ex);
           }
       }

       public static Collection<PurchaseOrderServiceItem> GetPurchaseOrderServiceItem(string orderNumber, string ItemSequenceNo)
       {
           try
           {
               string whereCluase = "";
               string orderCluase = "";
               whereCluase = " EBELN = '" + Utility.EscapeSQL(orderNumber) + "' AND EBELP='" + Utility.EscapeSQL(ItemSequenceNo) + "' ";
               orderCluase = " LBLN1 asc ";
               return PurchaseOrderServiceItemDAO.RetrieveByQuery(whereCluase, orderCluase);
           }
           catch (Exception ex)
           {
               Utility.ExceptionLog(ex);
               throw (ex);
           }
       }    
        */
    }
}

//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Vinss, Rajendran Vinoth Prabu
// Created Date : 26 Dec 2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This Controller class enables to provide methods for accessing Delivery DAO, inorder to access database table [DLVORD]  
//       -Insert, Delete Update and Retrieve.
//	  
// Revision History:
//    1.0:
//      Author  : Vinss
//      Date    : 26 Dec 2009
//      Comments: Created class 
//    
// Copyright 2008-2010 ISS/Fujitec
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL.DeliveryOrder
{
    public class DeliveryOrderController
    {
        MainController mainController = null;
        /// <summary>
        /// public DeliveryOrderController(MainController maincontroller)
        /// Parameterized Constructor - To initialize MainController
        /// </summary>
        /// <param name="maincontroller">main controller goes here</param>
        public void DeliveryOrderController(MainController maincontroller)
        {

            this.mainController = mainController;
        
        }
        /// <summary>
        /// public void InsertDeliveryOrder(eProcurement_DAL.DeliveryOrder deliveryorder)
        /// To create Delivery Order
        /// </summary>
        /// <param name="deliveryorder"></param>
        public void InsertDeliveryOrder(eProcurement_DAL.DeliveryOrder deliveryorder)
        {
            try
            {
                mainController.GetDAOCreator().CreateDeliveryOrderDAO().Insert(DeliveryOrder);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        /// <summary>
        /// public void UpdateDeliveryOrder(eProcurement_DAL.DeliveryOrder deliveryorder)
        /// To update existing Delivery Order
        /// </summary>
        /// <param name="deliveryorder">deliveryorder goes here</param>
        public void UpdateDeliveryOrder(eProcurement_DAL.DeliveryOrder deliveryorder)
        {
            try
            {
                mainController.GetDAOCreator().CreateDeliveryOrderDAO().Update(deliveryorder);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        /// <summary>
        /// public void DeleteDeliveryOrder(eProcurement_DAL.DeliveryOrder deliveryorder)
        /// To delete delivery Order
        /// </summary>
        /// <param name="deliveryorder">deliveryorder goes here</param>
        public void DeleteDeliveryOrder(eProcurement_DAL.DeliveryOrder deliveryorder)
        {
            try
            {
                mainController.GetDAOCreator().CreateDeliveryOrderDAO().Delete(deliveryorder);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }


        /// <summary>
        ///  public Collection<eProcurement_DAL.DeliveryOrder> RetrieveAllDeliveryOrder (eProcurement_DAL.DeliveryOrder deliveryorder)
        /// To retrieve all Delivery Order
        /// </summary>
        /// <returns>Collection<eProcurement_DAL.DeliveryOrder> goes here</returns>
        public Collection<eProcurement_DAL.DeliveryOrder> RetrieveAllDeliveryOrder ()
        {
            try
            {
                return mainController.GetDAOCreator().CreateDeliveryOrderDAO().RetrieveAll();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierid"></param>
        /// <returns></returns>
        public Collection<eProcurement_DAL.DeliveryOrder> RetrieveAllDeliveryOrderBy(string supplierid)
        {
            try
            {
                string whereClause = ""
                return mainController.GetDAOCreator().CreateDeliveryOrderDAO().RetrieveByQuery(su;
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        /// <summary>
        /// public eProcurement_DAL.DeliveryOrder RetrieveByKeyDeliveryOrder(string ordernumber, string itemsequence, string deliverynumber)
        /// To retrieve Delivery Order By Key
        /// </summary>
        /// <param name="ordernumber">ordernumber goes here</param>
        /// <param name="itemsequence">itemsequence goes here</param>
        /// <param name="deliverynumber">deliverynumber goes here</param>
        /// <returns>eProcurement_DAL.DeliveryOrder returns here</returns>
         public eProcurement_DAL.DeliveryOrder RetrieveByKeyDeliveryOrder(string ordernumber, string itemsequence, string deliverynumber)
        {
            try
            {
                return mainController.GetDAOCreator().CreateDeliveryOrderDAO().RetrieveByKey(ordernumber, itemsequence, deliverynumber);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }




       





    }
}
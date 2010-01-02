//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Vinss, Rajendran Vinoth Prabu & EI EI 
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

namespace eProcurement_BLL.Delivery
{
    public class DeliveryController
    {
        MainController mainController = null;

        /// <summary>
        /// public DeliveryOrderController(MainController maincontroller)
        /// Parameterized Constructor - To initialize MainController
        /// </summary>
        /// <param name="maincontroller">main controller goes here</param>
        public DeliveryController(MainController maincontroller)
        {

            this.mainController = maincontroller;
        
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
                mainController.GetDAOCreator().CreateDeliveryOrderDAO().Insert(deliveryorder);
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
        /// public Collection<eProcurement_DAL.RejectedGood> RetrieveAllRejectedGood()
        /// To retrieve all Rejected Goods Details
        /// </summary>
        /// <returns>Collection<eProcurement_DAL.RejectedGood> returns here</returns>
        public Collection<eProcurement_DAL.RejectedGood> RetrieveAllRejectedGood()
        {
            try
            {
                return mainController.GetDAOCreator().CreateRejectedGoodDAO().RetrieveAll();
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


        /// <summary>
        /// public Collection<eProcurement_DAL.DeliveryOrder> RetrieveByQueryDeliveryOrder(string ordernumber, string itemsequence, string deliverynumber,string supplierid)
        /// </summary>
        /// <param name="ordernumber">ordernumber goes here</param>
        /// <param name="itemsequence">itemsequence goes here</param>
        /// <param name="deliverynumber">deliverynumber goes here</param>
        /// <param name="supplierid">supplierid goes here</param>
        /// <returns>Collection<eProcurement_DAL.DeliveryOrder> returns here</returns>
        public Collection<eProcurement_DAL.DeliveryOrder> RetrieveByQueryDeliveryOrder(string ordernumber, string materialnumber, string deliverynumber, string supplierid, Nullable<long> fromdate, Nullable<long> todate)
        {
            try
            {
                string whereclause = "LIFNR='" + Utility.EscapeSQL(supplierid) + "' ";

                if(ordernumber != "")
                     whereclause += "AND EBELN like'" + Utility.EscapeSQL(ordernumber) + "' ";

                if(materialnumber != "")
                    whereclause += " AND MATNR like'" + Utility.EscapeSQL(materialnumber) + "' ";

                if(deliverynumber != "")
                    whereclause += "  AND VBELN like'" + Utility.EscapeSQL(deliverynumber) + "' ";

                if (fromdate.HasValue)
                    whereclause += " AND BEDAT >= " + fromdate.Value;

               if (todate.HasValue)
                   whereclause += " AND BEDAT <= " + todate.Value;
            


                return mainController.GetDAOCreator().CreateDeliveryOrderDAO().RetrieveByQuery(whereclause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }


        /// <summary>
        /// public Collection<eProcurement_DAL.DeliveryOrder> RetrieveByQueryRejectedGood(string ordernumber, string materialnumber, string deliverynumber, string documentnumber, string supplierid)
        /// 
        /// To retrieve RejectedGood based on search criteria
        /// </summary>
        /// <param name="ordernumber">ordernumber goes here</param>
        /// <param name="materialnumber">materialnumber goes here</param>
        /// <param name="deliverynumber">deliverynumber goes here</param>
        /// <param name="documentnumber">documentnumber goes here</param>
        /// <param name="supplierid">supplierid goes here</param>
        /// <returns>Collection<eProcurement_DAL.RejectedGood> returns here</returns>
        public Collection<eProcurement_DAL.RejectedGood> RetrieveByQueryRejectedGood(string ordernumber, string materialnumber, string deliverynumber, string documentnumber, string supplierid)
        {
            try
            {
                string whereclause = "LIFNR='" + Utility.EscapeSQL(supplierid) + "' ";

                if (ordernumber != "")
                    whereclause += "AND EBELN like'" + Utility.EscapeSQL(ordernumber) + "' ";

                if (materialnumber != "")
                    whereclause += " AND MATNR like'" + Utility.EscapeSQL(materialnumber) + "' ";

                if (deliverynumber != "")
                    whereclause += "  AND VBELN like'" + Utility.EscapeSQL(deliverynumber) + "' ";

                if (deliverynumber != "")
                    whereclause += "  AND DOCNO like'" + Utility.EscapeSQL(documentnumber) + "' ";



                return mainController.GetDAOCreator().CreateRejectedGoodDAO().RetrieveByQuery(whereclause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }


        public RejectedGood GetRejectedGood(string orderNumber, string itemSequence, string documentNumber)
        {
            return mainController.GetDAOCreator().CreateRejectedGoodDAO().RetrieveByKey(orderNumber, itemSequence, documentNumber);
        }

       /* public Collection<RejectedGood> EnquirePendingAckPOList(string orderNumber, string itemSequence, string documentNumber, string materialNumber)
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
                        RejectedGood rejectedgood = mainController.GetDAOCreator().CreateRejectedGoodDAO()
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

                        rejectedgood.AcknowledgeStatus = RejAckStatus.Yes;

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



        */
       





    }
}
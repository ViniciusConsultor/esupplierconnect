using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL
{
    public class ShortageMaterialController
    {
        MainController mainController = null;
        public ShortageMaterialController(MainController mainController) 
        {
            this.mainController = mainController;
        }

        public Collection<ShortageMaterialVO> GetShortageMaterialList(string materialNumber)
        {
            try
            {
                Collection<ShortageMaterialVO> stMaterialVOs = new Collection<ShortageMaterialVO>();
                string whereClause = "";
                if (materialNumber != "")
                    whereClause = " MATNR = '" + Utility.EscapeSQL(materialNumber) + "' ";
                string orderClause = " MATNR asc ";
                Collection<ShortageMaterial> stMaterials = mainController.GetDAOCreator().CreateShortageMaterialDAO()
                    .RetrieveByQuery(whereClause,orderClause);
                foreach (ShortageMaterial stMaterial in stMaterials) 
                {
                    ShortageMaterialVO stMaterialVO = new ShortageMaterialVO();
                    stMaterialVO.MaterialNumber = stMaterial.MaterialNumber;
                    stMaterialVO.ShortageQuantity = stMaterial.ShortageQuantity;
                    stMaterialVO.Plant = stMaterial.Plant;

                    MaterialStock mStock = mainController.GetDAOCreator().CreateMaterialStockDAO()
                        .RetrieveByKey(stMaterial.MaterialNumber, stMaterial.Plant);
                    if (mStock != null) 
                    {
                        stMaterialVO.MaterialDescription = mStock.MaterialDescription;
                        stMaterialVO.InspectionStock = mStock.InspectionStock;
                        stMaterialVO.UnrestrictedStock = mStock.UnrestrictedStock;
                        stMaterialVO.UnitOfMeasure = mStock.UnitOfMeasure;
                    }

                    stMaterialVOs.Add(stMaterialVO); 
                }

                return stMaterialVOs;
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
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
    }

}

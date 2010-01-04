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

        public void ProcessShortageMaterialList()
        {
            try
            {
                mainController.GetDAOCreator().CreateExecuteCommandDAO().ExpeditePurchase(null);   
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
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

        public Collection<ShortageMaterialVO> GetExpeditingShortageMaterialList(string materialNumber)
        {
            try
            {
                Collection<ShortageMaterialVO> stMaterialVOs = new Collection<ShortageMaterialVO>();
               
                string whereClause = "";
                string materialCheckNo = "";

                Collection<string> materialNos = new Collection<string>();
                if (materialNumber != "")
                    whereClause = " MATNR = '" + Utility.EscapeSQL(materialNumber) + "' ";
                Collection<PurchaseExpediting> items = mainController.GetDAOCreator().CreatePurchaseExpeditingDAO()
                    .RetrieveByQuery(whereClause);
                foreach (PurchaseExpediting item in items)
                {
                    materialCheckNo = item.MaterialNumber.Trim().ToUpper();
                    if (!materialNos.Contains(materialCheckNo))
                        materialNos.Add(materialCheckNo);
                }

                if (materialNos.Count == 0)
                    return stMaterialVOs;

                whereClause = "";
                if (materialNumber != "")
                    whereClause = " MATNR = '" + Utility.EscapeSQL(materialNumber) + "' ";
                string orderClause = " MATNR asc ";
                Collection<ShortageMaterial> stMaterials = mainController.GetDAOCreator().CreateShortageMaterialDAO()
                    .RetrieveByQuery(whereClause, orderClause);
                foreach (ShortageMaterial stMaterial in stMaterials)
                {
                    //Only show the shortage material which has expedite records
                    materialCheckNo = stMaterial.MaterialNumber.Trim().ToUpper();
                    if (materialNos.Contains(materialCheckNo)) 
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
                }

                return stMaterialVOs;
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace eProcurement_DAL
{
    public abstract class DAOCreator
    {
        private static DAOCreator daoCreator = null;
        public static DAOCreator GetDAOCreator(string storeType) 
        {
		    if(daoCreator == null){
                switch (storeType)
                {
			        case "SQLSERVER":
                        daoCreator = new SQLServerDAOCreator();
				        break;
			        default:
                        daoCreator = new SQLServerDAOCreator();
				        break;
			    }	
		    }
		    return daoCreator;
	    }

        public abstract IAccessMatrixDAO CreateAccessMatrixDAO();
        public abstract IDeliveryOrderDAO CreateDeliveryOrderDAO();
        public abstract IFunctionDAO CreateFunctionDAO();
        public abstract IMaterialRequirementDAO CreateMaterialRequirementDAO();
        public abstract IMaterialStockDAO CreateMaterialStockDAO();
        public abstract INotificationDAO CreateNotificationDAO();
        public abstract IPurchaseExpeditingDAO CreatePurchaseExpeditingDAO();
        public abstract IPurchaseHeaderTextDAO CreatePurchaseHeaderTextDAO();
        public abstract IPurchaseItemTextDAO CreatePurchaseItemTextDAO();
        public abstract IPurchaseOrderHeaderDAO CreatePurchaseOrderHeaderDAO();
        public abstract IPurchaseOrderHistoryDAO CreatePurchaseOrderHistoryDAO();
        public abstract IPurchaseOrderItemDAO CreatePurchaseOrderItemDAO();
        public abstract IPurchaseOrderItemScheduleDAO CreatePurchaseOrderItemScheduleDAO();
        public abstract IPurchaseOrderServiceItemDAO CreatePurchaseOrderServiceItemDAO();
        public abstract IPurchaseServiceTaskDAO CreatePurchaseServiceTaskDAO();
        public abstract IQuotationHeaderDAO CreateQuotationHeaderDAO();
        public abstract IQuotationItemDAO CreateQuotationItemDAO();
        public abstract IRequisitionHeaderDAO CreateRequisitionHeaderDAO();
        public abstract IRequisitionItemDAO CreateRequisitionItemDAO();
        public abstract IShortageMaterialDAO CreateShortageMaterialDAO();
        public abstract ISubcontractorMaterialDAO CreateSubcontractorMaterialDAO();
        public abstract ISupplierDAO CreateSupplierDAO();
        public abstract IUserDAO CreateUserDAO();
        public abstract IContractHeaderDAO CreateContractHeaderDAO();
        public abstract IContractItemDAO CreateContractItemDAO();
        public abstract IPurchaseExpeditingViewDAO CreatePurchaseExpeditingViewDAO();
        public abstract IRejectedGoodDAO CreateRejectedGoodDAO();
        public abstract IPurchaseGroupDAO CreatePurchaseGroupDAO();
        public abstract IAttachmentDAO CreateAttachmentDAO(bool includeAttachmentData);
       

    }
}

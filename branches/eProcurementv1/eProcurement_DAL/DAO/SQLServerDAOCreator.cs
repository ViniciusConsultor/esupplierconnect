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
    public class SQLServerDAOCreator : DAOCreator
    {
        private AccessMatrixDAO accessMatrixDAO = null;
        private DeliveryOrderDAO deliveryOrderDAO = null;
        private FunctionDAO functionDAO = null;
        private MaterialRequirementDAO materialRequirementDAO = null;
        private MaterialStockDAO materialStockDAO = null;
        private NotificationDAO notificationDAO = null;
        private PurchaseExpeditingDAO purchaseExpeditingDAO = null;
        private PurchaseHeaderTextDAO purchaseHeaderTextDAO = null;
        private PurchaseItemTextDAO purchaseItemTextDAO = null;
        private PurchaseOrderHeaderDAO purchaseOrderHeaderDAO = null;
        private PurchaseOrderHistoryDAO purchaseOrderHistoryDAO = null;
        private PurchaseOrderItemDAO purchaseOrderItemDAO = null;
        private PurchaseOrderItemScheduleDAO purchaseOrderItemScheduleDAO = null;
        private PurchaseOrderServiceItemDAO purchaseOrderServiceItemDAO = null;
        private PurchaseServiceTaskDAO purchaseServiceTaskDAO = null;
        private QuotationHeaderDAO quotationHeaderDAO = null;
        private QuotationItemDAO quotationItemDAO = null;
        private RequisitionHeaderDAO requisitionHeaderDAO = null;
        private RequisitionItemDAO requisitionItemDAO = null;
        private ShortageMaterialDAO shortageMaterialDAO = null;
        private SubcontractorMaterialDAO subcontractorMaterialDAO = null;
        private SupplierDAO supplierDAO = null;
        private UserDAO userDAO = null;
        private ContractItemDAO contractItemDAO = null;
        private ContractHeaderDAO contractHeaderDAO = null;
        private PurchaseExpeditingViewDAO purchaseExpeditingViewDAO = null;
        private RejectedGoodDAO rejectedGoodDAO = null;
        

        public override IAccessMatrixDAO CreateAccessMatrixDAO() 
        {
            if (this.accessMatrixDAO == null)
                this.accessMatrixDAO = new AccessMatrixDAO();
            return this.accessMatrixDAO;
        }

        public override IDeliveryOrderDAO CreateDeliveryOrderDAO()
        {
            if (this.deliveryOrderDAO == null)
                this.deliveryOrderDAO = new DeliveryOrderDAO();
            return this.deliveryOrderDAO;
        }

        public override IFunctionDAO CreateFunctionDAO()
        {
            if (this.functionDAO == null)
                this.functionDAO = new FunctionDAO();
            return this.functionDAO;
        }

        public override IMaterialRequirementDAO CreateMaterialRequirementDAO()
        {
            if (this.materialRequirementDAO == null)
                this.materialRequirementDAO = new MaterialRequirementDAO();
            return this.materialRequirementDAO;
        }

        public override IMaterialStockDAO CreateMaterialStockDAO()
        {
            if (this.materialStockDAO == null)
                this.materialStockDAO = new MaterialStockDAO();
            return this.materialStockDAO;
        }

        public override INotificationDAO CreateNotificationDAO()
        {
            if (this.notificationDAO == null)
                this.notificationDAO = new NotificationDAO();
            return this.notificationDAO;
        }

        public override IPurchaseExpeditingDAO CreatePurchaseExpeditingDAO()
        {
            if (this.purchaseExpeditingDAO == null)
                this.purchaseExpeditingDAO = new PurchaseExpeditingDAO();
            return this.purchaseExpeditingDAO;
        }

        public override IPurchaseHeaderTextDAO CreatePurchaseHeaderTextDAO()
        {
            if (this.purchaseHeaderTextDAO == null)
                this.purchaseHeaderTextDAO = new PurchaseHeaderTextDAO();
            return this.purchaseHeaderTextDAO;
        }

        public override IPurchaseItemTextDAO CreatePurchaseItemTextDAO()
        {
            if (this.purchaseItemTextDAO == null)
                this.purchaseItemTextDAO = new PurchaseItemTextDAO();
            return this.purchaseItemTextDAO;
        }

        public override IPurchaseOrderHeaderDAO CreatePurchaseOrderHeaderDAO()
        {
            if (this.purchaseOrderHeaderDAO == null)
                this.purchaseOrderHeaderDAO = new PurchaseOrderHeaderDAO();
            return this.purchaseOrderHeaderDAO;
        }

        public override IPurchaseOrderHistoryDAO CreatePurchaseOrderHistoryDAO()
        {
            if (this.purchaseOrderHistoryDAO == null)
                this.purchaseOrderHistoryDAO = new PurchaseOrderHistoryDAO();
            return this.purchaseOrderHistoryDAO;
        }

        public override IPurchaseOrderItemDAO CreatePurchaseOrderItemDAO()
        {
            if (this.purchaseOrderItemDAO == null)
                this.purchaseOrderItemDAO = new PurchaseOrderItemDAO();
            return this.purchaseOrderItemDAO;
        }

        public override IPurchaseOrderItemScheduleDAO CreatePurchaseOrderItemScheduleDAO()
        {
            if (this.purchaseOrderItemScheduleDAO == null)
                this.purchaseOrderItemScheduleDAO = new PurchaseOrderItemScheduleDAO();
            return this.purchaseOrderItemScheduleDAO;
        }

        public override IPurchaseOrderServiceItemDAO CreatePurchaseOrderServiceItemDAO()
        {
            if (this.purchaseOrderServiceItemDAO == null)
                this.purchaseOrderServiceItemDAO = new PurchaseOrderServiceItemDAO();
            return this.purchaseOrderServiceItemDAO;
        }

        public override IPurchaseServiceTaskDAO CreatePurchaseServiceTaskDAO()
        {
            if (this.purchaseServiceTaskDAO == null)
                this.purchaseServiceTaskDAO = new PurchaseServiceTaskDAO();
            return this.purchaseServiceTaskDAO;
        }

        public override IQuotationHeaderDAO CreateQuotationHeaderDAO()
        {
            if (this.quotationHeaderDAO == null)
                this.quotationHeaderDAO = new QuotationHeaderDAO();
            return this.quotationHeaderDAO;
        }

        public override IQuotationItemDAO CreateQuotationItemDAO()
        {
            if (this.quotationItemDAO == null)
                this.quotationItemDAO = new QuotationItemDAO();
            return this.quotationItemDAO;
        }

        public override IRequisitionHeaderDAO CreateRequisitionHeaderDAO()
        {
            if (this.requisitionHeaderDAO == null)
                this.requisitionHeaderDAO = new RequisitionHeaderDAO();
            return this.requisitionHeaderDAO;
        }

        public override IRequisitionItemDAO CreateRequisitionItemDAO()
        {
            if (this.requisitionItemDAO == null)
                this.requisitionItemDAO = new RequisitionItemDAO();
            return this.requisitionItemDAO;
        }

        public override IShortageMaterialDAO CreateShortageMaterialDAO()
        {
            if (this.shortageMaterialDAO == null)
                this.shortageMaterialDAO = new ShortageMaterialDAO();
            return this.shortageMaterialDAO;
        }

        public override ISubcontractorMaterialDAO CreateSubcontractorMaterialDAO()
        {
            if (this.subcontractorMaterialDAO == null)
                this.subcontractorMaterialDAO = new SubcontractorMaterialDAO();
            return this.subcontractorMaterialDAO;
        }

        public override ISupplierDAO CreateSupplierDAO()
        {
            if (this.supplierDAO == null)
                this.supplierDAO = new SupplierDAO();
            return this.supplierDAO;
        }

        public override IUserDAO CreateUserDAO()
        {
            if (this.userDAO == null)
                this.userDAO = new UserDAO();
            return this.userDAO;
        }

        public override IContractHeaderDAO CreateContractHeaderDAO()
        {
            if (this.contractHeaderDAO == null)
                this.contractHeaderDAO = new ContractHeaderDAO();
            return this.contractHeaderDAO;
        }

        public override IContractItemDAO CreateContractItemDAO()
        {
            if (this.contractItemDAO == null)
                this.contractItemDAO = new ContractItemDAO();
            return this.contractItemDAO;
        }

        public override IPurchaseExpeditingViewDAO CreatePurchaseExpeditingViewDAO() 
        {
            if (this.purchaseExpeditingViewDAO == null)
                this.purchaseExpeditingViewDAO = new PurchaseExpeditingViewDAO();
            return this.purchaseExpeditingViewDAO;
        }

        public override IRejectedGoodDAO CreateRejectedGoodDAO()
        {
            if (this.rejectedGoodDAO == null)
                this.rejectedGoodDAO = new RejectedGoodDAO();
            return this.rejectedGoodDAO;
            
        }
    }
}

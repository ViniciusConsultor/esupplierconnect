using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using eProcurement_DAL;
using eProcurement_BLL.UserManagement;
using eProcurement_BLL.PurchaseOrder;
using eProcurement_BLL.Notification;
using eProcurement_BLL.PurchaseContract;
using eProcurement_BLL.Delivery;
using eProcurement_BLL.Quotation;

namespace eProcurement_BLL
{
    public class MainController
    {
        //Data Store Type, It's used to get related DAOCreator
        private static string m_DataStoreType = "";
        public static string DataStoreType
        {
            set { m_DataStoreType = value; }
            get { return m_DataStoreType; }
        }
        
        // LoginUserVO
        private LoginUserVO loginUserVO = null;
        
        //DAOCreator
        private DAOCreator daoCreator = null;

        //Controllers
        private LoginController loginController = null;
        private UserController userController = null;
        private OrderHeaderController orderHeaderController = null;
        private OrderItemController orderItemController = null;
        private SupplierController supplierController = null;
        private ShortageMaterialController shortageMaterialController = null;
        private QuotationController quotationController = null;
        private RequisitionController requisitionController = null;
        private NotificationController notificationController = null;
        private PurchaseExpeditingController purchaseExpeditingController = null;
        private PurchaseContractController purchaseContractController = null;        
        private DeliveryController deliveryController = null;
        private AttachmentController attachmentController = null;
        

        public MainController()
        {
            this.daoCreator = DAOCreator.GetDAOCreator(m_DataStoreType);  
        }
        
        public MainController(LoginUserVO loginUserVO) 
        {
            this.loginUserVO = loginUserVO;
            this.daoCreator = DAOCreator.GetDAOCreator(m_DataStoreType); 
        }

        public LoginUserVO GetLoginUserVO()
        {
            return this.loginUserVO;
        }

        public DAOCreator GetDAOCreator()
        {
            return this.daoCreator;
        }

        public LoginController GetLoginController() 
        {
            if (this.loginController == null)
                this.loginController = new LoginController(this);
            return this.loginController;
        }

        public UserController GetUserController()
        {
            if (this.userController == null)
                this.userController = new UserController(this);
            return this.userController;
        }

        public OrderHeaderController GetOrderHeaderController()
        {
            if (this.orderHeaderController == null)
                this.orderHeaderController = new OrderHeaderController(this);
            return this.orderHeaderController;
        }

        public OrderItemController GetOrderItemController()
        {
            if (this.orderItemController == null)
                this.orderItemController = new OrderItemController(this);
            return this.orderItemController;
        }

        public SupplierController GetSupplierController()
        {
            if (this.supplierController == null)
                this.supplierController = new SupplierController(this);
            return this.supplierController;
        }

        public ShortageMaterialController GetShortageMaterialController()
        {
            if (this.shortageMaterialController == null)
                this.shortageMaterialController = new ShortageMaterialController(this);
            return this.shortageMaterialController;
        }

        public QuotationController GetQuotationController()
        {
            if (this.quotationController == null)
                this.quotationController = new QuotationController(this);
            return this.quotationController;
        }
        public RequisitionController GetRequisitionController()
        {
            if (this.requisitionController == null)
                this.requisitionController = new RequisitionController(this);
            return this.requisitionController;
        }

        public NotificationController GetNotificationController()
        {
            if (this.notificationController == null)
                this.notificationController = new NotificationController(this);
            return this.notificationController;
        }


        public PurchaseExpeditingController GetPurchaseExpeditingController()
        {
            if (this.purchaseExpeditingController == null)
                this.purchaseExpeditingController = new PurchaseExpeditingController(this);
            return this.purchaseExpeditingController;
        }

        
        public PurchaseContractController GetPurchaseContractController()
        {
            if (this.purchaseContractController == null)
                this.purchaseContractController = new PurchaseContractController(this);
            return this.purchaseContractController;
        }
      
        public DeliveryController GetDeliveryController()
        {
            if (this.deliveryController == null)
                this.deliveryController = new DeliveryController(this);
            return this.deliveryController;
        }

        public AttachmentController GetAttachmentController()
        {
            if (this.attachmentController == null)
                this.attachmentController = new AttachmentController(this);
            return this.attachmentController;
        }
        
        

    }
}

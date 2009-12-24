using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using eProcurement_DAL;
using eProcurement_BLL.UserManagement;
using eProcurement_BLL.PurchaseOrder;

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
        private OrderHeaderController orderHeaderController = null;
        private OrderItemController orderItemController = null;

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

    }
}

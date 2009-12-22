using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using eProcurement_DAL;
using eProcurement_BLL.UserManagement;

namespace eProcurement_BLL
{
    public class MainController
    {
        private LoginUserVO loginUserVO = null;
        public LoginUserVO IsLogIndividually
        {
            set { this.loginUserVO = value;}
        }

        private LoginController loginController = null;

        public MainController()
        {

        }
        
        public MainController(LoginUserVO loginUserVO) 
        {
            this.loginUserVO = loginUserVO;
        }

        public LoginController GetLoginController() 
        {
            if (this.loginController == null)
                this.loginController = new LoginController();
            return this.loginController;
        }

    }
}

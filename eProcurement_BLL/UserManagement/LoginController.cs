using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using eProcurement_DAL;

namespace eProcurement_BLL.UserManagement
{
    public class LoginController
    {
        MainController mainController = null;
        public LoginController(MainController mainController) 
        {
            this.mainController = mainController;
        }

        /// <summary>
        /// Validate Login 
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="password">Password</param>
        /// <returns>
        /// 0:Successful
        /// 1:Faild(User account doesn't exist in our database.)
        /// 2:Faild(Your account has been deleted.)
        /// 3:Faild(Invalid Password.)
        /// </returns>
        public int ValidateLogin(string userId, string password) 
        {
            try
            {
                ////////////////////////////////////////////////////////////////////
                //Check whether user account exists
                ////////////////////////////////////////////////////////////////////
                User user = mainController.GetDAOCreator().CreateUserDAO().RetrieveByKey(userId);   
                if(user==null)
                {
                    Utility.InfoLog("User Management module: Login fail for UserID '" + userId + "'." + "No record in database.");
                     return 1;
                }

                ////////////////////////////////////////////////////////////////////
                //Check whether user account is active
                ////////////////////////////////////////////////////////////////////
                if (string.Compare(user.UserStatus,UserStatus.Active,true)!=0)
                {
                     Utility.InfoLog("User Management module: Login fail for UserID '" + userId + "'." + "User account has been logically deleted.");
                     return 2;
                }

                ////////////////////////////////////////////////////////////////////
                //Check whether user password is correct
                ////////////////////////////////////////////////////////////////////
                if (string.Compare(user.UserPassword, password, false) != 0)
                {
                    Utility.InfoLog("User Management module: Login fail for UserID '" + userId + "'." + "Invalid Password.");
                    return 3;
                }

                Utility.InfoLog("User Management module: Login Successfully for UserID '" + userId + "'." + Utility.GetLongDate(DateTime.Now));
                return 0;
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        /// <summary>
        /// Get Login User Info
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>
        /// LoginUserVO
        /// </returns>
        public LoginUserVO GetLoginUserInfo(string userId) 
        {
            try
            {
                User user = mainController.GetDAOCreator().CreateUserDAO().RetrieveByKey(userId);
                if (user == null)
                {
                    throw new Exception("LoginController:GetLoginUserInfo - Invalid User :" + userId); 
                }
                
                LoginUserVO loginUserVO = new LoginUserVO();
                loginUserVO.UserId = user.UserId.Trim();
                loginUserVO.UserName = user.UserName;
                loginUserVO.LastLoginDateTime = DateTime.Now;
                loginUserVO.EmailAddr = user.UserEmail;
                loginUserVO.ProfileType = user.ProfileType;
                loginUserVO.SupplierId = user.SupplierID.Trim();
                loginUserVO.Role = user.UserRole;
                if (!string.IsNullOrEmpty(user.SupplierID.Trim()))
                {
                    Supplier supplier = mainController.GetSupplierController().GetSupplier(user.SupplierID);
                    loginUserVO.SupplierName = supplier.SupplierName;
                    loginUserVO.SupplierAddr = supplier.SupplierAddress + " " + supplier.City + " " + supplier.PostalCode;
                }
                else 
                {
                    loginUserVO.SupplierName = "";
                    loginUserVO.SupplierAddr = "";
                }

                Collection<string> funcList = new Collection<string>();
                string whereClause = "";
                whereClause = " USRROLE='" + Utility.EscapeSQL(user.UserRole) + "' and PROFTYP='" 
                                + Utility.EscapeSQL(user.ProfileType)  + "' ";
                Collection<AccessMatrix> accessMatrixColl = mainController.GetDAOCreator().CreateAccessMatrixDAO().RetrieveByQuery(whereClause);
                foreach (AccessMatrix aM in accessMatrixColl)
                    funcList.Add(aM.FunctionID); 

                loginUserVO.FuncList = funcList;

                Collection<string> purchaseGrpList = new Collection<string>();
                purchaseGrpList.Add("PhGrp1");
                purchaseGrpList.Add("PhGrp2");
                loginUserVO.PurchaseGrpList = purchaseGrpList;

                return loginUserVO;
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        
    }
}

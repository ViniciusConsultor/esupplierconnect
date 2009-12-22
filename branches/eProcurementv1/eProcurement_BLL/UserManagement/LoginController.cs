using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using eProcurement_DAL;

namespace eProcurement_BLL.UserManagement
{
    public class LoginController
    {

        /// <summary>
        /// Validate Login 
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="password">Password</param>
        /// <returns>
        /// 0:Successful
        /// 1:Faild(User account doesn't exist in our database.)
        /// 2:Faild(Your account has been deleted.)
        /// </returns>
        public int ValidateLogin(string userId, string password) 
        {
            try
            {

                ////////////////////////////////////////////////////////////////////
                //Check whether user account exists
                ////////////////////////////////////////////////////////////////////
                bool userExist = true;
                if (!userExist)
                {
                    Utility.InfoLog("User Management module: Login fail for UserID '" + userId + "'." + "No record in database.");
                     return 1;
                }

                ////////////////////////////////////////////////////////////////////
                //Check whether user account is active
                ////////////////////////////////////////////////////////////////////
                bool userActive = true;
                if (!userActive)
                {
                     Utility.InfoLog("User Management module: Login fail for UserID '" + userId + "'." + "User account has been logically deleted.");
                     return 2;
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
                LoginUserVO loginUserVO = new LoginUserVO();
                loginUserVO.UserId = userId;
                loginUserVO.UserName = "debugger";
                loginUserVO.LastLoginDateTime = DateTime.Now;
                loginUserVO.EmailAddr = "";
                loginUserVO.ProfileType = ProfileType.Supplier;
                loginUserVO.SupplierId = "001";
                loginUserVO.SupplierName = "CPP GLOBAL PRODUCTS P L";
                loginUserVO.SupplierAddr = "Fujitec Singapore Corpn, Ltd. 204 Bedok South Avenue 1 Singapore 469333 ";
                loginUserVO.Role = "Administrator";

                Collection<string> purchaseGrpList = new Collection<string>();
                purchaseGrpList.Add("PhGrp1");
                purchaseGrpList.Add("PhGrp2");
                loginUserVO.PurchaseGrpList = purchaseGrpList;

                Collection<string> funcList = new Collection<string>();
                funcList.Add("F-0001");
                funcList.Add("F-0002");
                loginUserVO.FuncList = funcList;

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

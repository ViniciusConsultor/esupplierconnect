using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using eProcurement_DAL;

namespace eProcurement_BLL.UserManagement
{
    public class UserController
    {

        MainController mainController = null;

        public UserController(MainController mainController) 
        {
            this.mainController = mainController;
        }


        //public Collection<User> ValidateUser(string userId, string pswd)
        //{
        //    return UserDAO.RetrieveByQuery("[USERID]='" + userId + "' AND [USRPWD]='" + pswd + "'");
        //}

        public Collection<User> GetUsers()
        {
            return mainController.GetDAOCreator().CreateUserDAO().RetrieveAll(); //UserDAO.RetrieveAll();
        }

        public Collection<User> GetUsers(string userid)
        {
            string whereClause = string.Empty;
            whereClause = "([USERID]<>'" + userid + "' AND [PROFTYP]<>'System')";

            return mainController.GetDAOCreator().CreateUserDAO().RetrieveByQuery(whereClause, "[USERID]"); //UserDAO.RetrieveAll(userid, "[USERID]");
        }

        public Collection<User> GetUsers(string userid, string supplierID)
        {
            string whereClause = string.Empty;
            whereClause = "(USERID<>'" + userid + "' AND LIFNR='" + supplierID + "' AND USRROLE<>'Administrator')";

            return mainController.GetDAOCreator().CreateUserDAO().RetrieveByQuery(whereClause, "[USERID]");
        }

        public User GetUser(string userId)
        {
            if (userId.Length > 0)
                return mainController.GetDAOCreator().CreateUserDAO().RetrieveByKey(userId); // UserDAO.RetrieveByKey(userId);

            return null;
        }

        public DataTable GetSuppliers()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SupplierID");
            dt.Columns.Add("SupplierIDName");

            Collection<Supplier> suplist = mainController.GetDAOCreator().CreateSupplierDAO().RetrieveAll();

            foreach (Supplier s in suplist){
                DataRow dr = dt.NewRow();
                dr["SupplierID"] = s.SupplierID.Trim();
                dr["SupplierIDName"] = "[" + s.SupplierID.Trim() + "] " + s.SupplierName;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public void InsertUser(User u)
        {
            try
            {
                mainController.GetDAOCreator().CreateUserDAO().Insert(u);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUser(User u)
        {
            try
            {
                mainController.GetDAOCreator().CreateUserDAO().Update(u);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUserStatus(string userId, string status, string updatedBy)
        {
            try{
                User u = mainController.GetDAOCreator().CreateUserDAO().RetrieveByKey(userId);

                u.UserStatus = status;
                u.UpdatedBy = updatedBy;

                mainController.GetDAOCreator().CreateUserDAO().Update(u);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUserPassword(string userId, string pswd, string updatedBy)
        {
            try
            {
                User u = mainController.GetDAOCreator().CreateUserDAO().RetrieveByKey(userId);

                u.UserPassword = pswd;
                u.UpdatedBy = updatedBy;

                mainController.GetDAOCreator().CreateUserDAO().Update(u);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

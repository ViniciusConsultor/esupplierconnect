using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;  
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using eProcurement_BLL;
using eProcurement_BLL.UserManagement;
using eProcurement_DAL;

public partial class Login : BaseForm
{
    private MainController mainController = null;
    
    new void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.mainController = new MainController();

            if (!IsPostBack)
            {
                //Clean session temporary data 
                Session.Abandon();
                txtUserName.Focus();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ImgbtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        string userId = null;
        string password = null;

        try
        {
            userId = txtUserName.Text.Trim();
            password = txtPassword.Text.Trim();

            ////////////////////////////////////////////////////////////////////
            //Check mandatory input field
            ////////////////////////////////////////////////////////////////////
            if (userId == "" || password == "")
            {
                this.lblError.Visible = true;
                if (txtUserName.Text.Trim() == "" && txtPassword.Text.Trim() == "")
                {
                    lblError.Text = "Please enter user name and password.";
                    txtUserName.Focus();
                    return;
                }
                else if (txtUserName.Text.Trim() == "" && txtPassword.Text.Trim() != "")
                {
                    lblError.Text = "Please enter user name.";
                    txtUserName.Focus();
                    return;
                }
                else
                {
                    lblError.Text = "Please enter password.";
                    txtPassword.Focus();
                    return;
                }
            }

            int iReturn = this.mainController.GetLoginController().ValidateLogin(userId, password);
            if (iReturn > 0) 
            {
                if (iReturn == 1) 
                {
                    this.lblError.Visible = true;
                    txtUserName.Focus();
                    lblError.Text = "User account doesn't exist in our database.";
                    return;
                }

                if (iReturn == 2)
                {
                    this.lblError.Visible = true;
                    txtUserName.Focus();
                    lblError.Text = "Your account has been deleted.";
                    return;
                }
            }

            LoginUserVO loginUserVO = this.mainController.GetLoginController().GetLoginUserInfo(userId); 
           
            Session.Add(SessionKey.LOGIN_USER, loginUserVO);

            Response.Redirect("Common/Welcome.aspx");
               
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);

            this.lblError.Visible = true;
            this.lblError.Text = "Problem connecting to the server. Please contact Administrator.";
        }
    }
}

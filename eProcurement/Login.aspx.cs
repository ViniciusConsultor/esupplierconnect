using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using eProcurement_BLL;
using eProcurement_DAL;

public partial class Login : BaseForm
{
    new void Page_Load(object sender, EventArgs e)
    {
        try
        {
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

            /*
            ////////////////////////////////////////////////////////////////////
            //Check whether user account exists
            ////////////////////////////////////////////////////////////////////
            SecAvaUserProfile UserProfileRecord = SecAvaUserProfile.RetrieveByKey(UserId);
            if (UserProfileRecord == null)
            {
                this.lblError.Visible = true;
                txtUserName.Focus();
                lblError.Text = "User account doesn't exist in our database.";
                InfoLog("Security module: Login fail for UserID '" + UserId + "'." + "No record in database.");
                return;
            }

            ////////////////////////////////////////////////////////////////////
            //Check whether user account is active
            ////////////////////////////////////////////////////////////////////
            if (UserProfileRecord.DelInd == FLAG_YES)
            {
                this.lblError.Visible = true;
                txtUserName.Focus();
                lblError.Text = "Your account has been deleted.";
                InfoLog("Security module: Login fail for UserID '" + UserId + "'." + "User account has been logically deleted.");
                return;
            }
            */
           
            Session.Add(SessionKey.LOGIN_USER, null);

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
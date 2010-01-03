using System;
using System.Data;
using System.Configuration;
using System.Collections;
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

public partial class UserManagement_UserPassword : BaseForm
{
    private MainController mainController = null;

    #region Events Handlers

    new protected void Page_Load(object sender, EventArgs e)
    {
        this.mainController = new MainController();

        if (!Page.IsPostBack)
        {
            //Access control
            /***************************************************/
            base.m_FunctionIdColl.Add("U-0003");

            base.Page_Load(sender, e);
            /***************************************************/

            LoginUserVO loginUser = (LoginUserVO)Session[SessionKey.LOGIN_USER];
            lblUserID.Text = loginUser.UserId;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        lblError.Text = "";

        try
        {
            CheckSessionTimeOut();

            if (VerifyOldPassword(lblUserID.Text, txtCurrPassword.Text))
            {
                this.mainController.GetUserController().UpdateUserPassword(lblUserID.Text, txtNewPassword.Text, lblUserID.Text);                

                lblMessage.Text = "<br />Password updated successfully.";
            }
            else
            {
                throw new Exception("<br />Incorrect current password.");
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    #endregion

    #region Private Functions

    private bool VerifyOldPassword(string userId, string pswd)
    {
        User u = this.mainController.GetUserController().GetUser(userId);

        return u.UserPassword != pswd ? false : true;
    }

    #endregion


}

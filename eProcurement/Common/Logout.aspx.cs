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

public partial class Common_Logout : BaseForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (LoginUser!= null)
            {
                Utility.InfoLog("User Management module: Logout Successfully for UserID '" + LoginUser.UserId + "'." + Utility.GetLongDate(DateTime.Now));
                lblMessage.Text = "<b>You have logged out successfully.</b>";
            }
            else
            {
                lblMessage.Text = "Your session has timeout, please re-login again.";
                
            }
            Session.Abandon();
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/login.aspx");
    }
}

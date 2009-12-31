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

public partial class UserManagement_UserList : BaseForm
{
    private MainController mainController = null;

    new protected void Page_Load(object sender, EventArgs e)
    {
        this.mainController = new MainController();

        if (!Page.IsPostBack)
        {
            //Access control
            /***************************************************/
            base.m_FunctionIdColl.Add("U-0001");

            base.Page_Load(sender, e);
            /***************************************************/

            LoadUsers();
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        int i = 0;
        int cnt = 0;
        string pswd = string.Empty;

        lblMsg.Text = "";
        lblError.Text = "";

        try
        {
            CheckSessionTimeOut();

            LoginUserVO loginUser = (LoginUserVO)Session[SessionKey.LOGIN_USER];

            PasswordGenerator pg = new PasswordGenerator();
            pg.Minimum = 8;
            pg.Maximum = 10;

            foreach (GridViewRow row in gvData.Rows)
            {
                if (((CheckBox)row.Cells[0].FindControl("chkDelete")).Checked)
                {
                    this.mainController.GetUserController().UpdateUserPassword(gvData.DataKeys[i].Values[0].ToString(), pg.Generate(), loginUser.UserId);
                    cnt++;
                }
                i++;
            }
            lblMsg.Text = "<br />Selected " + Convert.ToString(cnt) + " user(s)  password has been reset.<br />The auto-generated new password has been sent to user via email.";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int i = 0;
        int cnt = 0;

        lblMsg.Text = "";
        lblError.Text = "";

        try
        {
            CheckSessionTimeOut();

            LoginUserVO loginUser = (LoginUserVO)Session[SessionKey.LOGIN_USER];

            foreach (GridViewRow row in gvData.Rows)
            {
                if (((CheckBox)row.Cells[0].FindControl("chkDelete")).Checked)
                {
                    this.mainController.GetUserController().UpdateUserStatus(gvData.DataKeys[i].Values[0].ToString(), "V", loginUser.UserId);
                    cnt++;
                }
                i++;
            }
            LoadUsers();
            lblMsg.Text = "<br />Selected " + Convert.ToString(cnt) + " user(s) status has been changed to void(V) and logically deleted.";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void gvData_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink lbhlUserID = (HyperLink)e.Row.FindControl("lbhlUserID");
            lbhlUserID.Attributes.Add("UserID", lbhlUserID.Text);
            lbhlUserID.NavigateUrl = "User.aspx?Type=Edit&UserID=" + lbhlUserID.Text;
        }
    }

    private void LoadUsers()
    {
        Collection<User> users = new Collection<User>();

        LoginUserVO loginUser = (LoginUserVO)Session[SessionKey.LOGIN_USER];

        if ((string.Compare(loginUser.Role, UserRole.Administrator, true) == 0) && (string.Compare(loginUser.ProfileType, ProfileType.System, true) == 0)) //System Admin
            users = this.mainController.GetUserController().GetUsers(loginUser.UserId);
        else if ((string.Compare(loginUser.Role, UserRole.Administrator, true) == 0) && (loginUser.ProfileType != ProfileType.System)) //Other Admin
            users = this.mainController.GetUserController().GetUsers(loginUser.UserId, loginUser.SupplierId);

        gvData.DataSource = users;
        gvData.DataBind();

        if (gvData.Rows.Count < 1)
        {
            btnDelete.Visible = false;
            btnReset.Visible = false;
        }
        else
        {
            btnDelete.Visible = true;
            btnReset.Visible = true;
        }
    }

}

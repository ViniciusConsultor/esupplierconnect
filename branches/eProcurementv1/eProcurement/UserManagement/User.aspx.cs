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

public partial class UserManagement_User : BaseForm
{
    private MainController mainController = null;

    #region Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        this.mainController = new MainController();

        if (!Page.IsPostBack)
        {
            LoadRolesTypes();
            LoadSupplierID();

            string type = Request.QueryString["Type"];

            ViewState.Add("Type", type);

            if (type == null)
            {
                LoginUserVO loginUser = (LoginUserVO)Session[SessionKey.LOGIN_USER];
                GetUser(loginUser.UserId); //Session["EditUserID"]));
                btnSave.Visible = true;
                rfvUserID.Enabled = false;
            }
            else if (type == "Edit")
            {
                GetUser(Convert.ToString(Request.QueryString["UserID"])); //Session["EditUserID"]));
                btnSave.Visible = true;
                rfvUserID.Enabled = false;
            }
            else if (type == "New")
            {
                txtUserID.Visible = true;
                lblUserID.Visible = false;
                btnSave.Visible = true;
                rfvUserID.Enabled = true;
                rdoStatusYes.Enabled = false;
                rdoStatusNo.Enabled = false;
            }
        }
    }

    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRole.Items.Count > 0)
        {
            ddlType.Items.Clear();

            LoginUserVO loginUser = (LoginUserVO)Session[SessionKey.LOGIN_USER];

            if (loginUser.Role == UserRole.Administrator && loginUser.ProfileType == ProfileType.System)
            {
                if (ddlRole.SelectedValue == UserRole.Administrator)
                {
                    ddlType.Items.Add(new ListItem(ProfileType.Buyer, ProfileType.Buyer));
                    ddlType.Items.Add(new ListItem(ProfileType.Supplier, ProfileType.Supplier));
                    ddlType.Items.Add(new ListItem(ProfileType.WarehouseUser, ProfileType.WarehouseUser));
                    ddlType.Items.Add(new ListItem(ProfileType.System, ProfileType.System));

                }
                else
                {
                    ddlType.Items.Add(new ListItem(ProfileType.Buyer, ProfileType.Buyer));
                    ddlType.Items.Add(new ListItem(ProfileType.Supplier, ProfileType.Supplier));
                    ddlType.Items.Add(new ListItem(ProfileType.WarehouseUser, ProfileType.WarehouseUser));
                }
            }
            else
            {
                ddlType.Items.Add(new ListItem(ProfileType.Buyer, ProfileType.Buyer));
                ddlType.Items.Add(new ListItem(ProfileType.Supplier, ProfileType.Supplier));
                ddlType.Items.Add(new ListItem(ProfileType.WarehouseUser, ProfileType.WarehouseUser));
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string newUserId = string.Empty;

            newUserId = txtUserID.Visible == true ? txtUserID.Text : lblUserID.Text;

            LoginUserVO loginUser = (LoginUserVO)Session[SessionKey.LOGIN_USER];

            string d = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd");

            lblError.Text = "";
            lblMessage.Text = "";

            PasswordGenerator pg = new PasswordGenerator();
            pg.Minimum = 8;
            pg.Maximum = 10;

            User u = new User();
            u.UserId = newUserId;
            u.UserName = txtUserName.Text;
            u.UserPassword = pg.Generate();
            u.UserEmail = txtEmail.Text;

            u.UserRole = ddlRole.Visible == true ? ddlRole.SelectedItem.Text : lblRole.Text;
            u.ProfileType = ddlType.Visible == true ? ddlType.SelectedItem.Text : lblType.Text;

            u.UpdatedBy = loginUser.UserId;
            u.UpdatedDate = Convert.ToInt64(d);

            u.SupplierID = ddlSupplierID.Visible == true ? ddlSupplierID.SelectedValue : loginUser.SupplierId;

            if (rdoStatusYes.Checked == true)
                u.UserStatus = "A";
            else
                u.UserStatus = "V";

            if (Convert.ToString(ViewState["Type"]) == "New")
            {
                if (!ExistingUser(newUserId))
                {
                    //UserController.InsertUser(u);
                    this.mainController.GetDAOCreator().CreateUserDAO().Insert(u);

                    string emailServer = "exchangeServerName";
                    string title = "Password for New User Registration at SupplierConnect@Fujitec";
                    string body = "Hello " + u.UserName + ",<br /><br />" +
                        "Weclome to SupplierConnect@Fujitec.<br />The new account '<b>" + u.UserId +
                        "</b>' has been newly created. Please use the below auto-generated password to login. " +
                        "You may change the password after you've login to the system.<br /><br />" +
                        "SupplierConnect@Fujitec: http://sampleaddress.fujitec.com<br />" +
                        "User ID: " + u.UserId + "<br />" +
                        "Password: " + u.UserPassword + "<br /><br /><br /><br />" +
                        "[This is system auto-generated email. Please do not reply.]";

                    //Utility.SentEmail("SupplierConnect@Fujitec", u.UserEmail, title, body, emailServer);

                    lblMessage.Text = "New user created and notification email has been send to the user.";
                }
                else
                    throw new Exception("UserID already exists.");
            }
            else if (Convert.ToString(ViewState["Type"]) == "Edit")
            {
                //UserController.UpdateUser(u);
                this.mainController.GetDAOCreator().CreateUserDAO().Update(u);
                lblMessage.Text = "User data has been updated successfully.";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    #endregion

    #region Private Functions

    private void GetUser(string userId)
    {
        //User u = UserController.GetUser(userId);
        User u = this.mainController.GetDAOCreator().CreateUserDAO().RetrieveByKey(userId);

        lblUserID.Text = userId;
        txtUserName.Text = u.UserName;
        txtEmail.Text = u.UserEmail;

        lblRole.Text = u.UserRole;
        lblType.Text = u.ProfileType;
        ddlRole.SelectedValue = u.UserRole;
        ddlType.SelectedValue = u.ProfileType;

        lblSupplierID.Text = u.SupplierID;
        ddlSupplierID.SelectedValue = u.SupplierID;

        if (u.UserStatus == UserStatus.Active)
        {
            rdoStatusYes.Checked = true;
            rdoStatusNo.Checked = false;
        }
        else
        {
            rdoStatusYes.Checked = false;
            rdoStatusNo.Checked = true;
        }
    }

    private void LoadRolesTypes()
    {
        ddlRole.Items.Clear();
        ddlType.Items.Clear();

        ddlRole.Items.Add(new ListItem(UserRole.Operator, UserRole.Operator));
        ddlRole.Items.Add(new ListItem(UserRole.Viewer, UserRole.Viewer));

        ddlType.Items.Add(new ListItem(ProfileType.Buyer, ProfileType.Buyer));
        ddlType.Items.Add(new ListItem(ProfileType.Supplier, ProfileType.Supplier));
        ddlType.Items.Add(new ListItem(ProfileType.WarehouseUser, ProfileType.WarehouseUser));
        ddlType.Items.Add(new ListItem(ProfileType.System, ProfileType.System));

        LoginUserVO loginUser = (LoginUserVO)Session[SessionKey.LOGIN_USER];

        if (loginUser.Role == UserRole.Administrator && loginUser.ProfileType == ProfileType.System)
        {
            ddlRole.Items.Add(new ListItem(UserRole.Administrator, UserRole.Administrator));
            ddlRole.AutoPostBack = true;

            ddlType.Visible = true;
            lblType.Visible = false;
        }
        else if (loginUser.Role == UserRole.Administrator && loginUser.ProfileType != ProfileType.System)
        {
            ddlRole.AutoPostBack = false;

            ddlType.Visible = false;
            lblType.Visible = true;
            lblType.Text = loginUser.ProfileType;
        }

        if (loginUser.Role == UserRole.Administrator)
        {
            ddlRole.Visible = true;
            lblRole.Visible = false;
        }
        else
        {
            ddlRole.Visible = false;
            lblRole.Visible = true;
            lblRole.Text = loginUser.Role;

            ddlType.Visible = false;
            lblType.Visible = true;
            lblType.Text = loginUser.ProfileType;
        }
    }

    private void LoadSupplierID()
    {
        DataTable dt = this.mainController.GetUserController().GetSuppliers();
        ddlSupplierID.DataSource = dt;
        ddlSupplierID.DataTextField = "SupplierIDName";
        ddlSupplierID.DataValueField = "SupplierID";
        ddlSupplierID.DataBind();

        LoginUserVO loginUser = (LoginUserVO)Session[SessionKey.LOGIN_USER];
        if (loginUser.Role == UserRole.Administrator && loginUser.ProfileType == ProfileType.System)
        {
            ddlSupplierID.Visible = true;
            lblSupplierID.Visible = false;
        }
        else
        {
            ddlSupplierID.Visible = false;
            lblSupplierID.Visible = true;
            lblSupplierID.Text = loginUser.SupplierId;
        }
    }

    private bool ExistingUser(string userId)
    {
        //User u = UserController.GetUser(userId);
        User u = this.mainController.GetDAOCreator().CreateUserDAO().RetrieveByKey(userId);

        if (u != null)
            return true;

        return false;
    }

    #endregion
}

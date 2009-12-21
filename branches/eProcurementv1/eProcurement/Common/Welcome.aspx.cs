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
using eProcurement_BLL.User;
using eProcurement_DAL;

public partial class Common_Welcome : BaseForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            base.Page_Load(sender, e);

            LoginUserVO loginUserVO = (LoginUserVO)Session[SessionKey.LOGIN_USER];
            if (loginUserVO != null)
            {
                System.DateTime LastLoginTime = loginUserVO.LastLoginDateTime;
               
                LastLoginTimeLiteral.Text = "Your last login time is " + LastLoginTime.ToString("dd/MM/yyyy") + " " + LastLoginTime.ToShortTimeString();
                PrivacyStatementLiteral.Text = "<b>WARNING:</b> <br>Any unauthorised access will be subject to disciplinary action by Fujitec management.";
            }
        }
    }
}

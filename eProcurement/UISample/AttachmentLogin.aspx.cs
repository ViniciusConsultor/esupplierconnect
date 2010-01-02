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
using eProcurement_BLL.UserManagement;
using eProcurement_DAL;

public partial class UISample_AttachmentLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuyer_Click(object sender, EventArgs e)
    {
        try
        {
            LoginUserVO loginUserVO = new LoginUserVO();
            loginUserVO.UserId = "test1";
            loginUserVO.UserName = "tester 1";
            loginUserVO.LastLoginDateTime = DateTime.Now;
            loginUserVO.EmailAddr = "";
            loginUserVO.ProfileType = ProfileType.Buyer;
            loginUserVO.SupplierId = "";
            loginUserVO.Role = "";

            Session.Add(SessionKey.LOGIN_USER, loginUserVO);

            Response.Redirect("AttachmentSample.aspx");

            
        }
        catch (Exception ex)
        {
           
        }
    }

    protected void btnSupplier_Click(object sender, EventArgs e)
    {
        try
        {
            LoginUserVO loginUserVO = new LoginUserVO();
            loginUserVO.UserId = "test2";
            loginUserVO.UserName = "tester 2";
            loginUserVO.LastLoginDateTime = DateTime.Now;
            loginUserVO.EmailAddr = "";
            loginUserVO.ProfileType = ProfileType.Supplier;
            loginUserVO.SupplierId = "";
            loginUserVO.Role = "";

            Session.Add(SessionKey.LOGIN_USER, loginUserVO);

            Response.Redirect("AttachmentSample.aspx");

            
        }
        catch (Exception ex)
        {

        }
    }
}

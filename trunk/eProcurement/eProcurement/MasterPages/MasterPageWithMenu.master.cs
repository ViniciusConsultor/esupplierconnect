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

public partial class MasterPages_MasterPageWithMenu : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string profile = "SUPPLIER";
        if (string.IsNullOrEmpty(profile)) return;
        if (profile.ToUpper() == "SUPPLIER")
        {
            plSupplier.Visible = true;
            plBuyer.Visible = false;
        }

        if (profile.ToUpper() == "BUYER")
        {
            plSupplier.Visible = false;
            plBuyer.Visible = true;
        } 
    }
}

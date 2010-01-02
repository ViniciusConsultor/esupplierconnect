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

public partial class UISample_AttachmentSample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnInit_Click(object sender, EventArgs e)
    {
        try
        {
            bool isReadonly = ddlReadonly.SelectedValue == "Y" ? true : false;

            attPanel.InitPanel(txtNo.Text.Trim(), isReadonly); 

        }
        catch (Exception ex)
        {

        }
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {
            txtIds.Text = "";
            Collection<Guid> ids = attPanel.GetAddedAttachments();
            foreach (Guid id in ids) 
            {
                txtIds.Text += id.ToString() + "||";  
            }

        }
        catch (Exception ex)
        {

        }
    }
}

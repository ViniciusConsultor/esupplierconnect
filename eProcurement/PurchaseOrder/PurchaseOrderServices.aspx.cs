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
using eProcurement_DAL;

public partial class PurchaseOrder_PurchaseOrderServices : BaseForm
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            plMessage.Visible = false;
            lblMessage.Text = string.Empty;
            if (!IsPostBack)
            {
                ShowData();
            }
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            string sMessage = ex.Message;
            displayCustomMessage(sMessage, lblMessage, SystemMessageType.Error);
        }
    }

    private void ShowData()
    {
        string orderNumber = Request.QueryString["OrderNumber"];
        string itemNo = Request.QueryString["ItemNo"];
        Collection<PurchaseOrderServiceItem> texts = PurchaseOrderItemController.GetPurchaseOrderServiceItem(orderNumber, itemNo);
        gvData.DataSource = texts;
        gvData.DataBind();
        if (texts.Count == 0)
            lblCount.Text = string.Format("{0} record(s) found. ", texts.Count.ToString());
    }

    protected void gvData_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }

}

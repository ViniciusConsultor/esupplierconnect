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

public partial class PurchaseOrder_PurchaseOrderItemText : BaseForm
{
    new protected void Page_Load(object sender, EventArgs e)
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
        //Collection<PurchaseOrderItemText> texts = PurchaseOrderItemController.GetPurchaseOrderItemTexts(orderNumber, itemNo);
        Collection<PurchaseItemText> objs = new Collection<PurchaseItemText>();
        int iCount = 9;
        for (int i = 1; i <= iCount; i++)
        {
            PurchaseItemText obj = new PurchaseItemText();
            obj.OrderNumber = "0000000001";
            obj.ItemSequence  = "0001";
            obj.TextSequence = "0" + i;
            obj.LongText = "Text " + i;
            objs.Add(obj);
        }

        gvData.DataSource = objs;
        gvData.DataBind();
        if (objs.Count == 0)
            lblCount.Text = string.Format("{0} record(s) found. ", objs.Count.ToString());
    }

    protected void gvData_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }
}

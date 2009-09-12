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

public partial class PurchaseOrder_PurchaseOrderList : BaseForm
{
    private Collection<PurchaseOrderHeader> m_Data
    {
        get
        {
            if (ViewState["m_Data"] != null)
            {
                return (Collection<PurchaseOrderHeader>)ViewState["m_Data"];
            }
            else
            {
                return null;
            }
        }
        set
        {
            ViewState["m_Data"] = value;
        }
    }
    
    new protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            plMessage.Visible = false;
            lblMessage.Text = string.Empty;
            if (!IsPostBack)
            {
                GetData();
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string strErrorMsg = ValidateInput();

            if (!string.IsNullOrEmpty(strErrorMsg.ToString()))
            {
                plMessage.Visible = true;
                displayCustomMessage(FormatErrorMessage(strErrorMsg.ToString()), lblMessage, SystemMessageType.Error);
                return;
            }
            
            GetData();
            ShowData();
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            string sMessage = ex.Message;
            displayCustomMessage(sMessage, lblMessage, SystemMessageType.Error);
        }
    }

    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvData.PageIndex = e.NewPageIndex;
        ShowData();
    }

   
    protected void gvData_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbhlOrderNo = (LinkButton)e.Row.FindControl("lbhlOrderNo");
            //string url = "~/PurchaseOrder/AcknowledgePurchaseOrder.aspx";
            lbhlOrderNo.Attributes.Add("OrderNo", lbhlOrderNo.Text);   
            //lbhlOrderNo.PostBackUrl = url;
        }
    }

    private void GetData()
    {
        string orderNumber = txtOrderNumber.Text.Trim();
        DateTime startDate = DateTime.MinValue;
        DateTime endDate = DateTime.MinValue;
        if (dtpFrom.SelectedDateString != "") 
            startDate = dtpFrom.SelectedDate;
        if (dtpTo.SelectedDateString != "")
            endDate = dtpTo.SelectedDate;
        m_Data = PurchaseOrderController.GetPendingAckPOList(orderNumber, startDate, endDate, "");  
    }

    private void ShowData()
    {
        gvData.DataSource = m_Data;
        gvData.DataBind();
        lblCount.Text = string.Format("{0} record(s) found. ", m_Data.Count.ToString());

    }

    protected void hlOrderNo_OnClick(object sender, System.EventArgs e)
    {
        try
        {
            bool found = false;
            LinkButton lbhlOrderNo = (LinkButton)sender;
            string orderNo = lbhlOrderNo.Attributes["OrderNo"].ToString();
            foreach (PurchaseOrderHeader poHeader in m_Data) 
            {
                if (string.Compare(poHeader.OrderNumber, orderNo, true) == 0) 
                {
                    Session["Ack_POHeader"] = poHeader;
                    found = true;
                    break; 
                }
            }
            if (!found)
                throw new Exception("Timeout");
            string url = "~/PurchaseOrder/AcknowledgePurchaseOrder.aspx";
            Response.Redirect(url); 

        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            string sMessage = ex.Message;
            displayCustomMessage(sMessage, lblMessage, SystemMessageType.Error);
        }
    }

    #region validation
    private string ValidateInput()
    {
        System.Text.StringBuilder strErrorMsg = new System.Text.StringBuilder(string.Empty);

        bool bIsValid = true;
        if (dtpFrom.Text != "")
        {
            if (!dtpFrom.IsValidDate)
            {
                bIsValid = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Order Date From."));
            }
        }

        if (dtpTo.Text != "")
        {
            if (!dtpTo.IsValidDate)
            {
                bIsValid = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Order Date To."));
            }
        }

        if (!bIsValid)
        {
            return strErrorMsg.ToString();
        }

        if (dtpFrom.SelectedDateString != "" && dtpTo.SelectedDateString != "")
        {
            DateTime dtFrom = dtpFrom.SelectedDate;
            DateTime dtTo = dtpTo.SelectedDate;

            if (dtFrom.CompareTo(dtTo) > 0) //fromdate - todate (0=equal, 1=greater, -1=smaller)
            {
                strErrorMsg.Append(MakeListItem("Order Date To must be equal or greater than Order Date From."));
                return strErrorMsg.ToString();
            }
        }
        return strErrorMsg.ToString();
    }
    #endregion
}

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

public partial class Expediting_AckExpeditingList : BaseForm
{
    private MainController mainController = null;

    new protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Instantiate MainController
            this.mainController = new MainController(base.LoginUser);

            plMessage.Visible = false;
            lblMessage.Text = string.Empty;
            if (!IsPostBack)
            {
                //Access control
                /***************************************************/
                base.m_FunctionId = "S-0013";
                base.Page_Load(sender, e);
                /***************************************************/

                if (!string.IsNullOrEmpty(Request.QueryString["ProceeSuccess"]))
                {
                    if (string.Compare(Request.QueryString["ProceeSuccess"], "Y", true) == 0) 
                    {
                        plMessage.Visible = true;
                        string sMessage = "Purchase expediting has been acknowledged successfully.";
                        displayCustomMessage(sMessage, lblMessage, SystemMessageType.Information);
                    }
                }
                
                if (!string.IsNullOrEmpty(Request.QueryString["PageIdx"]))
                {
                    gvData.PageIndex = Convert.ToInt32(Request.QueryString["PageIdx"].ToString());
                }


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
        Collection<PurchaseOrderHeader> poColl = GetData();
        gvData.DataSource = poColl;
        gvData.DataBind();
        lblCount.Text = string.Format("{0} record(s) found. ", poColl.Count.ToString());
    }

    private Collection<PurchaseOrderHeader> GetData()
    {
        Collection<PurchaseOrderHeader> poColl = new Collection<PurchaseOrderHeader>();

        poColl = mainController.GetPurchaseExpeditingController().GetPendingExpeditingAcknowledgePOList();  
    
        return poColl;
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
            lbhlOrderNo.Attributes.Add("OrderNo", lbhlOrderNo.Text);
        }
    }

    protected void hlOrderNo_OnClick(object sender, System.EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();
            LinkButton lbhlOrderNo = (LinkButton)sender;
            string orderNo = lbhlOrderNo.Attributes["OrderNo"].ToString();
            string url = "";

            url = "~/Expediting/AckExpediting.aspx?PageIdx=" + gvData.PageIndex.ToString();
            
            Session[SessionKey.OrderNumber] = orderNo;
         
            if (url != null)
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
    
}

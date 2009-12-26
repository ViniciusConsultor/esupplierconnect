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
    private MainController mainController = null;

    private string m_FuncFlag
    {
        get
        {
            if (ViewState["m_FuncFlag"] != null && ViewState["m_FuncFlag"].ToString() != string.Empty)
            {
                return ViewState["m_FuncFlag"].ToString();
            }
            else
            {
                return "";
            }
        }
        set
        {
            ViewState["m_FuncFlag"] = value;
        }
    }

    //Store Search Criteria 
    [Serializable]
    private class SearchCriteriaVO 
    {
        public string OrderNumber;
        public Nullable<long> FromDate;
        public Nullable<long> ToDate;
        public string SupplierId;
        public string BuyerName;
        public string Status;
    }

    //Store Search Criteria 
    private SearchCriteriaVO m_SearchCriteriaVO
    {
        get
        {
            if (ViewState["m_SearchCriteriaVO"] != null) 
            {
                return (SearchCriteriaVO)ViewState["m_SearchCriteriaVO"];
            }
            else
            {
                return null;
            }
        }
        set
        {
            ViewState["m_SearchCriteriaVO"] = value;
        }
    }

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
                base.m_FunctionIdColl.Add("S-0001");
                base.m_FunctionIdColl.Add("S-0002");
                base.m_FunctionIdColl.Add("B-0001");
                base.m_FunctionIdColl.Add("B-0002");
                  
                string functionId = Request.QueryString["FunctionId"];
                if (string.IsNullOrEmpty(functionId)) 
                {
                    throw new Exception("Invalid Function Id."); 
                }
                else
                {
                    base.m_FunctionId = functionId;
                    if (string.Compare(functionId, "S-0001", true) == 0)
                    {
                        m_FuncFlag = "ACK_ORDER"; 
                    }
                    if (string.Compare(functionId, "B-0001", true) == 0)
                    {
                        m_FuncFlag = "ACPT_ORDER_ACKMT";
                    }
                    if (string.Compare(functionId, "S-0002", true) == 0)
                    {
                        m_FuncFlag = "VIEW_ORDER_SUPPLIER";
                    }
                    if (string.Compare(functionId, "B-0002", true) == 0)
                    {
                        m_FuncFlag = "VIEW_ORDER_BUYER";
                    }
                }
                base.Page_Load(sender, e);
                /***************************************************/
                imgSupplierSearch.Attributes.Add("onclick", "OpenSupplierDialog('" + txtSupplierId.ClientID + "')");
                imgSupplierSearch.Attributes.Add("style", "cursor: hand");

                //Initialize Page
                InitPage();

                //Handle for return back from order details page
                if(!string.IsNullOrEmpty(Request.QueryString["ReturnFromDetails"]))
                {
                    if (string.Compare(Request.QueryString["ReturnFromDetails"], "Y", true) == 0) 
                    {
                        SearchCriteriaVO searchCriteriaVO = new SearchCriteriaVO();
                        searchCriteriaVO.OrderNumber = Request.QueryString["OrderNumber"];
                        if (!string.IsNullOrEmpty(Request.QueryString["FormDate"]))
                            searchCriteriaVO.FromDate = Convert.ToInt64(Request.QueryString["FormDate"].ToString());
                        else
                            searchCriteriaVO.FromDate = null;
                        if (!string.IsNullOrEmpty(Request.QueryString["ToDate"]))
                            searchCriteriaVO.ToDate = Convert.ToInt64(Request.QueryString["ToDate"].ToString());
                        else
                            searchCriteriaVO.ToDate = null;
                        searchCriteriaVO.SupplierId = Request.QueryString["SupplierId"];
                        searchCriteriaVO.BuyerName = Request.QueryString["BuyerName"];
                        searchCriteriaVO.Status = Request.QueryString["Status"];
                        m_SearchCriteriaVO = searchCriteriaVO;

                        if (!string.IsNullOrEmpty(Request.QueryString["PageIdx"])) 
                        {
                            gvData.PageIndex = Convert.ToInt32(Request.QueryString["PageIdx"].ToString());
                        }

                        ShowData();
                    }
                } 
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

    private void InitPage() 
    {
        try
        {
            if (string.Compare(m_FuncFlag, "ACK_ORDER", false) == 0) 
            {
                lblSubPath.Text = "Acknowledge Order";
                plshSupplier.Visible = false;
                plshBuyer.Visible = true;
                plshStatus.Visible = false;
            }

            if (string.Compare(m_FuncFlag, "ACPT_ORDER_ACKMT", false) == 0)
            {
                lblSubPath.Text = "Accept Order Acknowledgement";
                plshSupplier.Visible = true;
                plshBuyer.Visible = true;
                plshStatus.Visible = false;
            }

            if (string.Compare(m_FuncFlag, "VIEW_ORDER_SUPPLIER", false) == 0)
            {
                lblSubPath.Text = "Enquire Order";
                plshSupplier.Visible = false;
                plshBuyer.Visible = true;
                plshStatus.Visible = true;
                InitStatusList();
            }

            if (string.Compare(m_FuncFlag, "VIEW_ORDER_BUYER", false) == 0)
            {
                lblSubPath.Text = "Enquire Order";
                plshSupplier.Visible = true;
                plshBuyer.Visible = true;
                plshStatus.Visible = true;
                InitStatusList();
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    private void InitStatusList()
    {
        ddlStatus.Items.Clear();
        
        ListItem liAdd;
        string sText, sValue;

        liAdd = new ListItem();
        sText = "- All -";
        sValue = "";
        liAdd.Text = sText;
        liAdd.Value = sValue;
        ddlStatus.Items.Add(liAdd);

        liAdd = new ListItem();
        sText = "Pending Acknowledgement";
        sValue = "PA";
        liAdd.Text = sText;
        liAdd.Value = sValue;
        ddlStatus.Items.Add(liAdd);

        liAdd = new ListItem();
        sText = "Pending Confirm Order Acknowledgement";
        sValue = "PC";
        liAdd.Text = sText;
        liAdd.Value = sValue;
        ddlStatus.Items.Add(liAdd);

        liAdd = new ListItem();
        sText = "Accepted";
        sValue = "AC";
        liAdd.Text = sText;
        liAdd.Value = sValue;
        ddlStatus.Items.Add(liAdd);

        liAdd = new ListItem();
        sText = "Rejected";
        sValue = "RE";
        liAdd.Text = sText;
        liAdd.Value = sValue;
        ddlStatus.Items.Add(liAdd);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();

            string strErrorMsg = ValidateInput();

            if (!string.IsNullOrEmpty(strErrorMsg.ToString()))
            {
                plMessage.Visible = true;
                displayCustomMessage(FormatErrorMessage(strErrorMsg.ToString()), lblMessage, SystemMessageType.Error);
                return;
            }

            StoreSearchCriteria();
            ShowData();
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            displayCustomMessage(ex.Message, lblMessage, SystemMessageType.Error);
        }
    }

    private void StoreSearchCriteria() 
    {
        SearchCriteriaVO searchCriteriaVO = new SearchCriteriaVO();
        searchCriteriaVO.OrderNumber = txtOrderNumber.Text.Trim();
        if (dtpFrom.Text != "")
            searchCriteriaVO.FromDate = GetStoredDateValue(dtpFrom.SelectedDate);
        else
            searchCriteriaVO.FromDate = null;
        if (dtpTo.Text != "")
            searchCriteriaVO.ToDate = GetStoredDateValue(dtpTo.SelectedDate);
        else
            searchCriteriaVO.ToDate = null;
        searchCriteriaVO.SupplierId = txtSupplierId.Text.Trim();
        searchCriteriaVO.BuyerName = txtBuyer.Text.Trim();
        searchCriteriaVO.Status = ddlStatus.SelectedValue; 
        m_SearchCriteriaVO = searchCriteriaVO;
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
        if (string.Compare(m_FuncFlag, "ACK_ORDER", false) == 0)
        {
            poColl = mainController.GetOrderHeaderController().GetPendingAckPOList
           (m_SearchCriteriaVO.OrderNumber, m_SearchCriteriaVO.FromDate, m_SearchCriteriaVO.ToDate, m_SearchCriteriaVO.BuyerName);
        }

        if (string.Compare(m_FuncFlag, "ACPT_ORDER_ACKMT", false) == 0)
        {
            poColl = mainController.GetOrderHeaderController().GetPendingConfirmPOList
            (m_SearchCriteriaVO.OrderNumber, m_SearchCriteriaVO.FromDate, m_SearchCriteriaVO.ToDate, m_SearchCriteriaVO.BuyerName, m_SearchCriteriaVO.SupplierId);
        }

        if (string.Compare(m_FuncFlag, "VIEW_ORDER_SUPPLIER", false) == 0 ||
            string.Compare(m_FuncFlag, "VIEW_ORDER_BUYER", false) == 0)
        {
            poColl = mainController.GetOrderHeaderController().EnquiryPOList
            (m_SearchCriteriaVO.OrderNumber, m_SearchCriteriaVO.FromDate, m_SearchCriteriaVO.ToDate, m_SearchCriteriaVO.BuyerName, m_SearchCriteriaVO.SupplierId, m_SearchCriteriaVO.Status);
        }
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
            if (string.Compare(m_FuncFlag, "ACK_ORDER", false) == 0)
            {
                url = "~/PurchaseOrder/PurchaseOrderDetail.aspx?FunctionId=" + base.m_FunctionId;
                url += "&OrderNumber=" + m_SearchCriteriaVO.OrderNumber;
                if (m_SearchCriteriaVO.FromDate.HasValue)
                {
                    url += "&FormDate=" + m_SearchCriteriaVO.FromDate.Value.ToString();
                }
                if (m_SearchCriteriaVO.ToDate.HasValue)
                {
                    url += "&ToDate=" + m_SearchCriteriaVO.ToDate.Value.ToString();
                }
                url += "&BuyerName=" + m_SearchCriteriaVO.BuyerName;
                url += "&PageIdx=" + gvData.PageIndex.ToString();

                Session[SessionKey.OrderNumber] = orderNo;
            }
            if (string.Compare(m_FuncFlag, "ACPT_ORDER_ACKMT", false) == 0)
            {
                url = "~/PurchaseOrder/PurchaseOrderDetail.aspx?FunctionId=" + base.m_FunctionId;
                url += "&OrderNumber=" + m_SearchCriteriaVO.OrderNumber;
                if (m_SearchCriteriaVO.FromDate.HasValue)
                {
                    url += "&FormDate=" + m_SearchCriteriaVO.FromDate.Value.ToString();
                }
                if (m_SearchCriteriaVO.ToDate.HasValue)
                {
                    url += "&ToDate=" + m_SearchCriteriaVO.ToDate.Value.ToString();
                }
                url += "&SupplierId=" + m_SearchCriteriaVO.SupplierId;
                url += "&PageIdx=" + gvData.PageIndex.ToString();

                Session[SessionKey.OrderNumber] = orderNo;
            }
            if (string.Compare(m_FuncFlag, "VIEW_ORDER_SUPPLIER", false) == 0 ||
                string.Compare(m_FuncFlag, "VIEW_ORDER_BUYER", false) == 0)
            {
                url = "~/PurchaseOrder/PurchaseOrderDetail.aspx?FunctionId=" + base.m_FunctionId;
                url += "&OrderNumber=" + m_SearchCriteriaVO.OrderNumber;
                if (m_SearchCriteriaVO.FromDate.HasValue)
                {
                    url += "&FormDate=" + m_SearchCriteriaVO.FromDate.Value.ToString();
                }
                if (m_SearchCriteriaVO.ToDate.HasValue)
                {
                    url += "&ToDate=" + m_SearchCriteriaVO.ToDate.Value.ToString();
                }
                url += "&SupplierId=" + m_SearchCriteriaVO.SupplierId;
                url += "&BuyerName=" + m_SearchCriteriaVO.BuyerName;
                url += "&Status=" + m_SearchCriteriaVO.Status;
                url += "&PageIdx=" + gvData.PageIndex.ToString();

                Session[SessionKey.OrderNumber] = orderNo;
            }

            if(url!=null)
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

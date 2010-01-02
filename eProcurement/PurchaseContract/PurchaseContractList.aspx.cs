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

public partial class PurchaseContract_PurchaseContractList :BaseForm 
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
        public string ContractNumber;
        public Nullable<long> ContractFromDate;
        public Nullable<long> ContractToDate;
        public Nullable<long> ValidFromDate;
        public Nullable<long> ValidToDate;
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
                base.m_FunctionIdColl.Add("S-0007");
                base.m_FunctionIdColl.Add("S-0008");
                base.m_FunctionIdColl.Add("B-0005");
                
                string functionId = Request.QueryString["FunctionId"];
                if (string.IsNullOrEmpty(functionId))
                {
                    throw new Exception("Invalid Function Id.");
                }
                else
                {
                    base.m_FunctionId = functionId;
                    if (string.Compare(functionId, "S-0007", true) == 0)
                    {
                        m_FuncFlag = "ACK_CONTRACT";
                    }
                    if (string.Compare(functionId, "B-0005", true) == 0)
                    {
                        m_FuncFlag = "VIEW_CONTRACT_BUYER"; 
                    }
                    if (string.Compare(functionId, "S-0008", true) == 0)
                    {
                        m_FuncFlag = "VIEW_CONTRACT_SUPPLIER";
                    }
                    //if (string.Compare(functionId, "B-0002", true) == 0)
                    //{
                    //    m_FuncFlag = "VIEW_ORDER_BUYER";
                    //}
                    //if (string.Compare(functionId, "B-0004", true) == 0)
                    //{
                    //    m_FuncFlag = "ACK_ORDER_BUYER";
                    //}
                }
                base.Page_Load(sender, e);
                /***************************************************/
                imgSupplierSearch.Attributes.Add("onclick", "OpenSupplierDialog('" + txtSupplierId.ClientID + "')");
                imgSupplierSearch.Attributes.Add("style", "cursor: hand");

                //Initialize Page
                InitPage();

                //Handle for return back from order details page
                if (!string.IsNullOrEmpty(Request.QueryString["ReturnFromDetails"]))
                {
                    if (string.Compare(Request.QueryString["ReturnFromDetails"], "Y", true) == 0)
                    {
                        SearchCriteriaVO searchCriteriaVO = new SearchCriteriaVO();
                        searchCriteriaVO.ContractNumber = Request.QueryString["ContractNumber"];
                        if (!string.IsNullOrEmpty(Request.QueryString["ContractFromDate"]))
                            searchCriteriaVO.FromDate = Convert.ToInt64(Request.QueryString["ContractFromDate"].ToString());
                        else
                            searchCriteriaVO.FromDate = null;
                        if (!string.IsNullOrEmpty(Request.QueryString["ContractToDate"]))
                            searchCriteriaVO.ToDate = Convert.ToInt64(Request.QueryString["ContractToDate"].ToString());
                        else
                            searchCriteriaVO.ToDate = null;
                        if(!string.IsNullOrEmpty(Request.QueryString["ValidFromDate"]))
                            searchCriteriaVO.ValidFromDate=Convert.ToInt64(Request.QueryString["ValidFromDate"].ToString());
                        else
                            searchCriteriaVO.ValidFromDate= null;
                        if (!string.IsNullOrEmpty(Request.QueryString["ValidToDate"]))
                            searchCriteriaVO.ValidToDate = Convert.ToInt64(Request.QueryString["ValidToDate"].ToString());
                        else
                            searchCriteriaVO.ValidToDate = null;
                        searchCriteriaVO.SupplierId = Request.QueryString["SupplierId"];
                        searchCriteriaVO.Status = Request.QueryString["Status"];
                        //searchCriteriaVO.BuyerName = Request.QueryString["BuyerName"];
                        //searchCriteriaVO.Status = Request.QueryString["Status"];
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
            if (string.Compare(m_FuncFlag, "ACK_CONTRACT", false) == 0)
            {
                lblSubPath.Text = "Acknowledge Contract";
                plshSupplier.Visible = false;
                //plshBuyer.Visible = true;
                //plshStatus.Visible = false;
            }

           if (string.Compare(m_FuncFlag, "VIEW_CONTRACT_SUPPLIER", false) == 0)
            {
                lblSubPath.Text = "Enquire Contract";
                plshSupplier.Visible = false;
                //plshBuyer.Visible = true;
                //plshStatus.Visible = true;
                //InitStatusList();
            }

            if (string.Compare(m_FuncFlag, "VIEW_CONTRACT_BUYER", false) == 0)
            {
                lblSubPath.Text = "Enquire Contract";
                plshSupplier.Visible = true;
                //plshBuyer.Visible = true;
                //plshStatus.Visible = true;
                //InitStatusList();
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
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
        searchCriteriaVO.ContractNumber  = txtConNum.Text.Trim();
        if (dtpContractFrom.Text != "")
            searchCriteriaVO.ContractFromDate = GetStoredDateValue(dtpContractFrom.SelectedDate);
        else
            searchCriteriaVO.ContractFromDate = null;
        if (dtpContractTo.Text != "")
            searchCriteriaVO.ContractToDate  = GetStoredDateValue(dtpContractTo.SelectedDate);
        else
            searchCriteriaVO.ContractToDate = null;
        searchCriteriaVO.SupplierId = txtSupplierId.Text.Trim();
        if (dtpValFrom.Text != "")
            searchCriteriaVO.ValidFromDate = GetStoredDateValue(dtpValFrom.SelectedDate);
        else
            searchCriteriaVO.ContractFromDate = null;
        if (dtpValTo.Text != "")
            searchCriteriaVO.ValidToDate = GetStoredDateValue(dtpValTo.SelectedDate);
        else
            searchCriteriaVO.ValidToDate = null;
        //searchCriteriaVO.BuyerName = txtBuyer.Text.Trim();
        //searchCriteriaVO.Status = ddlStatus.SelectedValue;
        m_SearchCriteriaVO = searchCriteriaVO;
    }

    private void ShowData()
    {
        Collection<ContractHeader> poColl = GetData();
        gvData.DataSource = poColl;
        gvData.DataBind();
        lblCount.Text = string.Format("{0} record(s) found. ", poColl.Count.ToString());
    }

    private Collection<ContractHeader> GetData()
    {
        Collection<ContractHeader> pcColl = new Collection<ContractHeader>();
        if (string.Compare(m_FuncFlag, "ACK_CONTRACT", false) == 0)
        {
            pcColl = mainController.GetContractHeaderController().GetPendingAckContractList
           (m_SearchCriteriaVO.ContractNumber, m_SearchCriteriaVO.ContractFromDate, m_SearchCriteriaVO.ContractToDate,  m_SearchCriteriaVO.ValidFromDate, m_SearchCriteriaVO.ValidToDate);
        }
                
        if (string.Compare(m_FuncFlag, "VIEW_CONTRACT_SUPPLIER", false) == 0 ||
            string.Compare(m_FuncFlag, "VIEW_CONTRACT_BUYER", false) == 0)
        {
            pcColl = mainController.GetContractHeaderController().EnquiryContractList
            (m_SearchCriteriaVO.ContractNumber, m_SearchCriteriaVO.ContractFromDate, m_SearchCriteriaVO.ContractToDate, m_SearchCriteriaVO.ValidFromDate, m_SearchCriteriaVO.ValidToDate,m_SearchCriteriaVO.SupplierId,m_FuncFlag.Status);
        }
        return pcColl;
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
            LinkButton lbhlContractNo = (LinkButton)e.Row.FindControl("lbhlContractNo");
            lbhlContractNo.Attributes.Add("ContractNo", lbhlContractNo.Text);
        }
    }

    protected void hlContractNo_OnClick(object sender, System.EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();
            LinkButton lbhlContractNo = (LinkButton)sender;
            string contractNo = lbhlContractNo.Attributes["ContractNo"].ToString();
            string url = "";
            if (string.Compare(m_FuncFlag, "ACK_CONTRACT", false) == 0)
            {
                url = "~/PurchaseContract/PurchaseContractDetails.aspx?FunctionId=" + base.m_FunctionId;
                url += "&ContractNumber=" + m_SearchCriteriaVO.ContractNumber;
                if (m_SearchCriteriaVO.ValidFromDate.HasValue)
                {
                    url += "&ContractFromDate=" + m_SearchCriteriaVO.ContractFromDate.Value.ToString();
                }
                if (m_SearchCriteriaVO.ContractToDate.HasValue)
                {
                    url += "&ContractToDate=" + m_SearchCriteriaVO.ContractToDate.Value.ToString();
                }
                //url += "&BuyerName=" + m_SearchCriteriaVO.BuyerName;
                url += "&PageIdx=" + gvData.PageIndex.ToString();

                Session[SessionKey.ContractNumber] = contractNo;
            }
            
            if (string.Compare(m_FuncFlag, "VIEW_CONTRACT_SUPPLIER", false) == 0 ||
                string.Compare(m_FuncFlag, "VIEW_CONTRACT_BUYER", false) == 0)
            {
                url = "~/PurchaseContract/PurchaseContractDetail.aspx?FunctionId=" + base.m_FunctionId;
                url += "&ContractNumber=" + m_SearchCriteriaVO.ContractNumber;
                if (m_SearchCriteriaVO.ContractFromDate.HasValue)
                {
                    url += "&ContractFromDate=" + m_SearchCriteriaVO.ContractFromDate.Value.ToString();
                }
                if (m_SearchCriteriaVO.ContractToDate.HasValue)
                {
                    url += "&ContractToDate=" + m_SearchCriteriaVO.ContractToDate.Value.ToString();
                }
                url += "&SupplierId=" + m_SearchCriteriaVO.SupplierId;
                //url += "&BuyerName=" + m_SearchCriteriaVO.BuyerName;
                //url += "&Status=" + m_SearchCriteriaVO.Status;
                url += "&PageIdx=" + gvData.PageIndex.ToString();

                Session[SessionKey.OrderNumber] = contractNo;
            }

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
    #region validation
    private string ValidateInput()
    {
        System.Text.StringBuilder strErrorMsg = new System.Text.StringBuilder(string.Empty);

        bool bIsValid = true;
        bool bIsValidExp = true;
        if (dtpContractFrom.Text != "")
        {
            if (!dtpContractFrom.IsValidDate)
            {
                bIsValid = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Contract Date From."));
            }
        }

        if (dtpContractTo.Text != "")
        {
            if (!dtpContractTo.IsValidDate)
            {
                bIsValid = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Contract Date To."));
            }
        }
        if (dtpExpiryFrom.Text != "")
        {
            if (!dtpExpiryFrom.IsValidDate)
            {
                bIsValidExp = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Expiry Date From."));
            }
        }

        if (dtpExpiryTo.Text != "")
        {
            if (!dtpExpiryTo.IsValidDate)
            {
                bIsValidExp = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Expiry Date To."));
            }
        }
        if (!bIsValid)
        {
            return strErrorMsg.ToString();
        }

        if (dtpContractFrom.SelectedDateString != "" && dtpContractTo.SelectedDateString != "")
        {
            DateTime dtConFrom = dtpContractFrom.SelectedDate;
            DateTime dtConTo = dtpContractTo.SelectedDate;

            if (dtConFrom.CompareTo(dtConTo) > 0) //fromdate - todate (0=equal, 1=greater, -1=smaller)
            {
                strErrorMsg.Append(MakeListItem("Contract Date To must be equal or greater than Contract Date From."));
                return strErrorMsg.ToString();
            }
        }
        if (!bIsValidExp)
        {
            return strErrorMsg.ToString();
        }

        if (dtpExpiryFrom.SelectedDateString != "" && dtpExpiryTo.SelectedDateString != "")
        {
            DateTime dtValFrom = dtpValFrom.SelectedDate;
            DateTime dtValTo = dtpValTo.SelectedDate;

            if (dtValFrom.CompareTo(dtValTo) > 0) //fromdate - todate (0=equal, 1=greater, -1=smaller)
            {
                strErrorMsg.Append(MakeListItem("Valid Date To must be equal or greater than Valid Date From."));
                return strErrorMsg.ToString();
            }
        }
        return strErrorMsg.ToString();
    }
    #endregion
}

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

    //Store Search Criteria 
    [Serializable]
    private class SearchCriteriaVO
    {
        public string ContractNumber;
        public Nullable<long> ContractFromDate;
        public Nullable<long> ContractToDate;
        public Nullable<long> ExpiryFromDate;
        public Nullable<long> ExpiryToDate;
        public string SupplierId;
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
    protected void Page_Load(object sender, EventArgs e)
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
                base.m_FunctionId = "S-0007";
                base.Page_Load(sender, e);
                /***************************************************/
                
                //Handle for return back from Contract details page
                if (!string.IsNullOrEmpty(Request.QueryString["ReturnFromDetails"]))
                {
                    if (string.Compare(Request.QueryString["ReturnFromDetails"], "Y", true) == 0)
                    {
                        SearchCriteriaVO searchCriteriaVO = new SearchCriteriaVO();
                        searchCriteriaVO.ContractNumber = Request.QueryString["ContractNumber"];

                        if (!string.IsNullOrEmpty(Request.QueryString["ContractFromDate"]))
                            searchCriteriaVO.ContractFromDate = Convert.ToInt64(Request.QueryString["ContractFromDate"].ToString());
                        else
                            searchCriteriaVO.ContractFromDate = null;
                        if (!string.IsNullOrEmpty(Request.QueryString["ContractToDate"]))
                            searchCriteriaVO.ContractToDate = Convert.ToInt64(Request.QueryString["ContractToDate"].ToString());
                        else
                            searchCriteriaVO.ContractToDate = null;

                        if (!string.IsNullOrEmpty(Request.QueryString["ExpiryFromDate"]))
                            searchCriteriaVO.ExpiryFromDate = Convert.ToInt64(Request.QueryString["ExpiryFromDate"].ToString());
                        else
                            searchCriteriaVO.ExpiryFromDate = null;
                        if (!string.IsNullOrEmpty(Request.QueryString["ExpiryToDate"]))
                            searchCriteriaVO.ExpiryToDate = Convert.ToInt64(Request.QueryString["ExpiryToDate"].ToString());
                        else
                            searchCriteriaVO.ExpiryToDate = null;

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
        searchCriteriaVO.ContractNumber = txtContractNumber.Text.Trim();
        if (dtpContractFrom.Text != "")
            searchCriteriaVO.ContractFromDate = GetStoredDateValue(dtpContractFrom.SelectedDate);
        else
            searchCriteriaVO.ContractFromDate = null;
        if (dtpContractTo.Text != "")
            searchCriteriaVO.ContractToDate = GetStoredDateValue(dtpContractTo.SelectedDate);
        else
            searchCriteriaVO.ContractToDate = null;
        if (dtpExpiryFrom.Text != "")
            searchCriteriaVO.ExpiryFromDate = GetStoredDateValue(dtpExpiryFrom.SelectedDate);
        else
            searchCriteriaVO.ExpiryFromDate = null;
        if (dtpExpiryTo.Text != "")
            searchCriteriaVO.ExpiryToDate = GetStoredDateValue(dtpExpiryTo.SelectedDate);
        else
            searchCriteriaVO.ExpiryToDate = null;
        m_SearchCriteriaVO = searchCriteriaVO;
    }

    private void ShowData()
    {
        Collection<ContractHeader> contractColl = GetData();
        gvData.DataSource = contractColl;
        gvData.DataBind();
        lblCount.Text = string.Format("{0} record(s) found. ", contractColl.Count.ToString());
    }

    private Collection<ContractHeader> GetData()
    {
        Collection<ContractHeader> contractColl = new Collection<ContractHeader>();

        contractColl = mainController.GetPurchaseContractController().SearchPurchaseContract
        (m_SearchCriteriaVO.ContractNumber, m_SearchCriteriaVO.ContractFromDate, m_SearchCriteriaVO.ContractToDate,
            m_SearchCriteriaVO.ExpiryFromDate, m_SearchCriteriaVO.ExpiryToDate, mainController.GetLoginUserVO().SupplierId ,ContractAckStatus.No);
        return contractColl;
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

            url = "~/PurchaseContract/PurchaseContractDetails.aspx?FunctionId=" + base.m_FunctionId;
            url += "&ContractNumber=" + m_SearchCriteriaVO.ContractNumber;
            if (m_SearchCriteriaVO.ContractFromDate.HasValue)
            {
                url += "&ContractFromDate=" + m_SearchCriteriaVO.ContractFromDate.Value.ToString();
            }
            if (m_SearchCriteriaVO.ContractToDate.HasValue)
            {
                url += "&ContractToDate=" + m_SearchCriteriaVO.ContractToDate.Value.ToString();
            }
            if (m_SearchCriteriaVO.ExpiryFromDate.HasValue)
            {
                url += "&ExpiryFromDate=" + m_SearchCriteriaVO.ExpiryFromDate.Value.ToString();
            }
            if (m_SearchCriteriaVO.ExpiryToDate.HasValue)
            {
                url += "&ExpiryToDate=" + m_SearchCriteriaVO.ExpiryToDate.Value.ToString();
            }
            url += "&PageIdx=" + gvData.PageIndex.ToString();

            Session[SessionKey.ContractNumber] = contractNo;

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
                bIsValid = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Expiry Date From."));
            }
        }

        if (dtpExpiryTo.Text != "")
        {
            if (!dtpExpiryTo.IsValidDate)
            {
                bIsValid = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Expiry Date To."));
            }
        }

        if (!bIsValid)
        {
            return strErrorMsg.ToString();
        }

        if (dtpContractFrom.SelectedDateString != "" && dtpContractTo.SelectedDateString != "")
        {
            DateTime dtContractFrom = dtpContractFrom.SelectedDate;
            DateTime dtContractTo = dtpContractTo.SelectedDate;

            if (dtContractFrom.CompareTo(dtContractTo) > 0) //fromdate - todate (0=equal, 1=greater, -1=smaller)
            {
                strErrorMsg.Append(MakeListItem("Contract Date To must be equal or greater than Contract Date From."));
                return strErrorMsg.ToString();
            }
        }

        if (dtpExpiryFrom.SelectedDateString != "" && dtpExpiryTo.SelectedDateString != "")
        {
            DateTime dtExpiryFrom = dtpExpiryFrom.SelectedDate;
            DateTime dtExpiryTo = dtpExpiryTo.SelectedDate;

            if (dtExpiryFrom.CompareTo(dtExpiryTo) > 0) //fromdate - todate (0=equal, 1=greater, -1=smaller)
            {
                strErrorMsg.Append(MakeListItem("Expiry Date To must be equal or greater than Expiry Date From."));
                return strErrorMsg.ToString();
            }
        }

        return strErrorMsg.ToString();
    }
    #endregion

}

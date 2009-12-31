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
using eProcurement_BLL.UserManagement;
using eProcurement_DAL;

public partial class Quotation_QuotationRequestList : BaseForm
{

    private MainController mainController = null;

    #region Search Criteria
    [Serializable]
    private class SearchCriteriaVO
    {
        public Nullable<long> QuotationFromDate;
        public Nullable<long> QuotationToDate;
        public Nullable<long> ExpireFromDate;
        public Nullable<long> ExpireToDate;
        public string QuotationNumber;
        public string RequestNumber;
        public string SupplierId;
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
#endregion

    #region Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            plMessage.Visible = false;
            lblMessage.Text = string.Empty;

            //Instantiate MainController
            this.mainController = new MainController(); 

            if (!IsPostBack)
            {
                //Access control
                /***************************************************/
                base.m_FunctionIdColl.Add("Q-0001");
                base.Page_Load(sender, e);
                /***************************************************/

                imgSupplierSearch.Attributes.Add("onclick", "OpenSupplierDialog('" + txtSupplierId.ClientID + "')");
                imgSupplierSearch.Attributes.Add("style", "cursor: hand");

                LoginUserVO loginUser = (LoginUserVO)Session[SessionKey.LOGIN_USER];
                pnlSupplier.Visible = loginUser.ProfileType == ProfileType.Supplier ? false : true;
                LoadReqNo();
                
              //InitGrid();
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
            GetData();
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            displayCustomMessage(ex.Message, lblMessage, SystemMessageType.Error);
        }
    }

    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbhlQuotationNo = (LinkButton)e.Row.FindControl("lbhlQuotationNo");
            lbhlQuotationNo.Attributes.Add("QuotationNumber", lbhlQuotationNo.Text);

            HyperLink lbhlQuoNo = (HyperLink)e.Row.FindControl("lbhlQuoNo");
            Label lblReqNo = (Label)e.Row.FindControl("lblReqNo");

            lbhlQuoNo.Attributes.Add("lbhlQuoNo", lbhlQuoNo.Text);
            lbhlQuoNo.NavigateUrl = "QuotationRequestDetails.aspx?RequestNumber=" + lblReqNo.Text;
        }
    }

    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvData.PageIndex = e.NewPageIndex;
        GetData();
    }

    protected void lbhlQuotationNo_OnClick(object sender, System.EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();
            LinkButton lbhlQuotationNo = (LinkButton)sender;
            string quoNo = lbhlQuotationNo.Attributes["QuotationNumber"].ToString();
            string url = "";

            url = "~/Quotation/QuotationRequestDetails.aspx?FunctionId=" + base.m_FunctionId;
            url += "&RequestNumber=" + m_SearchCriteriaVO.RequestNumber;

            //url += "&QuotationNumber=" + m_SearchCriteriaVO.QuotationNumber;
            //if (m_SearchCriteriaVO.QuotationFromDate.HasValue)
            //{
            //    url += "&QuoFromDate=" + m_SearchCriteriaVO.QuotationFromDate.Value.ToString();
            //}
            //if (m_SearchCriteriaVO.QuotationToDate.HasValue)
            //{
            //    url += "&QuoToDate=" + m_SearchCriteriaVO.QuotationToDate.Value.ToString();
            //}
            //if (m_SearchCriteriaVO.ExpireFromDate.HasValue)
            //{
            //    url += "&ExpFromDate=" + m_SearchCriteriaVO.ExpireFromDate.Value.ToString();
            //}
            //if (m_SearchCriteriaVO.ExpireToDate.HasValue)
            //{
            //    url += "&ExpToDate=" + m_SearchCriteriaVO.ExpireToDate.Value.ToString();
            //}
            //url += "&RequestNumber=" + m_SearchCriteriaVO.RequestNumber;
            //url += "&SupplierId=" + m_SearchCriteriaVO.SupplierId;

            //url += "&PageIdx=" + gvData.PageIndex.ToString();

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

    #endregion

    #region Private Methods

    private void StoreSearchCriteria()
    {
        SearchCriteriaVO searchCriteriaVO = new SearchCriteriaVO();

        searchCriteriaVO.QuotationNumber = txtQuotationNo.Text.Trim();

        if (dtQuoDtFrom.Text != "")
            searchCriteriaVO.QuotationFromDate = GetStoredDateValue(dtQuoDtFrom.SelectedDate);
        else
            searchCriteriaVO.QuotationFromDate = null;

        if (dtQuoDtTo.Text != "")
            searchCriteriaVO.QuotationToDate = GetStoredDateValue(dtQuoDtTo.SelectedDate);
        else
            searchCriteriaVO.QuotationToDate = null;

        if (dtExpDtFrom.Text != "")
            searchCriteriaVO.ExpireFromDate = GetStoredDateValue(dtExpDtFrom.SelectedDate);
        else
            searchCriteriaVO.ExpireFromDate = null;

        if (dtQuoDtTo.Text != "")
            searchCriteriaVO.ExpireToDate = GetStoredDateValue(dtExpDtTo.SelectedDate);
        else
            searchCriteriaVO.ExpireToDate = null;
        
        LoginUserVO loginUser = (LoginUserVO) Session[SessionKey.LOGIN_USER];
        searchCriteriaVO.SupplierId = pnlSupplier.Visible == true ? txtSupplierId.Text.Trim() : loginUser.SupplierId;

        searchCriteriaVO.RequestNumber = ddlRequestNo.SelectedValue;
        //searchCriteriaVO.Status = ddlStatus.SelectedValue;
        m_SearchCriteriaVO = searchCriteriaVO;
    }

    private void LoadReqNo()
    {
        Collection<QuotationHeader> qHeader = this.mainController.GetDAOCreator().CreateQuotationHeaderDAO().RetrieveAll(" EBELN ASC");
        ddlRequestNo.DataSource = qHeader;
        ddlRequestNo.DataTextField = "RequestNumber";
        ddlRequestNo.DataValueField = "RequestNumber";
        ddlRequestNo.DataBind();
    }

    private void GetData()
    {
        Collection<QuotationHeader> objs = this.mainController.GetQuotationController().GetQuotationHeaderList(m_SearchCriteriaVO.QuotationNumber, m_SearchCriteriaVO.QuotationFromDate, m_SearchCriteriaVO.QuotationToDate, m_SearchCriteriaVO.ExpireFromDate, m_SearchCriteriaVO.ExpireToDate, m_SearchCriteriaVO.RequestNumber, m_SearchCriteriaVO.SupplierId);

        gvData.DataSource = objs;
        gvData.DataBind();
        lblCount.Text = string.Format("{0} record(s) found. ", objs.Count.ToString());
    }

    #endregion

    #region Validation
    private string ValidateInput()
    {
        System.Text.StringBuilder strErrorMsg = new System.Text.StringBuilder(string.Empty);

        bool bIsValid = true;
        if (dtQuoDtFrom.Text != "")
        {
            if (!dtQuoDtFrom.IsValidDate)
            {
                bIsValid = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Quotation Date From."));
            }
        }

        if (dtQuoDtTo.Text != "")
        {
            if (!dtQuoDtTo.IsValidDate)
            {
                bIsValid = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Quotation Date To."));
            }
        }

        if (dtExpDtFrom.Text != "")
        {
            if (!dtExpDtFrom.IsValidDate)
            {
                bIsValid = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Expiry Date From."));
            }
        }

        if (dtExpDtTo.Text != "")
        {
            if (!dtExpDtTo.IsValidDate)
            {
                bIsValid = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Expiry Date To."));
            }
        }


        if (!bIsValid)
        {
            return strErrorMsg.ToString();
        }

        if (dtQuoDtFrom.SelectedDateString != "" && dtQuoDtTo.SelectedDateString != "" && dtExpDtFrom.SelectedDateString != "" && dtExpDtTo.SelectedDateString != "")
        {
            DateTime dtQtnFrom = dtQuoDtFrom.SelectedDate;
            DateTime dtQtnTo = dtQuoDtTo.SelectedDate;

            if (dtQtnFrom.CompareTo(dtQtnTo) > 0) //fromdate - todate (0=equal, 1=greater, -1=smaller)
            {
                strErrorMsg.Append(MakeListItem("Quotation Date To must be equal or greater than Quotation Date From."));
                return strErrorMsg.ToString();
            }

            DateTime dtExpFrom = dtExpDtFrom.SelectedDate;
            DateTime dtExpTo = dtExpDtTo.SelectedDate;

            if (dtExpFrom.CompareTo(dtExpTo) > 0) //fromdate - todate (0=equal, 1=greater, -1=smaller)
            {
                strErrorMsg.Append(MakeListItem("Expiry Date To must be equal or greater than Expiry Date From."));
                return strErrorMsg.ToString();
            }
        }
        return strErrorMsg.ToString();
    }
    #endregion

}


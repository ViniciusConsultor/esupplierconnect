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
using eProcurement_DAL;
using eProcurement_BLL;

public partial class Quotation_ProcessQuotationList : BaseForm 
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
      
        public Nullable<long> QuoFromDate;
        public Nullable<long> QuoToDate;
        public Nullable<long> ExpFromDate;
        public Nullable<long> ExpToDate;
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
                base.m_FunctionIdColl.Add("S-0010");

                string functionId = Request.QueryString["FunctionId"];
                if (string.IsNullOrEmpty(functionId))
                {
                    throw new Exception("Invalid Function Id.");
                }
                else
                {
                    base.m_FunctionId = functionId;
                    if (string.Compare(functionId, "S-0010", true) == 0)
                    {
                        m_FuncFlag = "PROCESS_QUOTATION";
                    }
                   
                }
                base.Page_Load(sender, e);
                /***************************************************/
                //imgSupplierSearch.Attributes.Add("onclick", "OpenSupplierDialog('" + txtSupplierId.ClientID + "')");
                //imgSupplierSearch.Attributes.Add("style", "cursor: hand");

                //Initialize Page
                InitPage();

                //Handle for return back from order details page
                if (!string.IsNullOrEmpty(Request.QueryString["ReturnFromDetails"]))
                {
                    if (string.Compare(Request.QueryString["ReturnFromDetails"], "Y", true) == 0)
                    {
                        SearchCriteriaVO searchCriteriaVO = new SearchCriteriaVO();
                        
                        if (!string.IsNullOrEmpty(Request.QueryString["QuoFormDate"]))
                            searchCriteriaVO.QuoFromDate = Convert.ToInt64(Request.QueryString["QuoFormDate"].ToString());
                        else
                            searchCriteriaVO.QuoFromDate = null;
                        if (!string.IsNullOrEmpty(Request.QueryString["QuoToDate"]))
                            searchCriteriaVO.QuoToDate = Convert.ToInt64(Request.QueryString["QuoToDate"].ToString());
                        else
                            searchCriteriaVO.QuoToDate = null;
                        if (!string.IsNullOrEmpty(Request.QueryString["ExpFormDate"]))
                            searchCriteriaVO.ExpFormDate = Convert.ToInt64(Request.QueryString["ExpFormDate"].ToString());
                        else
                            searchCriteriaVO.ExpFormDate = null;
                        if (!string.IsNullOrEmpty(Request.QueryString["ExpToDate"]))
                            searchCriteriaVO.ExpToDate = Convert.ToInt64(Request.QueryString["ExpToDate"].ToString());
                        else
                            searchCriteriaVO.ExpToDate = null;
                        searchCriteriaVO.QuotationNumber = Request.QueryString["QuotationNumber"];
                        searchCriteriaVO.RequestNumber = Request.QueryString["RequestNumber"];
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
            if (string.Compare(m_FuncFlag, "PROCESS_QUOTATION", false) == 0)
            {
                lblSubPath.Text = "Process Quotation";
                //plshSupplier.Visible = false;
                //plshBuyer.Visible = true;
                //plshStatus.Visible = false;
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
        searchCriteriaVO.OrderNumber = txtOrderNumber.Text.Trim();
        if (dtQuoDtFrom.Text != "")
            searchCriteriaVO.QuoFromDate = GetStoredDateValue(dtQuoDtFrom.SelectedDate);
        else
            searchCriteriaVO.QuoToDate = null;
        if (dtQuoDtFrom.Text != "")
            searchCriteriaVO.QuoToDate = GetStoredDateValue(dtQuoDtTo.SelectedDate);
        else
            searchCriteriaVO.QuoToDate = null;
        if (dtExpDtFrom.Text != "")
            searchCriteriaVO.ExpFromDate = GetStoredDateValue(dtExpDtFrom.SelectedDate);
        else
            searchCriteriaVO.ExpFromDate = null;
        //searchCriteriaVO.SupplierId = txtSupplierId.Text.Trim();
        //searchCriteriaVO.BuyerName = txtBuyer.Text.Trim();
        //searchCriteriaVO.Status = "R";//for request
        m_SearchCriteriaVO = searchCriteriaVO;
    }

    private void ShowData()
    {
        Collection<QuotationHeader> qoColl = GetData();
        gvData.DataSource = qoColl;
        gvData.DataBind();
        lblCount.Text = string.Format("{0} record(s) found. ", qoColl.Count.ToString());
    }

    private Collection<QuotationHeader> GetData()
    {
        Collection<QuotationHeader> qoColl = new Collection<QuotationHeader>();
        if (string.Compare(m_FuncFlag, "PROCESS_QUOTATION", false) == 0)
        {
            qoColl = mainController.GetQuotationController().GetQuotationHeaderList
           (m_SearchCriteriaVO.QuoFromDate, m_SearchCriteriaVO.QuoToDate, m_SearchCriteriaVO.ExpFromDate, m_SearchCriteriaVO.ExpToDate, m_SearchCriteriaVO.QuotationNumber, m_SearchCriteriaVO.RequestNumber, Session[SessionKey.LOGIN_USER].ToString());
        }

       return qoColl;
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
            LinkButton lbhlQuotationNo = (LinkButton)e.Row.FindControl("lbhlQuotationNo");
            lbhlQuotationNo.Attributes.Add("QuotationNumber", lbhlQuotationNo.Text);
        }
    }

    protected void hlQuotationNo_OnClick(object sender, System.EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();
            LinkButton lbhlQuotationNo = (LinkButton)sender;
            string quotationNo = lbhlQuotationNo.Attributes["QuotationNumber"].ToString();
            string url = "";
            if (string.Compare(m_FuncFlag, "PROCESS_QUOTATION", false) == 0)
            {
                url = "~/DeliveryOrder/ProcessQuotationDetails.aspx?FunctionId=" + base.m_FunctionId;
                url += "&QuotationNumber=" + m_SearchCriteriaVO.QuotationNumber;
                if (m_SearchCriteriaVO.QuoFromDate.HasValue)
                {
                    url += "&QuoFromDate=" + m_SearchCriteriaVO.QuoFromDate.Value.ToString();
                }
                if (m_SearchCriteriaVO.QuoToDate.HasValue)
                {
                    url += "&QuoToDate=" + m_SearchCriteriaVO.QuoToDate.Value.ToString();
                }
                if (m_SearchCriteriaVO.ExpFromDate.HasValue)
                {
                    url += "&ExpFromDate=" + m_SearchCriteriaVO.ExpFromDate.Value.ToString();
                }
                if (m_SearchCriteriaVO.ExpToDate.HasValue)
                {
                    url += "&ExpToDate=" + m_SearchCriteriaVO.ExpToDate.Value.ToString();
                }
                //url += "&BuyerName=" + m_SearchCriteriaVO.BuyerName;
                url += "&PageIdx=" + gvData.PageIndex.ToString();

                //Session[SessionKey.Q] = orderNo;
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
                bIsValidExp = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Expiry Date From."));
            }
        }

        if (dtExpDtTo.Text != "")
        {
            if (!dtExpDtTo.IsValidDate)
            {
                bIsValidExp = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Expiry Date To."));
            }
        }
        if ((!bIsValid) || (!bIsValidExp))
        {
            return strErrorMsg.ToString();
        }

        if (dtQuoDtFrom.SelectedDateString != "" && dtQuoDtTo.SelectedDateString != "")
        {
            DateTime dtQFrom = dtQuoDtFrom.SelectedDate;
            DateTime dtQTo = dtQuoDtTo.SelectedDate;

            if (dtQFrom.CompareTo(dtQTo) > 0) //quotation fromdate - quotation todate (0=equal, 1=greater, -1=smaller)
            {
                strErrorMsg.Append(MakeListItem("Quotation Date To must be equal or greater than Quotation Date From."));
                return strErrorMsg.ToString();
            }
        }

        if (dtExpDtFrom.SelectedDateString != "" && dtExpDtTo.SelectedDateString != "")
        {
            DateTime dtEFrom = dtExpDtFrom.SelectedDate;
            DateTime dtETo = dtExpDtTo.SelectedDate;

            if (dtEFrom.CompareTo(dtETo) > 0) //expiry fromdate - expiry todate (0=equal, 1=greater, -1=smaller)
            {
                strErrorMsg.Append(MakeListItem("Expiry Date To must be equal or greater than Expiry Date From."));
                return strErrorMsg.ToString();
            }
        }
        return strErrorMsg.ToString();
    }
    #endregion
}

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
using eProcurement_BLL.UserManagement;
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
                base.m_FunctionId = "S-0010";
                m_FuncFlag = "PROCESS_QUOTATION";

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
                ShowData();           
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }


    private void ShowData()
    {
        Collection<QuotationHeader> qoColl = new Collection<QuotationHeader>();
        qoColl = GetData();

        gvData.DataSource = qoColl;
        gvData.DataBind();
        lblCount.Text = string.Format("{0} record(s) found. ", qoColl.Count.ToString());
    }

    private Collection<QuotationHeader> GetData()
    {
        Collection<QuotationHeader> qoColl = new Collection<QuotationHeader>();
    
        LoginUserVO loginUserVO = (LoginUserVO)Session[SessionKey.LOGIN_USER];
        string SupID;
        SupID = loginUserVO.SupplierId;
        qoColl = mainController.GetQuotationController().GetPendingProcessQuotationList(SupID);
    
        return qoColl;
    }

    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvData.PageIndex = e.NewPageIndex;
        ShowData();
    }



    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbhlRFQNo = (LinkButton)e.Row.FindControl("hlRFQNo");
            lbhlRFQNo.Attributes.Add("RequestNumber", lbhlRFQNo.Text);

            Label lblRecSts = (Label)e.Row.FindControl("lblRecordStatus");
            if (string.Compare(lblRecSts.Text, QuotationStatus.Request, true) == 0)
            {
                lblRecSts.Text = "Request";
            }

        }
    }

    protected void hlRFQNo_OnClick(object sender, System.EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();
            LinkButton lbhlRFQNo = (LinkButton)sender;
            string requestNo = lbhlRFQNo.Text.ToString();
            string url = "";
            if (string.Compare(m_FuncFlag, "PROCESS_QUOTATION", false) == 0)
            {
                url = "~/Quotation/ProcessQuotationDetail.aspx?FunctionId=" + base.m_FunctionId;
                url += "&RequestNumber=" + requestNo;
                url += "&PageIdx=" + gvData.PageIndex.ToString();

                Session[SessionKey.RequestNumber] = requestNo;
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

   
}

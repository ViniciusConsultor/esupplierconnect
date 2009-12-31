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

public partial class DeliveryOrder_EnquireDeliveryOrders : BaseForm
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
        public string DeliveryNumber;
        public string MaterialNumber;
        public Nullable<long> FromDate;
        public Nullable<long> ToDate;
        public string SupplierID;
        
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
                base.m_FunctionIdColl.Add("S-0005");
                base.m_FunctionIdColl.Add("W-0001");
                

                /*string functionId = Request.QueryString["FunctionId"];
                if (string.IsNullOrEmpty(functionId))
                {
                    throw new Exception("Invalid Function Id.");
                }
                else
                {
                    base.m_FunctionId = functionId;
                    if (string.Compare(functionId, "S-0005", true) == 0)
                    {
                        m_FuncFlag = "ENQ_DELIVERYORDER";
                    }

                    if (string.Compare(functionId, "W-0001", true) == 0)
                    {
                        m_FuncFlag = "ENQ_DELIVERYORDER";
                    }


                   
                } */
                base.Page_Load(sender, e);
                /***************************************************/
                
                //Initialize Page
                InitPage();                
                
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

            Collection<DeliveryOrder> doColl = new Collection<DeliveryOrder>();

            doColl = mainController.GetDeliveryOrderController().RetrieveAllDeliveryOrder();


            ddlDeliveryNo.DataSource = doColl;
            ddlDeliveryNo.DataTextField = "DeliveryNumber";
            ddlDeliveryNo.DataValueField = "DeliveryNumber";
            ddlDeliveryNo.DataBind();


            ddlOrderNo.DataSource = doColl;
            ddlOrderNo.DataTextField = "OrderNumber";
            ddlOrderNo.DataValueField = "OrderNumber";
            ddlOrderNo.DataBind();


            ddlMaterialNo.DataSource = doColl;
            ddlMaterialNo.DataTextField = "MaterialNumber";
            ddlMaterialNo.DataValueField = "MaterialNumber";
            ddlMaterialNo.DataBind();




            
            
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
        searchCriteriaVO.OrderNumber = ddlOrderNo.SelectedValue.ToString();
        searchCriteriaVO.MaterialNumber = ddlMaterialNo.SelectedValue.ToString();
        searchCriteriaVO.DeliveryNumber = ddlDeliveryNo.SelectedValue.ToString();
        searchCriteriaVO.SupplierID = this.mainController.GetLoginUserVO().SupplierId.ToString();
        searchCriteriaVO.FromDate = GetStoredDateValue(dtpFrom.SelectedDate);
        searchCriteriaVO.ToDate = GetStoredDateValue(dtpTo.SelectedDate);

       
        m_SearchCriteriaVO = searchCriteriaVO;
    }

    private void ShowData()
    {
        Collection<DeliveryOrder> doColl = GetData();
        gvData.DataSource = doColl;
        gvData.DataBind();
        lblCount.Text = string.Format("{0} record(s) found. ", doColl.Count.ToString());
    }

    private Collection<DeliveryOrder> GetData()
    {
        Collection<DeliveryOrder> doColl = new Collection<DeliveryOrder>();
       // if (string.Compare(m_FuncFlag, "ENQ_DELIVERYORDER", false) == 0)
       // {
            doColl = mainController.GetDeliveryOrderController().RetrieveByQueryDeliveryOrder(m_SearchCriteriaVO.OrderNumber,m_SearchCriteriaVO.MaterialNumber,m_SearchCriteriaVO.DeliveryNumber,m_SearchCriteriaVO.SupplierID,m_SearchCriteriaVO.FromDate,m_SearchCriteriaVO.ToDate);
       // }

        
        return doColl;
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

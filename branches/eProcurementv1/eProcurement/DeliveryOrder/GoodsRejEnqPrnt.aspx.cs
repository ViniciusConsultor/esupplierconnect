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

public partial class DeliveryOrder_GoodsRejEnqPrnt : BaseForm
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
        public string DocumentNumber;
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
                base.m_FunctionIdColl.Add("S-0016");
              


                //string functionId = Request.QueryString["FunctionId"];
                string functionId = "S-0016";
                if (string.IsNullOrEmpty(functionId))
                {
                    throw new Exception("Invalid Function Id.");
                }
                else
                {
                    base.m_FunctionId = functionId;
                    if (string.Compare(functionId, "S-0016", true) == 0)
                    {
                        m_FuncFlag = "ENQ_REJECTEDGOODS";
                    }




                   
                } 
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

            Collection<RejectedGood> rgColl = new Collection<RejectedGood>();

            rgColl = mainController.GetDeliveryController().RetrieveAllRejectedGood();


            ddlDeliveryNo.DataSource = rgColl;
            ddlDeliveryNo.DataTextField = "ReferenceNumber";
            ddlDeliveryNo.DataValueField = "ReferenceNumber";
            ddlDeliveryNo.DataBind();
            ddlDeliveryNo.Items.Insert(0, String.Empty);



            ddlOrderNo.DataSource = rgColl;
            ddlOrderNo.DataTextField = "OrderNumber";
            ddlOrderNo.DataValueField = "OrderNumber";
            ddlOrderNo.DataBind();
            ddlOrderNo.Items.Insert(0, String.Empty);



            ddlMaterialNo.DataSource = rgColl;
            ddlMaterialNo.DataTextField = "MaterialNumber";
            ddlMaterialNo.DataValueField = "MaterialNumber";
            ddlMaterialNo.DataBind();
            ddlMaterialNo.Items.Insert(0, String.Empty);

            ddlDocumentNo.DataSource = rgColl;
            ddlDocumentNo.DataTextField = "DocumentNumber";
            ddlDocumentNo.DataValueField = "DocumentNumber";
            ddlDocumentNo.DataBind();
            ddlDocumentNo.Items.Insert(0, String.Empty);


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

            string strErrorMsg = String.Empty;

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
        searchCriteriaVO.DocumentNumber = ddlDocumentNo.SelectedValue.ToString();

        m_SearchCriteriaVO = searchCriteriaVO;
    }

    private void ShowData()
    {
        Collection<RejectedGood> rgColl = GetData();
        gvData.DataSource = rgColl;
        gvData.DataBind();
        lblCount.Text = string.Format("{0} record(s) found. ", rgColl.Count.ToString());
    }

    private Collection<RejectedGood> GetData()
    {
        Collection<RejectedGood> rgColl = new Collection<RejectedGood>();
        // if (string.Compare(m_FuncFlag, "ENQ_DELIVERYORDER", false) == 0)
        // {
        rgColl = mainController.GetDeliveryController().RetrieveByQueryRejectedGood(m_SearchCriteriaVO.OrderNumber, m_SearchCriteriaVO.MaterialNumber, m_SearchCriteriaVO.DeliveryNumber, m_SearchCriteriaVO.DeliveryNumber,m_SearchCriteriaVO.SupplierID);
        // }


        return rgColl;
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



    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Collection<RejectedGood> rgColl = GetData();
    }
}
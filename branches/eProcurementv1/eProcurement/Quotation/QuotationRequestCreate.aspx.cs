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

public partial class Quotation_QuotationRequestCreate : BaseForm

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

    private string m_QueryString
    {
        get
        {
            if (ViewState["m_QueryString"] != null && ViewState["m_QueryString"].ToString() != string.Empty)
            {
                return ViewState["m_QueryString"].ToString();
            }
            else
            {
                return "";
            }
        }
        set
        {
            ViewState["m_QueryString"] = value;
        }
    }

    private bool CheckAccessRight()
    {
        if (string.Compare(m_FuncFlag, "QTRR", false) == 0)
        {

        }        
        return true;
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
                //////////////////////////Access control
                /////////////////////////***************************************************/
                ////////////////////////base.m_FunctionIdColl.Add("S-0010");
                

                ////////////////////////string functionId = Request.QueryString["FunctionId"];
                ////////////////////////if (string.IsNullOrEmpty(functionId))
                ////////////////////////{
                ////////////////////////    throw new Exception("Invalid Function Id.");
                ////////////////////////}
                ////////////////////////else
                ////////////////////////{
                ////////////////////////    if (string.Compare(functionId, "S-0010", true) == 0)
                ////////////////////////    {
                ////////////////////////        m_FuncFlag = "CreateRFQ";
                ////////////////////////        base.m_FunctionId = "S-0010";
                ////////////////////////    }
                   
                ////////////////////////}
                ////////////////////////base.Page_Load(sender, e);
                /////////////////////////***************************************************/

                //////////////////////////Initialize Page
                ////////////////////////InitPage();

                //////////////////////////Check access right
                ////////////////////////if (CheckAccessRight() == false)
                ////////////////////////    GotoTimeOutPage();

                //////////////////////////store querystring in viewstate, it will be used to pass back to list page
                ////////////////////////string queryString = Request.QueryString.ToString();
                

                
                InitItems();
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
    private void InitItems()
    {
        Collection<MaterialStock> items = mainController.GetDAOCreator().CreateMaterialStockDAO().RetrieveAll();        
        ddlMaterialNo.DataSource = items;
        ddlMaterialNo.DataTextField = "materialNumber";
        ddlMaterialNo.DataValueField = "materialNumber";
        ddlMaterialNo.DataBind();
        ddlMaterialNo.Items.Add(new ListItem("", "0"));
        ddlMaterialNo.SelectedValue = "0";
        

    }
    private void InitPage()
    {
        try
        {
            if (string.Compare(m_FuncFlag, "CreateRFQ", false) == 0)
            {
                lblSubPath.Text = "Quotation Request Create";
            }         
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        try
        {
            string url = "~/Quotation/QuotationRequestCreate.aspx";
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string materialNO = ddlMaterialNo.SelectedItem.Value.ToString().Trim() ;
        string RequisitionNo = txtRequisitionNo.Text.ToString().Trim();

        Collection<RequisitionItem> items = mainController.GetRequisitionController().GetRequisitionList(materialNO, RequisitionNo);

        lstRequisition.Items.Clear();
        lstRequisition.DataSource = items;
        lstRequisition.DataTextField = "RequisitionNumber";
        lstRequisition.DataValueField = "RequisitionNumber";
        lstRequisition.DataBind();

        Collection<Supplier> SupplierList = mainController.GetSupplierController().GetSupplierList();
        lstSupplier.Items.Clear();
        lstSupplier.DataSource = SupplierList;
        lstSupplier.DataTextField = "supplierName";
        lstSupplier.DataValueField = "supplierID";
        lstSupplier.DataBind();        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //
    }
    protected void ddlMaterialNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        string materialNO = ddlMaterialNo.SelectedItem.Value.ToString().Trim();
        string whereClause = " MATNR='" + materialNO + "' ";

        Collection<MaterialStock> items = mainController.GetDAOCreator().CreateMaterialStockDAO().RetrieveByQuery(whereClause);        

        if (items.Count >0 )
        { txtMaterialDesc.Text = items[0].MaterialDescription; }

    }
    protected void txtRequisitionNo_TextChanged(object sender, EventArgs e)
    {
        string RequisitionNo = txtRequisitionNo.Text.ToString().Trim();      

        
        Collection<RequisitionItem> items = mainController.GetRequisitionController().GetRequisitionList(RequisitionNo);

        ddlMaterialNo.DataSource = items;
        ddlMaterialNo.DataTextField = "materialNumber";
        ddlMaterialNo.DataValueField = "materialNumber";
        ddlMaterialNo.DataBind();
        ddlMaterialNo.Items.Add(new ListItem("", "0"));
        ddlMaterialNo.SelectedValue = "0";
        txtMaterialDesc.Text = ""; 

    }
}

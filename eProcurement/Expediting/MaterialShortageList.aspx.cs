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

public partial class PurchaseOrder_MaterialShortageList : BaseForm
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

    private int CurrentPage
    {
        get
        {
            // look for current page in ViewState
            object o = this.ViewState["_CurrentPage"];
            if (o == null)
                return 1; // default page index of 0
            else
                return (int)o;
        }

        set
        {
            this.ViewState["_CurrentPage"] = value;
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
                base.m_FunctionIdColl.Add("B-0011");
                base.m_FunctionIdColl.Add("B-0010");
                string functionId = Request.QueryString["FunctionId"];
                if (string.IsNullOrEmpty(functionId))
                {
                    throw new Exception("Invalid Function Id.");
                }
                else
                {
                    base.m_FunctionId = functionId;
                    if (string.Compare(functionId, "B-0011", true) == 0)
                    {
                        m_FuncFlag = "VIEW";
                    }
                    if (string.Compare(functionId, "B-0010", true) == 0)
                    {
                        m_FuncFlag = "PROCESS";
                    }
                }
                base.Page_Load(sender, e);
                /***************************************************/
                
                imgMaterialSearch.Attributes.Add("onclick", "OpenMaterialDialog('" + txtMaterialNumber.ClientID + "')");
                imgMaterialSearch.Attributes.Add("style", "cursor: hand");

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
            if (string.Compare(m_FuncFlag, "VIEW", false) == 0)
            {
                lblSubPath.Text = "View Shortage List";
                plView.Visible = true;
                plProcess.Visible = false;
                ShowData();
            }

            if (string.Compare(m_FuncFlag, "PROCESS", false) == 0)
            {
                lblSubPath.Text = "Purchase Order Expediting Process";
                plView.Visible = false;
                plProcess.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    protected void btnProcess_Click(object sender, EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();

            Process();
            CurrentPage = 1;
            ShowData();
            plView.Visible = true;
            plProcess.Visible = false;

        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            displayCustomMessage(ex.Message, lblMessage, SystemMessageType.Error);
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();
            CurrentPage = 1;
            ShowData();
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            displayCustomMessage(ex.Message, lblMessage, SystemMessageType.Error);
        }
    }

    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();
            txtMaterialNumber.Text = "";
            CurrentPage = 1;
            ShowData();
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            displayCustomMessage(ex.Message, lblMessage, SystemMessageType.Error);
        }
    }

    private void Process()
    {
        mainController.GetShortageMaterialController().ProcessShortageMaterialList(); 
    }

    private void ShowData()
    {
        string materialNumber = txtMaterialNumber.Text.Trim();
        Collection<ShortageMaterialVO> stMaterialVOs = mainController.GetShortageMaterialController().GetShortageMaterialList(materialNumber);

        PagedDataSource objPds = new PagedDataSource();
        //Set DataSource
        objPds.DataSource = stMaterialVOs;
        // Indicate that the data should be paged
        objPds.AllowPaging = true;
        // Set the number of items you wish to display per page
        objPds.PageSize = 20;
        // Set the PagedDataSource's current page 
        objPds.CurrentPageIndex = CurrentPage - 1;

        lblCurrentPage1.Text = CurrentPage.ToString();
        lblCurrentPage2.Text = CurrentPage.ToString();
        lblTotalPage1.Text = objPds.PageCount.ToString();
        lblTotalPage2.Text = objPds.PageCount.ToString();

        // Disable Prev or Next buttons if necessary
        btnPrev1.Enabled = !objPds.IsFirstPage;
        btnPrev2.Enabled = !objPds.IsFirstPage;
        btnNext1.Enabled = !objPds.IsLastPage;
        btnNext2.Enabled = !objPds.IsLastPage;

        gvItem.DataSource = objPds;
        gvItem.DataBind();
        lblCount.Text = string.Format("{0} record(s) found. ", stMaterialVOs.Count.ToString());
    }

    protected void gvItem_ItemDataBound(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView gvMaterialDtl = (GridView)e.Item.FindControl("gvMaterialDtl");
            Label lblSN = (Label)e.Item.FindControl("lblSN");
            Label lblMaterialNumber = (Label)e.Item.FindControl("lblMaterialNumber");
            lblSN.Text = Convert.ToString(Convert.ToInt32(lblSN.Text) + 1 + 20 * (CurrentPage - 1));

            Collection<PurchaseExpeditingVO> purchaseExpdVOs = mainController.GetPurchaseExpeditingController()
                .GetPurchaseExpeditingList(lblMaterialNumber.Text);
            gvMaterialDtl.DataSource = purchaseExpdVOs;
            gvMaterialDtl.DataBind();
        }
    }

    protected void gvMaterialDtl_RowDataBound(Object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            lblStatus.Text = ExpediteStatus.GetDesc(lblStatus.Text);  
        }
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            // Set viewstate variable to the previous page
            CurrentPage -= 1;

            // Reload control
            ShowData();

        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            displayCustomMessage(ex.Message, lblMessage, SystemMessageType.Error);
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            ShowData();
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            displayCustomMessage(ex.Message, lblMessage, SystemMessageType.Error);
        }
    }

}

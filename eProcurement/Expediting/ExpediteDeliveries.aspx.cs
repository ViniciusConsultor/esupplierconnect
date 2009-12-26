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

public partial class Expediting_ExpediteDeliveries : BaseForm
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
                base.m_FunctionId = "B-0013";
                base.Page_Load(sender, e);
                /***************************************************/

                imgMaterialSearch.Attributes.Add("onclick", "OpenMaterialDialog('" + txtMaterialNumber.ClientID + "')");
                imgMaterialSearch.Attributes.Add("style", "cursor: hand");

                ShowData();
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

    protected void btnProcess_Click(object sender, EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();

           
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
            ShowData();
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            displayCustomMessage(ex.Message, lblMessage, SystemMessageType.Error);
        }
    }

    private void ShowData()
    {
        string materialNumber = txtMaterialNumber.Text.Trim();
        Collection<ShortageMaterialVO> stMaterialVOs = mainController.GetShortageMaterialController().GetShortageMaterialList(materialNumber);
        gvItem.DataSource = stMaterialVOs;
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
            lblSN.Text = Convert.ToString(Convert.ToInt32(lblSN.Text) + 1);

            Collection<PurchaseExpeditingVO> purchaseExpdVOs = mainController.GetShortageMaterialController()
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
            string sStatus = lblStatus.Text.Trim();
            CheckBox ckExpedite = (CheckBox)e.Row.FindControl("ckExpedite");
            lblStatus.Text = ExpediteStatus.GetDesc(sStatus);
            if (string.Compare(sStatus, ExpediteStatus.New, true) != 0) 
            {
                ckExpedite.Enabled = false;
            } 
        }
    }
}

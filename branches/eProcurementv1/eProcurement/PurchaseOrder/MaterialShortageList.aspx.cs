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
                base.m_FunctionId = "B-0011";
                base.Page_Load(sender, e);
                /***************************************************/
            }

            ShowData();
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            string sMessage = ex.Message;
            displayCustomMessage(sMessage, lblMessage, SystemMessageType.Error);
        }
    }

    private void ShowData()
    {
        Collection<ShortageMaterialVO> stMaterialVOs = mainController.GetShortageMaterialController().GetShortageMaterialList();
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


}

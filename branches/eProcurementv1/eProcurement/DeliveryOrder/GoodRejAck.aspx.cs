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

public partial class DeliveryOrder_GoodRejAck : BaseForm
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
        public string ItemSequence;
        public string DocumentNumber;
        public string MaterialNumber;
    }

    private string m_CurrentOrderNumber
    {
        get
        {
            if (ViewState["m_CurrentOrderNumber"] != null && ViewState["m_CurrentOrderNumber"].ToString() != string.Empty)
            {
                return ViewState["m_CurrentOrderNumber"].ToString();
            }
            else
            {
                return "";
            }
        }
        set
        {
            ViewState["m_CurrentOrderNumber"] = value;
        }
    }
    private string m_CurrentItemSequence
    {
        get
        {
            if (ViewState["m_CurrentItemSequence"] != null && ViewState["m_CurrentItemSequence"].ToString() != string.Empty)
            {
                return ViewState["m_CurrentItemSequence"].ToString();
            }
            else
            {
                return "";
            }
        }
        set
        {
            ViewState["m_CurrentItemSequence"] = value;
        }
    }
    private string m_CurrentDocumentNumber
    {
        get
        {
            if (ViewState["m_CurrentDocumentNumber"] != null && ViewState["m_CurrentDocumentNumber"].ToString() != string.Empty)
            {
                return ViewState["m_CurrentDocumentNumber"].ToString();
            }
            else
            {
                return "";
            }
        }
        set
        {
            ViewState["m_CurrentDocumentNumber"] = value;
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
    new protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Instantiate MainController
            this.mainController = new MainController(base.LoginUser);

            plMessage.Visible = false;
            lblMessage.Text = string.Empty;
            btnAcknowledge.Visible = false;
            btnReturn.Visible = false;
            if (!IsPostBack)
            {
                //Access control
                /***************************************************/
                base.m_FunctionIdColl.Add("S-0015");
                //base.m_FunctionIdColl.Add("B-0001");

                string functionId = Request.QueryString["FunctionId"];
                if (string.IsNullOrEmpty(functionId))
                {
                    throw new Exception("Invalid Function Id.");
                }
                else
                {
                    base.m_FunctionId = functionId;
                    if (string.Compare(functionId, "S-0015", true) == 0)
                    {
                        m_FuncFlag = "ACK_REC_REJECTED_GOODS";
                    }
                    
                }
                base.Page_Load(sender, e);
                /***************************************************/

                //Initialize Page
                InitPage();

                //Check access right
                if (CheckAccessRight() == false)
                    GotoTimeOutPage();

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
            if (string.Compare(m_FuncFlag, "ACK_REC_REJECTED_GOODS", false) == 0)
            {
                lblSubPath.Text = "Acknowledge Receipt Rejected Goods";
                btnAcknowledge.Visible = true;
                btnReturn.Visible  = true;
            }

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    private bool CheckAccessRight()
    {
        if (string.Compare(m_FuncFlag, "ACK_REC_REJECTED_GOODS", false) == 0)
        {

        }
               
        return true;
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string materialNo = ddlMaterialNo.SelectedItem.Value.ToString().Trim();
        string itemSeq = ddlItemSequence.SelectedItem.Value.ToString().Trim();
        string docNo = ddlDocumentNo.SelectedItem.Value.ToString().Trim();
        string orderNo = txtOrderNo.Text.ToString().Trim();

        Collection<RejectedGood> rgood = mainController.GetDeliveryController().GetRejectedGoodList(orderNo, itemSeq, docNo, materialNo);

        gvItem.DataSource = rgood;
        gvItem.DataBind();
        lblCount.Text = rgood.Count.ToString() + " Record(s) was found.";
        if (rgood.Count > 0)
        {
            btnAcknowledge.Visible = true;
            btnAcknowledge.Enabled = true;
            btnReturn.Visible = true;
            btnReturn.Enabled = true;
        }
   }

    private void StoreSearchCriteria()
    {
        SearchCriteriaVO searchCriteriaVO = new SearchCriteriaVO();
        searchCriteriaVO.OrderNumber = txtOrderNo.Text.Trim();
        searchCriteriaVO.ItemSequence = ddlItemSequence.SelectedValue;
        searchCriteriaVO.DocumentNumber = ddlDocumentNo.SelectedValue;
        searchCriteriaVO.MaterialNumber = ddlMaterialNo.SelectedValue;
        m_SearchCriteriaVO = searchCriteriaVO;
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

    protected void gvItem_ItemDataBound(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblOrderNo = (Label)e.Item.FindControl("lblOrderNo");
            Label lblMaterialNumber = (Label)e.Item.FindControl("lblMaterialNumber");
            Label lblItemSeq = (Label)e.Item.FindControl("lblItemSeq");
            Label lblDocumentNo = (Label)e.Item.FindControl("lblDocumentNo");
            Label lblUOM = (Label)e.Item.FindControl("lblUOM");
            Label lblRefNo = (Label)e.Item.FindControl("lblRefNo");
            Label lblRejectQuantity = (Label)e.Item.FindControl("lblRejectQuantity");
            Label lblRejectDate = (Label)e.Item.FindControl("lblRejectDate");
            
            CheckBox chkAcknowledge = (CheckBox)e.Item.FindControl("chkAcknowledge");
            
        
        }
    }
    
    protected void btnAcknowledge_Click(object sender, EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();

            //string strErrorMsg = ValidateInput();
            string strErrorMsg = "";
            if (!string.IsNullOrEmpty(strErrorMsg.ToString()))
            {
                plMessage.Visible = true;
                displayCustomMessage(FormatErrorMessage(strErrorMsg.ToString()), lblMessage, SystemMessageType.Error);
                return;
            }

            Collection<RejectedGood> rGood = new Collection<RejectedGood>();

            RejectedGood rGoodobj = new RejectedGood();

            foreach (GridViewRow rowItem in gvItem.Rows)
            {
                Label lblOrderNo = (Label)rowItem.FindControl("lblOrderNo");
                Label lblItemSeq = (Label)rowItem.FindControl("lblItemSeq");
                Label lblDocNo = (Label)rowItem.FindControl("lblDocumentNo");
                CheckBox chkAck = (CheckBox) rowItem.FindControl("chkAcknowledge");

                if (chkAck.Checked== true )
                {
                    rGoodobj.AcknowledgeStatus = RejAckStatus.Yes;
                    rGoodobj.OrderNumber = lblOrderNo.Text.ToString();
                    rGoodobj.ItemSequence = lblItemSeq.Text.ToString();
                    rGoodobj.DocumentNumber = lblDocNo.Text.ToString();
                    rGood.Add(rGoodobj);
                    
                }
                
            }
            if (rGood.Count >0 )
            {
            mainController.GetDeliveryController().AcknowledgeRejectedGood(rGood);
            }
            
            plMessage.Visible = true;
            string sMessage = "Rejected Good has been acknowledged successfully.";
            displayCustomMessage(sMessage, lblMessage, SystemMessageType.Information);
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            string sMessage = ex.Message;
            displayCustomMessage(sMessage, lblMessage, SystemMessageType.Error);
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        try
        {
            string url = "~/DeliveryOrder/GoodRejAck.aspx";
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


    protected void txtOrderNo_TextChanged(object sender, EventArgs e)
    {
        string OrderNo = txtOrderNo.Text.ToString().Trim();

        Collection<RejectedGood> rgood = mainController.GetDeliveryController().GetRejectedGoodList(OrderNo);

        ddlItemSequence.DataSource = rgood;
        ddlItemSequence.DataTextField = "itemSequence";
        ddlItemSequence.DataValueField = "itemSequence";
        ddlItemSequence.DataBind();
        ddlItemSequence.Items.Add(new ListItem("", "0"));
        ddlItemSequence.SelectedValue = "0";
        //txtMaterialDesc.Text = ""; 

        ddlMaterialNo.DataSource = rgood;
        ddlMaterialNo.DataTextField = "materialNumber";
        ddlMaterialNo.DataValueField = "materialNumber";
        ddlMaterialNo.DataBind();
        ddlMaterialNo.Items.Add(new ListItem("", "0"));
        ddlMaterialNo.SelectedValue = "0";
        //txtMaterialDesc.Text = ""; 

        ddlDocumentNo.DataSource = rgood;
        ddlDocumentNo.DataTextField = "documentNumber";
        ddlDocumentNo.DataValueField = "documentNumber";
        ddlDocumentNo.DataBind();
        ddlDocumentNo.Items.Add(new ListItem("", "0"));
        ddlDocumentNo.SelectedValue = "0";

    }
    protected void ddlMaterialNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        string materialNo = ddlMaterialNo.SelectedItem.Value.ToString().Trim();
        string whereClause = " MATNR='" + materialNo + "' ";

        Collection<RejectedGood> rgood = mainController.GetDAOCreator().CreateRejectedGoodDAO().RetrieveByQuery(whereClause);

        //if (items.Count > 0)
        //{ txtMaterialDesc.Text = items[0].MaterialDescription; }
    }

    protected void ddlItemSequence_SelectedIndexChanged(object sender, EventArgs e)
    {
        string itemSeq = ddlItemSequence.SelectedItem.Value.ToString().Trim();
        string whereClause = " EBELP='" + itemSeq + "' ";
    }
    protected void ddlDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdStatus = (HiddenField)e.Row.FindControl("hdStatus");
            string sStatus = hdStatus.Value.Trim();

            CheckBox ckACKstatus = (CheckBox)e.Row.FindControl("chkAcknowledge");

            if (string.Compare(sStatus, ExpediteStatus.Acknowledge, true) == 0)
            {
                ckACKstatus.Checked = true;
            }
            else
            { ckACKstatus.Checked = false; }
        }
    }
}
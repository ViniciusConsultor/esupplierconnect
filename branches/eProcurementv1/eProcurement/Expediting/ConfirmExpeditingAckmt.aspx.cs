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


public partial class Expediting_ConfirmExpeditingAckmt : BaseForm
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
                base.m_FunctionId = "B-0014";
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

    private void ShowData()
    {
        string materialNumber = txtMaterialNumber.Text.Trim();
        Collection<ShortageMaterialVO> stMaterialVOs = mainController.GetShortageMaterialController().GetExpeditingShortageMaterialList(materialNumber);
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
                .GetPurchaseExpeditingList(lblMaterialNumber.Text.Trim());
            gvMaterialDtl.DataSource = purchaseExpdVOs;
            gvMaterialDtl.DataBind();
        }
    }

    protected void gvMaterialDtl_RowDataBound(Object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdStatus = (HiddenField)e.Row.FindControl("hdStatus");
            string sStatus = hdStatus.Value.Trim();
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            lblStatus.Text = ExpediteStatus.GetDesc(sStatus);
            
            UserControls_DatePicker dtExpeditDate = (UserControls_DatePicker)e.Row.FindControl("dtExpeditDate");
            HiddenField hdExpeditDate = (HiddenField)e.Row.FindControl("hdExpeditDate");
            if (!string.IsNullOrEmpty(hdExpeditDate.Value))
            {
                dtExpeditDate.SelectedDate = GetDateTimeFormStoredValue(Convert.ToInt64(hdExpeditDate.Value));
            }

            CheckBox ckExpedite = (CheckBox)e.Row.FindControl("ckExpedite");
            TextBox txtExpediteQty = (TextBox)e.Row.FindControl("txtExpediteQty");
            DropDownList ddlDecision = (DropDownList)e.Row.FindControl("ddlDecision");
            
            if (string.Compare(sStatus, ExpediteStatus.Acknowledge, true) == 0)
            {
                ckExpedite.Checked = true;
                ckExpedite.Enabled = false;
                
            }
            else 
            {
                ckExpedite.Enabled = false;
                ddlDecision.Visible = false;
                txtExpediteQty.Enabled = false;
                dtExpeditDate.Enabled = false;
            }
        }
    }

    protected void btnSumbit_Click(object sender, EventArgs e)
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

            Collection<PurchaseExpediting> expeditings = new Collection<PurchaseExpediting>();
            foreach (RepeaterItem rowItem in gvItem.Items)
            {
                GridView gvMaterialDtl = (GridView)rowItem.FindControl("gvMaterialDtl");
                foreach (GridViewRow rowSchedule in gvMaterialDtl.Rows)
                {
                    Label lblOrderNo = (Label)rowSchedule.FindControl("lblOrderNo");
                    Label lblItemSequence = (Label)rowSchedule.FindControl("lblItemSequence");
                    Label lblScheduleSequence = (Label)rowSchedule.FindControl("lblScheduleSequence");

                    CheckBox ckExpedite = (CheckBox)rowSchedule.FindControl("ckExpedite");
                    DropDownList ddlDecision = (DropDownList)rowSchedule.FindControl("ddlDecision");

                    if (ckExpedite.Checked && ddlDecision.SelectedValue != "")
                    {
                        UserControls_DatePicker dtExpeditDate = (UserControls_DatePicker)rowSchedule.FindControl("dtExpeditDate");
                        TextBox txtExpediteQty = (TextBox)rowSchedule.FindControl("txtExpediteQty");

                        PurchaseExpediting expediting = new PurchaseExpediting();
                        expediting.OrderNumber = lblOrderNo.Text;
                        expediting.ItemSequence = lblItemSequence.Text;
                        expediting.ScheduleSequence = lblScheduleSequence.Text;
                        expediting.ExpeditDate = GetStoredDateValue(dtExpeditDate.SelectedDate);
                        expediting.ExpediteQuantity = Convert.ToDecimal(txtExpediteQty.Text.Trim());
                        expediting.RecordStatus = ddlDecision.SelectedValue;
                        expeditings.Add(expediting);
                    }
                }
            }

            mainController.GetPurchaseExpeditingController().ConfirmExpeditingAcknowledgement(expeditings);

            ShowData();

            plMessage.Visible = true;
            string sMessage = "Records have been submitted successfully.";
            displayCustomMessage(sMessage, lblMessage, SystemMessageType.Information);
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            displayCustomMessage(ex.Message, lblMessage, SystemMessageType.Error);
        }
    }

    #region validation
    private string ValidateInput()
    {
        System.Text.StringBuilder strErrorMsg = new System.Text.StringBuilder(string.Empty);
        bool bIsValid = true;
        int iCount = 0;
        foreach (RepeaterItem rowItem in gvItem.Items)
        {
            GridView gvMaterialDtl = (GridView)rowItem.FindControl("gvMaterialDtl");
            Label lblItemSN = (Label)rowItem.FindControl("lblSN");

            foreach (GridViewRow rowSchedule in gvMaterialDtl.Rows)
            {
                CheckBox ckExpedite = (CheckBox)rowSchedule.FindControl("ckExpedite");
                DropDownList ddlDecision = (DropDownList)rowSchedule.FindControl("ddlDecision");

                if (ckExpedite.Checked && ddlDecision.SelectedValue !="")
                {
                    iCount++;

                    Label lblScheduleSN = (Label)rowSchedule.FindControl("lblScheduleSN");

                    string strSN = " for the record " + lblItemSN.Text + "-" + lblScheduleSN.Text + ".";

                    UserControls_DatePicker dtExpeditDate = (UserControls_DatePicker)rowSchedule.FindControl("dtExpeditDate");
                    TextBox txtExpediteQty = (TextBox)rowSchedule.FindControl("txtExpediteQty");
                    if (txtExpediteQty.Text.Trim() == "")
                    {
                        bIsValid = false;
                        strErrorMsg.Append(MakeListItem("Please select a valid value for Expedit Qty" + strSN));
                    }
                    else
                    {
                        if (!IsNumericText(txtExpediteQty.Text.Trim()))
                        {
                            bIsValid = false;
                            strErrorMsg.Append(MakeListItem("Please enter a valid Expedite Qty" + strSN));
                        }
                    }
                    if (dtExpeditDate.Text == "")
                    {
                        bIsValid = false;
                        strErrorMsg.Append(MakeListItem("Please select a valid value for Expedit Date" + strSN));
                    }
                    else
                    {
                        if (!dtExpeditDate.IsValidDate)
                        {
                            bIsValid = false;
                            strErrorMsg.Append(MakeListItem("Please select a valid value for Expedit Date" + strSN));
                        }
                    }
                }
            }
        }

        if (iCount == 0)
        {
            strErrorMsg.Append(MakeListItem("Please select at least one record to sumbit."));
        }

        return strErrorMsg.ToString();
    }
    #endregion

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

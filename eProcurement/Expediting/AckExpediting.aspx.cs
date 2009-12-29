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


public partial class Expediting_AckExpediting : BaseForm
{
    private MainController mainController = null;

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
            if (!IsPostBack)
            {
                //Access control
                /***************************************************/
                base.m_FunctionId = "S-0013";
                base.Page_Load(sender, e);
                /***************************************************/

                //store querystring in viewstate, it will be used to pass back to list page
                string queryString = Request.QueryString.ToString();
                m_QueryString = queryString;

                InitPOHeader();
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

    private void InitPOHeader()
    {
        PurchaseOrderHeader poHeader = mainController.GetOrderHeaderController().
            GetPurchaseOrderHeader(Session[SessionKey.OrderNumber].ToString());
        if (poHeader == null)
        {
            throw new Exception("Invalid Order Number.");
        }

        Supplier supplier = mainController.GetSupplierController().GetSupplier(poHeader.SupplierId);

        lblSupplierName.Text = supplier.SupplierName;
        lblSupplierAddress.Text = supplier.SupplierAddress;
        lblPostalCode.Text = "Singapore " + supplier.PostalCode;
        lblCountry.Text = supplier.CountryCode;

        lblShipmentAddress.Text = poHeader.ShipmentAddress;

        lblOrderNumber.Text = poHeader.OrderNumber;
        if (poHeader.OrderDate.HasValue)
            lblOrderDate.Text = GetShortDate(GetDateTimeFormStoredValue(poHeader.OrderDate.Value));
        else
            lblOrderDate.Text = "";
        lblSupplierId.Text = poHeader.SupplierId;
        lblOrderAmount.Text = poHeader.OrderAmount.ToString();
        lblGSTAmount.Text = poHeader.GstAmount.ToString();
        lblCurrency.Text = poHeader.CurrencyCode;
        lblPaymentTerm.Text = poHeader.PaymentTerms;
        lblBuyer.Text = poHeader.BuyerName;
        lblSalePerson.Text = poHeader.SalesPerson;
        lblRemarks.Text = poHeader.Remarks;
        hlHeaderText.NavigateUrl = "javascript:ShowHeaderText()";
    }

    private void InitItems()
    {
        Collection<PurchaseOrderItem> items = mainController.GetPurchaseExpeditingController()
            .GetExpeditingOrderItems(Session[SessionKey.OrderNumber].ToString());
        gvItem.DataSource = items;
        gvItem.DataBind();

    }

    protected void gvItem_ItemDataBound(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView gvSchedule = (GridView)e.Item.FindControl("gvSchedule");
            Label lblItemSequence = (Label)e.Item.FindControl("lblItemSequence");
            //Label lblPricePerUnit = (Label)e.Item.FindControl("lblPricePerUnit");
            //Label lblNetPrice = (Label)e.Item.FindControl("lblNetPrice");
            //Label lblNetAmount = (Label)e.Item.FindControl("lblNetAmount");

            //decimal amount = Convert.ToDecimal(lblPricePerUnit.Text) * Convert.ToDecimal(lblNetPrice.Text);
            //lblNetAmount.Text = amount.ToString();

            HyperLink hlItemText = (HyperLink)e.Item.FindControl("hlItemText");
            HyperLink hlComponent = (HyperLink)e.Item.FindControl("hlComponent");
            HyperLink hlService = (HyperLink)e.Item.FindControl("hlService");

            hlItemText.NavigateUrl = "javascript:ShowItemText('" + lblItemSequence.Text + "')";
            hlComponent.NavigateUrl = "javascript:ShowComponent('" + lblItemSequence.Text + "')";
            hlService.NavigateUrl = "javascript:ShowService('" + lblItemSequence.Text + "')";

            Collection<PurchaseExpeditingVO> schedules = mainController.GetPurchaseExpeditingController()
                .GetExpeditingOrderItemSchedules(Session[SessionKey.OrderNumber].ToString(), lblItemSequence.Text);
            gvSchedule.DataSource = schedules;
            gvSchedule.DataBind();
        }
    }

    protected void gvSchedule_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string isFisrt = "Y";

            HiddenField hdFirst = (HiddenField)e.Row.FindControl("hdFirst");

            HiddenField hdStatus = (HiddenField)e.Row.FindControl("hdStatus");
            string sStatus = hdStatus.Value.Trim();

            UserControls_DatePicker dtPromiseDate1 = (UserControls_DatePicker)e.Row.FindControl("dtPromiseDate1");
            Label lblPromiseDate1 = (Label)e.Row.FindControl("lblPromiseDate1");

            UserControls_DatePicker dtPromiseDate2 = (UserControls_DatePicker)e.Row.FindControl("dtPromiseDate2");
            Label lblPromiseDate2 = (Label)e.Row.FindControl("lblPromiseDate2");

            if (!string.IsNullOrEmpty(lblPromiseDate1.Text))
                isFisrt = "N";

            hdFirst.Value = isFisrt;

            if (string.Compare(isFisrt,"Y",true)==0)
            {
                dtPromiseDate2.Visible = false;
                lblPromiseDate1.Visible = false;
                lblPromiseDate2.Visible = false;

            }
            else 
            {
                dtPromiseDate1.Visible = false; 
                lblPromiseDate2.Visible = false;
            }
            
        }
    }


    protected void btnAcknowledge_Click(object sender, EventArgs e)
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
                Label lblItemNo = (Label)rowItem.FindControl("lblItemSequence");
                GridView gvSchedule = (GridView)rowItem.FindControl("gvSchedule");

                foreach (GridViewRow rowSchedule in gvSchedule.Rows)
                {
                    Label lblScheduleSequence = (Label)rowSchedule.FindControl("lblScheduleSequence");
                    HiddenField hdFirst = (HiddenField)rowSchedule.FindControl("hdFirst");

                    PurchaseExpediting expediting = new PurchaseExpediting();
                    expediting.OrderNumber = Session[SessionKey.OrderNumber].ToString(); ;
                    expediting.ItemSequence = lblItemNo.Text;
                    expediting.ScheduleSequence = lblScheduleSequence.Text;
                    
                    if (string.Compare(hdFirst.Value, "Y", true) == 0)
                    {
                        UserControls_DatePicker dtPromiseDate1 = (UserControls_DatePicker)rowSchedule.FindControl("dtPromiseDate1");
                        expediting.PromiseDate1 = GetStoredDateValue(dtPromiseDate1.SelectedDate);
                    }
                    else
                    {
                        UserControls_DatePicker dtPromiseDate2 = (UserControls_DatePicker)rowSchedule.FindControl("dtPromiseDate2");
                        expediting.PromiseDate2 = GetStoredDateValue(dtPromiseDate2.SelectedDate);
                    }

                    expeditings.Add(expediting);

                }
            }

            mainController.GetPurchaseExpeditingController().AcknowledgePurchaseExpediting(expeditings);

            string url = "~/Expediting/AckExpeditingList.aspx?ProceeSuccess=Y&" + m_QueryString;
            Response.Redirect(url);

            //btnAcknowledge.Enabled = false;
            //btnAcknowledge1.Enabled = false;
            //plMessage.Visible = true;
            //string sMessage = "Purchase expediting has been acknowledged successfully.";
            //displayCustomMessage(sMessage, lblMessage, SystemMessageType.Information);
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
            string url = "~/Expediting/AckExpeditingList.aspx?" + m_QueryString;
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
        int iCount = 0;
        foreach (RepeaterItem rowItem in gvItem.Items)
        {
            Label lblItemNo = (Label)rowItem.FindControl("lblItemSequence");
            GridView gvSchedule = (GridView)rowItem.FindControl("gvSchedule");

            foreach (GridViewRow rowSchedule in gvSchedule.Rows)
            {
                iCount++;
                
                Label lblScheduleSequence = (Label)rowSchedule.FindControl("lblScheduleSequence");
                HiddenField hdFirst = (HiddenField)rowSchedule.FindControl("hdFirst");

                string indicatorSN = string.Format(" Item Sequence:{0}, Schedule Sequence:{1}", lblItemNo.Text, lblScheduleSequence.Text);

                if (string.Compare(hdFirst.Value, "Y", true) == 0)
                {
                    UserControls_DatePicker dtPromiseDate1 = (UserControls_DatePicker)rowSchedule.FindControl("dtPromiseDate1");
                    if (dtPromiseDate1.Text == "")
                    {
                        bIsValid = false;
                        strErrorMsg.Append(MakeListItem("Please select a value for Promise Date 1." + indicatorSN));
                    }
                    else
                    {
                        if (!dtPromiseDate1.IsValidDate)
                        {
                            bIsValid = false;
                            strErrorMsg.Append(MakeListItem("Please select a valid value for Promise Date 1." + indicatorSN));
                        }
                    }
                }
                else 
                {
                    UserControls_DatePicker dtPromiseDate2 = (UserControls_DatePicker)rowSchedule.FindControl("dtPromiseDate2");
                    if (dtPromiseDate2.Text == "")
                    {
                        bIsValid = false;
                        strErrorMsg.Append(MakeListItem("Please select a value for Promise Date 2." + indicatorSN));
                    }
                    else
                    {
                        if (!dtPromiseDate2.IsValidDate)
                        {
                            bIsValid = false;
                            strErrorMsg.Append(MakeListItem("Please select a valid value for Promise Date 2." + indicatorSN));
                        }
                    }
                }

            }
        }

        if (iCount == 0)
        {
            strErrorMsg.Append(MakeListItem("No Record is to be processed."));
        }

        return strErrorMsg.ToString();
    }
    #endregion

}

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

public partial class PurchaseOrder_PurchaseOrderACK :BaseForm 
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
                base.m_FunctionIdColl.Add("S-0001");
                base.m_FunctionIdColl.Add("B-0001");

                string functionId = Request.QueryString["FunctionId"];
                if (string.IsNullOrEmpty(functionId))
                {
                    throw new Exception("Invalid Function Id.");
                }
                else
                {
                    if (string.Compare(functionId, "S-0001", true) == 0)
                    {
                        m_FuncFlag = "ACK_ORDER";
                        base.m_FunctionId = "S-0001";
                    }
                    if (string.Compare(functionId, "B-0001", true) == 0)
                    {
                        m_FuncFlag = "ACPT_ORDER_ACKMT";
                        base.m_FunctionId = "B-0001";
                    }
                }
                base.Page_Load(sender, e);
                /***************************************************/

                //Initialize Page
                InitPage();

                //Check access right
                if (CheckAccessRight() == false)
                    GotoTimeOutPage();

                //store querystring in viewstate, it will be used to pass back to list page
                string queryString = Request.QueryString.ToString();
                m_QueryString = queryString + "&ReturnFromDetails=Y";

                InitPOHeader();
                ImitItems();
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
            if (string.Compare(m_FuncFlag, "ACK_ORDER", false) == 0)
            {
                lblSubPath.Text = "Acknowledge Order";
            }

            if (string.Compare(m_FuncFlag, "ACPT_ORDER_ACKMT", false) == 0)
            {
                lblSubPath.Text = "Accept Order Acknowledgement";
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    private bool CheckAccessRight() 
    {
        if (string.Compare(m_FuncFlag, "ACK_ORDER", false) == 0)
        {
            
        }

        if (string.Compare(m_FuncFlag, "ACPT_ORDER_ACKMT", false) == 0)
        {
            
        }
        return true;
    }

    private void InitPOHeader() 
    {
        PurchaseOrderHeader poHeader = mainController.GetDAOCreator().
            CreatePurchaseOrderHeaderDAO().RetrieveByKey(Session[SessionKey.OrderNumber].ToString());
        if (poHeader == null) 
        {
            throw new Exception("Invalid Order Number."); 
        }

        Supplier supplier = mainController.GetDAOCreator().CreateSupplierDAO().RetrieveByKey(poHeader.SupplierId);  

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


    protected void gvItem_ItemDataBound(Object sender,RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView gvSchedule = (GridView)e.Item.FindControl("gvSchedule");
            Collection<PurchaseOrderItemSchedule> schedules = new Collection<PurchaseOrderItemSchedule>();
            int iCount = 2;
            for (int i = 1; i <= iCount; i++)
            {
                PurchaseOrderItemSchedule obj = new PurchaseOrderItemSchedule();

                obj.PurchaseOrderScheduleSequence = "0" + i;
                schedules.Add(obj);
            }
            gvSchedule.DataSource = schedules;
            gvSchedule.DataBind();
        }
     }

    private void ImitItems()
    {
        //Collection<PurchaseOrderItem> items = PurchaseOrderItemController.GetPurchaseOrderItems(m_Header.OrderNumber);
        Collection<PurchaseOrderItem> items=new Collection<PurchaseOrderItem>();
        int iCount = 2;
        for (int i = 1; i <= iCount; i++)
        {
            PurchaseOrderItem obj = new PurchaseOrderItem();

            obj.PurchaseItemSequenceNumber = "000" + i;
            obj.MaterialNumber = "M000" + i;
            obj.ShortText = "Material " + i;
            obj.OrderQuantity = 1000;
            obj.PricePerUnit  = 100;
            obj.UnitofMeasure  = "PCS";
            obj.NetPrice  = 300;
            obj.Remarks = "Remarks XXXXX " + i;
            obj.DeliveredQuantity  = 100;
            obj.LongTextDescription = "Long Text Description " + i;
            obj.StorageLocation = "Storage Location XXXXX " + i;
            items.Add(obj);
        }
        gvItem.DataSource = items;
        gvItem.DataBind();

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            
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
           
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            string sMessage = ex.Message;
            displayCustomMessage(sMessage, lblMessage, SystemMessageType.Error);
        }
    }

    
    /*
    private Collection<PurchaseOrderItemSchedule> m_Schedules
    {
        get
        {
            if (ViewState["m_Schedules"] != null)
            {
                return (Collection<PurchaseOrderItemSchedule>)ViewState["m_Schedules"];
            }
            else
            {
                return null;
            }
        }
        set
        {
            ViewState["m_Schedules"] = value;
        }
    }

    private Collection<PurchaseOrderItem> m_Items
    {
        get
        {
            if (ViewState["m_Items"] != null)
            {
                return (Collection<PurchaseOrderItem>)ViewState["m_Items"];
            }
            else
            {
                return null;
            }
        }
        set
        {
            ViewState["m_Items"] = value;
        }
    }

    private PurchaseOrderHeader m_Header
    {
        get
        {
            if (ViewState["m_Header"] != null)
            {
                return (PurchaseOrderHeader)ViewState["m_Header"];
            }
            else
            {
                return null;
            }
        }
        set
        {
            ViewState["m_Header"] = value;
        }
    }

    new protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            plMessage.Visible = false;
            lblMessage.Text = string.Empty;
            if (!IsPostBack)
            {
                PurchaseOrderHeader poHeader = (PurchaseOrderHeader)Session["Ack_POHeader"];
                m_Header = poHeader;
                m_Items = new Collection<PurchaseOrderItem>();
                m_Schedules = new Collection<PurchaseOrderItemSchedule>();
                Supplier supplier = SupplierController.GetSupplier(poHeader.SupplierID);
                lblSupplierName.Text = supplier.SupplierName;
                lblSupplierAddress.Text = supplier.SupplierAddress;
                lblPostalCode.Text = "Singapore " + supplier.PostalCode;
                lblCountry.Text = supplier.Country;
                lblShipmentAddress.Text = poHeader.ShipmentAddress;

                lblOrderNumber.Text = poHeader.OrderNumber;
                if (poHeader.OrderDate.HasValue)
                    lblOrderDate.Text = GetShortDate(GetDateTimeFormStoredValue(poHeader.OrderDate.Value));
                else
                    lblOrderDate.Text = "";
                lblSupplierId.Text = poHeader.SupplierID;
                lblPaymentTerm.Text = poHeader.PaymentTerms;
                lblRemarks.Text = poHeader.Remarks;
                lblBuyer.Text = poHeader.BuyerName;
                lblPhone.Text = "";
                lblCurrency.Text = poHeader.CurrencyCode;
                hlHeaderText.NavigateUrl = "javascript:ShowHeaderText('" + poHeader.OrderNumber + "')";

                ShowItems();
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

    //protected void lbhHeaderText_OnClick(object sender, System.EventArgs e)
    //{
    //    try
    //    {
    //        //LinkButton lbhHeaderText = (LinkButton)sender;
    //        string url = "~/PurchaseOrder/PurchaseOrderHeaderText.aspx";
    //        Response.Redirect(url);

    //    }
    //    catch (Exception ex)
    //    {
    //        ExceptionLog(ex);
    //        plMessage.Visible = true;
    //        string sMessage = ex.Message;
    //        displayCustomMessage(sMessage, lblMessage, SystemMessageType.Error);
    //    }
    //}

    protected void gvItem_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvSchedule = (GridView)e.Row.FindControl("gvSchedule");
            Label lblItemNo = (Label)e.Row.FindControl("lblItemNo");
            Label lblPricePerUnit = (Label)e.Row.FindControl("lblPricePerUnit");
            Label lblNetPrice = (Label)e.Row.FindControl("lblNetPrice");
            Label lblNetAmount = (Label)e.Row.FindControl("lblNetAmount");

            decimal amount = Convert.ToDecimal(lblPricePerUnit.Text) * Convert.ToDecimal(lblNetPrice.Text);
            lblNetAmount.Text = amount.ToString();

            HyperLink hlItemText = (HyperLink)e.Row.FindControl("hlItemText");
            HyperLink hlComponent = (HyperLink)e.Row.FindControl("hlComponent");
            HyperLink hlService = (HyperLink)e.Row.FindControl("hlService");

            hlItemText.NavigateUrl = "javascript:ShowItemText('" + m_Header.OrderNumber + "','" + lblItemNo.Text + "')";
            hlComponent.NavigateUrl = "javascript:ShowComponent('" + m_Header.OrderNumber + "','" + lblItemNo.Text + "')";
            hlService.NavigateUrl = "javascript:ShowService('" + m_Header.OrderNumber + "','" + lblItemNo.Text + "')";

            Collection<PurchaseOrderItemSchedule> schedules = PurchaseOrderItemController.GetPurchaseOrderScheduleItems(m_Header.OrderNumber, lblItemNo.Text);
            foreach (PurchaseOrderItemSchedule schedule in schedules)
            {
                m_Schedules.Add(schedule);
            }
            gvSchedule.DataSource = schedules;
            gvSchedule.DataBind();
        }
    }

    protected void gvSchedule_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdAckDate = (HiddenField)e.Row.FindControl("hdAckDate");
            UserControls_DatePicker dtpAck = (UserControls_DatePicker)e.Row.FindControl("dtpAck");
            if (hdAckDate.Value.Length > 1)
            {
                dtpAck.SelectedDate = GetDateTimeFormStoredValue(Convert.ToInt64(hdAckDate.Value));
            }

        }
    }

    private void ShowItems()
    {
        Collection<PurchaseOrderItem> items = PurchaseOrderItemController.GetPurchaseOrderItems(m_Header.OrderNumber);
        m_Items = items;
        gvItem.DataSource = items;
        gvItem.DataBind();

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string strErrorMsg = ValidateInput();

            if (!string.IsNullOrEmpty(strErrorMsg.ToString()))
            {
                plMessage.Visible = true;
                displayCustomMessage(FormatErrorMessage(strErrorMsg.ToString()), lblMessage, SystemMessageType.Error);
                return;
            }

            m_Header.AcknowledgeStatus = POAckStatus.Acknowledged;

            foreach (GridViewRow rowItem in gvItem.Rows)
            {
                Label lblItemNo = (Label)rowItem.FindControl("lblItemNo");
                GridView gvSchedule = (GridView)rowItem.FindControl("gvSchedule");
                foreach (GridViewRow rowSchedule in gvSchedule.Rows)
                {
                    Label lblPurchaseOrderScheduleSequence = (Label)rowSchedule.FindControl("lblPurchaseOrderScheduleSequence");
                    UserControls_DatePicker dtpAck = (UserControls_DatePicker)rowSchedule.FindControl("dtpAck");

                    foreach (PurchaseOrderItemSchedule schedule in m_Schedules)
                    {
                        if (string.Compare(lblItemNo.Text, schedule.PurchaseOrderItemSequence, true) == 0 &&
                            string.Compare(lblPurchaseOrderScheduleSequence.Text, schedule.PurchaseOrderScheduleSequence, true) == 0)
                        {
                            schedule.AcknowledgementDate = GetStoredDateValue(dtpAck.SelectedDate);
                        }
                    }
                }
            }

            PurchaseOrderController.AcknowledgePurchaseOrder(m_Header, m_Schedules);

            btnSubmit.Enabled = false;
            plMessage.Visible = true;
            string sMessage = "Purchase Order has been acknowledged successfully.";
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
            string url = "~/PurchaseOrder/PurchaseOrderList.aspx";
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
        foreach (GridViewRow rowItem in gvItem.Rows)
        {
            GridView gvSchedule = (GridView)rowItem.FindControl("gvSchedule");
            foreach (GridViewRow rowSchedule in gvSchedule.Rows)
            {
                UserControls_DatePicker dtpAck = (UserControls_DatePicker)rowSchedule.FindControl("dtpAck");
                if (dtpAck.Text == "")
                {
                    bIsValid = false;
                    strErrorMsg.Append(MakeListItem("Please select a value for Ack.Dt."));
                }
                else
                {
                    if (!dtpAck.IsValidDate)
                    {
                        bIsValid = false;
                        strErrorMsg.Append(MakeListItem("Please select a valid value for Ack.Dt."));
                    }
                }
                bIsValid = false;
                break;
            }
            if (!bIsValid)
                break;
        }

        //if (!bIsValid)
        //{
        //    return strErrorMsg.ToString();
        //}

        //if (dtpFrom.SelectedDateString != "" && dtpTo.SelectedDateString != "")
        //{
        //    DateTime dtFrom = dtpFrom.SelectedDate;
        //    DateTime dtTo = dtpTo.SelectedDate;

        //    if (dtFrom.CompareTo(dtTo) > 0) //fromdate - todate (0=equal, 1=greater, -1=smaller)
        //    {
        //        strErrorMsg.Append(MakeListItem("Order Date To must be equal or greater than Order Date From."));
        //        return strErrorMsg.ToString();
        //    }
        //}
        return strErrorMsg.ToString();
    }
    #endregion
     * */
}

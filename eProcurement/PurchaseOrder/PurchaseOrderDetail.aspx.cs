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


public partial class PurchaseOrder_PurchaseOrderDetail : BaseForm
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
                    base.m_FunctionId = functionId;
                    if (string.Compare(functionId, "S-0001", true) == 0)
                    {
                        m_FuncFlag = "ACK_ORDER";
                    }
                    if (string.Compare(functionId, "B-0001", true) == 0)
                    {
                        m_FuncFlag = "ACPT_ORDER_ACKMT";
                    }
                    if (string.Compare(functionId, "S-0002", true) == 0)
                    {
                        m_FuncFlag = "VIEW_ORDER";
                    }
                    if (string.Compare(functionId, "B-0002", true) == 0)
                    {
                        m_FuncFlag = "VIEW_ORDER";
                    }
                    if (string.Compare(functionId, "B-0004", true) == 0)
                    {
                        m_FuncFlag = "ACK_ORDER_BUYER";
                    }
                }
                base.Page_Load(sender, e);
                /***************************************************/
                if ((LoginUser.FuncList.Contains("S-0003") || LoginUser.FuncList.Contains("B-0003"))
                    && string.Compare(m_FuncFlag, "VIEW_ORDER", false) == 0)
                {
                    btnPrint1.Attributes.Add("onclick", "PrintReport()");
                    btnPrint2.Attributes.Add("onclick", "PrintReport()");
                }
                else 
                {
                    btnPrint1.Visible = false;
                    btnPrint2.Visible = false; 
                }
                
                //Initialize Page
                InitPage();

                //Check access right
                if (CheckAccessRight() == false)
                    GotoTimeOutPage();

                //store querystring in viewstate, it will be used to pass back to list page
                string queryString = Request.QueryString.ToString();
                m_QueryString = queryString + "&ReturnFromDetails=Y";

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

    private void InitPage()
    {
        try
        {
            if (string.Compare(m_FuncFlag, "ACK_ORDER", false) == 0)
            {
                lblSubPath.Text = "Acknowledge Order";
                btnReject.Visible =false;
                btnAccept.Visible = false;
                btnReject1.Visible = false;
                btnAccept1.Visible = false;
            }

            if (string.Compare(m_FuncFlag, "ACK_ORDER_BUYER", false) == 0)
            {
                lblSubPath.Text = "Acknowledge Order by Buyer";
                btnReject.Visible = false;
                btnAccept.Visible = false;
                btnReject1.Visible = false;
                btnAccept1.Visible = false;
            }

            if (string.Compare(m_FuncFlag, "ACPT_ORDER_ACKMT", false) == 0)
            {
                lblSubPath.Text = "Accept Order Acknowledgement";
                btnAcknowledge.Visible = false;
                btnAcknowledge1.Visible = false;
            }

            if (string.Compare(m_FuncFlag, "VIEW_ORDER", false) == 0)
            {
                lblSubPath.Text = "View Order Details";
                btnAcknowledge.Visible = false;
                btnReject.Visible = false;
                btnAccept.Visible = false;
                btnAcknowledge1.Visible = false;
                btnReject1.Visible = false;
                btnAccept1.Visible = false;
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
        Collection<PurchaseOrderItem> items = mainController.GetOrderItemController()
            .GetPurchaseOrderItems(Session[SessionKey.OrderNumber].ToString());
        gvItem.DataSource = items;
        gvItem.DataBind();

    }

    protected void gvItem_ItemDataBound(Object sender,RepeaterItemEventArgs e)
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

            InitItemSchedules(lblItemSequence.Text, gvSchedule);
        }
     }

    private void InitItemSchedules(string itemSequence, GridView gvSchedule)
    {
        Collection<PurchaseOrderItemSchedule> schedules = mainController.GetOrderItemController()
               .GetPurchaseOrderItemSchedules(Session[SessionKey.OrderNumber].ToString(), itemSequence);
        gvSchedule.DataSource = schedules;
        gvSchedule.DataBind();

    }

     protected void gvSchedule_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             Label lblAcknowledgeDate = (Label)e.Row.FindControl("lblAcknowledgeDate");
             UserControls_DatePicker dtAcknowledgeDate = (UserControls_DatePicker)e.Row.FindControl("dtAcknowledgeDate");

             string strAcknowledgementDate = lblAcknowledgeDate.Text;
             if (!string.IsNullOrEmpty(strAcknowledgementDate)) 
             {
                 DateTime dtAcknowledgementDate = GetDateTimeFormStoredValue(Convert.ToInt64(strAcknowledgementDate));
                 lblAcknowledgeDate.Text = GetShortDate(dtAcknowledgementDate);
                 dtAcknowledgeDate.SelectedDate = dtAcknowledgementDate;
             } 
         }
     }

    protected void gvSchedule_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (string.Compare(m_FuncFlag, "ACK_ORDER", false) == 0)
            {
                //Acknowledge Date - Text
                e.Row.Cells[5].Visible = false;
            }

            if (string.Compare(m_FuncFlag, "ACPT_ORDER_ACKMT", false) == 0)
            {
                //Acknowledge Date - DatePicker
                e.Row.Cells[6].Visible = false;
            }

            if (string.Compare(m_FuncFlag, "VIEW_ORDER", false) == 0)
            {
                //Acknowledge Date - DatePicker
                e.Row.Cells[6].Visible = false;
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

             Collection<PurchaseOrderItemSchedule> schedules = new Collection<PurchaseOrderItemSchedule>();

             foreach (RepeaterItem rowItem in gvItem.Items)
             {
                 Label lblItemNo = (Label)rowItem.FindControl("lblItemSequence");
                 GridView gvSchedule = (GridView)rowItem.FindControl("gvSchedule");
                 foreach (GridViewRow rowSchedule in gvSchedule.Rows)
                 {
                     Label lblPurchaseOrderScheduleSequence = (Label)rowSchedule.FindControl("lblScheduleSequence");
                     UserControls_DatePicker dtpAck = (UserControls_DatePicker)rowSchedule.FindControl("dtAcknowledgeDate");
                     PurchaseOrderItemSchedule schedule = new PurchaseOrderItemSchedule();
                     schedule.PurchaseOrderNumber = Session[SessionKey.OrderNumber].ToString();
                     schedule.PurchaseOrderItemSequence = lblItemNo.Text;
                     schedule.PurchaseOrderScheduleSequence = lblPurchaseOrderScheduleSequence.Text;
                     schedule.AcknowledgementDate = GetStoredDateValue(dtpAck.SelectedDate);
                     schedules.Add(schedule); 
                 }
             }

             if (string.Compare(m_FuncFlag, "ACK_ORDER", false) == 0)
             {
                 mainController.GetOrderHeaderController().AcknowledgePurchaseOrder(schedules);  
             }

             if (string.Compare(m_FuncFlag, "ACK_ORDER_BUYER", false) == 0)
             {
                 mainController.GetOrderHeaderController().AcknowledgePurchaseOrderByBuyer(schedules);  
             }
       
             btnAcknowledge.Enabled = false;
             btnAcknowledge1.Enabled = false;
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

    protected void btnAcceptReject_Click(object sender, EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();

            bool bAccept = false;
            Button btn = (Button)sender;
            if (string.Compare(btn.ID, "btnAccept", false) == 0 || string.Compare(btn.ID, "btnAccept1", false) == 0)
            {
                bAccept = true;
            }

            int iReturn = mainController.GetOrderHeaderController().ConfirmOrderAcknowledgement(Session[SessionKey.OrderNumber].ToString(), bAccept);

            btnAccept.Enabled = false;
            btnReject.Enabled = false;
            btnAccept1.Enabled = false;
            btnReject1.Enabled = false;
            plMessage.Visible = true;
            string sMessage = "";
            if (iReturn==1)
                sMessage = "Purchase Order has been accepted successfully.";
            else if (iReturn==2)
                sMessage = "Purchase Order has been rejected successfully.";
            else 
                sMessage = "Purchase Order has been rejected for 2nd acknowledgement.";

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
             string url = "~/PurchaseOrder/PurchaseOrderList.aspx?" + m_QueryString;
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
             GridView gvSchedule = (GridView)rowItem.FindControl("gvSchedule");
             foreach (GridViewRow rowSchedule in gvSchedule.Rows)
             {
                 UserControls_DatePicker dtpAck = (UserControls_DatePicker)rowSchedule.FindControl("dtAcknowledgeDate");
                 iCount++;
                 if (dtpAck.Text == "")
                 {
                     bIsValid = false;
                     strErrorMsg.Append(MakeListItem("Please select a value for Acknowledge Date."));
                 }
                 else
                 {
                     if (!dtpAck.IsValidDate)
                     {
                         bIsValid = false;
                         strErrorMsg.Append(MakeListItem("Please select a valid value for Acknowledge Date."));
                     }
                 }
                 if (!bIsValid)
                     break;
             }
         }

         if (iCount == 0) 
         {
             strErrorMsg.Append(MakeListItem("You didn't acknowledge any order."));
         }

         return strErrorMsg.ToString();
     }
     #endregion

}

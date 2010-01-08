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


public partial class DeliveryOrder_PurchaseOrderDetail : BaseForm
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
                base.m_FunctionIdColl.Add("S-0004");
               

                string functionId = Request.QueryString["FunctionId"];

                if (string.IsNullOrEmpty(functionId))
                {
                    throw new Exception("Invalid Function Id.");
                }
                else
                {
                    base.m_FunctionId = functionId;

                    if (string.Compare(functionId, "S-0004", true) == 0)
                    {
                        m_FuncFlag = "Create Delivery Order";
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
          

            if (string.Compare(m_FuncFlag, "VIEW_ORDER", false) == 0)
            {
                lblSubPath.Text = "View Order Details";
               
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

            Collection<PurchaseOrderItemSchedule> schedules = mainController.GetOrderItemController()
                .GetPurchaseOrderItemSchedules(Session[SessionKey.OrderNumber].ToString(), lblItemSequence.Text);
            gvSchedule.DataSource = schedules;
            gvSchedule.DataBind();
        }
     }

     protected void gvSchedule_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             Label lblAcknowledgeDate = (Label)e.Row.FindControl("lblAcknowledgeDate");
             //UserControls_DatePicker dtAcknowledgeDate = (UserControls_DatePicker)e.Row.FindControl("dtAcknowledgeDate");

             string strAcknowledgementDate = lblAcknowledgeDate.Text;
             if (!string.IsNullOrEmpty(strAcknowledgementDate)) 
             {
                 DateTime dtAcknowledgementDate = GetDateTimeFormStoredValue(Convert.ToInt64(strAcknowledgementDate));
                 lblAcknowledgeDate.Text = GetShortDate(dtAcknowledgementDate);
                 //dtAcknowledgeDate.SelectedDate = dtAcknowledgementDate;
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

    

    
     protected void btnReturn_Click(object sender, EventArgs e)
     {
         try
         {
             string url = "~/DeliveryOrder/PurchaseOrderList.aspx?" + m_QueryString;
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {


        int i = 0;
        int cnt = 0;


        Collection<DeliveryOrder> doColl = new Collection<DeliveryOrder>();

        foreach (RepeaterItem item in gvItem.Items)
        {
            if (((CheckBox)item.FindControl("ckboxSelect")).Checked)
            {
               // this.mainController.GetUserController().UpdateUserStatus(gvData.DataKeys[i].Values[0].ToString(), "V", loginUser.UserId);

                Label lblMaterialNumber = (Label)item.FindControl("lblMaterialNumber");
                Label lblItemSequence = (Label)item.FindControl("lblItemSequence");
                Label lblOrderQuantity = (Label)item.FindControl("lblOrderQuantity");
                Label lblDeliveryQuantity = (Label)item.FindControl("lblDeliveryQuantity");

                DeliveryOrder doorder = new DeliveryOrder();

                doorder.OrderNumber = lblOrderNumber.Text.Trim();
                doorder.MaterialNumber = lblMaterialNumber.Text.Trim();
                doorder.ItemSequence = lblItemSequence.Text.Trim();

                doorder.OpenQuantity = Convert.ToDecimal(lblOrderQuantity.Text == "" ? "0" : lblOrderQuantity.Text) - Convert.ToDecimal(lblDeliveryQuantity.Text == "" ? "0" : lblDeliveryQuantity.Text);

                if (doorder.OpenQuantity > 0)
                doColl.Add(doorder);


                cnt++;
            }

            i++;

        }

        if (cnt == 0) 
        {
            plMessage.Visible = true;
            displayCustomMessage(FormatErrorMessage("Please select at least one item to create DO."), lblMessage, SystemMessageType.Error);
            return;
        }

        if (doColl.Count > 0)
        {
            Session.Add(SessionKey.DELIVERY_ORDER_COLLECTION, doColl);

            Response.Redirect("CreateDeliveryOrder.aspx");
        }
        else
        {
            plMessage.Visible = true;
            displayCustomMessage(FormatErrorMessage("The selected order items are fully deliveried."), lblMessage, SystemMessageType.Error);
        }

    }
    catch (Exception ex)
    {
        ExceptionLog(ex);

         // this.lblError.Visible = true;
        // this.lblError.Text = "Problem connecting to the server. Please contact Administrator.";
    }


        
    }
}

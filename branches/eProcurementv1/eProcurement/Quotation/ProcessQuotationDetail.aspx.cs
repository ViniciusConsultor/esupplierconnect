using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using eProcurement_DAL;
using eProcurement_BLL;
using System.Collections.ObjectModel;

public partial class Quotation_ProcessQuotationDetail : BaseForm
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

    private string m_CurrentQuotationNumber
    {
        get
        {
            if (ViewState["m_CurrentQuotationNumber"] != null && ViewState["m_CurrentQuotationNumber"].ToString() != string.Empty)
            {
                return ViewState["m_CurrentQuotationNumber"].ToString();
            }
            else
            {
                return "";
            }
        }
        set
        {
            ViewState["m_CurrentQuotationNumber"] = value;
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
                //base.m_FunctionId = "B-0007";
                 
                //m_FuncFlag = "PROCESS_QUOTATION";
       
                //base.Page_Load(sender, e);
                /***************************************************/

                //Initialize Page
                //InitPage();

                //Check access right
                //if (CheckAccessRight() == false)
                //    GotoTimeOutPage();

                //store querystring in viewstate, it will be used to pass back to list page
                string queryString = Request.QueryString.ToString();
                m_QueryString = queryString + "&ReturnFromDetails=Y";

                InitQuotationHeader();
                InitItems();
                //Initialize attachment panel
                InitAttachmentPanel();
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

    private void InitAttachmentPanel()
    {
        try
        {
            attPanel.InitPanel(Session[SessionKey.RequestNumber].ToString(), false);
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    

   private void InitQuotationHeader()
    {
        QuotationHeader qHeader = new QuotationHeader();
        qHeader = mainController.GetDAOCreator().CreateQuotationHeaderDAO().RetrieveByKey(Session[SessionKey.RequestNumber].ToString());
   

        if (qHeader == null)
        {
            throw new Exception("Invalid Request Number.");
        }

        Supplier supplier = mainController.GetSupplierController().GetSupplier(qHeader.SupplierId.ToString () );

        lblSupplierId.Text = qHeader.SupplierId;
        lblSupplierName.Text = supplier.SupplierName;
        lblSupplierAddress.Text = supplier.SupplierAddress;
        lblPostalCode.Text = "Singapore " + supplier.PostalCode;
        lblCountry.Text = supplier.CountryCode;

        //lblShipmentAddress.Text = "";

        lblRequestNumber.Text = qHeader.RequestNumber;
        if (qHeader.ExpiryDate.HasValue)
           lblRFQExpDate.Text = GetShortDate(GetDateTimeFormStoredValue(qHeader.ExpiryDate.Value));
        else
           lblRFQExpDate.Text = "";

        //for attachment

       
    }
    
    private void InitItems()
    {
        string whereClause = " EBELN = '" + Session[SessionKey.RequestNumber].ToString() + "'";
        Collection<QuotationItem> items = mainController.GetDAOCreator().CreateQuotationItemDAO().RetrieveByQuery(whereClause);    
        gvItem.DataSource = items;
        gvItem.DataBind();
        lblCount.Text = items.Count.ToString() + " Record(s) was found.";
        if (items.Count > 0)
        {
            plResult.Visible = true;
            btnReturn.Visible = true;
            btnSubmit.Visible = true;
        }

    }
              
    protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblReqSeq = (Label)e.Row.FindControl("lblReqSeq");
            Label lblMaterialNo = (Label)e.Row.FindControl("lblMaterialNumber");
            Label lblPlant = (Label)e.Row.FindControl("lblPlant");
            Label lblRequiredQuantity = (Label)e.Row.FindControl("lblReqQty");
            Label lblRQUnitMeasure = (Label)e.Row.FindControl("lblReqUOM");
            Label lblNetValue = (Label)e.Row.FindControl("lblNetValue");
            TextBox txtSupQty = (TextBox)e.Row.FindControl("txtSupQty");
            TextBox txtSupUOM = (TextBox)e.Row.FindControl("txtSupUOM");
            TextBox txtNetPrice = (TextBox)e.Row.FindControl("txtNetPrice");
            TextBox txtUnitPrice = (TextBox)e.Row.FindControl("txtUnitPrice");
            
            ////CalculateNetPrice
            //lblNetValue.Text = "javascript:CalculateNetPrice(" + txtNetPrice.Text + "," + txtUnitPrice.Text + " ," + txtSupQty.Text + ")";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
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

            EpTransaction tran = DataManager.BeginTransaction();
            try
            {
                QuotationHeader header = new QuotationHeader();
                header = mainController.GetDAOCreator().CreateQuotationHeaderDAO().RetrieveByKey(tran, lblRequestNumber.Text.ToString());


                //Check whether the order has already been acknowledged 
                if (string.Compare(header.RecordStatus, QuotationStatus.Acknowledge, true) == 0)
                {
                    throw new Exception("The quotation has already been processed by other user.");
                }

                //Update Order header
                header.RecordStatus = QuotationStatus.Acknowledge;
                header.QuotationNumber = txtQuotationNo.Text;
                header.QuotationDate = GetStoredDateValue(dtpQuotationDate.SelectedDate);
                header.QuotationExpiryDate = GetStoredDateValue(dtpExpiryDate.SelectedDate);
                mainController.GetDAOCreator().CreateQuotationHeaderDAO().Update(tran,header);

                //Collection<QuotationItem> qItems = new Collection<QuotationItem>();

                foreach (GridViewRow rowItem in gvItem.Rows)
                {
                    Label lblItemNo = (Label)rowItem.FindControl("lblReqSeq");
                    //GridView gvSchedule = (GridView)rowItem.FindControl("gvSchedule");
                    QuotationItem item = new QuotationItem();
                    item = mainController.GetDAOCreator().CreateQuotationItemDAO().RetrieveByKey(lblRequestNumber.Text, lblItemNo.Text);

                    Label lblNetValue = (Label)rowItem.FindControl("lblNetValue");
                    TextBox txtSupQty = (TextBox)rowItem.FindControl("txtSupQty");
                    TextBox txtSupUOM = (TextBox)rowItem.FindControl("txtSupUOM");
                    TextBox txtNetPrice = (TextBox)rowItem.FindControl("txtNetPrice");
                    TextBox txtUnitPrice = (TextBox)rowItem.FindControl("txtUnitPrice");

                    item.SupplyQuantity = Convert.ToDecimal(txtSupQty.Text);
                    item.SupplyUnitMeasure = txtSupUOM.Text;
                    item.PriceUnit = Convert.ToDecimal(txtUnitPrice.Text);
                    item.NetPrice = Convert.ToDecimal(txtNetPrice.Text);
                    item.NetValue = Convert.ToDecimal(lblNetValue.Text);
                    item.RecordStatus = QuotationStatus.Acknowledge;
                    mainController.GetDAOCreator().CreateQuotationItemDAO().Update(tran, item);
                }

                //Send Notificatio
                //Collection<string> buyerEmailList = new Collection<string>();
                //User user = mainController.GetDAOCreator().CreateUserDAO().RetrieveByKey(header.BuyerID);
                //if (user != null)
                //{
                //    if (!string.IsNullOrEmpty(user.UserEmail))
                //    {
                //        buyerEmailList.Add(user.UserEmail);
                //    }
                //}

                //if (buyerEmailList.Count == 0)
                //    buyerEmailList.Add(NotificationMessage.buyerEmail);
                //foreach (string email in buyerEmailList)
                //{
                //    eProcurement_DAL.Notification notification = new eProcurement_DAL.Notification();
                //    notification.NotificationType = NotificationMessage.RFQUpdate;
                //    notification.NotificationDate = Utility.GetStoredDateValue(DateTime.Now);
                //    notification.ReferenceNumber = header.RequestNumber;
                //    notification.ReferenceSequence = "";

                //    string sDate = "";
                //    if (header.QuotationExpiryDate.HasValue)
                //        sDate = Utility.GetShortDate(Utility.GetDateTimeFormStoredValue(header.QuotationExpiryDate.Value));
                //    notification.Message = string.Format("Request for Quotation:{0} Dated: {1} created please provide your quotation.",
                //          header.RequestNumber, sDate);

                //    notification.Sender = header.SupplierId;
                //    notification.Recipient = NotificationMessage.buyerRecepient;
                //    notification.Email = email.Trim();
                //    notification.Status = "0";
                //    mainController.GetNotificationController().InsertEmailNotification(tran, notification);
                //}

                tran.Commit();
                plMessage.Visible = true;
                lblMessage.Visible = true;
                string sMessage = "Quotation has been processed successfully.";
                displayCustomMessage(sMessage, lblMessage, SystemMessageType.Information);
                btnSubmit.Enabled = false;
                attPanel.InitPanel(Session[SessionKey.RequestNumber].ToString(), true);
                txtQuotationNo.ReadOnly = true;
                btnPrint.Enabled = true;
                btnPrint.Attributes.Add("onclick", "PrintReport()");
                Session[SessionKey.QuotationNumber] = txtQuotationNo.Text;

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw (ex);
            }
            finally
            {
                tran.Dispose();
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

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        try
        {
            string url = "~/Quotation/ProcessQuotationList.aspx?FunctionId=S-0010";
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

    protected void TextChangedEvent(object sender, EventArgs e)
    {
         try
        {
            TextBox txtNPrice = (TextBox)sender;
            GridViewRow gvItem = (GridViewRow)txtNPrice.Parent.Parent;
            int row = gvItem.RowIndex;
            
            //rowChanged[row] = true;
            Label lblNetValue = (Label)gvItem.FindControl("lblNetValue");
            TextBox txtSupQty = (TextBox)gvItem.FindControl("txtSupQty");
            TextBox txtNetPrice = (TextBox)gvItem.FindControl("txtNetPrice");
            TextBox txtUnitPrice = (TextBox)gvItem.FindControl("txtUnitPrice");


            //Net Value	((net price / unit price) * supply qty =net value)
            decimal NetValue;
            string NValue;
            NetValue  =(Convert.ToDecimal(txtNetPrice.Text) / Convert.ToDecimal(txtUnitPrice.Text)) * Convert.ToDecimal(txtSupQty.Text);
            //Convert.ToDouble(NetValue);

            NetValue = decimal.Parse(NetValue.ToString("####0.00"));

            //NValue = Convert.ToString(NetValue);
            //lblNetValue.Text = string.Format("{###0.00}", NValue);
            lblNetValue.Text = NetValue.ToString();
            //((Label)gvItem.FindControl("lblNetValue")).Text = NValue;
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
        bool bIsValidExp = true;

        if (dtpQuotationDate.Text != "")
        {
            if (!dtpQuotationDate.IsValidDate)
            {
                bIsValid = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Quotation Date."));
            }
        }

        if (dtpExpiryDate.Text != "")
        {
            if (!dtpExpiryDate.IsValidDate)
            {
                bIsValidExp = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Expiry Date."));
            }
        }
               
        if ((!bIsValid) || (!bIsValidExp))
        {
            return strErrorMsg.ToString();
        }

        if (dtpQuotationDate.SelectedDateString != "" && dtpExpiryDate.SelectedDateString != "")
        {
            DateTime dtQDate = dtpQuotationDate.SelectedDate;
            DateTime dtEDate = dtpExpiryDate.SelectedDate;

            if (dtQDate.CompareTo(dtEDate) > 0) //quotation date - expiry date (0=equal, 1=greater, -1=smaller)
            {
                strErrorMsg.Append(MakeListItem("Expiry Date must be equal or greater than Quotation Date."));
                return strErrorMsg.ToString();
            }
        }
                
        return strErrorMsg.ToString();
    }
    #endregion
  
}

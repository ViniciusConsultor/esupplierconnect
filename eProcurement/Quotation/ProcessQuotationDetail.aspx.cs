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
                base.m_FunctionId = "B-0007";
                 
                m_FuncFlag = "PROCESS_QUOTATION";
       
                //base.Page_Load(sender, e);
                /***************************************************/

                //Initialize Page
                InitPage();

                //Check access right
                if (CheckAccessRight() == false)
                    GotoTimeOutPage();

                //store querystring in viewstate, it will be used to pass back to list page
                string queryString = Request.QueryString.ToString();
                m_QueryString = queryString + "&ReturnFromDetails=Y";

                InitQuotationHeader();
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
            if (string.Compare(m_FuncFlag, "PROCESS_QUOTATION", false) == 0)
            {
                lblSubPath.Text = "Process Quotation";
                btnSubmit.Visible = true;
                btnReturn.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    private bool CheckAccessRight()
    {
        if (string.Compare(m_FuncFlag, "PROCESS_QUOTATION", false) == 0)
        {

        }
        return true;
    }

    private void InitQuotationHeader()
    {
        Collection<QuotationHeader> qHeaders = new Collection<QuotationHeader>();

        qHeaders = mainController.GetQuotationController().GetQuotationHeader(lblQuotationNo.Text.ToString ()  );

        QuotationHeader qHeader = new QuotationHeader();
        if (qHeaders.Count > 0 ){}

        qHeader=qHeaders[0];

        if (qHeader == null)
        {
            throw new Exception("Invalid Quotation Number.");
        }

        Supplier supplier = mainController.GetSupplierController().GetSupplier(qHeader.SupplierId.ToString () );

        lblSupplierId.Text = qHeader.SupplierId;
        lblSupplierName.Text = supplier.SupplierName;
        lblSupplierAddress.Text = supplier.SupplierAddress;
        lblPostalCode.Text = "Singapore " + supplier.PostalCode;
        lblCountry.Text = supplier.CountryCode;

        lblShipmentAddress.Text = "";

        lblRequestNumber.Text = qHeader.RequestNumber;
        //lblRFQDate.Text=""
        lblQuotationNo.Text = qHeader.QuotationNumber;
        if (qHeader.QuotationDate.HasValue)
            lblQuotationDate.Text = GetShortDate(GetDateTimeFormStoredValue(qHeader.QuotationDate.Value));
        else
            lblQuotationDate.Text = "";
        if (qHeader.ExpiryDate.HasValue)
            lbExpiryDate.Text = GetShortDate(GetDateTimeFormStoredValue(qHeader.ExpiryDate.Value));
        else
            lbExpiryDate.Text = "";
        //for attachment
       
    }

    private void InitItems()
    {
        string whereClause = " ANGNR = '" + lblQuotationNo.Text + "'";
        Collection<QuotationItem> items = mainController.GetDAOCreator().CreateQuotationItemDAO().RetrieveByQuery(whereClause);    
        gvItem.DataSource = items;
        gvItem.DataBind();

    }
    protected void gvItem_ItemDataBound(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //GridView gvSchedule = (GridView)e.Item.FindControl("gvSchedule");
            Label lblMaterialNo = (Label)e.Item.FindControl("lblMaterialNumber");
            Label lblPlant = (Label)e.Item.FindControl("lblPlant");
            Label lblRequiredQuantity = (Label)e.Item.FindControl("lblRequiredQuantity");
            Label lblRQUnitMeasure = (Label)e.Item.FindControl("lblRQUnitMeasure");
            Label lblSupplyQuantity = (Label)e.Item.FindControl("lblSupplyQuantity");
            Label lblSQUnitMeasure = (Label)e.Item.FindControl("lblSQUnitMeasure");
            Label lblPriceUnit = (Label)e.Item.FindControl("lblPriceUnit");
            Label lblNetPrice = (Label)e.Item.FindControl("lblNetPrice");
            Label lblNetAmount = (Label)e.Item.FindControl("lblNetAmount");
            decimal amount = Convert.ToDecimal(lblPriceUnit.Text) * Convert.ToDecimal(lblNetPrice.Text);
            lblNetAmount.Text = amount.ToString();

            //HyperLink hlItemText = (HyperLink)e.Item.FindControl("hlItemText");
            //HyperLink hlComponent = (HyperLink)e.Item.FindControl("hlComponent");
            //HyperLink hlService = (HyperLink)e.Item.FindControl("hlService");

            //hlItemText.NavigateUrl = "javascript:ShowItemText('" + lblItemSequence.Text + "')";
            //hlComponent.NavigateUrl = "javascript:ShowComponent('" + lblItemSequence.Text + "')";
            //hlService.NavigateUrl = "javascript:ShowService('" + lblItemSequence.Text + "')";

            //Collection<PurchaseOrderItemSchedule> schedules = mainController.GetOrderItemController()
            //    .GetPurchaseOrderItemSchedules(Session[SessionKey.OrderNumber].ToString(), lblItemSequence.Text);
            //gvSchedule.DataSource = schedules;
            //gvSchedule.DataBind();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            EpTransaction tran = DataManager.BeginTransaction();
            try
            {
                QuotationHeader header = new QuotationHeader();
                header = mainController.GetDAOCreator().CreateQuotationHeaderDAO().RetrieveByKey(tran, lblRequestNumber.Text.ToString());                


                //Check whether the order has already been acknowledged 
                if (string.Compare(header.RecordStatus, QuotationStatus.Acknowledge, true) == 0)
                {
                    throw new Exception("The quotation has already been acknowledged by other user.");
                }

                //Update Order header
                header.RecordStatus  = QuotationStatus.Acknowledge ;
                //header.AcknowledgeBy = mainController.GetLoginUserVO().UserId;
                mainController.GetDAOCreator().CreateQuotationHeaderDAO().Update(header);

                //Update Order Item
                /*foreach (PurchaseOrderItemSchedule schedule in schedules)
                {
                    scheduleSeq = schedule.PurchaseOrderScheduleSequence;

                    //Update Order Item
                    if (string.Compare(itemSeq, schedule.PurchaseOrderItemSequence, false) != 0)
                    {
                        PurchaseOrderItem item = mainController.GetDAOCreator().CreatePurchaseOrderItemDAO()
                            .RetrieveByKey(tran, orderNumber, schedule.PurchaseOrderItemSequence);
                        item.AcknowledgementStatus = POAckStatus.Yes;
                        mainController.GetDAOCreator().CreatePurchaseOrderItemDAO().Update(tran, item);
                        itemSeq = schedule.PurchaseOrderItemSequence;
                    }

                    //Update Order Item Schedule
                    scheduleSeq = schedule.PurchaseOrderScheduleSequence;
                    PurchaseOrderItemSchedule scheduleUpdt = mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO()
                        .RetrieveByKey(tran, orderNumber, schedule.PurchaseOrderItemSequence, scheduleSeq);
                    scheduleUpdt.AcknowledgementDate = schedule.AcknowledgementDate;
                    mainController.GetDAOCreator().CreatePurchaseOrderItemScheduleDAO()
                        .Update(tran, scheduleUpdt);

                }*/
                //tran.Commit();
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
            Utility.ExceptionLog(ex);
            throw (ex);
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


}

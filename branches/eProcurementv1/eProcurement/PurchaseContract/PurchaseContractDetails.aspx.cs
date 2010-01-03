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

public partial class PurchaseContract_PurchaseContractDetails : BaseForm
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
    private string m_CurrentContractNumber
    {
        get
        {
            if (ViewState["m_CurrentContractNumber"] != null && ViewState["m_CurrentContractNumber"].ToString() != string.Empty)
            {
                return ViewState["m_CurrentContractNumber"].ToString();
            }
            else
            {
                return "";
            }
        }
        set
        {
            ViewState["m_CurrentContractNumber"] = value;
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
                base.m_FunctionIdColl.Add("S-0007");
                base.m_FunctionIdColl.Add("S-0008");
                base.m_FunctionIdColl.Add("B-0005");

                string functionId = Request.QueryString["FunctionId"];
                if (string.IsNullOrEmpty(functionId))
                {
                    throw new Exception("Invalid Function Id.");
                }
                else
                {
                    base.m_FunctionId = functionId;
                    if (string.Compare(functionId, "S-0007", true) == 0)
                    {
                        m_FuncFlag = "ACK_CONTRACT";
                    }
                    if (string.Compare(functionId, "S-0008", true) == 0)
                    {
                        m_FuncFlag = "VIEW_CONTRACT";
                    }
                    if (string.Compare(functionId, "B-0005", true) == 0)
                    {
                        m_FuncFlag = "VIEW_CONTRACT";
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

                InitContractHeader();
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
            if (string.Compare(m_FuncFlag, "ACK_CONTRACT", false) == 0)
            {
                lblSubPath.Text = "Acknowledge Contract";
                //btnReject.Visible = false;
                //btnAccept.Visible = false;
            }

            //if (string.Compare(m_FuncFlag, "VIEW_ORDER_BUYER", false) == 0)
            //{
            //    lblSubPath.Text = "Acknowledge Order by Buyer";
            //    btnReject.Visible = false;
            //    btnAccept.Visible = false;
            //}

            if (string.Compare(m_FuncFlag, "VIEW_CONTRACT", false) == 0)
            {
                lblSubPath.Text = "View Contract Details";
                btnAcknowledge.Visible = false;
                //btnReject.Visible = false;
                //btnAccept.Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    private bool CheckAccessRight()
    {
        if (string.Compare(m_FuncFlag, "ACK_CONTRACT", false) == 0)
        {

        }

        return true;
    }
    private void InitContractHeader()
    {
        ContractHeader pcHeader = mainController.GetPurchaseContractController().
            GetContractHeader(Session[SessionKey.ContractNumber].ToString());
        if (pcHeader == null)
        {
            throw new Exception("Invalid Contract Number.");
        }

        Supplier supplier = mainController.GetSupplierController().GetSupplier(pcHeader.SupplierId);

        lblSupplierName.Text = supplier.SupplierName;
        lblSupplierAddress.Text = supplier.SupplierAddress;
        lblPostalCode.Text = "Singapore " + supplier.PostalCode;
        lblCountry.Text = supplier.CountryCode;

        lblShipmentAddress.Text = pcHeader.ShipmentAddress;

        lblContractNumber.Text = pcHeader.ContractNumber;
        if (pcHeader.ContractDate.HasValue)
            lblContractDate.Text = GetShortDate(GetDateTimeFormStoredValue(pcHeader.ContractDate.Value));
        else
            lblContractDate.Text = "";
        lblSupplierId.Text = pcHeader.SupplierId;
        lblContractCat.Text = pcHeader.ContractCategory;
        lblContractType.Text = pcHeader.DocumentType;
        lblPayment.Text = pcHeader.PaymentTerms;
        lblPurchaseGrp.Text = pcHeader.PurchasingGroup;
        lblCurrencyId.Text = pcHeader.Currency;
        lblExchangeRate.Text = pcHeader.ExchangeRate.ToString();
        if (pcHeader.ValidityStart.HasValue)
            lblValidStart.Text = GetShortDate(GetDateTimeFormStoredValue(pcHeader.ValidityStart.Value));
        else
            lblValidStart.Text = "";
        if (pcHeader.ValidityEnd.HasValue)
            lblValidEnd.Text = GetShortDate(GetDateTimeFormStoredValue(pcHeader.ValidityEnd.Value));
        else
            lblValidEnd.Text = "";
        //lblGSTAmount.Text = pcHeader.GstAmount.ToString();        
        lblContactPerson.Text = pcHeader.SalesContactPerson;
        lblTelephone.Text = pcHeader.Telephone;
        lblContractValue.Text = pcHeader.ContractValue.ToString();
        lblInternalRef.Text = pcHeader.InternalReference;
        //lblReRemarks.Text = poHeader.Remarks;
        //hlHeaderText.NavigateUrl = "javascript:ShowHeaderText()";
    }

    private void InitItems()
    {
        Collection<ContractItem> items = mainController.GetPurchaseContractController()
            .GetPurchaseContractItems(Session[SessionKey.ContractNumber].ToString());
        gvItem.DataSource = items;
        gvItem.DataBind();

    }
    protected void gvItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    GridView gvSchedule = (GridView)e.Item.FindControl("gvSchedule");
        //    Collection<PurchaseExpediting> schedules = new Collection<PurchaseExpediting>();
        //    int iCount = 2;
        //    for (int i = 1; i <= iCount; i++)
        //    {
        //        PurchaseExpediting obj = new PurchaseExpediting();
        //        obj.OrderNumber = "000000000" + i;
        //        obj.ItemSequence = "000" + i;
        //        obj.ScheduleSequence = "0" + i;
        //        schedules.Add(obj);
        //    }
        //    gvSchedule.DataSource = schedules;
        //    gvSchedule.DataBind();
        //}
    }
    protected void btnAcknowledge_Click(object sender, EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();

            //string strErrorMsg = ValidateInput();

            if (!string.IsNullOrEmpty(strErrorMsg.ToString()))
            {
                plMessage.Visible = true;
                displayCustomMessage(FormatErrorMessage(strErrorMsg.ToString()), lblMessage, SystemMessageType.Error);
                return;
            }

            if (string.Compare(m_FuncFlag, "ACK_CONTRACT", false) == 0)
            {
                mainController.GetPurchaseContractController().AcknowledgePurchaseContract(ContractHeader);
            }

            btnAcknowledge.Enabled = false;
            plMessage.Visible = true;
            string sMessage = "Purchase Contract has been acknowledged successfully.";
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
            string url = "~/PurchaseContract/PurchaseContractList.aspx?" + m_QueryString;
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

}
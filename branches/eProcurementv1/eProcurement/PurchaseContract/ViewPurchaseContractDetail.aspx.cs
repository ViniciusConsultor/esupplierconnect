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

public partial class PurchaseContract_ViewPurchaseContractDetail :BaseForm 
{
    private MainController mainController = null;

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
                }
                base.Page_Load(sender, e);
                /***************************************************/

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

    private void InitContractHeader()
    {
        ContractHeader contractHeader = mainController.GetPurchaseContractController()
            .GetContractHeader( Session[SessionKey.ContractNumber].ToString());
        if (contractHeader == null)
        {
            throw new Exception("Invalid Contract Number.");
        }

        Supplier supplier = mainController.GetSupplierController().GetSupplier(contractHeader.SupplierId);

        lblSupplierName.Text = supplier.SupplierName;
        lblSupplierAddress.Text = supplier.SupplierAddress;
        lblPostalCode.Text = "Singapore " + supplier.PostalCode;
        lblCountry.Text = supplier.CountryCode;

        //lblShipmentAddress.Text = supplier.ShipmentAddress;

        lblContractNumber.Text = contractHeader.ContractNumber;
        if (contractHeader.ContractDate.HasValue)
            lblContractDate.Text = GetShortDate(GetDateTimeFormStoredValue(contractHeader.ContractDate.Value));
        else
            lblContractDate.Text = "";
        lblSupplierId.Text = contractHeader.SupplierId;
        lblContractCategory.Text = contractHeader.ContractCategory;
        lblContractType.Text = contractHeader.DocumentType;
        lblpaymentTerm.Text = contractHeader.PaymentTerms;
        lblPurchasingGroup.Text = contractHeader.PurchasingGroup;
        lblCurrency.Text = contractHeader.Currency;
        lblExchangeRate.Text = contractHeader.ExchangeRate.ToString();
        if (contractHeader.ValidityStart.HasValue)
            lblValidityStart.Text = GetShortDate(GetDateTimeFormStoredValue(contractHeader.ValidityStart.Value));
        else
            lblValidityStart.Text = "";
        if (contractHeader.ValidityEnd.HasValue)
            lblValidityEnd.Text = GetShortDate(GetDateTimeFormStoredValue(contractHeader.ValidityEnd.Value));
        else
            lblValidityEnd.Text = "";
        lblContractPerson.Text = contractHeader.SalesContactPerson;
        lblTelephone.Text = contractHeader.Telephone;
        lblContractValue.Text = contractHeader.ContractValue.ToString() ;
        lblInternalReference.Text = contractHeader.InternalReference;
    }

    private void InitItems()
    {
        Collection<ContractItem> items = mainController.GetPurchaseContractController()
            .GetPurchaseContractItems(Session[SessionKey.ContractNumber].ToString());
        gvData.DataSource = items;
        gvData.DataBind();

    }

    protected void gvData_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
       
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        try
        {
            string url = "~/PurchaseContract/EnquiryPurchaseContractList.aspx?" + m_QueryString;
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

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

public partial class PurchaseOrder_PurchaseOrderHeaderText : BaseForm
{
    private MainController mainController = null;
    
    new protected void Page_Load(object sender, EventArgs e)
    {
        //Instantiate MainController
        this.mainController = new MainController(base.LoginUser);

        try
        {
            plMessage.Visible = false;
            lblMessage.Text = string.Empty;
            if (!IsPostBack)
            {
                InitPOHeader();
                InitHeaderText();
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
    }

    private void InitHeaderText()
    {
        string whereClause = " EBELN='" + Session[SessionKey.OrderNumber].ToString() + "' ";
        whereClause += " AND isnull(RECSTS,'')<>'D' ";
        string orderClause = " TXTITM asc ";
        Collection<PurchaseHeaderText> texts = mainController.GetOrderHeaderController()
            .GetPurchaseOrderHeaderText(Session[SessionKey.OrderNumber].ToString());
        gvData.DataSource = texts;
        gvData.DataBind();
    }
}

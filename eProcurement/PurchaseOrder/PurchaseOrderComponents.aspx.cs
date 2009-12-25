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

public partial class PurchaseOrder_PurchaseOrderComponents : BaseForm
{
    private MainController mainController = null;

    private string m_ItemSeq
    {
        get
        {
            if (ViewState["m_ItemSeq"] != null && ViewState["m_ItemSeq"].ToString() != string.Empty)
            {
                return ViewState["m_ItemSeq"].ToString();
            }
            else
            {
                return "";
            }
        }
        set
        {
            ViewState["m_ItemSeq"] = value;
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
                m_ItemSeq = Request.QueryString["ItemNo"];
                if (string.IsNullOrEmpty(m_ItemSeq))
                {
                    throw new Exception("Invalid Order Item Sequence Number.");
                }

                InitPOHeader();
                InitItem();
                InitItemComponents();
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

    private void InitItem()
    {
        PurchaseOrderItem item = mainController.GetOrderItemController()
            .GetPurchaseOrderItem(Session[SessionKey.OrderNumber].ToString(), m_ItemSeq); 
        if (item == null)
        {
            throw new Exception("Invalid Order Item Sequence Number.");
        }
        Collection<PurchaseOrderItem> items = new Collection<PurchaseOrderItem>();
        items.Add(item);
        gvItem.DataSource = items;
        gvItem.DataBind();

    }

    private void InitItemComponents()
    {
        Collection<SubcontractorMaterial> subMaterials = mainController.GetOrderItemController()
            .GetPurchaseOrderSubcontractComponents(Session[SessionKey.OrderNumber].ToString(), m_ItemSeq);
        gvData.DataSource = subMaterials;
        gvData.DataBind();
    }
}

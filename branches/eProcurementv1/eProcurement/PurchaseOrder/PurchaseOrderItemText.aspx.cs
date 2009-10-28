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

public partial class PurchaseOrder_PurchaseOrderItemText : BaseForm
{
    new protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            plMessage.Visible = false;
            lblMessage.Text = string.Empty;
            if (!IsPostBack)
            {
                PurchaseOrderHeader poHeader = new PurchaseOrderHeader();
                poHeader.OrderNumber = "0000000001";
                poHeader.SupplierId = "Supplier 1";
                poHeader.OrderDate = GetStoredDateValue(DateTime.Now);
                poHeader.OrderAmount = 1000;
                poHeader.GstAmount = Convert.ToDecimal(1000 * 0.07);
                poHeader.CurrencyCode = "SGD";
                poHeader.PaymentTerms = "PaymentTerms 1";
                poHeader.BuyerName = "BuyerName 1";
                poHeader.SalesPerson = "SalesPerson 1";
                poHeader.ShipmentAddress = "Fujitec Singapore Corpn, Ltd. 204 Bedok South Avenue 1 Singapore 469333";
                poHeader.Remarks = "Remarks";

                //m_Items = new Collection<PurchaseOrderItem>();
                //m_Schedules = new Collection<PurchaseOrderItemSchedule>();

                Supplier supplier = new Supplier();
                supplier.SupplierName = "CPP GLOBAL PRODUCTS P L";
                supplier.SupplierAddress = "NO.27 DEFU AVENUE 2";
                supplier.PostalCode = "539226";
                supplier.CountryCode = "Singapore";

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
                //hlHeaderText.NavigateUrl = "javascript:ShowHeaderText('" + poHeader.OrderNumber + "')";
                ShowItems();
                ShowData();
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

    private void ShowItems()
    {
        //Collection<PurchaseOrderItem> items = PurchaseOrderItemController.GetPurchaseOrderItems(m_Header.OrderNumber);
        Collection<PurchaseOrderItem> items = new Collection<PurchaseOrderItem>();
        int iCount = 1;
        for (int i = 1; i <= iCount; i++)
        {
            PurchaseOrderItem obj = new PurchaseOrderItem();

            obj.PurchaseItemSequenceNumber = "000" + i;
            obj.MaterialNumber = "M000" + i;
            obj.ShortText = "Material " + i;
            obj.OrderQuantity = 1000;
            obj.PricePerUnit = 100;
            obj.UnitofMeasure = "PCS";
            obj.NetPrice = 300;
            obj.Remarks = "Remarks XXXXX " + i;
            obj.DeliveredQuantity = 100;
            obj.LongTextDescription = "Long Text Description " + i;
            obj.StorageLocation = "Storage Location XXXXX " + i;
            items.Add(obj);
        }
        gvItem.DataSource = items;
        gvItem.DataBind();

    }

    private void ShowData()
    {
        string orderNumber = Request.QueryString["OrderNumber"];
        string itemNo = Request.QueryString["ItemNo"];
        //Collection<PurchaseOrderItemText> texts = PurchaseOrderItemController.GetPurchaseOrderItemTexts(orderNumber, itemNo);
        Collection<PurchaseItemText> objs = new Collection<PurchaseItemText>();
        int iCount = 9;
        for (int i = 1; i <= iCount; i++)
        {
            PurchaseItemText obj = new PurchaseItemText();
            obj.OrderNumber = "0000000001";
            obj.ItemSequence  = "0001";
            obj.TextSequence = "0" + i;
            obj.LongText = "Text " + i;
            objs.Add(obj);
        }

        gvData.DataSource = objs;
        gvData.DataBind();
        //if (objs.Count == 0)
        //    lblCount.Text = string.Format("{0} record(s) found. ", objs.Count.ToString());
    }

    protected void gvData_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }
}

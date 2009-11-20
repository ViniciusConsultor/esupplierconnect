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

public partial class Quotation_QuotationRequestDetails : BaseForm
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

                lblOrderNumber.Text = poHeader.OrderNumber;
                if (poHeader.OrderDate.HasValue)
                    lblExpiryDate.Text = GetShortDate(GetDateTimeFormStoredValue(poHeader.OrderDate.Value));
                else
                    lblExpiryDate.Text = "";
                lblOrderDate.Text = poHeader.SupplierId;
                lblRequestNo.Text = poHeader.OrderAmount.ToString();
                lblSupplierID.Text = poHeader.GstAmount.ToString() ;
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

    private void ShowItems()
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
}

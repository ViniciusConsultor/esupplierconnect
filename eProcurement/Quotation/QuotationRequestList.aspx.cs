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

public partial class Quotation_QuotationRequestList : BaseForm
{
    class TemVO
    {
        private string _Text1;
        public string Text1
        {
            get { return _Text1; }
            set { _Text1 = value; }
        }

        private string _Text2;
        public string Text2
        {
            get { return _Text2; }
            set { _Text2 = value; }
        }

        private string _Text3;
        public string Text3
        {
            get { return _Text3; }
            set { _Text3 = value; }
        }

        private string _Text4;
        public string Text4
        {
            get { return _Text4; }
            set { _Text4 = value; }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            plMessage.Visible = false;
            lblMessage.Text = string.Empty;
            if (!IsPostBack)
            {
              InitGrid();
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

    

    private void InitGrid()
    {
        Collection<PurchaseOrderHeader> objs = new Collection<PurchaseOrderHeader>();
        int iCount = 11;
        for (int i = 1; i <= iCount; i++)
        {
            PurchaseOrderHeader obj = new PurchaseOrderHeader();
            obj.OrderNumber = "000000000" + i;
            obj.SupplierId = "Supplier" + i;
            obj.OrderDate = GetStoredDateValue(DateTime.Now);
            obj.OrderAmount = 1000;
            obj.GstAmount = Convert.ToDecimal(1000 * 0.07);
            obj.CurrencyCode = "SGD";
            obj.PaymentTerms = "PaymentTerms" + i;
            obj.BuyerName = "BuyerName" + i;
            objs.Add(obj);
        }

        gvData.DataSource = objs;
        gvData.DataBind();
        lblCount.Text = string.Format("{0} record(s) found. ", objs.Count.ToString());
    }
}

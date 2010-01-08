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



public partial class DeliveryOrder_CreateDeliveryOrder : BaseForm
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
              
                // string functionId = Request.QueryString["FunctionId"];

                string functionId = "S-0004";
                if (string.IsNullOrEmpty(functionId))
                {
                    throw new Exception("Invalid Function Id.");
                }
                else
                {
                    base.m_FunctionId = functionId;
                    if (string.Compare(functionId, "S-0004", true) == 0)
                    {
                        m_FuncFlag = "CREATE_DELIVERYORDER_SUPPLIER";
                    }

                   


                }
                base.Page_Load(sender, e);
                /***************************************************/

                //Initialize Page
                InitPage();

            }
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            string sMessage = ex.Message;
        }

    }


    private void InitPage()
    {
        try
        {

            InitPOHeader();
            InitDataGridView();

            dtpDeliveryDate.SelectedDate = DateTime.Now;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

private void InitDataGridView()
    {

        Collection<DeliveryOrder> doColl = (Collection<DeliveryOrder>)Session["DELIVERY_ORDER_COLLECTION"];



        gvData.DataSource = doColl;
        gvData.DataBind();
 
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


    protected void btnReturn_Click(object sender, EventArgs e)
    {
        try
        {
            string url = "~/DeliveryOrder/PurchaseOrderDetail.aspx?FunctionId=" + "S-0002";
            url += "&OrderNumber=" + Session[SessionKey.OrderNumber].ToString();

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
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (validateInputs())
        {

            int i = 0;
            int cnt = 0;




            foreach (GridViewRow row in gvData.Rows)
            {
                TextBox txtDeliveryQuantity = (TextBox)row.FindControl("txtDeliveryQuantity");

                if (txtDeliveryQuantity.Text != null || txtDeliveryQuantity.Text != String.Empty)
                {

                    Label lblMaterialNumber = (Label)row.FindControl("lblMaterialNumber");
                    Label lblItemSequence = (Label)row.FindControl("lblItemSequence");
                    Label lblOpenQuantity = (Label)row.FindControl("lblOpenQuantity");

                    DeliveryOrder doorder = new DeliveryOrder();

                    doorder.DeliveryNumber = txtDeliveryNo.Text.Trim();
                    doorder.DeliveryDate = GetStoredDateValue(dtpDeliveryDate.SelectedDate);

                    doorder.OrderNumber = lblOrderNumber.Text.Trim();
                    doorder.ItemSequence = lblItemSequence.Text.Trim();
                    doorder.MaterialNumber = lblMaterialNumber.Text.Trim();
                    doorder.OpenQuantity = Convert.ToDecimal(lblOpenQuantity.Text.Trim());
                    doorder.DeliveryQuantity = Convert.ToDecimal(txtDeliveryQuantity.Text.Trim());
                    doorder.RecordStatus = "V"; // V- Void
                    doorder.SupplierID = this.mainController.GetLoginUserVO().SupplierId.ToString();


                    if (doorder.DeliveryNumber == String.Empty) lblMessage.Text = "Please enter Delivery Number.";
                    else if (!doorder.DeliveryDate.HasValue) lblMessage.Text = "Please select Delivery Date";
                    else if (doorder.OpenQuantity < doorder.DeliveryQuantity) lblMessage.Text = "Please make sure Delivery Quantity entered is less then or equal to Open Quantity";
                    else this.mainController.GetDeliveryController().InsertDeliveryOrder(doorder);

                    cnt++;
                }
                i++;
            }

            Response.Redirect("PurchaseOrderList.aspx?FunctionId=S-0004");
        }
    }

    protected bool validateInputs()
    {
        if (!(txtDeliveryNo.Text.Length > 0))
        {
            lblMessage.Text = "Please enter Delivery Order No, Thanks!";
            return false;
        }
        else
        {
            return true;
        }
    }
}

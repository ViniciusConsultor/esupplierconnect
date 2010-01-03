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

    private MainController mainController = null;

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
                base.m_FunctionIdColl.Add("B-0008");
                base.m_FunctionIdColl.Add("S-0011");

                base.Page_Load(sender, e);
                /***************************************************/

                string reqNumber = Request.QueryString["RequestNumber"];
                ViewState.Add("RequestNumber", reqNumber);

                if (reqNumber != null)
                    GetQuotation();
                else
                    throw new Exception("Invalid Quotation");

                attPanel.InitPanel(reqNumber, true);
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
            string url = "~/Quotation/QuotationRequestList.aspx";
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

    #region Private Methods

    private void GetQuotation()
    {
        try
        {
            string reqNumber = Convert.ToString(ViewState["RequestNumber"]);
            QuotationHeader quoHeader = this.mainController.GetDAOCreator().CreateQuotationHeaderDAO().RetrieveByKey(reqNumber);
            
            if (quoHeader != null)
            {
                lblRequestNo.Text = quoHeader.RequestNumber.ToString();
                lblQuotationNumber.Text = quoHeader.QuotationNumber.ToString();
                lblQuotationDate.Text = GetShortDate(GetDateTimeFormStoredValue(quoHeader.QuotationDate.Value));
                lblExpiryDate.Text = GetShortDate(GetDateTimeFormStoredValue(quoHeader.ExpiryDate.Value));
                lblSupplierID.Text = quoHeader.SupplierId;
            }

            Collection<QuotationItem> quoItem = this.mainController.GetDAOCreator().CreateQuotationItemDAO().RetrieveByQuery(" EBELN='" + reqNumber + "' ", " EBELP ");
            gvItem.DataSource = quoItem;
            gvItem.DataBind();

        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            string sMessage = ex.Message;
            displayCustomMessage(sMessage, lblMessage, SystemMessageType.Error);
        }
    }

    #endregion
}

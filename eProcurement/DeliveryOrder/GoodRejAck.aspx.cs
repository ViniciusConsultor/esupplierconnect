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

public partial class DeliveryOrder_GoodRejAck : BaseForm
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
    //Store Search Criteria 
    [Serializable]
    private class SearchCriteriaVO
    {
        public string OrderNumber;
        public string ItemSequence;
        public string DocumentNumber;
        public string MaterialNumber;
    }

    private string m_CurrentOrderNumber
    {
        get
        {
            if (ViewState["m_CurrentOrderNumber"] != null && ViewState["m_CurrentOrderNumber"].ToString() != string.Empty)
            {
                return ViewState["m_CurrentOrderNumber"].ToString();
            }
            else
            {
                return "";
            }
        }
        set
        {
            ViewState["m_CurrentOrderNumber"] = value;
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
                base.m_FunctionIdColl.Add("S-0015");
                //base.m_FunctionIdColl.Add("B-0001");

                string functionId = Request.QueryString["FunctionId"];
                if (string.IsNullOrEmpty(functionId))
                {
                    throw new Exception("Invalid Function Id.");
                }
                else
                {
                    base.m_FunctionId = functionId;
                    if (string.Compare(functionId, "S-0015", true) == 0)
                    {
                        m_FuncFlag = "ACK_REC_REJECTED_GOODS";
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

                InitRejectedGood();
                //InitItems();
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
            if (string.Compare(m_FuncFlag, "ACK_REC_REJECTED_GOODS", false) == 0)
            {
                lblSubPath.Text = "Acknowledge Receipt Rejected Goods";
                btnAcknowledge.Visible = true;
                btnReturn.Visible  = true;
            }

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    private bool CheckAccessRight()
    {
        if (string.Compare(m_FuncFlag, "ACK_REC_REJECTED_GOODS", false) == 0)
        {

        }
               
        return true;
    }

    private void InitRejectedGood()
    {
        RejectedGood rejGood = mainController.GetDeliveryController().
            GetRejectedGood(txtOrderNo.ToString(), ddlItemSequence.ToString(),ddlMaterialNo.ToString());
        if (rejGood == null)
        {
            throw new Exception("Invalid Order Number.");
        }
        gvItem.DataSource = rejGood;
        gvItem.DataBind();
        //Supplier supplier = mainController.GetSupplierController().GetSupplier(poHeader.SupplierId);

        //lblSupplierName.Text = supplier.SupplierName;
        //lblSupplierAddress.Text = supplier.SupplierAddress;
        //lblPostalCode.Text = "Singapore " + supplier.PostalCode;
        //lblCountry.Text = supplier.CountryCode;

        //lblShipmentAddress.Text = poHeader.ShipmentAddress;

        //lblOrderNumber.Text = poHeader.OrderNumber;
        //if (poHeader.OrderDate.HasValue)
        //    lblOrderDate.Text = GetShortDate(GetDateTimeFormStoredValue(poHeader.OrderDate.Value));
        //else
        //    lblOrderDate.Text = "";
        //lblSupplierId.Text = poHeader.SupplierId;
        //lblOrderAmount.Text = poHeader.OrderAmount.ToString();
        //lblGSTAmount.Text = poHeader.GstAmount.ToString();
        //lblCurrency.Text = poHeader.CurrencyCode;
        //lblPaymentTerm.Text = poHeader.PaymentTerms;
        //lblBuyer.Text = poHeader.BuyerName;
        //lblSalePerson.Text = poHeader.SalesPerson;
        //lblRemarks.Text = poHeader.Remarks;
        //hlHeaderText.NavigateUrl = "javascript:ShowHeaderText()";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
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

            StoreSearchCriteria();
            ShowData();
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            displayCustomMessage(ex.Message, lblMessage, SystemMessageType.Error);
        }
    }

    private void StoreSearchCriteria()
    {
        SearchCriteriaVO searchCriteriaVO = new SearchCriteriaVO();
        searchCriteriaVO.OrderNumber = txtOrderNo.Text.Trim();
        searchCriteriaVO.ItemSequence = ddlItemSequence.SelectedValue;
        searchCriteriaVO.DocumentNumber = ddlDocumentNo.SelectedValue;
        searchCriteriaVO.MaterialNumber = ddlMaterialNo.SelectedValue;
        m_SearchCriteriaVO = searchCriteriaVO;
    }

    //Store Search Criteria 
    private SearchCriteriaVO m_SearchCriteriaVO
    {
        get
        {
            if (ViewState["m_SearchCriteriaVO"] != null)
            {
                return (SearchCriteriaVO)ViewState["m_SearchCriteriaVO"];
            }
            else
            {
                return null;
            }
        }
        set
        {
            ViewState["m_SearchCriteriaVO"] = value;
        }
    }

    private void ShowData()
    {
        Collection<RejectedGood> rgColl = GetData();
        gvItem.DataSource = rgColl;
        gvItem.DataBind();
        lblCount.Text = string.Format("{0} record(s) found. ", rgColl.Count.ToString());
    }

    private Collection<RejectedGood> GetData()
    {
        Collection<RejectedGood> rgColl = new Collection<RejectedGood>();
        if (string.Compare(m_FuncFlag, "ACK_REC_REJECTED_GOODS", false) == 0)
        {
            rgColl  = mainController.GetDeliveryController().GetRejectedGood
           (m_SearchCriteriaVO.OrderNumber, m_SearchCriteriaVO.ItemSequence, m_SearchCriteriaVO.DocumentNumber, m_SearchCriteriaVO.MaterialNumber);
        }

       return rgColl;
    }

    protected void gvItem_ItemDataBound(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //GridView gvSchedule = (GridView)e.Item.FindControl("gvSchedule");
            //Collection<PurchaseOrderItemSchedule> schedules = new Collection<PurchaseOrderItemSchedule>();
            //int iCount = 2;
            //for (int i = 1; i <= iCount; i++)
            //{
            //    PurchaseOrderItemSchedule obj = new PurchaseOrderItemSchedule();

            //    obj.PurchaseOrderScheduleSequence = "0" + i;
            //    schedules.Add(obj);
            //}
            //gvSchedule.DataSource = schedules;
            //gvSchedule.DataBind();
        }
    }
    //private void InitGrid()
    //{
    //    Collection<RejectedGood> objs = new Collection<RejectedGood>();
    //    int iCount = 11;
    //    for (int i = 1; i <= iCount; i++)
    //    {
    //        RejectedGood obj = new RejectedGood();
    //        obj.OrderNumber = "000000000" + i;
    //        //obj.SupplierId = "Supplier" + i;
    //        obj.OrderDate = GetStoredDateValue(DateTime.Now);
    //        obj.OrderAmount = 1000;
    //        obj.GstAmount = Convert.ToDecimal(1000 * 0.07);
    //        obj.CurrencyCode = "SGD";
    //        obj.PaymentTerms = "PaymentTerms" + i;
    //        obj.BuyerName = "BuyerName" + i;
    //        objs.Add(obj);
    //    }

    //    gvData.DataSource = objs;
    //    gvData.DataBind();
    //    lblCount.Text = string.Format("{0} record(s) found. ", objs.Count.ToString());
    //}
    protected void btnAcknowledge_Click(object sender, EventArgs e)
    {
        try
        {
            CheckSessionTimeOut();

            //string strErrorMsg = ValidateInput();
            string strErrorMsg = "";
            if (!string.IsNullOrEmpty(strErrorMsg.ToString()))
            {
                plMessage.Visible = true;
                displayCustomMessage(FormatErrorMessage(strErrorMsg.ToString()), lblMessage, SystemMessageType.Error);
                return;
            }

            Collection<RejectedGood> rGood = new Collection<RejectedGood>();

            foreach (RepeaterItem rowItem in gvItem.Items)
            {
                Label lblOrderNo = (Label)rowItem.FindControl("lblOrderNo");
                Label lblItemSeq = (Label)rowItem.FindControl("lblItemSeq");
                Label lblDocNo = (Label)rowItem.FindControl("lblDocumentNo");
                CheckBox chkAck = (CheckBox) rowItem.FindControl("chkAcknowledge");

                if (chkAck.Checked= true )
                {
                    mainController.GetDeliveryController().AcknowledgeRejectedGood(rGood);
                }
                //GridView gvSchedule = (GridView)rowItem.FindControl("gvSchedule");

                //foreach (GridViewRow rowSchedule in gvSchedule.Rows)
                //{
                //    Label lblScheduleSequence = (Label)rowSchedule.FindControl("lblScheduleSequence");
                //    HiddenField hdFirst = (HiddenField)rowSchedule.FindControl("hdFirst");

                //    PurchaseExpediting expediting = new PurchaseExpediting();
                //    expediting.OrderNumber = Session[SessionKey.OrderNumber].ToString(); ;
                //    expediting.ItemSequence = lblItemNo.Text;
                //    expediting.ScheduleSequence = lblScheduleSequence.Text;

                //    if (string.Compare(hdFirst.Value, "Y", true) == 0)
                //    {
                //        UserControls_DatePicker dtPromiseDate1 = (UserControls_DatePicker)rowSchedule.FindControl("dtPromiseDate1");
                //        expediting.PromiseDate1 = GetStoredDateValue(dtPromiseDate1.SelectedDate);
                //    }
                //    else
                //    {
                //        UserControls_DatePicker dtPromiseDate2 = (UserControls_DatePicker)rowSchedule.FindControl("dtPromiseDate2");
                //        expediting.PromiseDate2 = GetStoredDateValue(dtPromiseDate2.SelectedDate);
                //    }

                //    expeditings.Add(expediting);

                //}
            }

            //mainController.GetDeliveryController().AcknowledgeRejectedGood(rGood);

            //string url = "~/Expediting/AckExpeditingList.aspx?ProceeSuccess=Y&" + m_QueryString;
            //Response.Redirect(url);

            btnAcknowledge.Enabled = false;
            plMessage.Visible = true;
            string sMessage = "Rejected Good has been acknowledged successfully.";
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
            string url = "~/DeliveryOrder/EnqDeliveryOrders.aspx?" + m_QueryString;
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
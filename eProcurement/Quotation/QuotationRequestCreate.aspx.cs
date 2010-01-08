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

public partial class Quotation_QuotationRequestCreate : BaseForm

{
    private MainController mainController = null;
    Collection<RequisitionItem> requisitionItemList;
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

    private bool CheckAccessRight()
    {
        if (string.Compare(m_FuncFlag, "QTRR", false) == 0)
        {

        }        
        return true;
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
                base.m_FunctionId = "B-0007";

                m_FuncFlag = "CreateRFQ";

                base.Page_Load(sender, e);
                
                /***************************************************/

                //Initialize Page
                InitPage();

                //Check access right
                if (CheckAccessRight() == false)
                    GotoTimeOutPage();

                //store querystring in viewstate, it will be used to pass back to list page
                string queryString = Request.QueryString.ToString();

                InitItems();

                //Initialize attachment panel
                InitAttachmentPanel();

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
    private void InitItems()
    {
        Collection<MaterialStock> items = mainController.GetDAOCreator().CreateMaterialStockDAO().RetrieveAll();

        ddlMaterialNo.Items.Clear();

        ListItem liAdd;
        string sText, sValue;

        liAdd = new ListItem();
        sText = "- All -";
        sValue = "";
        liAdd.Text = sText;
        liAdd.Value = sValue;
        ddlMaterialNo.Items.Add(liAdd);

        foreach (MaterialStock materialStock in items) 
        {
            liAdd = new ListItem();
            sText = materialStock.MaterialNumber + " - " + materialStock.MaterialDescription;
            sValue = materialStock.MaterialNumber;
            liAdd.Text = sText;
            liAdd.Value = sValue;
            ddlMaterialNo.Items.Add(liAdd);
        }

        Collection<Supplier> SupplierList = mainController.GetSupplierController().GetSupplierList();
        lstSupplier.Items.Clear();

        foreach (Supplier supplier in SupplierList)
        {
            liAdd = new ListItem();
            sText = supplier.SupplierID + " - " + supplier.SupplierName ;
            sValue = supplier.SupplierID;
            liAdd.Text = sText;
            liAdd.Value = sValue;
            lstSupplier.Items.Add(liAdd);
        } 
    }
    private void InitPage()
    {
        try
        {
            if (string.Compare(m_FuncFlag, "CreateRFQ", false) == 0)
            {
                lblSubPath.Text = "Quotation Request Create";
            }         
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    private void InitAttachmentPanel()
    {
        try
        {
            attPanel.InitPanel("", false);     
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        try
        {
            string url = "~/Quotation/QuotationRequestCreate.aspx?FunctionId=S-0010";
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string materialNO = ddlMaterialNo.SelectedItem.Value.ToString().Trim() ;
        string RequisitionNo = txtRequisitionNo.Text.ToString().Trim();

        Collection<RequisitionItem> items = mainController.GetRequisitionController().GetRequisitionList(materialNO, RequisitionNo);

        lstRequisition.Items.Clear();
        //lstRequisition.DataSource = items;
        //lstRequisition.DataTextField = "RequisitionNumber";
        //lstRequisition.DataValueField = "RequisitionNumber";
        //lstRequisition.DataBind();
        ListItem li;
        Int32 i;

        for (i=0;i< items.Count;i ++ )
        {
            li= new ListItem ();
            li.Text =items[i].RequisitionNumber ;
            li.Value =items[i].RequisitionNumber ;
            if (IsDropDownContain(lstRequisition, li.Text) == false)
                lstRequisition.Items.Add (li);
            
        }           
    }
     private  Boolean IsDropDownContain(System.Web.UI.WebControls.ListBox  ddl, string searchText) 
     {  
         foreach  (ListItem li in ddl.Items)
         {
            if (li.Value.ToLower()== searchText.ToLower ())
                return true; //'there is a duplicate item
         }  
        return false; //'there isn't any duplicate items
     }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //lstRequisition
            //lstSupplier
            //Collection<QuotationHeader> quotationHdrList = new Collection<QuotationHeader>();
            Collection<QuotationItem> quotationItemList = new Collection<QuotationItem>();
            Collection<RequisitionItem> requisitionItemList = new Collection<RequisitionItem>();

            QuotationHeader qtoHeader;
            QuotationItem qtoItem = new QuotationItem(); ;
            Int16 RequisitionItem, SupplierItem, requestSequence;
            RequisitionItem = 0;
            SupplierItem = 0;
            requestSequence = 0;            

            for (RequisitionItem = 0; RequisitionItem < lstRequisition.Items.Count; RequisitionItem++)
            {
                if (lstRequisition.Items[RequisitionItem].Selected)
                {
                    for (SupplierItem = 0; SupplierItem < lstSupplier.Items.Count; SupplierItem++)
                    {
                        if (lstSupplier.Items[SupplierItem].Selected)
                        {
                            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                            * Request for Quotation Header a.k.a Quotation Header                        
                            *~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
                            string strResqNo = lstRequisition.Items[RequisitionItem].Text + "-" + lstSupplier.Items[SupplierItem].Value;
                            qtoHeader = new QuotationHeader();
                            qtoHeader.RequestNumber = strResqNo;
                            qtoHeader.SupplierId = lstSupplier.Items[SupplierItem].Text;
                            qtoHeader.ExpiryDate = GetStoredDateValue(dtpExpiry.SelectedDate);
                            qtoHeader.QuotationNumber = "";
                            qtoHeader.QuotationDate = null;
                            qtoHeader.RecordStatus = QuotationStatus.Request;  //[R]equest / [A]cknowledge / [A]cceptance / [R]ejected
                            qtoHeader.BuyerID = base.LoginUser.UserId.ToString();
                            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                             *Request for Quotation Items a.k.a Quotation Items                        
                             *~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
                            //
                            //requestSequence++;

                            //RequisitionItem item;
                            string requisitionNO = lstRequisition.Items[RequisitionItem].Text.Trim();
                            Collection<RequisitionItem> items = mainController.GetRequisitionController().GetRequisitionList(requisitionNO);
                            quotationItemList = new Collection<QuotationItem>();
                            if (items.Count > 0)
                            {
                                for (requestSequence = 0; requestSequence <= items.Count - 1; requestSequence++)
                                {
                                    qtoItem = new QuotationItem();
                                    qtoItem.RequestNumber = strResqNo;
                                    qtoItem.RequestSequence = Convert.ToString(requestSequence + 1);
                                    qtoItem.MaterialNumber = ddlMaterialNo.SelectedValue;
                                    qtoItem.MaterialDescription = txtMaterialDesc.Text;

                                    //requisitionItemList.Add(items[0]);
                                    qtoItem.Plant = items[requestSequence].Plant;
                                    qtoItem.RequiredQuantity = items[requestSequence].RequiredQuantity;
                                    qtoItem.UnitMeasure = items[requestSequence].UnitOfMeasure;
                                    qtoItem.NetPrice = items[requestSequence].UnitPrice * items[requestSequence].RequiredQuantity;
                                    qtoItem.PriceUnit = items[requestSequence].UnitPrice;
                                    qtoItem.NetValue = (items[requestSequence].UnitPrice * items[requestSequence].RequiredQuantity);   //Net Value	((net price / price unit) * re qty =net value)
                                    qtoItem.RecordStatus = QuotationStatus.Request; //Record Status	[R]equest / [A]cknowledge / [A]cceptance / [R]ejected (R)
                                    qtoItem.RequisitionNumber = lstRequisition.Items[RequisitionItem].Text;
                                    qtoItem.RequisitionItemSequence = items[requestSequence].ItemSequence;
                                    quotationItemList.Add(qtoItem);
                                }
                            }

                            mainController.GetQuotationController().CreateQuotationRequest(qtoHeader, quotationItemList, attPanel.GetAddedAttachments()); 
                            
                            //mainController.GetDAOCreator().CreateQuotationHeaderDAO().Insert(qtoHeader);
                            //mainController.GetDAOCreator().CreateQuotationItemDAO().Insert(qtoItem);

                        }//end if supplier selected

                        //
                    }//end for supplier
                }//end if selected Requisition

            }//end for Requisition
            InitAttachmentPanel();
            
            gvItem.DataSource = new Collection<QuotationItem>();
            gvItem.DataBind();
            lblCount.Text = "0 Record(s) found.";   

            plMessage.Visible = true;
            string sMessage = "Quotation has been created successfully.";
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

    
    protected void ddlMaterialNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        string materialNO = ddlMaterialNo.SelectedItem.Value.ToString().Trim();
        string whereClause = " MATNR='" + materialNO + "' ";

        Collection<MaterialStock> items = mainController.GetDAOCreator().CreateMaterialStockDAO().RetrieveByQuery(whereClause);        

        if (items.Count >0 )
        { txtMaterialDesc.Text = items[0].MaterialDescription; }

    }
    protected void txtRequisitionNo_TextChanged(object sender, EventArgs e)
    {
        string RequisitionNo = txtRequisitionNo.Text.ToString().Trim();      

        
        Collection<RequisitionItem> items = mainController.GetRequisitionController().GetRequisitionList(RequisitionNo);

        ddlMaterialNo.DataSource = items;
        ddlMaterialNo.DataTextField = "materialNumber";
        ddlMaterialNo.DataValueField = "materialNumber";
        ddlMaterialNo.DataBind();
        ddlMaterialNo.Items.Add(new ListItem("", "0"));
        ddlMaterialNo.SelectedValue = "0";
        txtMaterialDesc.Text = ""; 
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        try
        {
            string strErrorMsg = ValidateInput();

            if (!string.IsNullOrEmpty(strErrorMsg.ToString()))
            {
                plMessage.Visible = true;
                displayCustomMessage(FormatErrorMessage(strErrorMsg.ToString()), lblMessage, SystemMessageType.Error);
                return;
            }
            

            //lstRequisition
            //lstSupplier
            Collection<QuotationHeader> quotationHdrList = new Collection<QuotationHeader>();
            Collection<QuotationItem> quotationItemList = new Collection<QuotationItem>();
            requisitionItemList = new Collection<RequisitionItem>();

            QuotationHeader qtoHeader;
            QuotationItem qtoItem = new QuotationItem(); ;
            Int16 RequisitionItem, SupplierItem, requestSequence;
            RequisitionItem = 0;
            SupplierItem = 0;
            requestSequence = 1;

            for (RequisitionItem = 0; RequisitionItem < lstRequisition.Items.Count; RequisitionItem++)
            {
                if (lstRequisition.Items[RequisitionItem].Selected)
                {
                    for (SupplierItem = 0; SupplierItem < lstSupplier.Items.Count; SupplierItem++)
                    {
                        if (lstSupplier.Items[SupplierItem].Selected)
                        {
                            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                            * Request for Quotation Header a.k.a Quotation Header                        
                            *~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
                            string strResqNo = lstRequisition.Items[RequisitionItem].Text + "-" + lstSupplier.Items[SupplierItem].Value;
                            qtoHeader = new QuotationHeader();
                            qtoHeader.RequestNumber = strResqNo; 
                            qtoHeader.SupplierId = lstSupplier.Items[SupplierItem].Text;
                            qtoHeader.ExpiryDate = GetStoredDateValue(dtpExpiry.SelectedDate);
                            qtoHeader.QuotationNumber = "";
                            qtoHeader.QuotationDate = null;
                            qtoHeader.RecordStatus = QuotationStatus.Request; //[R]equest / [A]cknowledge / [A]cceptance / [R]ejected
                            quotationHdrList.Add(qtoHeader);

                            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                             *Request for Quotation Items a.k.a Quotation Items                        
                             *~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
                            //RequisitionItem item;
                            string requisitionNO = lstRequisition.Items[RequisitionItem].Text.Trim();
                            Collection<RequisitionItem> items = mainController.GetRequisitionController().GetRequisitionList(requisitionNO);

                            if (items.Count > 0)
                            {
                                for (requestSequence = 0; requestSequence <= items.Count - 1; requestSequence++)
                                {
                                    qtoItem = new QuotationItem();
                                    qtoItem.RequestNumber = strResqNo;
                                    qtoItem.RequestSequence = Convert.ToString(requestSequence + 1);
                                    qtoItem.MaterialNumber = ddlMaterialNo.SelectedValue;
                                    qtoItem.MaterialDescription = txtMaterialDesc.Text;

                                    //requisitionItemList.Add(items[0]);
                                    qtoItem.Plant = items[requestSequence].Plant;
                                    qtoItem.RequiredQuantity = items[requestSequence].RequiredQuantity;
                                    qtoItem.UnitMeasure = items[requestSequence].UnitOfMeasure;
                                    qtoItem.NetPrice = items[requestSequence].UnitPrice * items[requestSequence].RequiredQuantity;
                                    qtoItem.PriceUnit = items[requestSequence].UnitPrice;
                                    qtoItem.NetValue = (items[requestSequence].UnitPrice * items[requestSequence].RequiredQuantity);   //Net Value	((net price / price unit) * re qty =net value)
                                    qtoItem.RecordStatus = QuotationStatus.Request; //Record Status	[R]equest / [A]cknowledge / [A]cceptance / [R]ejected (R)
                                    qtoItem.RequisitionNumber = lstRequisition.Items[RequisitionItem].Text;
                                    qtoItem.RequisitionItemSequence = items[requestSequence].ItemSequence;
                                    quotationItemList.Add(qtoItem);
                                }
                            }

                            //requestSequence++;

                        }//end if supplier selected
                        //
                    }//end for supplier
                }//end if selected Requisition

            }//end for Requisition

            //add into grid        
            
            gvItem.DataSource = quotationItemList;
            gvItem.DataBind();
            lblCount.Text = Convert.ToString(quotationItemList.Count) + " Record(s) found.";                         
            //gvRequisition / =requisitionItemList
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            string sMessage = ex.Message;
            displayCustomMessage(sMessage, lblMessage, SystemMessageType.Error);
        }
    }
    ////////protected void gvItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
    ////////{
        
        
    ////////    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    ////////    {
    ////////        GridView gvRequisition = (GridView)e.Item.FindControl("gvRequisition");
    ////////        if (requisitionItemList.Count > 0)
    ////////        {
    ////////            gvRequisition.DataSource = requisitionItemList;
    ////////            gvRequisition.DataBind();
    ////////        }
    ////////    }
    ////////}

    #region validation
    private string ValidateInput()
    {
        System.Text.StringBuilder strErrorMsg = new System.Text.StringBuilder(string.Empty);
        bool bIsValid = true;

        if (dtpExpiry.Text == "")
        {
            bIsValid = false;
            strErrorMsg.Append(MakeListItem("Please select a value for Expiry Date."));
        }
        else
        {
            if (!dtpExpiry.IsValidDate)
            {
                bIsValid = false;
                strErrorMsg.Append(MakeListItem("Please select a valid value for Expiry Date."));
            }
        }
        
        return strErrorMsg.ToString();
    }
    #endregion

    
}

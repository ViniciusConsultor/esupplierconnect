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

public partial class Dialog_SearchSupplier : BaseForm
{
    /// <summary>
    /// Get or Set Supplier Name
    /// </summary>
    private string SupplierName
    {
        get
        {
            if (String.IsNullOrEmpty(txtSupplierName.Text.Trim()))
                return "%%";
            else return txtSupplierName.Text.Trim();
        }
        set { txtSupplierName.Text = value; }
    }

    /// <summary>
    /// Get or Set Supplier Id
    /// </summary>
    private string SupplierId
    {
        get
        {
            if (String.IsNullOrEmpty(txtSupplierId.Text.Trim()))
                return "%%";
            else return txtSupplierId.Text.Trim();
        }
        set
        {
            txtSupplierId.Text = value;
        }
    }

    private MainController mainController = null;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Instantiate MainController
        this.mainController = new MainController(base.LoginUser); 

        if (!IsPostBack)
        {
            if (Request.QueryString["SupplierId"] != null)
            {
                SupplierId = Request.QueryString["SupplierId"];
            }

            //LoadData();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gvSupplier.PageIndex = 0;
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            Collection<Supplier> suppliers = mainController.GetSupplierController().GetSupplierList(SupplierId, SupplierName);
            gvSupplier.DataSource = suppliers;
            gvSupplier.DataBind();

            lblResult.Text = suppliers.Count + " item(s)";
        }
        catch (Exception ex)
        {
            ExceptionLog(ex); 
        }
    }


    protected void selectRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvSupplier.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                RadioButton selectRadioButton = (RadioButton)row.FindControl("selectRadioButton");

                if (selectRadioButton.Checked)
                {
                    string supplierId = row.Cells[2].Text.ToString();
                    string supplierName = row.Cells[3].Text.ToString();

                    SelectSupplier(supplierId, supplierName);
                }
            }
        }
    }

    private void SelectSupplier(string supplierId, string supplierName)
    {
        
        string scriptBlock = @"<script language=""JavaScript"">
               <!--     		    
                       window.returnValue = new Array('" + supplierId + "','" + supplierName + @"');
                       window.close();                                      
            // --> </script>";

        string scriptKey = "SupplierDialog";

        if (!ClientScript.IsStartupScriptRegistered(scriptKey))
        {
            ClientScript.RegisterStartupScript(GetType(), scriptKey, scriptBlock);
        }
    }

    protected void gvSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSupplier.PageIndex = e.NewPageIndex;
        LoadData();
    }

}

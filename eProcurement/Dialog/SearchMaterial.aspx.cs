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

public partial class Dialog_SearchMaterial : BaseForm
{
    /// <summary>
    /// Get or Set Material Desc
    /// </summary>
    private string MaterialDesc
    {
        get
        {
            if (String.IsNullOrEmpty(txtMaterialDesc.Text.Trim()))
                return "%%";
            else return txtMaterialDesc.Text.Trim();
        }
        set { txtMaterialDesc.Text = value; }
    }

    /// <summary>
    /// Get or Set Material No
    /// </summary>
    private string MaterialNo
    {
        get
        {
            if (String.IsNullOrEmpty(txtMaterialNo.Text.Trim()))
                return "%%";
            else return txtMaterialNo.Text.Trim();
        }
        set
        {
            txtMaterialNo.Text = value;
        }
    }

    private MainController mainController = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Instantiate MainController
        this.mainController = new MainController(base.LoginUser);

        if (!IsPostBack)
        {
            if (Request.QueryString["MaterialNo"] != null)
            {
                MaterialNo = Request.QueryString["MaterialNo"];
            }

            //LoadData();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gvMaterial.PageIndex = 0;
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            string whereClause = "";
            string orderClause = "";
            whereClause = " MATNR like '" + Utility.EscapeSQL(MaterialNo) + "'";
            whereClause += " AND [MAKTX] like '" + Utility.EscapeSQL(MaterialDesc) + "' ";

            orderClause = " MATNR asc ";
            Collection<MaterialStock> materials= this.mainController.GetDAOCreator().CreateMaterialStockDAO().RetrieveByQuery(whereClause, orderClause);
            gvMaterial.DataSource = materials;
            gvMaterial.DataBind();

            lblResult.Text = materials.Count + " item(s)";
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
        }
    }


    protected void selectRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvMaterial.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                RadioButton selectRadioButton = (RadioButton)row.FindControl("selectRadioButton");

                if (selectRadioButton.Checked)
                {
                    string materialNo = row.Cells[2].Text.ToString();
                    string materialDesc = row.Cells[3].Text.ToString();

                    SelectMaterial(materialNo, materialDesc);
                }
            }
        }
    }

    private void SelectMaterial(string materialNo, string materialDesc)
    {

        string scriptBlock = @"<script language=""JavaScript"">
               <!--     		    
                       window.returnValue = new Array('" + materialNo + "','" + materialDesc + @"');
                       window.close();                                      
            // --> </script>";

        string scriptKey = "MaterialDialog";

        if (!ClientScript.IsStartupScriptRegistered(scriptKey))
        {
            ClientScript.RegisterStartupScript(GetType(), scriptKey, scriptBlock);
        }
    }

    protected void gvMaterial_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMaterial.PageIndex = e.NewPageIndex;
        LoadData();
    }

}

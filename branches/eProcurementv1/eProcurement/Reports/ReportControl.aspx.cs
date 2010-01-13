using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using eProcurement_BLL.Reports;

public partial class Reports_ReportControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowReports();
    }

    private void ShowReports()
    {
        ReportClass objReport = null;

        switch (Request.QueryString["ReportName"].ToString())
        {
            case "ORDER":
                {
                    objReport = new PurchaseOrder();
                    //objReport.PrintOptions.PaperSize = PaperSize.PaperA4;
                    //objReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    //ParameterDiscreteValue objParamer = new ParameterDiscreteValue();
                    //objParamer.Value = Request.QueryString["OrderNo"];
                    //objReport.SetParameterValue("@Order", objParamer);
                    break;
                }
            case "CONTRACT":
                {
                    objReport = new Contract();
                    //objReport.PrintOptions.PaperSize = PaperSize.PaperA4;
                    //objReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    //ParameterDiscreteValue objParamer = new ParameterDiscreteValue();
                    //objParamer.Value = Request.QueryString["Contract"];
                    //objReport.SetParameterValue("@Order", objParamer);
                    break;
                }
            case "RFQ":
                {
                    objReport = new RFQDocument();
                    //ParameterDiscreteValue objParamer = new ParameterDiscreteValue();
                    //objParamer.Value = Request.QueryString["RFQNo"];
                    //objReport.SetParameterValue("@Order", objParamer);
                    break;
                }
            case "QUOTATION":
                {
                    objReport = new Quotation();
                    //ParameterDiscreteValue objParamer = new ParameterDiscreteValue();
                    //objParamer.Value = Request.QueryString["Quotation"];
                    //objReport.SetParameterValue("@Order", objParamer);
                    break;
                }
            case "REJECTION":
                {
                    objReport = new Quotation();
                    //ParameterDiscreteValue objParamer = new ParameterDiscreteValue();
                    //objParamer.Value = Request.QueryString["Supplier"].ToUpper();
                    //objReport.SetParameterValue("@Order", objParamer);
                    break;
                }
            case "DELIVERY":
                {
                    objReport = new Quotation();
                    //ParameterDiscreteValue objParamer = new ParameterDiscreteValue();
                    //objParamer.Value = Request.QueryString["Delivery"].ToUpper();
                    //objReport.SetParameterValue("@Order", objParamer);
                    break;
                }
        }
        TableLogOnInfo Loginfo = new TableLogOnInfo();
        foreach (CrystalDecisions.CrystalReports.Engine.Table oTable in objReport.Database.Tables)
        {
            Loginfo = oTable.LogOnInfo;
            Loginfo.ConnectionInfo.ServerName = "CHETAN1\\SQLEXPRESS";
            Loginfo.ConnectionInfo.DatabaseName = "eprocurement";
            Loginfo.ConnectionInfo.UserID = "epuradmin";
            Loginfo.ConnectionInfo.Password = "epuradmin";
            Loginfo.TableName = oTable.Name;
            oTable.ApplyLogOnInfo(Loginfo);
        }
        CrystalReportViewer1.ReportSource = objReport;
        CrystalReportViewer1.DataBind();

    }

}
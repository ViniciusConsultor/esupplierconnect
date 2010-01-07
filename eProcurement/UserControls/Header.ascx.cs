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

using eProcurement_BLL.UserManagement;
using eProcurement_BLL;

public partial class UserControls_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session[SessionKey.LOGIN_USER] == null) 
                {
                    Session.Abandon();
                    Response.Redirect("~/Common/Timeout.aspx");
                }

                LoginUserVO loginUserVO = (LoginUserVO)Session[SessionKey.LOGIN_USER];
                lblLoginUser.Text = loginUserVO.UserId + " - " + loginUserVO.UserName + " (" + loginUserVO.Role + ")";
                if (string.Compare(loginUserVO.ProfileType, ProfileType.Supplier, true) == 0)
                {
                    lblSupplier.Text = loginUserVO.SupplierId + " - " + loginUserVO.SupplierName + " | " + loginUserVO.SupplierAddr;
                    plSupplier.Visible = true;
                }
            }
            fnSetClockScript();
        }
        catch (Exception ex)
        {

        }
    }

    /// <summary>
    /// Append Clock script in client
    /// </summary>
    private void fnSetClockScript()
    {
        DateTime oServerDate = DateTime.Now;

        System.Text.StringBuilder strScript = new System.Text.StringBuilder("<script language='javascript'> \n");
        strScript.Append("     var oDateTime,tFresh,C_Time,nInterval=30000; \n");
        strScript.Append("     var yr_num=" + oServerDate.Year + ";\n");
        strScript.Append("     var mo_num=" + oServerDate.Month + ";\n");
        strScript.Append("     var day_num=" + oServerDate.Day + ";\n");
        strScript.Append("     var hr_num=" + oServerDate.Hour + ";\n");
        strScript.Append("     var min_num=" + oServerDate.Minute + ";\n");
        strScript.Append("     var sec_num=" + oServerDate.Second + ";\n");
        strScript.Append("     oDateTime=new Date(yr_num, mo_num-1, day_num, hr_num, min_num, sec_num)\n");
        strScript.Append("     C_Time=oDateTime.getTime(); \n");
        strScript.Append("     function fnDisplayTime() { \n");
        strScript.Append("       var sDate,sTime,sH,sM,oCurrentDate; \n");
        strScript.Append("       window.clearTimeout(tFresh); \n");
        strScript.Append("       oCurrentDate = new Date(); \n");
        strScript.Append("       oCurrentDate.setTime(C_Time); \n");
        strScript.Append("       C_Time+=nInterval; \n");
        strScript.Append("       sDate=oCurrentDate.toDateString(); \n");
        strScript.Append("       sH=(oCurrentDate.getHours()).toString(); \n");
        strScript.Append("       sM=(oCurrentDate.getMinutes()).toString(); \n");
        strScript.Append("       sTime=sH + \":\" + (\"0\" + sM).substring((\"0\" + sM).length-2);\n");
        strScript.Append("       //document.getElementById(\"tdTime\").innerText= oCurrentDate.toLocaleTimeString();\n");
        strScript.Append("       document.getElementById(\"tdTime\").innerText= sDate + \" \" + sTime; \n");
        strScript.Append("       tFresh=window.setTimeout(\"fnDisplayTime();\",nInterval); \n");
        strScript.Append("     } \n");
        strScript.Append("     if(document.attachEvent) window.attachEvent(\"onload\",  fnDisplayTime); \n");
        strScript.Append("     else  window.addEventListener(\"load\", fnDisplayTime,  false); \n");
        strScript.Append("</script> \n");

        if (!Page.IsClientScriptBlockRegistered("ClockScript"))
            Page.RegisterClientScriptBlock("ClockScript", strScript.ToString());
    }
}

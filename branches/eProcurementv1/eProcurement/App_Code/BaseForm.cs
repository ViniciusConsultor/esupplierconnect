using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

using log4net;
using eProcurement_BLL;
using eProcurement_BLL.UserManagement;
using eProcurement_DAL;

/// <summary>
/// Summary description for BaseForm
/// </summary>
public class BaseForm : System.Web.UI.Page
{
    static BaseForm()
    {
    
    }

    private bool _setCache;
    protected bool m_SetCache
    {
        get { return _setCache; }
        set { _setCache = value; }
    }

    private Collection<string> _functionIdColl = new Collection<string>();
    protected Collection<string> m_FunctionIdColl
    {
        get { return _functionIdColl; }
        set { _functionIdColl = value; }
    }

    private string _functionId;
    protected string m_FunctionId
    {
        get { return _functionId; }
        set { _functionId = value; }
    }

    protected LoginUserVO LoginUser
    {
        set
        {
            Session[SessionKey.LOGIN_USER] = value;
        }
        get
        {
            if (Session[SessionKey.LOGIN_USER] != null)
                return (LoginUserVO)Session[SessionKey.LOGIN_USER];
            else
                return null;
        }
    }

    public void Page_Load(object sender, EventArgs e)
    {
        try
        {
              if (!_setCache)
                    setNoCache();
            
            //Security: Check whether user has login or not
            if (LoginUser == null)
            {
                Session.Abandon();
                Response.Redirect("~/Login.aspx");
            }

            //One form, one function
            if (!string.IsNullOrEmpty(m_FunctionId))
            {
                if (!LoginUser.FuncList.Contains(m_FunctionId))
                {
                    Session.Abandon();
                    Response.Redirect("~/Common/Timeout.aspx");
                }
            }

            //One form, more than one functions
            if (m_FunctionIdColl.Count>0)
            {
                bool hasRight = false;
                for (int i = 0; i < m_FunctionIdColl.Count; i++) 
                {
                    if (LoginUser.FuncList.Contains(m_FunctionIdColl[i])) 
                    {
                        hasRight = true;
                        break;
                    } 
                }
                if (!hasRight)
                {
                    Session.Abandon();
                    Response.Redirect("~/Timeout.aspx");
                }
            }

        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
        }
    }

    protected virtual void setNoCache()
    {
        Response.Expires = -1;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    }

    #region Log
    //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    protected void ExceptionLog(Exception ex)
    {
        if (!ex.Message.Contains("Thread was being aborted"))
        {
            Utility.ExceptionLog(ex);
        }
    }

    protected void InfoLog(string message)
    {
        Utility.InfoLog(message); 
    }

    protected void InfoLog(string format, params object[] args)
    {
        Utility.InfoLog(format, args);
    }

    protected void DebugLog(string message)
    {
        Utility.DebugLog(message);
    }

    protected void DebugLog(string format, params object[] args)
    {
        Utility.DebugLog(format, args);
    }

    protected void ErrorLog(string message)
    {
        Utility.ErrorLog(message);
    }

    protected void ErrorLog(string format, params object[] args)
    {
        Utility.ErrorLog(format, args);
    }
    #endregion

    #region Commen Function - Format Date
    protected long GetStoredDateValue(DateTime dt)
    {
        return Utility.GetStoredDateValue(dt);
    }

    protected DateTime GetDateTimeFormStoredValue(long ldate)
    {
        return Utility.GetDateTimeFormStoredValue(ldate);
    }

    protected string GetStoredTimeValue(DateTime dt)
    {
        return Utility.GetStoredTimeValue(dt);
    }

    /// <summary>
    /// Get Short Date in string format from given DB Date
    /// </summary>
    /// <param name="strInput">Date</param>
    /// <returns>
    /// Date String (eg.02-04-2007)
    /// </returns>
    protected string GetShortDate(string strInput)
    {
        return Utility.GetShortDate(strInput);
    }

    /// <summary>
    /// Get Short Date in string format from given Date object
    /// </summary>
    /// <param name="dtInput">Date</param>
    /// <returns>
    /// Date String (eg.02-04-2007)
    /// Format changed by Jeya on 18-12-2006
    /// Date String (eg.02/04/2007)
    /// </returns>
    protected string GetShortDate(DateTime dtInput)
    {
        return Utility.GetShortDate(dtInput, '/');
    }

    /// <summary>
    /// Get Short Date in string format from given Date object
    /// </summary>
    /// <param name="dtInput"></param>
    /// <param name="chSeparator">Separator (/-:)</param>
    /// <returns>
    /// Date String (eg.02-04-2007)
    /// </returns>
    protected string GetShortDate(DateTime dtInput, char chSeparator)
    {
        return Utility.GetShortDate(dtInput, chSeparator);
    }

    /// <summary>
    /// Get Long Date in string format from given Date object
    /// </summary>
    /// <param name="dtInput">Date Object</param>
    /// <returns>
    /// Date String (eg.02-04-2007 23:22:15)
    /// Format changed by Jeya 18-12-2006
    /// Date String (eg.02/04/2007 23:22:15) 
    /// </returns>
    protected string GetLongDate(DateTime dtInput)
    {
        return Utility.GetLongDate(dtInput, '/'); 
    }

    /// <summary>
    /// Get Long Date in string format from given Date object
    /// </summary>
    /// <param name="dtInput">Date Object</param>
    /// <param name="chSeparator">Separator (/-:)</param>
    /// <returns>
    /// Date String (eg.02-04-2007 23:22:15)
    /// </returns>
    protected string GetLongDate(DateTime dtInput, char chSeparator)
    {
        return Utility.GetLongDate(dtInput, chSeparator);
    }

    #endregion

    #region Validation
    protected bool IsAlphaNumeric(string input)
    {
        return Utility.IsAlphaNumeric(input);
    }

    protected bool IsAlphaWithControl(string input)
    {
        return Utility.IsAlphaWithControl(input);
    }

    protected bool IsNumeric(string input)
    {
        return Utility.IsNumeric(input);
    }

    protected bool IsAlpha(string input)
    {
        return Utility.IsAlpha(input);
    }

    protected bool IsNumericText(string input)
    {
        return Utility.IsNumericText(input);
    }

    #endregion

    protected string EscapeSQL(string str)
    {
        return Utility.EscapeSQL(str);
    }

    protected void insertItem_DropDownList(System.Web.UI.WebControls.DropDownList dropDownList,
                                bool boolInsertAllItem, bool boolInsertSelectItem)
    {
        insertItem_DropDownList(dropDownList, boolInsertAllItem, boolInsertSelectItem, string.Empty, true);
    }

    protected void insertItem_DropDownList(System.Web.UI.WebControls.DropDownList dropDownList,
                                        bool boolInsertAllItem, bool boolInsertSelectItem, string strCustomValue, bool bItemFound)
    {
        if (dropDownList != null)
        {
            if (dropDownList.Items.Count > 0 && strCustomValue != string.Empty)
            {
                System.Web.UI.WebControls.ListItem allItem =
                        new System.Web.UI.WebControls.ListItem(strCustomValue, "");
                dropDownList.Items.Insert(0, allItem);
            }

            if (boolInsertAllItem)
            {
                if (dropDownList.Items.Count > 0)
                {
                    System.Web.UI.WebControls.ListItem allItem =
                            new System.Web.UI.WebControls.ListItem("-- All --", "");
                    dropDownList.Items.Insert(0, allItem);
                }
            }

            if (boolInsertSelectItem)
            {
                if (dropDownList.Items.Count > 0)
                {
                    System.Web.UI.WebControls.ListItem allItem =
                            new System.Web.UI.WebControls.ListItem("-- Select One --", "");
                    dropDownList.Items.Insert(0, allItem);
                }
            }

            if (!bItemFound)
            {
                System.Web.UI.WebControls.ListItem allItem =
                        new System.Web.UI.WebControls.ListItem("-- No items --", "");
                dropDownList.Items.Insert(0, allItem);
            }
        }
    }

    public static void displayCustomMessage(string strMsg, Label lblMsg, string strMsgType)
    {

        if (strMsg != string.Empty)
        {
            lblMsg.Text = strMsg;
            lblMsg.Visible = true;
            if (strMsgType != SystemMessageType.Information)
                lblMsg.CssClass = "labelErrorMessage";
            else
                lblMsg.CssClass = "labelMessage";
        }
        else
        {
            lblMsg.Text = "";
            lblMsg.Visible = false;
        }
    }

    public static string FormatErrorMessage(string strErrMsg)
    {

        StringBuilder strErrorMsg = new StringBuilder(string.Empty);
        if (strErrMsg != string.Empty)
        {
            strErrorMsg.Append("The following field(s) is/are not properly filled: <br /> ");
            strErrorMsg.Append("<ul>"); //start of bullet list format
            strErrorMsg.Append(strErrMsg.ToString());
            strErrorMsg.Append("</ul>"); //end of bullet list format
        }
        return strErrorMsg.ToString();
    }

    public static string MakeListItem(string strErrMsg)
    {

        StringBuilder strErrorMsg = new StringBuilder(string.Empty);
        if (strErrMsg != string.Empty)
        {
            strErrorMsg.Append("<li>"); //start of list item
            strErrorMsg.Append(strErrMsg.ToString());
            strErrorMsg.Append("</li>"); //end of list item
        }
        return strErrorMsg.ToString();
    }
}

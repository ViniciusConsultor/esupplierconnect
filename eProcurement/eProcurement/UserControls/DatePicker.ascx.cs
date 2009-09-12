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

[ValidationPropertyAttribute("SelectedDateString")]
public partial class UserControls_DatePicker : System.Web.UI.UserControl
{
    private bool blnShowErrorAlert;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((CalendarDate.ReadOnly == false) && (CalendarDate.Enabled == true))
        {
            //CalendarDate.Attributes.Add("onblur", "validateDate(this,'" + blnShowErrorAlert + "');");
            calendarImage.Attributes.Add("onclick", "return showCalendar('" + CalendarDate.ClientID + "', 'dd/mm/y');");
            calendarImage.Attributes.Add("onmouseover", "this.style.cursor='hand'");
            //this.calendarImage.Visible = true;
        }
        //else
        //{
        //    this.calendarImage.Visible = false;
        //}
    }

    public void EnabledDisabledCalImage(bool blIsEnabled)
    {
        if (blIsEnabled)
        {
            calendarImage.Attributes["onclick"] =
                "return showCalendar('" + CalendarDate.ClientID + "', 'dd/mm/y');";
            calendarImage.Attributes["onmouseover"] = "this.style.cursor='hand'";
        }
        else
        {
            calendarImage.Attributes["onclick"] = string.Empty;
            calendarImage.Attributes["onmouseover"] = string.Empty;
        }
    }

    // This propety was included by Rk on 18/12/2006
    public string CssClass
    {
        set
        {
            CalendarDate.CssClass = value;

        }
        get
        {
            return CalendarDate.CssClass;
        }
    }

    // This propety was included by Rk on 18/01/2007
    public bool EnableViewState
    {
        set
        {
            CalendarDate.EnableViewState = value;

        }
        get
        {
            return CalendarDate.EnableViewState;
        }
    }
    // This propety was included by Rk on 18/11/2006
    public bool ShowErrorAlert
    {
        set
        {
            blnShowErrorAlert = value;
        }
        get
        {
            return blnShowErrorAlert;
        }
    }
    public Unit TextboxWidth
    {
        set
        {
            CalendarDate.Width = value;
        }
        get
        {
            return CalendarDate.Width;
        }
    }
    // This propety was included by Rk on 16/01/2007
    // To retrive the enter text without format 
    public string Text
    {

        get
        {
            return CalendarDate.Text;
        }
    }
    public string SelectedDateString
    {
        set
        {
            if (value != null)
            {
                if (value.Length == 8)
                {
                    CalendarDate.Text = value.Substring(6) + "/" + value.Substring(4, 2) + "/" + value.Substring(0, 4);
                }
                else if (value.Length == 10)
                {
                    CalendarDate.Text = value;
                }
                else if (value.Length == 0)
                {
                    CalendarDate.Text = string.Empty;
                }

            }
        }
        get
        {
            if (CalendarDate.Text == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                string[] dtStr = CalendarDate.Text.Split('/');
                if (dtStr.Length == 3)
                {
                    string day = dtStr[0];
                    string mth = dtStr[1];
                    string year = dtStr[2];
                    return (year + mth + day);
                }
                else
                {
                    return string.Empty;
                }
            }

        }

    }

    public DateTime SelectedDate
    {
        get
        {
            return SelectedNullableDate.HasValue ?
                SelectedNullableDate.Value :
                DateTime.Now;
        }
        set { SelectedNullableDate = value; }
    }

    public DateTime? SelectedNullableDate
    {
        set
        {
            if (value.HasValue)
            {
                //DateTime dt = value;
                //string day = string.Empty;
                //string mth = string.Empty;

                //if (dt.Day < 10)
                //    day = "0" + dt.Day;
                //else
                //    day = dt.Day.ToString();

                //if (dt.Month < 10)
                //    mth = "0" + dt.Month;
                //else
                //    mth = dt.Month.ToString();

                //CalendarDate.Text = day + "/" + mth + "/" + dt.Year;
                CalendarDate.Text = GetShortDate(value.Value);
            }
            else
            {
                CalendarDate.Text = string.Empty;
            }
        }
        get
        {
            int day = 0;
            int mth = 0;
            int year = 0;

            try
            {
                string[] dtStr = CalendarDate.Text.Split('/');
                if (dtStr.Length == 3)
                {
                    day = int.Parse(dtStr[0]);
                    mth = int.Parse(dtStr[1]);
                    year = int.Parse(dtStr[2]);
                    return new DateTime(year, mth, day);
                }
                else
                {
                    //return DateTime.Now;
                    return (DateTime?)null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public bool Enabled
    {
        set
        {
            CalendarDate.Enabled = value;
            //calendarImage.Visible = value;
            EnabledDisabledCalImage(value);
        }
        get
        {
            return CalendarDate.Enabled;
        }
    }

    #region //Added by WaiLin on 16/05/2007

    public bool EnableValidation
    {
        set
        {
            rfvCalendarDate.Enabled = value;
        }
        get
        {
            return rfvCalendarDate.Enabled;
        }
    }

    public string ValidationErrMessage
    {
        set
        {
            rfvCalendarDate.ErrorMessage = value;
        }
        get
        {
            return rfvCalendarDate.ErrorMessage;
        }
    }

    public string ValidationGroup
    {
        set
        {
            rfvCalendarDate.ValidationGroup = value;
        }
        get
        {
            return rfvCalendarDate.ValidationGroup;
        }
    }

    #endregion//Added by rk on 30/11/2006

    public short TabIndex
    {
        set
        {
            CalendarDate.TabIndex = value;
        }
        get
        {
            return CalendarDate.TabIndex;
        }
    }


    public bool ReadOnly
    {
        set
        {
            CalendarDate.ReadOnly = value;
        }
        get
        {
            return CalendarDate.ReadOnly;
        }
    }


    public string onkeypress
    {
        set
        {
            CalendarDate.Attributes.Add("onkeypress", value);
        }
        get
        {
            return CalendarDate.Attributes["onkeypress"];
        }
    }

    public bool AutoPostBack
    {
        set
        {
            CalendarDate.AutoPostBack = value;
        }
        get
        {
            return CalendarDate.AutoPostBack;
        }
    }

    public event System.EventHandler TextChanged;

    protected void CalendarDate_OnTextChanged(object sender, EventArgs e)
    {
        if (TextChanged != null)
        {
            TextChanged(sender, e);
        }
    }

    // This propety was included by Rk on 16/01/2007
    // To validate the entered date
    public bool IsValidDate
    {
        get
        {
            int day = 0;
            int mth = 0;
            int year = 0;

            try
            {
                string[] dtStr = CalendarDate.Text.Split('/');
                DateTime dtGenerateDate;
                if (dtStr.Length == 3 && (dtStr[2].Length == 4))
                {
                    day = int.Parse(dtStr[0]);
                    mth = int.Parse(dtStr[1]);
                    year = int.Parse(dtStr[2]);
                    //if (day > 0 && mth > 0 && year > 00)
                    //{
                    dtGenerateDate = new DateTime(year, mth, day);
                    return true;
                    //}
                    //else { return false; }
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    // This method was included by MTBB on 22/03/2007
    // To clear selected value
    public void ClearText()
    {
        CalendarDate.Text = string.Empty;
    }

    private string GetShortDate(DateTime dtInput)
    {
        return GetShortDate(dtInput, '/');
    }

    /// <summary>
    /// Get Short Date in string format from given Date object
    /// </summary>
    /// <param name="dtInput"></param>
    /// <param name="chSeparator">Separator (/-:)</param>
    /// <returns>
    /// Date String (eg.02-04-2007)
    /// </returns>
    private string GetShortDate(DateTime dtInput, char chSeparator)
    {
        if (dtInput.Year == 0001)
            return string.Empty;

        string str = "dd" + chSeparator + "MM" + chSeparator + "yyyy";

        return dtInput.ToString(str);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace eProcurement_BLL
{
    public class Utility
    {
        #region Log
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void ExceptionLog(Exception ex)
        {
            if (!ex.Message.Contains("Thread was being aborted"))
            {
                LogHelper.WriteLog(LogHelper.LogLevel.Fatal, LogHelper.ComposeExceptionMessage(ex));
            }
        }

        public static void InfoLog(string message)
        {
            LogHelper.WriteLog(LogHelper.LogLevel.Info, message);
        }

        public static void InfoLog(string format, params object[] args)
        {
            LogHelper.WriteLog(LogHelper.LogLevel.Info, format, args);
        }

        public static void DebugLog(string message)
        {
            LogHelper.WriteLog(LogHelper.LogLevel.Debug, message);
        }

        public static void DebugLog(string format, params object[] args)
        {
            LogHelper.WriteLog(LogHelper.LogLevel.Debug, format, args);
        }

        public static void ErrorLog(string message)
        {
            LogHelper.WriteLog(LogHelper.LogLevel.Error, message);
        }

        public static void ErrorLog(string format, params object[] args)
        {
            LogHelper.WriteLog(LogHelper.LogLevel.Error, format, args);
        }
        #endregion

        #region Commen Function - Format Date
        public static long GetStoredDateValue(DateTime dt)
        {
            return Convert.ToInt64(dt.Year.ToString() +
                   ("0" + dt.Month.ToString()).Substring(dt.Month.ToString().Length - 1, 2) +
                   ("0" + dt.Day.ToString()).Substring(dt.Day.ToString().Length - 1, 2));
        }

        public static DateTime GetDateTimeFormStoredValue(long ldate)
        {
            string strDate = ldate.ToString();
            if (strDate.Length != 8)
                return DateTime.MinValue;

            int year = Convert.ToInt32(strDate.Substring(0, 4));
            int month = Convert.ToInt32(strDate.Substring(4, 2));
            int day = Convert.ToInt32(strDate.Substring(6, 2));

            return new DateTime(year, month, day);
        }

        public static string GetStoredTimeValue(DateTime dt)
        {
            return ("0" + dt.Hour.ToString()).Substring(dt.Hour.ToString().Length - 1, 2) +
                   ("0" + dt.Minute.ToString()).Substring(dt.Minute.ToString().Length - 1, 2) +
                   ("0" + dt.Second.ToString()).Substring(dt.Second.ToString().Length - 1, 2);
        }
        
        /// <summary>
        /// Get Short Date in string format from given DB Date
        /// </summary>
        /// <param name="strInput">Date</param>
        /// <returns>
        /// Date String (eg.02-04-2007)
        /// </returns>
        public static string GetShortDate(string strInput)
        {
            return GetShortDate(Convert.ToDateTime(strInput));
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
        public static string GetShortDate(DateTime dtInput)
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
        public static string GetShortDate(DateTime dtInput, char chSeparator)
        {
            if (dtInput.Year == 0001)
                return string.Empty;

            string str = "dd" + chSeparator + "MM" + chSeparator + "yyyy";

            return dtInput.ToString(str);
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
        public static string GetLongDate(DateTime dtInput)
        {
            return GetLongDate(dtInput, '/');
        }

        /// <summary>
        /// Get Long Date in string format from given Date object
        /// </summary>
        /// <param name="dtInput">Date Object</param>
        /// <param name="chSeparator">Separator (/-:)</param>
        /// <returns>
        /// Date String (eg.02-04-2007 23:22:15)
        /// </returns>
        public static string GetLongDate(DateTime dtInput, char chSeparator)
        {
            if (dtInput.Year == 0001)
                return string.Empty;

            string str = "dd" + chSeparator + "MM" + chSeparator + "yyyy HH:mm:ss";

            return dtInput.ToString(str);
        }

        #endregion

        #region Validation
        public static bool IsAlphaNumeric(string input)
        {
            Regex invalidPattern = new Regex("[^a-zA-Z0-9]");
            Regex validPattern = new Regex("[a-zA-Z0-9]*");
            return !invalidPattern.IsMatch(input) &&
                validPattern.IsMatch(input);
        }

        public static bool IsAlphaWithControl(string input)
        {
            Regex invalidPattern = new Regex("[^a-zA-Z0-9()._/-]");
            Regex validPattern = new Regex("[a-zA-Z0-9()._/-]*");
            return !invalidPattern.IsMatch(input) &&
                validPattern.IsMatch(input);
        }

        public static bool IsNumeric(string input)
        {
            Regex invalidPattern = new Regex("[^0-9]");
            Regex validPattern = new Regex("[0-9]*");
            return !invalidPattern.IsMatch(input) &&
                validPattern.IsMatch(input);
        }

        public static bool IsAlpha(string input)
        {
            Regex invalidPattern = new Regex("[^a-zA-Z]");
            Regex validPattern = new Regex("[a-zA-Z]*");
            return !invalidPattern.IsMatch(input) &&
                validPattern.IsMatch(input);
        }

        public static bool IsNumericText(string input)
        {
            if (input.IndexOf(".") > -1)
            {
                //decimal
                string[] parts = input.Split('.');
                if (parts.Length > 2)
                    return false;
                else
                    return IsNumeric(parts[0]) && IsNumeric(parts[1]);
            }
            else
            {
                //integer
                return IsNumeric(input);
            }
        }

        #endregion

        public static string EscapeSQL(string str)
        {
            string strReturn = string.Empty;
            if (!string.IsNullOrEmpty(str))
                strReturn = str.Replace("'", "''");
            return strReturn;
        }

    }
}

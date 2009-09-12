using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using log4net;

namespace eProcurement_BLL
{
    /// <summary>
    /// Log helper utility.
    /// </summary>
    public class LogHelper
    {
        private static readonly ILog _log = null;
        //LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static LogHelper()
        {
            MethodBase methodBase = MethodBase.GetCurrentMethod();
            Type type = methodBase.DeclaringType;
            _log = LogManager.GetLogger(type);

            log4net.Config.XmlConfigurator.Configure();
        }

        public static ILog Log
        {
            get { return _log; }
        }

        #region Indention

        private static int _indention = 0;
        private static int _indentionStep = 2;

        private static string GetIndention()
        {
            return new string(' ', _indention);
        }

        public static void Indent()
        {
            _indention += _indentionStep;
        }

        public static void Unindent()
        {
            _indention -= _indentionStep;
            if (_indention < 0)
            {
                _indention = 0;
            }
        }

        #endregion

        #region Write Log

        // different from log4net.Core.Level
        public enum LogLevel
        {
            Info,
            Debug,
            Error,
            Fatal
        }

        private const string SEPARATOR = "---------------------------------------------------------------------------------------------------------------";

        public static void WriteWebLog(LogLevel logLevel, string message, string url, string userId, string clientIP)
        {
            string loggerName = MethodBase.GetCurrentMethod().DeclaringType.ToString();
            ILog logEngine = LogManager.GetLogger(loggerName);

            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(url))
            {
                sb.Append(Environment.NewLine)
                    .Append(url);
            }

            if (!string.IsNullOrEmpty(userId))
            {
                sb.Append(Environment.NewLine)
                    .AppendFormat("User: {0}", userId);
            }

            if (!string.IsNullOrEmpty(clientIP))
            {
                sb.Append(Environment.NewLine)
                    .AppendFormat("Client IP: {0}", clientIP);
            }

            sb.Append(Environment.NewLine)
                //.Append(Environment.NewLine)
                .Append(message)
                .Append(Environment.NewLine)
                .Append(SEPARATOR);

            switch (logLevel)
            {
                case LogLevel.Info:
                    if (logEngine.IsInfoEnabled)
                    {
                        logEngine.Info(sb.ToString());
                    }
                    break;
                case LogLevel.Debug:
                    if (logEngine.IsDebugEnabled)
                    {
                        logEngine.Debug(sb.ToString());
                    }
                    break;
                case LogLevel.Error:
                    if (logEngine.IsErrorEnabled)
                    {
                        logEngine.Error(sb.ToString());
                    }
                    break;
                case LogLevel.Fatal:
                    if (logEngine.IsFatalEnabled)
                    {
                        logEngine.Error(sb.ToString());
                    }
                    break;
            }
        }

        /// <summary>
        /// Writes the given message as the given log level into the log.
        /// </summary>
        /// <param name="logLevel">The given log level.</param>
        /// <param name="message">The given message</param>
        public static void WriteLog(LogLevel logLevel, string message)
        {
            WriteWebLog(logLevel, GetIndention() + message, null, null, null);
        }

        /// <summary>
        /// Writes the given message as the given log level into the log.
        /// </summary>
        /// <param name="logLevel">The given log level.</param>
        /// <param name="format">
        /// A string containing zero or more format items.
        /// </param>
        /// <param name="args">
        /// An object array containing zero or more items to format.
        /// </param>
        public static void WriteLog(LogLevel logLevel, string logFormat, params object[] args)
        {
            WriteLog(logLevel, string.Format(logFormat, args));
        }

        public static void WriteLog(LogLevel logLevel, object obj)
        {
            WriteLog(logLevel, GetIndention() + obj.ToString());
        }

        public static void WriteLog(LogLevel logLevel)
        {
            WriteLog(logLevel, string.Empty);
        }

        /// <summary>
        /// Writes the given message as the information into the log.
        /// </summary>
        /// <param name="message"></param>
        public static void WriteInfoLog(string message)
        {
            WriteLog(LogHelper.LogLevel.Info, message);
        }

        /// <summary>
        /// Writes the given message as the information into the log.
        /// </summary>
        /// <param name="format">
        /// A string containing zero or more format items.
        /// </param>
        /// <param name="args">
        /// An object array containing zero or more items to format.
        /// </param>
        public static void WriteInfoLog(string format, params object[] args)
        {
            WriteInfoLog(string.Format(format, args));
        }

        #endregion

        #region Log Helper Methods

        public static void ListStrings(IList<string> items)
        {
            Indent();
            foreach (string item in items)
            {
                WriteLog(LogLevel.Info, "{0}", item);
            }
            Unindent();
        }

        public static string ComposeExceptionMessage(Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(ex.Message);
            sb.Append(Environment.NewLine);
            sb.Append(ex.StackTrace);

            if (ex.InnerException != null)
            {
                sb.Append(Environment.NewLine)
                    .Append(Environment.NewLine)
                    .Append(ComposeExceptionMessage(ex.InnerException));
            }

            return sb.ToString();
        }

        #endregion
    }
}

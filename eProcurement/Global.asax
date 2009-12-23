<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
    	//Initialize Log4net
        log4net.Config.XmlConfigurator.Configure();

        String dataStoreType = System.Web.Configuration.WebConfigurationManager.AppSettings["DATA_STORE_TYPE"].ToString();
        eProcurement_BLL.MainController.DataStoreType = dataStoreType;
    }

    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        Application.Clear();
        
        try
        {
            // "Session not available" exception may occur
            Session.Abandon();
        }
        catch { }
    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs  
        //string SEPARATOR = "---------------------------------------------------------------------------------------------------------------";
        //string LF = "\r\n";

        Exception ex = //Server.GetLastError().GetBaseException();
            Server.GetLastError();  // catch all stack trace

        if (!ex.Message.Contains("Thread was being aborted"))
        {
            eProcurement_BLL.LogHelper.WriteLog(
                eProcurement_BLL.LogHelper.LogLevel.Error,  
                eProcurement_BLL.LogHelper.ComposeExceptionMessage(ex)); 
            
            Server.ClearError();

            if (!ex.Message.Contains("is not marked as serializable"))
            {
                Response.Redirect("~/Common/Error.aspx");
            }
        }
    }
    
    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
    }
       
</script>

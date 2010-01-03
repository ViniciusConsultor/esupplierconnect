using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using eProcurement_BLL;
using eProcurement_DAL;
using eProcurement_BLL.UserManagement;

using System.IO;
using System.Text;

public partial class UserControls_AttachmentPanel : System.Web.UI.UserControl
{

    #region Page Load
    private MainController mainController = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.mainController = new MainController((LoginUserVO)Session[SessionKey.LOGIN_USER]); 
    }

    #endregion

    #region Properties

    private string RfqNumber
    {
        get
        {
            if (ViewState["RfqNumber"] != null && ViewState["RfqNumber"].ToString() != string.Empty)
            {
                return ViewState["RfqNumber"].ToString();
            }
            else
            {
                return "";
            }
        }
        set
        {
            ViewState["RfqNumber"] = value;
        }
    }

    private bool ReadOnly
    {
        get
        {
            if (ViewState["ReadOnly"] != null)
            {
                return (bool)ViewState["ReadOnly"];
            }
            else
            {
                return true;
            }
        }
        set
        {
            ViewState["ReadOnly"] = value;
        }
    }

    private Collection<Guid> AttachmentIds
    {
        get
        {
            if (ViewState["AttachmentIds"] != null)
            {
                return (Collection<Guid>)ViewState["AttachmentIds"];
            }
            else
            {
                return new Collection<Guid>();
            }
        }
        set
        {
            ViewState["AttachmentIds"] = value;
        }
    }

    private int UploadFileSize
    {
        get
        {
            if (ViewState["UploadFileSize"] != null)
            {
                return Convert.ToInt32 (ViewState["UploadFileSize"].ToString());
            }
            else
            {
                return 0;
            }
        }
        set
        {
            ViewState["UploadFileSize"] = value;
        }
    }

    private int TotalFileSize
    {
        get
        {
            if (ViewState["TotalFileSize"] != null)
            {
                return Convert.ToInt32(ViewState["TotalFileSize"].ToString());
            }
            else
            {
                return 0;
            }
        }
        set
        {
            ViewState["TotalFileSize"] = value;
        }
    }
    #endregion

    public void InitPanel(String rfqNumber, bool readOnly)
    {
        try
        {
            RfqNumber = rfqNumber;
            ReadOnly = readOnly;

            if (readOnly)
                tblUpload.Visible = false;
            else
                tblUpload.Visible = true;

            String uploadFileSize = System.Web.Configuration.WebConfigurationManager.AppSettings["UPLOAD_FILE_SIZE"].ToString();
            String totalFileSize = System.Web.Configuration.WebConfigurationManager.AppSettings["TOTAL_FILE_SIZE"].ToString();
            if (string.IsNullOrEmpty(uploadFileSize))
                uploadFileSize = "5120000";
            if (string.IsNullOrEmpty(totalFileSize))
                totalFileSize = "20480000";

            UploadFileSize = Convert.ToInt32(uploadFileSize);
            TotalFileSize = Convert.ToInt32(totalFileSize);

            lblUploadFileSize.Text = String.Format("The size of an attachment is limited to '{0}' MB.", UploadFileSize / 1024000.0);
            lblTotalFileSize.Text = String.Format("Total size of attachments are limited to '{0}' MB.", TotalFileSize / 1024000.0);

            LoadDocument();

        }
        catch (Exception ex)
        {
            Utility.ExceptionLog(ex); 
            lblMessage.Text = ex.Message;
            tblUpload.Visible = false;
        }
    }

    public Collection<Guid> GetAddedAttachments() 
    {
        return AttachmentIds;
    } 

    #region Event Handler

    protected void btnAddFile_Click(object sender, EventArgs e)
    {
        try
        {
            if (!PageValidate())
                return;

            if (!CheckFileSize())
                return;

            // Save Documents
            Attachment objDoc = new Attachment();

            objDoc.FileName = fuAttachment.FileName;
            objDoc.FileDesc = txtAttachmentDescription.Text.Trim();
            objDoc.FileSize = fuAttachment.FileBytes.Length;
            objDoc.FileData = fuAttachment.FileBytes;
            objDoc.AttachDate = Utility.GetStoredDateValue(DateTime.Now);
            objDoc.RfqNumber = RfqNumber;

            Guid attachmentId = mainController.GetAttachmentController().AddAttachment(objDoc);
            if(string.IsNullOrEmpty(RfqNumber))
            {
                Collection<Guid> attachmentIds=AttachmentIds;
                attachmentIds.Add(attachmentId);
                AttachmentIds = attachmentIds;
            } 
            LoadDocument();
            txtAttachmentDescription.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.ExceptionLog(ex);
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnDeleteFile_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkDel; 
            Guid attachmentId;
            Collection<Attachment> attachments = new Collection<Attachment>();

            foreach (GridViewRow row in gvFileUpload.Rows)
            {
                chkDel = (CheckBox)row.FindControl("chkDeleted");

                if (chkDel.Checked)
                {
                    attachmentId = new Guid(((Label)row.FindControl("lblDocumentSid")).Text.Trim());
                    Attachment att = new Attachment();
                    att.AttachmentId = attachmentId;
                    attachments.Add(att); 
                }
            }

            if (attachments.Count > 0) 
            {
                mainController.GetAttachmentController().DeleteAttachments(attachments);

                if (string.IsNullOrEmpty(RfqNumber))
                {
                    Collection<Guid> attachmentIds = AttachmentIds;
                    foreach (Attachment att in attachments) 
                    {
                        attachmentIds.Remove(att.AttachmentId);  
                    }
                    AttachmentIds = attachmentIds;
                } 
                
                LoadDocument();
            }
        }
        catch (Exception ex)
        {
            Utility.ExceptionLog(ex);
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvFileUpload_PreRender(object sender, EventArgs e)
    {
        if (gvFileUpload.Rows.Count == 0)
            return;

        foreach (GridViewRow item in gvFileUpload.Controls[0].Controls)
        {
            if (item.RowType == DataControlRowType.Header)
            {
                StringBuilder strScript = new StringBuilder("<script language='javascript'> \n");

                //add client check for delelte action
                strScript.Append(" function ValidateDelete() { \n");
                strScript.Append("      var bDelete = false; \n");
                for (int i = 0; i < gvFileUpload.Rows.Count; i++)
                {
                    strScript.Append("     if ( document.getElementById('" +
                        gvFileUpload.Rows[i].Cells[3].FindControl("chkDeleted").ClientID + "').checked) bDelete = true; \n");
                }

                strScript.Append("      if ( bDelete ) \n");
                strScript.Append("          mainForm_onSubmit=window.confirm(\"Do you want to delete these record(s) selected?\"); \n");
                strScript.Append("      else {\n");
                strScript.Append("          alert(\"lease select at least one record to delete.\"); \n");

                strScript.Append("          mainForm_onSubmit=false; \n");
                strScript.Append("      } \n");
                strScript.Append(" } \n");
                strScript.Append("</script> \n");

                if (!Page.ClientScript.IsClientScriptBlockRegistered("CheckStatus"))
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CheckStatus", strScript.ToString());

                btnDeleteFile.Attributes.Add("onClick", "ValidateDelete();");
                return;
            }
        }
    }

    protected void gvFileUpload_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Guid docSId = new Guid(e.CommandArgument.ToString());
            DownloadDocument(docSId);
        }
    }

    protected void gvFileUpload_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkDel = (CheckBox)e.Row.FindControl("chkDeleted");
            Label lblProfileType = (Label)e.Row.FindControl("lblProfileType");
            Label lblAttachedDate = (Label)e.Row.FindControl("lblAttachedDate");
            lblAttachedDate.Text = Utility.GetShortDate(Utility.GetDateTimeFormStoredValue(Convert.ToInt64(lblAttachedDate.Text)));
            if (string.Compare(lblProfileType.Text.Trim(), mainController.GetLoginUserVO().ProfileType, true) != 0 ||
                ReadOnly)
            {
                chkDel.Enabled =false;
            }  
        }
    }
    #endregion

    #region Methods
    protected void LoadDocument()
    {
        try
        {
            Collection<Attachment> attachments = new Collection<Attachment>(); 

            if (!string.IsNullOrEmpty(RfqNumber))
            {
                attachments = mainController.GetAttachmentController().GetAttachmentList(RfqNumber);
            }
            else if (AttachmentIds.Count>0)
            {
                attachments = mainController.GetAttachmentController().GetAttachmentList(AttachmentIds);
            }

            gvFileUpload.DataSource = attachments;
            gvFileUpload.DataBind();

            lblResult.Text = attachments.Count + " record(s) found";
            lblMessage.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.ExceptionLog(ex); 
            throw ex;
        }
    }

    private void DownloadDocument(Guid docSId)
    {
        Attachment objDoc = mainController.GetAttachmentController().GetAttachment(docSId);

        // Identify the file name.
        string filename = objDoc.FileName;
        byte[] fileSize = objDoc.FileData;

        // Identify the file to download including its path.
        string filepath = Server.MapPath(@"~\Quotation" + "\\" + filename);

        if (File.Exists(filepath))
        {
            File.Delete(filepath);
        }
        // Save File.
        File.WriteAllBytes(filepath, fileSize);

        //-------------------------------------------

        Stream iStream = null;
        // Buffer to read 10K bytes in chunk:
        byte[] buffer = new Byte[5000];
        // Length of the file:
        int length;
        // Total bytes to read:
        long dataToRead;

        try
        {
            // Open the file.
            iStream = new FileStream(filepath, FileMode.Open,
                FileAccess.Read, FileShare.Read);

            // Total bytes to read:
            dataToRead = iStream.Length;

            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.AddHeader("Content-Length", fileSize.Length.ToString());

            // Read the bytes.
            while (dataToRead > 0)
            {
                // Verify that the client is connected.
                if (Response.IsClientConnected)
                {
                    // Read the data in buffer.
                    length = iStream.Read(buffer, 0, 5000);
                    // Write the data to the current output stream.
                    Response.OutputStream.Write(buffer, 0, length);
                    // Flush the data to the HTML output.
                    Response.Flush();
                    buffer = new Byte[5000];
                    dataToRead = dataToRead - length;
                }
                else
                {
                    // Prevent infinite loop if user disconnects
                    dataToRead = -1;
                }
            }
        }
        catch (Exception ex)
        {
            // Trap the error, if any.
            Utility.ExceptionLog(ex); 
        }
        finally
        {
            if (iStream != null)
            {
                // Close the file.
                iStream.Close();
            }

            // Delete the file
            File.Delete(filepath);
        }
    }

    private bool CheckFileSize()
    {
        int fileSize = fuAttachment.PostedFile.ContentLength;
        //Check uploaded file size
        if (fileSize > UploadFileSize)
        {
            lblMessage.Text = String.Format(@"Your file was not added. The size of an attachment 
                is limited to '{0}' MB.", UploadFileSize / 1024000);
            return false;
        }

        long totalSize = 0;
        Label lblProfileType, lblFileSize;
        foreach (GridViewRow row in gvFileUpload.Rows)
        {
            lblProfileType = (Label)row.FindControl("lblProfileType");
            lblFileSize = (Label)row.FindControl("lblFileSize");
            if (string.Compare(lblProfileType.Text.Trim(), mainController.GetLoginUserVO().ProfileType, true) == 0) 
            {
                totalSize += Convert.ToInt64(lblFileSize.Text);
            }  
        }
        totalSize += fileSize;
       
        //Check total file size
        if (totalSize > TotalFileSize)
        {
            lblMessage.Text = String.Format(@"Your file was not added. Total size of attachments 
                are limited to '{0}' MB.", TotalFileSize / 1024000);
            return false;
        }
        return true;
    }

    #endregion

    #region Server Side Validation

    private bool PageValidate()
    {
        if (!fuAttachment.HasFile)
        {
            lblMessage.Text = "Invalid File Path";
            return false;
        }
        lblMessage.Text = String.Empty;
        return true;
    }

    #endregion
}

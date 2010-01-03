using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;
using eProcurement_BLL.UserManagement; 
namespace eProcurement_BLL.Quotation
{
    public class AttachmentController
    {
        MainController mainController = null;
        public AttachmentController(MainController mainController) 
        {
            this.mainController = mainController;
        }

        public Collection<Attachment> GetAttachmentList(string rfqNumber)
        {
            try
            {
                string whereClause = "";
                string orderClause = "";

                whereClause = " (EBELN = '" + Utility.EscapeSQL(rfqNumber) + "') ";

                Collection<QuotationItem> items = mainController.GetDAOCreator().CreateQuotationItemDAO().RetrieveByQuery(whereClause);
                if (items.Count > 0) 
                {
                    whereClause += " OR (EBELN = '" + Utility.EscapeSQL(items[0].RequisitionNumber) + "') ";
                }

                orderClause = " PROFTYP,FILENAME asc ";
                return this.mainController.GetDAOCreator().CreateAttachmentDAO(false).RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Collection<Attachment> GetAttachmentList(Collection<Guid> attachmentIds)
        {
            try
            {
                string whereClause = "";
                string orderClause = "";

                foreach (Guid attachmentId in attachmentIds)
                {
                    if (whereClause == "")
                    {
                        whereClause += "(";
                    }
                    else
                    {
                        whereClause += " or ";
                    }
                    whereClause += "ATTCHMTID='" + attachmentId.ToString() + "'";
                }
                if (whereClause != "") whereClause += ")";

                orderClause = " PROFTYP,FILENAME asc ";
                return this.mainController.GetDAOCreator().CreateAttachmentDAO(false).RetrieveByQuery(whereClause, orderClause);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Guid AddAttachment(Attachment attachment)
        {
            try
            {
                Guid attachmentId = Guid.NewGuid();
                attachment.AttachmentId = attachmentId;
                attachment.AttachDate = Utility.GetStoredDateValue(DateTime.Now);
                attachment.ProfileType = mainController.GetLoginUserVO().ProfileType;
                attachment.CreateBy = mainController.GetLoginUserVO().UserId;
                attachment.StorePath = "";
                attachment.DelInd = "N";
                this.mainController.GetDAOCreator().CreateAttachmentDAO(false).Insert(attachment);
                return attachmentId;
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public Attachment GetAttachment(Guid attachmentId)
        {
            try
            {
                return this.mainController.GetDAOCreator().CreateAttachmentDAO(true).RetrieveByKey(attachmentId); 
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public void DeleteAttachments(Collection<Attachment> attachments)
        {
            try
            {
                foreach (Attachment att in attachments) 
                {
                    Attachment attCur = this.mainController.GetDAOCreator().CreateAttachmentDAO(false).RetrieveByKey(att.AttachmentId);
                    if (attCur != null) 
                    {
                        this.mainController.GetDAOCreator().CreateAttachmentDAO(false).Delete(attCur);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }
    }
}

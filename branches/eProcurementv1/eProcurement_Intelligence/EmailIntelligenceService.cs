using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using eProcurement_BLL.Notification;
using eProcurement_DAL;

namespace eProcurement_Intelligence
{
    public partial class EmailIntelligenceService : Form
    {

        #region CONSTANTS
        private const string SG_FUJITEC_ADDRESS = "Fujitec Corporation Pte Ltd, 204 Bedok South Avenue 1, Singapore - 469333";
        private const string SG_FUJITEC_PHONE = "Tel: +65 6241 6222";
        private const string SG_FUJITEC_FAX = "Fax: +65 6444 7626";
        private const string EMAIL_BODY = "Good Day! Dear Individual, Please download attachement. Thanks.";
        private const string SMTP_SERVER = "FUJITEC";
        private const string EMAIL_SUBJECT = "Purchase Order Information from Fujitec Singapore";
        #endregion




        eProcurement_BLL.MainController maincontroller;
              

        public EmailIntelligenceService()
        {
            InitializeComponent();

            maincontroller = new eProcurement_BLL.MainController();
        }

        private void EmailIntelligenceService_Load(object sender, EventArgs e)
        {

          //  CreateDirectoryToday();

          //  CreateEmailAttachementFile("Hello", "Hi");

          //  AmendEmailAttachementFile("Hello","Bye");

            CreateEmailSummary();

            this.Close();




        }

        private void CreateDirectoryToday()
        {
             if (!Directory.Exists(Application.StartupPath + Application.StartupPath + @"\" + DateTime.Today.ToString("yyyyMMMdd")));
            Directory.CreateDirectory(Application.StartupPath + @"\"+DateTime.Today.ToString("yyyyMMMdd"));
        }

        private void CreateEmailAttachementFile(String userid, String contents)
        {

            string filepath = Application.StartupPath + @"\" + DateTime.Today.ToString("yyyyMMMdd") + @"\" + userid + @".doc";
            // Create Email Attachement File 
            if (File.Exists(filepath) == true)
            {
                File.Delete(filepath);
            }
            StreamWriter SW;
            SW = File.CreateText(filepath);

            SW.WriteLine(contents);

            SW.Close();
 
        }

        private string GetFilePath(String userid)
        {
            return Application.StartupPath + @"\" + DateTime.Today.ToString("yyyyMMMdd") + @"\" + userid + @".doc";
        }


        private void AmendEmailAttachementFile(string userid, string contents)
        {
            String filepath = Application.StartupPath + @"\" + DateTime.Today.ToString("yyyyMMMdd") + @"\" + userid + @".doc";

            StreamWriter SW;

            SW = File.AppendText(filepath);

            SW.WriteLine(contents);

            SW.Close();

        }


    private void CreateEmailSummary()
        {
            // Create a directory with today's date
            CreateDirectoryToday();

            Collection<Notification> recipiantcoll = new Collection<Notification>();   


            recipiantcoll = maincontroller.GetNotificationController().RetrieveByQueryEmailNotificationRecipiant("0"); // 0- Not Yet notified

            if (recipiantcoll.Count > 0)
            {
                
                        

                foreach (Notification notificationrecipiant in recipiantcoll)
                {

                   if (notificationrecipiant.Recipient != "" || notificationrecipiant.Recipient != null)
                    {
                        CreateEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "Good Day!");
                        AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), SG_FUJITEC_ADDRESS);
                        AmendEmailAttachementFile(notificationrecipiant.Recipient, SG_FUJITEC_PHONE);
                        AmendEmailAttachementFile(notificationrecipiant.Recipient, SG_FUJITEC_FAX);
                        AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                        Collection<Notification> notificationmessagecoll = new Collection<Notification>();

                        // Purchase Order Created (Notification Message)
                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.OrderCreate);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "Purchase Order Created");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }




                        // Purchase Order Update (Notification Message)

                        notificationmessagecoll.Clear();

                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.OrderUpdate);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "Purchase Order Updated");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }




                        // Purchase Order Expedited (Notification Message)

                        notificationmessagecoll.Clear();

                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.OrderExpedite);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "Purchase Order Expedited");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }





                        // Purchase Order Acknowledged (Notification Message)

                        notificationmessagecoll.Clear();

                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.OrderAcknowledged);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "Purchase Order Acknowledged");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }


                        // Purchase Order Expedite Acknowledged (Notification Message)

                        notificationmessagecoll.Clear();

                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.ExpediteAcknowledged);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "Purchase Order Expedite Acknowledged");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }



                        // Purchase Order Acknowledged First Time Rejection (Notification Message)

                        notificationmessagecoll.Clear();

                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.OrderAckFirstReject);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "Purchase Order Acknowledged First Time Rejection");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }



                        // Purchase Order Expediting Ack First Time Rejection (Notification Message)

                        notificationmessagecoll.Clear();

                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.ExpediteAckFirstReject);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "Purchase Order Expediting Ack First Time Rejection");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }



                        // Contract Create (Notification Message)

                        notificationmessagecoll.Clear();

                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.ContractCreate);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "Contract Created");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }



                        // Contract Update (Notification Message)

                        notificationmessagecoll.Clear();

                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.ContractUpdate);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "Contract Updated");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }



                        // RFQ Create (Notification Message)

                        notificationmessagecoll.Clear();

                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.RFQCreate);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "RFQ Created");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }




                        // RFQ Update (Notification Message)

                        notificationmessagecoll.Clear();

                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.RFQUpdate);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "RFQ Updated");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }



                        // Goods Rejection (Notification Message)

                        notificationmessagecoll.Clear();

                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.RejectionCreate);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "Goods Rejection");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }



                        // Vendor Creation (Notification Message)

                        notificationmessagecoll.Clear();

                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.VendorCreate);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "Vendor Created");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }


                        // Vendor Updation (Notification Message)

                        notificationmessagecoll.Clear();

                        notificationmessagecoll = maincontroller.GetNotificationController().RetrieveNotificationByRecipient("0", notificationrecipiant.Recipient, eProcurement_BLL.NotificationMessage.VendorUpdate);


                        if (notificationmessagecoll.Count > 0)
                        {
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "Vendor Updated");
                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");

                            foreach (Notification notificationmessage in notificationmessagecoll)
                            {
                                AmendEmailAttachementFile(notificationrecipiant.Recipient, notificationmessage.Message);
                            }

                            AmendEmailAttachementFile(notificationrecipiant.Recipient.Trim(), "--------------------------------");
                        }


                        try
                        {

                            // Send Email Notification
                            eProcurement_BLL.Utility.SentEmailWithAttachement1(eProcurement_BLL.NotificationMessage.buyerEmail, notificationrecipiant.Email, EMAIL_SUBJECT, EMAIL_BODY, SMTP_SERVER, GetFilePath(notificationrecipiant.Recipient.Trim()));


                            // Updtae Successful Email Notification
                            maincontroller.GetNotificationController().UpdateNotificationStatus(notificationrecipiant.Recipient.Trim(), "1"); // 1 - Successfully Email Send

                        }
                        catch (Exception ex)
                        {

                            String filename = DateTime.Today.ToString("yyyyMMMdd") + @"-ErrorLog.doc";

                            if (!File.Exists(filename))
                            {
                                CreateEmailAttachementFile(filename.Trim(), "Good Day!");
                                AmendEmailAttachementFile(filename.Trim(), SG_FUJITEC_ADDRESS);
                                AmendEmailAttachementFile(filename.Trim(), SG_FUJITEC_PHONE);
                                AmendEmailAttachementFile(filename.Trim(), SG_FUJITEC_FAX);
                                AmendEmailAttachementFile(filename.Trim(), "--------------------------------");

                                AmendEmailAttachementFile(filename.Trim(), ex.ToString());
                            }
                            else
                            {                                

                                AmendEmailAttachementFile(filename.Trim(), ex.ToString());
                            }
                        }

                    }



                }
            }
            else
            {
                String filename = DateTime.Today.ToString("yyyyMMMdd") + @"-Log.doc";

                
                    CreateEmailAttachementFile(filename.Trim(), "Good Day!");
                
                    AmendEmailAttachementFile(filename.Trim(), SG_FUJITEC_ADDRESS);
                    AmendEmailAttachementFile(filename.Trim(), SG_FUJITEC_PHONE);
                    AmendEmailAttachementFile(filename.Trim(), SG_FUJITEC_FAX);
                    AmendEmailAttachementFile(filename.Trim(), "--------------------------------");

                    AmendEmailAttachementFile(filename.Trim(), "No Notification Messages Today till (" + DateTime.Now.ToString("yyyy MMM dd hh:mm tt") + ").");
                
            }

            
 
        }
        

    }
}
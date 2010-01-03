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
        eProcurement_BLL.MainController maincontroller;

        public EmailIntelligenceService()
        {
            InitializeComponent();

            maincontroller = new eProcurement_BLL.MainController();
        }

        private void EmailIntelligenceService_Load(object sender, EventArgs e)
        {

            // Create a directory with today's date

            CreateDirectoryToday();

            Collection<Notification> recipiantcoll = new Collection<Notification>();
            Collection<Notification> notificationcoll = new Collection<Notification>();


            recipiantcoll = maincontroller.GetNotificationController().RetrieveByQueryEmailNotificationRecipiant("0"); // 0- Not Yet notified

            notificationcoll = maincontroller.GetNotificationController().RetrieveByQueryEmailNotification("0"); // 0- Not Yet notifiyed

            foreach (Notification notificationrecipiant in recipiantcoll)
            {
                Collection<Notification> tempnotification = new Collection<Notification>();
               

                foreach (Notification notification in notificationcoll)
                {

                    if (notification.Recipient.Equals(notificationrecipiant.Recipient))
                    {

                        tempnotification.Add(notification);
 
                    }

                }

                


                 

 
            }

           

            CreateTextFileUser("Hello");


           
         


        }

        private void CreateDirectoryToday()
        {
             if (!Directory.Exists(Application.StartupPath + Application.StartupPath + @"\" + DateTime.Today.ToString("yyyyMMMdd"))) ;
            Directory.CreateDirectory(Application.StartupPath + @"\"+DateTime.Today.ToString("yyyyMMMdd"));
        }

        private void CreateTextFileUser(String userid)
        {
            // Create Email Attachement File 
            if (File.Exists(Application.StartupPath + @"\" + DateTime.Today.ToString("yyyyMMMdd") + @"\" + userid) == true)
            {
                File.Delete(Application.StartupPath + @"\" + DateTime.Today.ToString("yyyyMMMdd") + @"\" + userid);
            }
            StreamWriter SW;
            SW = File.CreateText(Application.StartupPath + @"\" + DateTime.Today.ToString("yyyyMMMdd") + @"\" + userid);

            SW.WriteLine("Have A Nice Day!");

            SW.Close();
 
        }


    }
}
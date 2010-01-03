using System;
using System.Collections.Generic;
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
        public EmailIntelligenceService()
        {
            InitializeComponent();
        }

        private void EmailIntelligenceService_Load(object sender, EventArgs e)
        {

            // Create a directory with today's date

            CreateDirectoryToday();

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
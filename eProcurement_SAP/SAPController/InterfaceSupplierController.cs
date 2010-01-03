using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAPInterface;
using SAP.Connector;
using eProcurement_DAL;
using eProcurement_BLL;
using eProcurement_BLL.Notification;

namespace eProcurement_SAP
{
    public class InterfaceSupplierController
    {
        private ZSUPPLIERTable supplier;

        private string aMsgstr = "";
        private int aRecCount = 0;
        private InterfaceForm aForm;
        private MainController mainController;

        public InterfaceSupplierController(InterfaceForm aForm, MainController mainController)
        {
            this.aForm = aForm;
            this.mainController = mainController;
        }

        public void GetSupplierDetail()
        {
            RetrieveSupplier retrieveSupplier;

            try
            {
                retrieveSupplier = new RetrieveSupplier();

                aForm.getLabel().Text = "Retrieval of Suppliers Data  in Progress ....";
                aForm.getLabel().Refresh();

                retrieveSupplier.GetSupplierDetails();
                supplier = retrieveSupplier.GetSupplier();

                aForm.getLabel().Text = "Update of Suppliers Data  in Progress ....";
                aForm.getLabel().Refresh();

                this.UpdateSupplier();

                aForm.getLabel().Text = "Update of Suppliers Master Data Completed";
                aForm.getLabel().Refresh();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        private void UpdateSupplier()
        {
            int wstep;

            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {

                    //---------------------------------------
                    // Get Supplier Details
                    //---------------------------------------
                    aRecCount = supplier.Count;
                    this.setParameters();
                    wstep = 10;
                    foreach (ZSUPPLIER supobj in supplier)
                    {
                        Supplier supmst = new Supplier();
                        supmst.SupplierID = supobj.Lifnr;
                        supmst.Password = supobj.Passw;
                        supmst.Title = supobj.Anred;
                        supmst.SupplierName = supobj.Name1.Trim() + " " + supobj.Name2.Trim() + " " + supobj.Name3.Trim();
                        supmst.SupplierAddress = supobj.Stras;
                        supmst.PostalCode = supobj.Pstlz;
                        supmst.Region = supobj.Regio;
                        supmst.City = supobj.City;
                        supmst.CountryCode = supobj.Land1;
                        supmst.Telephone1 = supobj.Telf1;
                        supmst.Telephone2 = supobj.Telf2;
                        supmst.FaxNo = supobj.Telfx;
                        supmst.EmailID = supobj.Email.Trim();
                        supmst.UserField = supobj.Sperq;
                        supmst.RecordStatus = "";
                        Notification notification = new Notification();
                        if (mainController.GetDAOCreator().CreateSupplierDAO().RetrieveByKey(tran, supobj.Lifnr) != null)
                        {
                            mainController.GetDAOCreator().CreateSupplierDAO().Update(tran, supmst);
                            notification.NotificationType = NotificationMessage.VendorUpdate;
                        }
                        else
                        {
                            mainController.GetDAOCreator().CreateSupplierDAO().Insert(tran, supmst);
                            notification.NotificationType = NotificationMessage.VendorCreate;
                        }

                        aMsgstr = "You have been assigned with supplier Id : " + supobj.Lifnr + ", please login with following user Id and password to access eProcurement Web Site. Please change your password at initial login.";

                        notification.NotificationId = 0;
                        notification.NotificationDate = Convert.ToInt64(System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString().PadLeft(2, '0') + System.DateTime.Now.Day.ToString().PadLeft(2, '0'));
                        notification.ReferenceNumber = supobj.Lifnr;
                        notification.ReferenceSequence = "";
                        notification.Recipient = supobj.Lifnr;
                        notification.Sender = NotificationMessage.buyerSender;
                        notification.Message = aMsgstr;
                        notification.Email = supobj.Email.Trim();
                        if (notification.Email == "")
                        {
                            notification.Email = NotificationMessage.buyerEmail;
                        }
                        notification.Status = "0";
                        this.ProcessNotification(notification);
                        aForm.getProgressBar().Increment(wstep);
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw (ex);
                }
                finally
                {
                    tran.Dispose();
                }
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public DataTable GetSupplier()
        {
            return supplier.ToADODataTable();
        }

        private void setParameters()
        {
            aForm.getProgressBar().Value = 1;
            aForm.getProgressBar().Step = 0;
            aForm.getProgressBar().Maximum = aRecCount;
            aForm.getProgressBar().Minimum = 1;
        }

        private void ProcessNotification(Notification pNotification)
        {
            try
            {
                NotificationController notificationControl = new NotificationController(mainController);
                notificationControl.InsertEmailNotification(pNotification);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

    }
}
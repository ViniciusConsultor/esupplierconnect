//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Vinss, Rajendran Vinoth Prabu
// Created Date : 26 Dec 2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This Controller class enables to provide methods for accessing Notification DAO, inorder to access database table [notification]  
//       -Insert, Delete Update and Retrieve.
//	  
// Revision History:
//    1.0:
//      Author  : Vinss
//      Date    : 26 Dec 2009
//      Comments: Created class 
//    
// Copyright 2008-2010 ISS/Fujitec
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL.Notification
{
    public class NotificationController
    {
        MainController mainController = null;
        /// <summary>
        /// public NotificationController(MainController mainController)
        /// Parameterized Constructor - Initialize MainController object
        /// </summary>
        /// <param name="mainController">mainController goes here</param>
        public NotificationController(MainController mainController)
        {
            this.mainController = mainController;
        }

        /// <summary>
        /// public void InsertEmailNotification(eProcurement_DAL.Notification notification)
        /// To Insert Email Notification
        /// </summary>
        /// <param name="notification">notification goes here</param>
        public void InsertEmailNotification(eProcurement_DAL.Notification notification)
        {
            try
            {
                mainController.GetDAOCreator().CreateNotificationDAO().Insert(notification);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        /// <summary>
        /// public void UpdateEmailNotification(eProcurement_DAL.Notification notification)
        /// To update Email Notification
        /// </summary>
        /// <param name="notification">notification goes here</param>
        public void UpdateEmailNotification(eProcurement_DAL.Notification notification)
        {
            try
            {
                mainController.GetDAOCreator().CreateNotificationDAO().Update(notification);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        /// <summary>
        /// public void DeleteEmailNotification(eProcurement_DAL.Notification notification)
        /// To delete Email Notification
        /// </summary>
        /// <param name="notification">notification goes here</param>
        public void DeleteEmailNotification(eProcurement_DAL.Notification notification)
        {
            try
            {
                mainController.GetDAOCreator().CreateNotificationDAO().Delete(notification);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        /// <summary>
        ///  public Collection<eProcurement_DAL.Notification> DeleteEmailNotification(eProcurement_DAL.Notification notification)
        /// To retrieve all Email Notification
        /// </summary>
        /// <returns>Collection<eProcurement_DAL.Notification> return here</returns>
        public Collection<eProcurement_DAL.Notification> RetrieveAllEmailNotification()
        {
            try
            {
                return mainController.GetDAOCreator().CreateNotificationDAO().RetrieveAll();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        /// <summary>
        /// public eProcurement_DAL.Notification RetrieveByKeyEmailNotification(String notificationID)
        /// Tp retrieve Email Notification By Key
        /// </summary>
        /// <param name="notificationID">notitifcationID goes here</param>
        /// <returns>eProcurement_DAL.Notification returns here</returns>
        public eProcurement_DAL.Notification RetrieveByKeyEmailNotification(String notificationID)
        {
            try
            {
                return mainController.GetDAOCreator().CreateNotificationDAO().RetrieveByKey(notificationID);
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }


       


    }
}
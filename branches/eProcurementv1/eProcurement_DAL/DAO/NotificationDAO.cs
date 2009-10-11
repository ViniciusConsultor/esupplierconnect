//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Vinss, Rajendran Vinoth Prabu
// Created Date : 11 Oct 2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class enables to provide methods for accessing database table [notification]  
//       -Insert, Delete Update and Retrieve.
//	  
// Revision History:
//    1.0:
//      Author  : Vinss
//      Date    : 11 Oct 2009
//      Comments: Created class 
//    
// Copyright 2008-2010 ISS/Fujitec
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace eProcurement_DAL
{
    ///<summary>Data Access Object - Database table [notification]</summary>
    public class NotificationDAO
    {
        #region RetrieveAll
        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <returns>
        /// Collection of Notification Object
        /// </returns>
        public static Collection<Notification> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Notification Object 
        /// </returns>
        public static Collection<Notification> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        /// <summary>
        /// Retrieve all the records from database table  
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <returns>
        /// Collection of Notification Object
        /// </returns>
        public static Collection<Notification> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        /// <summary>
        /// Retrieve all the records in a specified sort order from database table 
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Notification Object 
        /// </returns>
        public static Collection<Notification> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of Notification Object 
        /// </returns>
        public static Collection<Notification> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Notification Object 
        /// </returns>
        public static Collection<Notification> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        /// <summary>
        /// Retrieve list of record from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <returns>
        /// Collection of Notification Object 
        /// </returns>
        public static Collection<Notification> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        /// <summary>
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Notification Object 
        /// </returns>
        public static Collection<Notification> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="notificationId">Notification Id: notification.NOTIFID</param>
        /// <returns>
        /// Notification Object
        /// </returns>
        public static Notification RetrieveByKey(string notificationId)
        {
            return RetrieveByKey(null, notificationId);
        }

        /// <summary>
        /// Retrieve a record from database table for the given primary key(s)
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="notificationId">Notification Id: notification.NOTIFID</param>
        /// <returns>
        /// Notification Object
        /// </returns>
        public static Notification RetrieveByKey(EpTransaction epTran, string notificationId)
        {
            Notification entity = null;
            string whereClause = " NOTIFID='" + DataManager.EscapeSQL(notificationId) + "' ";
            
            Collection<Notification> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert a record into database table for the given Entity Object. 
        /// </summary>
        /// <param name="Notification">Notification Object</param>
        public static void Insert(Notification entity)
        {
            Insert(null, entity);
        }

        /// <summary>
        /// Insert a record into database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="Notification">Notification Object</param>
        public static void Insert(EpTransaction epTran, Notification entity)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.Text;

            //set connection
            SqlConnection connection;
            if (epTran == null)
                connection = DataManager.GetConnection();
            else
                connection = epTran.GetSqlConnection();
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            cm.Connection = connection;

            //set transaction
            if (epTran != null)
                cm.Transaction = epTran.GetSqlTransaction();

            //Check whether record exists
            Notification checkEntity = RetrieveByKey(epTran, entity.NotificationID);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO notification ([NOTIFID],[NOTIFTYPE],[NOTIFDATE],[REFNUM],[REFSEQ],[MESSAGE],[SENDER],[RECIPIENT],[EMAIL],[STATUS]) VALUES(@NOTIFID,@NOTIFTYP,@NOTIFDATE,@REFNUM,@REFSEQ,@MESSAGE,@SENDER,@RECIPIENT,@EMAIL,@STATUS])";
            SqlParameter p1 = new SqlParameter("@NOTIFID", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.NotificationId;

            SqlParameter p2 = new SqlParameter("@NOTIFTYPE", SqlDbType.VarChar, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.NotificationType;

            SqlParameter p3 = new SqlParameter("@NOTIFDATE", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p3);
            p3.Value = entity.NotificationDate;

            SqlParameter p4 = new SqlParameter("@REFNUM", SqlDbType.Char, 10);
            cm.Parameters.Add(p4);
            p4.Value = entity.ReferenceNumber;

            SqlParameter p5 = new SqlParameter("@REFSEQ", SqlDbType.Char, 5);
            cm.Parameters.Add(p5);
            p5.Value = entity.ReferenceSequence;

            SqlParameter p6 = new SqlParameter("@MESSAGE", SqlDbType.VarChar, 500);
            cm.Parameters.Add(p6);
            p6.Value = entity.Message;
           

            SqlParameter p7 = new SqlParameter("@SENDER", SqlDbType.VarChar, 20);
            cm.Parameters.Add(p7);
            p7.Value = entity.Sender;

            SqlParameter p8 = new SqlParameter("@RECIPIENT", SqlDbType.VarChar, 20);
            cm.Parameters.Add(p8);
            p8.Value = entity.Recipient;
            
            SqlParameter p9 = new SqlParameter("@EMAIL", SqlDbType.VarChar, 70);
            cm.Parameters.Add(p9);
            p9.Value = entity.Email;

            SqlParameter p10 = new SqlParameter("@STATUS", SqlDbType.Char, 1);
            cm.Parameters.Add(p10);
            p10.Value = entity.Status;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="Notification">Notification Object</param>
        public static void Update(Notification entity)
        {
            Update(null, entity);
        }

        /// <summary>
        /// Update the record on database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="Notification">Notification Object</param>
        public static void Update(EpTransaction epTran, Notification entity)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.Text;

            //set connection
            SqlConnection connection;
            if (epTran == null)
                connection = DataManager.GetConnection();
            else
                connection = epTran.GetSqlConnection();
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            cm.Connection = connection;

            //set transaction
            if (epTran != null)
                cm.Transaction = epTran.GetSqlTransaction();

            //Check whether record exists
            Notification checkEntity = RetrieveByKey(epTran, entity.NotificationId);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE notification NOTIFTYP=@NOTIFTYP,NOTIFDATE=@NOTIFDATE,REFNUM=@REFNUM,REFSEQ=@REFSEQ,MESSAGE=@MESSAGE,SENDER=@SENDER,RECIPIENT=@RECIPIENT,EMAIL=@EMAIL,STATUS=@STATUS WHERE NOTIFID=@NOTIFID";

            SqlParameter p1 = new SqlParameter("@NOTIFTYPE", SqlDbType.VarChar, 5);
            cm.Parameters.Add(p1);
            p1.Value = entity.NotificationType;

            SqlParameter p2 = new SqlParameter("@NOTIFDATE", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p2);
            p2.Value = entity.NotificationDate;

            SqlParameter p3 = new SqlParameter("@REFNUM", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.ReferenceNumber;

            SqlParameter p4 = new SqlParameter("@REFSEQ", SqlDbType.Char, 5);
            cm.Parameters.Add(p4);
            p4.Value = entity.ReferenceSequence;

            SqlParameter p5 = new SqlParameter("@MESSAGE", SqlDbType.VarChar, 500);
            cm.Parameters.Add(p5);
            p5.Value = entity.Message;


            SqlParameter p6 = new SqlParameter("@SENDER", SqlDbType.VarChar, 20);
            cm.Parameters.Add(p6);
            p6.Value = entity.Sender;

            SqlParameter p7 = new SqlParameter("@RECIPIENT", SqlDbType.VarChar, 20);
            cm.Parameters.Add(p7);
            p7.Value = entity.Recipient;

            SqlParameter p8 = new SqlParameter("@EMAIL", SqlDbType.VarChar, 70);
            cm.Parameters.Add(p8);
            p8.Value = entity.Email;

            SqlParameter p9 = new SqlParameter("@STATUS", SqlDbType.Char, 1);
            cm.Parameters.Add(p9);
            p9.Value = entity.Status;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="Notification">Notification Object</param>
        public static void Delete(Notification entity)
        {
            Delete(null, entity);
        }

        /// <summary>
        /// Delete the record from database table for the given Entity Object.
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="Notification">Notification Object</param>
        public static void Delete(EpTransaction epTran, Notification entity)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.Text;

            //set connection
            SqlConnection connection;
            if (epTran == null)
                connection = DataManager.GetConnection();
            else
                connection = epTran.GetSqlConnection();
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            cm.Connection = connection;

            //set transaction
            if (epTran != null)
                cm.Transaction = epTran.GetSqlTransaction();

            //Check whether record exists
            Notification checkEntity = RetrieveByKey(epTran, entity.NotificationId);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM notification WHERE NOTIFID=@NOTIFID";

            SqlParameter p1 = new SqlParameter("@NOTIFID", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.NotificationId;
            
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        /// Retrieve list of record in a specified sort order from database table for the given search criteria
        /// </summary>
        /// <param name="epTran">EpTransaction Object</param>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="sortClaues">Sort Clause</param>
        /// <returns>
        /// Collection of Notification Object 
        /// </returns>
        private static Collection<Notification> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<Notification> entities = new Collection<Notification>();

            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.Text;

            //set connection
            SqlConnection connection;
            if (epTran == null)
                connection = DataManager.GetConnection();
            else
                connection = epTran.GetSqlConnection();
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            cm.Connection = connection;

            //set transaction
            if (epTran != null)
                cm.Transaction = epTran.GetSqlTransaction();

            //Retrieve Data
            string selectCommand = "SELECT [NOTIFID],[NOTIFTYP],[NOTIFDATE],[REFNUM],[REFSEQ],[MESSAGE],[SENDER],[RECIPIENT],[EMAIL],[STATUS] FROM notification";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                Notification entity = new Notification();
                entity.NotificationId = rd["NOTIFID"].ToString();
                entity.NotificationType = rd["NOTIFTYP"].ToString();
                entity.NotificationDate = System.Convert.ToInt64(rd["NOTIFDATE"]);
                entity.ReferenceNumber = rd["REFNUM"].ToString();
                entity.ReferenceSequence = rd["REFSEQ"].ToString();
                entity.Message = rd["MESSAGE"].ToString();
                entity.Sender = rd["SENDER"].ToString();
                entity.Recipient = rd["RECIPIENT"].ToString();
                entity.Email = rd["EMAIL"].ToString();
                entity.Status = rd["STATUS"].ToString();              


                entities.Add(entity);

            }
            // close reader
            rd.Close();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();

            return entities;
        }
        #endregion
    }
}

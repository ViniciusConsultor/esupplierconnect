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
    public class UserDAO
    {
        #region RetrieveAll
        public static Collection<User> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public static Collection<User> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public static Collection<User> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public static Collection<User> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public static Collection<User> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public static Collection<User> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public static Collection<User> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public static Collection<User> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public static User RetrieveByKey(string userID)
        {
            return RetrieveByKey(null, userID);
        }

        public static User RetrieveByKey(EpTransaction epTran, string userID)
        {
            MaterialRequirement entity = null;
            string whereClause = " USERID='" + DataManager.EscapeSQL(userID) + "' ";

            Collection<MaterialRequirement> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public static void Insert(User entity)
        {
            Insert(null, entity);
        }

        public static void Insert(EpTransaction epTran, User entity)
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
            User checkEntity = RetrieveByKey(epTran, entity.UserId);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO USER ([USERID],[USRNAM],[USRPWD],[USRROLE],[USREMAIL],[UPDTBY],[UPDTDATE],[USRSTAT]) VALUES(@USERID,@USRNAM,@USRPWD,@USRROLE,@USREMAIL,@UPDTBY,@UPDTDATE,@USRSTAT)";

            SqlParameter p1 = new SqlParameter("@USERID", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.UserId;

            SqlParameter p2 = new SqlParameter("@USRNAM", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p2);
            p2.Value = entity.UserName;

            SqlParameter p3 = new SqlParameter("@USRPWD", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.UserPassword;

            SqlParameter p4 = new SqlParameter("@USRROLE", SqlDbType.Char, 15);
            cm.Parameters.Add(p4);
            p4.Value = entity.UserRole;

            SqlParameter p5 = new SqlParameter("@USREMAIL", SqlDbType.VarChar, 70);
            cm.Parameters.Add(p5);
            p5.Value = entity.UserEmail;

            SqlParameter p6 = new SqlParameter("@UPDTBY", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p6);
            p6.Value = entity.UpdatedBy;

            SqlParameter p7 = new SqlParameter("@UPDTDATE", SqlDbType.DateTime);
            cm.Parameters.Add(p7);
            p7.Value = entity.UpdatedDate;

            SqlParameter p8 = new SqlParameter("@USRSTAT", SqlDbType.Char, 1);
            cm.Parameters.Add(p8);
            p8.Value = entity.UserStatus;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public static void Update(User entity)
        {
            Update(null, entity);
        }

        public static void Update(EpTransaction epTran, User entity)
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
            User checkEntity = RetrieveByKey(epTran, entity.UserId);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE USER SET [USERID]=@USERID,[USRNAM]=@USRNAM,[USRPWD]=@USRPWD,[USRROLE]=@USRROLE,[USREMAIL]=@USREMAIL,[UPDTBY]=@UPDTBY,[UPDTDATE]=@UPDTDATE,[USRSTAT]=@USRSTAT WHERE USERID=@USERID";

            SqlParameter p1 = new SqlParameter("@USRNAM", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p1);
            p1.Value = entity.UserName;

            SqlParameter p2 = new SqlParameter("@USRPWD", SqlDbType.Char, 10);
            cm.Parameters.Add(p2);
            p2.Value = entity.UserPassword;

            SqlParameter p3 = new SqlParameter("@USRROLE", SqlDbType.Char, 15);
            cm.Parameters.Add(p3);
            p3.Value = entity.UserRole;

            SqlParameter p4 = new SqlParameter("@USREMAIL", SqlDbType.VarChar, 70);
            cm.Parameters.Add(p4);
            p4.Value = entity.UserEmail;

            SqlParameter p5 = new SqlParameter("@UPDTBY", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p5);
            p5.Value = entity.UpdatedBy;

            SqlParameter p6 = new SqlParameter("@UPDTDATE", SqlDbType.DateTime);
            cm.Parameters.Add(p6);
            p6.Value = entity.UpdatedDate;

            SqlParameter p7 = new SqlParameter("@USRSTAT", SqlDbType.Char, 1);
            cm.Parameters.Add(p7);
            p7.Value = entity.UserStatus;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public static void Delete(User entity)
        {
            Delete(null, entity);
        }

        public static void Delete(EpTransaction epTran, User entity)
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
            User checkEntity = RetrieveByKey(epTran, entity.UserId);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM USER WHERE USERID=@USERID";
            SqlParameter p1 = new SqlParameter("@USERID", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.UserId;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<User> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<User> entities = new Collection<User>();

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
            string selectCommand = "SELECT [USERID],[USRNAM],[USRPWD],[USRROLE],[USREMAIL] FROM USER";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                User entity = new User();
                entity.UserId = rd["USERID"].ToString();
                entity.UserName = rd["USRNAM"].ToString();
                entity.UserPassword = rd["USRPSWD"].ToString();
                entity.UserRole= rd["USRROLE"].ToString();
                entity.UserEmail = rd["USREMAIL"].ToString();
                entity.UpdatedBy = rd["UPDTBY"].ToString();
                entity.UpdatedDate = Convert.ToString(rd["UPDTDATE"]);
                entity.UserStatus = rd["USRSTAT"].ToString();

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

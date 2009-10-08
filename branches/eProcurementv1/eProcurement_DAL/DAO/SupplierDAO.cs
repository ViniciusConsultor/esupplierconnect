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
    public class SupplierDAO
    {
        #region RetrieveAll
        public static Collection<Supplier> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public static Collection<Supplier> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public static Collection<Supplier> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public static Collection<Supplier> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public static Collection<Supplier> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public static Collection<Supplier> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public static Collection<Supplier> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public static Collection<Supplier> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public static Supplier RetrieveByKey(string supplierID)
        {
            return RetrieveByKey(null, supplierID);
        }

        public static Supplier RetrieveByKey(EpTransaction epTran, string supplierID)
        {
            Supplier entity = null;
            string whereClause = " LIFNR='" + DataManager.EscapeSQL(supplierID) + "' ";
            
            Collection<Supplier> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public static void Insert(Supplier entity)
        {
            Insert(null, entity);
        }

        public static void Insert(EpTransaction epTran, Supplier entity)
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
            Supplier checkEntity = RetrieveByKey(epTran, entity.SupplierID);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO vndmst ([LIFNR],[PASSWD],[ANRED],[NAME],[ADDRESS],[PSTLZ],[KORT],[REGIO],[LAND1],[TELF1],[TELF2],[TELFX],[SPREQ],[EMAIL],[RECSTS]) VALUES(@LIFNR,@PASSWD,@ANRED,@NAME,@ADDRESS,@PSTLZ,@KORT,@REGIO,@LAND1,@TELF1,@TELF2,@TELFX,@SPREQ,@EMAIL,@RECSTS))";
            SqlParameter p1 = new SqlParameter("@LIFNR", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.SupplierID;
            SqlParameter p2 = new SqlParameter("@PASSWD", SqlDbType.Char, 10);
            cm.Parameters.Add(p2);
            p2.Value = entity.Password;
            SqlParameter p3 = new SqlParameter("@ANRED", SqlDbType.VarChar, 15);
            cm.Parameters.Add(p3);
            p3.Value = entity.Title;
            SqlParameter p4 = new SqlParameter("@NAME", SqlDbType.VarChar, 80);
            cm.Parameters.Add(p4);
            p4.Value = entity.SupplierName;
            SqlParameter p5 = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 60);
            cm.Parameters.Add(p5);
            p5.Value = entity.SupplierAddress;
            SqlParameter p6 = new SqlParameter("@PSTLZ", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p6);
            p6.Value = entity.PostalCode;
            SqlParameter p7 = new SqlParameter("@KORT", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p7);
            p7.Value = entity.City;
            SqlParameter p8 = new SqlParameter("@REGIO", SqlDbType.Char, 3);
            cm.Parameters.Add(p8);
            p8.Value = entity.Region;
            SqlParameter p9 = new SqlParameter("@LAND1", SqlDbType.Char, 3);
            cm.Parameters.Add(p9);
            p9.Value = entity.CountryCode;
            SqlParameter p10 = new SqlParameter("@TELF1", SqlDbType.VarChar, 16);
            cm.Parameters.Add(p10);
            p10.Value = entity.Telephone1;
            SqlParameter p11 = new SqlParameter("@TELF2", SqlDbType.VarChar, 16);
            cm.Parameters.Add(p11);
            p11.Value = entity.Telephone2;
            SqlParameter p12 = new SqlParameter("@TELFX", SqlDbType.VarChar, 31);
            cm.Parameters.Add(p12);
            p12.Value = entity.FaxNo;
            SqlParameter p13 = new SqlParameter("@SPREQ", SqlDbType.Char, 3);
            cm.Parameters.Add(p13);
            p13.Value = entity.UserField;
            SqlParameter p14 = new SqlParameter("@EMAIL", SqlDbType.VarChar, 100);
            cm.Parameters.Add(p14);
            p14.Value = entity.EmailID;
            SqlParameter p15 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p15);
            p15.Value = entity.RecordStatus;
            
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public static void Update(Supplier entity)
        {
            Update(null, entity);
        }

        public static void Update(EpTransaction epTran, Supplier entity)
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
            Supplier checkEntity = RetrieveByKey(epTran, entity.SupplierID);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE vndmst SET LIFNR=@LIFNR,PASSWD=@PASSWD,ANRED=@ANRED,NAME=@NAME,ADDRESS=@ADDRESS,PSTLZ=@PSTLZ,KORT=@KORT,REGIO=@REGIO,LAND1=@LAND1,TELF1=@TELF1,TELF2=@TELF2,TELFX=@TELFX,SPREQ=@SPREQ,EMAIL=@EMAIL,RECSTS=@RECSTS WHERE LIFNR=@LIFNR";
            SqlParameter p1 = new SqlParameter("@LIFNR", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.SupplierID;
            SqlParameter p2 = new SqlParameter("@PASSWD", SqlDbType.Char, 10);
            cm.Parameters.Add(p2);
            p2.Value = entity.Password;
            SqlParameter p3 = new SqlParameter("@ANRED", SqlDbType.VarChar, 15);
            cm.Parameters.Add(p3);
            p3.Value = entity.Title;
            SqlParameter p4 = new SqlParameter("@NAME", SqlDbType.VarChar, 80);
            cm.Parameters.Add(p4);
            p4.Value = entity.SupplierName;
            SqlParameter p5 = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 60);
            cm.Parameters.Add(p5);
            p5.Value = entity.SupplierAddress;
            SqlParameter p6 = new SqlParameter("@PSTLZ", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p6);
            p6.Value = entity.PostalCode;
            SqlParameter p7 = new SqlParameter("@KORT", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p7);
            p7.Value = entity.City;
            SqlParameter p8 = new SqlParameter("@REGIO", SqlDbType.Char, 3);
            cm.Parameters.Add(p8);
            p8.Value = entity.Region;
            SqlParameter p9 = new SqlParameter("@LAND1", SqlDbType.Char, 3);
            cm.Parameters.Add(p9);
            p9.Value = entity.CountryCode;
            SqlParameter p10 = new SqlParameter("@TELF1", SqlDbType.VarChar, 16);
            cm.Parameters.Add(p10);
            p10.Value = entity.Telephone1;
            SqlParameter p11 = new SqlParameter("@TELF2", SqlDbType.VarChar, 16);
            cm.Parameters.Add(p11);
            p11.Value = entity.Telephone2;
            SqlParameter p12 = new SqlParameter("@TELFX", SqlDbType.VarChar, 31);
            cm.Parameters.Add(p12);
            p12.Value = entity.FaxNo;
            SqlParameter p13 = new SqlParameter("@SPREQ", SqlDbType.Char, 3);
            cm.Parameters.Add(p13);
            p13.Value = entity.UserField;
            SqlParameter p14 = new SqlParameter("@EMAIL", SqlDbType.VarChar, 100);
            cm.Parameters.Add(p14);
            p14.Value = entity.EmailID;
            SqlParameter p15 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p15);
            p15.Value = entity.RecordStatus;
                  
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public static void Delete(Supplier entity)
        {
            Delete(null, entity);
        }

        public static void Delete(EpTransaction epTran, Supplier entity)
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
            Supplier checkEntity = RetrieveByKey(epTran, entity.SupplierID);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM vndmst WHERE LIFNR=@LIFNR";
            SqlParameter p1 = new SqlParameter("@LIFNR", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.SupplierID;
            
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<Supplier> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<Supplier> entities = new Collection<Supplier>();

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
            string selectCommand = "SELECT [LIFNR],[PASSWD],[ANRED],[NAME],[ADDRESS],[PSTLZ],[KORT],[REGIO],[LAND1],[TELF1],[TELF2],[TELFX],[SPREQ],[EMAIL],[RECSTS] FROM vndmst";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                Supplier entity = new Supplier();
                entity.SupplierID = rd["LIFNR"].ToString();
                entity.Password = rd["PASSWD"].ToString();
                entity.Title = rd["ANRED"].ToString();
                entity.SupplierName = rd["NAME"].ToString();
                entity.SupplierAddress = rd["ADDRESS"].ToString();
                entity.PostalCode = rd["PSTLZ"].ToString();
                entity.City = rd["KORT"].ToString();
                entity.Region = rd["REGIO"].ToString();
                entity.CountryCode = rd["LAND1"].ToString();
                entity.Telephone1 = rd["TELF1"].ToString();
                entity.Telephone2 = rd["TELF2"].ToString();
                entity.FaxNo = rd["TELFX"].ToString();
                entity.UserField = rd["SPREQ"].ToString();
                entity.EmailID = rd["EMAIL"].ToString();
                entity.RecordStatus = rd["RECSTS"].ToString();

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

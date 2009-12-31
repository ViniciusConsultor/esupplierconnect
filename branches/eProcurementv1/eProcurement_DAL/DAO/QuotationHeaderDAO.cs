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
    public class QuotationHeaderDAO : IQuotationHeaderDAO
    {
        #region RetrieveAll
        public override Collection<QuotationHeader> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public override Collection<QuotationHeader> RetrieveAll(string sortClause)
        {
            return Retrieve(null, "", sortClause);
        }

        public override Collection<QuotationHeader> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public override Collection<QuotationHeader> RetrieveAll(EpTransaction epTran, string sortClause)
        {
            return Retrieve(epTran, "", sortClause);
        }
        #endregion

        #region RetrieveByQuery
        public override Collection<QuotationHeader> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public override Collection<QuotationHeader> RetrieveByQuery(string whereClause, string sortClause)
        {
            return Retrieve(null, whereClause, sortClause);
        }

        public override Collection<QuotationHeader> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public override Collection<QuotationHeader> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClause)
        {
            return Retrieve(epTran, whereClause, sortClause);
        }
        #endregion

        #region RetrieveByKey
        public override QuotationHeader RetrieveByKey(string RequestNumber)
        {
            return RetrieveByKey(null, RequestNumber);
        }

        public override QuotationHeader RetrieveByKey(EpTransaction epTran, string RequestNumber)
        {
            QuotationHeader entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(RequestNumber) + "' ";

            Collection<QuotationHeader> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public override void Insert(QuotationHeader entity)
        {
            Insert(null, entity);
        }

        public override void Insert(EpTransaction epTran, QuotationHeader entity)
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
            QuotationHeader checkEntity = RetrieveByKey(epTran, entity.RequestNumber);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO rfqhdr ([EBELN],[LIFNR],[ANGDT],[ANGNR],[KDATB],[RECSTS]) VALUES(@EBELN,@LIFNR,@ANGDT,@ANGNR,@KDATB,@RECSTS)";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.RequestNumber;

            SqlParameter p2 = new SqlParameter("@LIFNR", SqlDbType.Char, 10);
            cm.Parameters.Add(p2);
            p2.Value = entity.SupplierId;
            

            SqlParameter p3 = new SqlParameter("@ANGDT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p3);
            if (entity.ExpiryDate.HasValue)
                p3.Value = entity.ExpiryDate;
            else
                p3.Value = DBNull.Value;

            SqlParameter p4 = new SqlParameter("@ANGNR", SqlDbType.Char, 10);
            cm.Parameters.Add(p4);
            p4.Value = entity.QuotationNumber;
           

            SqlParameter p5 = new SqlParameter("@KDATB", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p5);
            if (entity.QuotationDate.HasValue)
                p5.Value = entity.QuotationDate;
            else
                p5.Value = DBNull.Value;

            SqlParameter p6 = new SqlParameter("@RECSTS", SqlDbType.Char, 10);
            cm.Parameters.Add(p6);
            p6.Value = entity.RecordStatus;
            
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public override void Update(QuotationHeader entity)
        {
            Update(null, entity);
        }

        public override void Update(EpTransaction epTran, QuotationHeader entity)
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
            QuotationHeader checkEntity = RetrieveByKey(epTran, entity.RequestNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE rfqhdr set [EBELN]=@EBELN,[LIFNR]=@LIFNR,[ANGDT]=@ANGDT,[ANGNR]=@ANGNR,[KDATB]=@KDATB,[RECSTS]=@RECSTS WHERE EBELN=@EBELN";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.RequestNumber;

            SqlParameter p2 = new SqlParameter("@LIFNR", SqlDbType.Char, 10);
            cm.Parameters.Add(p2);
            p2.Value = entity.SupplierId;


            SqlParameter p3 = new SqlParameter("@ANGDT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p3);
            if (entity.ExpiryDate.HasValue)
                p3.Value = entity.ExpiryDate;
            else
                p3.Value = DBNull.Value;

            SqlParameter p4 = new SqlParameter("@ANGNR", SqlDbType.Char, 10);
            cm.Parameters.Add(p4);
            p4.Value = entity.QuotationNumber;
       
            SqlParameter p5 = new SqlParameter("@KDATB", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p5);
            p5.Value = entity.QuotationDate;


            SqlParameter p6 = new SqlParameter("@RECSTS", SqlDbType.Char, 10);
            cm.Parameters.Add(p6);
            p6.Value = entity.RecordStatus;



            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public override void Delete(QuotationHeader entity)
        {
            Delete(null, entity);
        }

        public override void Delete(EpTransaction epTran, QuotationHeader entity)
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
            QuotationHeader checkEntity = RetrieveByKey(epTran, entity.RequestNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM rfqhdr WHERE EBELN=@EBELN";
            
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.RequestNumber;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<QuotationHeader> Retrieve(EpTransaction epTran, string whereClause, string sortClause)
        {
            Collection<QuotationHeader> entities = new Collection<QuotationHeader>();

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
            string selectCommand = "SELECT [EBELN],[LIFNR],[ANGDT],[ANGNR],[KDATB],[RECSTS] FROM rfqhdr";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClause)) selectCommand += " order by " + sortClause;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                QuotationHeader entity = new QuotationHeader();

                entity.RequestNumber = rd["EBELN"].ToString();

                if (rd.IsDBNull(1))
                    entity.SupplierId = null;
                else
                    entity.SupplierId = rd["LIFNR"].ToString();

                if (rd.IsDBNull(1))
                    entity.ExpiryDate = null;
                else
                    entity.ExpiryDate = Convert.ToInt64(rd["ANGDT"]);

                if (rd.IsDBNull(1))
                    entity.QuotationNumber = null;
                else
                    entity.QuotationNumber = rd["ANGNR"].ToString();

                if (rd.IsDBNull(1))
                    entity.QuotationDate = null;
                else
                    entity.QuotationDate = Convert.ToInt64(rd["KDATB"]);

                if (rd.IsDBNull(1))
                    entity.RecordStatus = null;
                else
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
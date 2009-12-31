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
    public class QuotationItemDAO : IQuotationItemDAO
    {
        #region RetrieveAll
        public override Collection<QuotationItem> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public override Collection<QuotationItem> RetrieveAll(string sortClause)
        {
            return Retrieve(null, "", sortClause);
        }

        public override Collection<QuotationItem> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public override Collection<QuotationItem> RetrieveAll(EpTransaction epTran, string sortClause)
        {
            return Retrieve(epTran, "", sortClause);
        }
        #endregion

        #region RetrieveByQuery
        public override Collection<QuotationItem> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public override Collection<QuotationItem> RetrieveByQuery(string whereClause, string sortClause)
        {
            return Retrieve(null, whereClause, sortClause);
        }

        public override Collection<QuotationItem> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public override Collection<QuotationItem> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClause)
        {
            return Retrieve(epTran, whereClause, sortClause);
        }
        #endregion

        #region RetrieveByKey
        public override QuotationItem RetrieveByKey(string RequestNumber, string RequestSequence)
        {
            return RetrieveByKey(null, RequestNumber, RequestSequence);
        }

        public override QuotationItem RetrieveByKey(EpTransaction epTran, string RequestNumber, string RequestSequence)
        {
            QuotationItem entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(RequestNumber) + "' ";
            whereClause += "AND EBELP='" + DataManager.EscapeSQL(RequestSequence) + "'";

            Collection<QuotationItem> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public override void Insert(QuotationItem entity)
        {
            Insert(null, entity);
        }

        public override void Insert(EpTransaction epTran, QuotationItem entity)
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
            QuotationItem checkEntity = RetrieveByKey(epTran, entity.RequestNumber, entity.RequestSequence);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO rfqdtl ([EBELN],[EBELP],[MATNR],[TXZ01],[WERKS],[KTMNG],[MEINS],[NETPR],[PEINH],[NETWR],[RECSTS]) VALUES(@EBELN,@EBELP,@MATNR,@TXZ01,@WERKS,@KTMNG,@MEINS,@NETPR,@PEINH,@NETWR,@RECSTS)";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.RequestNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.RequestSequence;

             SqlParameter p3 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p3);
            p3.Value = entity.MaterialNumber;
      
            SqlParameter p4 = new SqlParameter("@TXZ01", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p4);
            p4.Value = entity.MaterialDescription;
        
            SqlParameter p5 = new SqlParameter("@WERKS", SqlDbType.Char, 4);
            cm.Parameters.Add(p5);
            p5.Value = entity.Plant;
      
            SqlParameter p6 = new SqlParameter("@KTMNG", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p6);
            if (entity.RequiredQuantity.HasValue)
                p6.Value = entity.RequiredQuantity;
            else
                p6.Value = DBNull.Value;

            SqlParameter p7 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p7);
            p7.Value = entity.UnitMeasure;
           
            SqlParameter p8 = new SqlParameter("@NETPR", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p8);
            if (entity.NetPrice.HasValue)
                p8.Value = entity.NetPrice;
            else
                p8.Value = DBNull.Value;

            SqlParameter p9 = new SqlParameter("@PEINH", SqlDbType.Decimal, 5);
            cm.Parameters.Add(p9);
            if (entity.PriceUnit.HasValue)
                p9.Value = entity.PriceUnit;
            else
                p9.Value = DBNull.Value;

            SqlParameter p10 = new SqlParameter("@NETWR", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p10);
            if (entity.NetValue.HasValue)
                p10.Value = entity.NetValue;
            else
                p10.Value = DBNull.Value;

            SqlParameter p11 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p11);
            p11.Value = entity.RecordStatus;
            
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public override void Update(QuotationItem entity)
        {
            Update(null, entity);
        }

        public override void Update(EpTransaction epTran, QuotationItem entity)
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
            QuotationItem checkEntity = RetrieveByKey(epTran, entity.RequestNumber, entity.RequestSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE rfqdtl SET [MATNR]=@MATNR,[TXZ01]=@TXZ01,[WERKS]=@WERKS,[KTMNG]=@KTMNG,[MEINS]=@MEINS,[NETPR]=@NETPR,[PEINH]=@PEINH,[NETWR]=@NETWR,[RECSTS]=@RECSTS WHERE [EBELN]=@EBELN and [EBELP]=@EBELP";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.RequestNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.RequestSequence;

            SqlParameter p3 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p3);
            p3.Value = entity.MaterialNumber;
 

            SqlParameter p4 = new SqlParameter("@TXZ01", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p4);
            p4.Value = entity.MaterialDescription;
        
            SqlParameter p5 = new SqlParameter("@WERKS", SqlDbType.Char, 4);
            cm.Parameters.Add(p5);
            p5.Value = entity.Plant;
           

            SqlParameter p6 = new SqlParameter("@KTMNG", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p6);
            if (entity.RequiredQuantity.HasValue)
                p6.Value = entity.RequiredQuantity;
            else
                p6.Value = DBNull.Value;

            SqlParameter p7 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p7);
            p7.Value = entity.UnitMeasure;         

            SqlParameter p8 = new SqlParameter("@NETPR", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p8);
            if (entity.NetPrice.HasValue)
                p8.Value = entity.NetPrice;
            else
                p8.Value = DBNull.Value;

            SqlParameter p9 = new SqlParameter("@PEINH", SqlDbType.Decimal, 5);
            cm.Parameters.Add(p9);
            if (entity.PriceUnit.HasValue)
                p9.Value = entity.PriceUnit;
            else
                p9.Value = DBNull.Value;

            SqlParameter p10 = new SqlParameter("@NETWR", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p10);
            if (entity.NetValue.HasValue)
                p10.Value = entity.NetValue;
            else
                p10.Value = DBNull.Value;

            SqlParameter p11 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p11);
            p11.Value = entity.RecordStatus;
 

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public override void Delete(QuotationItem entity)
        {
            Delete(null, entity);
        }

        public override void Delete(EpTransaction epTran, QuotationItem entity)
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
            QuotationItem checkEntity = RetrieveByKey(epTran, entity.RequestNumber, entity.RequestSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM rfqdtl WHERE EBELN=@EBELN AND EBELP=@EBELP";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.RequestNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.VarChar, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.RequestSequence;


            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<QuotationItem> Retrieve(EpTransaction epTran, string whereClause, string sortClause)
        {
            Collection<QuotationItem> entities = new Collection<QuotationItem>();

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
            string selectCommand = "SELECT [EBELN],[EBELP],[MATNR],[TXZ01],[WERKS],[KTMNG],[MEINS],[NETPR],[PEINH],[NETWR],[RECSTS] FROM rfqdtl";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClause)) selectCommand += " order by " + sortClause;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                QuotationItem entity = new QuotationItem();
                entity.RequestNumber = rd["EBELN"].ToString();
                entity.RequestSequence = rd["EBELP"].ToString();

                if (rd.IsDBNull(2))
                    entity.MaterialNumber = null;
                else
                    entity.MaterialNumber = rd["MATNR"].ToString();
                
                if (rd.IsDBNull(3))
                    entity.MaterialDescription = null;
                else
                    entity.MaterialDescription = rd["TXZ01"].ToString();

                if (rd.IsDBNull(4))
                    entity.Plant = null;
                else
                    entity.Plant = rd["WERKS"].ToString(); 

                if (rd.IsDBNull(5))
                    entity.RequiredQuantity = null;
                else
                    entity.RequiredQuantity = Convert.ToDecimal(rd["KTMNG"]);

                if (rd.IsDBNull(6))
                    entity.UnitMeasure = null;
                else
                    entity.UnitMeasure = rd["MEINS"].ToString(); 

                if (rd.IsDBNull(7))
                    entity.NetPrice = null;
                else
                    entity.NetPrice = Convert.ToDecimal(rd["NETPR"]);

                if (rd.IsDBNull(8))
                    entity.PriceUnit = null;
                else
                    entity.PriceUnit = Convert.ToDecimal(rd["PEINH"]);

                if (rd.IsDBNull(9))
                    entity.NetValue = null;
                else
                    entity.NetValue = Convert.ToDecimal(rd["NETWR"]);

                if (rd.IsDBNull(10))
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

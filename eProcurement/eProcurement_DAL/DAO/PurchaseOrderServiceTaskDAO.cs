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
    public class PurchaseOrderServiceTaskDAO
    {

        #region RetrieveAll
        public static Collection<PurchaseOrderServiceTask> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public static Collection<PurchaseOrderServiceTask> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public static Collection<PurchaseOrderServiceTask> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public static Collection<PurchaseOrderServiceTask> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public static Collection<PurchaseOrderServiceTask> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public static Collection<PurchaseOrderServiceTask> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public static Collection<PurchaseOrderServiceTask> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public static Collection<PurchaseOrderServiceTask> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public static PurchaseOrderServiceTask RetrieveByKey(string ServiceLineNumber, string ServiceLineSequence)
        {
            return RetrieveByKey(null, ServiceLineNumber, ServiceLineSequence);
        }

        public static PurchaseOrderServiceTask RetrieveByKey(EpTransaction epTran, string ServiceLineNumber, string ServiceLineSequence)
        {
            PurchaseOrderServiceTask entity =null;
            string whereClause = " LBLN1='" + DataManager.EscapeSQL(ServiceLineNumber) + "' ";
            whereClause += "AND EXTROW='" + DataManager.EscapeSQL(ServiceLineSequence) + "'";

            Collection<PurchaseOrderServiceTask> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public static void Insert(PurchaseOrderServiceTask entity)
        {
            Insert(null, entity);
        }

        public static void Insert(EpTransaction epTran, PurchaseOrderServiceTask entity)
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
            PurchaseOrderServiceTask checkEntity = RetrieveByKey(epTran, entity.ServiceLineNumber, entity.ServiceLineSequence);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO PURSRH ([LBLN1],[EXTROW],[SRVPOS],[MENGE], [MEINS], [SBRTWR], [KTEXT1]) VALUES(@LBLN1,@EXTROW, @SRVPOS, @MENGE, @MEINS, @SBRTWR, @KTEXT1)";

            SqlParameter p1 = new SqlParameter("@LBLN1", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.ServiceLineNumber;
            SqlParameter p2 = new SqlParameter("@EXTROW", SqlDbType.Char, 10);
            cm.Parameters.Add(p2);
            p2.Value = entity.ServiceLineSequence;
            SqlParameter p3 = new SqlParameter("@SRVPOS", SqlDbType.Char, 18);
            cm.Parameters.Add(p3);
            p3.Value = entity.ServiceMaterial;
            SqlParameter p4 = new SqlParameter("@MENGE", SqlDbType.Decimal,13);
            cm.Parameters.Add(p4);
            if (entity.ServiceQuantity.HasValue)
                p4.Value = entity.ServiceQuantity;
            else
                p4.Value = DBNull.Value;

            SqlParameter p5 = new SqlParameter("@MEINS", SqlDbType.Char,3);
            cm.Parameters.Add(p5);
            p5.Value = entity.UnitOfMeasure;
            SqlParameter p6 = new SqlParameter("@SBRTWR", SqlDbType.Decimal,11);
            cm.Parameters.Add(p6);
            if (entity.ServicePrice.HasValue)
                p6.Value = entity.ServicePrice;
            else
                p6.Value = DBNull.Value;

            SqlParameter p7 = new SqlParameter("@KTEXT1", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p7);
            p7.Value = entity.ServiceText;
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public static void Update(PurchaseOrderServiceTask entity)
        {
            Update(null, entity);
        }

        public static void Update(EpTransaction epTran, PurchaseOrderServiceTask entity)
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
            PurchaseOrderServiceTask checkEntity = RetrieveByKey(epTran, entity.ServiceLineNumber, entity.ServiceLineSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE PURSRH SET SRVPOS=@SRVPOS,MENGE=@MENGE,MEINS=@MEINS,SBRTWR=@SBRTWR, KTEXT1=@KTEXT1 WHERE LBLN1=@LBLN1 AND EXTROW=@EXTROW";
            SqlParameter p1 = new SqlParameter("@SRVPOS", SqlDbType.Char, 18);
            cm.Parameters.Add(p1);
            p1.Value = entity.ServiceLineSequence;
            SqlParameter p2 = new SqlParameter("@MENGE", SqlDbType.Decimal);
            cm.Parameters.Add(p2);
            if (entity.ServiceQuantity.HasValue)
                p2.Value = entity.ServiceQuantity;
            else
                p2.Value = DBNull.Value;
            
            SqlParameter p3 = new SqlParameter("@MEINS", SqlDbType.Char,3);
            cm.Parameters.Add(p3);
            p3.Value = entity.UnitOfMeasure;
            SqlParameter p4 = new SqlParameter("@SBRTWR", SqlDbType.Decimal,13);
            cm.Parameters.Add(p4);
            if (entity.ServicePrice.HasValue)
                p4.Value = entity.ServicePrice;
            else
                p4.Value = DBNull.Value;

            SqlParameter p5 = new SqlParameter("@KTEXT1", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p5);
            p5.Value = entity.ServiceText;
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public static void Delete(PurchaseOrderServiceTask entity)
        {
            Delete(null, entity);
        }

        public static void Delete(EpTransaction epTran, PurchaseOrderServiceTask entity)
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
            PurchaseOrderServiceTask checkEntity = RetrieveByKey(epTran, entity.ServiceLineNumber, entity.ServiceLineSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM PURSRH WHERE LBLN1=@LBLN1 AND EXTROW=@EXTROW";
            SqlParameter p1 = new SqlParameter("@LBLN1", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.ServiceLineNumber;
            SqlParameter p2 = new SqlParameter("@EXTROW", SqlDbType.Char, 10);
            cm.Parameters.Add(p2);
            p2.Value = entity.ServiceLineSequence;
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<PurchaseOrderServiceTask> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<PurchaseOrderServiceTask> entities = new Collection<PurchaseOrderServiceTask>();

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
            string selectCommand = "SELECT [LBLN1],[EXTROW],[SRVPOS],[MENGE],[MEINS],[SBRTWR],[KTEXT1] FROM PURSRH";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseOrderServiceTask entity = new PurchaseOrderServiceTask();
                entity.ServiceLineNumber = rd["LBLN1"].ToString();
                entity.ServiceLineSequence = rd["EXTROW"].ToString();
                entity.ServiceMaterial = rd["SRVPOS"].ToString();

                if (rd.IsDBNull(3))
                    entity.ServiceQuantity = null;
                else
                    entity.ServiceQuantity = Convert.ToDecimal(rd["MENGE"].ToString());
                
                entity.UnitOfMeasure= rd["MEINS"].ToString();

                if (rd.IsDBNull(5))
                    entity.ServicePrice = null;
                else
                    entity.ServicePrice = Convert.ToDecimal(rd["SBRTWR"].ToString());
                
                entity.ServiceText = rd["KTEXT1"].ToString();
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

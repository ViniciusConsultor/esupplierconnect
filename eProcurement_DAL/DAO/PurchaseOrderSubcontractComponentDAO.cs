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
    public class PurchaseOrderSubcontractComponentDAO
    {

        #region RetrieveAll
        public static Collection<PurchaseOrderSubcontractComponent> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public static Collection<PurchaseOrderSubcontractComponent> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public static Collection<PurchaseOrderSubcontractComponent> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public static Collection<PurchaseOrderSubcontractComponent> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public static Collection<PurchaseOrderSubcontractComponent> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public static Collection<PurchaseOrderSubcontractComponent> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public static Collection<PurchaseOrderSubcontractComponent> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public static Collection<PurchaseOrderSubcontractComponent> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public static PurchaseOrderSubcontractComponent RetrieveByKey(string orderNumber, string ItemSequenceNumber, string ComponentSequenceNumber)
        {
            return RetrieveByKey(null, orderNumber, ItemSequenceNumber, ComponentSequenceNumber);
        }

        public static PurchaseOrderSubcontractComponent RetrieveByKey(EpTransaction epTran, string orderNumber, string ItemSequenceNumber, string ComponentSequenceNumber)
        {
            PurchaseOrderSubcontractComponent entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(orderNumber) + "' ";
            whereClause += "AND EBELP='" + DataManager.EscapeSQL(ItemSequenceNumber) + "' ";
            whereClause += "AND COMPL='" + DataManager.EscapeSQL(ComponentSequenceNumber) + "'";

            Collection<PurchaseOrderSubcontractComponent> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public static void Insert(PurchaseOrderSubcontractComponent entity)
        {
            Insert(null, entity);
        }

        public static void Insert(EpTransaction epTran, PurchaseOrderSubcontractComponent entity)
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
            PurchaseOrderSubcontractComponent checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequenceNumber, entity.ComponentSequenceNumber);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO PURSBC ([EBELN],[EBELP],[COMPL],[MATNR], [MAKTX], [BDMNG], [MEINS], [STS], [RECSTS]) VALUES(@EBELN,@EBELP, @COMPL, @MATNR, @MAKTX, @BDMNG, @MEINS, @STS, @RECSTS)";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;
            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequenceNumber;
            SqlParameter p3 = new SqlParameter("@COMPL", SqlDbType.Char, 5);
            cm.Parameters.Add(p3);
            p3.Value = entity.ComponentSequenceNumber;
            SqlParameter p4 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p4);
            p4.Value = entity.MaterialNumber;
            SqlParameter p5 = new SqlParameter("@MAKTX", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p5);
            p5.Value = entity.MaterialDescription;
            SqlParameter p6 = new SqlParameter("@BDMNG", SqlDbType.Decimal);
            cm.Parameters.Add(p6);
            if (entity.ComponentQuantity.HasValue)
                p6.Value = entity.ComponentQuantity;
            else
                p6.Value = DBNull.Value;

            SqlParameter p7 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p7);
            p7.Value = entity.UnitOfMeasure;
            SqlParameter p8 = new SqlParameter("@STS", SqlDbType.Char, 1);
            cm.Parameters.Add(p8);
            p8.Value = entity.UnitOfMeasure;
            SqlParameter p9 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p9);
            p7.Value = entity.RecordStatus;
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public static void Update(PurchaseOrderSubcontractComponent entity)
        {
            Update(null, entity);
        }

        public static void Update(EpTransaction epTran, PurchaseOrderSubcontractComponent entity)
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
            PurchaseOrderSubcontractComponent checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequenceNumber, entity.ComponentSequenceNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE PURSBC SET MATNR=@MATNR,MAKTX=@MAKTX,BDMNG=@BDMNG,MEINS=@MEINS,STS=@STS,RECSTS=@RECSTS WHERE EBELN=@EBELN AND EBELP=@EBELP AND COMPL=@COMPL";
            SqlParameter p1 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p1);
            p1.Value = entity.MaterialNumber;
            SqlParameter p2 = new SqlParameter("@MAKTX", SqlDbType.VarChar,40);
            cm.Parameters.Add(p2);
            p2.Value = entity.MaterialDescription;
            SqlParameter p3 = new SqlParameter("@BDMNG", SqlDbType.Decimal);
            cm.Parameters.Add(p3);
            if (entity.ComponentQuantity.HasValue)
                p3.Value = entity.ComponentQuantity;
            else
                p3.Value = DBNull.Value;
            
            SqlParameter p4 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p4);
            p4.Value = entity.UnitOfMeasure;
            SqlParameter p5 = new SqlParameter("@STS", SqlDbType.Char, 1);
            cm.Parameters.Add(p5);
            p5.Value = entity.ItemStatus;
            SqlParameter p6 = new SqlParameter("@MEINS", SqlDbType.Char, 1);
            cm.Parameters.Add(p6);
            p6.Value = entity.RecordStatus;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public static void Delete(PurchaseOrderSubcontractComponent entity)
        {
            Delete(null, entity);
        }

        public static void Delete(EpTransaction epTran, PurchaseOrderSubcontractComponent entity)
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
            PurchaseOrderSubcontractComponent checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequenceNumber, entity.ComponentSequenceNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM PURSBC WHERE EBELN=@EBELN AND EBELP=@EBELP AND COMPL=@COMPL";
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;
            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequenceNumber;
            SqlParameter p3 = new SqlParameter("@COMPL", SqlDbType.Char, 5);
            cm.Parameters.Add(p3);
            p3.Value = entity.ComponentSequenceNumber;
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<PurchaseOrderSubcontractComponent> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<PurchaseOrderSubcontractComponent> entities = new Collection<PurchaseOrderSubcontractComponent>();

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
            string selectCommand = "SELECT [EBELN],[EBELP],[COMPL],[MATNR],[MAKTX],[BDMNG],[MEINS],[STS],[RECSTS] FROM PURSBC";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseOrderSubcontractComponent entity = new PurchaseOrderSubcontractComponent();
                entity.OrderNumber = rd["EBELN"].ToString();
                entity.ItemSequenceNumber = rd["EBELP"].ToString();
                entity.ComponentSequenceNumber = rd["COMPL"].ToString();
                entity.MaterialNumber = rd["MATNR"].ToString();
                entity.MaterialDescription = rd["MAKTX"].ToString();

                if (rd.IsDBNull(5))
                    entity.ComponentQuantity = null;
                else
                    entity.ComponentQuantity = Convert.ToDecimal(rd["BDMNG"].ToString());
                entity.UnitOfMeasure = rd["MEINS"].ToString();
                entity.ItemStatus = rd["STS"].ToString();
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

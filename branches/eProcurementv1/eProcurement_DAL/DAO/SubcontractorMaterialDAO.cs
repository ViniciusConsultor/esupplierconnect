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
    public class SubcontractorMaterialDAO
    {
        #region RetrieveAll
        public static Collection<SubcontractorMaterial> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public static Collection<SubcontractorMaterial> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public static Collection<SubcontractorMaterial> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public static Collection<SubcontractorMaterial> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion
        #region RetrieveByQuery
        public static Collection<SubcontractorMaterial> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public static Collection<SubcontractorMaterial> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public static Collection<SubcontractorMaterial> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public static Collection<SubcontractorMaterial> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion
        #region RetrieveByKey
        public static SubcontractorMaterial RetrieveByKey(string orderNumber, string ItemSequence, string ComponentSequence)
        {
            return RetrieveByKey(null, orderNumber, ItemSequence, ComponentSequence);
        }

        public static SubcontractorMaterial RetrieveByKey(EpTransaction epTran, string orderNumber, string ItemSequence, string ComponentSequence)
        {
            SubcontractorMaterial entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(orderNumber) + "' ";
            whereClause += "AND EBELP='" + DataManager.EscapeSQL(ItemSequence) + "' ";
            whereClause += "AND COMPL='" + DataManager.EscapeSQL(ComponentSequence) + "'";

            Collection<SubcontractorMaterial> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
       #endregion
        #region Insert
        public static void Insert(SubcontractorMaterial entity)
        {
            Insert(null, entity);
        }

        public static void Insert(EpTransaction epTran, SubcontractorMaterial entity)
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
            SubcontractorMaterial checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.ComponentSequence);
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
            p2.Value = entity.ItemSequence;
            SqlParameter p3 = new SqlParameter("@COMPL", SqlDbType.Char, 5);
            cm.Parameters.Add(p3);
            p3.Value = entity.ComponentSequence;
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
            p9.Value = entity.RecordStatus;
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public static void Update(SubcontractorMaterial entity)
        {
            Update(null, entity);
        }

        public static void Update(EpTransaction epTran, SubcontractorMaterial entity)
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
            SubcontractorMaterial checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.ComponentSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE PURSBC SET MATNR=@MATNR,MAKTX=@MAKTX,BDMNG=@BDMNG,MEINS=@MEINS,STS=@STS,RECSTS=@RECSTS WHERE EBELN=@EBELN AND EBELP=@EBELP AND COMPL=@COMPL";
            SqlParameter p1 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p1);
            p1.Value = entity.MaterialNumber;
            SqlParameter p2 = new SqlParameter("@MAKTX", SqlDbType.VarChar, 40);
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
        public static void Delete(SubcontractorMaterial entity)
        {
            Delete(null, entity);
        }

        public static void Delete(EpTransaction epTran, SubcontractorMaterial entity)
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
            PurchaseOrderSubcontractComponent checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.ComponentSequence);
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
            p2.Value = entity.ItemSequence;
            SqlParameter p3 = new SqlParameter("@COMPL", SqlDbType.Char, 5);
            cm.Parameters.Add(p3);
            p3.Value = entity.ComponentSequence;
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
          #endregion
        #region private methods
        private static Collection<SubcontractorMaterial> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<SubcontractorMaterial> entities = new Collection<SubcontractorMaterial>();

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
                SubcontractorMaterial entity = new SubcontractorMaterial();
                entity.OrderNumber = rd["EBELN"].ToString();
                entity.ItemSequence = rd["EBELP"].ToString();
                entity.ComponentSequence = rd["COMPL"].ToString();
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

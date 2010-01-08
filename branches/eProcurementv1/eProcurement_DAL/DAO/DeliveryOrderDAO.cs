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
    public class DeliveryOrderDAO : IDeliveryOrderDAO
    {
        #region RetrieveAll
        public override Collection<DeliveryOrder> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public override Collection<DeliveryOrder> RetrieveAll(string sortClause)
        {
            return Retrieve(null, "", sortClause);
        }

        public override Collection<DeliveryOrder> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public override Collection<DeliveryOrder> RetrieveAll(EpTransaction epTran, string sortClause)
        {
            return Retrieve(epTran, "", sortClause);
        }
        #endregion

        #region RetrieveByQuery
        public override Collection<DeliveryOrder> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public override Collection<DeliveryOrder> RetrieveByQuery(string whereClause, string sortClause)
        {
            return Retrieve(null, whereClause, sortClause);
        }

        public override Collection<DeliveryOrder> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public override Collection<DeliveryOrder> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClause)
        {
            return Retrieve(epTran, whereClause, sortClause);
        }
        #endregion

        #region RetrieveByKey
        public override DeliveryOrder RetrieveByKey(string OrderNumber, string ItemSequence, string DeliveryNumber)
        {
            return RetrieveByKey(null, OrderNumber, ItemSequence, DeliveryNumber);
        }

        public override DeliveryOrder RetrieveByKey(EpTransaction epTran, string OrderNumber, string ItemSequence, string DeliveryNumber)
        {
            DeliveryOrder entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(OrderNumber) + "' ";
            whereClause += "AND EBELP='" + DataManager.EscapeSQL(ItemSequence) + "' ";
            whereClause += "AND VBELN='" + DataManager.EscapeSQL(DeliveryNumber) + "'";

            Collection<DeliveryOrder> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public override void Insert(DeliveryOrder entity)
        {
            Insert(null, entity);
        }

        public override void Insert(EpTransaction epTran, DeliveryOrder entity)
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
            DeliveryOrder checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.DeliveryNumber);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO dlvord ([EBELN],[EBELP],[VBELN],[MATNR],[BEDAT],[WEMNG],[RECSTS],[LIFNR]) VALUES(@EBELN,@EBELP,@VBELN,@MATNR,@BEDAT,@WEMNG,@RECSTS,@LIFNR)";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;

            SqlParameter p3 = new SqlParameter("@VBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.DeliveryNumber;

            SqlParameter p4 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p4);
            p4.Value = entity.MaterialNumber;

            SqlParameter p5 = new SqlParameter("@BEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p5);
            if (entity.DeliveryDate.HasValue)
                p5.Value = entity.DeliveryDate;
            else
                p5.Value = DBNull.Value;

            SqlParameter p6 = new SqlParameter("@WEMNG", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p6);
            if (entity.DeliveryQuantity.HasValue)
                p6.Value = entity.DeliveryQuantity;
            else
                p6.Value = DBNull.Value;

            SqlParameter p7 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p7);
            p7.Value = entity.RecordStatus;

            SqlParameter p8 = new SqlParameter("@LIFNR", SqlDbType.NVarChar,10);
            cm.Parameters.Add(p8);
            p8.Value = entity.SupplierID;
  

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public override void Update(DeliveryOrder entity)
        {
            Update(null, entity);
        }

        public override void Update(EpTransaction epTran, DeliveryOrder entity)
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
            DeliveryOrder checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.DeliveryNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE dvlord SET [MATNR]=@MATNR,[BEDAT]=@BEDAT,[WEMNG]=@WEMNG,[RECSTS]=@RECSTS WHERE [EBELN]=@EBELN and [EBELP]=@EBELP and [VBELN]=@VBELN";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;

            SqlParameter p3 = new SqlParameter("@VBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.DeliveryNumber;

            SqlParameter p4 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p4);
            p4.Value = entity.MaterialNumber;
            
            SqlParameter p5 = new SqlParameter("@BEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p5);
            if (entity.DeliveryDate.HasValue)
                p5.Value = entity.DeliveryDate;
            else
                p5.Value = DBNull.Value;

            SqlParameter p6 = new SqlParameter("@WEMNG", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p6);
            if (entity.DeliveryQuantity.HasValue)
                p6.Value = entity.DeliveryQuantity;
            else
                p6.Value = DBNull.Value;

            SqlParameter p7 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p7);
            p7.Value = entity.RecordStatus;
            
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public override void Delete(DeliveryOrder entity)
        {
            Delete(null, entity);
        }

        public override void Delete(EpTransaction epTran, DeliveryOrder entity)
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
            DeliveryOrder checkEntity = RetrieveByKey(epTran, entity.OrderNumber, entity.ItemSequence, entity.DeliveryNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM dlvord WHERE EBELN=@EBELN AND EBELP=@EBELP AND VBELN=@VBELN";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.OrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;

            SqlParameter p3 = new SqlParameter("@VBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.DeliveryNumber;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<DeliveryOrder> Retrieve(EpTransaction epTran, string whereClause, string sortClause)
        {
            Collection<DeliveryOrder> entities = new Collection<DeliveryOrder>();

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
            string selectCommand = "SELECT [EBELN],[EBELP],[VBELN],[MATNR],[BEDAT],[WEMNG],[RECSTS],[LIFNR] FROM dlvord";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClause)) selectCommand += " order by " + sortClause;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                DeliveryOrder entity = new DeliveryOrder();
                entity.OrderNumber = rd["EBELN"].ToString();
                entity.ItemSequence = rd["EBELP"].ToString();
                entity.DeliveryNumber = rd["VBELN"].ToString();

                if (rd.IsDBNull(4))
                    entity.MaterialNumber = null;
                else
                    entity.MaterialNumber = rd["MATNR"].ToString();

                if (rd.IsDBNull(5))
                    entity.DeliveryDate = null;
                else
                    entity.DeliveryDate = Convert.ToInt64(rd["BEDAT"]);

                if (rd.IsDBNull(6))
                    entity.DeliveryQuantity = null;
                else
                    entity.DeliveryQuantity = Convert.ToDecimal(rd["WEMNG"]);

                if (rd.IsDBNull(7))
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

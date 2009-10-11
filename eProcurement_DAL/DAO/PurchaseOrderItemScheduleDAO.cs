using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace eProcurement_DAL
{
    public class PurchaseOrderItemScheduleDAO
    {
        #region RetrieveAll
        public static Collection<PurchaseOrderItemSchedule> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }
        
        public static Collection<PurchaseOrderItemSchedule> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public static Collection<PurchaseOrderItemSchedule> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public static Collection<PurchaseOrderItemSchedule> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public static Collection<PurchaseOrderItemSchedule> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public static Collection<PurchaseOrderItemSchedule> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public static Collection<PurchaseOrderItemSchedule> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public static Collection<PurchaseOrderItemSchedule> RetrieveByQuery
            (EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public static PurchaseOrderItemSchedule RetrieveByKey
            (string orderNumber, string ItemSequenceNO, string ScheduleSequenceNo)
        {
            return RetrieveByKey(null, orderNumber, ItemSequenceNO, ScheduleSequenceNo);
        }

        public static PurchaseOrderItemSchedule RetrieveByKey
            (EpTransaction epTran, string orderNumber, string ItemSequenceNO, string ScheduleSequenceNo)
        {
            PurchaseOrderItemSchedule entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(orderNumber) + "' ";
            whereClause += "AND EBELP='" + DataManager.EscapeSQL(ItemSequenceNO) + "' AND ETENR = '" + DataManager.EscapeSQL(ScheduleSequenceNo) + "'";

            Collection<PurchaseOrderItemSchedule> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public static void Insert(PurchaseOrderItemSchedule entity)
        {
            Insert(null, entity);
        }

        public static void Insert(EpTransaction epTran, PurchaseOrderItemSchedule entity)
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
            PurchaseOrderItemSchedule checkEntity = RetrieveByKey(epTran, entity.PurchaseOrderNumber, entity.PurchaseOrderItemSequence, entity.PurchaseOrderScheduleSequence);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO PURSCH ([EBELN], [EBELP], [MATNR], [ETENR], [SLFDAT], [MENGE], [EINDT], [WEMNG], [ACKDT], [RECSTS], [PRMDT]) VALUES(@EBELN, @EBELP, @MATNR, @ETENR, @SLFDAT, @MENGE, @EINDT, @WEMNG, @ACKDT, @RECSTS, @PRMDT)";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.PurchaseOrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.PurchaseOrderScheduleSequence;

            SqlParameter p3 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p3);
            p3.Value = entity.MaterialNumber;

            SqlParameter p4 = new SqlParameter("@ETENR", SqlDbType.Char, 4);
            cm.Parameters.Add(p4);
            p4.Value = entity.PurchaseOrderScheduleSequence;

            SqlParameter p5 = new SqlParameter("@SLFDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p5);
            if (entity.OrderItemScheduleDate.HasValue)
                p5.Value = entity.OrderItemScheduleDate.Value;
            else
                p5.Value = DBNull.Value;

            SqlParameter p6 = new SqlParameter("@MENGE", SqlDbType.Decimal, 4);
            cm.Parameters.Add(p6);
            if (entity.DeliveryScheduleQuantity.HasValue)
                p6.Value = entity.DeliveryScheduleQuantity;
            else
                p6.Value = DBNull.Value;

            SqlParameter p7 = new SqlParameter("@EINDT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p7);
            if (entity.DeliveryDate.HasValue)
                p7.Value = entity.DeliveryDate;
            else
                p7.Value = DBNull.Value;

            SqlParameter p8 = new SqlParameter("@WEMNG", SqlDbType.Decimal, 4);
            cm.Parameters.Add(p8);
            if (entity.DeliveredQuantity.HasValue)
                p8.Value = entity.DeliveredQuantity;
            else
                p8.Value = DBNull.Value;

            SqlParameter p9 = new SqlParameter("@ACKDT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p9);
            if (entity.AcknowledgementDate.HasValue)
                p9.Value = entity.AcknowledgementDate;
            else
                p9.Value = DBNull.Value;

            SqlParameter p10 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p10);
            p10.Value = entity.RecordStatus;

            SqlParameter p11 = new SqlParameter("@PRMDT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p11);
            if (entity.ExpeditingPromiseDate.HasValue)
                p11.Value = entity.ExpeditingPromiseDate;
            else
                p11.Value = DBNull.Value;
            
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public static void Update(PurchaseOrderItemSchedule entity)
        {
            Update(null, entity);
        }

        public static void Update(EpTransaction epTran, PurchaseOrderItemSchedule entity)
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
            PurchaseOrderItemSchedule checkEntity = RetrieveByKey(epTran, entity.PurchaseOrderNumber, entity.PurchaseOrderItemSequence, entity.PurchaseOrderScheduleSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE PURSCH SET MATNR = @MATNR, SLFDAT = @SLFDAT , MENGE = @MENGE, EINDT = @EINDT , WEMNG = @WEMNG, ACKDT = @ACKDT , RECSTS = @RECSTS, PRMDT = @PRMDT WHERE EBELN=@EBELN AND EBELP=@EBELP AND ETENR = @ETENR ";
            
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.PurchaseOrderNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.PurchaseOrderItemSequence;

            SqlParameter p3 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p3);
            p3.Value = entity.MaterialNumber;

            SqlParameter p4 = new SqlParameter("@ETENR", SqlDbType.Char, 4);
            cm.Parameters.Add(p4);
            p4.Value = entity.PurchaseOrderScheduleSequence;

            SqlParameter p5 = new SqlParameter("@SLFDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p5);
            if(entity.OrderItemScheduleDate.HasValue) 
                p5.Value = entity.OrderItemScheduleDate.Value;
            else
                p5.Value = DBNull.Value ;

            SqlParameter p6 = new SqlParameter("@MENGE", SqlDbType.Decimal, 4);
            cm.Parameters.Add(p6);
            if (entity.DeliveryScheduleQuantity.HasValue) 
                p6.Value = entity.DeliveryScheduleQuantity;
            else
                p6.Value = DBNull.Value;

            SqlParameter p7 = new SqlParameter("@EINDT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p7);
            if (entity.DeliveryDate.HasValue)
                p7.Value = entity.DeliveryDate;
            else
                p7.Value = DBNull.Value;

            SqlParameter p8 = new SqlParameter("@WEMNG", SqlDbType.Decimal, 4);
            cm.Parameters.Add(p8);
            if (entity.DeliveredQuantity.HasValue)
                p8.Value = entity.DeliveredQuantity;
            else
                p8.Value = DBNull.Value;

            SqlParameter p9 = new SqlParameter("@ACKDT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p9);
            if (entity.AcknowledgementDate.HasValue)
                p9.Value = entity.AcknowledgementDate;
            else
                p9.Value = DBNull.Value;

            SqlParameter p10 = new SqlParameter("@RECSTS", SqlDbType.Char, 1);
            cm.Parameters.Add(p10);
            p10.Value = entity.RecordStatus;

            SqlParameter p11 = new SqlParameter("@PRMDT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p11);
            if (entity.ExpeditingPromiseDate.HasValue)
                p11.Value = entity.ExpeditingPromiseDate;
            else
                p11.Value = DBNull.Value;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public static void Delete(PurchaseOrderItemSchedule entity)
        {
            Delete(null, entity);
        }

        public static void Delete(EpTransaction epTran, PurchaseOrderItemSchedule entity)
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
            
            PurchaseOrderItemSchedule checkEntity = RetrieveByKey
                (epTran, entity.PurchaseOrderNumber, entity.PurchaseOrderItemSequence, entity.PurchaseOrderScheduleSequence);

            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM PURSCH WHERE EBELN=@EBELN AND EBELP=@EBELP AND ETENR = @ETENR ";

            SqlParameter p3 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p3);
            p3.Value = entity.PurchaseOrderNumber ;

            SqlParameter p4 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p4);
            p4.Value = entity.PurchaseOrderItemSequence ;


            SqlParameter p5 = new SqlParameter("@ETENR", SqlDbType.Char, 4);
            cm.Parameters.Add(p5);
            p5.Value = entity.PurchaseOrderScheduleSequence ;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<PurchaseOrderItemSchedule> Retrieve(
            EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<PurchaseOrderItemSchedule> entities = new Collection<PurchaseOrderItemSchedule>();

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
            string selectCommand = "SELECT [EBELN], [EBELP], [MATNR], [ETENR], [SLFDAT], [MENGE], [EINDT], " + 
                                   "       [WEMNG], [ACKDT] , [RECSTS], [PRMDT] FROM PURSCH";

            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                PurchaseOrderItemSchedule entity = new PurchaseOrderItemSchedule();

                entity.PurchaseOrderNumber  = rd["EBELN"].ToString();
                entity.PurchaseOrderItemSequence = rd["EBELP"].ToString();
                entity.MaterialNumber  = rd["MATNR"].ToString();
                entity.PurchaseOrderScheduleSequence = rd["ETENR"].ToString();
                
                if (rd.IsDBNull(4))
                    entity.OrderItemScheduleDate = null;
                else
                    entity.OrderItemScheduleDate  =Convert.ToInt64(rd["SLFDAT"]);

                if (rd.IsDBNull(5))
                    entity.DeliveryScheduleQuantity = null;
                else
                    entity.DeliveryScheduleQuantity = Convert.ToDecimal(rd["MENGE"]);

                if (rd.IsDBNull(6))
                    entity.DeliveryDate = null;
                else
                    entity.DeliveryDate = Convert.ToInt64(rd["EINDT"]);

                if (rd.IsDBNull(7))
                    entity.DeliveredQuantity = null;
                else
                    entity.DeliveredQuantity = Convert.ToDecimal(rd["WEMNG"]);

                if (rd.IsDBNull(8))
                    entity.AcknowledgementDate = null;
                else
                    entity.AcknowledgementDate = Convert.ToInt64(rd["ACKDT"]);

                entity.RecordStatus  = rd["RECSTS"].ToString();

                if (rd.IsDBNull(10))
                    entity.ExpeditingPromiseDate = null;
                else
                    entity.ExpeditingPromiseDate = Convert.ToInt64(rd["PRMDT"]);

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
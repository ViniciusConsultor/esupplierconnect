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
    public class RequisitionItemDAO
    {
        #region RetrieveAll
        public static Collection<RequisitionItem> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public static Collection<RequisitionItem> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public static Collection<RequisitionItem> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public static Collection<RequisitionItem> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public static Collection<RequisitionItem> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public static Collection<RequisitionItem> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public static Collection<RequisitionItem> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public static Collection<RequisitionItem> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public static RequisitionItem RetrieveByKey(string requisitionNumber, string itemSequence)
        {
            return RetrieveByKey(null, requisitionNumber, itemSequence);
        }

        public static RequisitionItem RetrieveByKey(EpTransaction epTran, string requisitionNumber, string itemSequence)
        {
            RequisitionItem entity = null;
            string whereClause = " BANFN='" + DataManager.EscapeSQL(requisitionNumber) + "' ";
            whereClause += "AND BNFPO='" + DataManager.EscapeSQL(itemSequence) + "'";

            Collection<RequisitionItem> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public static void Insert(RequisitionItem entity)
        {
            Insert(null, entity);
        }

        public static void Insert(EpTransaction epTran, RequisitionItem entity)
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
            RequisitionItem checkEntity = RetrieveByKey(epTran, entity.RequisitionNumber, entity.ItemSequence);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO reqdtl ([BANFN],[BNFPO],[EKGRP],[MATNR],[TXZ01],[WERKS],[MENGE],[MEINS],[LFDAT],[PREIS],[PEINH],[EBELN],[EBELP],[BEDAT],[WAERS],[RLWRT]) VALUES(@BANFN,@BNFPO,@EKGRP,@MATNR,@TXZ01,@WERKS,@MENGE,@MEINS,@LFDAT,@PREIS,@PEINH,@EBELN,@EBELP,@BEDAT,@WAERS,@RLWRT)";

            SqlParameter p1 = new SqlParameter("@BANFN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.RequisitionNumber;

            SqlParameter p2 = new SqlParameter("@BNFPO", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;

            SqlParameter p3 = new SqlParameter("@EKGRP", SqlDbType.Char, 4);
            cm.Parameters.Add(p3);
            p3.Value = entity.PurchasingGroup;

            SqlParameter p4 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p4);
            p4.Value = entity.MaterialNumber;

            SqlParameter p5 = new SqlParameter("@TXZ01", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p5);
            p5.Value = entity.MaterialDescription;

            SqlParameter p6 = new SqlParameter("@WERKS", SqlDbType.Char, 4);
            cm.Parameters.Add(p6);
            p6.Value = entity.Plant;

            SqlParameter p7 = new SqlParameter("@MENGE", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p7);
            if (entity.RequiredQuantity.HasValue)
                p7.Value = entity.RequiredQuantity;
            else
                p7.Value = DBNull.Value;

            SqlParameter p8 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p8);
            p8.Value = entity.UnitOfMeasure;

            SqlParameter p9 = new SqlParameter("@LFDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p9);
            if (entity.RequiredDate.HasValue)
                p9.Value = entity.RequiredDate;
            else
                p9.Value = DBNull.Value;
                        SqlParameter p10 = new SqlParameter("@PREIS", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p10);
            if (entity.EstimatedPrice.HasValue)
                p10.Value = entity.EstimatedPrice;
            else
                p10.Value = DBNull.Value;

            SqlParameter p11 = new SqlParameter("@PEINH", SqlDbType.Decimal, 5);
            cm.Parameters.Add(p11);
            if (entity.UnitPrice.HasValue)
                p11.Value = entity.UnitPrice;
            else
                p11.Value = DBNull.Value;

            SqlParameter p12 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p12);
            p12.Value = entity.OrderNumber;

            SqlParameter p13 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p13);
            p13.Value = entity.SequenceNumber;

            SqlParameter p14 = new SqlParameter("@BEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p14);
            if (entity.OrderDate.HasValue)
                p14.Value = entity.OrderDate;
            else
                p14.Value = DBNull.Value;

            SqlParameter p15 = new SqlParameter("@WAERS", SqlDbType.Char, 3);
            cm.Parameters.Add(p15);
            p15.Value = entity.CurrencyId;

            SqlParameter p16 = new SqlParameter("@RLWRT", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p16);
            if (entity.TotalValue.HasValue)
                p16.Value = entity.TotalValue;
            else
                p16.Value = DBNull.Value;
                     
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public static void Update(RequisitionItem entity)
        {
            Update(null, entity);
        }

        public static void Update(EpTransaction epTran, RequisitionItem entity)
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
            RequisitionItem checkEntity = RetrieveByKey(epTran, entity.RequisitionNumber, entity.ItemSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE  reqdtl SET [EKGRP]=@EKGRP,[MATNR]=@MATNR,[TXZ01]=@TXZ01,[WERKS]=@WERKS,[MENGE]=@MENGE,[MEINS]=@MEINS,[LFDAT]=@LFDAT,[PREIS]=@PREIS,[PEINH]=@PEINH,[EBELN]=@EBELN,[EBELP]=@EBELP,[BEDAT]=@BEDAT,[WAERS]=@WAERS,[RLWRT]=@RLWRT WHERE [BANFN]=@BANFN and [BNFPO]=@BNFPO";

            SqlParameter p1 = new SqlParameter("@BANFN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.RequisitionNumber;

            SqlParameter p2 = new SqlParameter("@BNFPO", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;

            SqlParameter p3 = new SqlParameter("@EKGRP", SqlDbType.Char, 4);
            cm.Parameters.Add(p3);
            p3.Value = entity.PurchasingGroup;

            SqlParameter p4 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p4);
            p4.Value = entity.MaterialNumber;

            SqlParameter p5 = new SqlParameter("@TXZ01", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p5);
            p5.Value = entity.MaterialDescription;

            SqlParameter p6 = new SqlParameter("@WERKS", SqlDbType.Char, 4);
            cm.Parameters.Add(p6);
            p6.Value = entity.Plant;

            SqlParameter p7 = new SqlParameter("@MENGE", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p7);
            if (entity.RequiredQuantity.HasValue)
                p7.Value = entity.RequiredQuantity;
            else
                p7.Value = DBNull.Value;

            SqlParameter p8 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p8);
            p8.Value = entity.UnitOfMeasure;

            SqlParameter p9 = new SqlParameter("@LFDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p9);
            if (entity.RequiredDate.HasValue)
                p9.Value = entity.RequiredDate;
            else
                p9.Value = DBNull.Value;
            SqlParameter p10 = new SqlParameter("@PREIS", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p10);
            if (entity.EstimatedPrice.HasValue)
                p10.Value = entity.EstimatedPrice;
            else
                p10.Value = DBNull.Value;

            SqlParameter p11 = new SqlParameter("@PEINH", SqlDbType.Decimal, 5);
            cm.Parameters.Add(p11);
            if (entity.UnitPrice.HasValue)
                p11.Value = entity.UnitPrice;
            else
                p11.Value = DBNull.Value;

            SqlParameter p12 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p12);
            p12.Value = entity.OrderNumber;

            SqlParameter p13 = new SqlParameter("@EBELP", SqlDbType.Char, 5);
            cm.Parameters.Add(p13);
            p13.Value = entity.SequenceNumber;

            SqlParameter p14 = new SqlParameter("@BEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p14);
            if (entity.OrderDate.HasValue)
                p14.Value = entity.OrderDate;
            else
                p14.Value = DBNull.Value;

            SqlParameter p15 = new SqlParameter("@WAERS", SqlDbType.Char, 3);
            cm.Parameters.Add(p15);
            p15.Value = entity.CurrencyId;

            SqlParameter p16 = new SqlParameter("@RLWRT", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p16);
            if (entity.TotalValue.HasValue)
                p16.Value = entity.TotalValue;
            else
                p16.Value = DBNull.Value;
            
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public static void Delete(RequisitionItem entity)
        {
            Delete(null, entity);
        }

        public static void Delete(EpTransaction epTran, RequisitionItem entity)
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
            RequisitionItem checkEntity = RetrieveByKey(epTran, entity.RequisitionNumber, entity.ItemSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM reqdtl WHERE BANFN=@BANFN AND BNFPO=@BNFPO";

            SqlParameter p1 = new SqlParameter("@BANFN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.RequisitionNumber;

            SqlParameter p2 = new SqlParameter("@BNFPO", SqlDbType.Char, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ItemSequence;


            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private static Collection<RequisitionItem> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<RequisitionItem> entities = new Collection<RequisitionItem>();

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
            string selectCommand = "SELECT [BANFN],[BNFPO],[EKGRP],[MATNR],[TXZ01],[WERKS],[MENGE],[MEINS],[LFDAT],[PREIS],[PEINH],[EBELN],[EBELP],[BEDAT],[WAERS],[RLWRT] FROM reqdtl";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                RequisitionItem entity = new RequisitionItem();
                entity.RequisitionNumber = rd["BANFN"].ToString();
                entity.ItemSequence = rd["BNFPO"].ToString();
                entity.PurchasingGroup = rd["EKGRP"].ToString();
                entity.MaterialNumber = rd["MATNR"].ToString();
                entity.MaterialDescription = rd["TXZ01"].ToString();
                entity.Plant = rd["WERKS"].ToString();
                
                if (rd.IsDBNull(6))
                    entity.RequiredQuantity   = null;
                else
                    entity.RequiredQuantity = Convert.ToInt64(rd["MENGE"]); 
                                               
                entity.UnitOfMeasure = rd["MEINS"].ToString();

                if (rd.IsDBNull(8))
                    entity.RequiredDate = null;
                else
                    entity.RequiredDate = Convert.ToInt64(rd["LFDAT"]);

                if (rd.IsDBNull(9))
                    entity.EstimatedPrice = null;
                else
                    entity.EstimatedPrice = Convert.ToInt64(rd["PREIS"]);

                if (rd.IsDBNull(10))
                    entity.UnitPrice = null;
                else
                    entity.UnitPrice = Convert.ToInt64(rd["PEINH"]);

                entity.OrderNumber = rd["EBELN"].ToString();
                entity.SequenceNumber = rd["EBELP"].ToString();

                if (rd.IsDBNull(13))
                    entity.OrderDate = null;
                else
                    entity.OrderDate = Convert.ToInt64(rd["BEDAT"]);

                entity.CurrencyId = rd["WAERS"].ToString();

                if (rd.IsDBNull(13))
                    entity.TotalValue = null;
                else
                    entity.TotalValue = Convert.ToInt64(rd["RLWRT"]);

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

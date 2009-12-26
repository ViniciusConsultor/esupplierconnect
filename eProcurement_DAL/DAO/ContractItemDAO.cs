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
    public class ContractItemDAO : IContractItemDAO
    {
        #region RetrieveAll
        public override Collection<ContractItem> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public override Collection<ContractItem> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public override Collection<ContractItem> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public override Collection<ContractItem> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public override Collection<ContractItem> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public override Collection<ContractItem> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public override Collection<ContractItem> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public override Collection<ContractItem> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public override ContractItem RetrieveByKey(string contractNumber, string contractItemSequence)
        {
            return RetrieveByKey(null, contractNumber, contractItemSequence);
        }

        public override ContractItem RetrieveByKey(EpTransaction epTran, string contractNumber, string contractItemSequence)
        {
            ContractItem entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(contractNumber) + "' ";
            whereClause += "AND EBELP='" + DataManager.EscapeSQL(contractItemSequence) + "'";

            Collection<ContractItem> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public override void Insert(ContractItem entity)
        {
            Insert(null, entity);
        }

        public override void Insert(EpTransaction epTran, ContractItem entity)
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
            ContractItem checkEntity = RetrieveByKey(epTran, entity.ContractNumber, entity.ContractItemSequence);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO contitm ([EBELN],[EBELP],[TXZ01],[MATNR],[WERKS],[MATKL],[KTMNG],[MEINS],[NETPR],[PEINH],[BRTWR],[ANFNR],[BANFN],[AFNAM]) VALUES(@EBELN,@EBELP,@TXZ01,@MATNR,@WERKS,@MATKL,@KTMNG,@MEINS,@NETPR,@PEINH,@BRTWR,@ANFNR,@BANFN,@AFNAM)";
           
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.ContractNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.VarChar, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ContractItemSequence;

            SqlParameter p3 = new SqlParameter("@TXZ01", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p3);
            p3.Value = entity.Description;

            SqlParameter p4 = new SqlParameter("@MATNR", SqlDbType.VarChar, 18);
            cm.Parameters.Add(p4);
            p4.Value = entity.MaterialNumber;

            SqlParameter p5 = new SqlParameter("@WERKS", SqlDbType.Char, 4);
            cm.Parameters.Add(p5);
            p5.Value = entity.Plant;

            SqlParameter p6 = new SqlParameter("@MATKL", SqlDbType.VarChar, 9);
            cm.Parameters.Add(p6);
            p6.Value = entity.MaterialGroup;

            SqlParameter p7 = new SqlParameter("@KTMNG", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p7);
            if (entity.TargetQuantity.HasValue)
                p7.Value = entity.TargetQuantity;
            else
                p7.Value = DBNull.Value;

            SqlParameter p8 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p8);
            p8.Value = entity.UnitOfMeasure;

            SqlParameter p9 = new SqlParameter("@NETPR", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p9);
            if (entity.UnitPrice.HasValue)
                p9.Value = entity.UnitPrice;
            else
                p9.Value = DBNull.Value;

            SqlParameter p10 = new SqlParameter("@PEINH", SqlDbType.Decimal, 5);
            cm.Parameters.Add(p10);
            if (entity.PricePerUnit.HasValue)
                p10.Value = entity.PricePerUnit;
            else
                p10.Value = DBNull.Value;

            SqlParameter p11 = new SqlParameter("@BRTWR", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p11);
            if (entity.NetValue.HasValue)
                p11.Value = entity.NetValue;
            else
                p11.Value = DBNull.Value;

            SqlParameter p12 = new SqlParameter("@ANFNR", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p12);
            p12.Value = entity.RFQNumber;

            SqlParameter p13 = new SqlParameter("@BANFN", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p13);
            p13.Value = entity.RequisitionNumber;

            SqlParameter p14 = new SqlParameter("@AFNAM", SqlDbType.VarChar, 12);
            cm.Parameters.Add(p14);
            p14.Value = entity.Requisitioner;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public override void Update(ContractItem entity)
        {
            Update(null, entity);
        }

        public override void Update(EpTransaction epTran, ContractItem entity)
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
            ContractItem checkEntity = RetrieveByKey(epTran, entity.ContractNumber, entity.ContractItemSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE contitm SET [TXZ01]=@TXZ01,[MATNR]=@MATNR,[WERKS]=@WERKS,[MATKL]=@MATKL,[KTMNG]=@KTMNG,[MEINS]=@MEINS,[NETPR]=@NETPR,[PEINH]=@PEINH,[BRTWR]=@BRTWR,[ANFNR]=@ANFNR,[BANFN]=@BANFN,[AFNAM]=@AFNAM WHERE [EBELN]=@EBELN and [EBELP]=@EBELP";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.ContractNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.VarChar, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ContractItemSequence;

            SqlParameter p3 = new SqlParameter("@TXZ01", SqlDbType.VarChar, 40);
            cm.Parameters.Add(p3);
            p3.Value = entity.Description;

            SqlParameter p4 = new SqlParameter("@MATNR", SqlDbType.VarChar, 18);
            cm.Parameters.Add(p4);
            p4.Value = entity.MaterialNumber;

            SqlParameter p5 = new SqlParameter("@WERKS", SqlDbType.Char, 4);
            cm.Parameters.Add(p5);
            p5.Value = entity.Plant;

            SqlParameter p6 = new SqlParameter("@MATKL", SqlDbType.VarChar, 9);
            cm.Parameters.Add(p6);
            p6.Value = entity.MaterialGroup;

            SqlParameter p7 = new SqlParameter("@KTMNG", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p7);
            if (entity.TargetQuantity.HasValue)
                p7.Value = entity.TargetQuantity;
            else
                p7.Value = DBNull.Value;

            SqlParameter p8 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p8);
            p8.Value = entity.UnitOfMeasure;

            SqlParameter p9 = new SqlParameter("@NETPR", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p9);
            if (entity.UnitPrice.HasValue)
                p9.Value = entity.UnitPrice;
            else
                p9.Value = DBNull.Value;

            SqlParameter p10 = new SqlParameter("@PEINH", SqlDbType.Decimal, 5);
            cm.Parameters.Add(p10);
            if (entity.PricePerUnit.HasValue)
                p10.Value = entity.PricePerUnit;
            else
                p10.Value = DBNull.Value;

            SqlParameter p11 = new SqlParameter("@BRTWR", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p11);
            if (entity.NetValue.HasValue)
                p11.Value = entity.NetValue;
            else
                p11.Value = DBNull.Value;

            SqlParameter p12 = new SqlParameter("@ANFNR", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p12);
            p12.Value = entity.RFQNumber;

            SqlParameter p13 = new SqlParameter("@BANFN", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p13);
            p13.Value = entity.RequisitionNumber;

            SqlParameter p14 = new SqlParameter("@AFNAM", SqlDbType.VarChar, 12);
            cm.Parameters.Add(p14);
            p14.Value = entity.Requisitioner;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public override void Delete(ContractItem entity)
        {
            Delete(null, entity);
        }

        public override void Delete(EpTransaction epTran, ContractItem entity)
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
            ContractItem checkEntity = RetrieveByKey(epTran, entity.ContractNumber, entity.ContractItemSequence);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM contitm WHERE EBELN=@EBELN AND EBELP=@EBELP";
            
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.ContractNumber;

            SqlParameter p2 = new SqlParameter("@EBELP", SqlDbType.VarChar, 5);
            cm.Parameters.Add(p2);
            p2.Value = entity.ContractItemSequence;


            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private Collection<ContractItem> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<ContractItem> entities = new Collection<ContractItem>();

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
            string selectCommand = "SELECT [EBELN],[EBELP],[TXZ01],[MATNR],[WERKS],[MATKL],[KTMNG],[MEINS],[NETPR],[PEINH],[BRTWR],[ANFNR],[BANFN],[AFNAM] FROM contitm";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                ContractItem entity = new ContractItem();
                entity.ContractNumber = rd["EBELN"].ToString();
                entity.ContractItemSequence = rd["EBELP"].ToString();
                entity.Description  = rd["TXZ01"].ToString();
                entity.MaterialNumber  = rd["MATNR"].ToString();
                entity.Plant = rd["WERKS"].ToString();
                entity.MaterialGroup = rd["MATKL"].ToString();

                if (rd.IsDBNull(6))
                    entity.TargetQuantity  = null;
                else
                    entity.TargetQuantity = Convert.ToInt64(rd["KTMNG"]);
                
                entity.UnitOfMeasure  = rd["MEINS"].ToString();

                if (rd.IsDBNull(8))
                    entity.UnitPrice  = null;
                else
                    entity.UnitPrice = Convert.ToInt64(rd["NETPR"]);

                if (rd.IsDBNull(9))
                    entity.PricePerUnit  = null;
                else
                    entity.PricePerUnit = Convert.ToInt64(rd["PEINH"]);

                if (rd.IsDBNull(10))
                    entity.NetValue = null;
                else
                    entity.NetValue = Convert.ToInt64(rd["BRTWR"]);

                entity.RFQNumber  = rd["ANFNR"].ToString();
                entity.RequisitionNumber  = rd["BANFN"].ToString();
                entity.Requisitioner  = rd["AFNAM"].ToString();

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

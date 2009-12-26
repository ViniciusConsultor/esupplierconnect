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
    public class ContractHeaderDAO : IContractHeaderDAO
    {       
        #region RetrieveAll
        public override Collection<ContractHeader> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public override Collection<ContractHeader> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public override Collection<ContractHeader> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public override Collection<ContractHeader> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public override Collection<ContractHeader> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public override Collection<ContractHeader> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public override Collection<ContractHeader> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public override Collection<ContractHeader> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public override ContractHeader RetrieveByKey(string ContractNumber)
        {
            return RetrieveByKey(null, ContractNumber);
        }

        public override ContractHeader RetrieveByKey(EpTransaction epTran, string ContractNumber)
        {
            ContractHeader entity = null;
            string whereClause = " EBELN='" + DataManager.EscapeSQL(ContractNumber) + "' ";

            Collection<ContractHeader> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public override void Insert(ContractHeader entity)
        {
            Insert(null, entity);
        }

        public override void Insert(EpTransaction epTran, ContractHeader entity)
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
            ContractHeader checkEntity = RetrieveByKey(epTran, entity.ContractNumber);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO conthdr ([EBELN],[BEDAT],[BSTYP],[BSART],[ERNAM],[LIFNR],[ZTERM],[EKGRP],[WAERS],[WKURS],[KDATB],[KDATE],[VERKF],[TELF1],[KTWRT],[IHERZ]) VALUES(@EBELN,@BEDAT,@BSTYP,@BSART,@ERNAM,@LIFNR,@ZTERM,@EKGRP,@WAERS,@WKURS,@KDATB,@KDATE,@VERKF,@TELF1,@KTWRT,@IHERZ)";
            
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.ContractNumber;

            SqlParameter p2 = new SqlParameter("@BEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p2);
            if (entity.ContractDate.HasValue)
                p2.Value = entity.ContractDate;
            else
                p2.Value = DBNull.Value;

            SqlParameter p3 = new SqlParameter("@BSTYP", SqlDbType.Char, 1);
            cm.Parameters.Add(p3);
            p3.Value = entity.ContractCategory;

            SqlParameter p4 = new SqlParameter("@BSART", SqlDbType.Char, 4);
            cm.Parameters.Add(p4);
            p4.Value = entity.DocumentType;

            SqlParameter p5 = new SqlParameter("@ERNAM", SqlDbType.VarChar, 12);
            cm.Parameters.Add(p5);
            p5.Value = entity.CreatedBy;

            SqlParameter p6 = new SqlParameter("@LIFNR", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p6);
            p6.Value = entity.SupplierId;

            SqlParameter p7 = new SqlParameter("@ZTERM", SqlDbType.Char, 4);
            cm.Parameters.Add(p7);
            p7.Value = entity.PaymentTerms;

            SqlParameter p8 = new SqlParameter("@EKGRP", SqlDbType.Char, 3);
            cm.Parameters.Add(p8);
            p8.Value = entity.PurchasingGroup;

            SqlParameter p9 = new SqlParameter("@WAERS", SqlDbType.Char, 5);
            cm.Parameters.Add(p9);
            p9.Value = entity.Currency;

            SqlParameter p10 = new SqlParameter("@WKURS", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p10);
            if (entity.ExchangeRate.HasValue)
                p10.Value = entity.ExchangeRate;
            else
                p10.Value = DBNull.Value;

            SqlParameter p11 = new SqlParameter("@KDATB", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p11);
            if (entity.ValidityStart.HasValue)
                p11.Value = entity.ValidityStart;
            else
                p11.Value = DBNull.Value;

            SqlParameter p12 = new SqlParameter("@KDATE", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p12);
            if (entity.ValidityEnd.HasValue)
                p12.Value = entity.ValidityEnd;
            else
                p12.Value = DBNull.Value;

            SqlParameter p13 = new SqlParameter("@VERKF", SqlDbType.VarChar, 30);
            cm.Parameters.Add(p13);
            p13.Value = entity.SalesContactPerson;

            SqlParameter p14 = new SqlParameter("@TELF1", SqlDbType.VarChar, 16);
            cm.Parameters.Add(p14);
            p14.Value = entity.Telephone;

            SqlParameter p15 = new SqlParameter("@KTWRT", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p15);
            if (entity.ContractValue.HasValue)
                p15.Value = entity.ContractValue;
            else
                p15.Value = DBNull.Value;

            SqlParameter p16 = new SqlParameter("@IHERZ", SqlDbType.VarChar, 12);
            cm.Parameters.Add(p16);
            p16.Value = entity.InternalReference;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public override void Update(ContractHeader entity)
        {
            Update(null, entity);
        }

        public override void Update(EpTransaction epTran, ContractHeader entity)
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
            ContractHeader checkEntity = RetrieveByKey(epTran, entity.ContractNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE conthdr set [BEDAT]=@BEDAT,[BSTYP]=@BSTYP,[BSART]=@BSART,[ERNAM]=@ERNAM,[LIFNR]=@LIFNR,[ZTERM]=@ZTERM,[EKGRP]=@EKGRP,[WAERS]=@WAERS,[WKURS]=@WKURS,[KDATB]=@KDATB,[KDATE]=@KDATE,[VERKF]=@VERKF,[TELF1]=@TELF1,[KTWRT]=@KTWRT,[IHERZ]=@IHERZ WHERE EBELN=@EBELN";

            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.ContractNumber;

            SqlParameter p2 = new SqlParameter("@BEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p2);
            if (entity.ContractDate.HasValue)
                p2.Value = entity.ContractDate;
            else
                p2.Value = DBNull.Value;

            SqlParameter p3 = new SqlParameter("@BSTYP", SqlDbType.Char, 1);
            cm.Parameters.Add(p3);
            p3.Value = entity.ContractCategory;

            SqlParameter p4 = new SqlParameter("@BSART", SqlDbType.Char, 4);
            cm.Parameters.Add(p4);
            p4.Value = entity.DocumentType;

            SqlParameter p5 = new SqlParameter("@ERNAM", SqlDbType.VarChar, 12);
            cm.Parameters.Add(p5);
            p5.Value = entity.CreatedBy;

            SqlParameter p6 = new SqlParameter("@LIFNR", SqlDbType.VarChar, 10);
            cm.Parameters.Add(p6);
            p6.Value = entity.SupplierId;

            SqlParameter p7 = new SqlParameter("@ZTERM", SqlDbType.Char, 4);
            cm.Parameters.Add(p7);
            p7.Value = entity.PaymentTerms;

            SqlParameter p8 = new SqlParameter("@EKGRP", SqlDbType.Char, 3);
            cm.Parameters.Add(p8);
            p8.Value = entity.PurchasingGroup;

            SqlParameter p9 = new SqlParameter("@WAERS", SqlDbType.Char, 5);
            cm.Parameters.Add(p9);
            p9.Value = entity.Currency;

            SqlParameter p10 = new SqlParameter("@WKURS", SqlDbType.Decimal, 11);
            cm.Parameters.Add(p10);
            if (entity.ExchangeRate.HasValue)
                p10.Value = entity.ExchangeRate;
            else
                p10.Value = DBNull.Value;

            SqlParameter p11 = new SqlParameter("@KDATB", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p11);
            if (entity.ValidityStart.HasValue)
                p11.Value = entity.ValidityStart;
            else
                p11.Value = DBNull.Value;

            SqlParameter p12 = new SqlParameter("@KDATE", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p12);
            if (entity.ValidityEnd.HasValue)
                p12.Value = entity.ValidityEnd;
            else
                p12.Value = DBNull.Value;

            SqlParameter p13 = new SqlParameter("@VERKF", SqlDbType.VarChar, 30);
            cm.Parameters.Add(p13);
            p13.Value = entity.SalesContactPerson;

            SqlParameter p14 = new SqlParameter("@TELF1", SqlDbType.VarChar, 16);
            cm.Parameters.Add(p14);
            p14.Value = entity.Telephone;

            SqlParameter p15 = new SqlParameter("@KTWRT", SqlDbType.Decimal, 13);
            cm.Parameters.Add(p15);
            if (entity.ContractValue.HasValue)
                p15.Value = entity.ContractValue;
            else
                p15.Value = DBNull.Value;

            SqlParameter p16 = new SqlParameter("@IHERZ", SqlDbType.VarChar, 12);
            cm.Parameters.Add(p16);
            p16.Value = entity.InternalReference;


            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public override void Delete(ContractHeader entity)
        {
            Delete(null, entity);
        }

        public override void Delete(EpTransaction epTran, ContractHeader entity)
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
            ContractHeader checkEntity = RetrieveByKey(epTran, entity.ContractNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM conthdr WHERE EBELN=@EBELN";
            SqlParameter p1 = new SqlParameter("@EBELN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.ContractNumber;
          
            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private Collection<ContractHeader> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<ContractHeader> entities = new Collection<ContractHeader>();

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
            string selectCommand = "SELECT [EBELN],[BEDAT],[BSTYP],[BSART],[ERNAM],[LIFNR],[ZTERM],[EKGRP],[WAERS],[WKURS],[KDATB],[KDATE],[VERKF],[TELF1],[KTWRT],[IHERZ] FROM conthdr";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                ContractHeader entity = new ContractHeader();
                entity.ContractNumber = rd["EBELN"].ToString();
                
                if (rd.IsDBNull(1))
                    entity.ContractDate = null;
                else
                    entity.ContractDate = Convert.ToInt64(rd["BEDAT"]);
                
                entity.ContractCategory = rd["BSTYP"].ToString();
                entity.DocumentType = rd["BSART"].ToString();
                entity.CreatedBy = rd["ERNAM"].ToString();
                entity.SupplierId = rd["LIFNR"].ToString();
                entity.PaymentTerms = rd["ZTERM"].ToString();
                entity.PurchasingGroup = rd["EKGRP"].ToString();
                entity.Currency = rd["WAERS"].ToString();

                if (rd.IsDBNull(9))
                    entity.ExchangeRate = null;
                else
                    entity.ExchangeRate = Convert.ToInt64(rd["WKURS"]);

                if (rd.IsDBNull(10))
                    entity.ValidityStart = null;
                else
                    entity.ValidityStart = Convert.ToInt64(rd["KDATB"]);

                if (rd.IsDBNull(11))
                    entity.ValidityEnd = null;
                else
                    entity.ValidityEnd = Convert.ToInt64(rd["KDATE"]);

                entity.SalesContactPerson = rd["VERKF"].ToString();
                entity.Telephone = rd["TELF1"].ToString();

                if (rd.IsDBNull(14))
                    entity.ContractValue = null;
                else
                    entity.ContractValue = Convert.ToInt64(rd["KTWRT"]);

                entity.InternalReference = rd["IHERZ"].ToString();

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

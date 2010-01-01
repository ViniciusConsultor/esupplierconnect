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
    public class RequisitionHeaderDAO : IRequisitionHeaderDAO
    {
        #region RetrieveAll
        public override Collection<RequisitionHeader> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public override Collection<RequisitionHeader> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public override Collection<RequisitionHeader> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public override Collection<RequisitionHeader> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public override Collection<RequisitionHeader> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public override Collection<RequisitionHeader> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public override Collection<RequisitionHeader> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public override Collection<RequisitionHeader> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public override RequisitionHeader RetrieveByKey(string RequisitionNumber)
        {
            return RetrieveByKey(null, RequisitionNumber);
        }

        public override RequisitionHeader RetrieveByKey(EpTransaction epTran, string RequisitionNumber)
        {
            RequisitionHeader entity = null;
            string whereClause = " BANFN='" + DataManager.EscapeSQL(RequisitionNumber) + "' ";

            Collection<RequisitionHeader> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public override void Insert(RequisitionHeader entity)
        {
            Insert(null, entity);
        }

        public override void Insert(EpTransaction epTran, RequisitionHeader entity)
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
            RequisitionHeader checkEntity = RetrieveByKey(epTran, entity.RequisitionNumber);
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO reqhdr ([BANFN],[BSART],[BSTYP],[BADAT],[STATU],[FRGZU],[FRGDT]) VALUES(@BANFN,@BSART,@BSTYP,@BADAT,@STATU,@FRGZU,@FRGDT)";

            SqlParameter p1 = new SqlParameter("@BANFN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.RequisitionNumber;

            SqlParameter p2 = new SqlParameter("@BSART", SqlDbType.Char, 4);
            cm.Parameters.Add(p2);
            p2.Value = entity.DocumentType;

            SqlParameter p3 = new SqlParameter("@BSTYP", SqlDbType.Char, 1);
            cm.Parameters.Add(p3);
            p3.Value = entity.RequisitionCategory;

            SqlParameter p4 = new SqlParameter("@BADAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p4);
            if (entity.RequisitionDate.HasValue)
                p4.Value = entity.RequisitionDate;
            else
                p4.Value = DBNull.Value;

            SqlParameter p5 = new SqlParameter("@STATU", SqlDbType.Char, 1);
            cm.Parameters.Add(p5);
            p5.Value = entity.Status;

            SqlParameter p6 = new SqlParameter("@FRGZU", SqlDbType.Char, 2);
            cm.Parameters.Add(p6);
            p6.Value = entity.ReleaseStatus;

            SqlParameter p7 = new SqlParameter("@FRGDT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p7);
            if (entity.ReleaseDate.HasValue)
                p7.Value = entity.ReleaseDate;
            else
                p7.Value = DBNull.Value;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public override void Update(RequisitionHeader entity)
        {
            Update(null, entity);
        }

        public override void Update(EpTransaction epTran, RequisitionHeader entity)
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
            RequisitionHeader checkEntity = RetrieveByKey(epTran, entity.RequisitionNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE reqhdr set [BSART]=@BSART,[BSTYP]=@BSTYP,[BADAT]=@BADAT,[STATU]=@STATU,[FRGZU]=@FRGZU,[FRGDT]=@FRGDT WHERE BANFN=@BANFN";

            SqlParameter p1 = new SqlParameter("@BANFN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.RequisitionNumber;

            SqlParameter p2 = new SqlParameter("@BSART", SqlDbType.Char, 4);
            cm.Parameters.Add(p2);
            p2.Value = entity.DocumentType;

            SqlParameter p3 = new SqlParameter("@BSTYP", SqlDbType.Char, 1);
            cm.Parameters.Add(p3);
            p3.Value = entity.RequisitionCategory;

            SqlParameter p4 = new SqlParameter("@BADAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p4);
            if (entity.RequisitionDate.HasValue)
                p4.Value = entity.RequisitionDate;
            else
                p4.Value = DBNull.Value;

            SqlParameter p5 = new SqlParameter("@STATU", SqlDbType.Char, 1);
            cm.Parameters.Add(p5);
            p5.Value = entity.Status;

            SqlParameter p6 = new SqlParameter("@FRGZU", SqlDbType.Char, 2);
            cm.Parameters.Add(p6);
            p6.Value = entity.ReleaseStatus;

            SqlParameter p7 = new SqlParameter("@FRGDT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p7);
            if (entity.ReleaseDate.HasValue)
                p7.Value = entity.ReleaseDate;
            else
                p7.Value = DBNull.Value;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public override void Delete(RequisitionHeader entity)
        {
            Delete(null, entity);
        }

        public override void Delete(EpTransaction epTran, RequisitionHeader entity)
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
            RequisitionHeader checkEntity = RetrieveByKey(epTran, entity.RequisitionNumber);
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM reqhdr WHERE BANFN=@BANFN";
            SqlParameter p1 = new SqlParameter("@BANFN", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.RequisitionNumber;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private  Collection<RequisitionHeader> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<RequisitionHeader> entities = new Collection<RequisitionHeader>();

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
            string selectCommand = "SELECT [BANFN],[BSART],[BSTYP],[BADAT],[STATU],[FRGZU],[FRGDT] FROM reqhdr";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                RequisitionHeader entity = new RequisitionHeader();
                entity.RequisitionNumber = rd["BANFN"].ToString();
                entity.DocumentType = rd["BSART"].ToString();
                entity.RequisitionCategory = rd["BSTYP"].ToString();
                
                if (rd.IsDBNull(3))
                    entity.RequisitionDate = null;
                else
                    entity.RequisitionDate = Convert.ToInt64(rd["BADAT"]);

                entity.Status = rd["STATU"].ToString();
                entity.ReleaseStatus = rd["FRGZU"].ToString();
                
                if (rd.IsDBNull(6))
                    entity.ReleaseDate = null;
                else
                    entity.ReleaseDate = Convert.ToInt64(rd["FRGDT"]);

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

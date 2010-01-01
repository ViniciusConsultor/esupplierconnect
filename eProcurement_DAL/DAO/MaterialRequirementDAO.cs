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
    public class MaterialRequirementDAO : IMaterialRequirementDAO
    {
        #region RetrieveAll
        public override Collection<MaterialRequirement> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public override Collection<MaterialRequirement> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public override Collection<MaterialRequirement> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public override Collection<MaterialRequirement> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public override Collection<MaterialRequirement> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public override Collection<MaterialRequirement> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public override Collection<MaterialRequirement> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public override Collection<MaterialRequirement> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public override MaterialRequirement RetrieveByKey(string materialNumber, string plant, long requiredDate)
        {
            return RetrieveByKey(null, materialNumber, plant, requiredDate);
        }

        public override MaterialRequirement RetrieveByKey(EpTransaction epTran, string materialNumber, string plant, long requiredDate)
        {
            MaterialRequirement entity = null;
            string whereClause = " MATNR='" + DataManager.EscapeSQL(materialNumber) + "' ";
            whereClause += "AND WERKS='" + DataManager.EscapeSQL(plant) + "' ";
            whereClause += "AND BDTER=" + requiredDate + " ";

            Collection<MaterialRequirement> entities = Retrieve(epTran, whereClause, "");
            if (entities.Count > 0)
                entity = entities[0];

            return entity;
        }
        #endregion

        #region Insert
        public override void Insert(MaterialRequirement entity)
        {
            Insert(null, entity);
        }

        public override void Insert(EpTransaction epTran, MaterialRequirement entity)
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
            MaterialRequirement checkEntity = RetrieveByKey(epTran, entity.MaterialNumber, entity.Plant, Convert.ToInt64(entity.RequiredDate));
            if (checkEntity != null)
            {
                throw new Exception("Record already exists.");
            }

            //Insert 
            cm.CommandText = "INSERT INTO MTLREQ ([MATNR],[WERKS],[BDTER],[BDMNG],[MEINS]) VALUES(@MATNR,@WERKS,@AEDAT,@REQDQT,@MEINS)";

            SqlParameter p1 = new SqlParameter("@MATNR", SqlDbType.Char, 10);
            cm.Parameters.Add(p1);
            p1.Value = entity.MaterialNumber;

            SqlParameter p2 = new SqlParameter("@WERKS", SqlDbType.Char, 4);
            cm.Parameters.Add(p2);
            p2.Value = entity.Plant;

            SqlParameter p3 = new SqlParameter("@AEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p3);
            if (entity.RequiredDate.HasValue)
                p3.Value = entity.RequiredDate;
            else
                p3.Value = DBNull.Value;

            SqlParameter p4 = new SqlParameter("@REQDQT", SqlDbType.Decimal, 8);
            cm.Parameters.Add(p4);
            if (entity.RequiredQuantity.HasValue)
                p4.Value = entity.RequiredQuantity;
            else
                p4.Value = DBNull.Value;

            SqlParameter p5 = new SqlParameter("@MEINS", SqlDbType.Char, 3);
            cm.Parameters.Add(p5);
            p5.Value = entity.UnitOfMeasure;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Update
        public override void Update(MaterialRequirement entity)
        {
            Update(null, entity);
        }

        public override void Update(EpTransaction epTran, MaterialRequirement entity)
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
            MaterialRequirement checkEntity = RetrieveByKey(epTran, entity.MaterialNumber,entity.Plant,Convert.ToInt64(entity.RequiredDate));
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "UPDATE MTLREQ SET [MATNR]=@MATNR,[WERKS]=@WERKS,[BDTER]=@AEDAT,[BDMNG]=@REQDQT,[MEINS]=@MEINS WHERE MATNR=@MATNR";

            SqlParameter p1 = new SqlParameter("@MATNR", SqlDbType.VarChar, 18);
            cm.Parameters.Add(p1);
            p1.Value = entity.MaterialNumber;

            SqlParameter p2 = new SqlParameter("@WERKS", SqlDbType.VarChar, 4);
            cm.Parameters.Add(p2);
            p2.Value = entity.Plant;

            SqlParameter p3 = new SqlParameter("@AEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p3);
            if (entity.RequiredDate.HasValue)
                p3.Value = entity.RequiredDate;
            else
                p3.Value = DBNull.Value;

            SqlParameter p4 = new SqlParameter("@REQDQT", SqlDbType.Decimal, 8);
            cm.Parameters.Add(p4);
            if (entity.RequiredQuantity.HasValue)
                p4.Value = entity.RequiredQuantity;
            else
                p4.Value = DBNull.Value;

            SqlParameter p5 = new SqlParameter("@MEINS", SqlDbType.VarChar, 3);
            cm.Parameters.Add(p5);
            p5.Value = entity.UnitOfMeasure;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region Delete
        public override void Delete(MaterialRequirement entity)
        {
            Delete(null, entity);
        }

        public override void Delete(EpTransaction epTran, MaterialRequirement entity)
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
            MaterialRequirement checkEntity = RetrieveByKey(epTran, entity.MaterialNumber,entity.Plant,Convert.ToInt64(entity.RequiredDate));
            if (checkEntity == null)
            {
                throw new Exception("Record doesn't exist.");
            }

            //Update 
            cm.CommandText = "DELETE FROM MTLREQ WHERE MATNR=@MATNR AND WERKS=@WERKS AND BDTER=@AEDAT";
            SqlParameter p1 = new SqlParameter("@MATNR", SqlDbType.Char, 18);
            cm.Parameters.Add(p1);
            p1.Value = entity.MaterialNumber;

            SqlParameter p2 = new SqlParameter("@WERKS", SqlDbType.Char, 4);
            cm.Parameters.Add(p2);
            p2.Value = entity.Plant;

            SqlParameter p3 = new SqlParameter("@AEDAT", SqlDbType.BigInt, 8);
            cm.Parameters.Add(p3);
            if (entity.RequiredQuantity.HasValue)
                p3.Value = entity.RequiredDate;
            else
                p3.Value = DBNull.Value;

            cm.ExecuteNonQuery();

            if (epTran == null)
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }
        #endregion

        #region private methods
        private  Collection<MaterialRequirement> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<MaterialRequirement> entities = new Collection<MaterialRequirement>();

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
            string selectCommand = "SELECT [MATNR],[WERKS],[BDTER],[BDMNG],[MEINS] FROM MTLREQ";
            if (!string.IsNullOrEmpty(whereClause)) selectCommand += " where " + whereClause;
            if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " order by " + sortClaues;

            cm.CommandText = selectCommand;
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                MaterialRequirement entity = new MaterialRequirement();
                entity.MaterialNumber = rd["MATNR"].ToString();
                entity.Plant = rd["WERKS"].ToString();

                if (rd.IsDBNull(2))
                    entity.RequiredDate = null;
                else
                    entity.RequiredDate = Convert.ToInt64(rd["BDTER"]);

                if (rd.IsDBNull(3))
                    entity.RequiredQuantity = null;
                else
                    entity.RequiredQuantity = Convert.ToDecimal(rd["BDMNG"]);

                entity.UnitOfMeasure = rd["MEINS"].ToString();

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

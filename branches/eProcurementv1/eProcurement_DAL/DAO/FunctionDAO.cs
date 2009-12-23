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
    public class FunctionDAO : IFunctionDAO
    {
        #region RetrieveAll

        public override Collection<Function> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public override Collection<Function> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public override Collection<Function> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public override Collection<Function> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public override Collection<Function> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public override Collection<Function> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public override Collection<Function> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public override Collection<Function> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey
        public override Function RetrieveByKey(string functionId)
        {
            try{
                return RetrieveByKey(null, functionId);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public override Function RetrieveByKey(EpTransaction epTran, string functionId)
        {
            Function entity = null;
            try
            {
                string whereClause = " FUNCID='" + DataManager.EscapeSQL(functionId) + "' ";

                Collection<Function> entities = Retrieve(epTran, whereClause, "");
                if (entities.Count > 0)
                    entity = entities[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        #endregion

        #region Insert
        public override void Insert(Function entity)
        {
            try{
                Insert(null, entity);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public override void Insert(EpTransaction epTran, Function entity)
        {
            try
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
                Function checkEntity = RetrieveByKey(epTran, entity.FunctionID);
                if (checkEntity != null)
                {
                    throw new Exception("Record already exists.");
                }

                //Insert 
                cm.CommandText = "INSERT INTO ACCESSMATRIX ([FUNCID],[FUNCNAM]) VALUES(@FUNCID,@FUNCNAM)";

                SqlParameter p1 = new SqlParameter("@FUNCID", SqlDbType.VarChar, 6);
                cm.Parameters.Add(p1);
                p1.Value = entity.FunctionID;

                SqlParameter p2 = new SqlParameter("@FUNCNAM", SqlDbType.VarChar, 50);
                cm.Parameters.Add(p2);
                p2.Value = entity.FunctionName;

                cm.ExecuteNonQuery();

                if (epTran == null)
                    if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public override void Update(Function entity)
        {
            try{
                Update(null, entity);
            }
            catch (Exception ex)
            { throw ex; }

        }

        public override void Update(EpTransaction epTran, Function entity)
        {
            try
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
                Function checkEntity = RetrieveByKey(epTran, entity.FunctionID);
                if (checkEntity == null)
                {
                    throw new Exception("Record doesn't exist.");
                }

                //Update 
                cm.CommandText = "UPDATE FUNCTION SET [FUNCNAM]=@FUNCNAM WHERE FUNCID=@FUNCID";

                SqlParameter p1 = new SqlParameter("@FUNCID", SqlDbType.VarChar, 6);
                cm.Parameters.Add(p1);
                p1.Value = entity.FunctionID;

                cm.ExecuteNonQuery();

                if (epTran == null)
                    if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Delete
        public override void Delete(Function entity)
        {
            try{
                Delete(null, entity);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public override void Delete(EpTransaction epTran, Function entity)
        {
            try
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
                Function checkEntity = RetrieveByKey(epTran, entity.FunctionID);
                if (checkEntity == null)
                {
                    throw new Exception("Record doesn't exist.");
                }

                //Update 
                cm.CommandText = "DELETE FROM FUNCTION WHERE FUNCID=@FUNCID";

                SqlParameter p1 = new SqlParameter("@FUNCID", SqlDbType.VarChar, 6);
                cm.Parameters.Add(p1);
                p1.Value = entity.FunctionID;
                
                cm.ExecuteNonQuery();

                if (epTran == null)
                    if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #region private methods
        private static Collection<Function> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<Function> entities = new Collection<Function>();
            try{

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
                string selectCommand = "SELECT * FROM FUNCTION";
                if (!string.IsNullOrEmpty(whereClause)) selectCommand += " WHERE " + whereClause;
                if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " ORDER BY " + sortClaues;

                cm.CommandText = selectCommand;
                SqlDataReader rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    Function entity = new Function();
                    entity.FunctionID = rd["FUNCID"].ToString();
                    entity.FunctionName = rd["FUNCNAM"].ToString();

                    entities.Add(entity);

                }
                // close reader
                rd.Close();

                if (epTran == null)
                    if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
            }
            catch (Exception ex)
            { throw ex; }

            return entities;
        }

        #endregion
    }
}


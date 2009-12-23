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
    public class AccessMatrixDAO: IAccessMatrixDAO 
    {
        #region RetrieveAll

        public override Collection<AccessMatrix> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public override Collection<AccessMatrix> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public override Collection<AccessMatrix> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public override Collection<AccessMatrix> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public override Collection<AccessMatrix> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public override Collection<AccessMatrix> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public override Collection<AccessMatrix> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public override Collection<AccessMatrix> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey

        public override AccessMatrix RetrieveByKey(string userRole, string profileType, string functionId)
        {
            return RetrieveByKey(null, userRole, profileType, functionId);
        }

        public override AccessMatrix RetrieveByKey(EpTransaction epTran, string userRole, string profileType, string functionId)
        {
            AccessMatrix entity = null;
            try
            {
                string whereClause = " USRROLE='" + DataManager.EscapeSQL(userRole) + "' AND PROFTYP='" + profileType + "' AND FUNCID='" + functionId + "'";

                Collection<AccessMatrix> entities = Retrieve(epTran, whereClause, "");
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
        public override void Insert(AccessMatrix entity)
        {
            try{
                Insert(null, entity);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public override void Insert(EpTransaction epTran, AccessMatrix entity)
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
                AccessMatrix checkEntity = RetrieveByKey(epTran, entity.UserRole, entity.ProfileType, entity.FunctionID);
                if (checkEntity != null)
                {
                    throw new Exception("Record already exists.");
                }

                //Insert 
                cm.CommandText = "INSERT INTO ACCESSMATRIX ([USRROLE],[PROFTYP],[FUNCID]) VALUES(@USRROLE,@PROFTYP,@FUNCID)";

                SqlParameter p1 = new SqlParameter("@USRROLE", SqlDbType.VarChar, 15);
                cm.Parameters.Add(p1);
                p1.Value = entity.UserRole;

                SqlParameter p2 = new SqlParameter("@PROFTYP", SqlDbType.VarChar, 10);
                cm.Parameters.Add(p2);
                p2.Value = entity.ProfileType;

                SqlParameter p3 = new SqlParameter("@FUNCID", SqlDbType.VarChar, 6);
                cm.Parameters.Add(p3);
                p3.Value = entity.FunctionID;

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
        public override void Update(AccessMatrix entity)
        {
            try{
                Update(null, entity);
            }
            catch (Exception ex)
            { throw ex; }

        }

        public override void Update(EpTransaction epTran, AccessMatrix entity)
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
                AccessMatrix checkEntity = RetrieveByKey(epTran, entity.UserRole, entity.ProfileType, entity.FunctionID);
                if (checkEntity == null)
                {
                    throw new Exception("Record doesn't exist.");
                }

                //Update 
                // hong yu, feel free to update the below query, it's abit strange since you made all of the columns primary keys
                cm.CommandText = "UPDATE ACCESSMATRIX SET [USRROLE]=@USRROLE,[PROFTYP]=@PROFTYP,[FUNCID]=@FUNCID WHERE USRROLE=@USRROLE AND PROFTYP=@PROFTYP AND FUNCID=@FUNCID";

                SqlParameter p1 = new SqlParameter("@USRROLE", SqlDbType.VarChar, 15);
                cm.Parameters.Add(p1);
                p1.Value = entity.UserRole;

                SqlParameter p2 = new SqlParameter("@PROFTYP", SqlDbType.VarChar, 10);
                cm.Parameters.Add(p2);
                p2.Value = entity.ProfileType;

                SqlParameter p3 = new SqlParameter("@FUNCID", SqlDbType.VarChar, 6);
                cm.Parameters.Add(p3);
                p3.Value = entity.FunctionID;

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
        public override void Delete(AccessMatrix entity)
        {
            try{
                Delete(null, entity);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public override void Delete(EpTransaction epTran, AccessMatrix entity)
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
                AccessMatrix checkEntity = RetrieveByKey(epTran, entity.UserRole, entity.ProfileType, entity.FunctionID);
                if (checkEntity == null)
                {
                    throw new Exception("Record doesn't exist.");
                }

                //Update 
                cm.CommandText = "DELETE FROM ACCESSMATRIX WHERE USRROLE=@USRROLE AND PROFTYP=@PROFTYP AND FUNCID=@FUNCID";

                SqlParameter p1 = new SqlParameter("@USRROLE", SqlDbType.VarChar, 15);
                cm.Parameters.Add(p1);
                p1.Value = entity.UserRole;

                SqlParameter p2 = new SqlParameter("@PROFTYP", SqlDbType.VarChar, 10);
                cm.Parameters.Add(p2);
                p2.Value = entity.ProfileType;

                SqlParameter p3 = new SqlParameter("@FUNCID", SqlDbType.VarChar, 6);
                cm.Parameters.Add(p3);
                p3.Value = entity.FunctionID;
                
                cm.ExecuteNonQuery();

                if (epTran == null)
                    if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #region private methods
        private static Collection<AccessMatrix> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<AccessMatrix> entities = new Collection<AccessMatrix>();
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
                string selectCommand = "SELECT * FROM ACCESSMATRIX";
                if (!string.IsNullOrEmpty(whereClause)) selectCommand += " WHERE " + whereClause;
                if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " ORDER BY " + sortClaues;

                cm.CommandText = selectCommand;
                SqlDataReader rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    AccessMatrix entity = new AccessMatrix();
                    entity.UserRole = rd["USRROLE"].ToString();
                    entity.ProfileType = rd["PROFTYP"].ToString();
                    entity.FunctionID = rd["FUNCID"].ToString();

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


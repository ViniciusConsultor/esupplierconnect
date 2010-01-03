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
    public class PurchaseGroupDAO : IPurchaseGroupDAO
    {
        #region RetrieveAll

        public override Collection<PurchaseGroup> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public override Collection<PurchaseGroup> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public override Collection<PurchaseGroup> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public override Collection<PurchaseGroup> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public override Collection<PurchaseGroup> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public override Collection<PurchaseGroup> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public override Collection<PurchaseGroup> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public override Collection<PurchaseGroup> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey

        public override PurchaseGroup RetrieveByKey(string purchaseGroup, string UserId)
        {
            return RetrieveByKey(null, purchaseGroup, UserId);
        }

        public override PurchaseGroup RetrieveByKey(EpTransaction epTran, string purchaseGroup, string UserId)
        {
            PurchaseGroup entity = null;
            try
            {
                string whereClause = " PURGROUP='" + DataManager.EscapeSQL(purchaseGroup) + "' AND USERID='" + DataManager.EscapeSQL(UserId) + "' ";

                Collection<PurchaseGroup> entities = Retrieve(epTran, whereClause, "");
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
        public override void Insert(PurchaseGroup entity)
        {
            try
            {
                Insert(null, entity);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public override void Insert(EpTransaction epTran, PurchaseGroup entity)
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
                PurchaseGroup checkEntity = RetrieveByKey(epTran, entity.PurGroup, entity.UserId);
                if (checkEntity != null)
                {
                    throw new Exception("Record already exists.");
                }

                //Insert 
                cm.CommandText = "INSERT INTO PurchaseGroup ([PURGROUP],[USERID]) VALUES(@PURGROUP,@USERID)";

                SqlParameter p1 = new SqlParameter("@PURGROUP", SqlDbType.VarChar, 3);
                cm.Parameters.Add(p1);
                p1.Value = entity.PurGroup;

                SqlParameter p2 = new SqlParameter("@USERID", SqlDbType.VarChar, 10);
                cm.Parameters.Add(p2);
                p2.Value = entity.UserId;

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
        public override void Update(PurchaseGroup entity)
        {
            try
            {
                Update(null, entity);
            }
            catch (Exception ex)
            { throw ex; }

        }

        public override void Update(EpTransaction epTran, PurchaseGroup entity)
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
                PurchaseGroup checkEntity = RetrieveByKey(epTran, entity.PurGroup, entity.UserId);
                if (checkEntity == null)
                {
                    throw new Exception("Record doesn't exist.");
                }

                //Update 
                // hong yu, feel free to update the below query, it's abit strange since you made all of the columns primary keys
                cm.CommandText = "UPDATE PurchaseGroup SET [PURGROUP]=@PURGROUP,[USERID]=@USERID WHERE [PURGROUP]=@PURGROUP1,[USERID]=@USERID1";

                SqlParameter p1 = new SqlParameter("@PURGROUP", SqlDbType.VarChar, 3);
                cm.Parameters.Add(p1);
                p1.Value = entity.PurGroup;

                SqlParameter p2 = new SqlParameter("@USERID", SqlDbType.VarChar, 10);
                cm.Parameters.Add(p2);
                p2.Value = entity.UserId;

                SqlParameter p3 = new SqlParameter("@PURGROUP1", SqlDbType.VarChar, 3);
                cm.Parameters.Add(p3);
                p3.Value = entity.PurGroup;

                SqlParameter p4 = new SqlParameter("@USERID1", SqlDbType.VarChar, 10);
                cm.Parameters.Add(p4);
                p4.Value = entity.UserId;

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
        public override void Delete(PurchaseGroup entity)
        {
            try
            {
                Delete(null, entity);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public override void Delete(EpTransaction epTran, PurchaseGroup entity)
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
                PurchaseGroup checkEntity = RetrieveByKey(epTran, entity.PurGroup, entity.UserId);
                if (checkEntity == null)
                {
                    throw new Exception("Record doesn't exist.");
                }

                //Update 
                cm.CommandText = "DELETE FROM PurchaseGroup WHERE PURGROUP=@PURGROUP AND USERID=@USERID";

                SqlParameter p1 = new SqlParameter("@PURGROUP", SqlDbType.VarChar, 3);
                cm.Parameters.Add(p1);
                p1.Value = entity.PurGroup;

                SqlParameter p2 = new SqlParameter("@USERID", SqlDbType.VarChar, 10);
                cm.Parameters.Add(p2);
                p2.Value = entity.UserId;

                cm.ExecuteNonQuery();

                if (epTran == null)
                    if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #region private methods
        private Collection<PurchaseGroup> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<PurchaseGroup> entities = new Collection<PurchaseGroup>();
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

                //Retrieve Data
                string selectCommand = "SELECT PURGROUP,USERID FROM PurchaseGroup";
                if (!string.IsNullOrEmpty(whereClause)) selectCommand += " WHERE " + whereClause;
                if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " ORDER BY " + sortClaues;

                cm.CommandText = selectCommand;
                SqlDataReader rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    PurchaseGroup entity = new PurchaseGroup();
                    entity.PurGroup = rd["PURGROUP"].ToString();
                    entity.UserId = rd["USERID"].ToString();

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

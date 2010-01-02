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
    public class AttachmentDAO : IAttachmentDAO
    {
        private bool includeAttachmentData = true;

        public AttachmentDAO() 
        {
            this.includeAttachmentData = true;
        }

        public AttachmentDAO(bool includeAttachmentData)
        {
            this.includeAttachmentData = includeAttachmentData;
        }

        #region RetrieveAll

        public override Collection<Attachment> RetrieveAll()
        {
            return Retrieve(null, "", "");
        }

        public override Collection<Attachment> RetrieveAll(string sortClaues)
        {
            return Retrieve(null, "", sortClaues);
        }

        public override Collection<Attachment> RetrieveAll(EpTransaction epTran)
        {
            return Retrieve(epTran, "", "");
        }

        public override Collection<Attachment> RetrieveAll(EpTransaction epTran, string sortClaues)
        {
            return Retrieve(epTran, "", sortClaues);
        }
        #endregion

        #region RetrieveByQuery
        public override Collection<Attachment> RetrieveByQuery(string whereClause)
        {
            return Retrieve(null, whereClause, "");
        }

        public override Collection<Attachment> RetrieveByQuery(string whereClause, string sortClaues)
        {
            return Retrieve(null, whereClause, sortClaues);
        }

        public override Collection<Attachment> RetrieveByQuery(EpTransaction epTran, string whereClause)
        {
            return Retrieve(epTran, whereClause, "");
        }

        public override Collection<Attachment> RetrieveByQuery(EpTransaction epTran, string whereClause, string sortClaues)
        {
            return Retrieve(epTran, whereClause, sortClaues);
        }
        #endregion

        #region RetrieveByKey

        public override Attachment RetrieveByKey(Guid attachmentId)
        {
            return RetrieveByKey(null, attachmentId);
        }

        public override Attachment RetrieveByKey(EpTransaction epTran, Guid attachmentId)
        {
            Attachment entity = null;
            try
            {
                string whereClause = " ATTCHMTID='" + attachmentId.ToString() + "' ";

                Collection<Attachment> entities = Retrieve(epTran, whereClause, "");
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
        public override void Insert(Attachment entity)
        {
            try
            {
                Insert(null, entity);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public override void Insert(EpTransaction epTran, Attachment entity)
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
                Attachment checkEntity = RetrieveByKey(epTran, entity.AttachmentId);
                if (checkEntity != null)
                {
                    throw new Exception("Record already exists.");
                }

                //Insert 
                cm.CommandText = "INSERT INTO ATTACHMENT ([ATTCHMTID],[FILENAME],[FILEDESC],[FILESIZE],[FILEDATA],[ATTCHDATE],[STOREPATH],[PROFTYP],[CREATEBY],[EBELN],[DELIND]) VALUES(@ATTCHMTID,@FILENAME,@FILEDESC,@FILESIZE,@FILEDATA,@ATTCHDATE,@STOREPATH,@PROFTYP,@CREATEBY,@EBELN,@DELIND)";

                SqlParameter p1 = new SqlParameter("@ATTCHMTID", SqlDbType.UniqueIdentifier);
                cm.Parameters.Add(p1);
                p1.Value = entity.AttachmentId;

                SqlParameter p2 = new SqlParameter("@FILENAME", SqlDbType.VarChar, 50);
                cm.Parameters.Add(p2);
                p2.Value = entity.FileName;

                SqlParameter p3 = new SqlParameter("@FILEDESC", SqlDbType.VarChar, 200);
                cm.Parameters.Add(p3);
                p3.Value = entity.FileDesc;

                SqlParameter p4 = new SqlParameter("@FILESIZE", SqlDbType.BigInt);
                cm.Parameters.Add(p4);
                p4.Value = entity.FileSize;

                SqlParameter p5 = new SqlParameter("@FILEDATA", SqlDbType.Binary);
                cm.Parameters.Add(p5);
                p5.Value = entity.FileDesc;

                SqlParameter p6 = new SqlParameter("@ATTCHDATE", SqlDbType.BigInt);
                cm.Parameters.Add(p6);
                p6.Value = entity.AttachDate;

                SqlParameter p7 = new SqlParameter("@STOREPATH", SqlDbType.VarChar, 200);
                cm.Parameters.Add(p7);
                p7.Value = entity.StorePath;

                SqlParameter p8 = new SqlParameter("@PROFTYP", SqlDbType.VarChar, 10);
                cm.Parameters.Add(p8);
                p8.Value = entity.ProfileType;

                SqlParameter p9 = new SqlParameter("@CREATEBY", SqlDbType.VarChar, 10);
                cm.Parameters.Add(p9);
                p9.Value = entity.CreateBy;

                SqlParameter p10 = new SqlParameter("@EBELN", SqlDbType.VarChar, 10);
                cm.Parameters.Add(p10);
                p10.Value = entity.RfqNumber;

                 SqlParameter p11 = new SqlParameter("@DELIND", SqlDbType.VarChar, 1);
                cm.Parameters.Add(p11);
                p11.Value = entity.DelInd;

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
        public override void Update(Attachment entity)
        {
            try
            {
                Update(null, entity);
            }
            catch (Exception ex)
            { throw ex; }

        }

        public override void Update(EpTransaction epTran, Attachment entity)
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
                Attachment checkEntity = RetrieveByKey(epTran, entity.AttachmentId);
                if (checkEntity == null)
                {
                    throw new Exception("Record doesn't exist.");
                }

                //Update 
                // hong yu, feel free to update the below query, it's abit strange since you made all of the columns primary keys
                cm.CommandText = "UPDATE ATTACHMENT SET [FILENAME]=@FILENAME,[FILEDESC]=@FILEDESC,[FILESIZE]=@FILESIZE,[FILEDATA]=@FILEDATA,[ATTCHDATE]=@ATTCHDATE,[STOREPATH]=@STOREPATH,[PROFTYP]=@PROFTYP,[CREATEBY]=@CREATEBY,[EBELN]=@EBELN,[DELIND]=@DELIND WHERE [ATTCHMTID]=@ATTCHMTID";

                SqlParameter p1 = new SqlParameter("@ATTCHMTID", SqlDbType.UniqueIdentifier);
                cm.Parameters.Add(p1);
                p1.Value = entity.AttachmentId;

                SqlParameter p2 = new SqlParameter("@FILENAME", SqlDbType.VarChar, 50);
                cm.Parameters.Add(p2);
                p2.Value = entity.FileName;

                SqlParameter p3 = new SqlParameter("@FILEDESC", SqlDbType.VarChar, 200);
                cm.Parameters.Add(p3);
                p3.Value = entity.FileDesc;

                SqlParameter p4 = new SqlParameter("@FILESIZE", SqlDbType.BigInt);
                cm.Parameters.Add(p4);
                p4.Value = entity.FileSize;

                SqlParameter p5 = new SqlParameter("@FILEDATA", SqlDbType.Binary);
                cm.Parameters.Add(p5);
                p5.Value = entity.FileDesc;

                SqlParameter p6 = new SqlParameter("@ATTCHDATE", SqlDbType.BigInt);
                cm.Parameters.Add(p6);
                p6.Value = entity.AttachDate;

                SqlParameter p7 = new SqlParameter("@STOREPATH", SqlDbType.VarChar, 200);
                cm.Parameters.Add(p7);
                p7.Value = entity.StorePath;

                SqlParameter p8 = new SqlParameter("@PROFTYP", SqlDbType.VarChar, 10);
                cm.Parameters.Add(p8);
                p8.Value = entity.ProfileType;

                SqlParameter p9 = new SqlParameter("@CREATEBY", SqlDbType.VarChar, 10);
                cm.Parameters.Add(p9);
                p9.Value = entity.CreateBy;

                SqlParameter p10 = new SqlParameter("@EBELN", SqlDbType.VarChar, 10);
                cm.Parameters.Add(p10);
                p10.Value = entity.RfqNumber;

                SqlParameter p11 = new SqlParameter("@DELIND", SqlDbType.VarChar, 1);
                cm.Parameters.Add(p11);
                p11.Value = entity.DelInd;

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
        public override void Delete(Attachment entity)
        {
            try
            {
                Delete(null, entity);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public override void Delete(EpTransaction epTran, Attachment entity)
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
                Attachment checkEntity = RetrieveByKey(epTran, entity.AttachmentId);
                if (checkEntity == null)
                {
                    throw new Exception("Record doesn't exist.");
                }

                //Update 
                cm.CommandText = "DELETE FROM ATTACHMENT WHERE ATTCHMTID=@ATTCHMTID";

                SqlParameter p1 = new SqlParameter("@ATTCHMTID", SqlDbType.UniqueIdentifier);
                cm.Parameters.Add(p1);
                p1.Value = entity.AttachmentId;

                cm.ExecuteNonQuery();

                if (epTran == null)
                    if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #region private methods
        private Collection<Attachment> Retrieve(EpTransaction epTran, string whereClause, string sortClaues)
        {
            Collection<Attachment> entities = new Collection<Attachment>();
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
                string selectCommand = "SELECT [ATTCHMTID],[FILENAME],[FILEDESC],[FILESIZE],[FILEDATA],[ATTCHDATE],[STOREPATH],[PROFTYP],[CREATEBY],[EBELN],[DELIND] FROM ATTACHMENT";
                if (!string.IsNullOrEmpty(whereClause)) selectCommand += " WHERE " + whereClause;
                if (!string.IsNullOrEmpty(sortClaues)) selectCommand += " ORDER BY " + sortClaues;

                cm.CommandText = selectCommand;
                SqlDataReader rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    Attachment entity = new Attachment();
                    entity.AttachmentId = new Guid(rd["ATTCHMTID"].ToString());
                    entity.FileName = rd["FILENAME"].ToString();
                    entity.FileDesc = rd["FILEDESC"].ToString();
                    entity.FileSize = Convert.ToInt64(rd["FILESIZE"].ToString());
                    if (this.includeAttachmentData)
                        entity.FileData = (byte[])rd["FILEDATA"];
                    else
                        entity.FileData = null;
                    entity.AttachDate = Convert.ToInt64(rd["ATTCHDATE"].ToString());
                    entity.StorePath = rd["STOREPATH"].ToString();
                    entity.ProfileType = rd["PROFTYP"].ToString();
                    entity.CreateBy = rd["CREATEBY"].ToString();
                    entity.RfqNumber = rd["EBELN"].ToString();
                    entity.DelInd = rd["DELIND"].ToString();

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

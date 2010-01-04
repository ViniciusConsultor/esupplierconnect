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
    public class ExecuteCommandDAO : IExecuteCommandDAO
    {
        public override void ExpeditePurchase(EpTransaction epTran) 
        {
            try
            {
                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.StoredProcedure;

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

                cm.CommandText = "PURCHASE_EXPEDITE";

                cm.ExecuteNonQuery();

                if (epTran == null)
                    if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Helpers
{
    public static class DatabaseHelperExtension
    {

        //openconnection
        public static SqlConnection DBConnection(this SqlConnection sqlConnection, string conectionString)
        {
            try
            {
                sqlConnection = new SqlConnection(conectionString);
                sqlConnection.Open();
                return sqlConnection; 
            }
            catch (Exception e)
            {
                LogHelpers.Write("Error :: " + e.Message);
            }
            return null;
        }



        //close connection
        public static void DBClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                LogHelpers.Write("Error :: " + e.Message);
            }
        }


        //execution
        public static DataTable ExecuteQuery(this SqlConnection sqlConnection,string queryString)
        {
            DataSet dataSet;
            try
            {
                //checking state of connection
                if (sqlConnection == null || ((sqlConnection != null && (sqlConnection.State == ConnectionState.Closed || 
                    sqlConnection.State == ConnectionState.Broken))))
                {
                    sqlConnection.Open();
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = new SqlCommand(queryString, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "table");
                sqlConnection.Close();
                return dataSet.Tables["table"];

            }
            catch (Exception e)
            {
                dataSet = null;
                sqlConnection.Close();
                LogHelpers.Write("Error :: " + e.Message);
                return null;
            }
            finally
            {
                dataSet = null;
                sqlConnection.Close();
            }

        }


    }
}

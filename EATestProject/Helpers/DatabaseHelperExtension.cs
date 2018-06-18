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
        public static void ExecuteQuery(this SqlConnection sqlConnection,string queryString)
        {
            DataSet dataSet;
            try
            {
                //checking state of connection
                if (sqlConnection == null || ((sqlConnection != null && (sql))))
                {

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }


    }
}

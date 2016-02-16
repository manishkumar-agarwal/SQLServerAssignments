using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWrapper
{
    internal class DBInteraction
    {
        internal static DBConnection databaseConnection = new DBConnection();

        /// <summary>
        /// This method executes commands to execute the SP on SQL-SERVER
        /// </summary>
        /// <param name="sqlCommand">The command which needs to be executed on the SQL Server</param>
        /// <returns>Returns a SqlDataReader object for the queries being performed</returns>
        internal static SqlDataReader ExecuteCommand(SqlCommand sqlCommand)
        {
            SqlDataReader queryResult;
            databaseConnection.OpenDBConnection(); 
            queryResult = sqlCommand.ExecuteReader();
            return queryResult;
        }

        /// <summary>
        /// This method checks if the connection is established with the DB.
        /// If DB Connection is not established this method establishes a connection
        /// </summary>
        internal static void SetUpDBConnection()
        {
            if (!databaseConnection.IsConnectedToDB)
            {
                databaseConnection.ConnectToDB();
            }
        }
    }
}

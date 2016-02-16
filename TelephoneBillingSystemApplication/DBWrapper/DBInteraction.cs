using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DBWrapper
{
    internal class DBInteraction
    {
        private static DBConnection databaseConnection = new DBConnection();

        
        private static SqlCommand GenerateSQLCommand(string storedProcedureName, 
                                                List<SqlParameter> storedProcedureParameterList)
        {
            StringBuilder queryString = new StringBuilder("EXEC");

            foreach (var sqlParameter in storedProcedureParameterList)
            {
                queryString.Append(" ");
                queryString.Append(sqlParameter.ParameterName);
            }

            SqlCommand sqlCommand = new SqlCommand(queryString.ToString(), DBConnection.SqlDBConnection);

            sqlCommand.Parameters.AddRange(storedProcedureParameterList.ToArray());

            return sqlCommand;
        }

        internal static SqlDataReader ExecuteSelect(string storedProcedureName, 
                                                    List<SqlParameter> storedProcedureParameterList)
        {
            CheckDBConnection();
            var sqlCommand = GenerateSQLCommand(storedProcedureName, storedProcedureParameterList);
            var queryResult = sqlCommand.ExecuteReader();
            return queryResult;
        }

        internal static int ExecuteNonSelect(string storedProcedureName,
                                                    List<SqlParameter> storedProcedureParameterList)
        {
            CheckDBConnection();
            var sqlCommand = GenerateSQLCommand(storedProcedureName, storedProcedureParameterList);
            return sqlCommand.ExecuteNonQuery();
        }


        /// <summary>
        /// this method establishes a DB connection
        /// </summary>
        private static void SetUpDBConnection()
        {
            databaseConnection.ConnectToDB();
            databaseConnection.OpenDBConnection();
        }

        /// <summary>
        /// This method checks if the connection is established with the DB.
        /// If DB Connection is not established this method establishes a connection
        /// </summary>
        private static void CheckDBConnection()
        {
            if (!databaseConnection.IsConnectedToDB)
            {
                SetUpDBConnection();
            }
        }
    }
}

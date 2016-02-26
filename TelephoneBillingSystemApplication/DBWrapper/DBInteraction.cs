using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DBWrapper
{
    internal class DBInteraction
    {
        private static DBConnection databaseConnection = new DBConnection();

        
        internal static SqlCommand GenerateSQLCommand(string storedProcedureName, 
                                                List<SqlParameter> storedProcedureParameterList)
        {
            int noOfParameters = storedProcedureParameterList.Count;
            StringBuilder queryString = new StringBuilder("EXEC " + storedProcedureName);

            foreach (var sqlParameter in storedProcedureParameterList)
            {
                queryString.Append(" ");
                queryString.Append(sqlParameter.ParameterName);
                if(--noOfParameters > 0)
                {
                    queryString.Append(",");
                }
            }

            SqlCommand sqlCommand = new SqlCommand(queryString.ToString(), DBConnection.SqlDBConnection);

            sqlCommand.Parameters.AddRange(storedProcedureParameterList.ToArray());

            return sqlCommand;
        }

        internal static SqlDataReader ExecuteSelect(string storedProcedureName, 
                                                    List<SqlParameter> storedProcedureParameterList)
        {
            SetUpDBConnection();
            var sqlCommand = GenerateSQLCommand(storedProcedureName, storedProcedureParameterList);
            var queryResult = sqlCommand.ExecuteReader();
            return queryResult;
        }

        internal static int ExecuteNonSelect(string storedProcedureName,
                                                    List<SqlParameter> storedProcedureParameterList)
        {
            SetUpDBConnection();
            var sqlCommand = GenerateSQLCommand(storedProcedureName, storedProcedureParameterList);
            return sqlCommand.ExecuteNonQuery();
        }


        /// <summary>
        /// this method establishes a DB connection
        /// </summary>
        internal static bool SetUpDBConnection()
        {
            var isNewConnectionSetup = false;
            if (!CheckDBConnection())
            {
                isNewConnectionSetup = databaseConnection.ConnectToDB();
                databaseConnection.OpenDBConnection();
            }
            return isNewConnectionSetup;
        }

        /// <summary>
        /// This method checks if the connection is established with the DB.
        /// If DB Connection is not established this method establishes a connection
        /// </summary>
        internal static bool CheckDBConnection()
        {
            return databaseConnection.IsConnectedToDB;
            
        }
    }
}

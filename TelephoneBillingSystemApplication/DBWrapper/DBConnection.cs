using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWrapper
{
    /// <summary>
    /// This class defines the methods for the connections to the Database
    /// </summary>
    public class DBConnection
    {
        private string connectionString = "Data Source=(local);Initial Catalog=AdventureWorks;"
            + "Integrated Security=true";

        public static SqlConnection SqlDBConnection;

        private bool isConnectedToDB;

        public bool IsConnectedToDB
        {
            get { return isConnectedToDB; }
        }

        public DBConnection()
        {
            
        }

        public DBConnection(string connectionString) 
        {
            this.connectionString = connectionString;

        }

        /// <summary>
        /// This method setsup a connection to the Database
        /// </summary>
        /// <returns>Returns a flag indicating the connection status </returns>
        public bool ConnectToDB()
        {
            bool connectionSuccessfulFlag = false;
            if (!isConnectedToDB)
            {
                SqlDBConnection = new SqlConnection(connectionString);

                isConnectedToDB = true;

                connectionSuccessfulFlag = true;
            }
            
            return connectionSuccessfulFlag;
        }

        /// <summary>
        /// This method connects to the DB as provided by the user when the application 
        /// is already connected
        /// </summary>
        /// <param name="connectionString">the DB connection string</param>
        /// <returns>Returns a flag if the connection was successful</returns>
        public bool ConnectToDifferentDB(string connectionString)
        {
            bool connectToDifferentDBFlag = false;

            this.connectionString = connectionString;

            if (DisposeSQLConnection())
            {
                connectToDifferentDBFlag = ConnectToDB();
            }

            return connectToDifferentDBFlag;
        }

        /// <summary>
        /// This methods disposes the current SQLConnection which has been set up
        /// </summary>
        /// <returns>returns a flag indicatin </returns>
        private bool DisposeSQLConnection()
        {
            SqlDBConnection.Dispose();
            isConnectedToDB = false;
            return true;
        }


        /// <summary>
        /// This method opens the connection to the connected SQL Database
        /// </summary>
        public void OpenDBConnection()
        {
            SqlDBConnection.Open();
        }

        /// <summary>
        /// This method closes the connection to the connected SQL Database
        /// </summary>
        public void CloseDBConnection()
        {
            SqlDBConnection.Close();
        }
    }
}

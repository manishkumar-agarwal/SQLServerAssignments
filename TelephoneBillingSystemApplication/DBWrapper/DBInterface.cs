using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWrapper
{
    /// <summary>
    /// This class provides an interface for the performing operations on the database.
    /// </summary>
    public class DBInterface
    {

        public static void GetProductDetailsByCategoryID(int productCategoryID)
        {
            DBInteraction.SetUpDBConnection();
            string spCallString = "EXEC dbo.uspGetProductCategoryDetailsByID @ProductCategoryID;";
            SqlCommand sqlCommand = new SqlCommand(spCallString, DBConnection.SqlDBConnection);
            sqlCommand.Parameters.AddWithValue("@ProductCategoryID", productCategoryID);
            SqlDataReader queryResult =  DBInteraction.ExecuteCommand(sqlCommand);
            Display(queryResult);
            DBInteraction.databaseConnection.CloseDBConnection();

        }

        public static void GetAllActiveProductCategories()
        {
            DBInteraction.SetUpDBConnection();
            string spCallString = "EXEC dbo.uspGetAllActiveProductCategories;";
            SqlCommand sqlCommand = new SqlCommand(spCallString, DBConnection.SqlDBConnection);
            SqlDataReader queryResult = DBInteraction.ExecuteCommand(sqlCommand);
            Display(queryResult);
            DBInteraction.databaseConnection.CloseDBConnection();
        }

        public static void InsertProductCategory(string productCategoryName)
        {
            DBInteraction.SetUpDBConnection();
            string spCallString = "EXEC [dbo].[uspInsertProductCategory] @ProductCategoryName;";
            SqlCommand sqlCommand = new SqlCommand(spCallString, DBConnection.SqlDBConnection);
            sqlCommand.Parameters.AddWithValue("@ProductCategoryName", productCategoryName);
            SqlDataReader queryResult = DBInteraction.ExecuteCommand(sqlCommand);
            DisplayOperationStatus(queryResult);
            DBInteraction.databaseConnection.CloseDBConnection();
        }

        public static void InactivateProductCategory(int productCategoryID)
        {
            DBInteraction.SetUpDBConnection();
            string spCallString = "EXEC [dbo].[uspUpdateProductCategoryAsInactive] @ProductCategoryID;";
            SqlCommand sqlCommand = new SqlCommand(spCallString, DBConnection.SqlDBConnection);
            sqlCommand.Parameters.AddWithValue("@ProductCategoryID", productCategoryID);
            SqlDataReader queryResult = DBInteraction.ExecuteCommand(sqlCommand);
            DisplayOperationStatus(queryResult);
            DBInteraction.databaseConnection.CloseDBConnection();
        }

        public static void UpdateProductCategoryName(int productCategoryID, string productCategoryName)
        {
            DBInteraction.SetUpDBConnection();
            string spCallString = "EXEC [dbo].[uspUpdateProductCategoryByID]" + 
                "@ProductCategoryID, @ProductCategoryName ;";
            SqlCommand sqlCommand = new SqlCommand(spCallString, DBConnection.SqlDBConnection);
            sqlCommand.Parameters.AddWithValue("@ProductCategoryID", productCategoryID);
            sqlCommand.Parameters.AddWithValue("@ProductCategoryName", productCategoryName);
            SqlDataReader queryResult = DBInteraction.ExecuteCommand(sqlCommand);
            DisplayOperationStatus(queryResult);
            DBInteraction.databaseConnection.CloseDBConnection();
        }

        private static void DisplayOperationStatus(SqlDataReader queryResult)
        {
            Console.WriteLine("Operation Successful");
        }

        public static void GetAllProductCategories()
        {
            DBInteraction.SetUpDBConnection();
            string spCallString = "EXEC dbo.uspGetAllProductCategories;";
            SqlCommand sqlCommand = new SqlCommand(spCallString, DBConnection.SqlDBConnection);
            SqlDataReader queryResult = DBInteraction.ExecuteCommand(sqlCommand);
            Display(queryResult);
            DBInteraction.databaseConnection.CloseDBConnection();
        }

        /// <summary>
        /// This method displays the results send by a query on the console
        /// </summary>
        /// <param name="queryResult">This parameter is the results send by the query</param>
        internal static void Display(SqlDataReader queryResult)
        {
            if (!queryResult.HasRows)
            {
                Console.WriteLine("No details found for criteria. Please retry with a different Criteria");
                return;
            }

            while (queryResult.Read())
            {
                for (int i = 0; i < queryResult.FieldCount; i++)
                {
                    Console.Write("\t{0}\t", queryResult[i]);
                }
                Console.WriteLine();

            }
            queryResult.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DBWrapper
{
    /// <summary>
    /// This class provides an interface for the performing operations on the database.
    /// </summary>
    public class DBInterface
    {

        static string StoredProcedureName; 
        static List<SqlParameter> StoredProcedureParameterList = new List<SqlParameter>();

        public static SqlDataReader GetProductDetailsByCategoryID(int productCategoryID)
        {
            
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "dbo.uspGetProductCategoryDetailsByID";
            StoredProcedureParameterList.Add(new SqlParameter("@ProductCategoryID", productCategoryID));
            return  DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static void GetAllActiveProductCategories()
        {
            string spCallString = "EXEC dbo.uspGetAllActiveProductCategories;";
            SqlCommand sqlCommand = new SqlCommand(spCallString, DBConnection.SqlDBConnection);
            SqlDataReader queryResult = DBInteraction.ExecuteCommand(sqlCommand);
            Display(queryResult);
        }

        public static void InsertProductCategory(string productCategoryName)
        {
            string spCallString = "EXEC [dbo].[uspInsertProductCategory] @ProductCategoryName;";
            SqlCommand sqlCommand = new SqlCommand(spCallString, DBConnection.SqlDBConnection);
            sqlCommand.Parameters.AddWithValue("@ProductCategoryName", productCategoryName);
            SqlDataReader queryResult = DBInteraction.ExecuteCommand(sqlCommand);
            DisplayOperationStatus(queryResult);
        }

        public static void InactivateProductCategory(int productCategoryID)
        {

            string spCallString = "EXEC [dbo].[uspUpdateProductCategoryAsInactive] @ProductCategoryID;";
            SqlCommand sqlCommand = new SqlCommand(spCallString, DBConnection.SqlDBConnection);
            sqlCommand.Parameters.AddWithValue("@ProductCategoryID", productCategoryID);
            SqlDataReader queryResult = DBInteraction.ExecuteCommand(sqlCommand);
            DisplayOperationStatus(queryResult);
        }

        public static void UpdateProductCategoryName(int productCategoryID, string productCategoryName)
        {
            string spCallString = "EXEC [dbo].[uspUpdateProductCategoryByID]" + 
                "@ProductCategoryID, @ProductCategoryName ;";
            SqlCommand sqlCommand = new SqlCommand(spCallString, DBConnection.SqlDBConnection);
            sqlCommand.Parameters.AddWithValue("@ProductCategoryID", productCategoryID);
            sqlCommand.Parameters.AddWithValue("@ProductCategoryName", productCategoryName);
            SqlDataReader queryResult = DBInteraction.ExecuteCommand(sqlCommand);
            DisplayOperationStatus(queryResult);
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

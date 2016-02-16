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

        public static SqlDataReader GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public static SqlDataReader GetProductDetailsByCategoryID(int productCategoryID)
        {  
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "dbo.uspGetProductCategoryDetailsByID";
            StoredProcedureParameterList.Add(new SqlParameter("@ProductCategoryID", productCategoryID));
            return  DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

       

        public static void InsertProductCategory(string productCategoryName)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "[dbo].[uspInsertProductCategory]";
            StoredProcedureParameterList.Add(new SqlParameter("@ProductCategoryName", productCategoryName));
            int queryResult = DBInteraction.ExecuteNonSelect(StoredProcedureName, StoredProcedureParameterList);
            DisplayOperationStatus(queryResult);
        }

    

        private static void DisplayOperationStatus(object queryResult)
        {
            Console.WriteLine("Operation Successful");
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

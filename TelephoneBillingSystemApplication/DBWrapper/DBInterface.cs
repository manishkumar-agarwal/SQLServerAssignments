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
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "[TelephoneSystem].[uspGetAllCustomers]";
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetProductDetailsByCategoryID(int productCategoryID)
        {  
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "dbo.uspGetProductCategoryDetailsByID";
            StoredProcedureParameterList.Add(new SqlParameter("@ProductCategoryID", productCategoryID));
            return  DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetAllEmployees()
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "[TelephoneSystem].[uspGetAllEmployees]";
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static void InsertProductCategory(string productCategoryName)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "[dbo].[uspInsertProductCategory]";
            StoredProcedureParameterList.Add(new SqlParameter("@ProductCategoryName", productCategoryName));
            int queryResult = DBInteraction.ExecuteNonSelect(StoredProcedureName, StoredProcedureParameterList);
            //DisplayOperationStatus(queryResult);
        }
    }
}

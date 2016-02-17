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

        public static SqlDataReader GetCustomerByID(int customerMobileNumber)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "[TelephoneSystem].[uspGetCustomerById]";
            StoredProcedureParameterList.Add(new SqlParameter("@customerMobileNumer", customerMobileNumber));
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static int AddCutomer(int customerMobileNumber, string customerName, string customerEmail, int employeeId, string customerIdentity)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "[TelephoneSystem].[uspAddCustomer]";
            StoredProcedureParameterList.Add(new SqlParameter("@CustomerMobileNumber", customerMobileNumber));
            StoredProcedureParameterList.Add(new SqlParameter("@CustomerName", customerName));
            StoredProcedureParameterList.Add(new SqlParameter("@CustomerEmailAddress", customerEmail));
            StoredProcedureParameterList.Add(new SqlParameter("@CustomersEmployeeId", employeeId));
            StoredProcedureParameterList.Add(new SqlParameter("@CustomersIdentity", customerIdentity));
            return DBInteraction.ExecuteNonSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetCustomerBillHistory(int customerMobileNumber)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "[TelephoneSystem].[uspGetCustomerBillHistory]";
            StoredProcedureParameterList.Add(new SqlParameter("@customerMobileNumer", customerMobileNumber));
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);

        }

        public static int UpdateCustomer(int customerMobileNumber, string customerEmail)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "[TelephoneSystem].[uspUpdateCustomer]";
            StoredProcedureParameterList.Add(new SqlParameter("@CustomerMobileNumber", customerMobileNumber));
            StoredProcedureParameterList.Add(new SqlParameter("@CustomerEmailAddress", customerEmail));
            return DBInteraction.ExecuteNonSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetCutomersForEmployee(int employeeId)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "[TelephoneSystem].[uspGetAllCustomersForEmployee]";
            StoredProcedureParameterList.Add(new SqlParameter("@EmployeeID", employeeId));
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetSummaryForEmployees()
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "[TelephoneSystem].[uspSummaryForEmployees]";
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetBonusForEmployee(int employeeId)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "[TelephoneSystem].[uspGetBonusForEmployee]";
            StoredProcedureParameterList.Add(new SqlParameter("@EmployeeID", employeeId));
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetEmployeeById(int employeeId)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "[TelephoneSystem].[uspGetEmployeeByID]";
            StoredProcedureParameterList.Add(new SqlParameter("@EmployeeID", employeeId));
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetAllEmployees()
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = "[TelephoneSystem].[uspGetAllEmployees]";
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

       
    }
}

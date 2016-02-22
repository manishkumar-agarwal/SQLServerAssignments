using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

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
            StoredProcedureName = ConfigurationManager.AppSettings.Get("GetAllCustomersSP");
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetCustomerByID(int customerMobileNumber)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = ConfigurationManager.AppSettings.Get("GetCustomerByIdSP");
            StoredProcedureParameterList.Add(new SqlParameter("@customerMobileNumer", customerMobileNumber));
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static int AddCutomer(int customerMobileNumber, string customerName, string customerEmail, int employeeId, string customerIdentity)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = ConfigurationManager.AppSettings.Get("AddCustomerSP");
            StoredProcedureParameterList.Add(new SqlParameter("@CustomerMobileNumber", customerMobileNumber));
            StoredProcedureParameterList.Add(new SqlParameter("@CustomerName", customerName));
            StoredProcedureParameterList.Add(new SqlParameter("@CustomerEmailAddress", customerEmail));
            StoredProcedureParameterList.Add(new SqlParameter("@CustomersEmployeeId", employeeId));
            StoredProcedureParameterList.Add(new SqlParameter("@CustomersIdentity", customerIdentity));
            return DBInteraction.ExecuteNonSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static int RecordBillPaymentForCustomer(int customerMobileNumber, string billPaymentMode, decimal billAmount)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = ConfigurationManager.AppSettings.Get("RecordBillPaymentForCustomerSP");
            StoredProcedureParameterList.Add(new SqlParameter("@CustomerMobileNumber", customerMobileNumber));
            StoredProcedureParameterList.Add(new SqlParameter("@BillPaymentMode", billPaymentMode));
            StoredProcedureParameterList.Add(new SqlParameter("@BillAmount", billAmount));
            return DBInteraction.ExecuteNonSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetCustomerBillHistory(int customerMobileNumber)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = ConfigurationManager.AppSettings.Get("GetCustomerBillHistorySP");
            StoredProcedureParameterList.Add(new SqlParameter("@customerMobileNumer", customerMobileNumber));
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);

        }

        public static int UpdateCustomer(int customerMobileNumber, string customerEmail)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = ConfigurationManager.AppSettings.Get("UpdateCustomerSP");
            StoredProcedureParameterList.Add(new SqlParameter("@CustomerMobileNumber", customerMobileNumber));
            StoredProcedureParameterList.Add(new SqlParameter("@CustomerEmailAddress", customerEmail));
            return DBInteraction.ExecuteNonSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetCutomersForEmployee(int employeeId)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = ConfigurationManager.AppSettings.Get("GetCustomersForEmployeeSP");
            StoredProcedureParameterList.Add(new SqlParameter("@EmployeeID", employeeId));
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetSummaryForEmployees()
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = ConfigurationManager.AppSettings.Get("GetSummaryForEmployeesSP");
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetBonusForEmployee(int employeeId)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = ConfigurationManager.AppSettings.Get("GetBonusForEmployeeSP");
            StoredProcedureParameterList.Add(new SqlParameter("@EmployeeID", employeeId));
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetEmployeeById(int employeeId)
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = ConfigurationManager.AppSettings.Get("GetEmployeeByIDSP");
            StoredProcedureParameterList.Add(new SqlParameter("@EmployeeID", employeeId));
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

        public static SqlDataReader GetAllEmployees()
        {
            StoredProcedureParameterList.Clear();
            StoredProcedureName = ConfigurationManager.AppSettings.Get("GetAllEmployeesSP");
            return DBInteraction.ExecuteSelect(StoredProcedureName, StoredProcedureParameterList);
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBWrapper;

namespace UserInterfaceFunctions
{
    class UserInterfaceToDbAccessFunctions
    {
        internal static SqlDataReader DisplayAllCustomers()
        {
            return DBInterface.GetAllCustomers();
        }

        internal static SqlDataReader DisplayCustomerByID()
        {
            var customerMobileNumber = UserInterfaceSetupFunctions.GetMobileNumber();
            return DBInterface.GetCustomerByID(customerMobileNumber);
        }

        internal static SqlDataReader DisplayCustomerBillHistory()
        {
            var customerMobileNumber = UserInterfaceSetupFunctions.GetMobileNumber();
            return DBInterface.GetCustomerBillHistory(customerMobileNumber);
        }

        internal static SqlDataReader DisplayAllEmployees()
        {
            return DBInterface.GetAllEmployees();
        }

        internal static SqlDataReader DisplayEmployeeByID()
        {
            var employeeId = UserInterfaceSetupFunctions.GetEmployeeId();
            return DBInterface.GetEmployeeById(employeeId);
        }

        internal static SqlDataReader DisplayEmployeesCustomers()
        {
            throw new NotImplementedException();
        }

        internal static SqlDataReader DisplayBonusForEmployee()
        {
            throw new NotImplementedException();
        }
    }
}

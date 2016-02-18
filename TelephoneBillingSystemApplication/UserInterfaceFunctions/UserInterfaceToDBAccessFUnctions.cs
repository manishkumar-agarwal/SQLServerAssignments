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

        internal static void AddCustomer()
        {
            var customerMobileNumber = UserInterfaceSetupFunctions.GetMobileNumber();
            var customerName = UserInterfaceSetupFunctions.GetCustomerName();
            var customerEmail = UserInterfaceSetupFunctions.GetCustomerEmail();
            var employeeId = UserInterfaceSetupFunctions.GetEmployeeId();
            var customerIdentity = UserInterfaceSetupFunctions.GetCustomerIdentity();
            int insertCount = DBInterface.AddCutomer(customerMobileNumber, customerName, customerEmail,
                employeeId, customerIdentity);
            if(insertCount > 0)
            {
                Console.WriteLine("Inserted Customer Successfully");
            }
        }

        internal static void RecordBillPayment()
        {
            var customerMobileNumber = UserInterfaceSetupFunctions.GetMobileNumber();
            var billPaymentMode = UserInterfaceSetupFunctions.GetBillPaymemtMode();
            var billAmount = UserInterfaceSetupFunctions.GetBillAmount();
            int insertCount = DBInterface.RecordBillPaymentForCustomer(customerMobileNumber, billPaymentMode, billAmount);
            if (insertCount > 0)
            {
                Console.WriteLine("Inserted Customer Bill Successfully");
            }
        }

        internal static void UpdateCustomer()
        {
            var customerMobileNumber = UserInterfaceSetupFunctions.GetMobileNumber();
            var customerEmail = UserInterfaceSetupFunctions.GetCustomerEmail();
            int updateCount = DBInterface.UpdateCustomer(customerMobileNumber, customerEmail);

            if(updateCount == 0)
            {
                Console.WriteLine("Update Customer Not Successful");
            }
            else
            {
                Console.WriteLine("Updated Customer successfully");
            }
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
            var employeeId = UserInterfaceSetupFunctions.GetEmployeeId();
            return DBInterface.GetCutomersForEmployee(employeeId);
        }

        internal static SqlDataReader DisplayBonusForEmployee()
        {
            var employeeId = UserInterfaceSetupFunctions.GetEmployeeId();
            return DBInterface.GetBonusForEmployee(employeeId);
        }

        internal static SqlDataReader DisplayTransactionSummaryForEmployees()
        {
            return DBInterface.GetSummaryForEmployees();
        }
    }
}

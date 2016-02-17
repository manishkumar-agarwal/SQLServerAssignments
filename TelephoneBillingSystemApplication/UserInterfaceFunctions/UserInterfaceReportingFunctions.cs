using System;
using System.Data.SqlClient;
using TelephoneBillingSystemChoices;

namespace UserInterfaceFunctions
{
    public class UserInterfaceReportingFunctions
    {
        public static void UserReportingFunction(TelephoneBillSystemChoices userChoice)
        {
            try
            {
                SqlDataReader queryResult = null;
                switch (userChoice)
                {
                    case TelephoneBillSystemChoices.DisplayAllCustomers:
                    case TelephoneBillSystemChoices.DisplayCustomerByID:
                    case TelephoneBillSystemChoices.DisplayCustomerBillingHistory:
                        queryResult = CustomerRelatedReporting(userChoice);
                        break;
                    case TelephoneBillSystemChoices.DisplayAllEmployees:
                    case TelephoneBillSystemChoices.DisplayEmployeeByID:
                    case TelephoneBillSystemChoices.DisplayCustomersOfEmployee:
                    case TelephoneBillSystemChoices.DisplayTransactionSummaryforEmployees:
                    case TelephoneBillSystemChoices.CalculateEmployeeBonus:
                        queryResult = EmployeeRelatedReporting(userChoice);
                        break;
                }

                UserInterfaceDisplayFunctions.DisplayQueryResult(queryResult);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception Occured" + ex.Message);
            }
        }

        private static SqlDataReader CustomerRelatedReporting(TelephoneBillSystemChoices userChoice)
        {
            SqlDataReader queryResult = null;
            switch (userChoice)
            {
                case TelephoneBillSystemChoices.DisplayAllCustomers:
                    queryResult = UserInterfaceToDbAccessFunctions.DisplayAllCustomers();
                    break;
                case TelephoneBillSystemChoices.DisplayCustomerByID:
                    queryResult = UserInterfaceToDbAccessFunctions.DisplayCustomerByID();
                    break;
                case TelephoneBillSystemChoices.DisplayCustomerBillingHistory:
                    queryResult = UserInterfaceToDbAccessFunctions.DisplayCustomerBillHistory();
                    break;
            }
            return queryResult;

        }

        private static SqlDataReader EmployeeRelatedReporting(TelephoneBillSystemChoices userChoice)
        {
            SqlDataReader queryResult = null;
            switch (userChoice)
            {
                case TelephoneBillSystemChoices.DisplayAllEmployees:
                    queryResult = UserInterfaceToDbAccessFunctions.DisplayAllEmployees();
                    break;
                case TelephoneBillSystemChoices.DisplayEmployeeByID:
                    queryResult = UserInterfaceToDbAccessFunctions.DisplayEmployeeByID();
                    break;
                case TelephoneBillSystemChoices.DisplayCustomersOfEmployee:
                    queryResult = UserInterfaceToDbAccessFunctions.DisplayEmployeesCustomers();
                    break;
                case TelephoneBillSystemChoices.DisplayTransactionSummaryforEmployees:
                    queryResult = UserInterfaceToDbAccessFunctions.DisplayTransactionSummaryForEmployees();
                    break;
                case TelephoneBillSystemChoices.CalculateEmployeeBonus:
                    queryResult = UserInterfaceToDbAccessFunctions.DisplayBonusForEmployee();
                    break;
            }
            return queryResult;
        }
    }
}

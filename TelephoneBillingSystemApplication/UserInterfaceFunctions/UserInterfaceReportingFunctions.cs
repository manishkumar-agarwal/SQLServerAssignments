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
                        queryResult = UserInterfaceToDbAccessFunctions.DisplayAllCustomers();
                        break;
                }

                UserInterfaceDisplayFunctions.DisplayQueryResult(queryResult);
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Exception Occured");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured");
            }
        }
    }
}

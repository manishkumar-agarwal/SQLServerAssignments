using System;
using System.Data.SqlClient;
using TelephoneBillingSystemChoices;

namespace UserInterfaceFunctions
{
    public class UserInterfaceModificationFunctions
    {
        public static void UserDataModificationFunction(TelephoneBillSystemChoices userChoice)
        {
            try
            {
                switch (userChoice)
                {
                    case TelephoneBillSystemChoices.AddCustomer:
                        UserInterfaceToDbAccessFunctions.AddCustomer();
                        break;
                    case TelephoneBillSystemChoices.UpdateCustomer:
                        UserInterfaceToDbAccessFunctions.UpdateCustomer();
                        break;
                    case TelephoneBillSystemChoices.GenerateCustomerBill:
                    case TelephoneBillSystemChoices.RecordPayment:
                        UserInterfaceToDbAccessFunctions.RecordBillPayment();
                        break;
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception Occured" + ex.Message);
            }
        }
    }
}

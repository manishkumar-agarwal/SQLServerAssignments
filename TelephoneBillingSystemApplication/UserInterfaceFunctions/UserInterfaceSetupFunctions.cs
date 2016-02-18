using System;
using UserInputFunctions;

namespace UserInterfaceFunctions
{
    class UserInterfaceSetupFunctions
    {

        internal static int GetEmployeeId()
        {
            var employeeId = UserInputGathering.GetIntergerInput("Please enter the Employee ID");

            if (UserInputValidation.IsValidIntegerValue(employeeId) == false)
            {
                throw new InvalidOperationException(" ");
            }

            return employeeId;

        }

        internal static int GetMobileNumber()
        {
            var mobileNumber = UserInputGathering.GetIntergerInput("Please enter the Customer Mobile Number");

            if (UserInputValidation.IsValidMobileNumber(mobileNumber) == false)
            {
                throw new InvalidOperationException("Mobile Number not valid ");
            }

            return mobileNumber;

        }

        internal static string GetCustomerName()
        {
            var customerName = UserInputGathering.GetStringInput("Enter Customer Name");
            if (!UserInputValidation.IsValidString(customerName))
            {
                throw new InvalidOperationException(" ");

            }

            return customerName;
        }

        internal static string GetCustomerIdentity()
        {
            var customerIdentity = UserInputGathering.GetStringInput("Enter Customer Identity Type");
            if (!UserInputValidation.IsValidCustomerIdentity(customerIdentity))
            {
                throw new InvalidOperationException(" ");

            }

            return customerIdentity;
        }

        internal static string GetBillPaymemtMode()
        {
            var billPaymentMode = UserInputGathering.GetStringInput("Enter Bill Payment Mode");
            if (!UserInputValidation.IsValidString(billPaymentMode))
            {
                throw new InvalidOperationException(" ");

            }

            return billPaymentMode;
        }

        internal static decimal GetBillAmount()
        {
            var amount = UserInputGathering.GetStringInput("Enter Bill Amount");
            var billAmount = Decimal.Parse(amount);
            if(billAmount <=0 || billAmount >= 1000000)
            {
                Console.WriteLine("Bad Amount Value");
                throw new InvalidOperationException(" ");
            }

            return billAmount;
        }

        internal static string GetCustomerEmail()
        {
            var customerEmailAddress = UserInputGathering.GetStringInput("Enter Customer Email");
            if (!UserInputValidation.IsValidEmailAddress(customerEmailAddress))
            {
                throw new InvalidOperationException(" ");

            }

            return customerEmailAddress;
        }
    }
}

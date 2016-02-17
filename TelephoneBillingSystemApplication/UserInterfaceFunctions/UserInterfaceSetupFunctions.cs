using System;
using UserInputFunctions;

namespace UserInterfaceFunctions
{
    class UserInterfaceSetupFunctions
    {

        internal static int GetEmployeeId()
        {
            int employeeId = UserInputGathering.GetIntergerInput("Please enter the Employee ID");

            if (UserInputValidation.IsValidIntegerValue(employeeId) == false)
            {
                throw new InvalidOperationException(" ");
            }

            return employeeId;

        }

        internal static int GetMobileNumber()
        {
            int mobileNumber = UserInputGathering.GetIntergerInput("Please enter the Customer Mobile Number");

            if (UserInputValidation.IsValidMobileNumber(mobileNumber) == false)
            {
                throw new InvalidOperationException("Mobile Number not valid ");
            }

            return mobileNumber;

        }
    }
}

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
    }
}

using System;
using TelephoneBillingSystemChoices;
using UserInputFunctions;
using UserInterfaceFunctions;

namespace UserActionsWrapper
{
    /// <summary>
    /// This class provides methods for the interaction with the user
    /// </summary>
    public class UserInteractionFunctions
    {
        public static TelephoneBillSystemChoices GetUserActionChoice()
        {
            TelephoneBillSystemChoices usersFunctionChoice = PromptUsersChoice();

            if (!ValidateUsersChoice(usersFunctionChoice))
            {
                throw new InvalidOperationException("\nBad Option Choice!! Please Try Again with a Valid Choice\n");
            }

            return usersFunctionChoice;
        }

        /// <summary>
        /// This method prompts the user options and takes a UserFunctionChoice input from user
        /// </summary>
        /// <returns>Returns the Users Choice of Action </returns>
        private static TelephoneBillSystemChoices PromptUsersChoice()
        {
            Console.Write("\nWelcome to the Telephone Billing System Console" +
                "\nPlease enter the action to perform " +
                "\n1) Display All Telephone Customers" +
                "\n2) Display Customer By ID" +
                "\n3) Display Customer Billing History" +
                "\n4) Display Telephone Company Employees" +
                "\n5) Display Employee By ID" +
                "\n6) Display Customers Of an Employee" +
                "\n7) Display Summary for Employees " +
                "\n8) Display Employee Bonus Details " +
                "\n9) Add a New Customer" +
                "\n10) Update Customer Name" +
                "\n11) Generate New Customer Bill" +
                "\n12) Record Customer Bill Payment" +
                "\n13) End Application\n\nPlease enter your choice : ");

            TelephoneBillSystemChoices userChoice = UserInputGathering.GetUsersChoice();
            return userChoice;
        }

        /// <summary>
        /// This method performs validation to check that the userchoice is valid
        /// </summary>
        /// <param name="userChoice"> Users Choice inputted for action</param>
        /// <returns>Flag indicating the users choice is valid or not</returns>
        private static bool ValidateUsersChoice(TelephoneBillSystemChoices userChoice)
        {
            bool isValidUserChoiceFlag = UserInputValidation.IsValidUserChoice(userChoice);
            return isValidUserChoiceFlag;
        }


        /// <summary>
        /// This method calls the appropriate methods based on the UsersChoice of activity
        /// </summary>
        /// <param name="userChoice">This is the UsersChoice which has been inputted by User.</param>
        public static void ProcessUsersChoice(TelephoneBillSystemChoices userChoice)
        {

            switch (userChoice)
            {
                case TelephoneBillSystemChoices.DisplayAllCustomers:
                case TelephoneBillSystemChoices.DisplayCustomerByID:
                case TelephoneBillSystemChoices.DisplayCustomerBillingHistory:
                case TelephoneBillSystemChoices.DisplayAllEmployees:
                case TelephoneBillSystemChoices.DisplayEmployeeByID:
                case TelephoneBillSystemChoices.CalculateEmployeeBonus:
                case TelephoneBillSystemChoices.DisplayCustomersOfEmployee:
                case TelephoneBillSystemChoices.DisplayTransactionSummaryforEmployees:
                    UserInterfaceReportingFunctions.UserReportingFunction(userChoice);
                    break;
                case TelephoneBillSystemChoices.AddCustomer:
                case TelephoneBillSystemChoices.UpdateCustomer:
                case TelephoneBillSystemChoices.GenerateCustomerBill:
                case TelephoneBillSystemChoices.RecordPayment:
                    UserInterfaceModificationFunctions.UserDataModificationFunction(userChoice);
                    break;
                case TelephoneBillSystemChoices.EndApplication:
                    Console.WriteLine("\nThanks for Using Telephone Billing System Application!!\n");
                    return;

            }
        }
    }
}

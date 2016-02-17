using System;
using TelephoneBillingSystemChoices;

namespace UserInputFunctions
{
    /// <summary>
    /// This class provides functionality to validate user inputs
    /// </summary>
    public class UserInputValidation
    {

        /// <summary>
        /// This method validates if a character input is valid
        /// </summary>
        /// <param name="inputCharacter">character input to check for validity</param>
        /// <returns>Returns a flag indicating character is valid or not</returns>
        public static bool IsValidLetter(char inputCharacter)
        {
            var isValidLetterFlag = true;
            if (!char.IsLetter(inputCharacter))
            {
                Console.WriteLine("Bad Input Character!!. Please try again with proper input");
                isValidLetterFlag = false;
            }

            return isValidLetterFlag;
        }

        public static bool IsValidMobileNumber(int mobileNumber)
        {
            var isValidMobileNumber = true;

            if(mobileNumber < 1000000000 || mobileNumber > 2000000000)
            {
                isValidMobileNumber = false;
            }
            return isValidMobileNumber;
        }

        public static bool IsValidEmailAddress(string customerEmailAddress)
        {
            var isValidEmailAddress = true;

            if (!customerEmailAddress.Contains("@"))
            {
                isValidEmailAddress = false;
            }
            return isValidEmailAddress;
        }

        public static bool IsValidCustomerIdentity(string customerIdentity)
        {
            var isValidIdentity = true;
            

            if (!(customerIdentity.Equals("Aadhar") ||
                  customerIdentity.Equals("PAN Card") ||
                  customerIdentity.Equals("Passport")))
            {
                Console.WriteLine("Bad Customer Identity");
                isValidIdentity = false;
            }
            return isValidIdentity;
        }


        /// <summary>
        /// This method checks if the Input User Choice is Valid
        /// </summary>
        /// <param name="userChoice">The UsersChoice inputted by the user</param>
        /// <returns>Returns a boolean flag to indicate if input UserChoice is valid</returns>
        public static bool IsValidUserChoice(TelephoneBillSystemChoices userChoice)
        {
            var isValidUserChoiceFlag = false;

            if (Enum.IsDefined(typeof(TelephoneBillSystemChoices),userChoice))
                isValidUserChoiceFlag = true;

            return isValidUserChoiceFlag;

        }

        /// <summary>
        /// This method checks if the given input string has a valid value for further processing 
        /// </summary>
        /// <param name="stringToValidate"> This is the string value which needs to be validated</param>
        /// <returns> A flag indicating the string is valid or invalid</returns>
        public static bool IsValidString(string stringToValidate)
        {
            var validStringFlag = true;
            if (String.IsNullOrWhiteSpace(stringToValidate))
            {
                Console.WriteLine("Empty String Passed, Please Provide Proper Input");
                validStringFlag = false;
            }
            return validStringFlag;
        }

        /// <summary>
        /// This method validates if an input integer is valid
        /// </summary>
        /// <param name="integerValue">integer input to check for validity</param>
        /// <returns>Returns a flag indicating character is valid or not</returns>
        public static bool IsValidIntegerValue(int integerValue)
        {
            var isValidIntegerValue = true;
            if (integerValue == 0)
            {
                Console.WriteLine("Cannot be Zero Integer");
                isValidIntegerValue = false;
            }

            return isValidIntegerValue;
        }



        /// <summary>
        /// This method validates if the start character and end character combination is valid
        /// </summary>
        /// <param name="startCharacter">start character</param>
        /// <param name="endCharacter">end character</param>
        /// <returns>Returns a flag to indicate the start character and end character combination is valid</returns>
        public static bool ValidateStartAndEndCharacter(char startCharacter, char endCharacter)
        {
            var isStartEndCharacterValid = true;
            if (startCharacter > endCharacter)
            {
                Console.WriteLine($"\nStart Character {startCharacter} cannot be after the " +
                    $"End Character {endCharacter} .\n Bad Input!! Please retry with correct Inputs\n");

                isStartEndCharacterValid = false;
            }

            return isStartEndCharacterValid;
        }
    }
}

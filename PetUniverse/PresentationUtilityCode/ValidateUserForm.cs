using DataTransferObjects;
using System;

namespace PresentationUtilityCode
{
    /// <summary>
    /// Creator: Steven Cardona
    /// Created: 02/10/2020
    /// Approver: Zach Behrensmeyer
    ///
    /// Class with validation methods for users
    /// </summary>
    public static class ValidateUserForm
    {

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// This is to verify that FirstName is not null, blank or a space
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        /// <param name="firstName">The String that is from the first name text box</param>
        /// <returns>true if firstName meets all if condition else method returns false</returns>
        public static bool IsValidFirstName(this string firstName)
        {
            bool isValid = false;

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// This is to verify that Last Name is not null, blank or a space
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// </remarks>
        /// <param name="lastName">The String that is from the last name text box</param>
        /// <returns>true if lastName meets all if condition else method returns false</returns>
        public static bool IsValidLastName(this string lastName)
        {
            bool isValid = false;

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// This method checks if provided email address is valid
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(this string email)
        {
            bool isValid = false;

            if (!string.IsNullOrWhiteSpace(email) && email.Length <= 100 && email.Contains("@") && email.Contains(".") && email.Length > 7)
            {
                isValid = true;
            }
            return isValid;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020
        /// Approver: Zach Behrensmeyer        
        /// 
        /// This method checks if provided phone number is valid
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// </remarks>
        /// <param name="phoneNumber">Phone number provided by textbox input</param>
        /// <returns>return true if phonenumber passes all condition else returns false or throws
        /// exception because it can't convert to int64</returns>
        public static bool IsValidPhoneNumber(this string phoneNumber)
        {
            bool isValid = false;
            
            // check length
            if (!string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length == 10)
            {
                try
                {
                    // Check if all digits
                    long phone = Convert.ToInt64(phoneNumber);

                    // if all digits is valid = true
                    isValid = true;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Invalid phone number");
                }
            }
            return isValid;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/11/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This method checks if provided phone number is valid
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// </remarks>
        /// <param name="city">String value of city from city textbox</param>
        /// <returns>Returns true if city is less than or equal to 20 characters
        /// long else returns false</returns>
        public static bool IsValidCity(this string city)
        {
            bool isValid = false;

            if (!string.IsNullOrEmpty(city) && city.Length <= 20)
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/11/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This method checks if provided phone number is valid
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// </remarks>
        /// <param name="state">State value that is being validated</param>
        /// <returns>Return true if state is in Enumeration else returns falsef</returns>
        public static bool IsValidState(this string state)
        {
            bool isValid = false;

            States.StatesAb testState;
            if (Enum.TryParse<States.StatesAb>(state, out testState))
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/11/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This method checks if provided phone number is valid
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// </remarks>
        /// <param name="zipcode">Zipcode that is being validated</param>
        /// <returns>Returns true if password is at least 7 characters long</returns>
        public static bool IsValidZipcode(this string zipcode)
        {
            bool isValid = false;

            if (string.IsNullOrWhiteSpace(zipcode) && zipcode.Length == 5)
            {
                try
                {
                    int zip = Int32.Parse(zipcode);
                    isValid = true;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Invalid Zipcode");
                }
            }

            return isValid;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/11/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This method checks if the provided Password is at least 7 characters long
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// </remarks>
        /// <param name="password"></param>
        /// <returns>Returns true if password is at least 7 characters else return false</returns>
        public static bool IsValidPassword(this string password)
        {
            bool result = false;

            if (password.Length >= 7)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 03/01/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This method checks if the provided Password is at least 7 characters long
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// </remarks>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool IsValidAddress1(this string address)
        {
            bool result = false;

            if (address.Length <= 250)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 03/01/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This method checks if the provided Password is at least 7 characters long
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// </remarks>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool IsValidAddress2(this string address)
        {
            bool result = false;

            if (address.Length <= 250 || string.IsNullOrEmpty(address))
            {
                result = true;
            }

            return result;
        }

    }
}

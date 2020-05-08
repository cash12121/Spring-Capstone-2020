using System;
using System.Linq;

namespace PresentationUtilityCode
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 3/1/2020
    /// Approver: Ben Hanna, 3/6/2020
    /// Approver: 
    /// 
    /// A utility class for validating the animal
    /// vet appointment form
    /// </summary>
    public static class ValidateVetAppointmentForm
    {
        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver: 
        /// 
        /// Validates the appointment time. The time field must contain
        /// a colon and an am or pm to be valid. It must also be able to
        /// be parsed with the selected appointent date
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public static bool IsValidTime(this string time, DateTime date)
        {
            return time.Contains(":") &&
                time.ToLower().Contains("pm") ||
                time.ToLower().Contains("am") &&
                DateTime.TryParse(
                    date.ToShortDateString() + " " + time, out date);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver: 
        /// 
        /// Validates the vet name. Vet names can't be blank
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public static bool IsValidVetName(this string vetName)
        {
            return vetName != " " &&
                vetName != "";
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver: 
        /// 
        /// Validates the clinic address. The address can't be blank,
        /// must contain a combination of digits and letters, and must
        /// contain spaces. 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public static bool IsValidClinicAddress(this string clinicAddress)
        {
            return clinicAddress != "" &&
                clinicAddress != " " &&
                clinicAddress.Any(char.IsDigit) &&
                clinicAddress.Any(char.IsLetter) &&
                clinicAddress.Any(char.IsWhiteSpace);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver: 
        /// 
        /// Validates the appointment description. Description must
        /// be greater than 5 characters
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public static bool IsValidAppointmentDescription(
            this string description)
        {
            return description.Length > 5;
        }
    }
}

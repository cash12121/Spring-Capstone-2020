using DataTransferObjects;
using System.Collections.Generic;

namespace PresentationUtilityCode
{
    /// <summary>
	/// Creator: Chase Schulte
	/// Created: 02/07/2020
	/// Approver: Kaleb Bachert
	///
	/// Class for validating ERoleView
	/// </summary>
    public static class ValidateERole
    {

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Check if ERoleID string length and if it's empty
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="eRole"></param>
        /// <returns></returns>
        public static bool checkERoleID(this string eRole)
        {
            bool isValid = false;
            if (eRole.Length > 1 && eRole.Length < 50)
            {

                isValid = true;
            }
            return isValid;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Check if DepartmentID string length and if it's empty
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="dept"></param>
        /// <returns></returns>
        public static bool checkDepartmentID(this string dept)
        {
            bool isValid = false;

            if (dept.Length > 0 && dept.Length < 50)
            {

                isValid = true;
            }
            return isValid;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Check if Description is too long
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="description"></param>
        /// <returns></returns>
        public static bool checkDescription(this string description)
        {
            bool isValid = false;
            if (description.Length < 200)
            {

                isValid = true;
            }
            return isValid;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Check if eRole is too long, too small
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="eRole"></param>
        /// <returns></returns>
        public static bool checkERoleIndex(this int eRoleIndex, List<ERole> eRoles)
        {
            bool isValid = false;
            if (eRoleIndex < 0 || eRoleIndex >= eRoles.Count)
            {
                isValid = true;
            }
            return isValid;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Simple string compari
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="aString"></param>
        /// <param name="anotherString"></param>
        /// <returns></returns>
        public static bool checkStringIsEqual(this string aString, string anotherString)
        {
            bool isValid = false;
            if (aString == anotherString)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}

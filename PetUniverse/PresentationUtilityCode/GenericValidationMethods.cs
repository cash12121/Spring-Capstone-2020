namespace PresentationUtilityCode
{
    public static class GenericValidationMethods
    {
        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/3/2020
        /// Approver: Thomas Dupuy
        ///
        /// This is a generic extension method used to validate any string
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// </remarks>
        /// <param name="anyString"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static bool IsValidString(this string anyString, int maxLength)
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(anyString) && anyString.Length <= maxLength)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/3/2020
        /// Approver: Thomas Dupuy
        ///
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// </remarks>
        /// <param name="anyString"></param>
        /// <returns></returns>
        public static bool IsValidString(this string anyString)
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(anyString))
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/3/2020
        /// Approver: Thomas Dupuy
        ///
        /// This is a generic extension method used to validate any string
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// </remarks>
        /// <param name="anyString"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static bool IsValidString(this string anyString, int maxLength, int minLength)
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(anyString)
                && anyString.Length <= maxLength
                && anyString.Length >= minLength)
            {
                result = true;
            }
            return result;
        }
    }
}

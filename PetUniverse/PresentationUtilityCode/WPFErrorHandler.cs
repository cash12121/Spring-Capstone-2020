using System.Windows;

namespace PresentationUtilityCode
{
    /// <summary>
    /// Creator: Steven Cardona
    /// Created: 02/11/2020
    /// Approver: Zach Behrensmeyer
    /// 
    /// Class to handle error messaging that are 
    /// coming directly from the WPF Presentaion Layer
    /// </summary>
    public static class WPFErrorHandler
    {
        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/11/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Method of general Error handling.
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="message"></param>
        /// <param name="typeOfError"></param>
        public static void ErrorMessage(this string message, string typeOfError = null)
        {
            string caption = null;
            if (!string.IsNullOrEmpty(typeOfError))
            {
                caption = typeOfError + " Error";
            }
            else
            {
                caption = "Error";
            }
            MessageBox.Show(message, caption, MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        ///// <summary>
        ///// Creator: Carl Davis
        ///// Date: 02/22/2020
        ///// Approver: Steven Cardona
        ///// 
        ///// Method of general Error handling.
        ///// </summary>
        ///// <remarks>
        ///// Updated BY: N/A
        ///// Updated N/A
        ///// Update: N/A
        ///// Approver: N/A
        ///// </remarks>
        ///// <param name="message"></param>
        ///// <param name="typeOfError"></param>
        ///// <param name="innerMessage"></param>
        //public static void ErrorMessage(this string message, string typeOfError = null, string innerMessage = null)
        //{
        //    string caption = null;
        //    string innerMessage1 = null;
        //    if (!string.IsNullOrEmpty(typeOfError))
        //    {
        //        caption = typeOfError + " Error";
        //    }
        //    else if (!string.IsNullOrEmpty(innerMessage))
        //    {
        //        innerMessage1 = innerMessage;
        //    }
        //    else
        //    {
        //        caption = "Error";
        //        innerMessage1 = "";
        //    }
        //    MessageBox.Show(message + "\n\n" + innerMessage1, caption, MessageBoxButton.OK,
        //        MessageBoxImage.Error);
        //}


        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/11/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Method of general Error handling.
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        public static void SuccessMessage(this string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButton.OK);
        }
    }
}

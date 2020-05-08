using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    public interface IPoSCustomerPortalAccessor
    {

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Create a Shipping Error.
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="errorDesc"></param>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>

        int ReportShippingError(string errorType, string errorDesc);

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// </summary>
        /// <param name="cardType"></param>
        /// <param name="cardNumber"></param>
        /// <param name="securityCode"></param>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>

        int AddCreditCard(string cardType, string cardNumber, string securityCode);

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>

        List<CreditCardVM2> GetAllCreditCards();

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        int DeleteCreditCard(string cardNumber);

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 04/28/2020
        /// Approver: Rasha Mohammed
        /// 
        /// submits Survey record.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        int InsertCustomerSurvey(string customerName, string serviceRating, string notes);

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 04/28/2020
        /// Approver: Rasha Mohammed
        /// 
        /// submits Conflict record.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        int InsertEmpCustProblem(string problemType, string name, string description);
    }
}

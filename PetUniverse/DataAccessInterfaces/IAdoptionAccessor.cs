using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Awaab Elamin 
    /// Created: 2020/02/04
    /// Approver: Mohamed Elamin
    /// Include all interface(public) methods for ReviewerManger (Logic Layer).
    /// </summary>
    public interface IAdoptionAccessor
    {
        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// retrieve All Adoption Apllications
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        List<AdoptionApplication> getAllAdoptionApplication();

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// retrieve the customer data from the customer table by his last name
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 04/22/2020
        /// Update: Added return tag.
        /// </remarks>
        /// <param name="customerLastName"></param>
        /// <returns>customer</returns>
        AdoptionCustomer getCustomerByCustomerName(string customerLastName);

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// retrieve Customer last name record from customer table by his ID
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 04/22/2020
        /// Update: Added return tag.
        /// </remarks>
        /// <param name="customerID"></param>
        /// <returns>customer</returns>
        string getCustomerLastName(int customerID);

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// 
        /// retrieve question syntax acoording to questionID
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 04/22/2020
        /// Update: Added return tag.
        /// </remarks>
        /// <param name="questionID"></param>
        /// <returns>Qestion Description</returns>
        string getQestionDescription(int questionID);

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2/15/2020
        /// Approver: Mohamed Elamin, 2/21/2020
        /// 
        /// retrieve Adoption Apllication for a customer by his ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="customerID"></param>
        AdoptionApplication getAdoptionApplicationByCustomerEmail(string customerEmail);

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// 
        /// retrieve Adoption Apllication for a customer by his ID
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 04/22/2020
        /// Update: Added return tag.
        /// </remarks>
        /// <param name="customerEmail"></param>
        /// <returns>Customer Questionnair</returns>
        List<CustomerQuestionnar> getCustomerQuestionnair(string customerEmail);

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// 
        /// update the status of the adoption application
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 04/22/2020
        /// Update: Added return tag.
        /// </remarks>
        /// <param name="decision"></param>
        /// <param name="adoptionApplicationID"></param>
        ///  <returns>Row Count</returns>
        int changeAdoptionApplicationStatus(int adoptionApplicationID, string decision);

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// 
        /// insert the status of the adoption application
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="adoptionApplication"></param>
        /// <returns>True or false depending if the record was inserted</returns>
        bool insertAdoptionApplication(AdoptionApplication adoptionApplication);

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// Get all questions.
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 04/22/2020
        /// Update: Added return tag.
        /// </remarks>
        /// <returns>List of questions</returns>
        List<string> getAllQuestions();

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// Get all questions.
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 04/22/2020
        /// Update: Added return tag.
        /// </remarks>
        /// <param name="questionnair"></param>
        /// <returns>True or false depending if the record was inserted </returns>
        bool inserQuestionnair(Questionnair questionnair);

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created:  2020/04/15
        /// Approver: Mohamed Elamin
        /// 
        /// Get all Animals
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <return>Animals Medicals Records</return>
        List<AnimalMedical> getAllAnimals();
    }
}

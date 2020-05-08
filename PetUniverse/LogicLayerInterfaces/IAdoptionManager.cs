using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/04
    /// Approver: Mohamed Elamin
    ///
    /// interface contains public method for reviewer manager
    /// </summary>
    public interface IAdoptionManager
    {
        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// Retrieve the data of the Questionnair.
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/22 
        /// Update: Added Comments.
        /// </remarks>
        List<AdoptionApplication> retrieveCustomersFilledQuestionnair();

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin 
        /// 
        /// Retrieve a Customer record by his last name.
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update:  Added Comments.
        /// </remarks>
        /// <param name="customerLastName"></param>
        /// <returns>customer</returns>
        AdoptionCustomer retrieveCustomerByCustomerName(string customerLastName);

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin 
        /// 
        /// Retrieve A customer's AdoptionApplication by a customerID
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Added Comments.
        /// </remarks>
        /// <param name="CustomerID"></param>
        /// <returns>adoptionApplication</returns>
        AdoptionApplication retrieveCustomerAdoptionApplicaionByCustomerEmail(string customerID);

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin 
        /// 
        /// Update the status of the adoption application according the reviewer decision.
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Added Comments. 
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <param name="decision"></param>
        /// <returns>True or false depending if the record was updated</returns>
        bool SubmitReviewerDecision(int adoptionApplicationID, string decision);

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin 
        /// Retrieve A customer's Questionnar by Customer Email.
        /// </summary>
        /// <remarks> 
        /// Updater: Awaab Elamin
        /// Updated: 3/15/2020
        /// Update: After DB updated in Customer Table, We don't need to below method.
        /// 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Added Comments.
        /// </remarks>
        /// <param name="customerEmail"></param>
        /// <returns>customerQuestionnars</returns>
        List<CustomerQuestionnar> retrieveCustomerQuestionnar(string customerEmail);

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin 
        /// 
        /// Update the status of the adoption application according the reviewer decision.
        /// 
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Added Comments.
        /// </remarks>
        /// <param name="adoptionApplication"></param>
        /// <returns>True or false depending if the record was updated</returns>
        bool addAdoptionApplication(AdoptionApplication adoptionApplication);

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// 
        /// Retrieve all questions.
        /// 
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Added Comments.
        /// </remarks>
        /// <returns>List of questions</returns>
        List<string> retrieveAllQuestions();

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// 
        /// Addd Customer questionnair to questionnair table .
        /// 
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Added Comments
        /// </remarks>
        /// <param name="questionnair"></param>
        /// <returns>True or false depending if the record was inserted </returns>
        bool addQuestionnair(Questionnair questionnair);

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// 
        /// retririeve all medical records for animals
        /// 
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Added Comments
        /// </remarks>
        /// <returns>List<AnimalMedical></returns>
        List<AnimalMedical> retrieveAllAnimals();
    }
}

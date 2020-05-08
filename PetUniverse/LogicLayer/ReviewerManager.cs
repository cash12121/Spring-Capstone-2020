using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/04
    /// Approver: Mohamed Elamin
    /// Manager class for Reviewer precoesses
    /// </summary>
    public class ReviewerManager : IAdoptionManager
    {
        private IAdoptionAccessor adoptionAccessor;
        private AdoptionApplication adoptionApplication = new AdoptionApplication();
        private AdoptionCustomer customer;

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// Default Constructor intial adotionAccessor to
        /// reviewer manager accessor and customer object
        /// </summary
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Fixed comments format
        /// </remarks> 
        public ReviewerManager()
        {
            adoptionAccessor = new ReviewerAccessor();
            customer = null;
        }


        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// Construct assgined a fake data access to addoption application object
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Fixed comments format.
        /// </remarks>
        /// <param name="fakeReviewerAccessor"></param>
        public ReviewerManager(IAdoptionAccessor fakeReviewerAccessor)
        {
            adoptionAccessor = fakeReviewerAccessor;
        }

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// Retrieve the data of the Questionnair.
        /// </summary>
        /// <remarks>
        /// Updater: Awaab Elamin
        /// Updated: 2020/03/15
        /// Update: According to DB update, change customer id to be customer Email.
        /// 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Fixed comments format. Added try catch block.
        /// </remarks>
        /// <returns>List of Customers who Filled Questionnair</returns>
        public List<AdoptionApplication> retrieveCustomersFilledQuestionnair()
        {
            List<AdoptionApplication> adoptionApplications = new List<AdoptionApplication>();
            List<AdoptionApplication> customersFilledQuestionnair = new List<AdoptionApplication>();
            List<CustomerQuestionnar> customerQuestionnar = new List<CustomerQuestionnar>();
            adoptionApplications = adoptionAccessor.getAllAdoptionApplication();

            foreach (AdoptionApplication adoptionApplication in adoptionApplications)
            {

                customerQuestionnar = adoptionAccessor.getCustomerQuestionnair(adoptionApplication.CustomerEmail);
                if (null != customerQuestionnar && customerQuestionnar.Count >= 1)
                {

                    customersFilledQuestionnair.Add(adoptionApplication);
                }
            }


            return customersFilledQuestionnair;
        }

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin 
        /// Retrieve A customer's Questionnar by a Customer ID.
        /// </summary>
        /// <remarks> 
        /// Updater: Awaab Elamin
        /// Updated: 3/15/2020
        /// Update: After DB updated in Customer Table, We don't need to below method.
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Fixed Comments format. Added try catch block and deleted commented code.
        /// </remarks>
        /// <param name="customerEmail"></param>
        /// <returns>customerQuestionnars</returns>
        public List<CustomerQuestionnar> retrieveCustomerQuestionnar(string customerEmail)
        {
            List<CustomerQuestionnar> customerQuestionnars = new List<CustomerQuestionnar>();
            try
            {
                if (customerEmail != null && customerEmail != "")
                {
                    customerQuestionnars = adoptionAccessor.getCustomerQuestionnair(customerEmail);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
           
            return customerQuestionnars;
        }

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin 
        /// Retrieve a customer record by his last name
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Fixed comments format.Added try catch block.
        /// </remarks>
        /// <param name="customerLastName"></param>
        /// <returns>customer</returns>
        public AdoptionCustomer retrieveCustomerByCustomerName(string customerLastName)
        {
            customer = adoptionAccessor.getCustomerByCustomerName(customerLastName);

            return customer;
        }

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin 
        /// Retrieve A customer's AdoptionApplication by a customerID
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Fixed Comments format.Added try catch block.
        /// </remarks>
        /// <param name="customerEmail"></param>
        /// <returns >adoptionApplication</returns>
        public AdoptionApplication retrieveCustomerAdoptionApplicaionByCustomerEmail(string customerEmail)
        {
            adoptionApplication = adoptionAccessor.getAdoptionApplicationByCustomerEmail(customerEmail);
            return adoptionApplication;
        }

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin 
        /// Update the status of the adoption application according the reviewer decision.
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Fixed Comments format. Added try catch block. 
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <param name="decision"></param>
        /// <returns>True or false depending if the record was updated</returns>
        public bool SubmitReviewerDecision(int adoptionApplicationID, string decision)
        {
            Boolean result = false;

            if (adoptionAccessor.changeAdoptionApplicationStatus(adoptionApplicationID, decision) == 1)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin 
        /// add the adoption application of the customer
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Fixed Comments format.
        /// </remarks>
        /// <param name="adoptionApplication"></param>
        /// <returns>True or false depending if the record was inserted</returns>
        public bool addAdoptionApplication(AdoptionApplication adoptionApplication)
        {
            bool result = false;
            try
            {
                if (adoptionAccessor.insertAdoptionApplication(adoptionApplication))
                {
                    result = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// Retrieve all questions.
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Fixed Comments format.Added ex and the throw message.
        /// </remarks>
        /// <returns>List of questions</returns>
        public List<string> retrieveAllQuestions()
        {
            List<string> questions = new List<string>();
            try
            {
                questions = adoptionAccessor.getAllQuestions();
            }
            catch (Exception)
            {

                throw;
            }
            return questions;
        }

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/02/04
        /// Approver: Mohamed Elamin
        /// Addd custome questionnair to questionnair table 
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Added Comments. Added try catch block.
        /// </remarks>
        /// <param name="questionnair"></param>
        /// <returns>True or false depending if the record was inserted </returns>
        public bool addQuestionnair(Questionnair questionnair)
        {
            bool result = false;
            // questionnair.CustomerEmail = model
            if (adoptionAccessor.inserQuestionnair(questionnair))
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Creator: Awaab Elamin 
        /// Created: 2020/04/15
        /// Approver: Mohamed Elamin
        /// retrieve all animal medical records 
        /// </summary>
        /// <remarks> 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/21 
        /// Update: Added Comments. Added try catch block.
        /// </remarks>
        /// <returns>animals Medical records</returns>
        public List<AnimalMedical> retrieveAllAnimals()
        {
            List<AnimalMedical> animals = new List<AnimalMedical>();
            try
            {
                animals = adoptionAccessor.getAllAnimals();
            }
            catch (Exception)
            {

                throw;
            }
            return animals;

        }
    }
}

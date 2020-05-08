using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/29
    /// Approver: Mohamed Elamin
    /// Test the reviewer manager
    /// </summary>
    [TestClass]
    public class ReviewerManagerTest
    {
        private IAdoptionAccessor fakeReviewerAccessor;
        private ReviewerManager reviewerManager;

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/04/02
        /// Approver: Mohamed Elamin
        /// initialize the fakeReviewerAccessor and assgined the reviewer mananger object
        /// to the fake data access, So we can test the reviewer manager without effecting the real DB
        /// </summary>
        [TestInitialize]
        public void TestSetup()
        {
            fakeReviewerAccessor = new FakeReviewerAccessor();
            reviewerManager = new ReviewerManager(fakeReviewerAccessor);
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/04/02
        /// Approver: Mohamed Elamin
        /// Test the RetrieveCustomersFilledQuestionnair method
        /// to pass the test must retrieve 1
        /// (The count of the fake rows on the fake DB)
        /// </summary>
        [TestMethod]
        public void TestRetrieveCustomersFilledQuestionnair()
        {
            //arrange
            List<AdoptionApplication> adoptionApplications = new List<AdoptionApplication>();

            //Acct
            adoptionApplications = reviewerManager.retrieveCustomersFilledQuestionnair();
            if (adoptionApplications != null)
            {
                Assert.AreEqual(4, adoptionApplications.Count);
            }

        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/04/02
        /// Approver: Mohamed Elamin
        /// Test GetCustomerBuyCustomerName method
        /// to pass the test must retrieve "Elamin"
        /// (The value that we assgined to the parameter must match the last name of one
        /// of the Fake customers)
        /// </summary>
        [TestMethod]
        public void TestGetCustomerByCustomerName()
        {
            //arrange
            AdoptionCustomer customer = null;
            string customerName = "Elamin";

            //acct
            customer = reviewerManager.retrieveCustomerByCustomerName(customerName);
            //assert
            Assert.AreEqual(customerName, customer.LastName);

        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/04/02
        /// Approver: Mohamed Elamin
        /// Test  for RetrieveCustomerQuestionnair method
        /// to pass the test must retrieve "10"
        /// (The value that we assgined to the parameter (10000) must match with 10 rows on our fake DB)
        /// </summary>
        [TestMethod]
        public void TestRetrieveCustomerQuestionnair()
        {
            //arrange
            List<CustomerQuestionnar> customerQuestionnars = new List<CustomerQuestionnar>();
            string customerEmail = "Awaab@live.com";

            //acct
            customerQuestionnars = reviewerManager.retrieveCustomerQuestionnar(customerEmail);

            ////Assert
            Assert.AreEqual(10, customerQuestionnars.Count);

        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/04/02
        /// Approver: Mohamed Elamin
        /// Test  for SubmitReviewerDecision
        /// to pass the test must retrieve "true"
        /// (That means the status changed to Interviewer)
        /// </summary>
        [TestMethod]
        public void TestSubmitReviewerDecision()
        {
            // bool (int adoptionApplicationID, string decision);
            int adoptionApplicationID = 10000;
            string Reviewerdecision = "Interviewer";
            bool expect = true;
            bool result = reviewerManager.SubmitReviewerDecision(adoptionApplicationID, Reviewerdecision);
            Assert.AreEqual(expect, result);
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/04/02
        /// Approver: Mohamed Elamin
        /// Test  for TestSubmitInterviewerDecision
        /// to pass the test must retrieve "true"
        /// (That means the status changed to InHomeInspection)
        /// </summary>
        [TestMethod]
        public void TestSubmitInterviewerDecision()
        {
            int adoptionApplicationID = 10000;
            string Interviewerdecision = "InHomeInspection";
            bool expect = true;
            bool result = reviewerManager.SubmitReviewerDecision(adoptionApplicationID, Interviewerdecision);
            Assert.AreEqual(expect, result);
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/04/02
        /// Approver: Mohamed Elamin
        /// Test  for TestSubmitDenyDecision
        /// to pass the test must retrieve "true"
        /// (That means the status changed to deny)
        /// </summary>
        [TestMethod]
        public void TestSubmitDenyDecision()
        {
            // bool (int adoptionApplicationID, string decision);
            int adoptionApplicationID = 10000;
            string Denydecision = "Deny";
            bool expect = true;
            bool result = reviewerManager.SubmitReviewerDecision(adoptionApplicationID, Denydecision);
            Assert.AreEqual(expect, result);
        }


        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/04/02
        /// Approver: Mohamed Elamin
        /// Test  for addAdoptionApplication
        /// to pass the test must retrieve "true"
        /// (That means the application added correctly)
        /// </summary>
        [TestMethod]
        public void TestAdoptionApplication()
        {
            AdoptionApplication adoptionApplication = new AdoptionApplication();
            adoptionApplication.AdoptionApplicationID = 10003;
            adoptionApplication.CustomerEmail = "Awaab@PetUnviesal.com";
            adoptionApplication.AnimalID = 10004;
            adoptionApplication.RecievedDate = DateTime.Now;
            adoptionApplication.Status = "Reviewer";
            bool expect = true;
            bool result = reviewerManager.addAdoptionApplication(adoptionApplication);
            Assert.AreEqual(expect, result);
        }

        //public List<AnimalMedical> retrieveAllAnimals()
        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/04/15
        /// Approver: Mohamed Elamin
        /// Test  for addAdoptionApplication
        /// to pass the test must retrieve "true"
        /// (That means the application added correctly)
        /// </summary>
        [TestMethod]
        public void TestretrieveAllAnimals()
        {
            List<AnimalMedical> result = new List<AnimalMedical>();
            int expect = 5;
            result = reviewerManager.retrieveAllAnimals();
            Assert.AreEqual(expect, result.Count);
        }

    }
}

using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator : Derek Taylor
    /// Created: 2/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// This class tests the ApplicantManager Class
    /// </summary>
    /// <remarks>
    /// UPDATED BY: Matt Deaton
    /// UPDATE DATE: 2020-04-16
    /// CHANGE: Added Tests to ensure all Application Processes work properly
    /// 
    /// </remarks>
    [TestClass]
    public class ApplicantManagerTests
    {
        private IApplicantAccessor _fakeApplicantAccessor;
        private ApplicantManager _applicantManager;

        /// <summary>
        /// Creator : Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This is the fake constructor. Initializes the test class.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeApplicantAccessor = new FakeApplicantAccessor();
            _applicantManager = new ApplicantManager(_fakeApplicantAccessor);
        }

        /// <summary>
        /// Creator : Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This Method is test for the SelectAllApplicants() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>  
        [TestMethod]
        public void TestSelectAllApplicants()
        {
            // Arrange
            List<Applicant> selectedApplicants;
            // Act
            selectedApplicants = _applicantManager.RetrieveApplicants();
            // Assert
            Assert.AreEqual(3, selectedApplicants.Count);
        }

        /// <summary>
        /// Creator : Ryan Morganti
        /// Created: 2020/03/19
        /// Approver: Derek Taylor
        /// 
        /// TestMethod for SelectAllJobPositions() 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>  
        [TestMethod]
        public void TestSelectAllJobPositions()
        {
            // Arrange
            List<JobListing> jobs;

            // Act
            jobs = _applicantManager.RetrieveAllPositions();

            // Assert
            Assert.AreEqual(3, jobs.Count);
        }

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Test Method for ApplicantManger method AddFosterApplication
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// </remarks>
        [TestMethod]
        public void TestApplicantManagerAddFosterApplicant()
        {
            // Arrange
            Applicant fosterApplication = new Applicant()
            {
                ApplicantID = 999999,
                FirstName = "Angela",
                LastName = "Schrute",
                MiddleName = "Noelle",
                Email = "angela.schrute@dundermifflin.com",
                PhoneNumber = "5709045023",
                AddressLineOne = "12345 Beet Road",
                AddressLineTwo = "Schrute Farms",
                City = "Scranton",
                State = "PA",
                Zipcode = "18447",
                Foster = true
            };

            // Arrange
            bool successfulAdd = false;
            bool expectedResult = true;

            // Act
            successfulAdd = _applicantManager.AddFosterApplicant(fosterApplication);

            // Assert
            Assert.AreEqual(expectedResult, successfulAdd);

        }// End TestApplicantManagerAddFosterApplicant()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Test Method for ApplicationManger method AddFosterApplication
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// </remarks>
        [TestMethod]
        public void TestApplicantManagerRetrieveApplicantByID()
        {
            // Arrange
            int applicantID = 100000;
            Applicant applicant = null;
            int result = 0;

            // Act
            applicant = _applicantManager.RetrieveApplicantByID(applicantID);
            if (applicant != null)
            {
                result = 1;
            }

            // Assert
            Assert.AreEqual(1, result);
        }// End TestApplicantManagerRetrieveApplicantByID()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-16
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Test Method for ApplicationManger method RetrieveApplicantForInterview
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// </remarks>
        [TestMethod]
        public void TestApplicantManagerRetrieveApplicantForInterview()
        {
            // Arrange
            int applicantID = 100000;
            ApplicantVM applicant = null;
            int result = 0;

            // Act
            applicant = _applicantManager.RetrieveApplicantForInterview(applicantID);
            if (applicant != null)
            {
                result = 1;
            }

            // Assert
            Assert.AreEqual(1, result);
        }// End TestApplicantManagerRetrieveApplicantForInterview()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-16
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Test Method for ApplicationManger method EditInterviewNotes
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// </remarks>
        [TestMethod]
        public void TestApplicantManagerEditInterviewNotes()
        {
            // Arrange
            ApplicantVM oldApplicant = new ApplicantVM()
            {
                FirstName = "Dwight",
                MiddleName = "Kurt",
                LastName = "Schrute",
                Email = "beetfarmer78@aol.com",
                PhoneNumber = "16415210932",
                AddressLineOne = "3142 Schrute Farms Road",
                AddressLineTwo = "",
                City = "Scranton",
                State = "PA",
                Zipcode = "18503",
                Foster = false,
                ApplicantStatus = "Declined",
                ApplicationID = 100000,
                ApplicationPostion = "Kennel Cleaner",
                InterviewNotes = "Applied for Kennel Cleaner, but he wanted to be a Sales Person",
                HomeCheckDate = null,
                SchoolName = "Scranton High",
                SchoolCity = "Scranton",
                SchoolState = "PA",
                SchoolLevel = "Diploma",
                ReferenceName = "Michael Scott",
                ReferenceNameRelationship = "Current Boss",
                ReferenceNamePhoneNumber = "16415210931",
                ReferenceNameEmail = "greatscott@dundermifflin.com",
                PreviousWorkName = "Dunder Mifflin",
                PreviousWorkCity = "Scranton",
                PreviousWorkState = "PA",
                PreviousWorkType = "Sales",
                ApplicantSkills = "Hard Worker",
                ResumePath = "scrute_dwight.doc"
            };
            ApplicantVM newApplicant = new ApplicantVM()
            {
                FirstName = "Dwight",
                MiddleName = "Kurt",
                LastName = "Schrute",
                Email = "beetfarmer78@aol.com",
                PhoneNumber = "16415210932",
                AddressLineOne = "3142 Schrute Farms Road",
                AddressLineTwo = "",
                City = "Scranton",
                State = "PA",
                Zipcode = "18503",
                Foster = false,
                ApplicantStatus = "Declined",
                ApplicationID = 100000,
                ApplicationPostion = "Kennel Cleaner",
                InterviewNotes = "Very strange man. Do Not Hire This Person!!!! Applied for Kennel Cleaner, but he wanted to be a Sales Person",
                HomeCheckDate = null,
                SchoolName = "Scranton High",
                SchoolCity = "Scranton",
                SchoolState = "PA",
                SchoolLevel = "Diploma",
                ReferenceName = "Michael Scott",
                ReferenceNameRelationship = "Current Boss",
                ReferenceNamePhoneNumber = "16415210931",
                ReferenceNameEmail = "greatscott@dundermifflin.com",
                PreviousWorkName = "Dunder Mifflin",
                PreviousWorkCity = "Scranton",
                PreviousWorkState = "PA",
                PreviousWorkType = "Sales",
                ApplicantSkills = "Hard Worker",
                ResumePath = "scrute_dwight.doc"
            };

            // Act
            bool result = false;
            result = _applicantManager.EditInterviewNotes(oldApplicant.ApplicationID, oldApplicant.InterviewNotes, newApplicant.InterviewNotes);

            // Assert
            Assert.AreEqual(true, result);
        }// End TestApplicantManagerEditInterviewNotes()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-16
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Test Method for ApplicationManger method EditApplicationStatus
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// </remarks>
        [TestMethod]
        public void TestApplicantManagerEditApplicationStatus()
        {
            // Arrange
            ApplicantVM oldApplicant = new ApplicantVM()
            {
                FirstName = "Dwight",
                MiddleName = "Kurt",
                LastName = "Schrute",
                Email = "beetfarmer78@aol.com",
                PhoneNumber = "16415210932",
                AddressLineOne = "3142 Schrute Farms Road",
                AddressLineTwo = "",
                City = "Scranton",
                State = "PA",
                Zipcode = "18503",
                Foster = false,
                ApplicantStatus = "Pending Interview",
                ApplicationID = 100000,
                ApplicationPostion = "Kennel Cleaner",
                InterviewNotes = "Applied for Kennel Cleaner, but he wanted to be a Sales Person",
                HomeCheckDate = null,
                SchoolName = "Scranton High",
                SchoolCity = "Scranton",
                SchoolState = "PA",
                SchoolLevel = "Diploma",
                ReferenceName = "Michael Scott",
                ReferenceNameRelationship = "Current Boss",
                ReferenceNamePhoneNumber = "16415210931",
                ReferenceNameEmail = "greatscott@dundermifflin.com",
                PreviousWorkName = "Dunder Mifflin",
                PreviousWorkCity = "Scranton",
                PreviousWorkState = "PA",
                PreviousWorkType = "Sales",
                ApplicantSkills = "Hard Worker",
                ResumePath = "scrute_dwight.doc"
            };
            ApplicantVM newApplicant = new ApplicantVM()
            {
                FirstName = "Dwight",
                MiddleName = "Kurt",
                LastName = "Schrute",
                Email = "beetfarmer78@aol.com",
                PhoneNumber = "16415210932",
                AddressLineOne = "3142 Schrute Farms Road",
                AddressLineTwo = "",
                City = "Scranton",
                State = "PA",
                Zipcode = "18503",
                Foster = false,
                ApplicantStatus = "Declined",
                ApplicationID = 100000,
                ApplicationPostion = "Kennel Cleaner",
                InterviewNotes = "Applied for Kennel Cleaner, but he wanted to be a Sales Person",
                HomeCheckDate = null,
                SchoolName = "Scranton High",
                SchoolCity = "Scranton",
                SchoolState = "PA",
                SchoolLevel = "Diploma",
                ReferenceName = "Michael Scott",
                ReferenceNameRelationship = "Current Boss",
                ReferenceNamePhoneNumber = "16415210931",
                ReferenceNameEmail = "greatscott@dundermifflin.com",
                PreviousWorkName = "Dunder Mifflin",
                PreviousWorkCity = "Scranton",
                PreviousWorkState = "PA",
                PreviousWorkType = "Sales",
                ApplicantSkills = "Hard Worker",
                ResumePath = "scrute_dwight.doc"
            };

            // Act
            bool result = false;
            result = _applicantManager.EditApplicationStatus(oldApplicant.ApplicationID, oldApplicant.ApplicantStatus, newApplicant.ApplicantStatus);

            // Assert
            Assert.AreEqual(true, result);
        }// End TestApplicantManagerEditApplicationStatus()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-16
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Test Method for ApplicationManger method EditApplicationStatus
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// </remarks>
        [TestMethod]
        public void TestApplicantManagerEditHomeCheckDate()
        {
            // Arrange
            ApplicantVM oldApplicant = new ApplicantVM()
            {
                FirstName = "Dwight",
                MiddleName = "Kurt",
                LastName = "Schrute",
                Email = "beetfarmer78@aol.com",
                PhoneNumber = "16415210932",
                AddressLineOne = "3142 Schrute Farms Road",
                AddressLineTwo = "",
                City = "Scranton",
                State = "PA",
                Zipcode = "18503",
                Foster = true,
                ApplicantStatus = "Pending Interview",
                ApplicationID = 100000,
                ApplicationPostion = "Foster",
                InterviewNotes = "Applicant states they have a large beet farm where the dog could run around. Many other animals on farm.",
                HomeCheckDate = DateTime.Now,
                SchoolName = "Scranton High",
                SchoolCity = "Scranton",
                SchoolState = "PA",
                SchoolLevel = "Diploma",
                ReferenceName = "Michael Scott",
                ReferenceNameRelationship = "Current Boss",
                ReferenceNamePhoneNumber = "16415210931",
                ReferenceNameEmail = "greatscott@dundermifflin.com",
                PreviousWorkName = "Dunder Mifflin",
                PreviousWorkCity = "Scranton",
                PreviousWorkState = "PA",
                PreviousWorkType = "Sales",
                ApplicantSkills = "Hard Worker",
                ResumePath = "scrute_dwight.doc"
            };
            ApplicantVM newApplicant = new ApplicantVM()
            {
                FirstName = "Dwight",
                MiddleName = "Kurt",
                LastName = "Schrute",
                Email = "beetfarmer78@aol.com",
                PhoneNumber = "16415210932",
                AddressLineOne = "3142 Schrute Farms Road",
                AddressLineTwo = "",
                City = "Scranton",
                State = "PA",
                Zipcode = "18503",
                Foster = true,
                ApplicantStatus = "Pending Interview",
                ApplicationID = 100000,
                ApplicationPostion = "Kennel Cleaner",
                InterviewNotes = "Applicant states they have a large beet farm where the dog could run around. Many other animals on farm.",
                HomeCheckDate = DateTime.Now.AddDays(2),
                SchoolName = "Scranton High",
                SchoolCity = "Scranton",
                SchoolState = "PA",
                SchoolLevel = "Diploma",
                ReferenceName = "Michael Scott",
                ReferenceNameRelationship = "Current Boss",
                ReferenceNamePhoneNumber = "16415210931",
                ReferenceNameEmail = "greatscott@dundermifflin.com",
                PreviousWorkName = "Dunder Mifflin",
                PreviousWorkCity = "Scranton",
                PreviousWorkState = "PA",
                PreviousWorkType = "Sales",
                ApplicantSkills = "Hard Worker",
                ResumePath = "scrute_dwight.doc"
            };

            // Act
            bool result = false;
            result = _applicantManager.EditHomeCheckDate(oldApplicant.ApplicationID, oldApplicant.HomeCheckDate, newApplicant.HomeCheckDate);

            // Assert
            Assert.AreEqual(true, result);
        }// End TestApplicantManagerEditHomeCheckDate()

        /// <summary>
        /// Creator : Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This is the test cleanup method
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _fakeApplicantAccessor = null;
            _applicantManager = null;
        }
    }
}

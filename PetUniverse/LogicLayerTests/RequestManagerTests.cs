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
    ///  Creator: Kaleb Bachert
    ///  Created: 2/9/2020
    ///  Approver: Zach Behrensmeyer
    ///  
    ///  Test Class for RequestManager
    /// </summary>

    [TestClass]
    public class RequestManagerTests
    {
        private IRequestAccessor _requestAccessor;

        //Test Variables
        private IRequestAccessor _fakeRequestAccessor;
        private RequestManager _requestManager;

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/9
        ///  APPROVER: Jordan Lindo
        ///  
        ///  Constructor for instantiating FakeRequestAccessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public RequestManagerTests()
        {
            _requestAccessor = new FakeRequestAccessor();
        }

        [TestInitialize]
        public void TestSetup()
        {
            _fakeRequestAccessor = new FakeRequestAccessor();
            _requestManager = new RequestManager(_fakeRequestAccessor);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/9
        ///  APPROVER: Jordan Lindo
        ///  
        ///  Test method for retrieving all open requests
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveRequestsByStatusOpen()
        {
            //arrange
            List<RequestVM> requests;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            requests = requestManager.RetrieveRequestsByStatus(true);

            //assert
            Assert.AreEqual(3, requests.Count);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/9
        ///  APPROVER: Jordan Lindo
        ///  
        ///  Test method for retrieving all closed requests
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveRequestsByStatusClosed()
        {
            //arrange
            List<RequestVM> requests;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            requests = requestManager.RetrieveRequestsByStatus(false);

            //assert
            Assert.AreEqual(0, requests.Count);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/19
        ///  APPROVER: NA
        ///  
        ///  Test method for approving a request
        /// </summary>
        /// <remarks>
        /// UPDATER: Kaleb Bachert
        /// UPDATED: 2020/3/7
        /// UPDATE: Added parameter for RequestType
        /// 
        /// </remarks>
        [TestMethod]
        public void TestApproveRequest()
        {
            //arrange
            int requestsChanged;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            requestsChanged = requestManager.ApproveRequest(1000001, 1000000, "Time Off");

            //assert
            Assert.AreEqual(1, requestsChanged);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/14
        /// Approver:Derek Taylor
        /// 
        /// Test Method for validating good input results when retrieving
        /// new Requests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveNewRequestsByDepartmentID()
        {
            // arrange
            List<DepartmentRequest> _selectedRequest = new List<DepartmentRequest>();
            List<DepartmentRequest> _selectedRequest2 = new List<DepartmentRequest>();
            List<string> requestID = new List<string>() { "CustomerService" };
            List<string> requestID2 = new List<string>() { "Management" };

            // act
            _selectedRequest = _requestManager.RetrieveNewRequestsByDepartmentID(requestID);
            _selectedRequest2 = _requestManager.RetrieveNewRequestsByDepartmentID(requestID2);

            // assert
            Assert.AreEqual(1, _selectedRequest2.Count);
            Assert.AreEqual(2, _selectedRequest.Count);

        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/14
        /// Approver:Derek Taylor
        /// 
        /// Test Method for validating NULL input results when retrieving
        /// new Requests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestExceptionRetrieveNewRequestsByDepartmentID()
        {
            // arrange
            List<DepartmentRequest> _selectedRequest = new List<DepartmentRequest>();
            List<string> deptID = null;

            // act
            _selectedRequest = _requestManager.RetrieveNewRequestsByDepartmentID(deptID);
        }


        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/14
        /// Approver:Derek Taylor
        /// 
        /// Test Method for validating good input results when retrieving
        /// Completed Requests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveCompleteRequestsByDepartmentID()
        {
            // arrange
            List<DepartmentRequest> _selectedRequest = new List<DepartmentRequest>();
            List<DepartmentRequest> _selectedRequest2 = new List<DepartmentRequest>();
            List<string> requestID = new List<string>() { "CustomerService" };
            List<string> requestID2 = new List<string>() { "Management" };

            // act
            _selectedRequest = _requestManager.RetrieveCompleteRequestsByDepartmentID(requestID);
            _selectedRequest2 = _requestManager.RetrieveCompleteRequestsByDepartmentID(requestID2);

            // assert
            Assert.AreEqual(2, _selectedRequest2.Count);
            Assert.AreEqual(1, _selectedRequest.Count);

        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/14
        /// Approver:Derek Taylor
        /// 
        /// Test Method for validating NULL input results when retrieving
        /// Completed Requests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestExceptionRetrieveCompleteRequestsByDepartmentID()
        {
            // arrange
            List<DepartmentRequest> _selectedRequest = new List<DepartmentRequest>();
            List<string> deptID = null;

            // act
            _selectedRequest = _requestManager.RetrieveCompleteRequestsByDepartmentID(deptID);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/14
        /// Approver:Derek Taylor
        /// 
        /// Test Method for validating good input results when retrieving
        /// Active Requests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveActiveRequestsByDepartmentID()
        {
            // arrange
            List<DepartmentRequest> _selectedRequest = new List<DepartmentRequest>();
            List<DepartmentRequest> _selectedRequest2 = new List<DepartmentRequest>();
            List<string> requestID = new List<string>() { "CustomerService" };
            List<string> requestID2 = new List<string>() { "Management" };

            // act
            _selectedRequest = _requestManager.RetrieveActiveRequestsByDepartmentID(requestID);
            _selectedRequest2 = _requestManager.RetrieveActiveRequestsByDepartmentID(requestID2);

            // assert
            Assert.AreEqual(0, _selectedRequest2.Count);
            Assert.AreEqual(2, _selectedRequest.Count);

        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/14
        /// Approver:Derek Taylor
        /// 
        /// Test Method for validating NULL input results when retrieving
        /// Active Requests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestExceptionRetrieveActiveRequestsByDepartmentID()
        {
            // arrange
            List<DepartmentRequest> _selectedRequest = new List<DepartmentRequest>();
            List<string> deptID = null;

            // act
            _selectedRequest = _requestManager.RetrieveActiveRequestsByDepartmentID(deptID);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/22
        /// Approver: Derek Taylor
        /// 
        /// Test Method for validating good input results when retrieving
        /// DepartmentIDs.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllDepartmentIDsByUserID()
        {
            // arrange
            int userID = 100001;
            List<string> deptIDs = new List<string>();

            // act
            deptIDs = _requestManager.RetrieveAllDepartmentIDsByUserID(userID);

            // assert
            Assert.AreEqual(3, deptIDs.Count);

        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/19
        ///  APPROVER: NA
        ///  
        ///  Test method for creating a request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestCreateTimeOffRequest()
        {
            //arrange
            bool singleRequestAdded;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            singleRequestAdded = requestManager.AddTimeOffRequest(new TimeOffRequest()
            {
                TimeOffRequestID = 1000002,
                EffectiveStart = DateTime.Now.AddDays(1),
                EffectiveEnd = DateTime.Now.AddDays(2),
                RequestID = 1000002
            }, 1000000);

            //assert
            Assert.AreEqual(true, singleRequestAdded);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/19
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Test method for retrieving a TimeOffRequestByRequestID
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveTimeOffRequestByRequestID()
        {
            // arrange
            TimeOffRequestVM request = null;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            // act
            request = requestManager.RetrieveTimeOffRequestByRequestID(1000000);

            // assert
            Assert.IsNotNull(request);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/9
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Test method for retrieving a ScheduleChangeRequestByRequestID
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveScheduleChangeRequestByRequestID()
        {
            // arrange
            ScheduleChangeRequestVM request = null;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            // act
            request = requestManager.RetrieveScheduleChangeRequestByRequestID(1000004);

            // assert
            Assert.IsNotNull(request);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/2/19
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Test method for creating an availability request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestCreateAvailabilityRequest()
        {
            //arrange
            bool singleRequestAdded;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            singleRequestAdded = requestManager.AddAvailabilityRequest(new AvailabilityRequestVM()
            {
                RequestID = 1000003
            }, 1000000);

            //assert
            Assert.AreEqual(true, singleRequestAdded);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/7
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Test method for creating an schedule change request
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestCreateScheduleChangeRequest()
        {
            //arrange
            bool singleRequestAdded;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            singleRequestAdded = requestManager.AddScheduleChangeRequest(new ScheduleChangeRequest()
            {
                ScheduleChangeRequestID = 1000000,
                ShiftID = 1000001
            }, 1000001);

            //assert
            Assert.AreEqual(true, singleRequestAdded);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        /// 
        /// Test Method for retrieving employee names and their associated userID from the database.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveEmployeeNames()
        {
            // arrange
            List<string[]> employeeNames = new List<string[]>();

            // act
            employeeNames = _requestManager.RetrieveEmployeeNames();

            // assert
            Assert.AreEqual(4, employeeNames.Count);

        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        /// 
        /// Test Method for retrieving all RequestTypes from the database.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllRequestTypes()
        {
            // arrange
            List<string> requestTypes;

            // act
            requestTypes = _requestManager.RetriveAllRequestTypes();

            // assert
            Assert.AreEqual(3, requestTypes.Count);

        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/10
        /// Approver: Derek Taylor
        /// 
        /// Test Method for retrieving all RequestResponses based on a RequestID.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllResponsesByRequestID()
        {
            // arrange
            int id = 101;
            List<RequestResponse> responses = new List<RequestResponse>();

            // act
            responses = _requestManager.RetrieveAllResponsesByRequestID(id);

            // assert
            Assert.AreEqual(2, responses.Count);

        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/16
        /// Approver: Derek Taylor
        /// 
        /// Test Method for updating a DepartmentRequest to Acknowledged, with a datetime and userID.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestSetDeptRequestStatusToAcknowledged()
        {
            // arrange
            int userID = 100001;
            int requestID = 100001;
            int result;

            // act
            result = _requestManager.SetDeptRequestStatusToAcknowledged(userID, requestID);

            // assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/16
        /// Approver: Derek Taylor
        /// 
        /// Test Method for updating a DepartmentRequest to Complete, with a datetime and userID.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestSetDeptRequestStatusToComplete()
        {
            // arrange
            int userID = 100001;
            int requestID = 100002;
            int result;

            // act
            result = _requestManager.SetDeptRequestStatusToCompleted(userID, requestID);

            // assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/18
        /// Approver: Derek Taylor
        /// 
        /// Test Method for updating a DepartmentRequest's details.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestEditDepartmentRequestDetails()
        {
            // arrange
            int result;
            DepartmentRequest originalRequest = new DepartmentRequest
            {
                RequestID = 100009,
                RequestingUserID = 100000,
                RequesteeGroupID = "Management",
                Topic = "topic1",
                Body = "Bodies everywhere"
            };
            string newGroupID = "Inventory";
            string newTopic = "topic2";
            string newBody = "body body";

            // act
            result = _requestManager.EditDepartmentRequestDetails(originalRequest.RequestingUserID, originalRequest.RequestID, originalRequest.RequesteeGroupID,
                                                                    originalRequest.Topic, originalRequest.Body, newGroupID, newTopic, newBody);

            // assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/2
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Test method for creating an Active Time Off record
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestCreateActiveTimeOff()
        {
            //arrange
            bool singleItemAdded;
            IRequestManager requestManager = new RequestManager(_requestAccessor);

            //act
            singleItemAdded = requestManager.AddActiveTimeOff(new ActiveTimeOff()
            {
                UserID = 1000001
            });

            //assert
            Assert.AreEqual(true, singleItemAdded);
        }


        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/21
        /// Approver: Kaleb Bachert 
        /// 
        /// Test Method for viewing an availability request by ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAvailabiltyRequstByID()
        {
            // arrange
            int requestID = 1000002;

            // act
            var result = _requestManager.RetrieveAvailabilityRequestByID(requestID);

            // assert
            Assert.AreEqual(requestID, result.RequestID);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/21
        /// Approver: Kaleb Bachert 
        /// 
        /// Test Method for fail for viewing an availability request by invalid ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        /// 
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestRetrieveAvailabiltyRequstByInvalidID()
        {
            // arrange
            int requestID = 1;

            // act
            var result = _requestManager.RetrieveAvailabilityRequestByID(requestID);


        }


        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        ///  CREATED: 2020/4/10
        ///  APPROVER: Matt Deaton
        ///  
        ///  This method tests adding a valid social media request
        ///  
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// 
        /// </summary>
        [TestMethod]
        public void TestCanAddValidSocialMediaRequest()
        {
            //Arrange
            int requestID = 0;
            SocialMediaRequest request = new SocialMediaRequest
            {
                DateCreated = DateTime.Now,
                Description = "A Good Description",
                Open = true,
                RequestingUserID = 100000,
                RequestTypeID = "Social Media",
                Title = "A Good Title"
            };

            //Act
            requestID = _fakeRequestAccessor.InsertSocialMediaRequest(request);

            //Assert
            Assert.AreNotEqual(requestID, 0);
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/4/10
        /// APPROVER: Matt Deaton
        ///  
        /// This method tests adding an invalid social media request
        ///  
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// 
        /// </summary>
        [TestMethod]
        public void TestCannotAddInvalidSocialMediaRequest()
        {
            //Arrange
            int requestID = 0;
            SocialMediaRequest request = new SocialMediaRequest
            {
                DateCreated = DateTime.Now,
                Description = "",//This will cause an unsucessful insertion
                Open = true,
                RequestingUserID = 100000,
                RequestTypeID = "Social Media",
                Title = "A Good Title"
            };

            //Act
            requestID = _fakeRequestAccessor.InsertSocialMediaRequest(request);

            //Assert
            Assert.AreEqual(requestID, 0);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/05/06
        /// Approver: Steve Coonrod
        /// 
        /// Test Method for creating a new DepartmentRequest record.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void InsertNewDepartmentRequest()
        {
            // Arrange
            int result = 0;
            DepartmentRequest request = new DepartmentRequest()
            {
                RequestID = 999
            };

            // Act
            result = _requestManager.CreateNewRequest(request);

            // Assert
            Assert.AreEqual(1, result);
        }


        [TestCleanup]
        public void TestTearDown()
        {
            _fakeRequestAccessor = null;
            _requestManager = null;
        }

    }
}

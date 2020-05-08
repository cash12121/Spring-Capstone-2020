using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessInterfaces;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayerInterfaces;
using LogicLayer;

namespace LogicLayerTests
{

    [TestClass]
    public class AvailabilityManagerTests
    {
        private IAvailabilityAccessor _availabilityAccessor;
        public AvailabilityManagerTests()
        {
            _availabilityAccessor = new FakeAvailabilityAccessor();

        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Inserting Availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestInsertAvailabilitySuccess()
        {
            //Arrange
            EmployeeAvailability availability = new EmployeeAvailability() { AvailabilityID = 5, DayOfWeek = "Monday", StartTime = "22:00", EndTime = "24:00", EmployeeID = 100001 };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            bool expectResult = true;
            //Act
            bool actualResult = _availabilityManager.AddAvailability(availability);
            //Assert
            Assert.AreEqual(expectResult, actualResult);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for failing Inserting Availability invalid userid
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [ExpectedException(typeof(ApplicationException))]
        [TestMethod]
        public void TestInsertAvailabilityInvalidUserID()
        {
            //Arrange
            EmployeeAvailability availability = new EmployeeAvailability() { AvailabilityID = 4, DayOfWeek = "Monday", StartTime = "22:00", EndTime = "24:00", EmployeeID = 0 };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            bool actualResult = _availabilityManager.AddAvailability(availability);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for failing Inserting Availability invalid availabilityID
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [ExpectedException(typeof(ApplicationException))]
        [TestMethod]
        public void TestInsertAvailabilityInvalidAvailabilityID()
        {
            //Arrange
            EmployeeAvailability availability = new EmployeeAvailability() { AvailabilityID = 1, DayOfWeek = "Monday", StartTime = "22:00", EndTime = "24:00", EmployeeID = 1 };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            bool actualResult = _availabilityManager.AddAvailability(availability);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Inserting invalid Availability day
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestInsertAvailabilityInvalidAvailabilityDay()
        {
            //Arrange
            EmployeeAvailability availability = new EmployeeAvailability() { AvailabilityID = 5, DayOfWeek = "Noday", StartTime = "22:00", EndTime = "24:00", EmployeeID = 100001 };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            bool expectResult = false;
            //Act
            bool actualResult = _availabilityManager.AddAvailability(availability);
            //Assert
            Assert.AreEqual(actualResult, expectResult);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Inserting Availability invalid startTime length
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [ExpectedException(typeof(ApplicationException))]
        [TestMethod]
        public void TestInsertAvailabilityInvalidAvailabilityStartTimeTooLong()
        {
            //Arrange
            EmployeeAvailability availability = new EmployeeAvailability() { AvailabilityID = 4, DayOfWeek = "Monday", StartTime = "12345678913245678789132", EndTime = "24:00", EmployeeID = 1 };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            bool actualResult = _availabilityManager.AddAvailability(availability);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Inserting Availability invalid endTime length
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [ExpectedException(typeof(ApplicationException))]
        [TestMethod]
        public void TestInsertAvailabilityInvalidAvailabilityEndTimeTooLong()
        {
            //Arrange
            EmployeeAvailability availability = new EmployeeAvailability() { AvailabilityID = 4, DayOfWeek = "Monday", StartTime = "22:00", EndTime = "12345677889132456789132", EmployeeID = 1 };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            bool actualResult = _availabilityManager.AddAvailability(availability);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for updating Availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestUpdateAvailabilitySuccess()
        {
            //Arrange
            EmployeeAvailability oldAvailability = new EmployeeAvailability()
            {
                AvailabilityID = 1,
                EmployeeID = 100000,
                DayOfWeek = "Monday",
                StartTime = new DateTime(2020, 4, 21, 10, 0, 0).ToString(),
                EndTime = new DateTime(2020, 4, 21, 23, 0, 0).ToString()
            };
            EmployeeAvailability availability = new EmployeeAvailability()
            {
                AvailabilityID = 1,
                EmployeeID = 100000,
                DayOfWeek = "Tuesday",
                StartTime = new DateTime(2020, 4, 21, 10, 0, 0).ToShortTimeString(),
                EndTime = new DateTime(2020, 4, 21, 23, 0, 0).ToShortTimeString()
            };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            bool expectResult = true;
            //Act
            bool actualResult = _availabilityManager.EditAvailability(availability, oldAvailability);
            //Assert
            Assert.AreEqual(expectResult, actualResult);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Update Availability invalid userID
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [ExpectedException(typeof(ApplicationException))]
        [TestMethod]
        public void TestUpdateNewAvailabilityInvalidUserID()
        {
            //Arrange
            EmployeeAvailability oldAvailability = new EmployeeAvailability() { AvailabilityID = 1, DayOfWeek = "Monday", StartTime = "10:00", EndTime = "18:00", EmployeeID = 1 };
            EmployeeAvailability availability = new EmployeeAvailability() { AvailabilityID = 1, DayOfWeek = "Monday", StartTime = "22:00", EndTime = "24:00", EmployeeID = 0 };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            bool actualResult = _availabilityManager.EditAvailability(availability, oldAvailability);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Updating Availability invalid AvailiabilityID
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [ExpectedException(typeof(ApplicationException))]
        [TestMethod]
        public void TestUpdateNewAvailabilityInvalidAvailabilityID()
        {
            //Arrange
            EmployeeAvailability oldAvailability = new EmployeeAvailability() { AvailabilityID = 1, DayOfWeek = "Monday", StartTime = "10:00", EndTime = "18:00", EmployeeID = 1 };
            EmployeeAvailability availability = new EmployeeAvailability() { AvailabilityID = 2, DayOfWeek = "Monday", StartTime = "22:00", EndTime = "24:00", EmployeeID = 1 };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            bool actualResult = _availabilityManager.EditAvailability(availability, oldAvailability);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Update a new Availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestUpdateNewAvailabilitySuccess()
        {
            //Arrange
            EmployeeAvailability oldAvailability = new EmployeeAvailability() { AvailabilityID = 1, EmployeeID = 100000, DayOfWeek = "Monday", StartTime = new DateTime(2020, 4, 21, 10, 0, 0).ToString(), EndTime = new DateTime(2020, 4, 21, 23, 0, 0).ToString() };
            EmployeeAvailability availability = new EmployeeAvailability() { AvailabilityID = 1, DayOfWeek = "Noday", StartTime = "22:00", EndTime = "24:00", EmployeeID = 100001 };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            bool expectResult = false;
            //Act
            bool actualResult = _availabilityManager.EditAvailability(availability, oldAvailability);
            //Assert
            Assert.AreEqual(actualResult, expectResult);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Updating Availability with no changes
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestUpdateNewAvailabilitySucessNoChanges()
        {
            //Arrange
            EmployeeAvailability oldAvailability = new EmployeeAvailability() { AvailabilityID = 1, EmployeeID = 100000, DayOfWeek = "Monday", StartTime = new DateTime(2020, 4, 21, 10, 0, 0).ToString(), EndTime = new DateTime(2020, 4, 21, 23, 0, 0).ToString() };
            EmployeeAvailability availability = new EmployeeAvailability() { AvailabilityID = 1, DayOfWeek = "Monday", StartTime = "10:00", EndTime = "18:00", EmployeeID = 100001 };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            bool expectResult = true;
            //Act
            bool actualResult = _availabilityManager.EditAvailability(availability, oldAvailability);
            //Assert
            Assert.AreEqual(actualResult, expectResult);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for invalid old Availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [ExpectedException(typeof(ApplicationException))]
        [TestMethod]
        public void TestUpdateOldAvailabilityNotReal()
        {
            //Arrange
            EmployeeAvailability oldAvailability = new EmployeeAvailability() { AvailabilityID = 1, DayOfWeek = "NoDay", StartTime = "10:00", EndTime = "18:00", EmployeeID = 1 };
            EmployeeAvailability availability = new EmployeeAvailability() { AvailabilityID = 1, DayOfWeek = "Monday", StartTime = "10:00", EndTime = "18:00", EmployeeID = 1 };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            bool actualResult = _availabilityManager.EditAvailability(availability, oldAvailability);

        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Update Availability Invalid Start Time Length
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [ExpectedException(typeof(ApplicationException))]
        [TestMethod]
        public void TestUpdateNewAvailabilityInvalidAvailabilityStartTimeTooLong()
        {
            //Arrange
            EmployeeAvailability oldAvailability = new EmployeeAvailability() { AvailabilityID = 1, DayOfWeek = "Monday", StartTime = "10:00", EndTime = "18:00", EmployeeID = 1 };
            EmployeeAvailability availability = new EmployeeAvailability() { AvailabilityID = 1, DayOfWeek = "Monday", StartTime = "12345678913245678789132", EndTime = "24:00", EmployeeID = 1 };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            bool actualResult = _availabilityManager.EditAvailability(availability, oldAvailability);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Updating Availability invalid endTime Length
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [ExpectedException(typeof(ApplicationException))]
        [TestMethod]
        public void TestUpdateNewAvailabilityInvalidAvailabilityEndTimeTooLong()
        {
            //Arrange
            EmployeeAvailability oldAvailability = new EmployeeAvailability() { AvailabilityID = 1, DayOfWeek = "Monday", StartTime = "10:00", EndTime = "18:00", EmployeeID = 1 };
            EmployeeAvailability availability = new EmployeeAvailability() { AvailabilityID = 1, DayOfWeek = "Monday", StartTime = "22:00", EndTime = "12345677889132456789132", EmployeeID = 1 };
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            bool actualResult = _availabilityManager.EditAvailability(availability, oldAvailability);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Retrieving all Availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllAvailabilites()
        {
            //Arrange

            int expectedResult = 4;
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            var actualResult = _availabilityManager.RetrieveAllAvailabilities();
            //Assert
            Assert.AreEqual(expectedResult, actualResult.Count);
        }

        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Retreiving Availability by User ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAvailabilitesByUserID()
        {
            //Arrange

            int expectedResult = 3;
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            var actualResult = _availabilityManager.RetrieveAvailabilityByUserID(100000);
            //Assert
            Assert.AreEqual(expectedResult, actualResult.Count);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Retreiving Availability by User ID invalid
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [ExpectedException(typeof(ApplicationException))]
        [TestMethod]
        public void TestRetrieveAvailabilitesInvalidUserID()
        {
            //Arrange


            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            var actualResult = _availabilityManager.RetrieveAvailabilityByUserID(0);


        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Activating Availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestActivateAvailabilites()
        {
            //Arrange

            bool expectedResult = true;
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            var actualResult = _availabilityManager.ActivateAvailability(1);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Activating Availability invalid ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [ExpectedException(typeof(ApplicationException))]
        [TestMethod]
        public void TestActivateAvailabilitesInvalidID()
        {
            //Arrange


            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            var actualResult = _availabilityManager.ActivateAvailability(10);

        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Dectivating Availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestDeactivateAvailabilites()
        {
            //Arrange

            bool expectedResult = true;
            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            var actualResult = _availabilityManager.DeactivateAvailability(1);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        /// Creator: Chase Schulte
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// 
        /// Test Method for Dectivating Availability invalid ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [ExpectedException(typeof(ApplicationException))]
        [TestMethod]
        public void TestDectivateAvailabilitesInvalidID()
        {
            //Arrange


            IAvailabilityManager _availabilityManager = new AvailabilityManager(_availabilityAccessor);
            //Act
            var actualResult = _availabilityManager.DeactivateAvailability(10);

        }

    }
}

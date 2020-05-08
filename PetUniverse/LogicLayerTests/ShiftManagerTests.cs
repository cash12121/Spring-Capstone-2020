using System;
using System.Collections.Generic;
using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
    /// <summary>
    ///  CREATOR: Kaleb Bachert
    ///  CREATED: 2020/4/1
    ///  APPROVER: Lane Sandburg
    ///  
    ///  Test Class for ShiftManager
    /// </summary>
    [TestClass]
    public class ShiftManagerTests
    {
        private IShiftAccessor _shiftAccessor;

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/1
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Constructor for instantiating FakeShiftAccessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public ShiftManagerTests()
        {
            _shiftAccessor = new FakeShiftAccessor();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/1
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Test method for retrieving all scheduled shifts for an Employee
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveShiftsByUser()
        {
            //arrange
            List<ShiftVM> shiftVMs;
            IShiftManager shiftManager = new ShiftManager(_shiftAccessor);

            //act
            shiftVMs = shiftManager.RetrieveShiftsByUser(100001);

            //assert
            Assert.AreEqual(3, shiftVMs.Count);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/1
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Test method for changing the EmployeeID for a shift
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestEditShiftUserWorking()
        {
            //Arrange
            IShiftManager shiftManager = new ShiftManager(_shiftAccessor);
            int shiftToChange = 1000002;
            int newUserWorking = 100000;
            int oldUserWorking = 100001;


            //Act
            bool oneShiftModified = shiftManager.EditShiftUserWorking(shiftToChange, newUserWorking, oldUserWorking);

            //Assert
            Assert.IsTrue(oneShiftModified);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/1
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Test method for increasing the count of hours worked for a user
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestEditEmployeeHoursWorkedPositive()
        {
            //Arrange
            IShiftManager shiftManager = new ShiftManager(_shiftAccessor);
            int userID = 1000000;
            int scheduleID = 1000000;
            int weekNumber = 1;
            double changeAmount = 8.2;


            //Act
            bool oneScheduleModified = shiftManager.EditEmployeeHoursWorked(userID, scheduleID, weekNumber, changeAmount);

            //Assert
            Assert.IsTrue(oneScheduleModified);
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/1
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Test method for decreasing the count of hours worked for a user
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestEditEmployeeHoursWorkedNegative()
        {
            //Arrange
            IShiftManager shiftManager = new ShiftManager(_shiftAccessor);
            int userID = 1000001;
            int scheduleID = 1000001;
            int weekNumber = 2;
            double changeAmount = -4.2;


            //Act
            bool oneScheduleModified = shiftManager.EditEmployeeHoursWorked(userID, scheduleID, weekNumber, changeAmount);

            //Assert
            Assert.IsTrue(oneScheduleModified);
        }

         private TestContext testContextInstance;

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

         /// <summary>
         /// Creator: Chase Schulte
         /// 
         /// Created: 04/07/2020
         /// Approver: Kaleb Bachert
         /// 
         /// Test Retrieve fail from "FakeShiftAccessor" because invalid ID
         /// </summary>
         ///
         /// <remarks>
         /// Updater 
         /// Updated:
         /// Update: 
         /// </remarks>
         [TestMethod]
         [ExpectedException(typeof(ApplicationException))]
         public void TestRetrieveShiftWithInvalidShiftID()
         {
             //Arrange
             int shiftID = 0;
             IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);
             //Act
             ShiftDetailsVM actualResult = _shiftManager.RetrieveShfitDetailsByID(shiftID);

         }

         /// <summary>
         /// Creator: Chase Schulte
         /// 
         /// Created: 04/07/2020
         /// Approver: Kaleb Bachert
         /// 
         /// Test Retrieve from "FakeShiftDetailsAccessor"
         /// </summary>
         ///
         /// <remarks>
         /// Updater 
         /// Updated:
         /// Update: 
         /// </remarks>
         [TestMethod]
         public void TestRetrieveShiftDetailsSuccess()
         {
             //Arrange
             int shiftID = 1;
             IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);
             ShiftDetailsVM expectResult = new ShiftDetailsVM() { ShiftID = 1, ShiftDate = DateTime.Now, RoleID = "Role1", ScheduleID = 1, ShiftTimeID = 1, EmployeeID = 1 };
             //Act
             ShiftDetailsVM actualResult = _shiftManager.RetrieveShfitDetailsByID(shiftID);
             //Assert
             Assert.AreEqual(actualResult.ShiftID, expectResult.ShiftID);
         }
         /// <summary>
         /// Creator: Chase Schulte
         /// 
         /// Created: 04/07/2020
         /// Approver: Kaleb Bachert
         /// 
         /// Test Retrieve from "FakeShiftDetailsAccessor" with different expected result
         /// </summary>
         ///
         /// <remarks>
         /// Updater 
         /// Updated:
         /// Update: 
         /// </remarks>
         [TestMethod]
         public void TestRetrieveShiftDetailsWithDifferentExpectedResult()
         {
             //Arrange
             int shiftID = 1;
             IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);
             ShiftDetailsVM expectResult = new ShiftDetailsVM() { ShiftID = 2, ShiftDate = DateTime.Now, RoleID = "Role1", ScheduleID = 1, ShiftTimeID = 1, EmployeeID = 1 };
             //Act
             ShiftDetailsVM actualResult = _shiftManager.RetrieveShfitDetailsByID(shiftID);
             //Assert
             Assert.AreNotEqual(actualResult.ShiftID, expectResult.ShiftID);
         }
         /// <summary>
         /// Creator: Chase Schulte
         /// 
         /// Created: 04/07/2020
         /// Approver:
         /// 
         /// Test Retrieve fail from "FakeShiftDetailsAccessor" because invalid ID
         /// </summary>
         ///
         /// <remarks>
         /// Updater 
         /// Updated:
         /// Update: 
         /// </remarks>
         [TestMethod]
         [ExpectedException(typeof(ApplicationException))]
         public void TestRetrieveShiftDetailsWithInvalidShiftID()
         {
             //Arrange
             int shiftID = 0;
             IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);
             //Act
             ShiftDetailsVM actualResult = _shiftManager.RetrieveShfitDetailsByID(shiftID);

         }


         /// <summary>
         /// Creator: Chase Schulte
         /// 
         /// Created: 04/07/2020
         /// Approver: Kaleb Bachert
         /// 
         /// Test Retrieve fail from "FakeShiftAccessor" because invalid ID
         /// </summary>
         ///
         /// <remarks>
         /// Updater 
         /// Updated:
         /// Update: 
         /// </remarks>
         [TestMethod]
         public void TestRetrieveShiftWithInvalidUserID()
         {
             //Arrange
             int userID = 0;
             IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);
             //Act
             var actualResult = _shiftManager.RetrieveShfitDetailsByUserID(userID);
             Assert.AreEqual(null, actualResult);

         }

         /// <summary>
         /// Creator: Chase Schulte
         /// 
         /// Created: 04/07/2020
         /// Approver: Kaleb Bachert
         /// 
         /// Test Retrieve from "FakeShiftDetailsAccessor"
         /// </summary>
         ///
         /// <remarks>
         /// Updater 
         /// Updated:
         /// Update: 
         /// </remarks>
         [TestMethod]
         public void TestRetrieveShiftDetailsByUSerIDSuccess()
         {
             //Arrange
             int userID = 1;
             IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);

             //Act
             var actualResult = _shiftManager.RetrieveShfitDetailsByUserID(userID);
             //Assert
             Assert.AreEqual(1, actualResult.Count);
         }

         /// <summary>
         /// Creator: Chase Schulte
         /// 
         /// Created: 04/07/2020
         /// Approver: Kaleb Bachert
         /// 
         /// Test Retrieve fail from "FakeShiftDetailsAccessor" because invalid ID
         /// </summary>
         ///
         /// <remarks>
         /// Updater 
         /// Updated:
         /// Update: 
         /// </remarks>
         [TestMethod]
         public void TestRetrieveShiftDetailsWithInvalidUserID()
         {
             //Arrange
             int userID = 0;
             IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);
             //Act
             var actualResult = _shiftManager.RetrieveShfitDetailsByUserID(userID);
             Assert.AreEqual(null, actualResult);
         }


        /// <summary>
        /// Creator: Chase Schulte
        /// 
        /// Created: 04/27/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Retrieve shifts by schedule and department id
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        [TestMethod]
        public void TestSelectShiftsByScheduleAndDepartmentID()
        {
            //Arrange
            int expectedResult = 1;
            string departmentID = "Test1";
            int scheduleID = 1;
            IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);
            //Act
            List<ShiftUserVM> actualResult = _shiftManager.RetrieveShiftsByScheduleAndDepartmentID(scheduleID, departmentID);
            Assert.AreEqual(expectedResult, actualResult.Count);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// 
        /// Created: 04/27/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Retrieve shifts by schedule and invalid department id
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        [TestMethod]
        public void TestSelectShiftsByScheduleAndInvalidDepartmentID()
        {
            //Arrange
            string departmentID = "Fake4";
            int scheduleID = 1;
            IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);
            //Act
            List<ShiftUserVM> actualResult = _shiftManager.RetrieveShiftsByScheduleAndDepartmentID(scheduleID, departmentID);
            Assert.AreEqual(null, actualResult);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// 
        /// Created: 04/27/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Retrieve shifts by schedule and department id invalid scheudle id
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        [TestMethod]
        public void TestSelectShiftsByScheduleAndInvalidScheduleID()
        {
            //Arrange
            int expectedResult = 0;
            string departmentID = "Test1";
            int scheduleID = 8;
            IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);
            //Act
            List<ShiftUserVM> actualResult = _shiftManager.RetrieveShiftsByScheduleAndDepartmentID(scheduleID, departmentID);
            Assert.AreEqual(expectedResult, actualResult.Count);
        }


        /// <summary>
        /// Creator: Chase Schulte
        /// 
        /// Created: 04/27/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Retrieve shifts by schedule and department id and date
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        [TestMethod]
        public void TestSelectShiftsByScheduleAndDepartmentIDDate()
        {
            //Arrange
            int expectedResult = 1;
            DateTime Date = DateTime.Today;
            string departmentID = "Test1";
            int scheduleID = 1;
            IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);
            //Act
            List<ShiftUserVM> actualResult = _shiftManager.RetrieveShiftsByScheduleAndDepartmentIDWithDate(scheduleID, departmentID, Date);
            Assert.AreEqual(expectedResult, actualResult.Count);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// 
        /// Created: 04/27/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Retrieve shifts by schedule and invalid department id and date
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        [TestMethod]
        public void TestSelectShiftsByScheduleAndInvalidDepartmentDate()
        {
            //Arrange
            DateTime Date = DateTime.Today;
            string departmentID = "Fake01";
            int scheduleID = 1;
            IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);
            //Act
            List<ShiftUserVM> actualResult = _shiftManager.RetrieveShiftsByScheduleAndDepartmentIDWithDate(scheduleID, departmentID, Date);
            Assert.AreEqual(null, actualResult);

        }
        /// <summary>
        /// Creator: Chase Schulte
        /// 
        /// Created: 04/27/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Retrieve shifts by invalid schedule and department id and date
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        [TestMethod]
        public void TestSelectShiftsByScheduleAndInvalidScheduleIDDate()
        {
            //Arrange
            DateTime Date = DateTime.Today;
            int expectedResult = 0;
            string departmentID = "Test1";
            int scheduleID = 8;
            IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);
            //Act
            List<ShiftUserVM> actualResult = _shiftManager.RetrieveShiftsByScheduleAndDepartmentIDWithDate(scheduleID, departmentID, Date);
            Assert.AreEqual(expectedResult, actualResult.Count);
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// 
        /// Created: 04/27/2020
        /// Approver:Kaleb Bachert
        /// 
        /// Test Retrieve shifts by schedule and department id with invalid date
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        [TestMethod]
        public void TestSelectShiftsByScheduleAndScheduleIInvalidDDate()
        {
            //Arrange
            DateTime Date = DateTime.Today.AddYears(10).AddDays(10);
            int expectedResult = 0;
            string departmentID = "Test1";
            int scheduleID = 1;
            IShiftManager _shiftManager = new ShiftManager(_shiftAccessor);
            //Act
            List<ShiftUserVM> actualResult = _shiftManager.RetrieveShiftsByScheduleAndDepartmentIDWithDate(scheduleID, departmentID, Date);
            Assert.AreEqual(expectedResult, actualResult.Count);
        }
    }
}

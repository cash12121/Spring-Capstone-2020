using System;
using System.Text;
using System.Collections.Generic;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessInterfaces;

namespace LogicLayerTests
{
    /// <summary>
    /// Summary description for EmployeeAvailabilityManagerTests
    /// </summary>
    [TestClass]
    public class EmployeeAvailabilityManagerTests
    {
        private IEmployeeAvailabilityAccessor _employeeAvailabilityAccessor;
        private FakeEmployeeAvailabilityAccessor _fakeEmployeeAvailabilityAccessor;


        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 4/2/2020
        /// Approver: Jordan Lindo
        /// 
        /// Setup for tests to run
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA        
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _employeeAvailabilityAccessor = new FakeEmployeeAvailabilityAccessor();
            _fakeEmployeeAvailabilityAccessor = new FakeEmployeeAvailabilityAccessor();

        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 4/2/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test for Creating a user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// </remarks>
        [TestMethod]
        public void TestCreateNewEmployeeAvailability()
        {
            // arrange
            EmployeeAvailability employeeAvailability = new EmployeeAvailability()
            {
                EmployeeID = 100000,
                DayOfWeek = "Monday",
                StartTime = "10:50:06",
                EndTime = "11:50:06"

            };

            bool created = false;
            bool expectedResult = true;

            // act
            created = _employeeAvailabilityAccessor.InsertNewEmployeeAvailability(employeeAvailability);

            // assert
            Assert.AreEqual(expectedResult, created);
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 4/9/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test for selecting the last user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// </remarks>
        [TestMethod]
        public void TestSelectLastUserID()
        {
            int employeeID;

            employeeID = _employeeAvailabilityAccessor.SelectLastCreatedEmployeeID();

            Assert.AreEqual(100001, employeeID);

        }
        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 4/9/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test for selecting availibilities 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAvailabilitiesByEmployeeID()
        {
            int employeeID = 100000;
            int expectedResult = 1;
            List<EmployeeAvailability> availabilities = _fakeEmployeeAvailabilityAccessor.SelectEmployeeAvailabilityByID(employeeID);


            Assert.AreEqual(expectedResult, availabilities.Count);

        }

    }
}

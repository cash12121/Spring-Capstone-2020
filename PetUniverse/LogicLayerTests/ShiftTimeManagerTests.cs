using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{

    /// <summary>
    /// Creator: Lane Sandburg
    /// Created: 02/07/2019
    /// Approver: Alex Diers
    /// 
    /// Tests of the Shift ManagerClass Methods
    /// </summary>
    [TestClass]
    public class ShiftTimeManagerTests
    {

        private IShiftTimeAccessor _shiftTimeAccessor;
        public ShiftTimeManagerTests()
        {
            _shiftTimeAccessor = new FakeShiftTimeAccessor();
        }


        /// /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// Test of the Shift Time insert Method
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
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

        [TestMethod]
        public void TestShiftTimeManagerInsertShiftTimeTests()
        {

            //arrange
            PetUniverseShiftTime shiftTime = new PetUniverseShiftTime();
            shiftTime.DepartmentID = "Shipping/Receiving";
            shiftTime.StartTime = "14:00:00";
            shiftTime.EndTime = "22:00:00";
            bool test;
            IShiftTimeManager shiftTimeManager = new ShiftTimeManager(_shiftTimeAccessor);

            //act
            test = shiftTimeManager.AddShiftTime(shiftTime);

            //assert
            Assert.IsTrue(test);
        }

        /// /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Kaleb Bachert
        /// 
        /// Test of the Shift Time deactivate Method
        /// </summary>
        /// <remarks>
        /// Updater: Lane Sandburg
        /// Updated: 05/05/2020
        /// Update: renamed to DeactivateShiftTime
        /// </remarks>
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

        [TestMethod]
        public void TestShiftTimeManagerDeactivatetShiftTimeTests()
        {

            //arrange
            int shiftTimeID = 100001;
            bool test;
            IShiftTimeManager shiftTimeManager = new ShiftTimeManager(_shiftTimeAccessor);
            bool expectedResult = true;

            //act
            test = shiftTimeManager.DeactivateShiftTime(shiftTimeID);

            //assert
            Assert.AreEqual(test, expectedResult);

        }

        /// /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// Test of the Shift Time Edit Method
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TestShiftTimeManagerEditShiftTimeTests()
        {

            //arrange
            PetUniverseShiftTime oldShiftTime = new PetUniverseShiftTime();
            oldShiftTime.DepartmentID = "Shipping/Receiving";
            oldShiftTime.StartTime = "14:00:00";
            oldShiftTime.EndTime = "22:00:00";

            PetUniverseShiftTime newShiftTime = new PetUniverseShiftTime();
            newShiftTime.DepartmentID = "Shipping/Receiving";
            newShiftTime.StartTime = "08:00:00";
            newShiftTime.EndTime = "16:00:00";
            bool test;
            IShiftTimeManager shiftTimeManager = new ShiftTimeManager(_shiftTimeAccessor);

            //act
            test = shiftTimeManager.EditShiftTime(oldShiftTime, newShiftTime);

            //assert
            Assert.IsTrue(test);
        }

        /// /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// Test of the Shift Time Retrieve Method
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TestShiftTimeManagerRetrieveShiftTimes()
        {
            //arrange
            List<PetUniverseShiftTime> shifTimes;
            IShiftTimeManager shiftTimeManager = new ShiftTimeManager(_shiftTimeAccessor);

            //act
            shifTimes = shiftTimeManager.RetrieveShiftTimes();

            //assert
            Assert.AreEqual(1, shifTimes.Count);
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 03/18/2020
        /// Approver: Chase Schulte
        /// 
        /// Test for selecting Shift time by departmentID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void SelectShiftTimesByDepartmentID()
        {
            IShiftTimeManager shiftTimeManager = new ShiftTimeManager(_shiftTimeAccessor);
            List<PetUniverseShiftTime> times;

            times = shiftTimeManager.RetrieveShiftTimesByDepartment("Sales");

            Assert.AreEqual(1, times.Count);
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 04/23/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test for selecting a Shift time by id.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        [TestMethod]
        public void TestSelectShiftTimesByID()
        {
            IShiftTimeManager shiftTimeManager = new ShiftTimeManager(_shiftTimeAccessor);
            PetUniverseShiftTime time;

            PetUniverseShiftTime target = new PetUniverseShiftTime()
            {
                ShiftTimeID = 100001,
                DepartmentID = "Sales",
                StartTime = "08:45:00",
                EndTime = "5:45:00"
            };

            time = shiftTimeManager.RetrieveShiftTimeByID(100001);

            Assert.AreEqual(target.ShiftTimeID, time.ShiftTimeID);
        }
    }
}

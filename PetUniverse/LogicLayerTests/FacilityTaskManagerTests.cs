using System;
using System.Collections.Generic;
using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 4/9/2020
    /// Approver: Ben Hanna, 4/10/20
    /// Approver: 
    /// 
    /// Test Class to test the logic layer facility task class 
    /// </summary>
    [TestClass]
    public class FacilityTaskManagerTests
    {
        private IFacilityTaskAccessor _fakeFacilityTaskAccessor;
        private FacilityTaskManager _facilityTaskManager;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to set up the objects for the test
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestInitialize]
        public void TestSetUp()
        {
            _fakeFacilityTaskAccessor = new FakeFacilityTaskAccessor();
            _facilityTaskManager = new FacilityTaskManager(_fakeFacilityTaskAccessor);
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to test the InsertFacilityTaskRecord in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddFacilityTaskRecord()
        {
            // arrange
            FacilityTask facilityTask = new FacilityTask()
            {
                FacilityTaskID = 1000000,
                FacilityTaskName = "Clean",
                UserID = 100000,
                StartDate = new DateTime(2018, 7, 10, 7, 10, 24),
                CompletionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                TaskCompleted = false
            };
            bool result = false;

            // act
            result = _facilityTaskManager.AddFacilityTaskRecord(facilityTask);

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to test the RetrieveAllFacilityTasks in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllFacilityTasks()
        {
            // arrange

            // act
            List<FacilityTask> tasks = _facilityTaskManager.RetrieveAllFacilityTask();

            int count = tasks.Count;

            // assert
            Assert.AreEqual(3, count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to test the RetrieveFacilityTaskByID in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveFacilityTasksByID()
        {
            // arrange

            int facilityTaskID = 1000000;

            // act
            List<FacilityTask> tasks = _facilityTaskManager.RetrieveFacilityTaskByID(facilityTaskID);

            int count = tasks.Count;

            // assert
            Assert.AreEqual(1, count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to test the RetrieveFacilityTasksByUserID in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveFacilityInspectionByUserID()
        {
            // arrange

            int userID = 100000;

            // act
            List<FacilityTask> tasks = _facilityTaskManager.RetrieveFacilityTaskByUserID(userID);

            int count = tasks.Count;

            // assert
            Assert.AreEqual(2, count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to test the RetrieveFacilityTaskByTaskName in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveFacilityTaskByTaskName()
        {
            // arrange

            string taskName = "Clean";

            // act
            List<FacilityTask> tasks = _facilityTaskManager.RetrieveFacilityTaskByTaskName(taskName);

            int count = tasks.Count;

            // assert
            Assert.AreEqual(3, count);
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/16/2020
        /// Approver: Daulton Schiling, 4/16/2020
        /// 
        /// Method to test the EditFacilityTask in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestEditFacilityTask()
        {
            // arrange
            FacilityTask oldFacilityTask = new FacilityTask()
            {
                FacilityTaskID = 1000000,
                FacilityTaskName = "Clean",
                UserID = 100000,
                StartDate = new DateTime(2018, 7, 10, 7, 10, 24),
                CompletionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                TaskCompleted = false
            };
            FacilityTask newFacilityTask = new FacilityTask()
            {
                FacilityTaskID = 1000000,
                FacilityTaskName = "Break",
                UserID = 100001,
                StartDate = new DateTime(2018, 7, 10, 7, 10, 24),
                CompletionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                TaskCompleted = false
            };
            bool result = false;

            // act
            result = _facilityTaskManager.EditFacilityTask(oldFacilityTask, newFacilityTask);

            // assert
            Assert.IsTrue(result);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/16/2020
        /// Approver: Daulton Schiling, 4/16/2020
        /// 
        /// Method to test the DeleteFacilityTask in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeleteFacilityTask()
        {
            // arrange
            FacilityTask taskRecord = new FacilityTask()
            {
                FacilityTaskID = 1000003,
                FacilityTaskName = "Break",
                UserID = 100001,
                StartDate = new DateTime(2018, 7, 10, 7, 10, 24),
                CompletionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                TaskCompleted = false
            };

            bool result = false;

            // act
            result = _facilityTaskManager.DeleteFacilityTask(taskRecord.FacilityTaskID);

            // assert
            Assert.IsTrue(result);

        }


        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// 
        /// Method to tear down the test and clear memory
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _facilityTaskManager = null;
            _fakeFacilityTaskAccessor = null;
        }
    }
}

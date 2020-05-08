using DataAccessFakes;
using DataAccessLayer;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using DataTransferObjects;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver:
    /// 
    /// Test class for NewAnimalChecklist
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>

    [TestClass]
    public class AnimalChecklistManagerTests
    {
        private INewAnimalChecklistAccessor _animalChecklistAccessor;

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// No argument constructor for NewAnimalChecklistTest
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        public AnimalChecklistManagerTests()
        {
            _animalChecklistAccessor = new FakeNewAnimalChecklistAccessor();
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Test method for RetrieveNewAnimalChecklistByAnimalID- tests with correct value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveNewAnimalChecklistByAnimalIDWithCorrectValue()
        {
            // arrange
            List<NewAnimalChecklist> NewAnimalChecklist;
            INewAnimalChecklistManager _AnimalChecklistManager = new NewAnimalChecklistManager(_animalChecklistAccessor);

            // act
            NewAnimalChecklist = _AnimalChecklistManager.RetrieveNewAnimalChecklistByAnimalID(1);

            // assert
            Assert.AreEqual(1, NewAnimalChecklist.Count);

        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Test method for RetrieveNewAnimalChecklistByAnimalID- tests for throwing the correct exception
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRetrieveNewAnimalChecklistByAnimalIDThrowsCorrectException()
        {
            // arrange
            INewAnimalChecklistManager _AnimalChecklistManager = new NewAnimalChecklistManager(_animalChecklistAccessor);


            // act
            _AnimalChecklistManager.RetrieveNewAnimalChecklistByAnimalID(-1);

        }



        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Test cleanup
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        [TestCleanup]
        public void TestTearDown()
        {
            _animalChecklistAccessor = null;

        }





    }
}


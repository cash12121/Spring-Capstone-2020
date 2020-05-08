using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
    public class AnimalMedicalHistoryManagerTests
    {
        private IAnimalMedicalHistoryAccessor animalMedicalHistoryAccessor;

        public AnimalMedicalHistoryManagerTests()
        {
            animalMedicalHistoryAccessor = new FakeMedicalHistoryAccessor();
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// 
        /// Test method for RetrieveAnimalMedicalHistoryByAnimalID- tests with correct value
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
            List<MedicalHistory> MH;

            IAnimalMedicalHistoryManager amhm = new AnimalMedicalHistoryManager(animalMedicalHistoryAccessor);

            // act
            MH = amhm.RetrieveAnimalMedicalHistoryByAnimalID(1);

            // assert
            Assert.AreEqual(1, MH.Count);

        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// 
        /// Test method for RetrieveAnimalMedicalHistoryByAnimalID- tests for throwing the correct exception
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRetrieveAnimalMedicalHistoryByAnimalIDThrowsCorrectException()
        {
            // arrange
            AnimalMedicalHistoryManager MH = new AnimalMedicalHistoryManager(animalMedicalHistoryAccessor);
            int TestValue = -1000;

            // act
            MH.RetrieveAnimalMedicalHistoryByAnimalID(TestValue);

        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/19/2020
        /// Approver: Carl Davis 4/16/2020 
        /// Approver: 
        /// 
        /// Test method for UpdateAnimalMedicalHistory
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestUpdateAnimalMedicalHistory()
        {

            // Arrange
            int result = 0;

            AnimalMedicalHistoryManager MH = new AnimalMedicalHistoryManager(animalMedicalHistoryAccessor);

            MedicalHistory new_ = new MedicalHistory()
            {

            };

            MedicalHistory old_ = new MedicalHistory()
            {

            };

            // Act
            result = MH.UpdateAnimalMedicalHistory(new_, old_);

            // Assert
            Assert.AreEqual(new_, old_);


        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/19/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Test method for UpdateAnimalMedicalHistory- test throws correct exception
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestUpdateAnimalMedicalHistoryThrowsCorrectException()
        {
            // Arrange
            int result = 0;

            AnimalMedicalHistoryManager MH = new AnimalMedicalHistoryManager(animalMedicalHistoryAccessor);

            // Act
            result = MH.UpdateAnimalMedicalHistory(null, null);



        }


    }
}

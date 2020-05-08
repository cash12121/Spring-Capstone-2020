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
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/4/2020
    /// 
    /// Unit tests for the kennel cleaning record related methods
    /// </summary>
    [TestClass]
    public class AnimalKennelCleaningManagerTests
    {
        private IAnimalKennelCleaningAccessor _cleaningAccessor;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Constructor to set up the fake data accessor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalKennelCleaningManagerTests()
        {
            _cleaningAccessor = new FakeAnimalKennelCleaningAccessor();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Test for adding a kennel cleaning record. Good value.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddKennelCleaningRecordSuccess()
        {
            //Arrange
            IAnimalKennelCleaningManager cleaningManager = new AnimalKennelCleaningManager(_cleaningAccessor);
            const bool expectedResult = true;
            AnimalKennelCleaningRecord cleaningRecord = new AnimalKennelCleaningRecord() { AnimalKennelID = 1, Date = DateTime.Now, FacilityKennelCleaningID = 3, Notes = "bubba", UserID = 1 };

            //Act
            bool actualResult = cleaningManager.AddKennelCleaningRecord(cleaningRecord);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Test for adding a kennel cleaning record. Simulated database error.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestAddKennelCleaningRecordFailure()
        {
            //Arrange
            IAnimalKennelCleaningManager cleaningManager = new AnimalKennelCleaningManager(_cleaningAccessor);
            AnimalKennelCleaningRecord cleaningRecord = new AnimalKennelCleaningRecord() { AnimalKennelID = 1, Date = DateTime.Now, FacilityKennelCleaningID = 0, Notes = "bubba", UserID = 1 };

            //Act
            bool actualResult = cleaningManager.AddKennelCleaningRecord(cleaningRecord);

            //Assert
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/7/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Test for getting a list of kennel cleaning records.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestGetKennelCleaningRecords()
        {
            //Arrange
            List<AnimalKennelCleaningRecord> cleaningRecords = new List<AnimalKennelCleaningRecord>();
            IAnimalKennelCleaningManager animalKennelCleaningManager = new AnimalKennelCleaningManager(_cleaningAccessor);

            //Act
            cleaningRecords = animalKennelCleaningManager.RetrieveAllKennelCleaningRecords();

            //Assert
            Assert.AreEqual(2, cleaningRecords.Count);
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/8/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Test for updating a kennel cleaning record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestUpdateKennelCleaningRecordGoodValue()
        {
            //Arrange
            IAnimalKennelCleaningManager animalKennelCleaningManager = new AnimalKennelCleaningManager(_cleaningAccessor);
            AnimalKennelCleaningRecord oldRecord = new AnimalKennelCleaningRecord
            {
                FacilityKennelCleaningID = 1,
                AnimalKennelID = 1,
                UserID = 1,
                Date = new DateTime(2019, 5, 24),
                Notes = "Notes Notes 1"
            };

            AnimalKennelCleaningRecord newRecord = new AnimalKennelCleaningRecord
            {
                FacilityKennelCleaningID = 1,
                AnimalKennelID = 1,
                UserID = 1,
                Date = new DateTime(2019, 5, 24),
                Notes = "Update Update 1"
            };

            bool expectedResult = true;

            //Act
            bool actualResult = animalKennelCleaningManager.EditKennelCleaningRecord(oldRecord, newRecord);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/8/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Test for updating a kennel cleaning record. Simulates Error
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateKennelCleaningRecordBadValue()
        {
            //Arrange
            IAnimalKennelCleaningManager animalKennelCleaningManager = new AnimalKennelCleaningManager(_cleaningAccessor);
            AnimalKennelCleaningRecord oldRecord = new AnimalKennelCleaningRecord
            {
                FacilityKennelCleaningID = 0,
                AnimalKennelID = 1,
                UserID = 1,
                Date = new DateTime(2019, 5, 24),
                Notes = "Notes Notes 1"
            };

            AnimalKennelCleaningRecord newRecord = new AnimalKennelCleaningRecord
            {
                FacilityKennelCleaningID = 0,
                AnimalKennelID = 1,
                UserID = 1,
                Date = new DateTime(2019, 5, 24),
                Notes = "Update Update 1"
            };

            //Act
            bool actualResult = animalKennelCleaningManager.EditKennelCleaningRecord(oldRecord, newRecord);

        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/9/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Test for deleting a kennel cleaning record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeleteKennelCleaningRecordGoodValue()
        {
            // Arrange
            IAnimalKennelCleaningManager animalKennelCleaningManager = new AnimalKennelCleaningManager(_cleaningAccessor);
            AnimalKennelCleaningRecord deleteMe = new AnimalKennelCleaningRecord
            {
                FacilityKennelCleaningID = 2,
                AnimalKennelID = 2,
                UserID = 1,
                Date = new DateTime(2019, 6, 24),
                Notes = "Notes Notes 2"
            };

            bool expectedResult = true;

            // Act
            bool actualResult = animalKennelCleaningManager.RemoveKennelCleaningRecord(deleteMe);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/9/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Test for deleting a kennel cleaning record. Simulates Error
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeleteKennelCleaningRecordBadValue()
        {
            // Arrange
            IAnimalKennelCleaningManager animalKennelCleaningManager = new AnimalKennelCleaningManager(_cleaningAccessor);
            AnimalKennelCleaningRecord deleteMe = new AnimalKennelCleaningRecord
            {
                FacilityKennelCleaningID = 10,
                AnimalKennelID = 2,
                UserID = 1,
                Date = new DateTime(2019, 6, 24),
                Notes = "Bad Notes Bad Notes"
            };

            // Act
            bool actualResult = animalKennelCleaningManager.RemoveKennelCleaningRecord(deleteMe);
        }
    }
}

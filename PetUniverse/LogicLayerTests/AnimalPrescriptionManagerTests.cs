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
    /// Creator: Ethan Murphy
    /// Created: 2/16/2020
    /// Approver: Carl Davis 2/21/2020
    /// Approver: 
    /// 
    /// Test class for the animal prescription manager
    /// </summary>
    [TestClass]
    public class AnimalPrescriptionManagerTests
    {
        private IAnimalPrescriptionsAccessor _animalPrescriptionsAccessor;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver:
        /// 
        /// Default constructor that initializes the fake 
        /// animal prescriptions accessor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalPrescriptionManagerTests()
        {
            _animalPrescriptionsAccessor = new FakeAnimalPrescriptionsAccessor();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver:
        /// 
        /// Tests adding an animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddingNewAnimalPrescriptionsRecord()
        {
            // Arrange
            bool result = false;
            IAnimalPrescriptionManager animalPrescriptionManager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);
            AnimalPrescriptionVM animalPrescription = new AnimalPrescriptionVM()
            {
                AnimalID = 5,
                AnimalPrescriptionID = 5,
                AnimalVetAppointmentID = 5,
                PrescriptionName = "test5",
                Dosage = 2.0M,
                Interval = "2 times a day",
                AdministrationMethod = "Oral",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                Description = "test5",
                AnimalName = "wefyawaw"
            };

            // Act
            result = animalPrescriptionManager.AddAnimalPrescriptionRecord(animalPrescription);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Tests retrieving all animal prescription records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestSelectingAllAnimalPrescriptionRecords()
        {
            // Arrange
            List<AnimalPrescriptionVM> animalPrescriptions =
                new List<AnimalPrescriptionVM>();
            IAnimalPrescriptionManager animalPrescriptionManager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);

            // Act
            animalPrescriptions = animalPrescriptionManager.RetrieveAllAnimalPrescriptions();

            // Assert
            Assert.AreEqual(4, animalPrescriptions.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Tests retrieving animal prescription records
        /// for a specific animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestSelectPrescriptionRecordsByValidAnimalName()
        {
            // Arrange
            List<AnimalPrescriptionVM> animalPrescriptions =
                new List<AnimalPrescriptionVM>();
            IAnimalPrescriptionManager animalPrescriptionManager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);
            string animalName = "fawuief";

            // Act
            animalPrescriptions =
                animalPrescriptionManager.RetrievePrescriptionsByAnimalName(animalName);

            // Assert
            Assert.AreEqual(1, animalPrescriptions.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Tests retrieving animal prescription records
        /// for a specific animal that doesn't exist.
        /// Result should be 0
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestSelectPrescriptionRecordsByAnInvalidAnimalName()
        {
            // Arrange
            List<AnimalPrescriptionVM> animalPrescriptions =
                new List<AnimalPrescriptionVM>();
            IAnimalPrescriptionManager animalPrescriptionManager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);
            string animalName = "hrehahsea";

            // Act
            animalPrescriptions =
                animalPrescriptionManager.RetrievePrescriptionsByAnimalName(animalName);

            // Assert
            Assert.AreEqual(0, animalPrescriptions.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Tests updating an existing animal
        /// prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestUpdateExistingAnimalPrescriptionRecord()
        {
            // Arrange
            bool result = false;
            AnimalPrescriptionVM existingRecord = new AnimalPrescriptionVM()
            {
                AnimalID = 1,
                AnimalPrescriptionID = 1,
                AnimalVetAppointmentID = 1,
                PrescriptionName = "test",
                Dosage = 2.0M,
                Interval = "2 times a day",
                AdministrationMethod = "Oral",
                StartDate = DateTime.Parse("3/20/2020"),
                EndDate = DateTime.Parse("4/15/2020"),
                Description = "test",
                AnimalName = "fawuief"
            };
            AnimalPrescriptionVM newRecord = new AnimalPrescriptionVM()
            {
                AnimalID = 1,
                AnimalPrescriptionID = 1,
                AnimalVetAppointmentID = 1,
                PrescriptionName = "wefafawef",
                Dosage = 4.0M,
                Interval = "3 times a day",
                AdministrationMethod = "Oral",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                Description = "test",
                AnimalName = "fawuief"
            };
            IAnimalPrescriptionManager manager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);

            // Act
            result = manager.EditAnimalPrescriptionRecord(
                existingRecord, newRecord);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Tests updating a non-existent animal
        /// prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestUpdateNonExistentAnimalPrescriptionRecord()
        {
            // Arrange
            bool result = false;
            AnimalPrescriptionVM existingRecord = new AnimalPrescriptionVM()
            {
                AnimalID = 500,
                AnimalPrescriptionID = 1241,
                AnimalVetAppointmentID = 1214,
                PrescriptionName = "test",
                Dosage = 2.0M,
                Interval = "2 times a day",
                AdministrationMethod = "Oral",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                Description = "test",
                AnimalName = "fawuief"
            };
            AnimalPrescriptionVM newRecord = new AnimalPrescriptionVM()
            {
                AnimalID = 1,
                AnimalPrescriptionID = 1,
                AnimalVetAppointmentID = 1,
                PrescriptionName = "wefafawef",
                Dosage = 4.0M,
                Interval = "3 times a day",
                AdministrationMethod = "Oral",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                Description = "test",
                AnimalName = "fawuief"
            };
            IAnimalPrescriptionManager manager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);

            // Act
            result = manager.EditAnimalPrescriptionRecord(
                existingRecord, newRecord);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Tests deactivating an active record, and
        /// reactivating a deactive record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestChangeAnimalPrescriptionActiveStatus()
        {
            // Arrange
            bool deactivateResult = false;
            bool activateResult = false;
            IAnimalPrescriptionManager manager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);
            AnimalPrescription activeRecord = new AnimalPrescription() { AnimalPrescriptionID = 1 };
            AnimalPrescription inActiveRecord = new AnimalPrescription() { AnimalPrescriptionID = 2 };

            // Act
            deactivateResult = manager.DeactivateAnimalPrescriptionRecord(activeRecord);
            activateResult = manager.ActivateAnimalPrescriptionRecord(inActiveRecord);

            // Assert
            Assert.IsTrue(deactivateResult);
            Assert.IsTrue(activateResult);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Tests deleting a valid prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeleteExistingAnimalPrescriptionRecord()
        {
            // Arrange
            bool result = false;
            IAnimalPrescriptionManager manager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);
            AnimalPrescriptionVM animalPrescription = new AnimalPrescriptionVM()
            {
                AnimalID = 1,
                AnimalPrescriptionID = 1,
                AnimalVetAppointmentID = 1,
                PrescriptionName = "test",
                Dosage = 2.0M,
                Interval = "2 times a day",
                AdministrationMethod = "Oral",
                StartDate = DateTime.Parse("3/20/2020"),
                EndDate = DateTime.Parse("4/15/2020"),
                Description = "test",
                AnimalName = "fawuief",
                Active = true
            };

            // Act
            result = manager.DeleteAnimalPrescriptionRecord(animalPrescription);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Tests deleting an invalid prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeleteNonExistentAnimalPrescriptionRecord()
        {
            // Arrange
            bool result = false;
            IAnimalPrescriptionManager manager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);
            AnimalPrescriptionVM animalPrescription = new AnimalPrescriptionVM()
            {
                AnimalID = 5,
                AnimalPrescriptionID = 100,
                AnimalVetAppointmentID = 1,
                PrescriptionName = "testfawefawef",
                Dosage = 2.0M,
                Interval = "2 times a dayawfeawef",
                AdministrationMethod = "Oral",
                StartDate = DateTime.Parse("3/20/2020"),
                EndDate = DateTime.Parse("4/15/2020"),
                Description = "test",
                AnimalName = "fawuief",
                Active = true
            };

            // Act
            result = manager.DeleteAnimalPrescriptionRecord(animalPrescription);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Tests retrieving prescription records by active/inactive status
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrievingRecordsByActiveAndDeactiveStatus()
        {
            // Arrange
            IAnimalPrescriptionManager manager =
                new AnimalPrescriptionsManager(_animalPrescriptionsAccessor);
            List<AnimalPrescriptionVM> activeRecords;
            List<AnimalPrescriptionVM> inactiveRecords;

            // Act
            activeRecords = manager.RetrieveAnimalPrescriptionsByActive();
            inactiveRecords = manager.RetrieveAnimalPrescriptionsByActive(false);

            // Assert
            Assert.AreEqual(3, activeRecords.Count);
            Assert.AreEqual(1, inactiveRecords.Count);
        }
    }
}

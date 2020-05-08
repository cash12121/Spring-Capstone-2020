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
    /// Created: 2/7/2020
    /// Approver: Carl Davis 2/14/2020
    /// Approver: Chuck Baxter 2/14/2020
    /// 
    /// Test class for the vet appointment manager
    /// </summary>
    [TestClass]
    public class VetAppointmentManagerTests
    {
        private IVetAppointmentAccessor _vetAppointmentAccessor;
        private List<AnimalVetAppointment> _vetAppointments;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Default constructor that initializes the fake vet appointment accessor
        /// and vet appointment manager, then retrieves a list of all vet appointments
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public VetAppointmentManagerTests()
        {
            _vetAppointmentAccessor = new FakeVetAppointmentAccessor();
            IVetAppointmentManager vetAppointmentManager = new VetAppointmentManager(_vetAppointmentAccessor);
            _vetAppointments = vetAppointmentManager.RetrieveAllVetAppointments();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Tests retrieving all vet appointment records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestVetAppointmentManagerRetrieveAllAppointments()
        {
            // Arrange
            List<AnimalVetAppointment> vetAppointments;
            IVetAppointmentManager vetAppointmentManager = new VetAppointmentManager(_vetAppointmentAccessor);

            // Act
            vetAppointments = vetAppointmentManager.RetrieveAllVetAppointments();

            // Assert
            Assert.AreEqual(3, vetAppointments.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Tests retrieving inactive vet appointment records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestVetAppointmentsManagerRetrieveInactiveAppointments()
        {
            // Arrange
            List<AnimalVetAppointment> vetAppointments;
            IVetAppointmentManager vetAppointmentManager = new VetAppointmentManager(_vetAppointmentAccessor, _vetAppointments);

            // Act
            vetAppointments = vetAppointmentManager.RetrieveVetAppointmentsByActive(false);

            // Assert
            Assert.AreEqual(1, vetAppointments.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Tests retrieving vet appointment records by animal ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestVetAppointmentsManagerRetrieveAppointmentsByAnimalID()
        {
            // Arrange
            List<AnimalVetAppointment> vetAppointments;
            IVetAppointmentManager vetAppointmentManager = new VetAppointmentManager(_vetAppointmentAccessor, _vetAppointments);

            // Act
            vetAppointments = vetAppointmentManager.RetrieveVetAppointmentsByAnimalID(1);

            // Assert
            Assert.AreEqual(1, vetAppointments.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Tests retrieving vet appointment records by animal name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestVetAppointmentsManagerRetrieveAppointmentsByAnimalName()
        {
            // Arrange
            List<AnimalVetAppointment> vetAppointments;
            IVetAppointmentManager vetAppointmentManager = new VetAppointmentManager(_vetAppointmentAccessor, _vetAppointments);

            // Act
            vetAppointments = vetAppointmentManager.RetrieveAppointmentsByAnimalName("qwerty");

            // Assert
            Assert.AreEqual(1, vetAppointments.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Tests retrieving vet appointment records by clinic address
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestVetAppointmentsManagerRetrieveAppointmentsByClinicAddress()
        {
            // Arrange
            List<AnimalVetAppointment> vetAppointments;
            IVetAppointmentManager vetAppointmentManager = new VetAppointmentManager(_vetAppointmentAccessor, _vetAppointments);

            // Act
            vetAppointments = vetAppointmentManager.RetrieveAppointmentsByClinicAddress("1234 asdf");

            // Assert
            Assert.AreEqual(1, vetAppointments.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Tests retrieving vet appointment records by appointment date
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestVetAppointmentsManagerRetrieveAppointmentsByAppointmentDate()
        {
            // Arrange
            List<AnimalVetAppointment> vetAppointments;
            IVetAppointmentManager vetAppointmentManager = new VetAppointmentManager(_vetAppointmentAccessor, _vetAppointments);

            // Act
            vetAppointments = vetAppointmentManager.RetrieveAppointmentsByDateTime(DateTime.Parse("3/1/2020 2:00PM"));

            // Assert
            Assert.AreEqual(1, vetAppointments.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Tests retrieving vet appointment records by follow up date
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestVetAppointmentsManagerRetrieveAppointmentsByAppointmentFollowUpDate()
        {
            // Arrange
            List<AnimalVetAppointment> vetAppointments;
            IVetAppointmentManager vetAppointmentManager = new VetAppointmentManager(_vetAppointmentAccessor, _vetAppointments);

            // Act
            vetAppointments = vetAppointmentManager
                .RetrieveAppointmentsByFollowUpDate(DateTime.Parse("2/20/2021 2:00PM"));

            // Assert
            Assert.AreEqual(1, vetAppointments.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Tests retrieving vet appointment records by vet name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestVetAppointmentsManagerRetrieveAppointmentsByVetName()
        {
            // Arrange
            List<AnimalVetAppointment> vetAppointments;
            IVetAppointmentManager vetAppointmentManager = new VetAppointmentManager(_vetAppointmentAccessor, _vetAppointments);

            // Act
            vetAppointments = vetAppointmentManager.RetrieveAppointmentsByVetName("hstrth");

            // Assert
            Assert.AreEqual(1, vetAppointments.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Tests adding new vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddAnimalVetAppointmentRecord()
        {
            // Arrange
            bool result = false;
            IVetAppointmentManager vetAppointmentManager = new VetAppointmentManager(_vetAppointmentAccessor);
            AnimalVetAppointment animalVetAppointment = new AnimalVetAppointment()
            {
                AnimalID = 4,
                VetAppointmentID = 4,
                AnimalName = "Test",
                UserID = 4,
                FollowUpDateTime = null,
                AppointmentDateTime = DateTime.Now,
                ClinicAddress = "Test",
                VetName = "Test",
                AppointmentDescription = "Test"
            };

            // Act
            result = vetAppointmentManager.AddAnimalVetAppointmentRecord(animalVetAppointment);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver:
        /// 
        /// Tests updating an existing vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestUpdateAnimalVetAppointmentRecord()
        {
            // Arrange
            bool result = false;
            IVetAppointmentManager vetAppointmentManager = new VetAppointmentManager(_vetAppointmentAccessor);
            AnimalVetAppointment oldRecord = new AnimalVetAppointment()
            {
                VetAppointmentID = 1,
                AnimalID = 1,
                AnimalName = "qwerty",
                UserID = 1,
                AppointmentDateTime = DateTime.Now,
                AppointmentDescription = "asdf",
                ClinicAddress = "1234 asdf",
                VetName = "awerga",
                FollowUpDateTime = null,
                Active = true
            };
            AnimalVetAppointment newRecord = new AnimalVetAppointment()
            {
                VetAppointmentID = 1,
                AnimalID = 1,
                AnimalName = "qwerty",
                UserID = 3,
                AppointmentDateTime = DateTime.Now,
                AppointmentDescription = "awefuhioawefouh",
                ClinicAddress = "1234 test",
                VetName = "awerga",
                FollowUpDateTime = DateTime.Now,
                Active = true
            };

            // Act
            vetAppointmentManager.AddAnimalVetAppointmentRecord(oldRecord);
            result = vetAppointmentManager.EditAnimalVetAppointmentRecord(oldRecord, newRecord);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver:
        /// 
        /// Tests updating a record that doesn't exist.
        /// Result should be false
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestUpdateNonExistantVetApppointmentRecord()
        {
            // Arrange
            bool result = false;
            IVetAppointmentManager vetAppointmentManager = new VetAppointmentManager(_vetAppointmentAccessor);
            AnimalVetAppointment oldRecord = new AnimalVetAppointment()
            {
                VetAppointmentID = 1,
                AnimalID = 1,
                AnimalName = "qwerty",
                UserID = 1,
                AppointmentDateTime = DateTime.Now,
                AppointmentDescription = "asdf",
                ClinicAddress = "1234 asdf",
                VetName = "awerga",
                FollowUpDateTime = null,
                Active = true
            };
            AnimalVetAppointment newRecord = new AnimalVetAppointment()
            {
                VetAppointmentID = 1,
                AnimalID = 1,
                AnimalName = "qwerty",
                UserID = 3,
                AppointmentDateTime = DateTime.Now,
                AppointmentDescription = "awefuhioawefouh",
                ClinicAddress = "1234 test",
                VetName = "awerga",
                FollowUpDateTime = DateTime.Now,
                Active = true
            };

            // Act
            result = vetAppointmentManager.EditAnimalVetAppointmentRecord(oldRecord, newRecord);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Tests retrieving animal vet appointments by
        /// a partially supplied animal name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAnimalAppointmentsByPartialAninmalName()
        {
            // Arrange
            List<AnimalVetAppointment> vetAppointments;
            IVetAppointmentManager vetAppointmentManager = new VetAppointmentManager(_vetAppointmentAccessor, _vetAppointments);

            // Act
            vetAppointments = vetAppointmentManager.RetrieveAppointmentsByPartialAnimalName("qwe");

            // Assert
            Assert.AreEqual(1, vetAppointments.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/27/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Tests deleting a valid appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeletingValidAppointmentRecord()
        {
            // Arrange
            bool result = false;
            IVetAppointmentManager manager =
                new VetAppointmentManager(_vetAppointmentAccessor);
            AnimalVetAppointment vetAppointment = new AnimalVetAppointment()
            {
                VetAppointmentID = 1,
                AnimalID = 1,
                UserID = 10000,
                AppointmentDateTime = DateTime.Now,
                AppointmentDescription = "test",
                ClinicAddress = "test",
                VetName = "test"
            };

            // Act
            manager.AddAnimalVetAppointmentRecord(vetAppointment);
            result = manager.RemoveAnimalVetAppointment(vetAppointment);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/27/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Tests deleting an invalid appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeletingInValidAppointmentRecord()
        {
            // Arrange
            bool result = false;
            IVetAppointmentManager manager =
                new VetAppointmentManager(_vetAppointmentAccessor);
            AnimalVetAppointment vetAppointment = new AnimalVetAppointment()
            {
                VetAppointmentID = 1,
                AnimalID = 1,
                UserID = 10000,
                AppointmentDateTime = DateTime.Now,
                AppointmentDescription = "test",
                ClinicAddress = "test",
                VetName = "test"
            };

            // Act
            result = manager.RemoveAnimalVetAppointment(vetAppointment);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/28/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Tests selecting vet records by active status
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestSelectVetAppointmentsByActive()
        {
            // Arrange
            List<AnimalVetAppointment> activeList;
            List<AnimalVetAppointment> inactiveList;
            IVetAppointmentManager manager =
                new VetAppointmentManager(_vetAppointmentAccessor);

            // Act
            activeList = manager.RetrieveVetAppointmentsByActive(true);
            inactiveList = manager.RetrieveVetAppointmentsByActive(false);

            // Assert
            Assert.AreEqual(2, activeList.Count);
            Assert.AreEqual(1, inactiveList.Count);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/28/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Tests deactivating record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeactivatingRecord()
        {
            // Arrange
            bool result = false;
            IVetAppointmentManager manager =
                new VetAppointmentManager(_vetAppointmentAccessor);
            AnimalVetAppointment vetAppointment = new AnimalVetAppointment()
            {
                VetAppointmentID = 1,
                Active = true
            };

            // Act
            result = manager.DeactivateVetAppointment(vetAppointment);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/28/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Tests activating a vet record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestActivatingRecord()
        {
            // Arrange
            bool result = false;
            IVetAppointmentManager manager =
                new VetAppointmentManager(_vetAppointmentAccessor);
            AnimalVetAppointment vetAppointment = new AnimalVetAppointment()
            {
                VetAppointmentID = 1,
                Active = false
            };

            // Act
            result = manager.ActivateVetAppointment(vetAppointment);

            // Assert
            Assert.IsTrue(result);
        }
    }
}

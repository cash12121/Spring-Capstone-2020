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
    /// Created: 2/21/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver:
    /// 
    /// Test class for the Animal Handling Notes features
    /// </summary>
    [TestClass]
    public class AnimalHandlingManagerTests
    {
        private IAnimalHandlingAccessor _handlingAccessor;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Initialize tests
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _handlingAccessor = new FakeAnimalHandlingAccessor();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver:  Chuck Baxter, 2/21/2020
        /// 
        /// Get handling notes by ID good value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestGetHandlingNotesByIDGoodValue()
        {
            // Arrange
            List<AnimalHandlingNotes> handlingNotes = new List<AnimalHandlingNotes>();
            IAnimalHandlingManager handlingManager = new AnimalHandlingManager(_handlingAccessor);

            // Act
            handlingNotes.Add(handlingManager.GetHandlingNotesByID(100000));

            // Assert
            Assert.AreEqual(1, handlingNotes.Count);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get handling notes by ID bad value
        /// </summary>
        //// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 2/28/2020
        /// Update: Removed the assert statement, since it's expecting an exception anyway
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestGetHandlingNotesByIDBadValue()
        {

            // Arrange
            List<AnimalHandlingNotes> handlingNotes = new List<AnimalHandlingNotes>();
            IAnimalHandlingManager handlingManager = new AnimalHandlingManager(_handlingAccessor);

            // Act
            handlingNotes.Add(handlingManager.GetHandlingNotesByID(0));

            // Assert
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get handling notes details by animal ID good value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestGetHandlingNotesByAnimalIDGoodValue()
        {
            // Arrange
            List<AnimalHandlingNotes> handlingNotes;
            IAnimalHandlingManager handlingManager = new AnimalHandlingManager(_handlingAccessor);

            // Act
            handlingNotes = handlingManager.GetAllHandlingNotesByAnimalID(100000);

            // Assert
            Assert.AreEqual(1, handlingNotes.Count);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get animal handling notes details by animal ID bad value 
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 2/28/2020
        /// Update: Removed the assert statement, since it's expecting an exception anyway
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestGetHandlingNotesByAnimalIDBadValue()
        {
            // Arrange
            List<AnimalHandlingNotes> handlingNotes;
            IAnimalHandlingManager handlingManager = new AnimalHandlingManager(_handlingAccessor);

            // Act
            handlingNotes = handlingManager.GetAllHandlingNotesByAnimalID(0);

            // Assert
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/28/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver: 
        /// 
        /// Test for adding an animal handling notes record. Successful add. 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddAnimalHandlingNotesSuccess()
        {
            // Arrange
            IAnimalHandlingManager handlingManager = new AnimalHandlingManager(_handlingAccessor);
            const bool expectedResult = true;
            AnimalHandlingNotes notes = new AnimalHandlingNotes()
            {
                HandlingNotesID = 1,
                AnimalID = 1000000,
                UserID = 100000,
                HandlingNotes = "Notes notes notes notes",
                TemperamentWarning = "Very mean. No touch.",
                UpdateDate = DateTime.Now
            };

            // Act
            bool actualResult = handlingManager.AddAnimalHandlingNotes(notes);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/28/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver: 
        /// 
        /// Test for adding an animal handling notes record. 
        /// Will simulate a failure via an intentionally triggered error
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestAddAnimalHandlingNotesFail()
        {

            // Arrange
            IAnimalHandlingManager handlingManager = new AnimalHandlingManager(_handlingAccessor);
            AnimalHandlingNotes notes = new AnimalHandlingNotes()
            {
                HandlingNotesID = 0,
                AnimalID = 1000000,
                UserID = 100000,
                HandlingNotes = "Notes notes notes notes",
                TemperamentWarning = "Very mean. No touch.",
                UpdateDate = DateTime.Now
            };

            // Act
            bool actualResult = handlingManager.AddAnimalHandlingNotes(notes);

            //Assert
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/4/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver: 
        /// 
        /// Test for updating an animal handling notes record. 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestUpdateHandlingRecordGoodValue()
        {

            // Arrange
            IAnimalHandlingManager handlingManager = new AnimalHandlingManager(_handlingAccessor);
            AnimalHandlingNotes oldNotes = new AnimalHandlingNotes()
            {
                HandlingNotesID = 100000,
                UserID = 100000,
                AnimalID = 100000,
                HandlingNotes = "notes",
                TemperamentWarning = "calm",
                UpdateDate = DateTime.Now
            };

            AnimalHandlingNotes newNotes = new AnimalHandlingNotes()
            {
                HandlingNotesID = 100000,
                UserID = 100000,
                AnimalID = 100000,
                HandlingNotes = "new notes",
                TemperamentWarning = "happy",
                UpdateDate = DateTime.Now
            };

            bool expectedResult = true;


            // Act
            bool actualResult = handlingManager.EditAnimalHandlingNotes(oldNotes, newNotes);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/4/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver: 
        /// 
        /// Test for updating an animal handling notes record. 
        /// Will simulate a failure via an intentionally triggered error
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateHandlingRecordBadValue()
        {

            // Arrange
            IAnimalHandlingManager handlingManager = new AnimalHandlingManager(_handlingAccessor);
            AnimalHandlingNotes oldNotes = new AnimalHandlingNotes()
            {
                HandlingNotesID = 0,
                UserID = 100000,
                AnimalID = 100000,
                HandlingNotes = "notes",
                TemperamentWarning = "calm",
                UpdateDate = DateTime.Now
            };

            AnimalHandlingNotes newNotes = new AnimalHandlingNotes()
            {
                HandlingNotesID = 0,
                UserID = 100000,
                AnimalID = 100000,
                HandlingNotes = "new notes",
                TemperamentWarning = "happy",
                UpdateDate = DateTime.Now
            };

            // Act
            bool actualResult = handlingManager.EditAnimalHandlingNotes(oldNotes, newNotes);

            //Assert
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Test Cleanup. You know what this does
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestCleanup]
        public void TestTeardown()
        {
            _handlingAccessor = null;
        }
    }
}

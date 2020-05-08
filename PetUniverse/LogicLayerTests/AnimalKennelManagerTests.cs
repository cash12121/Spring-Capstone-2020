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
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/14/2020
    /// Approver: Chuck Baxter, 2/14/2020
    /// 
    /// Unit tests for the kennel related methods
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    [TestClass]
    public class AnimalKennelManagerTests
    {
        private IAnimalKennelAccessor _kennelAccessor;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Constructor that assigns the fake accessor class to be the passed kennel accessor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalKennelManagerTests()
        {
            _kennelAccessor = new FakeAnimalKennelAccessor();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Test for adding a kennel record. Good value.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddKennelRecordSuccess()
        {
            //Arrange
            IAnimalKennelManager kennelManager = new AnimalKennelManager(_kennelAccessor);
            const bool expectedResult = true;
            AnimalKennel kennel = new AnimalKennel() { AnimalID = 1, AnimalKennelID = 1, UserID = 1, AnimalKennelInfo = "Info", AnimalKennelDateIn = DateTime.Now };

            //Act
            bool actualResult = kennelManager.AddKennelRecord(kennel);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Test for adding a kennel record. Will simulate a failure via an error
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestAddKennelRecordFail()
        {
            //Arrange
            IAnimalKennelManager kennelManager = new AnimalKennelManager(_kennelAccessor);
            AnimalKennel kennel = new AnimalKennel() { AnimalID = 1, AnimalKennelID = 0, UserID = 1, AnimalKennelInfo = "Info", AnimalKennelDateIn = DateTime.Now };
            //Act
            kennelManager.AddKennelRecord(kennel);
            //Assert
        }

        /// <summary>
        /// 
        /// Creator: Ben Hanna
        /// Created: 3/12/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Test for getting a list of kennel record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestGetKennelRecords()
        {
            //Arrange
            List<AnimalKennel> kennelRecords = new List<AnimalKennel>();
            IAnimalKennelManager kennelManager = new AnimalKennelManager(_kennelAccessor);

            //Act
            kennelRecords = kennelManager.GetAllAnimalKennels();

            //Assert
            Assert.AreEqual(2, kennelRecords.Count);
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/17/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
        /// 
        /// Test for updating a kennel record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestUpdateKennelRecordGoodValue()
        {
            //Arrange
            IAnimalKennelManager kennelManager = new AnimalKennelManager(_kennelAccessor);
            AnimalKennel oldKennel = new AnimalKennel()
            {
                AnimalKennelID = 1,
                AnimalID = 1,
                UserID = 1,
                AnimalKennelInfo = "info info info",
                AnimalKennelDateIn = new DateTime(2019, 5, 24),
                AnimalKennelDateOut = new DateTime(2020, 2, 24)
            };

            AnimalKennel newKennel = new AnimalKennel()
            {
                AnimalKennelID = 1,
                AnimalID = 1,
                UserID = 1,
                AnimalKennelInfo = "new new new new",
                AnimalKennelDateIn = new DateTime(2019, 5, 24),
                AnimalKennelDateOut = new DateTime(2020, 2, 24)
            };

            bool expectedResult = true;

            //Act
            bool actualResult = kennelManager.EditKennelRecord(oldKennel, newKennel);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// 
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/17/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
        /// 
        /// Test for updating a kennel record. Simulates Error
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateKennelRecordBadValue()
        {
            // Arrange
            IAnimalKennelManager kennelManager = new AnimalKennelManager(_kennelAccessor);
            AnimalKennel oldKennel = new AnimalKennel()
            {
                AnimalKennelID = 0,
                AnimalID = 1,
                UserID = 1,
                AnimalKennelInfo = "info info",
                AnimalKennelDateIn = new DateTime(2019, 5, 24),
                AnimalKennelDateOut = new DateTime(2020, 2, 24)
            };

            AnimalKennel newKennel = new AnimalKennel()
            {
                AnimalKennelID = 0,
                AnimalID = 1,
                UserID = 1,
                AnimalKennelInfo = "new new new new",
                AnimalKennelDateIn = new DateTime(2019, 5, 24),
                AnimalKennelDateOut = new DateTime(2020, 2, 24)
            };

            //Act
            bool actualResult = kennelManager.EditKennelRecord(oldKennel, newKennel);

        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/17/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
        /// 
        /// Test for adding a date out value to the record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddDateOut()
        {
            // arrange
            IAnimalKennelManager kennelManager = new AnimalKennelManager(_kennelAccessor);

            AnimalKennel kennel = new AnimalKennel()
            {
                AnimalKennelID = 2,
                AnimalID = 1,
                UserID = 1,
                AnimalKennelInfo = "info info info",
                AnimalKennelDateIn = new DateTime(2020, 2, 25)
            };

            bool expectedResult = true;

            // act
            kennel.AnimalKennelDateOut = DateTime.Now;

            bool actualResult = kennelManager.SetDateOut(kennel);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Teardown method. You know what this is.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestCleanup]
        public void TestTeardown()
        {
            _kennelAccessor = null;
        }
    }
}

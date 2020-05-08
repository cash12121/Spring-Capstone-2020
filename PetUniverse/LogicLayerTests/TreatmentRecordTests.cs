using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessInterfaces;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayerInterfaces;
using LogicLayer;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Zoey McDonald
    /// Created: 3/2/2020
    /// Approver: Timothy Lickteig
    /// 
    /// Tests for the logic layer methods for treatment records.
    /// </summary>
    [TestClass]
    public class TreatmentRecordTests
    {
        private ITreatmentRecordAccessor _treatmentRecordAccessor;

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Passing in the fake data accessor.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _treatmentRecordAccessor = new FakeTreatmentRecordAccessor();
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Test for adding a new treatment record to the database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public TreatmentRecordTests()
        {
            //
            // TODO: Add constructor logic here
            //
            _treatmentRecordAccessor = new FakeTreatmentRecordAccessor();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Test for adding a new treatment record to the database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestAddNewTreatmentRecord()
        {
            // arrange
            bool isValidTreatmentRecord = false;
            ITreatmentRecordManager treatmentRecordManager = new TreatmentRecordManager(_treatmentRecordAccessor);

            // act
            TreatmentRecord treatmentRecord1 = new TreatmentRecord()
            {
                TreatmentRecordID = 5,
                VetID = "vet120",
                AnimalID = 6,
                FormName = "Form Name",
                TreatmentDate = DateTime.Now.Date,
                TreatmentDescription = "This is a treatment description.",
                Notes = "These are notes. Blah Blah.",
                Reason = "Reason",
                Urgency = 2
            };
            isValidTreatmentRecord = treatmentRecordManager.AddNewTreatmentRecord(treatmentRecord1);

            // assert
            Assert.IsTrue(isValidTreatmentRecord);
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// Test for selecting treatment records to the database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestSelectTreatmentRecords()
        {
            // arrange
            List<TreatmentRecord> testTreatmentRecords;
            ITreatmentRecordManager treatmentRecordManager = new TreatmentRecordManager(_treatmentRecordAccessor);

            // act
            testTreatmentRecords = treatmentRecordManager.RetrieveTreatmentRecords();

            // assert
            Assert.IsNotNull(testTreatmentRecords);
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Test for deleting a treatment record to the database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>        
        [TestMethod]
        public void TestDeleteTreatmentRecord()
        {
            // arrange
            ITreatmentRecordManager treatmentRecordManager = new TreatmentRecordManager(_treatmentRecordAccessor);

            // act
            int rows = treatmentRecordManager.DeleteTreatmentRecord(100000);


            // assert
            Assert.AreEqual(1, rows);

        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// Test for editing an existing treatment record to the database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestEditTreatmentRecord()
        {
            // Arrange
            ITreatmentRecordManager treatmentRecordManager = new TreatmentRecordManager(_treatmentRecordAccessor);
            int rows = 0;
            // Act

            rows = treatmentRecordManager.EditTreatmentRecord(
                new TreatmentRecord()
                {
                    TreatmentRecordID = 1
                },
                new TreatmentRecord()
                {
                    TreatmentRecordID = 9,
                    VetID = "vet123",
                    AnimalID = 8,
                    FormName = "Form Name",
                    TreatmentDate = DateTime.Now.Date,
                    TreatmentDescription = "This is an edit treatment description.",
                    Notes = "These are notes. Blah Blah.",
                    Reason = "Reason",
                    Urgency = 6
                });

            // Assert
            Assert.AreEqual(1, rows);
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/4/2020
        /// Approver: Tim Lickteig
        /// 
        /// Test clean up
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _treatmentRecordAccessor = null;
        }
    }
}

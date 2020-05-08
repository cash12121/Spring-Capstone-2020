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
    /// Creator: Chase Schulte
    /// Created: 02/05/2020
    /// Approver: Kaleb Bachert
    ///
    /// Test ERole Objects from "FakeERoleAccessor"
    /// </summary>
    [TestClass]
    public class ERoleManagerTests
    {
        private IERoleAccessor _eRoleAccessor;
        public ERoleManagerTests()
        {
            _eRoleAccessor = new FakeERoleAccessor();
        }


        private TestContext testContextInstance;
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/05/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>

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
        /// Creator: Chase 
        /// 
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Insert ERole from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestInsertSuccess()
        {
            //Arrange
            ERole eRole = new ERole() { ERoleID = "ANewEmployee", DepartmentID = "A", Description = "", EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            bool expectResult = true;
            //Act
            bool actualResult = _eRoleManager.AddERole(eRole);
            //Assert
            Assert.AreEqual(actualResult, expectResult);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Insert with null ERole from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestInsertSuccessWithNullDescription()
        {
            //Arrange
            ERole eRole = new ERole() { ERoleID = "ANewEmployee", DepartmentID = "A", Description = null, EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            bool expectResult = true;
            //Act
            bool actualResult = _eRoleManager.AddERole(eRole);
            //Assert
            Assert.AreEqual(actualResult, expectResult);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Insert same ERole from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestSameERoleID()
        {
            //Arrange
            ERole eRole = new ERole() { ERoleID = "Manager", DepartmentID = "A", Description = "", EActive = false };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.AddERole(eRole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Insert RoleID over character limit from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestERoleIDOverCharacterLimit()
        {
            //Arrange
            ERole eRole = new ERole() { ERoleID = "123456789112345678911234567891123456789112345678910", DepartmentID = "A", Description = "", EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.AddERole(eRole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Insert Dept ID over char limit from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDepartmentIDOverCharacterLimit()
        {
            //Arrange
            ERole eRole = new ERole() { ERoleID = "AERoleID", DepartmentID = "123456789112345678911234567891123456789112345678910", Description = "", EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.AddERole(eRole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Insert ERole description over limit from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDescriptionOverCharacterLimit()
        {
            //Arrange
            ERole eRole = new ERole() { ERoleID = "AERoleID", DepartmentID = "A", Description = "123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678910", EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.AddERole(eRole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Insert ERole role Id empty from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestERoleIDEmpty()
        {
            //Arrange
            ERole eRole = new ERole() { ERoleID = "", DepartmentID = "A", Description = "123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678910", EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.AddERole(eRole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Insert ERole EDepartment ID Empty from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestEDepartmentIDEmpty()
        {
            //Arrange
            ERole eRole = new ERole() { ERoleID = "AERoleID", DepartmentID = "", Description = "123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678910", EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.AddERole(eRole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Insert ERole roleID null from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestERoleIDNull()
        {
            //Arrange
            ERole eRole = new ERole() { ERoleID = null, DepartmentID = "A", Description = "123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678910", EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.AddERole(eRole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Insert ERole Dept ID null from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestEDepartmentIDNull()
        {
            //Arrange
            ERole eRole = new ERole() { ERoleID = "AERoleID", DepartmentID = null, Description = "123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678910", EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.AddERole(eRole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Select All ERole from "FakeERoleAccessor"
        /// Do this via "Assert.IsNotNull". Check to makes sure "actualResult" contatins a collection of eRoles
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllERolesSuccess()
        {
            //Arrange
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            List<ERole> actualResult = _eRoleManager.RetrieveAllERoles();
            //Assert
            Assert.IsNotNull(actualResult);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Update Success from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestUpdateERoleSuccess()
        {
            //Arrange
            ERole oldERole = new ERole() { ERoleID = "Manager", DepartmentID = "A", Description = "", EActive = false };
            ERole newERole = new ERole() { ERoleID = "Manager", DepartmentID = "B", Description = "ANewDesc", EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            bool expectedResults = true;
            bool actualResult = _eRoleManager.EditERole(oldERole, newERole);
            //Assert
            Assert.AreEqual(actualResult, expectedResults);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Update With no Changes from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestUpdateERoleNoChanges()
        {
            //Arrange
            ERole oldERole = new ERole() { ERoleID = "Manager", DepartmentID = "A", Description = "", EActive = false };
            ERole newERole = new ERole() { ERoleID = "Manager", DepartmentID = "A", Description = "", EActive = false };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            bool expectedResults = true;
            bool actualResult = _eRoleManager.EditERole(oldERole, newERole);
            //Assert
            Assert.AreEqual(actualResult, expectedResults);

        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Update Null Descritpion from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestUpdateERoleNullDescription()
        {
            //Arrange
            ERole oldERole = new ERole() { ERoleID = "Manager", DepartmentID = "A", Description = "", EActive = false };
            ERole newERole = new ERole() { ERoleID = "Manager", DepartmentID = "A", Description = null, EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            bool expectedResults = true;
            bool actualResult = _eRoleManager.EditERole(oldERole, newERole);
            //Assert
            Assert.AreEqual(actualResult, expectedResults);

        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Update Old ERole Incorrect from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateERoleNullOldERoleIncorrect()
        {
            //Arrange
            ERole oldERole = new ERole() { ERoleID = "AManager", DepartmentID = "A", Description = "", EActive = false };
            ERole newERole = new ERole() { ERoleID = "Manager", DepartmentID = "A", Description = "", EActive = false };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.EditERole(oldERole, newERole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Update Dept ID over char limit from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateDepartmentIDOverCharacterLimit()
        {
            //Arrange
            ERole oldERole = new ERole() { ERoleID = "Manager", DepartmentID = "A", Description = "", EActive = false };
            ERole newERole = new ERole() { ERoleID = "AERoleID", DepartmentID = "123456789112345678911234567891123456789112345678910", Description = "", EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.EditERole(oldERole, newERole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: Jordan Lindo
        /// 
        /// Test Update ERole description over limit from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateDescriptionOverCharacterLimit()
        {
            //Arrange
            ERole oldERole = new ERole() { ERoleID = "Manager", DepartmentID = "A", Description = "", EActive = false };
            ERole newERole = new ERole() { ERoleID = "AERoleID", DepartmentID = "A", Description = "123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678910", EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.EditERole(oldERole, newERole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Update Null Old ERole from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateERoleNullOldERole()
        {
            //Arrange
            ERole oldERole = null;
            ERole newERole = new ERole() { ERoleID = "Manager", DepartmentID = "A", Description = "", EActive = false };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.EditERole(oldERole, newERole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Update Null deptID from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateERoleNullNewDeptID()
        {
            //Arrange
            ERole oldERole = new ERole() { ERoleID = "Manager", DepartmentID = "A", Description = "", EActive = false };
            ERole newERole = new ERole() { ERoleID = "Manager", DepartmentID = null, Description = "", EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.EditERole(oldERole, newERole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Update New ERole Null from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateERoleNullNewERole()
        {
            //Arrange
            ERole oldERole = null;
            ERole newERole = new ERole() { ERoleID = "Manager", DepartmentID = "A", Description = "", EActive = false };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.EditERole(oldERole, newERole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Update Change PK from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateERoleChangedPK()
        {
            //Arrange
            ERole oldERole = new ERole() { ERoleID = "Manager", DepartmentID = "A", Description = "", EActive = false };
            ERole newERole = new ERole() { ERoleID = "AManager", DepartmentID = "A", Description = "", EActive = true };
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.EditERole(oldERole, newERole);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Activate Success from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestActivateSuccess()
        {
            //Arrange
            string eRoleID = "Manager";
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            bool expectResult = true;
            //Act
            bool actualResult = _eRoleManager.ActivateERole(eRoleID);
            //Assert
            Assert.AreEqual(actualResult, expectResult);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Activate Already Active ERole from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestActivateAlreadyActivatedERoleID()
        {
            //Arrange
            string eRoleID = "Scheduler";
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            bool expectResult = true;
            //Act
            bool actualResult = _eRoleManager.ActivateERole(eRoleID);
            //Assert
            Assert.AreEqual(actualResult, expectResult);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test NonActivate Success from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestActivateNonExistantERoleID()
        {
            //Arrange
            string eRoleID = "aERoleID";
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.ActivateERole(eRoleID);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Activate Empty ERoleID from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestActivateEmptyERoleID()
        {
            //Arrange
            string eRoleID = "";
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.ActivateERole(eRoleID);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Activate Null ERole ID from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestActivateNullERoleID()
        {
            //Arrange
            string eRoleID = null;
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.ActivateERole(eRoleID);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Deactivate Success from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestDeactivateSuccess()
        {
            //Arrange
            string eRoleID = "Scheduler";
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            bool expectResult = true;
            //Act
            bool actualResult = _eRoleManager.DeactivateERole(eRoleID);
            //Assert
            Assert.AreEqual(actualResult, expectResult);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Deactivate Already Deactivated ERole from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestDeactivateAlreadyDeactivatedERoleID()
        {
            //Arrange
            string eRoleID = "Manager";
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            bool expectResult = true;
            //Act
            bool actualResult = _eRoleManager.DeactivateERole(eRoleID);
            //Assert
            Assert.AreEqual(actualResult, expectResult);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Deactivate nonExistant ERole from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeactivateNonExistantERoleID()
        {
            //Arrange
            string eRoleID = "aERoleID";
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.DeactivateERole(eRoleID);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Deactivate Empty ERole ID from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeactivateEmptyERoleID()
        {
            //Arrange
            string eRoleID = "";
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.DeactivateERole(eRoleID);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Deactivate Null ERole from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeactivateNullERoleID()
        {
            //Arrange
            string eRoleID = null;
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.DeactivateERole(eRoleID);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Delete Success from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestDeleteSuccess()
        {
            //Arrange
            string eRoleID = "Scheduler";
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            bool expectResult = true;
            //Act
            bool actualResult = _eRoleManager.DeleteERole(eRoleID);
            //Assert
            Assert.AreEqual(actualResult, expectResult);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Delete nonExistant ERole from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeleteNonExistantERoleID()
        {
            //Arrange
            string eRoleID = "aERoleID";
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.DeleteERole(eRoleID);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Delete Empty ERole ID from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeleteEmptyERoleID()
        {
            //Arrange
            string eRoleID = "";
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.DeleteERole(eRoleID);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test Delete Null ERole from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeleteNullERoleID()
        {
            //Arrange
            string eRoleID = null;
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            _eRoleManager.DeleteERole(eRoleID);
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Test seperate eRoles by active from "FakeERoleAccessor"
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestFindActiveERoles()
        {
            //Arrange
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            //Act
            List<ERole> activeERoles = _eRoleManager.RetrieveERolesByActive(true);
            List<ERole> inactiveERoles = _eRoleManager.RetrieveERolesByActive(false);
            //Assert
            Assert.AreNotEqual(activeERoles, inactiveERoles);
        }



        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a unit test for select roles by Department id.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void SelectERolesByDepartmentID()
        {
            IERoleManager _eRoleManager = new ERoleManager(_eRoleAccessor);
            string goodDepartmentID = "A";

            List<ERole> roles = _eRoleManager.RetrieveERolesByDepartmentID(goodDepartmentID);

            Assert.AreEqual(3, roles.Count);

        }


        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/07/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Clean up ERole Tests
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _eRoleAccessor = null;
        }
    }
}

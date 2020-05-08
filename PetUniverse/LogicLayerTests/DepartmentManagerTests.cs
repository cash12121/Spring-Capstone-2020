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
    /// Creator: Jordan Lindo
    /// Created: 2/6/2020
    /// Approver: Alex Diers
    /// 
    /// This is a unit test set for DepartmentManager.
    /// </summary>
    [TestClass]
    public class DepartmentManagerTests
    {
        private IDepartmentAccessor _departmentAccessor;
        private IDepartmentAccessor _brokenDepartmentAccessor;


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test constructor DepartmentManager.
        /// </summary>
        /// <remarks>
        /// Updater: Jordan Lindo
        /// Updated: Added failed connection fake.
        /// Approver: NA
        /// 
        /// </remarks>
        public DepartmentManagerTests()
        {
            _departmentAccessor = new FakeDepartmentAccessor();
            _brokenDepartmentAccessor = new FakeDepartmentAccessorFailedConnection();
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for retrieving all departments.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void RetrieveAllDepartmentsTest()
        {
            List<Department> departments;
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            departments = departmentManager.RetrieveAllDepartments();

            Assert.AreEqual(1, departments.Count);
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for retrieve by id.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void RetrieveDepartmentById()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            Department department = new Department()
            {
                DepartmentID = "Fake Department",
                Description = "Fake Description"
            };
            Department anotherDepartment;


            anotherDepartment = departmentManager.RetrieveDepartmentByID(department.DepartmentID);

            Assert.AreEqual(department.DepartmentID, anotherDepartment.DepartmentID);

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for good values insert.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddDepartmentTestGood()
        {
            string goodDepartmentId = "Good departmentId Test";
            string goodDescription = "Good description Test";
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            bool result = departmentManager.AddDepartment(goodDepartmentId, goodDescription);

            Assert.AreEqual(true, result);

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for null id insert.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddDepartmentTestBadNullId()
        {
            string badDepartmentId = null;
            string goodDescription = "Good description Test";
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            bool result = departmentManager.AddDepartment(badDepartmentId, goodDescription);

            Assert.AreEqual(false, result);

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for existing id insert.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddDepartmentTestBadRepeatId()
        {
            string badDepartmentId = "Fake Department";
            string goodDescription = "Good description Test";
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            bool result = departmentManager.AddDepartment(badDepartmentId, goodDescription);

            Assert.AreEqual(false, result);

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/16/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager too long ID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddDepartmentTestTooLongID()
        {
            string tooLong = "012345678910111213141516171819202122232425262728293031323334353637383940414243444546474849505152535455565758596061626364656667686970" +
                "012345678910111213141516171819202122232425262728293031323334353637383940414243444546474849505152535455565758596061626364656667686970" +
                "012345678910111213141516171819202122232425262728293031323334353637383940414243444546474849505152535455565758596061626364656667686970";
            string goodDescription = "Good description Test";
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            bool result = departmentManager.AddDepartment(tooLong, goodDescription);

            Assert.AreEqual(false, result);

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/6/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager just too long ID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddDepartmentTestTooLongIDEdge()
        {
            string tooLong = "111111111111111111111111111111111111111111111111111";
            string goodDescription = "Good description Test";
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            bool result = departmentManager.AddDepartment(tooLong, goodDescription);

            Assert.AreEqual(false, result);

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/16/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager just too long description.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddDepartmentTestTooLongDescription()
        {
            string tooLong = "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111" +
                "11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";
            string goodDepartmentId = "Good departmentId Test";
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            bool result = departmentManager.AddDepartment(goodDepartmentId, tooLong);

            Assert.AreEqual(false, result);

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/15/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager no match.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void UpdateDepartmentTestDepartmentNotFound()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            Department missingDepartment = new Department
            {
                DepartmentID = "Missing",
                Description = "None"
            };
            Department newDepartment = new Department
            {
                DepartmentID = "Missing",
                Description = "Other"
            };
            bool result = departmentManager.EditDepartment(missingDepartment, newDepartment);

            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/15/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager no match to original id by new.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void UpdateDepartmentTestNoMatchID()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            Department mismatchDepartment = new Department
            {
                DepartmentID = "firstDepartment",
                Description = "A Description"
            };
            Department otherDepartment = new Department
            {
                DepartmentID = "secondDepartment",
                Description = "A new Description"
            };

            bool result = departmentManager.EditDepartment(mismatchDepartment, otherDepartment);

            Assert.AreEqual(false, result);

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/15/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager no match to existing description.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void UpdateDepartmentTestNoMatchDescription()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            Department department = new Department
            {
                DepartmentID = "Fake Department",
                Description = "Flake Description"
            };
            Department anotherDepartment = new Department
            {
                DepartmentID = "Fake Department",
                Description = "Fake Description"
            };

            bool result = departmentManager.EditDepartment(department, anotherDepartment);
            Assert.AreEqual(false, result);

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/15/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager one char too long description.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void UpdateDepartmentTestTooLongDescription()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            Department department = new Department
            {
                DepartmentID = "Fake Department",
                Description = "Fake Description"
            };
            Department anotherDepartment = new Department
            {
                DepartmentID = "Fake Department",
                Description = "111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111" +
                "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111"
            };

            bool result = departmentManager.EditDepartment(department, anotherDepartment);
            Assert.AreEqual(false, result);

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/15/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager one char too long id.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void UpdateDepartmentTestTooLongID()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            Department department = new Department
            {
                DepartmentID = "Fake Department",
                Description = "Fake Description"
            };
            Department anotherDepartment = new Department
            {
                DepartmentID = "111111111111111111111111111111111111111111111111111",
                Description = "Fake Description"
            };

            bool result = departmentManager.EditDepartment(department, anotherDepartment);
            Assert.AreEqual(false, result);
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/29/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager good deactivate.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void EditDepartmentActiveGoodDeactivate()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            string goodDepartmentID = "Fake Department";
            bool active = false;
            bool result = departmentManager.EditDepartmentActive(goodDepartmentID, active);

            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/29/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager good deactivate.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void EditDepartmentActiveBadDeactivate()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            string badDepartmentID = "Bad Fake Department";
            bool active = false;
            bool result = departmentManager.EditDepartmentActive(badDepartmentID, active);

            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/29/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager good reactivate.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void EditDepartmentActiveGoodActivate()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            string goodDepartmentID = "DeactivatedID1";
            bool active = true;
            bool result = departmentManager.EditDepartmentActive(goodDepartmentID, active);

            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/29/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager bad reactivate.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void EditDepartmentActiveBaddActivate()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            string badDepartmentID = "Not DeactivatedID1";
            bool active = true;
            bool result = departmentManager.EditDepartmentActive(badDepartmentID, active);

            Assert.AreEqual(false, result);
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/1/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for failed connection.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestFailedConnectionAddDepatrment()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_brokenDepartmentAccessor);
            string goodID = "Fake";
            string goodDescription = "Fake Description";


            departmentManager.AddDepartment(goodID, goodDescription);

        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/1/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for failed connection.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestFailedConnectionEditDepatrment()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_brokenDepartmentAccessor);
            string goodID = "Fake";
            string goodDescription = "Fake Description";
            string otherDescription = "Other Words";



            departmentManager.EditDepartment(
                new Department
                {
                    DepartmentID = goodID,
                    Description = goodDescription
                },
                new Department
                {
                    DepartmentID = goodID,
                    Description = otherDescription
                }
            );

        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/1/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for failed connection.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestFailedConnectionEditDepatrmentActive()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_brokenDepartmentAccessor);
            string goodID = "Fake";
            bool active = false;

            departmentManager.EditDepartmentActive(goodID, active);

        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/1/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for failed connection.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestFailedConnectionRetrieveAllDepartments()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_brokenDepartmentAccessor);


            departmentManager.RetrieveAllDepartments();

        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/1/2020
        /// Approver: Alex Diers
        /// 
        /// This is a unit test for failed connection.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestFailedConnectionRetrieveDepartmentByID()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_brokenDepartmentAccessor);
            string goodID = "Fake";

            departmentManager.RetrieveDepartmentByID(goodID);

        }




    }
}

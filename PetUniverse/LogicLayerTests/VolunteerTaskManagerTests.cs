using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{

    /// <summary>
    /// NAME: Ethan Holmes
    /// DATE: 2/6/2020
    /// APPROVER: Josh Jackson, Timothy Licktieg
    /// 
    /// This Logic Layer Test will test the inertion of the CreatVolunteerTask() data accessor class.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATE DATE: N/A
    /// CHANGE DESCRIPTION: N/A
    /// </remarks>
    [TestClass]
    public class VolunteerTaskManagerTests
    {
        private IVolunteerTaskAccessor _fakeVolunteerAccessor;

        public VolunteerTaskManagerTests()
        {

            _fakeVolunteerAccessor = new FakeVolunteerTaskAccessor();


        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// This Test Method will check whether the intended data is inserted.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>
        [TestMethod]
        public void TestInsertVolunteerTaskRecord()
        {

            int result = _fakeVolunteerAccessor.CreateVolunteerTask("Name_FAKE", "Task_FAKE", "Assign_FAKEEEEE", "FAKE DESC", DateTime.Parse("02/04/2020"));
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// This Test method will check if the inteded data is returned by the
        /// GetAllVolunteerTasks() method.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>
        [TestMethod]
        public void TestViewAllVolunteerTaskRecords()
        {
            List<VolunteerTaskVM> results = _fakeVolunteerAccessor.GetAllVolunteerTasks();



            Assert.AreEqual(1, results.Count);
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// This Test method will check if the inteded data is returned by the
        /// test updating task record by name.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>
        [TestMethod]
        public void TestUpdateVolunteerTaskByName()
        {
            int result = _fakeVolunteerAccessor.UpdateVolunteerTask("NEWNAME", "TaskType1", "Group1", DateTime.Parse("02/03/2020"), "Description");
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: 
        /// 
        /// This Test method will check if the inteded data is returned by the
        /// test updating task record by name.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>
        [TestMethod]
        public void TestDeleteVolunteerTaskByName()
        {
            int result = _fakeVolunteerAccessor.DeleteVolunteerTask("DELETE_THIS");
            Assert.AreEqual(1, result);
        }


    }
}

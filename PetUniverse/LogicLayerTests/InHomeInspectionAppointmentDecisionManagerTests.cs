using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Awaab Elamin, 2020/02/21
    /// This Class for testing all public methods in the In-home Inspection Appointment
    /// Decision Manager class.
    /// </summary>
    [TestClass]
    public class InHomeInspectionAppointmentDecisionManagerTests
    {
        private IInHomeInspectionAppointmentDecisionAccessor _fakeInHomeInspectionAppointmentDecisionAccessor;
        private InHomeInspectionAppointmentDecisionManager _inHomeInspectionAppointmentDecisionManager;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:Awaab Elamin, 2020/02/21
        /// This is the Setup for tests.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeInHomeInspectionAppointmentDecisionAccessor = new FakeInHomeInspectionAppointmentDecisionAccessor();
            _inHomeInspectionAppointmentDecisionManager = new InHomeInspectionAppointmentDecisionManager
                (_fakeInHomeInspectionAppointmentDecisionAccessor);
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/03/10
        /// Approved By: Awaab Elamin, 2020/03/13
        /// This is the test for Get Customer Email method By Adoption Application Id.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        [TestMethod]
        public void TestGetCustomerEmailByAdoptionApplicationId()
        {

            // arrange
            string expected = "Fake@fake.fake";
            string result = "";
            int adoptionApplicationId = 10000;

            // act
            result = _inHomeInspectionAppointmentDecisionManager
                .GetCustomerEmailByAdoptionApplicationID(adoptionApplicationId);

            //Assert
            Assert.AreEqual(expected, result);


        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 2020/02/19
        /// Approved By: Awaab Elamin, 2020/02/21
        /// This is the test for Update HomeInspector Decision's method.
        /// Fake data.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>

        [TestMethod]
        public void TestUpdateHomeInspectorDecision()
        {
            // Arrange
            int adoptionApplicationID = 10001;
            string InHomeInspectionDecision = "Facilitator";
            bool expected = true;
            // Act
            bool result = _inHomeInspectionAppointmentDecisionManager.UpdateHomeInspectorDecision(adoptionApplicationID, InHomeInspectionDecision);
            //Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 2020/02/19
        /// Approved By: Awaab Elamin, 2020/02/21
        /// This is the test for Submit Deny Decision method.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        [TestMethod]
        public void TestSubmitDenyDecision()
        {
            // Arrange
            int adoptionApplicationID = 10000;
            string Denydecision = "Deny";
            bool expected = true;
            //Act
            bool result = _inHomeInspectionAppointmentDecisionManager.UpdateHomeInspectorDecision(adoptionApplicationID, Denydecision);
            //Assert
            Assert.AreEqual(expected, result);
        }


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is the test for Select Select Adoption Applications Aappointments
        /// By Appointment Type method.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>

        [TestMethod]
        public void TestSelectAdoptionApplicationsAappointmentsByAppointmentType()
        {
            // Arrange
            List<HomeInspectorAdoptionAppointmentDecision> SelectAdoptionApplicationsAappointmentsByAppointmentType;
            //Act
            SelectAdoptionApplicationsAappointmentsByAppointmentType = _inHomeInspectionAppointmentDecisionManager.
                SelectAdoptionApplicationsAappointmentsByAppointmentType();
            // Assert
            Assert.AreEqual(2, SelectAdoptionApplicationsAappointmentsByAppointmentType.Count);
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is the test for Edit Appointment of Adoption Applications.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        [TestMethod]
        public void TestEditAppointment()
        {
            bool expected = true;
            bool result;
            HomeInspectorAdoptionAppointmentDecision oldHomeInspectorAdoptionAppointmentDecision
                = new HomeInspectorAdoptionAppointmentDecision()
                {
                    AppointmentID = 100001,
                    AdoptionApplicationID = 100001,
                    AppointmentTypeID = "facilitator",
                    DateTime = DateTime.Now,
                    Notes = "These are my notes",
                    Decision = "facilitator",
                    LocationID = 12033,
                    Active = true
                };
            HomeInspectorAdoptionAppointmentDecision newHomeInspectorAdoptionAppointmentDecision
                = new HomeInspectorAdoptionAppointmentDecision()
                {
                    AppointmentID = 100001,
                    AdoptionApplicationID = 100001,
                    AppointmentTypeID = "facilitator",
                    DateTime = DateTime.Now,
                    Notes = "These are my notes",
                    Decision = "Deny",
                    LocationID = 12033,
                    Active = true
                };
            result = _inHomeInspectionAppointmentDecisionManager.EditAppointment
                    (oldHomeInspectorAdoptionAppointmentDecision,
                    newHomeInspectorAdoptionAppointmentDecision);

            Assert.AreEqual(expected, result);

        }
    }
}

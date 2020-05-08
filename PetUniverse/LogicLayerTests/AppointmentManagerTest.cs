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
    /// Creator: Thomas Dupuy
    /// Created: 02/06/2020
    /// Approver: Awaab Elamin
    /// 
    /// This test class is used to test the data layer
    /// </summary>
    [TestClass]
    public class AppointmentManagerTest
    {
        private IAppointmentAccessor _appointmentAccessor;

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 02/06/2020
        /// Approver: Awaab Elamin
        /// 
        /// This method is a no-argument constructor
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        public AppointmentManagerTest()
        {
            _appointmentAccessor = new FakeAppointmentAccessor();
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 02/06/2020
        /// Approver: Awaab Elamin
        /// 
        /// This test method is used to test the data layer
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestAppointmentRetrieveAllActive()
        {
            // arrange
            List<AppointmentLocationVM> appointments;
            IAppointmentManager appointmentManager = new AppointmentManager(_appointmentAccessor);

            // act
            appointments = appointmentManager.RetrieveAllActiveAppointments();

            // assert
            Assert.AreEqual(3, appointments.Count);
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 4/12/2020
        /// Approver: Michael Thompson
        /// 
        /// This test method is used to test the data layer
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestAppointmentRetrieveById()
        {
            // arrange
            AppointmentLocationVM appointment;
            IAppointmentManager appointmentManager = new AppointmentManager(_appointmentAccessor);
            AppointmentLocationVM selectedAppointment = new AppointmentLocationVM()
            {
                AppointmentID = 1,
                AdoptionApplicationID = 1,
                AppointmentTypeID = "InHomeInspection",
                DateTime = new DateTime(2020, 5, 1, 12, 30, 00),
                Notes = "",
                Decicion = "Undecided",
                LocationID = 1,
                Active = true,
                LocationName = "Home",
                LocationAddress1 = "123 Real Ave",
                LocationCity = "Marion",
                LocationState = "IA",
                LocationZip = "52402"
            };

            // act
            appointment = appointmentManager.RetrieveAppointmentByID(selectedAppointment.AppointmentID);

            // assert
            // Assert.AreEqual(selectedAppointment, appointment);
            Assert.AreEqual(selectedAppointment.AppointmentID, appointment.AppointmentID);
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 4/12/2020
        /// Approver: Michael Thompson
        /// 
        /// This test method is used to test the data layer
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestAppointmentAdd()
        {
            // arrange
            int result = 0;
            AppointmentLocationVM appointment = new AppointmentLocationVM()
            {
                AppointmentID = 4,
                AdoptionApplicationID = 4,
                AppointmentTypeID = "InHomeInspection",
                DateTime = new DateTime(2020, 8, 3, 12, 00, 00),
                Notes = "",
                Decicion = "Undecided",
                LocationID = 1,
                LocationName = "New Home",
                LocationAddress1 = "123 Real Ave",
                LocationCity = "Marion",
                LocationState = "IA",
                LocationZip = "52402"
            };
            IAppointmentManager appointmentManager = new AppointmentManager(_appointmentAccessor);

            // act
            result = appointmentManager.AddAppointment(appointment);

            // assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 4/12/2020
        /// Approver: Michael Thompson
        /// 
        /// This test method is used to test the data layer
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestAppointmentRemove()
        {
            // arrange
            int result = 0;
            AppointmentLocationVM appointment = new AppointmentLocationVM()
            {
                AppointmentID = 1,
                AdoptionApplicationID = 1,
                AppointmentTypeID = "InHomeInspection",
                DateTime = new DateTime(2020, 5, 1, 12, 30, 00),
                Notes = "",
                Decicion = "Undecided",
                LocationID = 1,
                LocationName = "Home",
                LocationAddress1 = "123 Real Ave",
                LocationCity = "Marion",
                LocationState = "IA",
                LocationZip = "52402"
            };
            IAppointmentManager appointmentManager = new AppointmentManager(_appointmentAccessor);

            // act
            result = appointmentManager.RemoveAppointment(appointment);

            // assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 4/12/2020
        /// Approver: Michael Thompson
        /// 
        /// This test method is used to test the data layer
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestAppointmentEdit()
        {
            // arrange
            int result = 0;
            AppointmentLocationVM oldAppointment = new AppointmentLocationVM()
            {
                AppointmentID = 1,
                AdoptionApplicationID = 1,
                AppointmentTypeID = "InHomeInspection",
                DateTime = new DateTime(2020, 5, 1, 12, 30, 00),
                Notes = "",
                Decicion = "Undecided",
                LocationID = 1,
                LocationName = "Home",
                LocationAddress1 = "123 Real Ave",
                LocationCity = "Marion",
                LocationState = "IA",
                LocationZip = "52402"
            };
            AppointmentLocationVM newAppointment = new AppointmentLocationVM()
            {
                AppointmentID = 1,
                AdoptionApplicationID = 1,
                AppointmentTypeID = "InHomeInspection",
                DateTime = new DateTime(2020, 5, 12, 12, 30, 00),
                Notes = "",
                Decicion = "Undecided",
                LocationID = 1,
                LocationName = "Home",
                LocationAddress1 = "123 Real Ave",
                LocationCity = "Marion",
                LocationState = "IA",
                LocationZip = "52402"
            };
            IAppointmentManager appointmentManager = new AppointmentManager(_appointmentAccessor);

            // act
            result = appointmentManager.EditAppointment(oldAppointment, newAppointment);

            // assert
            Assert.AreEqual(1, result);
        }
    }
}

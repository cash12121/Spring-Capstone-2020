using System;
using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Timothy Lickteig        
    /// Created: 04/27/2020
    /// Approver: Zoey McDonald
    /// 
    /// Test class for the foster appointment manager
    /// </summary>
    [TestClass]
    public class FosterAppointmentManagerTests
    {
        private IFosterAppointmentAccessor accessor 
            = new FakeFosterAppointmentAccessor();
        private IFosterAppointmentManager manager;

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// Initialize the test
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        [TestInitialize]
        public void Setup()
        {
            manager = new FosterAppointmentManager(accessor);
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// test method for trying to schedule an appointment
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        [TestMethod]
        public void TestFosterAppointmentManagerScheduleAppointment()
        {
            bool success = false;
            FosterAppointment appointment = new FosterAppointment()
            {
                VolunteerID = 1000000,
                StartTime = new DateTime(1, 1, 1, 12, 0, 0),
                EndTime = new DateTime(1, 1, 1, 14, 0, 0),
            };

            success = manager.ScheduleFosterAppointment(appointment);

            Assert.AreEqual(true, success);
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// test method for trying to schedule an invalid appointment
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestFosterAppointmentManagerCannotScheduleInvalidAppointmentTime()
        {
            FosterAppointment appointment = new FosterAppointment()
            {
                VolunteerID = 1000000,
                StartTime = new DateTime(1, 1, 1, 14, 0, 0),
                EndTime = new DateTime(1, 1, 1, 12, 0, 0),
            };

            manager.ScheduleFosterAppointment(appointment);
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// test method for trying to view all appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        [TestMethod]
        public void TestFosterAppointmentManagerSeeAllFosterAppointments()
        {
            manager.ScheduleFosterAppointment(new FosterAppointment()
            {
                VolunteerID = 5
            });
            manager.ScheduleFosterAppointment(new FosterAppointment()
            {
                VolunteerID = 7
            });

            System.Collections.Generic.List<FosterAppointmentVM> appointments = manager.ViewFosterAppointments();

            Assert.IsNotNull(appointments.Find(x => x.VolunteerID == 5));
            Assert.IsNotNull(appointments.Find(x => x.VolunteerID == 7));
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// test method for trying to update an appointment
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        [TestMethod]
        public void TestFosterAppointmentManagerUpdateFosterAppointment()
        {
            FosterAppointment oldAppt = new FosterAppointment()
            {
                FosterAppointmentID = 27,
                VolunteerID = 1
            };
            FosterAppointment newAppt = new FosterAppointment()
            {
                FosterAppointmentID = 27,
                VolunteerID = 2
            };

            manager.ScheduleFosterAppointment(oldAppt);
            bool result = manager.UpdateFosterAppointment(oldAppt, newAppt);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// test method for trying to delete an appointment
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        [TestMethod]
        public void TestFosterAppointmentManagerCancelAppointment()
        {
            manager.ScheduleFosterAppointment(new FosterAppointment()
            {
                FosterAppointmentID = 25
            });

            bool result = manager.CancelFosterAppointment(25);

            Assert.IsTrue(result);
            Assert.IsNull(manager.ViewFosterAppointments()
                .Find(x => x.FosterAppointmentID == 25));
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// test method for trying to delete a nonexisting appointment
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        [TestMethod]
        public void TestFosterAppointmentManagerCantCancelNonExistingAppointment()
        {
            bool result = manager.CancelFosterAppointment(Int32.MinValue);

            Assert.IsFalse(result);
        }
    }
}

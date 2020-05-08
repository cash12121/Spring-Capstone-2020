using DataAccessFakes;
using DataAccessInterfaces;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{

    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/18/2020
    /// CHECKED BY: 
    /// 
    /// Test class for Appointment type manager methods
    /// </summary>
    [TestClass]
    public class AppointmentTypeManagerTests
    {
        IAppointmentTypeAccessor _fakeAppointmentTypeAccessor;

        public AppointmentTypeManagerTests()
        {
            _fakeAppointmentTypeAccessor = new FakeAppointmentTypeAccessor();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/18/2020
        /// CHECKED BY: 
        /// 
        /// the default constructor for this class
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAppointmentTypeManagerRetrieveAllAppointmentTypes()
        {
            // arrange
            List<string> appointmentTypes;
            IAppointmentTypeManager appointmentTypeManager = new AppointmentTypeManager(_fakeAppointmentTypeAccessor);

            // act
            appointmentTypes = appointmentTypeManager.RetrieveAllAppontmentTypes();

            // assert
            Assert.AreEqual(3, appointmentTypes.Count);
        }
    }
}

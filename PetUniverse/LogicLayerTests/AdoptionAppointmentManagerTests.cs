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
    /// NAME: Austin Gee
    /// DATE: 2/6/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This class is used to unit test the AdopterApplicationManager class
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>

    [TestClass]
    public class AdoptionAppointmentManagerTests
    {
        IAdoptionAppointmentAccessor _adoptionAppointmentAccessor;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This is the no-argument constructor for this class.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AdoptionAppointmentManagerTests()
        {
            _adoptionAppointmentAccessor = new FakeAdoptionAppointmentAccessor();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This method test the TestAdoptionApplicationRetrievesActiveAdoptionAppointments method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionAppointmentRetrievesActiveAdoptionAppointments()
        {
            // arange
            List<AdoptionAppointmentVM> adoptionAppointmentVMs;
            IAdoptionAppointmentManager adoptionAppointmentManager = new AdoptionAppointmentManager(_adoptionAppointmentAccessor);

            // act
            adoptionAppointmentVMs = adoptionAppointmentManager.RetrieveAdoptionAppointmentsByActiveAndType(true, "Meet and Greet");

            // assert
            Assert.AreEqual(1, adoptionAppointmentVMs.Count);
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/5/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Tests the retrieves Adoption Appointment VMs by appointment ID method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionAppointmentRetrievesAdoptionAppointmentByAppointmentID()
        {
            // arrange
            AdoptionAppointmentVM adoptionAppointmentVM;
            IAdoptionAppointmentManager adoptionAppointmentManager = new AdoptionAppointmentManager(_adoptionAppointmentAccessor);

            // act
            adoptionAppointmentVM = adoptionAppointmentManager.RetrieveAdoptionAppointmentByAppointmentID(000);

            // assert
            Assert.AreEqual(000, adoptionAppointmentVM.AppointmentID);
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Tests the Insert appointment method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionAppointmentAddAdoptionAppointment()
        {
            // arrange
            bool result = false;
            var adoptionAppointment = new AdoptionAppointment()
            {
                AdoptionApplicationID = 000,
                AppointmentActive = true,
                AppointmentDateTime = DateTime.Now,
                AppointmentID = 000,
                AppointmentTypeID = "Fake",
                Decision = "Fake",
                LocationID = 000,
                Notes = "Fake"
            };
            IAdoptionAppointmentManager adoptionAppointmentManager = new AdoptionAppointmentManager(_adoptionAppointmentAccessor);

            // act
            result = adoptionAppointmentManager.AddAdoptionAppointment(adoptionAppointment);

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/27/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Tests the retrieves Adoption Appointment VMs by email method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionAppointmentRetrievesAdoptionAppointmentsByCustomerEmailAndActive()
        {
            // arrange
            List<AdoptionAppointmentVM> adoptionAppointmentVMs;
            IAdoptionAppointmentManager adoptionAppointmentManager = new AdoptionAppointmentManager(_adoptionAppointmentAccessor);

            // act
            adoptionAppointmentVMs = adoptionAppointmentManager.RetrieveAdoptionAppointmentsByCustomerEmailAndActive("Fake@fake.fake");

            // assert
            Assert.AreEqual(1, adoptionAppointmentVMs.Count);
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/27/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Tests the updates an appointments datetime
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionAppointmentManagerUpdatesAdoptionAppointmentDateTime()
        {
            // arrange
            IAdoptionAppointmentManager adoptionAppointmentManager = new AdoptionAppointmentManager(_adoptionAppointmentAccessor);

            // act
            bool result = adoptionAppointmentManager.EditAdoptionAppointmentDateTime(000, DateTime.Parse("7/12/1984"));

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/27/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Tests the updates an appointments datetime
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionAppointmentManagerRetrievesAdoptionAppointmentsByActive()
        {
            // arrange
            IAdoptionAppointmentManager adoptionAppointmentManager = new AdoptionAppointmentManager(_adoptionAppointmentAccessor);

            // act
            var result = adoptionAppointmentManager.RetrieveAdoptionAppointmentsByActive();

            // assert
            Assert.AreEqual(1, result.Count);
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/1/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Tests the updates an appointments datetime
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionAppointmentManagerEditAppointmentActive()
        {
            // arrange
            IAdoptionAppointmentManager adoptionAppointmentManager = new AdoptionAppointmentManager(_adoptionAppointmentAccessor);

            // act
            bool result = adoptionAppointmentManager.EditAdoptionAppointmentActive(000, false);

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/3/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Tests the Update adoption
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionAppointmentUpdateAdoptionAppointment()
        {
            // arrange
            bool result = false;
            var oldAdoptionAppointment = new AdoptionAppointment
            {
                AppointmentID = 000,
                AdoptionApplicationID = 000,
                AppointmentActive = true,
                AppointmentDateTime = DateTime.Parse("7/12/1984"),
                AppointmentTypeID = "FAKE",
                Decision = "Fake",
                LocationID = 000,
                LocationName = "Fake",
                Notes = "Fake",
            };

            var newAdoptionAppointment = new AdoptionAppointment
            {
                AppointmentID = 000,
                AdoptionApplicationID = 001,
                AppointmentActive = true,
                AppointmentDateTime = DateTime.Parse("7/12/1984"),
                AppointmentTypeID = "FAKE",
                Decision = "Fake",
                LocationID = 000,
                LocationName = "Fake",
                Notes = "Fake",
            };
            IAdoptionAppointmentManager adoptionAppointmentManager = new AdoptionAppointmentManager(_adoptionAppointmentAccessor);

            // act
            result = adoptionAppointmentManager.EditAdoptionAppointment(oldAdoptionAppointment, newAdoptionAppointment);

            // assert
            Assert.IsTrue(result);
        }
    }
}

using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Zoey McDonald
    /// DATE: 2/7/2020
    /// CHECKED BY: Ethan Holmes
    /// 
    /// This test class is used for testing volunteer event.
    /// 
    /// </summary>
    [TestClass]
    public class VolunteerEventTests
    {
        private IVolunteerEventAccessor _volunteerEventAccessor;
        private VolunteerEventManager _volunteerEventManager;

        public VolunteerEventTests()
        {
            _volunteerEventAccessor = new FakeVolunteerEventAccessor();
        }
        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This test method is used for testing the creation of a volunteer event. 
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// WHAT WAS CHANGED: N/A
        /// </remarks>
        [TestMethod]
        public void TestVolunteerManagerCreatesVolunteerEvent()
        {

            // Arrange
            VolunteerEventVM Volevent = new VolunteerEventVM()
            {
                EventName = "The Event Name",
                EventDescription = "The Event Description",
                Active = true
            };

            int rows = 0;
            IVolunteerEventManager _volunteerEventManager = new VolunteerEventManager(_volunteerEventAccessor);

            // Act
            rows = _volunteerEventManager.InsertVolunteerEvent(Volevent);

            // Assert
            Assert.AreEqual(rows, 1);
        }

        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This test method is used for testing the removal of a volunteer event. 
        /// 
        /// </summary>
        /// 
        [TestMethod]
        public void TestVolunteerEventManagerRemoveEvent()
        {
            // Arrange          
            int rows = 0;
            IVolunteerEventManager _volunteerEventManager = new VolunteerEventManager(_volunteerEventAccessor);
            // Act
            rows = _volunteerEventManager.RemoveVolunteerEvent(100000);

            // Assert
            Assert.AreEqual(1, rows);
        }

        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This test method is used for testing the removal of a non-existing volunteer event. 
        /// 
        /// </summary>
        [TestMethod]
        public void TestVolunteerEventManagerRemoveNonExistingEvent()
        {
            // Arrange
            IVolunteerEventManager _volunteerEventManager = new VolunteerEventManager(_volunteerEventAccessor);

            // Act
            int rows = _volunteerEventManager.RemoveVolunteerEvent(25225);

            // Assert
            Assert.AreEqual(0, rows);
        }

        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This test method is used for testing the when a volunteer event is updated. 
        /// 
        /// </summary>
        [TestMethod]
        public void TestVolunteerEventManagerUpdateEventRecord()
        {
            // Arrange
            IVolunteerEventManager _volunteerEventManager = new VolunteerEventManager(_volunteerEventAccessor);
            int rows = 0;

            // Act
            rows = _volunteerEventManager.UpdateVolunteerEvent(
                new VolunteerEvent()
                {
                    VolunteerEventID = 100000
                },
                new VolunteerEvent()
                {
                    VolunteerEventID = 100000,
                    EventName = "Cool Event",
                    EventDescription = "It is a cool event."
                });

            // Assert
            Assert.AreEqual(1, rows);
        }


    }
}
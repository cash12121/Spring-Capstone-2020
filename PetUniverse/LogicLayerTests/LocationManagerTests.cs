using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/19/2020
    /// CHECKED BY: 
    /// 
    /// Location Manager test methods
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    [TestClass]
    public class LocationManagerTests
    {
        ILocationAccessor _fakeLocationAccessor;

        public LocationManagerTests()
        {
            _fakeLocationAccessor = new FakeLocationAccessor();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/19/2020
        /// CHECKED BY: 
        /// 
        /// Test of retrieve all locations method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestLocationManagerRetrieveAllLocations()
        {
            // arrange
            var locationManager = new LocationManager(_fakeLocationAccessor);

            // act
            var locations = locationManager.RetrieveAllLocations();

            // assert
            Assert.AreEqual(3, locations.Count);
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/19/2020
        /// CHECKED BY: 
        /// 
        /// Test of retrieve all locations method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestLocationManagerInsertLocation()
        {
            // arrange
            var locationManager = new LocationManager(_fakeLocationAccessor);
            var location = new Location()
            {
                LocationID = 004,
                Name = "Fake",
                Address1 = "Fake",
                Address2 = "Fake",
                City = "Fake",
                State = "FK",
                Zip = "FAKE"
            };

            // act
            var result = locationManager.AddLocation(location);

            // assert
            Assert.IsTrue(result);
        }
    }
}

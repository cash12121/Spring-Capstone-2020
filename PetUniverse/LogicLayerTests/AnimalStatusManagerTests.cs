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
    /// DATE: 3/12/2020
    /// CHECKED BY: 
    /// 
    /// This class is used to unit test the AnimalStatusManager class
    /// </summary>
    [TestClass]
    public class AnimalStatusManagerTests
    {
        private IAnimalStatusAccessor _fakeAnimalStatusAccessor;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This is the standard constructor for this class
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AnimalStatusManagerTests()
        {
            _fakeAnimalStatusAccessor = new FakeAnimalStatusAccessor();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Thomas Dupuy
        /// 
        /// tests adding a status
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        [TestMethod]
        public void TestAnimalStatusManagerAddAnimalStatus()
        {
            // arrange
            bool result = false;
            IAnimalStatusManager animalStatusManager = new AnimalStatusManager(_fakeAnimalStatusAccessor);

            // act
            result = animalStatusManager.AddAnimalStatus(10, "ruff");

            // assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// tests deleting an animal status
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        [TestMethod]
        public void TestAnimalStatusManagerDeleteAnimalStatus()
        {
            // arrange
            bool result;
            IAnimalStatusManager animalStatusManager = new AnimalStatusManager(_fakeAnimalStatusAccessor);

            // act
            result = animalStatusManager.DeleteAnimalStatus(1, "Fake1");

            // assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// tests Retrieving animal statuses
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        [TestMethod]
        public void TestAnimalStatusManagerRestrieveStatusesByAnimalID()
        {
            //arrange
            var animalStatuses = new List<string>();
            IAnimalStatusManager animalStatusManager = new AnimalStatusManager(_fakeAnimalStatusAccessor);

            // act
            animalStatuses = animalStatusManager.RetrieveAnimalStatusesByAnimalID(1);

            // assert
            Assert.AreEqual(1, animalStatuses.Count);
        }
    }
}

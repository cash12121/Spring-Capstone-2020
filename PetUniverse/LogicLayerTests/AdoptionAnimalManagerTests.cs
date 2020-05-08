using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/5/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This class is used to unit test the AdoptionAnimalManager class
    /// </summary>
    [TestClass]
    public class AdoptionAnimalManagerTests
    {
        IAdoptionAnimalAccessor _fakeAdoptionAnimalAccessor;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/5/2020
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
        public AdoptionAnimalManagerTests()
        {
            _fakeAdoptionAnimalAccessor = new FakeAdoptionAnimalAccessor();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/5/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Tests the retrieve animal VMs by active method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionAnimalRetrieveAnimalsByActive()
        {
            // arrange
            List<AdoptionAnimalVM> adoptionAnimalVMs;
            IAdoptionAnimalManager adoptionAnimalManager = new AdoptionAnimalManager(_fakeAdoptionAnimalAccessor);

            // act
            adoptionAnimalVMs = adoptionAnimalManager.RetrieveAdoptionAnimalsByActive(true);

            // assert
            Assert.AreEqual(3, adoptionAnimalVMs.Count);
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/4/2020
        /// CHECKED BY: Micheal Thompson, 4/9/2020
        /// 
        /// Tests the decativate animal animalID
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionAnimalDeactivateAnimal()
        {
            // arrange
            bool result = false;
            IAdoptionAnimalManager adoptionAnimalManager = new AdoptionAnimalManager(_fakeAdoptionAnimalAccessor);

            // act
            result = adoptionAnimalManager.DeactivateAnimal(000);

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/29/2020
        /// CHECKED BY: 
        /// 
        /// Tests retrieve animals by active and adoptable
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionAnimalRetrieveAnimalsByActiveAndAdoptable()
        {
            // arrange
            
            IAdoptionAnimalManager adoptionAnimalManager = new AdoptionAnimalManager(_fakeAdoptionAnimalAccessor);

            // act
            var result = adoptionAnimalManager.RetrieveAdoptionAnimalsByActiveAndAdoptable();

            // assert
            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/29/2020
        /// CHECKED BY: 
        /// 
        /// Tests update animal adoptable quality
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionAnimalUpdateAnimalAdoptable()
        {
            // arrange

            IAdoptionAnimalManager adoptionAnimalManager = new AdoptionAnimalManager(_fakeAdoptionAnimalAccessor);

            // act
            var result = adoptionAnimalManager.EditAnimalAdoptable(000, true);

            // assert
            Assert.IsTrue(result);
        }
    }
}

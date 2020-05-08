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
    /// Creator: Robert Holmes
    /// Created: 2020/03/12
    /// Approver: Cash Carlson
    /// 
    /// Contains tests for PromotionManager class.
    /// </summary>
    [TestClass]
    public class PromotionManagerTests
    {
        private IPromotionAccessor _promotionAccessor;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/12
        /// Approver: Cash Carlson
        /// 
        /// Initializes variables for testing.
        /// </summary>
        [TestInitialize]
        public void TestSetup()
        {
            _promotionAccessor = new FakePromotionAccessor();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/12
        /// Approver: Cash Carlson
        /// 
        /// Tests if the manager is able to add a promotion.
        /// </summary>
        [TestMethod]
        public void TestAddPromotion()
        {
            //Arrange
            IPromotionManager promotionManager = new PromotionManager(_promotionAccessor);
            Promotion promotion = new Promotion()
            {
                PromotionID = "TESTPROMO",
                PromotionTypeID = "Percent",
                Discount = 0.95M,
                Description = "Test Description",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1)
            };
            promotion.Products.Add(new Product()
            {
                ProductID = "1234567890123",
                ItemID = 10000,
                Brand = "Test Brand",
                Category = "Test Category",
                Name = "Test Product",
                Taxable = true,
                Type = "Test Type",
                Description = "Test product description",
                Price = 1.00M
            });
            bool expectedResult = true;
            //Act
            bool actualResult = promotionManager.AddPromotion(promotion);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/12
        /// Approver: Cash Carlson
        /// 
        /// Tests whether the manager is able to retrieve all the promotion types.
        /// </summary>
        [TestMethod]
        public void TestRetrieveAllPromotionTypes()
        {
            //Arrange
            IPromotionManager promotionManager = new PromotionManager(_promotionAccessor);
            int expectedCount = 1;

            //Act
            List<string> list = promotionManager.GetAllPromotionTypes();

            //Assert
            Assert.AreEqual(expectedCount, list.Count);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// Tests whether the Promotion manager can properly call the edit method.
        /// </summary>
        [TestMethod]
        public void TestEditPromotion()
        {
            //Arrange
            IPromotionManager promotionManager = new PromotionManager(_promotionAccessor);
            Promotion oldPromotion = new Promotion()
            {
                PromotionID = "TESTPROMO",
                PromotionTypeID = "Percent",
                Discount = 0.95M,
                Description = "Test Description",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1)
            };
            oldPromotion.Products.Add(new Product()
            {
                ProductID = "1234567890123",
                ItemID = 10000,
                Brand = "Test Brand",
                Category = "Test Category",
                Name = "Test Product",
                Taxable = true,
                Type = "Test Type",
                Description = "Test product description",
                Price = 1.00M
            });
            Promotion newPromotion = new Promotion()
            {
                PromotionID = "TESTPROMO",
                PromotionTypeID = "Flat Amount",
                Discount = 0.95M,
                Description = "Test Description2",
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(2)
            };
            newPromotion.Products.Add(new Product()
            {
                ProductID = "1234567890123",
                ItemID = 10000,
                Brand = "Test Brand",
                Category = "Test Category",
                Name = "Test Product",
                Taxable = true,
                Type = "Test Type",
                Description = "Test product description",
                Price = 1.00M
            });
            bool expected = true;

            //Act
            bool actual = promotionManager.EditPromotion(oldPromotion, newPromotion);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/04/07
        /// Approver: Rasha Mohammed
        /// 
        /// Tests whether an active promo is successfully deactivated.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestMethod]
        public void TestDeactivatePromotion()
        {
            //Arrange
            IPromotionManager promotionManager = new PromotionManager(_promotionAccessor);
            Promotion promotion = new Promotion()
            {
                PromotionID = "TESTPROMO",
                PromotionTypeID = "Percent",
                Discount = 0.95M,
                Description = "Test Description",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1),
                Active = true
            };
            promotion.Products.Add(new Product()
            {
                ProductID = "1234567890123",
                ItemID = 10000,
                Brand = "Test Brand",
                Category = "Test Category",
                Name = "Test Product",
                Taxable = true,
                Type = "Test Type",
                Description = "Test product description",
                Price = 1.00M
            });
            bool expected = true;
            bool actual;

            //Act
            actual = promotionManager.TogglePromotionActive(promotion);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/07/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Tests whether an inactive promo is successfully reactivated.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestMethod]
        public void TestReactivateInactivePromotion()
        {
            //Arrange
            IPromotionManager promotionManager = new PromotionManager(_promotionAccessor);
            Promotion promotion = new Promotion()
            {
                PromotionID = "TESTPROMO",
                PromotionTypeID = "Percent",
                Discount = 0.95M,
                Description = "Test Description",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1),
                Active = false
            };
            promotion.Products.Add(new Product()
            {
                ProductID = "1234567890123",
                ItemID = 10000,
                Brand = "Test Brand",
                Category = "Test Category",
                Name = "Test Product",
                Taxable = true,
                Type = "Test Type",
                Description = "Test product description",
                Price = 1.00M
            });
            bool expected = true;
            bool actual;

            //Act
            actual = promotionManager.TogglePromotionActive(promotion);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// Cleans up after tests are run.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public void PromotionManagerTestsCleanup()
        {
            _promotionAccessor = null;
        }
    }
}

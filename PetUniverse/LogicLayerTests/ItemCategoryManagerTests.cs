using DataAccessFakes;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/02/22
    /// Approver: Dalton Reierson
    /// Approver: Jesse Tomash
    ///
    /// The test class for ItemCategoryManager.
    /// </summary>
    [TestClass]
    public class ItemCategoryManagerTests
    {

        private ItemCategory _itemCategory;
        private ItemCategoryManager _itemCategoryManager;
        private FakeItemCategoryAccessor _itemCategoryAccessor;

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Method to set up the tests.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _itemCategoryAccessor = new FakeItemCategoryAccessor();
            _itemCategoryManager = new ItemCategoryManager(_itemCategoryAccessor);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Test method to test creating a new item category.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestCreateNewItemCategory()
        {
            // arrange
            ItemCategory itemCategory = new ItemCategory()
            {
                ItemCategoryID = "Tool",
                Description = "Tool Description."
            };
            bool created = false;
            bool expectedResult = true;

            // act
            created = _itemCategoryManager.createNewItemCategory(itemCategory);

            // assert
            Assert.AreEqual(expectedResult, created);

        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Test method for testing getting a list of item categories.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestListItemCategories()
        {
            // arrange
            int expected = 2;
            List<ItemCategory> itemCategory;

            // act
            itemCategory = _itemCategoryManager.listItemCategories();

            // assert
            Assert.AreEqual(expected, itemCategory.Count);

        }


        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Method to clean up for the next test run.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>

        [TestCleanup]
        public void TestTearDown()
        {
            _itemCategory = null;
            _itemCategoryAccessor = null;
            _itemCategoryManager = null;
        }
    }
}

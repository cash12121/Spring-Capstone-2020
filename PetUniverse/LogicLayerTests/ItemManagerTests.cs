using DataAccessFakes;
using DataTransferObjects;
using DataAccessInterfaces;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/02/22
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// The test class for ItemManager.
    /// </summary>
    /// <remarks>
    /// Updater: Matt Deaton
    /// Updated: 2020-05-03
    /// Update: Set class attributes to the interface, instead of concrete classes, as per Tim's
    /// QA bug.  Ran all tests, and all passed. 
    /// </remarks>
    [TestClass]
    public class ItemManagerTests
    {

        private Item _item;
        private ItemManager _itemManager;
        private IItemAccessor _itemAccessor;

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:   Jesse Tomash
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
            _itemAccessor = new FakeItemAccessor();
            _itemManager = new ItemManager(_itemAccessor);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:   Jesse Tomash
        ///
        /// Test method to test creating a new item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestCreateNewItem()
        {
            // arrange
            Item item = new Item()
            {
                ItemCategoryID = "Cat Toys",
                ItemID = 1,
                ItemName = "Item",
                ItemQuantity = 100
            };
            bool created = false;
            bool expectedResult = true;

            // act
            created = _itemManager.createNewItem(item);

            // assert
            Assert.AreEqual(expectedResult, created);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/23
        /// Approver: Dalton Reierson
        /// Approver:   Jesse Tomash
        ///
        /// Test method for getting a list of items.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestListItem()
        {
            // Arrange
            int expectedResult = 3;
            List<Item> items = new List<Item>();

            // Act
            items = _itemManager.retrieveItems();

            // Assert
            Assert.AreEqual(expectedResult, items.Count);
        }


        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/04
        /// Approver: Dalton Reierson
        /// Approver:  
        ///
        /// Test Method that tests editing an item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestEditItem()
        {
            // Arrange
            Item oldItem = new Item()
            {
                ItemID = 1000,
                ItemCategoryID = "ItemID 1",
                ItemName = "Item 1",
                ItemQuantity = 20,
                Description = "Item Description 1"
            };

            Item newItem = new Item()
            {
                ItemID = 1000,
                ItemCategoryID = "ItemID 1",
                ItemName = "Item 2",
                ItemQuantity = 30,
                Description = "Item Description 2"
            };

            // Act
            bool result = false;
            result = _itemManager.editItemDetail(oldItem.ItemName, oldItem.Description, oldItem.ItemQuantity, newItem.ItemName, newItem.Description, newItem.ItemQuantity);

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/03/13
        /// Approver: Brandyn T. Coverdill
        /// Approver: Jesse Tomash
        ///
        /// Test Method for deactivateing items 
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeactivateItem()
        {
            // Arrange
            bool result = false;
            Item item = new Item();
            item.ItemID = 100000;
            item.ItemName = "Dog Food";
            item.ItemCategoryID = "Dog Food";
            item.Description = "Dog Food Description";
            item.ItemQuantity = 10;
            item.Active = true;


            // Act
            result = _itemManager.deactivateItem(item);

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Test Method for reactivateing items.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestReactivateItem()
        {
            // Arrange
            bool result = false;
            Item item = new Item();
            item.ItemID = 100000;
            item.ItemName = "Dog Food";
            item.ItemCategoryID = "Dog Food";
            item.Description = "Dog Food Description";
            item.ItemQuantity = 10;
            item.Active = false;


            // Act
            result = _itemManager.reactivateItems(item);

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Test method to test creating a new shelter item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestCreateNewShelterItem()
        {
            // arrange
            Item item = new Item()
            {
                ItemCategoryID = "Cat Toys",
                ItemID = 1,
                ItemName = "Item",
                ItemQuantity = 100
            };
            bool created = false;
            bool expectedResult = true;

            // act
            created = _itemManager.createNewShelterItem(item);

            // assert
            Assert.AreEqual(expectedResult, created);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/03/13
        /// Approver: Brandyn T. Coverdill
        /// Approver: Jesse Tomash
        ///
        /// Test Method that retreives items by active status
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveItemsByActive()
        {
            // Arrange
            int rowsAffected = 0;
            List<Item> itemList = new List<Item>();

            // Act
            itemList = _itemAccessor.getAllItemsByActive(true);
            rowsAffected = itemList.Count;

            // Assert
            Assert.AreEqual(5, rowsAffected);
        }

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-06
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Test method for return a list of shelter use items.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <returns>List of Items marked for shelter use</returns>
        [TestMethod]
        public void TestRetrieveShelterItemList()
        {
            //ARRANGE
            int expectedNumber = 5;
            List<Item> shelterItems = new List<Item>();

            //ACT
            shelterItems = _itemAccessor.SelectShelterItems(true);

            //ASSERT
            Assert.AreEqual(expectedNumber, shelterItems.Count);
        }// End TestRetrieveShelterItemList()

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-06
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Test method for return a list of shelter use items.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveNeededItemList()
        {
            int expectedNumber = 2;
            List<Item> shelterItems = new List<Item>();

            shelterItems = _itemAccessor.SelectNeededShelterItems();

            Assert.AreEqual(expectedNumber, shelterItems.Count);
        }// End TestRetrieveNeededItemList()

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-06
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Test method for Creating a new Donated Item.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        [TestMethod]
        public void TestCreateDonatedItem()
        {
            Item donatedItem = new Item()
            {
                ItemID = 777777,
                ItemName = "Test Item",
                ItemQuantity = 1,
                ItemCategoryID = "Dog Toy",
                ShelterItem = true,
                ShelterThreshold = 10
            };
            bool successfulAdd = false;
            bool expectedResult = true;

            successfulAdd = _itemManager.CreateNewDonatedItem(donatedItem);

            Assert.AreEqual(expectedResult, successfulAdd);
        }// End TestCreateDonatedItem()

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-06
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Test method for updating a Shelter Item.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        [TestMethod]
        public void TestEditShelterItem()
        {
            bool result = false;

            Item oldShelterItem = new Item()
            {
                ItemID = 100000,
                ItemName = "Denta Stix",
                ItemQuantity = 50,
                ItemCategoryID = "Dog Food",
                Description = "Treats to make a dog's breath better.",
                ShelterItem = true,
                ShelterThreshold = 25
            };
            Item newShelterItem = new Item()
            {
                ItemID = 100000,
                ItemName = "Denta Stix",
                ItemQuantity = 100, //Changed Value
                ItemCategoryID = "Dog Treats",
                Description = "Treats to make a dog's breath better.",
                ShelterItem = true,
                ShelterThreshold = 50 // Changed Value
            };

            result = _itemManager.EditShelterItem(oldShelterItem, newShelterItem);

            Assert.IsTrue(result);

        } // End TestEditShelterItem()

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:   Jesse Tomash
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
            _item = null;
            _itemAccessor = null;
            _itemManager = null;
        }
    }
}

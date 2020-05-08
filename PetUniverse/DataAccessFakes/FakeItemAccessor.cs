using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 02/22/2020
    /// Approver: Dalton Reierson
    /// Approver: Jesse Tomash
    ///
    /// The fake data accessor for Item.
    /// </summary>
    public class FakeItemAccessor : IItemAccessor
    {

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 02/22/2020
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// The method for adding a new item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public bool addNewItem(Item item)
        {
            bool itemID = item.ItemID.Equals(1);
            bool itemCategoryID = item.ItemCategoryID.Equals("Cat Toys");
            bool itemQuantity = item.ItemQuantity.Equals(100);
            bool itemName = item.ItemName.Equals("Item");

            if (itemID && itemCategoryID && itemQuantity && itemName)
            {
                return true;
            }
            else
            {
                throw new ApplicationException("Cannot add new Item.");
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 02/23/2020
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Method that gets all items from inventory.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<Item> getAllItems()
        {
            List<Item> items = new List<Item>()
            {
                new Item
                {
                    ItemID = 1,
                    ItemName = "Item1",
                    ItemQuantity = 10,
                    ItemCategoryID = "Dog Food"
                },

                new Item
                {
                    ItemID = 2,
                    ItemName = "Item2",
                    ItemQuantity = 20,
                    ItemCategoryID = "Dog Food"
                },

                new Item
                {
                    ItemID = 3,
                    ItemName = "Item3",
                    ItemQuantity = 30,
                    ItemCategoryID = "Cat Toys"
                }
            };
            return items;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 03/04/2020
        /// Approver: Dalton Reireson
        /// Approver: Jesse Tomash
        ///
        /// Method that updates an item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="newDesc"></param>
        /// <param name="newName"></param>
        /// <param name="newQuantity"></param>
        /// <param name="oldDesc"></param>
        /// <param name="oldName"></param>
        /// <param name="oldQuantity"></param>
        public int updateItemDetail(string oldName, string oldDesc, int oldQuantity, string newName, string newDesc, int newQuantity)
        {
            int result = 0;
            oldName = newName;
            oldDesc = newDesc;
            oldQuantity = newQuantity;

            if (oldName == newName && oldDesc == newDesc && oldQuantity == newQuantity)
            {
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 03/10/2020
        /// Approver: Brandyn T. Coverdill        
        ///
        /// Method that deactivates an item
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public int deactivateItem(Item item)
        {
            int rowsAffected = 0;

            Item testItem = new Item();
            testItem.ItemID = 100000;
            testItem.ItemName = "Dog Food";
            testItem.ItemCategoryID = "Dog Food";
            testItem.Description = "Dog Food Description";
            testItem.ItemQuantity = 10;
            testItem.Active = true;

            if (item.ItemID == testItem.ItemID &&
               item.ItemName == testItem.ItemName &&
               item.ItemCategoryID == testItem.ItemCategoryID &&
               item.Description == testItem.Description &&
               item.ItemQuantity == testItem.ItemQuantity &&
               item.Active == item.Active)
            {
                item.Active = false;
                rowsAffected = 1;
            }

            return rowsAffected;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 03/10/2020
        /// Approver: Brandyn T. Coverdill
        /// Approver: Jesse Tomash
        ///
        /// Method that returns all items with desired active state
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="active"></param>
        public List<Item> getAllItemsByActive(bool active)
        {
            List<Item> itemList = new List<Item>();
            List<Item> filterItemList = new List<Item>();

            for (int i = 0; i < 5; i++)
            {
                Item item = new Item();
                item.ItemID = 100000;
                item.ItemName = "Name";
                item.ItemQuantity = 10;
                item.ItemCategoryID = "100000";
                item.Description = "Test";
                item.Active = true;
                itemList.Add(item);
            }

            for (int i = 0; i < 4; i++)
            {
                Item item = new Item();
                item.ItemID = 100000;
                item.ItemName = "Name";
                item.ItemQuantity = 10;
                item.ItemCategoryID = "100000";
                item.Description = "Test";
                item.Active = false;
                itemList.Add(item);
            }

            var results = from item in itemList
                          where item.Active == true
                          select item;

            foreach (Item i in results)
            {
                filterItemList.Add(i);
            }
            return filterItemList;
        }

        /// <summary>
        /// Creator: Matt Deaton
        /// Created: 03/17/2020
        /// Approver: Steven Coonrod
        /// 
        /// Method to return a list of Items for Shelter use only.
        /// 
        /// </summary>
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="shelterItem"></param>
        /// <returns></returns>
        public List<Item> SelectShelterItems(bool shelterItem)
        {
            List<Item> allItems = new List<Item>();
            List<Item> shelterItems = new List<Item>();

            for (int i = 0; i < 5; i++)
            {
                Item items = new Item();
                items.ItemID = 444444;
                items.ItemName = "Test Name True";
                items.ItemQuantity = 50;
                items.ShelterThreshold = 10;
                items.ShelterItem = true;
                items.Description = "Test Description for True";
                allItems.Add(items);
            }
            for (int i = 0; i < 5; i++)
            {
                Item items = new Item();
                items.ItemID = 777777;
                items.ItemName = "Test Name False";
                items.ItemQuantity = 50;
                items.ShelterThreshold = 10;
                items.ShelterItem = false;
                items.Description = "Test Description for False";
                allItems.Add(items);
            }

            var shelterOnlyItem = from items in allItems
                                  where items.ShelterItem == true
                                  select items;

            foreach (Item item in shelterOnlyItem)
            {
                shelterItems.Add(item);
            }
            return shelterItems;
        }

        /// <summary>
        /// Creator: Matt Deaton
        /// Created: 03/17/2020
        /// Approver: Steven Coonrod
        /// 
        /// Method to return a list of needed shelter use items.
        /// 
        /// </summary>
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <returns></returns>
        public List<Item> SelectNeededShelterItems()
        {
            List<Item> neededItems = new List<Item>();
            List<Item> shelterItems = new List<Item>() {

                new Item
                {
                    ItemID = 1,
                    ItemName = "Earl the Squirrel",
                    ItemCategoryID = "Dog Toy",
                    ItemQuantity = 1,
                    ShelterItem = true,
                    ShelterThreshold = 3
                },

                new Item
                {
                    ItemID = 2,
                    ItemName = "Hopper the Rabbit",
                    ItemCategoryID = "Dog Toy",
                    ItemQuantity = 1,
                    ShelterItem = true,
                    ShelterThreshold = 2
                }
            };

            var shelterItemsOnly = from item in shelterItems
                                   where item.ShelterItem == true
                                   select item;

            foreach (Item i in shelterItemsOnly)
            {
                neededItems.Add(i);
            }
            return neededItems;
        }

        /// <summary>
        /// Creator: Matt Deaton
        /// Created: 03/17/2020
        /// Approver: Steven Coonrod
        /// 
        /// Method to add a new donated item to the shelter inventory.
        /// 
        /// </summary>
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="donatedItem"></param>
        /// <returns></returns>
        public int AddNewDonatedItem(Item donatedItem)
        {
            List<Item> shelterItems = new List<Item>();
            int originalCount = shelterItems.Count;
            shelterItems.Add(donatedItem);

            return shelterItems.Count - originalCount;
        }

        /// <summary>
        /// Creator: Matt Deaton
        /// Created: 03/17/2020
        /// Approver: Steven Coonrod
        /// 
        /// Method to updating an item that is in the shelter inventory.
        /// 
        /// </summary>
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="oldShelterItem"></param>
        /// <param name="newShelterItem"></param>
        /// <returns></returns>
        public int UpdateShelterItem(Item oldShelterItem, Item newShelterItem)
        {
            Item shelterItem = oldShelterItem;
            int results = 0;

            try
            {
                oldShelterItem = newShelterItem;
                results = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return results;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 04/10/2020
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Method that reactivates an item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public int reactivateItem(Item item)
        {
            int rowsAffected = 0;

            item.Active = true;

            if (item.Active == true)
            {
                item.Active = true;
                rowsAffected = 1;
            }

            return rowsAffected;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 04/10/2020
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// The method for adding a new shelter item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public bool addNewShelterItem(Item item)
        {
            bool itemID = item.ItemID.Equals(1);
            bool itemCategoryID = item.ItemCategoryID.Equals("Cat Toys");
            bool itemQuantity = item.ItemQuantity.Equals(100);
            bool itemName = item.ItemName.Equals("Item");

            if (itemID && itemCategoryID && itemQuantity && itemName)
            {
                return true;
            }
            else
            {
                throw new ApplicationException("Cannot add new Item.");
            }
        }

        public Item SelectItemByItemID(int itemID)
        {
            Item item = null;
            return item;
        }
    }
}

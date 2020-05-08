using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/02/22
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// The Logic Layer class for Item.
    /// </summary>
    public class ItemManager : IItemManager
    {

        private IItemAccessor _itemAccessor;

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// The method that adds a new item to the database.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public bool createNewItem(Item item)
        {
            try
            {
                return _itemAccessor.addNewItem(item);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to add a new Item", ex);
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/23
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Method that gets a list of items for inventory.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<Item> retrieveItems()
        {
            List<Item> items = new List<Item>();

            try
            {
                items = _itemAccessor.getAllItems();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Items Found", ex);
            }

            return items;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/04
        /// Approver: Dalton Reierson
        /// Approver:   Jesse Tomash
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
        public bool editItemDetail(string oldName, string oldDesc, int oldQuantity, string newName, string newDesc, int newQuantity)
        {

            bool result = false;

            try
            {
                result = 1 == _itemAccessor.updateItemDetail(oldName, oldDesc, oldQuantity, newName, newDesc, newQuantity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update Item Failed.", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/03/09
        /// Approver: Brandyn T. Coverdill
        /// Approver: Jesee Tomash
        ///
        /// The method that retrieves all items in inventory by active
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public List<Item> retrieveItemsByActive(bool active)
        {
            List<Item> itemList = new List<Item>();

            try
            {
                itemList = _itemAccessor.getAllItemsByActive(active);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Items not found.", ex);
            }

            return itemList;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/03/13
        /// Approver: Brandyn T. Coverdill
        /// Approver: Jesee Tomash
        ///
        /// Method to deactivate item
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public bool deactivateItem(Item item)
        {
            bool result = false;

            try
            {
                result = (1 == _itemAccessor.deactivateItem(item));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Deactivate Item Failed.", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Constructor for the Item Manager that takes an itemAccessor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        public ItemManager(IItemAccessor itemAccessor)
        {
            _itemAccessor = itemAccessor;
        }


        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Default Constructor for Item Manager.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ItemManager()
        {
            _itemAccessor = new ItemAccessor();
        }

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 3/4/2020
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Logic Layer method for retriving a list items for the shelter.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <returns>List of Items inteded for shelter use</returns>
        public List<Item> RetrieveShelterItems(bool shelterItem = true)
        {
            List<Item> items = null;
            try
            {
                items = _itemAccessor.SelectShelterItems(shelterItem);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Items Found.", ex);
            }
            return items;
        }// End RetrieveShelterItems()

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-07
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Logic Layer method for retriving a list items needed for the shelter.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="shelterThreshold"></param>
        /// <returns></returns>
        public List<Item> RetrieveNeededShelterItems()
        {
            List<Item> items = null;
            try
            {
                items = _itemAccessor.SelectNeededShelterItems();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Items Found.", ex);
            }
            return items;
        }// End RetrieveNeededShelterItems()

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-06
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Method to create a shelter item from a donated item.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="donatedItem"></param>
        /// <returns></returns>
        public bool CreateNewDonatedItem(Item donatedItem)
        {
            try
            {
                return 1 == _itemAccessor.AddNewDonatedItem(donatedItem);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to add Donation.", ex);
            }
        }// End CreateNewDonationItem()

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-14
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Method to Edit a Shelter Item in inventory.
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATED BY: Steve Coonrod
        /// UPDATED: 2020-4-25
        /// CHANGE: Changed the result to accomidate for a low inventory trigger
        ///         which will return 3 rows effected rather than 1
        /// 
        /// </remarks>
        /// <param name="oldShelterItem"></param>
        /// <param name="newShelterItem"></param>
        /// <returns>bool of result</returns>
        public bool EditShelterItem(Item oldShelterItem, Item newShelterItem)
        {
            bool result = false;

            try
            {
                int rowsEffected = _itemAccessor.UpdateShelterItem(oldShelterItem, newShelterItem);
                if (rowsEffected == 1 || rowsEffected == 3)
                {
                    result = true;
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to Update Shelter Item.", ex);
            }
            return result;
        }// End EditShelterItem()

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Method to reactivate an item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public bool reactivateItems(Item item)
        {
            bool result = false;

            try
            {
                result = (1 == _itemAccessor.reactivateItem(item));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Reactivate Item Failed.", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// The method that adds a new shelter item to the database.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public bool createNewShelterItem(Item item)
        {
            try
            {
                return _itemAccessor.addNewShelterItem(item);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to add a new Item", ex);
            }
        }
        /// <summary>
        /// Creator: Jesse Tomash
        /// Created: 4/26/2020
        /// Approver: 
        /// Approver: 
        ///
        /// selects item by item id
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public Item SelectItemByItemID(int itemID)
        {
            try
            {
                return _itemAccessor.SelectItemByItemID(itemID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable find item", ex);
            }
        }
    }
}

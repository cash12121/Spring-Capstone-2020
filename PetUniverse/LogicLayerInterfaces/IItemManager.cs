using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/02/22
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// The Logic Layer Interface for object Item.
    /// </summary>
    public interface IItemManager
    {
        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// The interface method for adding a new item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        bool createNewItem(Item item);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/23
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface method that gets a list of items from inventory.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        List<Item> retrieveItems();


        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/04
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface method that updates an item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        bool editItemDetail(string oldName, string oldDesc, int oldQuantity, string newName, string newDesc, int newQuantity);

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/03/09
        /// Approver: Brandyn T. Coverdill
        /// Approver: Jesse Tomash
        ///
        /// Interface method that gets a list of items from inventory by their active field.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="active"></param>
        List<Item> retrieveItemsByActive(bool active);

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/03/09
        /// Approver: Brandyn T. Coverdill
        /// Approver: Jesse Tomash
        ///
        /// Interface method that sets an items active field to 0
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        bool deactivateItem(Item item);

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-06
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Method to return a list of shelter use items.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <returns>List of Items marked for shelter use</returns>
        List<Item> RetrieveShelterItems(bool shelterItem = true);

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-06
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Method to return a list of Needed Shelter Items.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <returns></returns>
        List<Item> RetrieveNeededShelterItems();

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-06
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Method to add a new donation item to the shelter inventory.
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
        bool CreateNewDonatedItem(Item donatedItem);

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-06
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Method to Edit a Shelter Item in inventory.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="oldShelterItem"></param>
        /// <param name="newShelterItem"></param>
        /// <returns></returns>
        bool EditShelterItem(Item oldShelterItem, Item newShelterItem);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Interface method that sets an items active field to 1.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        bool reactivateItems(Item item);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// The interface method for adding a new shelter item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param> 
        bool createNewShelterItem(Item item);

        /// <summary>
        /// Creator: Jesse Tomash
        /// Created: 4/27/2020
        /// Approver: 
        ///
        /// The interface method for selecting itemid 
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param> 
        Item SelectItemByItemID(int itemID);
    }
}

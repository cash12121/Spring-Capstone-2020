using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 02/22/2020
    /// Approver: Dalton Reierson
    /// Approver: Jesse Tomash
    ///
    /// The Data Access Interface for type Item.
    /// </summary>
    public interface IItemAccessor
    {

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 02/22/2020
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Interface method that adds a new item to inventory.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        bool addNewItem(Item item);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 02/22/2020
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Interface method that gets all items for inventory.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        List<Item> getAllItems();


        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 02/22/2020
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Interface method that updates an item.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="newDesc"></param>
        /// <param name="newName"></param>
        /// <param name="newQuantity"></param>
        /// <param name="oldDesc"></param>
        /// <param name="oldName"></param>
        /// <param name="oldQuantity"></param>
        int updateItemDetail(string oldName, string oldDesc, int oldQuantity, string newName, string newDesc, int newQuantity);

        /// <summary>
        /// Creator: Dalton Reierson
        /// Creator: Brandyn T. Coverdill
        /// Created: 03/22/2020
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Interface method that selects all items by their active field
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="active"></param>
        List<Item> getAllItemsByActive(bool active);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 04/09/2020
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Interface method that sets the active field to 0
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        int deactivateItem(Item item);

        /// <summary>
        /// Creator: Matt Deaton
        /// Created: 03/06/2020
        /// Approver: Steven Coonrod
        /// 
        /// Method to return a list of shelter use items.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <returns>List of Items marked for shelter use</returns>
        List<Item> SelectShelterItems(bool shelterItem);

        /// <summary>
        /// Creator: Matt Deaton
        /// Created: 03/07/2020
        /// Approver: Steven Coonrod
        /// 
        /// Method to return a list of needed shelter items.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="shelterThreshold"></param>
        /// <returns></returns>
        List<Item> SelectNeededShelterItems();

        /// <summary>
        /// Creator: Matt Deaton
        /// Created: 03/07/2020
        /// Approver: Steven Coonrod
        /// 
        /// Method to add a new Shelter Item through donation.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="donatedItem"></param>
        /// <returns></returns>
        int AddNewDonatedItem(Item donatedItem);

        /// <summary>
        /// Creator: Matt Deaton
        /// Created: 03/07/2020
        /// Approver: Steven Coonrod
        /// 
        /// Method to update Shelter Item in inventory.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="oldShelterItem"></param>
        /// <param name="newShelterItem"></param>
        /// <returns></returns>
        int UpdateShelterItem(Item oldShelterItem, Item newShelterItem);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface method that adds a new shelter item to inventory.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        bool addNewShelterItem(Item item);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Interface method that sets the active field to 1
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        int reactivateItem(Item item);
        /// <summary>
        /// Creator: Jesse Tomash
        /// Created: 4/27/2020
        /// Approver: 
        /// Approver: 
        ///
        /// Interface method to select item by id
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

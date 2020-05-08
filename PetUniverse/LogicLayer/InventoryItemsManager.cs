using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Cash Carlson
    /// Created: 02/21/2020
    /// Approver: Zach Behrensmeyer
    ///
    /// Inventory Items manager class that has the logic for InventoryItems class
    /// </summary>
    public class InventoryItemsManager : IInventoryItemsManager
    {
        private IInventoryItemsAccessor _inventoryAccessor;

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 02/21/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Default Constructor for Inventory Items Manager Class that uses the
        /// data access class for InventoryItems
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        public InventoryItemsManager()
        {
            _inventoryAccessor = new InventoryItemsAccessor();
        }

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/02/21
        /// Approver: Zach Behrensmeyer
        ///
        /// Additional Constructor to use an alternative data accessor instead of 
        /// the default. Mostly used for testing
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="inventoryAccessor"></param>
        public InventoryItemsManager(IInventoryItemsAccessor inventoryAccessor)
        {
            _inventoryAccessor = inventoryAccessor;
        }

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/02/21
        /// Approver: Zach Behrensmeyer
        ///
        /// Logic method that uses an InventoryItemsAccessor method to get all
        /// of the InventoryItems
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <returns>A list of of InventoryItems</returns>
        public List<InventoryItems> RetrieveInventoryItems()
        {
            try
            {
                return _inventoryAccessor.SelectAllInventory();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }
    }
}

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
    /// Approver: Jesse Tomash
    ///
    /// The Logic Layer class for ItemCategory
    /// </summary>
    public class ItemCategoryManager : IItemCategoryManager
    {

        private IItemCategoryAccessor _itemCategoryAccessor;

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// The method for adding a new Item Category.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="itemCategory"></param>
        public bool createNewItemCategory(ItemCategory itemCategory)
        {
            try
            {
                return _itemCategoryAccessor.addNewItemCategory(itemCategory);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to add a new Item Category", ex);
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Method that gets a list of item categories.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<ItemCategory> listItemCategories()
        {
            return _itemCategoryAccessor.getItemCategories();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// constructor for itemCategory manager that takes an itemCategoryAccessor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        public ItemCategoryManager(IItemCategoryAccessor itemCategoryAccessor)
        {
            _itemCategoryAccessor = itemCategoryAccessor;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// The default constructor for the itemCategory manager.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ItemCategoryManager()
        {
            _itemCategoryAccessor = new ItemCategoryAccessor();
        }
    }
}

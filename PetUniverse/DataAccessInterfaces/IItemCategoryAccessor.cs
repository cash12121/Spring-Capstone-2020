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
    /// The Data Access Interface for ItemCategory.
    /// </summary>
    public interface IItemCategoryAccessor
    {

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 02/22/2020
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Method that creates a new Item Category.
        /// </summary>
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="itemCategory"></param>
        bool addNewItemCategory(ItemCategory itemCategory);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 02/22/2020
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Interface method that gets a list of item categories.
        /// </summary>
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        List<ItemCategory> getItemCategories();
    }
}
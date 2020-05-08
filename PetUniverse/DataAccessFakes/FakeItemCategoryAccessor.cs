using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 02/22/2020
    /// Approver: Dalton Reierson
    /// Approver: Jesse Tomash
    ///
    /// The fake data accessor for ItemCategory.
    /// </summary>
    public class FakeItemCategoryAccessor : IItemCategoryAccessor
    {

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 02/22/2020
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// The method for inserting a new category.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="itemCategory"></param>
        public bool addNewItemCategory(ItemCategory itemCategory)
        {
            bool itemCategoryID = itemCategory.ItemCategoryID.Equals("Tool");
            bool categoryName = itemCategory.Description.Equals("Tool Description.");

            if (itemCategoryID && categoryName)
            {
                return true;
            }
            else
            {
                throw new ApplicationException("Unable to add ItemCategory");
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 02/22/2020
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Method that gets a list of item categories.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<ItemCategory> getItemCategories()
        {
            List<ItemCategory> itemCategory = new List<ItemCategory>()
            {
                new ItemCategory
                {
                    ItemCategoryID = "Tool",
                    Description = "Tool"
                },

                new ItemCategory
                {
                    ItemCategoryID = "Medical",
                    Description = "Medical"
                }
            };
            return itemCategory;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 02/22/2020
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Method that gets the ItemCategoryID.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="categoryName"></param>
        public int getItemCategoryID(string categoryName)
        {
            return 0;
        }
    }
}

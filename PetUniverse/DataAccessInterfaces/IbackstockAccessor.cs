using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Tener karar
    /// Created: 02/7/2020
    /// Approver: Steven Cardona
    /// 
    /// Get Backstop inventory
    /// </summary>
    public interface IBackStockAccessor
    {

        /// <summary>
        /// Creator: Tener karar
        /// Created: 02/7/2020
        /// Approver: Steven Cardona
        /// 
        /// Get all items 
        /// </summary>
        /// <returns></returns>
        List<Item> getAllItemsInBackRoom();

        /// <summary>
        /// Creator: Tener karar
        /// Created: 02/7/2020
        /// Approver: Steven Cardona
        /// 
        /// Get the location by an ID
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        List<int> getItemLocationsByItemID(int itemID);

        /// <summary>
        /// Creator: Tener karar
        /// Created: 02/7/2020
        /// Approver: Steven Cardona
        /// 
        /// Update an item location
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="itemLocationID"></param>
        /// <param name="NewItemLocation"></param>
        /// <returns></returns>
        bool UpdateItemLocation(int itemID, int itemLocationID, int NewItemLocation);
    }
}
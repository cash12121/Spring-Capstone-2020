using DataAccessInterfaces;
using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Tener karar
    /// Created: 02/7/2020
    /// Approver: Steven Cardona
    ///
    /// The fake data accessor class for BackRecords
    /// Contains all methods for  making  the real  data
    /// </summary>
    public class FakeBackRecordAccessor : IBackStockAccessor
    {
        private List<Item> items = null;
        private List<ItemLocation> itemlocations = null;

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 02/7/2020
        /// Approver: Steven Cardona
        /// 
        /// No argument constructor
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        public FakeBackRecordAccessor()
        {
            items = new List<Item>()
            {
                new Item()
                {
                    ItemID = 10001,
                    ItemName = "gggggg",
                    ItemQuantity = 4,
                    ItemCategoryID ="ggg"
                },
            };

            itemlocations = new List<ItemLocation>()
            {
                new ItemLocation(){
                itemID = 1000,
                itemLocation=1000,
                },

                new ItemLocation(){
                itemID = 1001,
                itemLocation = 1002,
                },

                new ItemLocation(){
                itemID = 1000,
                itemLocation = 1004,
                },

                new ItemLocation(){
                itemID = 1003,
                itemLocation = 1005,
                },
            };
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 02/7/2020
        /// Approver: Steven Cardona
        /// 
        /// Method to get all items in the back room
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        public List<Item> getAllItemsInBackRoom()
        {
            return items;
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 02/7/2020
        /// Approver: Steven Cardona
        /// 
        /// Method to get an item in the back by ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="itemID"></param>
        public List<int> getItemLocationsByItemID(int itemID)
        {
            List<int> item = new List<int>();
            foreach (ItemLocation itemlocationFake in itemlocations)
            {
                if (itemID == itemlocationFake.itemID)
                {
                    item.Add(itemlocationFake.itemLocation);
                }
            }
            return item;
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 02/7/2020
        /// Approver: Steven Cardona
        /// 
        /// Method to update an item location
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="item"></param>
        /// <param name="itemLocationID"></param>
        /// <param name="NewItemLocation"></param>
        public bool UpdateItemLocation(int itemID, int itemLocationID, int NewItemLocation)
        {
            bool locationUpdate = false;

            foreach (ItemLocation itemlocationFake in itemlocations)
            {
                if (itemID == itemlocationFake.itemID && itemLocationID == itemlocationFake.itemLocation)
                {
                    itemlocationFake.itemLocation = NewItemLocation;
                    // if the item location is updated, locationUpdate = true
                    locationUpdate = true;
                    break;
                }
            }
            return locationUpdate;
        }
    }
}


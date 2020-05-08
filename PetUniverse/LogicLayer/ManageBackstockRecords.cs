using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Tener karar
    /// Created: 2020/02/7
    /// Approver
    ///
    /// The back stok manger class
    /// Contains all methods for performing manging the stock record functions
    /// </summary>
    public class ManageBackstockRecords : IManageBackstockRecords
    {
        private IBackStockAccessor BackRecordAccessor;
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this constrctor method  for manger stock
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>


        public ManageBackstockRecords()
        {
            BackRecordAccessor = new BackStockAccessor();
        }
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver:Steven CArdona
        /// 
        /// this anthor constrctor method  for manger stock
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="backRecordAccessorFakes"></param>
        public ManageBackstockRecords(IBackStockAccessor backRecordAccessorFakes)
        {
            this.BackRecordAccessor = backRecordAccessorFakes;
        }

        public bool EditItemLocation(int itemID, int itemLocationID, int NewItemLocation)
        {
            bool result;
            try
            {
                result = BackRecordAccessor.UpdateItemLocation(itemID, itemLocationID, NewItemLocation);
            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this method creating a list to holde item list
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="item"></param>

        public List<int> getItemLocations(int itemID)
        {
            List<int> locations = null;
            try
            {
                locations = BackRecordAccessor.getItemLocationsByItemID(itemID);

            }
            catch (Exception)
            {

                locations = new List<int>();
            }

            return locations;
        }
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this method for geting  all pets from back room update 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="item"></param>

        public List<Item> getPetsInBackRoom()
        {
            List<Item> result = null;
            try
            {
                result = BackRecordAccessor.getAllItemsInBackRoom();
            }
            catch (Exception)
            {

                result = new List<Item>();
            }


            return result;



        }
    }
}

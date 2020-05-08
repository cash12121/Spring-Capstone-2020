using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicLayer
{
    /// <summary>
    ///  Creator: Rasha Mohammed
    ///  Created: 4/1/2020
    ///  Approver: Ethan Holmes
    ///  
    ///  Manager Class for picture
    /// </summary>
    /// <remarks>
    /// Updater: Robert Holmes
    /// Updated: 04/29/2020 
    /// Update: Added AddPicture, RetrieveMostRecentPictureByProductID, and RetrieveAllPicutresByProducID
    /// 
    /// </remarks>
    public class PictureManager : IPictureManager
    {
        private IPictureAccessor _pictureAccessor;

        /// <summary>
		///  Creator: Rasha Nohammed
		///  Created: 4/1/2020
		///  Approver: Ethan Holmes
		///  
		///  Default Constructor for instantiating Accessor
        ///  
		/// </summary>
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// 
		/// </remarks>
		public PictureManager()
        {
            _pictureAccessor = new PictureAccessor();
        }

        /// <summary>
        ///  Creator: Rasha Mohammed
        ///  Created: 4/1/2020
        ///  Approver: Ethan Holmes
        ///  
        ///  Constructor for passing specific Accessor class
        ///  
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="pictureAccessor"></param>
        public PictureManager(IPictureAccessor pictureAccessor)
        {
            _pictureAccessor = pictureAccessor;
        }

        /// /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Calls relevent Data Access Layer functionality to add a picture to the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="picture"></param>
        /// <returns></returns>
        public bool AddPicture(Picture picture)
        {
            bool result = false;

            try
            {
                result = (1 == _pictureAccessor.InsertPicture(picture));
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        ///  Creator: Rasha Mohammed
        ///  Created: 4/1/2020
        ///  Approver: Ethan Holmes
        ///  
        ///  Method that retrieve all picture 
        ///  
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="pictureAccessor"></param>
        public List<Picture> RetrieveAllPictures()
        {
            List<Picture> result = null;
            try
            {

                result = _pictureAccessor.SelectAllPicture();


            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);

            }
            return result;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Returns most recently uploaded picture associated with the provided productID.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="productID"></param>
        /// <returns></returns>
        public Picture RetrieveMostRecentPictureByProductID(string productID)
        {
            List<Picture> pictures;
            try
            {
                pictures = RetrievePicturesByProductID(productID);
            }
            catch (Exception)
            {
                throw;
            }
            var picture = pictures.OrderByDescending(p => p.PictureID).FirstOrDefault(pic => pic.ProductID.Equals(productID));

            return picture;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Calls relevent data access layer functionality to return a list of pictures associated with the provided productID.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<Picture> RetrievePicturesByProductID(string productID)
        {
            List<Picture> result = null;
            try
            {
                result = _pictureAccessor.SelectAllPicturesByProductID(productID);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}

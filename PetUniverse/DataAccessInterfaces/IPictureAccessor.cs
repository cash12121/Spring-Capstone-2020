using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{/// <summary>
 /// Creator: Rasha Mohammed
 /// Created: 4/1/2020
 /// Approver: Ethan Holmes
 /// 
 /// Interface for picture data accessor to facilitate loose coupling.
 /// </summary>
 /// <remarks>
 /// Updater:
 /// Updated: 
 /// Update: 
 /// 
 /// </remarks>
    public interface IPictureAccessor
    {
        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// DATE: 4/1/2020
        /// APPROVER: Ethan Holmes
        ///
        /// Interface method signature for Selecting all picyures by ProductCategoryID
        ///
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns List of Picture</returns>
        //List<Picture> SelectAllPictureByProductCategoryID(string productCategoryID);

        List<Picture> SelectAllPicture();

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to return all pictures associated with a product id.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="productID"></param>
        /// <returns></returns>
        List<Picture> SelectAllPicturesByProductID(string productID);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to add a picture.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        int InsertPicture(Picture picture);
    }
}

using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// CREATOR: Rasha Mohammed
    /// DATE: 04/1/2020
    /// APPROVER: Ethan Holmes
    /// 
    /// Interface outlines the requirements for the Picture Manager class.
    /// </summary>
    /// <remarks>
    /// Updater: Robert Holmes
    /// Updated: 04/29/2020
    /// Update: Added new method signatures.
    /// </remarks>
    public interface IPictureManager
    {
        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// DATE: 04/1/2020
        /// APPROVER: Ethan Holmes
        /// 
        /// Interface to retrieve all pictures.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        List<Picture> RetrieveAllPictures();

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to return the most recently uploaded picture associated with the supplied productID.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="productID"></param>
        /// <returns></returns>
        Picture RetrieveMostRecentPictureByProductID(string productID);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to retrieve all pictures associated with the supplied productID.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="productID"></param>
        /// <returns></returns>
        List<Picture> RetrievePicturesByProductID(string productID);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to add a picture to the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="picture"></param>
        /// <returns></returns>
        bool AddPicture(Picture picture);
    }
}

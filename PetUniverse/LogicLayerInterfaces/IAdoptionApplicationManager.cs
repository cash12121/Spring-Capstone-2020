using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/19/2020
    /// CHECKED BY: Michael Thompson
    /// 
    /// Interface adoption application methods
    /// </summary>

    public interface IAdoptionApplicationManager
    {

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/28/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Add an adoption application to the database
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        bool AddAdoptionApplication(Application application);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/1/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Retrieves adoption applications by active from the data access layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        List<ApplicationVM> RetrieveAdoptionApplicationsByActive(bool active = true);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Retrieves adoption applications by email from the data access layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        List<ApplicationVM> RetrieveAdoptionApplicationsByEmailAndActive(string email, bool active = true);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/11/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Retrieves adoption applications by id
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns></returns>
        ApplicationVM RetrieveAdoptionApplicationByID(int adoptionApplicationID);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/22/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Deactivates an adoption application by id
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns></returns>
        bool DeactivateAdoptionApplication(int adoptionApplicationID);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/1/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Updates an adoption application
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="oldApplication"></param>
        /// <param name="newApplication"></param>
        /// <returns></returns>
        bool UpdateAdoptionApplication(Application oldApplication, Application newApplication);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/4/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// selects a list of adoption applications
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        List<ApplicationNameVM> RetrieveAdoptionApplicationsByActiveWithName(bool active);
    }
}

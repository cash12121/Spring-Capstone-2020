using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{

    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/18/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Interface that contains methods that relate to adoption application
    /// data access methods
    /// </summary>
    public interface IAdoptionApplicationAccessor
    {

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/28/2020
        /// Approver: Michael Thompson
        /// 
        /// inserts an adoption application into the database
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="application"></param>
        /// <returns></returns>
        int InsertAdoptionApplication(Application application);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 5/2/2020
        /// Approver: Michael Thompson
        /// 
        /// selects a list of ApplicationNameVMs by active including the first and last names
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        List<ApplicationNameVM> SelectAdoptionApplicationsByActiveWithName(bool active);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 5/2/2020
        /// Approver: Michael Thompson
        /// 
        /// selects a list of ApplicationVMs by active
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        List<ApplicationVM> SelectAdoptionApplicationsByActive(bool active);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/18/2020
        /// Approver: Thomas Dupuy
        /// 
        /// selects a list of ApplicationVMs by on Email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<ApplicationVM> SelectAdoptionApplicationsByEmail(string email, bool active);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/18/2020
        /// Approver: Michael Thompson
        /// 
        /// selects an ApplicationVM by on Email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        ApplicationVM SelectAdoptionApplicationByID(int adoptionApplicationID);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/22/2020
        /// Approver: Michael Thompson
        /// 
        /// selects an ApplicationVM by on Email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns></returns>
        int DeactivateAdoptionApplication(int adoptionApplicationID);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 5/2/2020
        /// Approver: Michael Thompson
        /// 
        /// Updates an application
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="oldApplication"></param>
        /// <param name="newApplication"></param>
        /// <returns></returns>
        int UpdateAdoptionApplication(Application oldApplication, Application newApplication);


    }
}

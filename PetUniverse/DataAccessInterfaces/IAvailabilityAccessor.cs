using DataTransferObjects;
using System.Collections.Generic;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/15
///  APPROVER: Lane Sandburg
///  
///  Interface for AvailabilityAccessor
/// </summary>
namespace DataAccessInterfaces
{
    public interface IAvailabilityAccessor
    {
        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/14
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for getting a list of all Users' Availabilities
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        List<EmployeeAvailability> SelectAllUsersAvailability();

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/03/28
        /// Approver: Kaleb Bachert: 
        /// 
        /// Interface method for selecting all avalabilites
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        List<EmployeeAvailability> SelectAllAvailabilities();
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/03/28
        /// Approver: Kaleb Bachert: 
        /// 
        /// Interface method for slecting availbilites by User ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<AvailabilityVM> SelectAvailabilityByUserID(int userID);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/03/28
        /// Approver: Kaleb Bachert: 
        /// 
        /// Interface method for updating Availability 
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="newAvailability"></param>
        /// <param name="oldAvailability"></param>
        /// <returns></returns>
        int UpdateAvailability(EmployeeAvailability newAvailability, EmployeeAvailability oldAvailability);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/03/28
        /// Approver: Kaleb Bachert: 
        /// 
        /// Interface method for activating availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="availabilityID"></param>
        /// <returns></returns>
        int ActivateAvailability(int availabilityID);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/03/28
        /// Approver: Kaleb Bachert: 
        /// 
        /// Interface method deactivating availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="availabilityID"></param>
        /// <returns></returns>
        int DeactivateAvailability(int availabilityID);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/03/28
        /// Approver: Kaleb Bachert: 
        /// 
        /// Interface method for inserting availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="availability"></param>
        /// <returns></returns>
        int InsertAvailability(EmployeeAvailability availability);
    }
}

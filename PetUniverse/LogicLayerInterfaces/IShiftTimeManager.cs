using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Lane Sandburg
    /// Created: 02/05/2019
    /// Approver: Alex Diers
    /// 
    /// Interface for shift time logic
    /// </summary>
    public interface IShiftTimeManager
    {

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// defenition for adding a shift time,
        /// returns true/false if shift time was added
        /// takes a shift time as a parameter.
        /// </summary>
        /// <remarks>
        /// Updater:NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <param name="shiftTime"></param>
        bool AddShiftTime(PetUniverseShiftTime shiftTime);

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 03/05/2019
        /// Approver: Kaleb Bachert
        /// 
        /// defenition for deactivating a shift time,
        /// returns true/false if shift time was deleted
        /// takes a shift time ID as a parameter.
        /// </summary>
        /// <remarks>
        /// Updater: Lane Sandburg
        /// Updated: 05/05/2020
        /// Update: Refactored to Deavtivate Shift Time
        /// </remarks> 
        /// <param name="shiftTime"></param>
        bool DeactivateShiftTime(int shiftTimeID);

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// defenition for editing a shift time,
        /// returns true/false if shift time was added
        /// takes a shift time as a parameter.
        /// </summary>
        /// <remarks>
        /// Updater:NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <param name="oldShiftTime"></param>
        /// <param name="newShiftTime"></param>

        bool EditShiftTime(PetUniverseShiftTime oldShiftTime, PetUniverseShiftTime newShiftTime);

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// defenition for retrieving all shift times,
        /// returns true/false if shift time was added
        /// takes a shift time as a parameter.
        /// </summary>
        /// <remarks>
        /// Updater:NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 

        List<PetUniverseShiftTime> RetrieveShiftTimes();


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// This is an interface method for selecting shift times by department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        List<PetUniverseShiftTime> RetrieveShiftTimesByDepartment(string departmentID);


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: 
        /// 
        /// This is an interface method for selecting shift times by id.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        PetUniverseShiftTime RetrieveShiftTimeByID(int shiftID);
    }
}

using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Timothy Lickteig
    /// Contributors: Kaleb Bachert
    /// Created: 02/05/2020
    /// Approver: Zoey McDonald
    /// 
    /// Interface for accessing the database for shift records
    /// </summary>
    public interface IVolunteerShiftAccessor
    {

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 02/17/2020
        /// Approver: Zoey McDonald
        /// 
        /// Method to get all shifts
        /// </summary>  
        /// <remarks>
        /// Updater: N/A
        /// Update: N/A
        /// Updated: N/A
        /// </remarks>
        /// <returns>A list of shifts from the database</returns>
        List<VolunteerShiftVM> SelectAllShifts();

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 03/01/2020
        /// Approver: Zoey McDonald
        /// 
        /// Data Access Method to get shifts for a volunteer
        /// </summary> 
        /// <remarks>
        /// Updater: N/A
        /// Update: N/A
        /// Updated: N/A
        /// </remarks>
        /// <param name="volunteerID">The volunteerID to query</param>
        /// <returns>A list of shifts from the database</returns>
        List<VolunteerShiftVM> SelectAllShiftsForAVolunteer(int volunteerID);

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Creator: 03/01/2020
        /// Approver: Zoey McDonald
        /// 
        /// Data Access Method to select a shift
        /// </summary>  
        /// <remarks>
        /// Updater: N/A
        /// Update: N/A
        /// Updated: N/A
        /// </remarks>
        /// <param name="shiftID">The shiftID to query</param>
        /// <returns>A shift from the database</returns>
        VolunteerShiftVM SelectShift(int shiftID);

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 02/10/2020
        /// Approver: Zoey McDonald
        /// 
        /// Method for editing a shift inside the DB
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Update: N/A
        /// Updated: N/A
        /// </remarks>
        /// <param name="oldShift">The shift to be updated</param>
        /// <param name="newShift">The new shift</param>
        /// <returns>Number of rows affected</returns>
        int UpdateShift(VolunteerShiftVM oldShift, VolunteerShiftVM newShift);

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 02/05/2020
        /// Approver: Zoey McDonald
        /// 
        /// Method for removing a shift from the DB
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Update: N/A
        /// Updated: N/A
        /// </remarks>
        /// <param name="shiftID">ShiftID to be removed</param>
        /// <returns>Number of rows affected</returns>
        int RemoveShift(int shiftID);

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 02/07/2020
        /// Approver: Zoey McDonald
        /// 
        /// Method for adding a shift to the DB
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Update: N/A
        /// Updated: N/A
        /// </remarks>
        /// <param name="shift">Shift Object to be added</param>
        /// <returns>Number of rows affected</returns>
        int AddShift(VolunteerShiftVM shift);

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 03/02/2020
        /// Approver: Zoey McDonald
        /// 
        /// Data Access method to add user to shift
        /// </summary> 
        /// <remarks>
        /// Updater: N/A
        /// Update: N/A
        /// Updated: N/A
        /// </remarks>
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The number of rows affected</returns>
        int SignVolunteerUpForShift(int volunteerID, int volunteerShiftID);

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 03/08/2020
        /// Approver: Zoey McDonald
        /// 
        /// Data Access method to cancel shift
        /// </summary>  
        /// <remarks>
        /// Updater: N/A
        /// Update: N/A
        /// Updated: N/A
        /// </remarks>
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The number of rows affected</returns>
        int CancelVolunteerShift(int volunteerID, int volunteerShiftID);
    }
}
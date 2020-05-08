using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     CONTRIBUTERS: Kaleb Bachert
    ///     DATE: 2020-02-05
    ///     CHECKED BY: Zoey McDonald
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public interface IVolunteerShiftManager
    {
        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="shift">Shift Object to be passed</param>
        /// <returns>Number of rows affected</returns>
        int AddVolunteerShift(VolunteerShiftVM shift);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-08
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="shift">ID of shift to remove</param>
        /// <returns>Number of rows affected</returns>
        int RemoveVolunteerShift(int shiftID);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-10
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="oldShift">Old shift to be replaced</param>
        /// <param name="newShift">Replacement shift</param>
        /// <returns>Number of rows affected</returns>
        int EditVolunteerShift(VolunteerShiftVM oldShift, VolunteerShiftVM newShift);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-02
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The number of rows affected</returns>
        int SignVolunteerUpForShift(int volunteerID, int volunteerShiftID);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-08
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The number of rows affected</returns>
        int CancelVolunteerShift(int volunteerID, int volunteerShiftID);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-01
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="shiftID">The shiftID to query</param>
        /// <returns>A list of shifts</returns>
        VolunteerShiftVM SelectVolunteerShift(int shiftID);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-17
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <returns>A list of availible shifts</returns>
        List<VolunteerShiftVM> ReturnAllVolunteerShifts();

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-01
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteer ID number</param>
        /// <returns>A list of shifts</returns>
        List<VolunteerShiftVM> ReturnAllVolunteerShiftsForAVolunteer(int volunteerID);
    }
}

using DataTransferObjects;
using System;
using System.Collections.Generic;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/3/31
///  APPROVER: Lane Sandburg
///  
///  Interface for ShiftAccessor
/// </summary>
namespace DataAccessInterfaces
{
    public interface IShiftAccessor
    {
        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/3/31
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for getting the scheduled Shifts for a User
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        List<ShiftVM> SelectShiftsByUser(int userID);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/14
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for getting a list of Shifts on a given day
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="date"></param>
        List<ShiftVM> SelectShiftsByDay(DateTime date);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for getting a the hours a User works in a given schedule
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// <param name="userID"></param>
        /// <param name="dateInSchedule"></param>
        ScheduleWithHoursWorked SelectScheduleHoursByUserAndDate(int userID, DateTime dateInSchedule);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for updating the user working on a specified shift
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// <param name="shiftID"></param>
        /// <param name="newUserWorking"></param>
        /// <param name="oldUserWorking"></param>
        int UpdateShiftUserWorking(int shiftID, int newUserWorking, int oldUserWorking);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for updating the user working on a specified shift
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// <param name="userID"></param>
        /// <param name="scheduleID"></param>
        /// <param name="weekNumber"></param>
        /// <param name="changeAmount"></param>
        int UpdateEmployeeHoursWorked(int userID, int scheduleID, int weekNumber, double changeAmount);

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/05
        /// Approver: Kaleb Bachert
        /// 
        /// interface method for selecting all shifts's details
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <returns></returns>
        List<ShiftDetailsVM> SelectAllShiftsDetailsByUserID(int userID);

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/05
        /// Approver: Kaleb Bachert
        /// 
        /// interface method for selecting a shift's details by id
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="shiftID"></param>
        /// <returns></returns>
        ShiftDetailsVM SelectShiftDetailsByID(int shiftID);

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 4/26/2020
        /// Approver:
        /// 
        /// interface method to retrieve shifts by department, userid, and schedule id
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="scheduleID"></param>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        List<ShiftUserVM> SelectShiftsByScheduleAndDepartmentID(int scheduleID, string departmentID);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 4/26/2020
        /// Approver:
        /// 
        /// interface method to retrieve shifts by department, and schedule id
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="scheduleID"></param>
        /// <param name="departmentID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        List<ShiftUserVM> SelectShiftsByScheduleAndDepartmentIDWithDate(int scheduleID, string departmentID, DateTime date);
    }
}

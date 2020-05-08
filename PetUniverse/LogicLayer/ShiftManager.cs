using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/1
///  APPROVER: Lane Sandburg
///  
///  Manager Class for Shifts
/// </summary>
namespace LogicLayer
{
    public class ShiftManager : IShiftManager
    {
        private IShiftAccessor _shiftAccessor;

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/1
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Default Constructor for instantiating Accessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public ShiftManager()
        {
            _shiftAccessor = new ShiftAccessor();
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/1
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Constructor for passing specific Accessor class
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="shifttAccessor"></param>

        public ShiftManager(IShiftAccessor shiftAccessor)
        {
            _shiftAccessor = shiftAccessor;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/1
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method calls the SelectShiftsByUser method from the Accessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<ShiftVM> RetrieveShiftsByUser(int userID)
        {
            try
            {
                return _shiftAccessor.SelectShiftsByUser(userID);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Shifts not found.", ex);
            }
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method calls the SelectScheduleHoursByUserAndDate method from the Accessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="dateInSchedule"></param>
        /// <returns></returns>
        public ScheduleWithHoursWorked RetrieveScheduleHoursByUserAndDate(int userID, DateTime dateInSchedule)
        {
            try
            {
                return _shiftAccessor.SelectScheduleHoursByUserAndDate(userID, dateInSchedule);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Hours Worked Not Found.", ex);
            }
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method calls the UpdateEmployeeHoursWorked method from the Accessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="scheduleID"></param>
        /// <param name="weekNumber"></param>
        /// <param name="changeAmount"></param>
        /// <returns></returns>
        public bool EditEmployeeHoursWorked(int userID, int scheduleID, int weekNumber, double changeAmount)
        {
            try
            {
                return 1 == _shiftAccessor.UpdateEmployeeHoursWorked(userID, scheduleID, weekNumber, changeAmount);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not added.", ex);
            }
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method calls the UpdateShiftUserWorking method from the Accessor
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="shiftID"></param>
        /// <param name="newUserWorking"></param>
        /// <param name="oldUserWorking"></param>
        /// <returns></returns>
        public bool EditShiftUserWorking(int shiftID, int newUserWorking, int oldUserWorking)
        {
            try
            {
                return 1 == _shiftAccessor.UpdateShiftUserWorking(shiftID, newUserWorking, oldUserWorking);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not added.", ex);
            }
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/05
        /// Approver: Kaleb Bachert
        /// 
        /// check if shift details retireved by shift ID returns a list
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="shiftID"></param>
        /// <returns></returns>
        public ShiftDetailsVM RetrieveShfitDetailsByID(int shiftID)
        {
            try
            {
                return _shiftAccessor.SelectShiftDetailsByID(shiftID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Shifts not found", ex);
            }
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/05
        /// Approver: Kaleb Bachert
        /// 
        /// check if shift details retireved by shift ID returns a list
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<ShiftDetailsVM> RetrieveShfitDetailsByUserID(int UserID)
        {
            try
            {
                return _shiftAccessor.SelectAllShiftsDetailsByUserID(UserID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Shifts not found", ex);
            }
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 4/26/2020
        /// Approver: Kaleb Bachert
        /// 
        /// method retrieve shifts by department, and schedule id
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
        public List<ShiftUserVM> RetrieveShiftsByScheduleAndDepartmentID(int scheduleID, string departmentID)
        {
            try
            {
                return _shiftAccessor.SelectShiftsByScheduleAndDepartmentID(scheduleID, departmentID);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Hours Worked Not Found.", ex);
            }
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 4/26/2020
        /// Approver: Kaleb Bachert
        /// 
        /// method retrieve shifts by department, date, and schedule id
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
        public List<ShiftUserVM> RetrieveShiftsByScheduleAndDepartmentIDWithDate(int scheduleID, string departmentID, DateTime date)
        {
            try
            {
                return _shiftAccessor.SelectShiftsByScheduleAndDepartmentIDWithDate(scheduleID, departmentID, date);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Hours Worked Not Found.", ex);
            }
        }
    }
}

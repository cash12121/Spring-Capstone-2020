using DataAccessFakes;
using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     CONTRIBUTERS: Kaleb Bachert
    ///     DATE: 2020-02-05
    ///     CHECKED BY: Zoey McDonald
    ///     Class for managing available volunteer shifts
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public class VolunteerShiftManager : IVolunteerShiftManager
    {
        IVolunteerShiftAccessor _accessor;

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <returns>VolunteerShiftManager object</returns>
        public VolunteerShiftManager()
        {
            _accessor = new VolunteerShiftAccessor();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="accessor">Data Access object</param>
        /// <returns>VolunteerShiftManager object</returns>
        public VolunteerShiftManager(IVolunteerShiftAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="shift">Shift Object to be passed</param>
        /// <returns>Number of rows affected</returns>
        public int AddVolunteerShift(VolunteerShiftVM shift)
        {
            int rows = 0;
            try
            {
                rows = _accessor.AddShift(shift);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-08
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="shift">ID of shift to remove</param>
        /// <returns>Number of rows affected</returns>
        public int RemoveVolunteerShift(int shiftID)
        {
            int rows = 0;
            try
            {
                rows = _accessor.RemoveShift(shiftID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-10
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="oldShift">Old shift to be replaced</param>
        /// <param name="newShift">Replacement shift</param>
        /// <returns>Number of rows affected</returns>
        public int EditVolunteerShift(VolunteerShiftVM oldShift, VolunteerShiftVM newShift)
        {
            int rows = 0;
            try
            {
                rows = _accessor.UpdateShift(oldShift, newShift);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rows;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-17
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <returns>A list of availible shifts</returns>
        public List<VolunteerShiftVM> ReturnAllVolunteerShifts()
        {
            List<VolunteerShiftVM> shifts = new List<VolunteerShiftVM>();

            try
            {
                shifts = _accessor.SelectAllShifts();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return shifts;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-01
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="shiftID">The shiftID to query</param>
        /// <returns>A list of shifts</returns>
        public VolunteerShiftVM SelectVolunteerShift(int shiftID)
        {
            try
            {
                return _accessor.SelectShift(shiftID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-01
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteer ID number</param>
        /// <returns>A list of shifts</returns>
        public List<VolunteerShiftVM> ReturnAllVolunteerShiftsForAVolunteer(int volunteerID)
        {
            try
            {
                return _accessor.SelectAllShiftsForAVolunteer(volunteerID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-02
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The number of rows affected</returns>
        public int SignVolunteerUpForShift(int volunteerID, int volunteerShiftID)
        {
            try
            {
                return _accessor.SignVolunteerUpForShift(volunteerID, volunteerShiftID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-08
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The number of rows affected</returns>
        public int CancelVolunteerShift(int volunteerID, int volunteerShiftID)
        {
            try
            {
                return _accessor.CancelVolunteerShift(volunteerID, volunteerShiftID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

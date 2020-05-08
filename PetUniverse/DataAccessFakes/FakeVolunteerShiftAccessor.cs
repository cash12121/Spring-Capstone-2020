using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Timothy Lickteig
    /// Contributor: Kaleb Bachert
    /// Created: 02/05/2020
    /// Approver: Zoey McDonald
    /// 
    /// Class for emulating an actual data access class for volunteer shifts
    /// </summary>
    public class FakeVolunteerShiftAccessor : IVolunteerShiftAccessor
    {
        private List<VolunteerShiftVM> _volunteerShifts = new List<VolunteerShiftVM>();

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 02/05/2020
        /// Approver: Zoey McDonald
        /// 
        /// Main constructor for the class
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        public FakeVolunteerShiftAccessor()
        {
            _volunteerShifts.Add(new VolunteerShiftVM()
            {
                VolunteerShiftID = 1,
                VolunteerID = 1,
                ShiftTitle = "Custodian",
                IsSpecialEvent = false,
                VolunteerShiftDate = DateTime.Now,
                ScheduleID = 1,
                ShiftNotes = "Blah blah blah",
                VolunteerTaskID = 1,
                Recurrance = "Once",
                ShiftDescription = "Let's clean everything",
                ShiftStartTime = TimeSpan.Zero,
                ShiftEndTime = TimeSpan.Zero + TimeSpan.Parse("6")
            });

            _volunteerShifts.Add(new VolunteerShiftVM()
            {
                VolunteerShiftID = 2,
                VolunteerID = 1,
                ShiftTitle = "Veterinarian",
                IsSpecialEvent = false,
                VolunteerShiftDate = DateTime.Now,
                ScheduleID = 1,
                ShiftNotes = "Blah blah blah",
                VolunteerTaskID = 1,
                Recurrance = "Once",
                ShiftDescription = "Let's heal everything",
                ShiftStartTime = TimeSpan.Zero,
                ShiftEndTime = TimeSpan.Zero + TimeSpan.Parse("6")
            });
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 02/05/2020
        /// Approver: Zoey McDonald
        /// 
        /// Fake add shift method
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks> 
        /// <param name="shift">Volunteer shift to be added</param>
        /// <returns>The number of rows affected</returns>
        public int AddShift(VolunteerShiftVM shift)
        {
            _volunteerShifts.Add(shift);
            return 1;
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 02/05/2020
        /// Approver: Zoey McDonald
        /// 
        /// Fake method to cancel
        /// </summary>        
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The number of rows affected</returns>
        public int CancelVolunteerShift(int volunteerID, int volunteerShiftID)
        {
            foreach (VolunteerShiftVM shift in _volunteerShifts)
            {
                if (volunteerShiftID == shift.VolunteerShiftID)
                {
                    shift.VolunteerID = 0;
                }
            }
            return 1;
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 02/05/2020
        /// Approver: Zoey McDonald
        /// 
        /// Fake to move a shift
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="shift">ID of the Volunteer shift to remove</param>
        /// <returns>The number of rows affected</returns>
        public int RemoveShift(int shiftID)
        {
            int rows = 0;
            VolunteerShiftVM shiftToRemove = new VolunteerShiftVM();

            foreach (VolunteerShiftVM shift in _volunteerShifts)
            {
                if (shiftID == shift.VolunteerShiftID)
                {
                    shiftToRemove = shift;
                    rows++;
                }
            }
            _volunteerShifts.Remove(shiftToRemove);
            return rows;
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 02/17/2020
        /// Approver: Zoey McDonald
        /// 
        /// Fake to get all shifts
        /// </summary>  
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <returns>A list of shifts from the list</returns>
        public List<VolunteerShiftVM> SelectAllShifts()
        {
            return _volunteerShifts;
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 02/03/2020
        /// Approver: Zoey McDonald
        /// 
        /// Fake to select all volunteer shifts
        /// </summary>  
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="volunteerID">The volunteerID to query</param>
        /// <returns>A list of shifts from the emulated database</returns>
        public List<VolunteerShiftVM> SelectAllShiftsForAVolunteer(int volunteerID)
        {
            List<VolunteerShiftVM> tempList = new List<VolunteerShiftVM>();

            foreach (VolunteerShiftVM shift in _volunteerShifts)
            {
                if (shift.VolunteerID == volunteerID)
                {
                    tempList.Add(shift);
                }
            }
            return tempList;
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 01/03/2020
        /// Approver: Zoey McDonald
        /// 
        /// Fake select shift method
        /// </summary>   
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="shiftID">The shiftID to query</param>
        /// <returns>A shift from the emulated database</returns>
        public VolunteerShiftVM SelectShift(int shiftID)
        {
            VolunteerShiftVM shift = new VolunteerShiftVM();

            foreach (VolunteerShiftVM shift2 in _volunteerShifts)
            {
                if (shift2.VolunteerShiftID == shiftID)
                {
                    shift = shift2;
                }
            }
            return shift;
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 02/03/2020
        /// Approver: Zoey McDonald
        /// 
        /// Fake to sign volunteer up for shift
        /// </summary> 
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The simluated number of rows affected</returns>
        public int SignVolunteerUpForShift(int volunteerID, int volunteerShiftID)
        {
            foreach (VolunteerShiftVM shift in _volunteerShifts)
            {
                if (volunteerShiftID == shift.VolunteerShiftID)
                {
                    shift.VolunteerID = volunteerID;
                }
            }
            return 1;
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 02/10/2020
        /// Approver: Zoey McDonald
        /// 
        /// Fake to update shift
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="oldShift">Old shift to be replaced</param>
        /// <param name="newShift">New shift as replacement</param>
        /// <returns>The number of rows affected</returns>
        public int UpdateShift(VolunteerShiftVM oldShift, VolunteerShiftVM newShift)
        {
            int rows = 0;
            int index = 0;

            foreach (VolunteerShiftVM tempShift in _volunteerShifts)
            {
                if (tempShift.VolunteerShiftID == oldShift.VolunteerShiftID)
                {
                    rows = 1;
                    break;
                }
                index++;
            }

            if (rows == 1)
            {
                _volunteerShifts[index] = newShift;
            }
            return rows;
        }
    }
}

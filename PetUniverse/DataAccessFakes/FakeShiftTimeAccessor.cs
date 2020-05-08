using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Lane Sandburg
    /// Created: 02/05/2020
    /// Approver: Alex Diers
    /// 
    /// the fake class for shift time accessor
    /// </summary>
    public class FakeShiftTimeAccessor : IShiftTimeAccessor
    {
        private List<PetUniverseShiftTime> shiftTimes;
        private List<PetUniverseShiftTime> managementShiftTimes;

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2020
        /// Approver: Alex Diers
        /// </summary>
        /// <remarks>
        /// Updater: Jordan Lindo
        /// Updated: 4/23/2020
        /// Update: Added ManagementShiftTimes.
        /// 
        /// Updater: Alex Diers
        /// Updated: 5/5/2020
        /// Update: Updated the date created to the correct year
        /// </remarks>

        public FakeShiftTimeAccessor()
        {
            shiftTimes = new List<PetUniverseShiftTime>()
            {
                new PetUniverseShiftTime()
                {
                    ShiftTimeID = 100001,
                    DepartmentID = "Sales",
                    StartTime = "08:45:00",
                    EndTime = "5:45:00"
                }
            };

            managementShiftTimes = new List<PetUniverseShiftTime>
            {
                new PetUniverseShiftTime()
                {
                    ShiftTimeID = 100002,
                    DepartmentID = "Management",
                    StartTime = "06:00",
                    EndTime = "14:30"
                }
            };
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 03/05/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Fake Logic for deleting a shift time
        /// </summary>
        /// <remarks>
        /// Updater: Alex Diers
        /// Updated: 5/5/2020
        /// Update: Added param and returns tags and updated 
        ///     the date created to correct year
        /// </remarks>
        /// <param name="shiftTimeID"></param>
        /// <returns></returns>
        public int DeactivateShiftTime(int shiftTimeID)
        {
            int result = 1;
            PetUniverseShiftTime shiftTime = null;
            foreach (var s in shiftTimes)
            {
                if (shiftTimeID == s.ShiftTimeID)
                {
                    shiftTime = s;
                }
            }

            if (shiftTime == null)
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2020
        /// Approver: Alex Diers
        /// 
        /// Fake Logic for inserting a shift time
        /// </summary>
        /// <remarks>
        /// Updater: Alex Diers
        /// Updated: 5/5/2020
        /// Update: Added param and returns tags and updated
        ///     the date created to the correct year
        /// </remarks> 
        /// <param name="shiftTime"></param>
        /// <returns></returns>
        public int InsertShiftTime(PetUniverseShiftTime shiftTime)
        {
            int result = 0;
            PetUniverseShiftTime newShiftTime = new PetUniverseShiftTime();
            newShiftTime = shiftTime;

            try
            {
                shiftTimes.Add(newShiftTime);
                result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2020
        /// Approver: Alex Diers
        /// 
        /// Fake Logic for selecting all shift times
        /// </summary>
        /// <remarks>
        /// Updater: Alex Diers
        /// Updated: 5/5/2020
        /// Update: Updated the date created to the correct year
        /// </remarks> 
        public List<PetUniverseShiftTime> SelectAllShiftTimes()
        {
            return (from s in shiftTimes
                    select s).ToList();
        }


        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/13/2020
        /// Approver: Alex Diers
        /// 
        /// Fake Logic for updating a shift time
        /// </summary>
        /// <remarks>
        /// Updater: Alex Diers
        /// Updated: 5/5/2020
        /// Update: Added param and returns tags and updated
        ///     the date created to the correct year
        /// </remarks> 
        /// <param name="oldShiftTime"></param>
        /// <param name="newShiftTime"></param>
        /// <returns></returns>
        public int UpdateShiftTime(PetUniverseShiftTime oldShiftTime, PetUniverseShiftTime newShiftTime)
        {
            int result = 0;
            PetUniverseShiftTime ShiftTime = oldShiftTime;

            try
            {
                oldShiftTime = newShiftTime;
                result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a method for selecting shift times by department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public List<PetUniverseShiftTime> SelectShiftTimeByDepartment(string departmentID)
        {
            List<PetUniverseShiftTime> times = new List<PetUniverseShiftTime>();

            foreach (PetUniverseShiftTime time in shiftTimes)
            {
                if (time.DepartmentID.Equals(departmentID))
                {
                    times.Add(time);
                }
            }
            return times;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/16/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a method for selecting shift times by id.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="shiftTimeID"></param>
        /// <returns></returns>
        public PetUniverseShiftTime SelectShiftTimeByID(int shiftTimeID)
        {
            PetUniverseShiftTime shiftTime = new PetUniverseShiftTime();
            foreach (PetUniverseShiftTime s in shiftTimes)
            {
                if (shiftTimeID == s.ShiftTimeID)
                {
                    shiftTime = s;
                }
            }
            foreach (PetUniverseShiftTime s in managementShiftTimes)
            {
                if (shiftTimeID == s.ShiftTimeID)
                {
                    shiftTime = s;
                }
            }

            return shiftTime;
        }
    }
}


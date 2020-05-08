using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 4/23/2020
    /// Approver: Chase Schulte
    /// 
    /// Test class for Schedule hours.
    /// </summary>
    public class FakeScheduleHoursAccessor : IScheduleHoursAccessor
    {
        private List<PUUserVMHours> _pUUserVMHours;

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// Constructor method for 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public FakeScheduleHoursAccessor()
        {
            _pUUserVMHours = new List<PUUserVMHours>();
        }


        public int InsertAllScheduleHours(int scheduleID, List<PUUserVMHours> employees)
        {
            int count = 0;
            foreach (PUUserVMHours employee in employees)
            {
                _pUUserVMHours.Add(employee);
                count++;
            }
            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 4/2/2020
    /// Approver: 
    /// 
    /// A VM for displaying start time and end time of a shift in a base schedule line
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    public class BaseScheduleLineVM : BaseScheduleLine
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}

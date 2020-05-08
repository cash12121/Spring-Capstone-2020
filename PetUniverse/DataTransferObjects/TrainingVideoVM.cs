using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Alex Diers
    /// Created: 3/10/2020
    /// Approver: Chase Schulte
    /// 
    /// Defines a TrainingVideoVM object for viewing videos by employee
    /// </summary>
    /// 
    /// <remarks>
    /// Updater 
    /// Updated:
    /// Update: 
    /// </remarks>
    public class TrainingVideoVM : TrainingVideo
    {
        public bool IsWatched { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

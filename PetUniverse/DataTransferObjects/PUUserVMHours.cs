using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 4/15/2020
    /// Approver: Chase Schulte
    /// 
    /// A user hours vm for scheduling.
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class PUUserVMHours : PetUniverseUser
    {
        public decimal Week1Hours { get; set; }
        public decimal Week2Hours { get; set; }
    }
}

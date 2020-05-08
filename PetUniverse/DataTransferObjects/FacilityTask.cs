using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 4/9/2020
    /// Approver: Ben Hanna, 4/10/20
    /// Approver: 
    /// 
    /// A class to store data for the Facility Task Fields
    /// </summary>
    public class FacilityTask
    {
        public int FacilityTaskID { get; set; }
        public string FacilityTaskName { get; set; }
        public int UserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string FacilityTaskNotes { get; set; }
        public bool TaskCompleted { get; set; }
    }
}

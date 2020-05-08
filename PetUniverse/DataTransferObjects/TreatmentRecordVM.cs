using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Zoey McDonald
    /// Created: 3/2/2020
    /// Approver:
    /// 
    /// A treatment record VM data transfer object.
    /// </summary>
    public class TreatmentRecordVM 
    {
        public string FormName { get; set; }

        public string TreatmentDate { get; set; }

        public string TreatmentDescription { get; set; }

        public string Notes { get; set; }

        public string Reason { get; set; }

        public string Urgency { get; set; }
    }
}

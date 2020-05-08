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
    /// A treatment record data transfer object.
    /// </summary>
    public class TreatmentRecord
    {
        public int TreatmentRecordID { get; set; }

        public string VetID { get; set; }

        public int AnimalID { get; set; }

        public string FormName { get; set; }

        public DateTime TreatmentDate { get; set; }

        public string TreatmentDescription { get; set; }

        public string Notes { get; set; }

        public string Reason { get; set; }

        public int Urgency { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Ethan Holmes
    /// Created: 04/28/2020
    /// Approver: Rasha Mohammed
    /// 
    /// Customer Survey Record Data Object.
    /// </summary>
    ///
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks>
    public class CustomerSurveyVM
    {
        public string customerName { get; set; }
        public string serviceRating { get; set; }
        public string notes { get; set; }
    }
}

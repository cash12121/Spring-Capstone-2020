using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WPFPresentation.Models
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 04/29/2020
    /// Approver: Jaeho Kim
    /// 
    /// Stores lists of strings to filter by.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class FilterViewModel
    {
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<string> Types { get; set; }
        public IEnumerable<string> Brands { get; set; }
    }
}
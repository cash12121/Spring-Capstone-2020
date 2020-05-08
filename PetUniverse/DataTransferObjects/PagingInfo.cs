using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 04/29/2020
    /// Approver: 
    /// 
    /// Holds info relevent to generating pages in the web view.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); } }
    }
}

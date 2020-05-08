using DataTransferObjects;
using System.Collections.Generic;

namespace WPFPresentation.Models
{
    /// <summary>
    /// CREATED BY: Derek Taylor
    /// DATE: 2/14/2020
    /// CHECKED BY: Ryan Morganti
    /// 
    /// This class is the ViewModel of the Applicant List
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// CHANGE: NA
    /// 
    /// </remarks>
    public class ApplicantListViewModel
    {
        /// <summary>
        /// CREATED BY: Derek Taylor
        /// DATE: 2/14/2020
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This class tests the LogManager Class
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        public List<Applicant> Applicants { get; set; }
    }
}
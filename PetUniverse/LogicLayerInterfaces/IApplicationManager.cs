using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 3/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// Interface that contains methods that relate to application
    /// retrieval
    /// </summary>
    public interface IApplicationManager
    {
        /// <summary>
        /// CREATED BY: Derek Taylor
        /// DATE CREATED: 3/14/2020
        /// APPROVED BY: Ryan Morganti
        /// 
        /// Interface for a Logic Layer method that adds an application.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="applicantID"></param>
        /// <param name="JobListingID"></param>
        /// <returns></returns>
        bool AddApplication(int applicantID, int JobListingID);

        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 3/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// Selects all applications by applicant
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="ApplicantID"></param>
        /// <returns></returns>
        List<JobApplication> RetrieveApplicationsByApplicantID(int ApplicantID);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 3/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// Interface that contains methods that relate to application
    /// data access
    /// </summary>
    public interface IApplicationAccessor
    {
        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 3/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// Inserts an application into the database
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="ApplicantID"></param>
        /// <returns></returns>
        int InsertApplication(int ApplicantID, int JobListingID);

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
        List<JobApplication> SelectApplicationsByApplicantID(int ApplicantID);



    }
}

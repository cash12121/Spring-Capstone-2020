using System;
using System.Collections.Generic;
using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 3/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// This class is handles the logic for Applications.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update: 
    /// </remarks>
    public class ApplicationManager : IApplicationManager
    {
        private IApplicationAccessor _applicationAccessor;

        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// No argument Constructor for ApplicationManager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public ApplicationManager()
        {
            _applicationAccessor = new ApplicationAccessor();
        }
        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 3/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This Constructor accesses the fake data for Applicants
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="applicationAccessor"></param>
        public ApplicationManager(IApplicationAccessor applicationAccessor)
        {
            _applicationAccessor = applicationAccessor;
        }
        /// <summary>
        /// CREATED BY: Derek Taylor
        /// DATE CREATED: 3/15/2020
        /// APPROVED BY: Ryan Morganti
        /// 
        /// Method to add a Job Application.
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
        public bool AddApplication(int applicantID, int JobListingID)
        {
            try
            {
                return 1 == _applicationAccessor.InsertApplication(applicantID, JobListingID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Insert Failed", ex);
            }
        }
        /// <summary>
        /// CREATED BY: Derek Taylor
        /// DATE CREATED: 3/15/2020
        /// APPROVED BY: Ryan Morganti
        /// 
        /// Method to retrieve a list of Job Applications for an applicant.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="ApplicantID"></param>
        /// <returns></returns>
        public List<JobApplication> RetrieveApplicationsByApplicantID(int ApplicantID)
        {
            try
            {
                return _applicationAccessor.SelectApplicationsByApplicantID(ApplicantID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }
    }
}

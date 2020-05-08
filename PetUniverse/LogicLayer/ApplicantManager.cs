using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 2/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// This class is handles the logic for Applicants.
    /// </summary>
    /// <remarks>
    /// Updater: Matt Deaton
    /// Updated: 2020-04-11
    /// Update: Added more methods to deal with applicants
    /// </remarks>
    public class ApplicantManager : IApplicantManager
    {
        private IApplicantAccessor _applicantAccessor;

        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// No argument Constructor for ApplicantManager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public ApplicantManager()
        {
            _applicantAccessor = new ApplicantAccessor();
        }
        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
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
        /// <param name="applicantAccessor"></param>
        public ApplicantManager(IApplicantAccessor applicantAccessor)
        {
            _applicantAccessor = applicantAccessor;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/19
        /// Approver: Derek Taylor
        /// 
        /// This method calls the ApplicantAccessor to retrieve all positions at PetUniverse 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public List<JobListing> RetrieveAllPositions()
        {
            try
            {
                return _applicantAccessor.SelectAllJobPositions();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Positions not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This method calls the ApplicantAccessor to retrieve all apllicants
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// 
        /// </summary>        
        /// <returns>List of Applicants</returns>
        public List<Applicant> RetrieveApplicants()
        {
            try
            {
                return _applicantAccessor.SelectAllApplicants();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Method to add a Foster Applicant.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="fosterApplicant"></param>
        /// <returns></returns>
        public bool AddFosterApplicant(Applicant fosterApplicant)
        {
            try
            {
                return 1 == _applicantAccessor.InsertFosterApplicant(fosterApplicant);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Insert Failed", ex);
            }

        }// End AddFosterApplicant

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Logic Layer method that retrieves an applicant by their applicantID.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public Applicant RetrieveApplicantByID(int applicantID)
        {
            Applicant applicant = null;

            try
            {
                applicant = _applicantAccessor.SelectApplicantByID(applicantID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Applicant could not be found.", ex);
            }

            return applicant;
        }// End RetrieveApplicantByID()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-12
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Logic Layer method that Retrieves an applicant  for an 
        /// interview using their applicantID.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="applicantID"></param>
        /// <returns></returns>
        public ApplicantVM RetrieveApplicantForInterview(int applicantID)
        {
            try
            {
                return _applicantAccessor.SelectApplicantForInterview(applicantID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Applicant not found.", ex);
            }
        }// End RetrieveApplicantForInterview()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-12
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Logic Layer method that updates the notes for an interview.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="applicantionID"></param>
        /// <param name="oldNotes"></param>
        /// <param name="newNotes"></param>
        /// <returns></returns>
        public bool EditInterviewNotes(int applicantionID, string oldNotes, string newNotes)
        {
            bool result = false;

            try
            {
                result = (1 == _applicantAccessor.UpdateInterviewNotes(applicantionID, oldNotes, newNotes));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Applicant could not be update.", ex);
            }

            return result;
        }// End EditInterviewNotes()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Logic Layer method that will update home check date by using the applicantID.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="applicantionID"></param>
        /// <param name="oldStatus"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        public bool EditApplicationStatus(int applicantionID, string oldStatus, string newStatus)
        {
            bool result = false;

            try
            {
                result = (1 == _applicantAccessor.UpdateApplicationStatus(applicantionID, oldStatus, newStatus));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Applicant could not be update.", ex);
            }

            return result;
        }// End EditApplicationStatus

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Logic Layer method that will update home check date by using the applicantID.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="applicationID"></param>
        /// <param name="oldDate"></param>
        /// <param name="newDate"></param>
        /// <returns></returns>
        public bool EditHomeCheckDate(int applicationID, DateTime? oldDate, DateTime? newDate)
        {
            bool result = false;

            try
            {
                result = (1 == _applicantAccessor.UpdateHomeCheckDate(applicationID, oldDate, newDate));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Date Change Did Not Occur", ex);
            }

            return result;
        }// End EditHomeCheckDate

    }// End class ApplicantManager : IApplicantManager

}// End namespace LogicLayer

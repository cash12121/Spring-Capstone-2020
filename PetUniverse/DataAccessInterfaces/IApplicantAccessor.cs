using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 2/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// 
    /// Interface for accessing Applicants
    /// </summary>
    /// <remarks>
    /// Updater: Matt Deaton
    /// Updated: 2020-04-16
    /// Update: Added methods to deal with other areas of application process
    /// </remarks>
    public interface IApplicantAccessor
    {

        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// 
        /// Method is used to retrieve all applicant records
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<Applicant> SelectAllApplicants();

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/19
        /// Approver: Derek Taylor
        /// 
        /// 
        /// Method is used to retrieve all Positions at PetUniverse
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<JobListing> SelectAllJobPositions();

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
        int InsertFosterApplicant(Applicant fosterApplicant);

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Method to view an Applicant with a provided ID#.
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
        Applicant SelectApplicantByID(int applicantID);

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-11
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Method used to select an applicant for an interview.
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
        ApplicantVM SelectApplicantForInterview(int applicantID);

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-16
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Method used to update interview notes using an applicantID from the Database.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="applicantID"></param>
        /// <param name="oldNotes"></param>
        /// <param name="newNotes"></param>
        /// <returns></returns>
        int UpdateInterviewNotes(int applicantionID, string oldNotes, string newNotes);

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-16
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Method used to update application status using an applicantID from the Database.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="applicationID"></param>
        /// <param name="oldStatus"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        int UpdateApplicationStatus(int applicationID, string oldStatus, string newStatus);

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-16
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Method used to update home check date using an applicantID from the Database.
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
		int UpdateHomeCheckDate(int applicationID, DateTime? oldDate, DateTime? newDate);
    }// End interface IApplicantAccessor
}
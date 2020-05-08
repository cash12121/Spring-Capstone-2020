using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// CREATE BY: Derek Taylor
    /// DATE: 2/14/2020
    /// CHECKED BY: Ryan Morganti
    /// 
    /// This is the interface for the ApplicantManager
    /// </summary>
    /// <remarks>
    /// Updated By: Matt Deaton
    /// Updated: 2020-04-16
    /// Update: Added interfaces to be used for other Application processes
    /// </remarks>

    public interface IApplicantManager
    {
        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This calls the Applicant Retrieval Data Accessor Method
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns>List of Logs</returns>
        List<Applicant> RetrieveApplicants();

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/19
        /// Approver: Derek Taylor
        /// 
        /// Used to make a call for a list of positions at Pet Universe
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns>List of JobListing</returns>
        List<JobListing> RetrieveAllPositions();

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Interface for a Logic Layer method that adds a foster applicant.
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
        bool AddFosterApplicant(Applicant fosterApplicant);

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Interface for a Logic Layer method that retrieves an applicant by their applicantID
        /// to be used for MVC.
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
        Applicant RetrieveApplicantByID(int applicantID);

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Interface for a Logic Layer method that retrieves an applicant by their applicantID
        /// to be used for an interview.
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
        ApplicantVM RetrieveApplicantForInterview(int applicantID);

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Interface for a Logic Layer method that will update interview notes by using the applicantID.
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
        bool EditInterviewNotes(int applicantionID, string oldNotes, string newNotes);

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Interface for a Logic Layer method that will update application status by using the applicantID.
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
        bool EditApplicationStatus(int applicantionID, string oldStatus, string newStatus);

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Interface for a Logic Layer method that will update home check date by using the applicantID.
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
        bool EditHomeCheckDate(int applicationID, DateTime? oldDate, DateTime? newDate);


    }// End interface IApplicantManager
}

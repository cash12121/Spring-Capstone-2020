using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 2/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// This class is where we can pull fake Applicant Records from
    /// </summary>    
    public class FakeApplicantAccessor : IApplicantAccessor
    {

        private List<Applicant> applicants = null;
        private List<ApplicantVM> _applicants = null;

        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This fake method is called to get a fake ApplicantAccessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns>Fake ApplicantAccessor</returns>
        public FakeApplicantAccessor()
        {
            applicants = new List<Applicant>()
            {
                new Applicant()
                {
                    AddressLineOne = "123 Fake Street",
                    AddressLineTwo = "Apt. 2b",
                    ApplicantID = 1,
                    City = "Faketown",
                    Email = "derek@petuniverse.com",
                    FirstName = "Derek",
                    LastName = "Taylor",
                    MiddleName = "Joel",
                    PhoneNumber = "15555555555",
                    State = "IA",
                    Zipcode = "55555"
                },

                new Applicant()
                {
                    AddressLineOne = "123 Fake Street",
                    AddressLineTwo = "Apt. 2b",
                    ApplicantID = 1,
                    City = "Faketown",
                    Email = "ryan@petuniverse.com",
                    FirstName = "Ryan",
                    LastName = "Morganti",
                    MiddleName = "Bill",
                    PhoneNumber = "15555555555",
                    State = "IA",
                    Zipcode = "55555"
                },

                new Applicant()
                {
                    AddressLineOne = "123 Fake Street",
                    AddressLineTwo = "Apt. 2b",
                    ApplicantID = 1,
                    City = "Faketown",
                    Email = "matt@petuniverse.com",
                    FirstName = "Matt",
                    LastName = "Deaton",
                    MiddleName = "Franklin",
                    PhoneNumber = "15555555555",
                    State = "IA",
                    Zipcode = "55555"
                }
            };

            _applicants = new List<ApplicantVM>()
            {
                new ApplicantVM
                {
                    FirstName = "Dwight",
                    MiddleName = "Kurt",
                    LastName = "Schrute",
                    Email = "beetfarmer78@aol.com",
                    PhoneNumber = "16415210932",
                    AddressLineOne = "3142 Schrute Farms Road",
                    AddressLineTwo = "",
                    City = "Scranton",
                    State = "PA",
                    Zipcode = "18503",
                    Foster = false,
                    ApplicantStatus = "Declined",
                    ApplicationID = 100000,
                    ApplicationPostion = "Kennel Cleaner",
                    InterviewNotes = "Strange man. Applied for Kennel Cleaner, but he wanted to be a Sales Person",
                    HomeCheckDate = null,
                    SchoolName = "Scranton High",
                    SchoolCity = "Scranton",
                    SchoolState = "PA",
                    SchoolLevel = "Diploma",
                    ReferenceName = "Michael Scott",
                    ReferenceNameRelationship = "Current Boss",
                    ReferenceNamePhoneNumber = "16415210931",
                    ReferenceNameEmail = "greatscott@dundermifflin.com",
                    PreviousWorkName = "Dunder Mifflin",
                    PreviousWorkCity = "Scranton",
                    PreviousWorkState = "PA",
                    PreviousWorkType = "Sales",
                    ApplicantSkills = "Hard Worker",
                    ResumePath = "scrute_dwight.doc"
                }
            };
        }

        List<JobListing> positions = new List<JobListing>
        {
            new JobListing{ JobListingID = 1},
            new JobListing{ JobListingID = 2},
            new JobListing{ JobListingID = 3}
        };


        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver:  Ryan Morganti
        /// 
        /// This fake method is called to get a fake list of Applicants
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns>Fake list of Applicants</returns>
        public List<Applicant> SelectAllApplicants()
        {
            var selectedApplicants = (from a in applicants
                                      select a).ToList();
            return selectedApplicants;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/19
        /// Approver:  Derek Taylor
        /// 
        /// Fake Accessor Method for returning a list of positions
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public List<JobListing> SelectAllJobPositions()
        {
            return positions;
        }

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Method to test adding a Foster Applicant.
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
        public int InsertFosterApplicant(Applicant fosterApplicant)
        {
            int oldCount = applicants.Count;
            applicants.Add(fosterApplicant);
            return applicants.Count - oldCount;
        }// End InsertFosterApplicant()

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
        public Applicant SelectApplicantByID(int applicantID)
        {
            Applicant applicant = new Applicant();
            foreach (var app in applicants)
            {
                if (app.ApplicantID == applicantID)
                {
                    applicant = app;
                    break;
                }
            }
            return applicant;
        }// End SelectApplicantByID()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-11
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Fake Accessor Layer method used to select items of an applicant 
        /// for testing to make sure all methods are working corretly.
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
        public ApplicantVM SelectApplicantForInterview(int applicantID)
        {
            ApplicantVM applicant = new ApplicantVM();
            foreach (var app in _applicants)
            {
                if (app.ApplicantID == applicantID)
                {
                    applicant = app;
                    break;
                }
            }
            return applicant;
        }// End SelectApplicantForInterview()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-11
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Fake Accessor Layer method used for testing to see 
        /// if UpdateInterviewNotes is working correctly.
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
        public int UpdateInterviewNotes(int applicantionID, string oldNotes, string newNotes)
        {
            int result = 0;
            oldNotes = newNotes;

            if (oldNotes == newNotes)
            {
                result = 1;
            }

            return result;

        }// End UpdateInterviewNotes()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-11
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Fake Accessor Layer method used for testing to see 
        /// if UpdateApplicationStatus is working correctly.
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
        public int UpdateApplicationStatus(int applicationID, string oldStatus, string newStatus)
        {
            int result = 0;
            oldStatus = newStatus;

            if (oldStatus == newStatus)
            {
                result = 1;
            }

            return result;
        }// End UpdateApplicationStatus()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-11
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Fake Accessor Layer method used for testing to see 
        /// if UpdateHomeCheckDate is working correctly.
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
        public int UpdateHomeCheckDate(int applicationID, DateTime? oldDate, DateTime? newDate)
        {
            int result = 0;
            oldDate = newDate;

            if (oldDate == newDate)
            {
                result = 1;
            }
            return result;
        }// End UpdateHomeCheckDate()

    }// End class FakeApplicantAccessor

}// End namespace DataAccessFakes

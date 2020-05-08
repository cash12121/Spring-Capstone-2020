using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{

    /// <summary>
    /// Creator: Hassan Karar.
    /// Created: 3/11/2020
    /// Approver:
    ///
    /// This Class for creating a fake job listing data which will used 
    /// for testing Logic layer public methodes.
    /// </summary>
    public class FakeJobListingAccessor : IJobListingAccessor
    {
        private List<JobListing> jobListings;
        private JobListing jobListing;

        /// <summary>
        /// Creator: Hassan Karar.
        /// Created: 3/12/2020
        /// Approver: 
        /// <summary>
        /// This method will get fake job listing when it called. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        public FakeJobListingAccessor()
        {
            jobListings = new List<JobListing>();
            jobListing = new JobListing();

            //first FAKE job listing
            jobListing.JobListingID = 10002;
            jobListing.Requirements = "No Requirments";
            jobListing.Responsibilities = "All the Responsibilities";
            jobListing.RoleID = "Admin";
            jobListing.StartingWage = 1246;
            jobListing.Benefits = "No Beneifits";

            //add first Fake JobListing to our list (joblistings)
            jobListings.Add(jobListing);

            //second FAKE joblisting
            jobListing.JobListingID = 10003;
            jobListing.Requirements = "No new Requirments";
            jobListing.Responsibilities = "All the Responsibilities";
            jobListing.RoleID = "Customer";
            jobListing.StartingWage = 1116;
            jobListing.Benefits = "Gym membership";

            // add the second Fake JobListing to our list (jobListing)
            jobListings.Add(jobListing);

        }

        /// <summary>
        /// Creator: Hassan Karar.
        /// Created: 03/13/2020
        /// Approver: 
        /// 
        /// Test fake deletion of job listings.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="jobListingID"></param>
        /// <returns>valueShouldReturn</returns>

        public int DeletetJobListing(int jobListingID)
        {
            int numberOfDeletedItems = 0;
            foreach (var item in jobListings)
            {
                if (item.JobListingID == jobListingID)
                {
                    jobListings.Remove(item);
                    numberOfDeletedItems++;
                }

            }

            return numberOfDeletedItems;
        }

        /// <summary>
        /// Creator: Hassan Karar.
        /// Created: 03/16/2020
        /// Approver: 
        /// <summary>
        /// Test to add a new job listing. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="JobListing"></param>
        /// <returns></returns>
        public List<JobListing> GetAllJobListings()
        {
            return jobListings;
        }

        public bool insertJobListing(JobListing jobListing)
        {
            int itemsBeforeAdded = jobListings.Count;
            bool valueShouldReturn = false;
            jobListings.Add(jobListing);

            if (jobListings.Count != itemsBeforeAdded )
            {
                valueShouldReturn = true;
            }

            return valueShouldReturn;
        }

        /// <summary>
        /// Creator: Hassan Karar.
        /// Created: 03/16/2020
        /// Approver: 
        /// 
        /// Test update job listings.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="newjoplisting"></param>
        /// <param name="oldjobListing"></param>
        /// <returns>valueShoudBeReturn</returns>

        public int UpdateJobListing(JobListing newjoplisting, JobListing oldjobListing)
        {
            int ex = 0;
            //   bool valueShoudBeReturn = false;
            //    foreach (var item in jobListings)
            //    {
            //        if (
            //            oldjobListing.JobListingID == item.JobListingID
            //            &&  oldjobListing.Requirements == item.Requirements
            //            && oldjobListing.Responsibilities == item.Responsibilities
            //            && oldjobListing.RoleID == item.RoleID
            //            && oldjobListing.StartingWage == item.StartingWage
            //            && oldjobListing.Benefits == item.Benefits

            //            )
            //        {

            //            newjoplisting.JobListingID = item.JobListingID;
            //            newjoplisting.Requirements = item.Requirements;
            //            newjoplisting.Responsibilities = item.Responsibilities;
            //            newjoplisting.RoleID = item.RoleID;
            //            newjoplisting.StartingWage = item.StartingWage;
            //            newjoplisting.Benefits = item.Benefits;

            //            valueShoudBeReturn = true;

            //        }


            //    }

            return  ex; //valueShoudBeReturn
        }


    }
}

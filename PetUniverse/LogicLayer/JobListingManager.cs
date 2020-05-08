using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessLayer;
using DataAccessInterfaces;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Hassan Karar.
    /// Created: 2020/3/10
    /// Approver: 
    ///
    /// This class contain the logic for the job listing event.
    /// 
    /// </summary>
    public class JobListingManager : IJobListingManager
    {
       
        private IJobListingAccessor _jobListingAccessor;

        public JobListingManager()
        {

            _jobListingAccessor = new JobListingAccessor();

        }
       public JobListingManager(IJobListingAccessor jobListingAccessor)
        {

            _jobListingAccessor = jobListingAccessor;

        }

        /// NAME: Hassan Karar
        /// DATE: 2020/3/10
        /// CHECKED BY: 
        /// <summary>
        /// This method is to add a job listing list to get all the job listing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="JobListing"></param>
        /// </remarks>
        /// 
        public bool addJobListing(JobListing jobListing)
        {
            bool result = false;
            try
            {
                result = _jobListingAccessor.insertJobListing(jobListing);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }



        /// NAME: Hassan Karar
        /// DATE: 2020/3/10
        /// CHECKED BY: 
        /// <summary>
        /// This method is to add a job listing list to get all the job listing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="JobListing"></param>
        /// </remarks>
        /// 
        public List<JobListing> RetrieveJobListing()
        {
            List<JobListing> jobs = new List<JobListing>();
            try
            {
                jobs = _jobListingAccessor.GetAllJobListings();
            }
            catch (Exception ex)
            {

                throw new ApplicationException(" No item fount ",ex);
            }

            return jobs;

        }

        /// NAME: Hassan Karar
        /// DATE: 2020/3/10
        /// CHECKED BY: 
        /// <summary>
        /// This method is to upadte special order.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="newJoblisting"></param>
        /// <param name="oldjobListing"></param>
        /// 
        /// </remarks>
        /// 

        public bool EditJobListing(JobListing newJobListing, JobListing oldJobListing)
        {
            bool result = false;

            try
            {
                 
                result = (1 == _jobListingAccessor.UpdateJobListing(newJobListing, oldJobListing));
               
            }
            catch (Exception ex)
            {

                throw new ApplicationException(" No item fount ", ex);
            }

            return result;
        }

        /// NAME: Hassan Karar
        /// DATE: 2020/3/10
        /// CHECKED BY: Steve Coonrod.
        /// <summary>
        /// This method is deleting a field from the job listing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// 

        public int  DeletetJobListing(int jobListingID)
        {
          int result = 0;
            try
            {
                result = _jobListingAccessor.DeletetJobListing(jobListingID);

            }
            catch (Exception ex)
            {

                throw new ApplicationException(" No item fount ", ex); 
            }
            return result;
        }
    }
}

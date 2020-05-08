using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
  public  interface IJobListingAccessor
    {
        List<JobListing> GetAllJobListings();
        bool insertJobListing(JobListing jobListing);
        
        int UpdateJobListing(JobListing newJobListing, JobListing oldJobListing);
        int  DeletetJobListing(int jobListingID);
    }


}

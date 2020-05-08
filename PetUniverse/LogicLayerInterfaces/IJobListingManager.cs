using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;
using System.Collections;
using LogicLayer;

namespace LogicLayerInterfaces
{
   public interface IJobListingManager
    {
        List<JobListing> RetrieveJobListing();
        bool addJobListing(JobListing jobListing);
        bool EditJobListing(JobListing newJobListing, JobListing oldJobListing);
      
        int DeletetJobListing(int jobListingID);
    }
}

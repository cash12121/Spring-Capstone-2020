using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{

    /// <summary>
    /// 
    /// CREATOR: Steve Coonrod
    /// CREATED: 2020/4/13
    /// APPROVER: Matt Deaton
    /// 
    /// The data transfer object to represent a request for a social media post
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// UPDATER: NA
    /// UPDATED: NA
    /// UPDATE: NA
    /// 
    /// </remarks>
    public class SocialMediaRequest : Request
    {
        public string Title { get; set; }

        public string Description { get; set; }

    }
}

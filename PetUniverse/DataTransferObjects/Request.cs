using System;

namespace DataTransferObjects
{
    /// <summary>
    ///  CREATOR: Kaleb Bachert
    ///  CREATED: 2020/2/7
    ///  APPROVER: Jordan Lindo
    ///  
    ///  Request Data Transfer Object
    /// </summary>

    public class Request
    {
        public int RequestID { get; set; }

        public string RequestTypeID { get; set; }

        public DateTime DateCreated { get; set; }

        public int RequestingUserID { get; set; }

        public bool Open { get; set; }
    }
}

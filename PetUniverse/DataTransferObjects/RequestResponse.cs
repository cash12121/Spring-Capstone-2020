using System;

namespace DataTransferObjects
{
    /// <summary>
    ///  Creator: Ryan Morganti
    ///  Created: 2020/03/10
    ///  Approver: Derek Taylor
    ///  
    ///  Request Response Data Transfer Object
    /// </summary>
    public class RequestResponse
    {
        public int RequestResponseID { get; set; }
        public int RequestID { get; set; }
        public int UserID { get; set; }
        public string Response { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

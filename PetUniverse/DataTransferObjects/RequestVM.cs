using System;

/// <summary>
///  Creator: Kaleb Bachert
///  Created: 2020/2/14
///  Approver: Jordan Lindo
///  Approver: Zach Behrensmeyer
///  
///  Request Data Transfer Object View Model
/// </summary>
/// 
namespace DataTransferObjects
{
    public class RequestVM : Request
    {

        public String EffectiveStart { get; set; }
        public String EffectiveEnd { get; set; }
        public String ApprovalDate { get; set; }
        public int RequestingEmployeeID { get; set; }
        public string RequestingEmail { get; set; }
        public int ApprovingUserID { get; set; }

    }
}
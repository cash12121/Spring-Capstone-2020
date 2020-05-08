using DataTransferObjects;
/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/3/15
///  APPROVER: Chase Schulte
///  
///  Request Data Transfer Object
/// </summary>
public class AvailabilityRequestVM : AvailabilityRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int RequestingUserID { get; set; }
}
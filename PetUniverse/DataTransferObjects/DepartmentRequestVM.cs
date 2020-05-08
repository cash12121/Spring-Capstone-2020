namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Ryan Morganti
    /// Created: 2020/02/06
    /// Approver: Derek Taylor
    /// 
    /// Class for storing DepartmentRequest ViewModel data pulled from the Data Store,
    /// based on UserID values
    /// Inherits from Class DepartmentRequest
    /// </summary>
    public class DepartmentRequestVM : DepartmentRequest
    {
        public string RequestorFirstName { get; set; }
        public string RequestorLastName { get; set; }
        public string AcknowledgeFirstName { get; set; }
        public string AcknowledgeLastName { get; set; }
        public string CompleteFirstName { get; set; }
        public string CompleteLastName { get; set; }

        public DepartmentRequestVM(DepartmentRequest dr)
        {
            this.RequestID = dr.RequestID;
            this.DateCreated = dr.DateCreated;
            this.RequestTypeID = dr.RequestTypeID;
            this.RequestingUserID = dr.RequestingUserID;
            this.RequestorGroupID = dr.RequestorGroupID;
            this.RequesteeGroupID = dr.RequesteeGroupID;
            this.DateAcknowledged = dr.DateAcknowledged;
            this.AcknowledgingEmployee = dr.AcknowledgingEmployee;
            this.DateCompleted = dr.DateCompleted;
            this.CompletedEmployee = dr.CompletedEmployee;
            this.Subject = dr.Subject;
            this.Topic = dr.Topic;
            this.Body = dr.Body;
        }
    }
}

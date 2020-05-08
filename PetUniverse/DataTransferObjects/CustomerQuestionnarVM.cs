namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/04
    /// Approver : Mohamed Elamin , 2/21/2020
    ///
    /// Data object class to handle the customer questionnair after replace the primary keys by real worlds
    /// </summary>
    public class CustomerQuestionnarVM
    {
        public string QuestionDescription { get; set; }
        public string CustomerLastName { get; set; }
        public int AdoptionApplicationID { get; set; }
        public string CustomerAnswer { get; set; }
    }
}

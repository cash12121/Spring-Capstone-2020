namespace DataTransferObjects
{
    /// <summary>
    ///   matchin the customer Qestionnair
    /// </summary>
    /// <remarks>
    /// by Awaab Elamin 2/5/2020
    /// Mohamed Elamin , 2/21/2020
    /// </remarks>
    /// <Remark>
    /// Updated by: Awaab Elamin
    /// Date: 3/15/2020
    /// <summary>
    /// update CustomerId to CustomerEmail and QuestionID to QuestionDescription to match update on DBA
    /// </summary>
    /// 
    /// </Remark>
    public class CustomerQuestionnar
    {
        public string QuestionDescription { get; set; }
        public string Answer { get; set; }
    }
}

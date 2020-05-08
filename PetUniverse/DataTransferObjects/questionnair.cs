namespace DataTransferObjects
{
    /// <summary>
    /// matching the General Question 
    /// </summary>
    /// <remarks>
    /// by Awaab Elamin 2/4/2020
    /// Mohamed Elamin , 2/21/2020
    /// </remarks>
    /// <Remark>
    /// Updated by: Awaab Elamin
    /// <summary>
    /// the update taking out customer ID to be compatible with DB updte
    /// Customer table updated 
    /// </summary>
    /// </Remark>
    public class Questionnair
    {
        public string question { get; set; }
        public string answer { get; set; }
        public int AdoptionApplicationID { get; set; }
        public string CustomerEmail { get; set; }
        public string Question1 { get; set; }
        public string Answer1 { get; set; }
        public string Question2 { get; set; }
        public string Answer2 { get; set; }
        public string Question3 { get; set; }
        public string Answer3 { get; set; }
        public string Question4 { get; set; }
        public string Answer4 { get; set; }
        public string Question5 { get; set; }
        public string Answer5 { get; set; }
        public string Question6 { get; set; }
        public string Answer6 { get; set; }
        public string Question7 { get; set; }
        public string Answer7 { get; set; }
        public string Question8 { get; set; }
        public string Answer8 { get; set; }
        public string Question9 { get; set; }
        public string Answer9 { get; set; }
        public string Question10 { get; set; }
        public string Answer10 { get; set; }
    }
}

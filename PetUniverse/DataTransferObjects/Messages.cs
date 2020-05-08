namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 03/16/20
    /// Approver: Steven Cardona
    /// 
    /// This class is where we create the properties of a user
    /// </summary>
    public class Messages
    {
        public int MessageID { get; set; }
        public string MessageBody { get; set; }
        public string MessageSubject { get; set; }
        public int SenderID { get; set; }
        public int RecipientID { get; set; }
        public bool Seen { get; set; }
    }
}

namespace DataTransferObjects
{

    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/14
    /// Approver: Ethan Holmes
    /// 
    /// Data transfer object for transaction type.
    /// </summary>
    public class TransactionType
    {
        public string TransactionTypeID { get; set; }
        public string Description { get; set; }
        public bool DefaultInStore { get; set; }
    }
}

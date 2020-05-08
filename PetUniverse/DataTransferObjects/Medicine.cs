namespace DataTransferObjects
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig    
    ///     DATE: 2020-02-09
    ///     CHECKED BY: Zoey McDonald
    ///     Medicine Data Transfer Object
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public class Medicine
    {
        public int MedicineID { get; set; }

        public string MedicineName { get; set; }

        public string MedicineDosage { get; set; }

        public string MedicineDescription { get; set; }
    }
}

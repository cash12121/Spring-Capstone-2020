namespace DataTransferObjects
{
    public class TrainingVideo
    {
        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Jordan Lindo
        /// 
        /// This class defines the Transfer Objects for TrainingVideo
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 03/01
        /// Update: Added active field
        /// </remarks>
        public string TrainingVideoID { get; set; }
        public int RunTimeMinutes { get; set; }
        public int RunTimeSeconds { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}

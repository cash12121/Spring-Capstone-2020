using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// 
    /// Animal Activity class
    /// </summary>
    /// <remarks>
    /// Updater: Ethan Murphy
    /// Updated: 4/2/2020
    /// Update: Added Description and Activity ID properties
    /// Approver: Carl Davis 4/3/2020
    /// </remarks>

    public class AnimalActivity
    {
        public int AnimalActivityId { get; set; }
        public int AnimalID { get; set; }
        public int UserID { get; set; }
        public string AnimalName { get; set; }
        public string AnimalActivityTypeID { get; set; }
        public DateTime ActivityDateTime { get; set; }
        public string Description { get; set; }
    }
}


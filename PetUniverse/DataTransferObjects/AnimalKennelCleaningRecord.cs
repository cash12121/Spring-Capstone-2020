using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/4/2020
    /// 
    /// Data transfer object for a kennel cleaning record
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public class AnimalKennelCleaningRecord
    {
        public int FacilityKennelCleaningID { get; set; }

        public int UserID { get; set; }

        public int AnimalKennelID { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }
    }
}

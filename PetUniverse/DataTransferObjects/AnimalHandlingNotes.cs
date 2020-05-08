using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/21/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver: Chuck Baxter, 2/21/2020
    /// 
    /// Data transfer object for AnimalHandlingNotes
    /// </summary>
    public class AnimalHandlingNotes
    {
        public int HandlingNotesID { get; set; }
        public int AnimalID { get; set; }
        public int UserID { get; set; }
        public string HandlingNotes { get; set; }
        public string TemperamentWarning { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}

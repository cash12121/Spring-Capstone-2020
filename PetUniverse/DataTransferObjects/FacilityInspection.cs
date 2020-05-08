using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/28/2020
    /// Approver: Ethan Murphy 3/6/2020
    /// Approver: 
    /// 
    /// A class to store data for the FacilityInspection Fields
    /// </summary>
    public class FacilityInspection
    {
        public int FacilityInspectionID { get; set; }
        public int UserID { get; set; }
        public string InspectorName { get; set; }
        public DateTime InspectionDate { get; set; }
        public string InspectionDescription { get; set; }
        public bool InspectionCompleted { get; set; }
    }
}

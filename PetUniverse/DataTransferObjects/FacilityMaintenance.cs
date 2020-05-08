namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/6/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// A class to store data for the FacilityMaintenanceFields
    /// </summary>
    public class FacilityMaintenance
    {
        public int FacilityMaintenanceID { get; set; }
        public int UserID { get; set; }
        public string MaintenanceName { get; set; }
        public string MaintenanceInterval { get; set; }
        public string MaintenanceDescription { get; set; }
        public bool Active { get; set; }
    }
}

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 3/30/2020
    /// Approver: Ethan Murphy 4/3/2020
    /// Approver: 
    /// 
    /// A class to store data for the FacilityInspectionItem Fields
    /// </summary>
    public class FacilityInspectionItem
    {
        public int FacilityInspectionItemID { get; set; }
        public string ItemName { get; set; }
        public int UserID { get; set; }
        public int FacilityInpectionID { get; set; }
        public string ItemDescription { get; set; }
    }
}

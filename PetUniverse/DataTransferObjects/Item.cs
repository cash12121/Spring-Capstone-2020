namespace DataTransferObjects
{ /// <summary>
  /// Creator: Tener karar
  /// Created: 2020/02/7
  /// Approver: Steven Cardona
  ///
  /// The data transfer object for item class
  /// Contains all getter and setter methods for item functions
  /// <remarks>
  /// Updated By: Dalton Reierson
  /// Updated: 2020/03/13
  /// Update: Added bool Active
  /// </remarks>
  /// </summary>
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public int ShelterThreshold { get; set; }
        public string ItemCategoryID { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool ShelterItem { get; set; }
    }
}

namespace DataTransferObjects
{
    /// <summary>
	/// Creator: Chase Schulte
	/// Created: 2020/02/05
	/// Approver: Kaleb Bachert
	///
	/// properties for a Role
    /// Updater: Chase Schulte
    /// Updated: 04/10/2020
    /// Update: Changed functionality to inherit ERole
    /// Approver: Kaleb Bachert
	/// </summary>
    public class ERole : PetUniverseUser
    {
        public string ERoleID { get; set; }
        public string DepartmentID { get; set; }
        public string Description { get; set; }
        public bool EActive { get; set; }
    }
}

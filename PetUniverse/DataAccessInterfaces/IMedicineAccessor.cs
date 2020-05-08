using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Timothy Lickteig    
    /// Created: 02/09/2020
    /// Approver: Zoey McDonald
    /// 
    /// Interface for medicine accessor classes
    /// </summary>
    public interface IMedicineAccessor
    {
        /// <summary>
        /// Creator: Timothy Lickteig    
        /// Created: 02/09/2020
        /// Approver: Zoey McDonald
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Udpated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="medicine">The medicine to enter</param>
        /// <returns>The number of rows affected</returns>
        int InsertMedicine(Medicine medicine);

        /// <summary>
        /// Creator: Timothy Lickteig    
        /// Created: 02/09/2020
        /// Approver: Zoey McDonald
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Udpated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="medicineID">The ID of the Medicine to delete</param>
        /// <returns>The number of rows affected</returns>
        int DeleteMedicine(int medicineID);

        /// <summary>
        /// Creator: Timothy Lickteig    
        /// Created: 02/09/2020
        /// Approver: Zoey McDonald
        /// </summary>     
        /// <remarks>
        /// Updater: N/A
        /// Udpated: N/A
        /// Update: N/A
        /// </remarks>
        /// <returns>All Medicine records in the database</returns>
        List<Medicine> SelectAllMedicines();
    }
}
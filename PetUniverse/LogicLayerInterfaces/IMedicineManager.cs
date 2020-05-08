using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig    
    ///     DATE: 2020-03-09
    ///     CHECKED BY: Zoey McDonald
    ///     Interface for managing medicine
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public interface IMedicineManager
    {
        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="medicineID">The ID of the Medicine to check out</param>
        /// <returns>The number of rows affected</returns>
        int CheckMedicineOut(int medicineID);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="medicine">Medicine object to check in</param>
        /// <returns>The number of rows affected</returns>
        int CheckMedicineIn(Medicine medicine);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-12
        ///     CHECKED BY: 
        /// </summary>        
        /// <returns>All medicine records</returns>
        List<Medicine> ReturnAllMedicine();
    }
}

using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/4/2020
    /// 
    /// Interface for Kennel Cleaning Record Accessors
    /// </summary>
    public interface IAnimalKennelCleaningAccessor
    {
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Adds a kennel cleaning record to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="cleaningRecord"></param>
        /// <returns></returns>
        int InsertKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/7/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Gets all of the kennel cleaning records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns> A list of all the kennel cleaning records </returns>
        List<AnimalKennelCleaningRecord> SelectAllKennelCleaningRecords();

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/8/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Updates a single record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldRecord"></param>
        /// <param name="newRecord"></param>
        /// <returns> Number of rows effected by the stored procedure. Should always be 1 </returns>
        int UpdateKennelCleaningRecord(AnimalKennelCleaningRecord oldRecord, AnimalKennelCleaningRecord newRecord);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/10/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Deletes a cleaning record from the database 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="cleaningRecord"></param>
        /// <returns></returns>
        int DeleteKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord);


    }
}

using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/4/2020
    /// 
    /// Interface for Kennel Cleaning Record Managers
    /// </summary>
    public interface IAnimalKennelCleaningManager
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
        bool AddKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/7/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// gets all of the kennel cleaning records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns> A list of all the kennel cleaning records </returns>
        List<AnimalKennelCleaningRecord> RetrieveAllKennelCleaningRecords();

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/8/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Edits a single cleaning record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldRecord"></param>
        /// <param name="newRecord"></param>
        /// <returns> True if successful </returns>
        bool EditKennelCleaningRecord(AnimalKennelCleaningRecord oldRecord, AnimalKennelCleaningRecord newRecord);

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
        bool RemoveKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord);
    }
}

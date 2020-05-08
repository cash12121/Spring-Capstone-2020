using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/14/2020
    /// Approver: Chuck Baxter, 2/14/2020
    /// 
    /// Interface for the kennel accessor methods
    /// </summary>
    public interface IAnimalKennelAccessor
    {

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Adds a kennel record to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennel"></param>
        /// <returns> Integer representing how many rows were effected. Should be exactly 1 </returns>
        int InsertKennelRecord(AnimalKennel kennel);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/12/2020
        /// Approver: Carl Davis, 3/13/2020
        /// 
        /// Gets a list of all the kennel records in the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns> List of kennel records </returns>
        List<AnimalKennel> RetriveAllAnimalKennels();

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/15/2020
        /// Approver: Carl Davis, 3/19/2020
        /// 
        /// Updates a single kennel record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldNotes"></param>
        /// <param name="newNotes"></param>
        /// <returns> Number of database rows effected. Should always be 1 </returns>
        int UpdateKennelRecord(AnimalKennel oldKennel, AnimalKennel newKennel);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/15/2020
        /// Approver: Carl Davis, 3/19/2020
        /// 
        /// Updates a single kennel record without a date out value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldNotes"></param>
        /// <param name="newNotes"></param>
        /// <returns> Number of database rows effected. Should always be 1 </returns>
        int UpdateKennelRecordNoDateOut(AnimalKennel oldKennel, AnimalKennel newKennel);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/19/2020
        /// 
        /// Adds a DateOut value to a single record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldNotes"></param>
        /// <param name="newNotes"></param>
        /// <returns> Number of database rows effected. Should always be 1 </returns>
        int AddDateOut(AnimalKennel kennel);
    }
}
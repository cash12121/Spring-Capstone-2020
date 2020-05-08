using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/14/2020
    /// Approver: Chuck Baxter, 2/14/2020
    /// 
    /// Interface for Kennel Managers
    /// </summary>
    public interface IAnimalKennelManager
    {
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Adds a new kennel record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennel"></param>
        /// <returns> Returns true if the method succeeds </returns>
        bool AddKennelRecord(AnimalKennel kennel);


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/12/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Gets a list of all the kennel records in the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns> List of kennel records </returns>
        List<AnimalKennel> GetAllAnimalKennels();

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/15/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
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
        /// <returns> true represents a successful action </returns>
        bool EditKennelRecord(AnimalKennel oldKennel, AnimalKennel newKennel);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
        /// 
        /// Changes the value of the date out field
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennel"></param>
        /// <returns> True represents a successful action </returns>
        bool SetDateOut(AnimalKennel kennel);
    }
}

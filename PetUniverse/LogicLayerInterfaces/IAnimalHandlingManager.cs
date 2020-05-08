using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/21/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver: Chuck Baxter, 2/21/2020
    /// 
    /// Interface for the Animal handling notes features manager class
    /// </summary>
    public interface IAnimalHandlingManager
    {
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get handling notes by animal handling notes ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="handlingNotesID"></param>
        /// <returns>Single instance of AnimalHandlingNotes</returns>
        AnimalHandlingNotes GetHandlingNotesByID(int handlingNotesID);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get a list of animal handling notes by the animal's ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns>List of AnimalHandlingNotes objects</returns>
        List<AnimalHandlingNotes> GetAllHandlingNotesByAnimalID(int animalID);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/28/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver:
        /// 
        /// Adds an animal handling record to the database and tells you if it succeeded
        /// </summary>
        /// <param name="project"></param>
        /// <returns> Returns true if successful </returns>
        bool AddAnimalHandlingNotes(AnimalHandlingNotes handlingNotes);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/4/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver:
        /// 
        /// Updates an animal handling record
        /// </summary>
        /// <param name="oldNotes"></param>
        /// <param name="newNotes"></param>
        /// <returns></returns>
        bool EditAnimalHandlingNotes(AnimalHandlingNotes oldNotes, AnimalHandlingNotes newNotes);
    }
}

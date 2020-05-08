using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/21/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver: Chuck Baxter, 2/21/2020
    /// 
    /// Interface for the animal handing notes accessor class
    /// </summary>
    public interface IAnimalHandlingAccessor
    {

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Select single animal handling notes record by primary key.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="handlingNotesID"></param>
        /// <returns>The animal handling notes record</returns>
        AnimalHandlingNotes SelectHandlingNotesByID(int handlingNotesID);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Select a list of animal handling notes records by their shared animal ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns>The list of animal handling notes records</returns>
        List<AnimalHandlingNotes> SelectAllHandlingNotesByAnimalID(int animalID);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/28/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver:
        /// 
        /// Adds an animal handling notes record to the database and tells you if it worked or not. 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="project"></param>
        /// <returns> Number of rows effected. Should be 1 </returns>
        int InsertAnimalHandlingNotes(AnimalHandlingNotes notes);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/4/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver:
        /// 
        /// Updates an existing record with new values. 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="project"></param>
        /// <returns> Number of rows effected. Should be 1 </returns>
        int UpdateAnimalHandlingNotes(AnimalHandlingNotes oldNotes, AnimalHandlingNotes newNotes);
    }
}
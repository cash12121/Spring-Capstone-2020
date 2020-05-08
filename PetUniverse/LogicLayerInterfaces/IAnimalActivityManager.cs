using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// 
    /// no argument constructor
    /// </summary>
    /// <remarks>
    /// Updater: Ethan Murphy
    /// Updated: 4/2/2020
    /// Update: Added methods for retrieving activity records
    /// by activity type and retrieving a list of activity types
    /// </remarks>

    public interface IAnimalActivityManager
    {

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Retrieves animal activities by activity type
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="activityType">Activity type ID</param>
        /// <returns>List of animal activities</returns>
        List<AnimalActivity> RetrieveAnimalActivitiesByActivityType(string activityType);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Retrieves list of animal activity types
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <returns>List of animal activity types</returns>
        List<AnimalActivityType> RetrieveAllAnimalActivityTypes();

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Searches the list of animal activity records with the
        /// specified animal name and returns results with similar names
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="animalName">The name of the animal</param>
        /// <param name="activityType">The activity type to search</param>
        /// <returns>List of animal activity types</returns>
        List<AnimalActivity> RetrieveAnimalActivitiesByPartialAnimalName(string animalName, string activityType);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Adds an animal activity record to the DB
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="animalActivity">Activity record to be added</param>
        /// <returns>Result of insert</returns>
        bool AddAnimalActivityRecord(AnimalActivity animalActivity);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/6/2020
        /// Approver: Chuck Baxter 4/7/2020
        /// 
        /// Edits an existing activity record
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="oldAnimalActivity">Existing record</param>
        /// <param name="newAnimalActivity">Updated record</param>
        /// <returns>Result of edit</returns>
        bool EditExistingAnimalActivityRecord(AnimalActivity oldAnimalActivity,
                                                AnimalActivity newAnimalActivity);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// Adds an animal activity type record to the DB
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="animalActivityType"></param>
        /// <returns></returns>
        bool AddAnimalActivityType(AnimalActivityType animalActivityType);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// updates an existing animal activity type record in the DB
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="oldAnimalActivityType"></param>
        /// <param name="newAnimalActivityType"></param>
        /// <returns></returns>
        bool EditAnimalActivityType(AnimalActivityType oldAnimalActivityType, AnimalActivityType newAnimalActivityType);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// deletes an existing animal activity type record in the DB
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="animalActivityType"></param>
        /// <returns></returns>
        bool DeleteAnimalActivityType(AnimalActivityType animalActivityType);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Deletes an existing animal activity record
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="animalActivity">Record to be deleted</param>
        /// <returns>Delete successful</returns>
        bool DeleteAnimalActivityRecord(AnimalActivity animalActivity);
    }
}

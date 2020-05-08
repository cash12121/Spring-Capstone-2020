using DataTransferObjects;
using System.Collections.Generic;
namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// 
    /// Interface for AnimalActivityAccessor
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public interface IAnimalActivityAccessor
    {

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Gets animal activity records by activity type
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="activity">Activity type ID</param>
        /// <returns>List of animal activity records</returns>
        List<AnimalActivity> GetAnimalActivityRecordsByActivityType(string activity);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Gets animal activity types
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal activity types</returns>
        List<AnimalActivityType> GetAnimalActivityTypes();

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Inserts an animal activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalActivity">The record to insert</param>
        /// <returns>List of animal activity types</returns>
        int InsertAnimalActivityRecord(AnimalActivity animalActivity);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/6/2020
        /// Approver: Chuck Baxter 4/7/2020
        /// 
        /// Updates an existing animal activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalActivity">The existing record</param>
        /// <param name="newAnimalActivity">The updated record</param>
        /// <returns>Update successful</returns>
        int UpdateAnimalActivityRecord(AnimalActivity oldAnimalActivity,
            AnimalActivity newAnimalActivity);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// Creates a new animal activty type
        /// </summary>
        /// <param name="animalActivityType"></param>
        /// <returns></returns>
        int InsertAnimalActivityType(AnimalActivityType animalActivityType);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// updates an existing animal activty type
        /// </summary>
        /// <param name="oldAnimalActivityType"></param>
        /// <param name="newAnimalActivityType"></param>
        /// <returns></returns>
        int UpdateAnimalActivityType(AnimalActivityType oldAnimalActivityType, AnimalActivityType newAnimalActivityType);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// deletes an existing animal activty type
        /// </summary>
        /// <param name="animalActivityType"></param>
        /// <returns></returns>
        int DeleteAnimalActivityType(AnimalActivityType animalActivityType);

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
        /// <returns>Number of records deleted</returns>
        int DeleteAnimalActivityRecord(AnimalActivity animalActivity);
    }
}

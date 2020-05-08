using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LogicLayer
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// 
    /// Interface for AnimalActivityManager
    /// </summary>
    /// <remarks>
    /// Updater: Ethan Murphy
    /// Updated: 4/2/2020
    /// Update: Added more funtionality
    /// </remarks>
    public class AnimalActivityManager : IAnimalActivityManager
    {
        private IAnimalActivityAccessor _activityAccessor;
        private List<AnimalActivity> animalActivities = null;

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// no argument constructor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        public AnimalActivityManager()
        {
            _activityAccessor = new AnimalActivityAccessor();
        }

        public AnimalActivityManager(IAnimalActivityAccessor animalActivityManager)
        {
            _activityAccessor = animalActivityManager;
        }

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
        public bool AddAnimalActivityRecord(AnimalActivity animalActivity)
        {
            try
            {
                return _activityAccessor.InsertAnimalActivityRecord(animalActivity) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to add record", ex);
            }
        }

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
        public bool EditExistingAnimalActivityRecord(AnimalActivity oldAnimalActivity, AnimalActivity newAnimalActivity)
        {
            try
            {
                return _activityAccessor.UpdateAnimalActivityRecord(oldAnimalActivity, newAnimalActivity) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Record not updated", ex);
            }
        }

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
        public List<AnimalActivityType> RetrieveAllAnimalActivityTypes()
        {
            try
            {
                return _activityAccessor.GetAnimalActivityTypes();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve activity types", ex);
            }
        }

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
        public List<AnimalActivity> RetrieveAnimalActivitiesByActivityType(string activityType)
        {
            try
            {
                animalActivities = _activityAccessor.GetAnimalActivityRecordsByActivityType(activityType);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve activities", ex);
            }
            return animalActivities;
        }

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
        public List<AnimalActivity> RetrieveAnimalActivitiesByPartialAnimalName(string animalName, string activityType)
        {
            if (animalActivities == null)
            {
                RetrieveAnimalActivitiesByActivityType(activityType);
            }
            return (from a in animalActivities
                    where a.AnimalName.ToLower().IndexOf(animalName.ToLower()) > -1
                    select a).ToList();
        }

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
        public bool AddAnimalActivityType(AnimalActivityType animalActivityType)
        {
            try
            {
                return _activityAccessor.InsertAnimalActivityType(animalActivityType) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to add record", ex);
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// updates an animal activity type record in the DB
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="oldAnimalActivityType"></param>
        /// <param name="newAnimalActivityType"></param>
        /// <returns></returns>
        public bool EditAnimalActivityType(AnimalActivityType oldAnimalActivityType, AnimalActivityType newAnimalActivityType)
        {
            try
            {
                return _activityAccessor.UpdateAnimalActivityType(oldAnimalActivityType, newAnimalActivityType) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to update record", ex);
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// deletes an animal activity type record in the DB
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="animalActivityType"></param>
        /// <returns></returns>
        public bool DeleteAnimalActivityType(AnimalActivityType animalActivityType)
        {
            try
            {
                return _activityAccessor.DeleteAnimalActivityType(animalActivityType) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to delete record", ex);
            }
        }

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
        public bool DeleteAnimalActivityRecord(AnimalActivity animalActivity)
        {
            try
            {
                return _activityAccessor.DeleteAnimalActivityRecord(animalActivity) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to delete record", ex);
            }
        }
    }
}

using DataAccessLayer;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{

    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// 
    /// Class to provide fake animal activity data
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public class FakeAnimalActivityAccessor : IAnimalActivityAccessor
    {

        private List<AnimalActivity> _animalActivity;
        private List<AnimalActivityType> activityTypes;

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 4/3/2020
        /// 
        /// fake animal activity records
        /// </summary>
        /// <remarks>
        /// Updater: Ethan Murphy
        /// Updated: 4/2/2020
        /// Update: Added more activities and activity types
        /// and removed a quattuordecillion of unnecessary blank lines
        /// </remarks>
        public FakeAnimalActivityAccessor()
        {
            _animalActivity = new List<AnimalActivity>()
            {
                new AnimalActivity() {
                    AnimalID = 1,
                    ActivityDateTime = DateTime.Now,
                    AnimalActivityTypeID = "Feeding",
                },

                new AnimalActivity() {
                    AnimalID = 2,
                    ActivityDateTime = DateTime.Now,
                    AnimalActivityTypeID = "Feeding",
                },

                new AnimalActivity()
                {
                    AnimalActivityId = 3,
                    ActivityDateTime = DateTime.Now,
                    AnimalActivityTypeID = "Play"
                },

                new AnimalActivity()
                {
                    AnimalActivityId = 4,
                    ActivityDateTime = DateTime.Now,
                    AnimalActivityTypeID = "Play"
                }
            };

            activityTypes = new List<AnimalActivityType>()
            {
                new AnimalActivityType()
                {
                    ActivityTypeId = "Feeding"
                },

                new AnimalActivityType()
                {
                    ActivityTypeId = "Play"
                }
            };
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis, 4/3/2020
        /// 
        /// Retrieves a list of fake animal activity records
        /// by activity type
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="activity">Activity type id</param>
        /// <returns>List of animal activity records</returns>
        public List<AnimalActivity> GetAnimalActivityRecordsByActivityType(string activity)
        {
            return _animalActivity.Where(a => a.AnimalActivityTypeID == activity).ToList();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis, 4/3/2020
        /// 
        /// Retrieves a list of fake animal activity types
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal activity types</returns>
        public List<AnimalActivityType> GetAnimalActivityTypes()
        {
            return activityTypes;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis, 4/3/2020
        /// 
        /// Inserts an animal activity into the existing list
        /// of fake animal activity records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalActivity">Record to insert</param>
        /// <returns>The number of records updated</returns>
        public int InsertAnimalActivityRecord(AnimalActivity animalActivity)
        {
            int startingLength = _animalActivity.Count;
            _animalActivity.Add(animalActivity);
            return _animalActivity.Count - startingLength;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/6/2020
        /// Approver: Chuck Baxter, 4/7/2020
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
        public int UpdateAnimalActivityRecord(AnimalActivity oldAnimalActivity, AnimalActivity newAnimalActivity)
        {
            int recordsUpdated = 0;

            var foundRecord = _animalActivity.Find(a => a.AnimalActivityTypeID
                                                        == oldAnimalActivity.AnimalActivityTypeID &&
                                                        a.AnimalID == oldAnimalActivity.AnimalID &&
                                                        a.UserID == oldAnimalActivity.UserID &&
                                                        a.AnimalActivityTypeID == oldAnimalActivity.AnimalActivityTypeID &&
                                                        a.ActivityDateTime == oldAnimalActivity.ActivityDateTime &&
                                                        a.Description == oldAnimalActivity.Description);
            if (foundRecord != null)
            {
                _animalActivity[_animalActivity.IndexOf(foundRecord)] = newAnimalActivity;
                recordsUpdated = ((!_animalActivity.Contains(foundRecord)) &&
                                _animalActivity.Contains(newAnimalActivity)) ? 1 : 0;
            }
            return recordsUpdated;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// Inserts an animal activity type into the existing list
        /// of fake animal activity type records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalActivityType"></param>
        /// <returns></returns>
        public int InsertAnimalActivityType(AnimalActivityType animalActivityType)
        {
            int startingLength = activityTypes.Count;
            activityTypes.Add(animalActivityType);
            return activityTypes.Count - startingLength;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// looks for a matching activity type id from the params in the collection to update
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalActivityType"></param>
        /// <param name="newAnimalActivityType"></param>
        /// <returns></returns>
        public int UpdateAnimalActivityType(AnimalActivityType oldAnimalActivityType, AnimalActivityType newAnimalActivityType)
        {
            int recordsUpdated = 0;
            if (oldAnimalActivityType.ActivityTypeId == "Feeding")
            {
                recordsUpdated = 1;
            }
            return recordsUpdated;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// looks for a matching activity type id from the params in the collection to delete
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public int DeleteAnimalActivityType(AnimalActivityType animalActivityType)
        {
            int recordsUpdated = 0;
            if (animalActivityType.ActivityTypeId == "Feeding")
            {
                recordsUpdated = 1;
            }
            return recordsUpdated;
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
        /// <returns>Number of records deleted</returns>
        public int DeleteAnimalActivityRecord(AnimalActivity animalActivity)
        {
            int rows = 0;
            int startingCount = _animalActivity.Count;

            var foundRecord = _animalActivity.Where(a => a.AnimalActivityId == animalActivity.AnimalActivityId &&
                                                         a.AnimalID == animalActivity.AnimalID &&
                                                         a.UserID == animalActivity.UserID &&
                                                         a.AnimalActivityTypeID == animalActivity.AnimalActivityTypeID &&
                                                         a.ActivityDateTime == animalActivity.ActivityDateTime &&
                                                         a.Description == animalActivity.Description).FirstOrDefault();

            if (foundRecord != null)
            {
                _animalActivity.Remove(foundRecord);
            }

            rows = startingCount - _animalActivity.Count;

            return rows;
        }
    }
}

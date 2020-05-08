using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/4/2020
    /// 
    /// Fake data access class for unit testing. Replaces the kennel cleaning records accessor.
    /// 
    /// </summary>
    public class FakeAnimalKennelCleaningAccessor : IAnimalKennelCleaningAccessor
    {
        private List<AnimalKennelCleaningRecord> cleaningRecords;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Constructor to set up the fake records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FakeAnimalKennelCleaningAccessor()
        {
            cleaningRecords = new List<AnimalKennelCleaningRecord>
            {
                new AnimalKennelCleaningRecord
                {
                    FacilityKennelCleaningID = 1,
                    AnimalKennelID = 1,
                    UserID = 1,
                    Date = new DateTime(2019, 5, 24),
                    Notes = "Notes Notes 1"
                },

                new AnimalKennelCleaningRecord
                {
                    FacilityKennelCleaningID = 2,
                    AnimalKennelID = 2,
                    UserID = 1,
                    Date = new DateTime(2019, 6, 24),
                    Notes = "Notes Notes 2"
                }

            };

        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/10/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Fake method to test removing the data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="cleaningRecord"></param>
        /// <returns></returns>
        public int DeleteKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord)
        {
            AnimalKennelCleaningRecord record = null;
            record = (cleaningRecords.Find(n => n.FacilityKennelCleaningID == cleaningRecord.FacilityKennelCleaningID));

            if (record != null)
            {
                cleaningRecords.Remove(cleaningRecord);

                return 1;
            }
            else
            {
                throw new ApplicationException("data not found");
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Fake method for testing adding stuff.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public int InsertKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord)
        {
            if (cleaningRecord.FacilityKennelCleaningID > 0)
            {
                cleaningRecords.Add(cleaningRecord);

                return 1;
            }
            else
            {
                throw new ApplicationException("test Exception");
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/7/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Fake method for testing getting a list of cleaning records.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns></returns>
        public List<AnimalKennelCleaningRecord> SelectAllKennelCleaningRecords()
        {
            return cleaningRecords;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/9/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Fake method for testing editing a cleaning record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldRecord"></param>
        /// <param name="newRecord"></param>
        /// <returns></returns>
        public int UpdateKennelCleaningRecord(AnimalKennelCleaningRecord oldRecord, AnimalKennelCleaningRecord newRecord)
        {
            AnimalKennelCleaningRecord record = null;
            record = (cleaningRecords.Find(n => n.FacilityKennelCleaningID == oldRecord.FacilityKennelCleaningID));

            if (record != null)
            {
                cleaningRecords[(oldRecord.FacilityKennelCleaningID - 1)] = newRecord;

                return 1;
            }
            else
            {
                throw new ApplicationException("data not found");
            }
        }
    }
}

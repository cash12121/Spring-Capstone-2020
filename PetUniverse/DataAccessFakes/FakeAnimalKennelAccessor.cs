using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/14/2020
    /// Approver: Chuck Baxter, 2/14/2020
    /// 
    /// Fake data access class for unit testing. Replaces the kennel accessor. 
    /// </summary>
    /// Coded by Ben Hanna - 2/12/2020
    /// Reviewed by Chuck Baxter, 2/14/2020
    /// Reviewed by Carl Davis, 2/14/2020
    /// </remarks>
    public class FakeAnimalKennelAccessor : IAnimalKennelAccessor
    {

        private List<AnimalKennel> records;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Constructor creates a list of kennel records for testing purposes
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FakeAnimalKennelAccessor()
        {
            records = new List<AnimalKennel>()
            {
                new AnimalKennel()
                {
                    AnimalKennelID = 1,
                    AnimalID = 1,
                    UserID = 1,
                    AnimalKennelInfo = "info info info",
                    AnimalKennelDateIn = new DateTime(2019, 5, 24),
                    AnimalKennelDateOut = new DateTime(2020, 2, 24)
                },

                new AnimalKennel()
                {
                    AnimalKennelID = 2,
                    AnimalID = 1,
                    UserID = 1,
                    AnimalKennelInfo = "info info info",
                    AnimalKennelDateIn = new DateTime(2020, 2, 25)
                }
            };
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
        /// 
        /// Simulates adding a date to the record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennel"></param>
        /// <returns></returns>
        public int AddDateOut(AnimalKennel kennel)
        {
            int kennelIndex = records.FindIndex(k => k.AnimalKennelID == kennel.AnimalKennelID);

            AnimalKennel animalKennel = records[kennelIndex];
            animalKennel.AnimalKennelDateOut = kennel.AnimalKennelDateOut;
            records[kennelIndex] = animalKennel;

            return (from k in records
                    where k.AnimalKennelID == kennel.AnimalKennelID
                    select k).Count();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Simulates adding a kennel record to the database. 
        /// Will intentionally throw an exception if the kennel ID isn't 1.
        /// </summary>
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/9/2020
        /// Update: Updated return value so we weren't using a magic number
        /// </remarks>
        /// <param name="kennel"></param>
        /// <returns> Represents the number of rows effected.</returns>
        public int InsertKennelRecord(AnimalKennel kennel)
        {
            int result = 0;

            if (kennel.AnimalKennelID == 1)
            {
                records.Add(kennel);
                result = 1;
            }
            else
            {
                throw new Exception("Test exception");
            }
            return result;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 3/13/2020        
        /// 
        /// Gets all kennel records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns></returns>
        public List<AnimalKennel> RetriveAllAnimalKennels()
        {
            return records;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/17/2020
        /// Approver: 
        /// Approver: Carl Davis, 3/19/2020
        /// 
        /// Simulates updating a kennel record
        /// </summary>
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/9/2020
        /// Update: Updated return value so we weren't using a magic number
        /// </remarks>
        /// <param name="oldKennel"></param>
        /// <param name="newKennel"></param>
        /// <returns></returns>
        public int UpdateKennelRecord(AnimalKennel oldKennel, AnimalKennel newKennel)
        {
            int result;
            AnimalKennel kennel = null;
            kennel = (records.Find(n => n.AnimalKennelID == oldKennel.AnimalKennelID));

            if (kennel != null)
            {
                records[(oldKennel.AnimalKennelID - 1)] = newKennel;
                result = 1;
            }
            else
            {
                throw new ApplicationException("data not found");
            }
            return result;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/17/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
        /// 
        /// Same method as above. Just here to make sure the interface works
        /// </summary>
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/9/2020
        /// Update: Updated return value so we weren't using a magic number
        /// </remarks>
        /// <param name="oldKennel"></param>
        /// <param name="newKennel"></param>
        /// <returns></returns>
        public int UpdateKennelRecordNoDateOut(AnimalKennel oldKennel, AnimalKennel newKennel)
        {
            int result = 0;
            AnimalKennel kennel = null;
            kennel = (records.Find(n => n.AnimalKennelID == oldKennel.AnimalKennelID));

            if (kennel != null)
            {
                records[(oldKennel.AnimalKennelID - 1)] = newKennel;
                result = 1;
            }
            else
            {
                throw new ApplicationException("data not found");
            }
            return result;
        }
    }
}

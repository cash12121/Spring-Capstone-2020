using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/4/2020
    /// Approver:
    /// 
    /// Interface for the kennel cleaning manager
    /// </summary>
    public class AnimalKennelCleaningManager : IAnimalKennelCleaningManager
    {
        private IAnimalKennelCleaningAccessor _cleaningAccessor;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// Approver:
        /// 
        /// Constructor for the real data access class
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalKennelCleaningManager()
        {
            _cleaningAccessor = new AnimalKennelCleaningAccessor();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Constructor for the fake data access class
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="cleaningAccessor"></param>
        public AnimalKennelCleaningManager(IAnimalKennelCleaningAccessor cleaningAccessor)
        {
            _cleaningAccessor = cleaningAccessor;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Adds the kennel cleaning record to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="cleaningRecord"></param>
        /// <returns></returns>
        public bool AddKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord)
        {
            bool result = false;

            try
            {
                result = _cleaningAccessor.InsertKennelCleaningRecord(cleaningRecord) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Record not added.", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/9/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Edits a cleaning record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldRecord"></param>
        /// <param name="newRecord"></param>
        /// <returns></returns>
        public bool EditKennelCleaningRecord(AnimalKennelCleaningRecord oldRecord, AnimalKennelCleaningRecord newRecord)
        {
            try
            {
                return 1 == _cleaningAccessor.UpdateKennelCleaningRecord(oldRecord, newRecord);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update Failed: Kennel Cleaning Record not Found", ex);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/8/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Retrieves all of the kennel cleaning records from the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns></returns>
        public List<AnimalKennelCleaningRecord> RetrieveAllKennelCleaningRecords()
        {
            try
            {
                return _cleaningAccessor.SelectAllKennelCleaningRecords();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Kennel cleaning Records not Found", ex);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/10/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Deletes a cleaning record from the database 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="cleaningRecord"></param>
        /// <returns></returns>
        public bool RemoveKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord)
        {
            bool result = false;
            try
            {
                result = _cleaningAccessor.DeleteKennelCleaningRecord(cleaningRecord) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Cleaning Record not deleted!", ex);
            }

            return result;
        }
    }
}

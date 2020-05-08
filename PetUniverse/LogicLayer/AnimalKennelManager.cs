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
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/14/2020
    /// Approver: Chuck Baxter, 2/14/2020
    /// 
    /// Manager class for the animal kennel table
    /// </summary>
    public class AnimalKennelManager : IAnimalKennelManager
    {
        private IAnimalKennelAccessor _kennelAccessor;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Constructor for real data access methods
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalKennelManager()
        {
            _kennelAccessor = new AnimalKennelAccessor();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Constructor for fake data access methods
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennelAccessor"></param>
        public AnimalKennelManager(IAnimalKennelAccessor kennelAccessor)
        {
            _kennelAccessor = kennelAccessor;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Adds a new kennel record to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennel"></param>
        /// <returns> returns True if the method was successful </returns>
        public bool AddKennelRecord(AnimalKennel kennel)
        {
            bool result = false;

            try
            {
                result = _kennelAccessor.InsertKennelRecord(kennel) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Record not added.", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
        /// 
        /// Updates a single kennel record in the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldKennel"></param>
        /// <param name="newKennel"></param>
        /// <returns> Returns true if record was updated successfully </returns>
        public bool EditKennelRecord(AnimalKennel oldKennel, AnimalKennel newKennel)
        {
            try
            {
                if (oldKennel.AnimalKennelDateOut != null)
                {
                    return 1 == _kennelAccessor.UpdateKennelRecord(oldKennel, newKennel);
                }
                else
                {
                    return 1 == _kennelAccessor.UpdateKennelRecordNoDateOut(oldKennel, newKennel);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update Failed: Kennel Record not Found", ex);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/13/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Gets all kennel records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns> A list of all of the kennel records in the database </returns>
        public List<AnimalKennel> GetAllAnimalKennels()
        {
            try
            {
                return _kennelAccessor.RetriveAllAnimalKennels();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Kennel Records not Found", ex);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
        /// 
        /// Chnges the value of the dateout field
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennel"></param>
        /// <returns> True represents a successful action </returns>
        public bool SetDateOut(AnimalKennel kennel)
        {
            try
            {
                return 1 == _kennelAccessor.AddDateOut(kennel);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Date update failed", ex);
            }
        }
    }
}

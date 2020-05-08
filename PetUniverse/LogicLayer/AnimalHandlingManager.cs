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
    /// Created: 2/21/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver:
    /// 
    /// Manager class for AnimalHandlingNotes
    /// </summary>
    public class AnimalHandlingManager : IAnimalHandlingManager
    {
        private IAnimalHandlingAccessor _handlingAccessor;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Constructor for the manager class. Real data access class.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalHandlingManager()
        {
            _handlingAccessor = new AnimalHandlingAccessor();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Constructor for the manager. Fake data access class.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="handlingAccessor"></param>
        public AnimalHandlingManager(IAnimalHandlingAccessor handlingAccessor)
        {
            _handlingAccessor = handlingAccessor;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/3/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver: 
        /// 
        /// Adds a record to the animal handling notes table.
        /// </summary> 
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="handlingNotes"></param>
        /// <returns></returns>
        public bool AddAnimalHandlingNotes(AnimalHandlingNotes handlingNotes)
        {
            bool result = false;
            try
            {
                result = _handlingAccessor.InsertAnimalHandlingNotes(handlingNotes) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Handling Record not added", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/5/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver: 
        /// 
        /// Updates a single animal handling notes record.
        /// </summary> 
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldNotes"></param>
        /// <param name="newNotes"></param>
        /// <returns></returns>
        public bool EditAnimalHandlingNotes(AnimalHandlingNotes oldNotes, AnimalHandlingNotes newNotes)
        {
            bool result = false;

            try
            {
                result = 1 == _handlingAccessor.UpdateAnimalHandlingNotes(oldNotes, newNotes);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update failed", ex);
            }

            return result;
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get Handling notes list by animal ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns>List of animal objects</returns>
        public List<AnimalHandlingNotes> GetAllHandlingNotesByAnimalID(int animalID)
        {
            try
            {
                return _handlingAccessor.SelectAllHandlingNotesByAnimalID(animalID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Handling Records not found", ex);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Get single animal handling notes object
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="handlingNotesID"></param>
        /// <returns>A single animal handling notes object</returns>
        public AnimalHandlingNotes GetHandlingNotesByID(int handlingNotesID)
        {
            try
            {
                return _handlingAccessor.SelectHandlingNotesByID(handlingNotesID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Selected Handling Record not found", ex);
            }
        }
    }
}

using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/21/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver: Chuck Baxter, 2/21/2020
    /// 
    /// Fake data access class for the animal handling notes
    /// </summary>
    public class FakeAnimalHandlingAccessor : IAnimalHandlingAccessor
    {

        private List<AnimalHandlingNotes> _handlingList;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// A constructor that makes a list of animal handling notes records for editing.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FakeAnimalHandlingAccessor()
        {
            _handlingList = new List<AnimalHandlingNotes>()
            {
                new AnimalHandlingNotes()
                {
                    HandlingNotesID = 100000,
                    UserID = 100000,
                    AnimalID = 100000,
                    HandlingNotes = "notes",
                    TemperamentWarning = "calm",
                    UpdateDate = DateTime.Now
                }
            };
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/28/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver:
        /// 
        /// Simlates adding a record to the database. Gives a deliberate error depending on the PK value.
        /// </summary>
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/9/2020
        /// Update: Updated return value so we weren't using a magic number
        /// </remarks>
        /// <param name="notes"></param>
        /// <returns> Represents the number of rows effected. </returns>
        public int InsertAnimalHandlingNotes(AnimalHandlingNotes notes)
        {
            int result = 0;
            if (notes.HandlingNotesID == 1)
            {
                _handlingList.Add(notes);
                result = 1;
            }
            else
            {
                throw new ApplicationException("Unit Test Insert Handling Notes Exception");
            }
            return result;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// simulates the presence of a method to return a list of animal notes
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns></returns>
        public List<AnimalHandlingNotes> SelectAllHandlingNotesByAnimalID(int animalID)
        {
            if ((from a in _handlingList
                 where a.AnimalID == animalID
                 select a).Count() >= 1)
            {
                return _handlingList;
            }
            else
            {
                throw new ApplicationException("data not found");
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Simulates a method to return a single Animal Handling Notes record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="handlingNotesID"></param>
        /// <returns></returns>
        public AnimalHandlingNotes SelectHandlingNotesByID(int handlingNotesID)
        {
            if ((from a in _handlingList
                 where a.HandlingNotesID == handlingNotesID
                 select a).Count() >= 1)
            {
                return _handlingList[0];
            }
            else
            {
                throw new ApplicationException("data not found");
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/29/2020
        /// Approver: Chuck Baxter, 3/5/2020        
        /// 
        /// Simulates a method to Update a an existing handling record.
        /// </summary>
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/9/2020
        /// Update: Updated return value so we weren't using a magic number
        /// </remarks>
        /// <param name="oldNotes"></param>
        /// <param name="newNotes"></param>
        /// <returns></returns>
        public int UpdateAnimalHandlingNotes(AnimalHandlingNotes oldNotes, AnimalHandlingNotes newNotes)
        {
            int result;
            AnimalHandlingNotes note = (_handlingList.Find(n => n.HandlingNotesID == oldNotes.HandlingNotesID));
            if (note != null)
            {
                int i = _handlingList.IndexOf(note);
                _handlingList[i] = newNotes;
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

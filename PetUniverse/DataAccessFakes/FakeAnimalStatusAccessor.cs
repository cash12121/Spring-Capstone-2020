using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/12/2020
    /// Approver: Michael Thompson
    /// 
    /// Animal Status Data Access fake used for testing purposes
    /// </summary>
    public class FakeAnimalStatusAccessor : IAnimalStatusAccessor
    {

        private List<AnimalStatus> _animalStatuses = new List<AnimalStatus>();

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// Constructor for the fake accessor, creates a list of 
        /// Animal Status objects.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public FakeAnimalStatusAccessor()
        {
            _animalStatuses = new List<AnimalStatus>()
            {
                new AnimalStatus()
                {
                    AnimalID = 1,
                    StatusID = "Fake1"
                },

                new AnimalStatus()
                {
                    AnimalID = 2,
                    StatusID = "Fake2"
                },

                new AnimalStatus()
                {
                    AnimalID = 3,
                    StatusID = "Fake3"
                },

                new AnimalStatus()
                {
                    AnimalID = 4,
                    StatusID = "Fake4"
                }
            };
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// Deletes a fake animal status
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="animalID"></param>
        /// <param name="statusID"></param>
        /// <returns></returns>
        public int DeleteAnimalStatus(int animalID, string statusID)
        {
            int rows = 0;
            foreach (var a in _animalStatuses)
            {
                if (a.AnimalID == animalID && a.StatusID == statusID)
                {
                    //_animalStatuses.Remove(a);
                    rows = 1;
                }
            }
            return rows;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// Inserts a fake animal status
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="animalID"></param>
        /// <param name="statusID"></param>
        /// <returns></returns>
        public int InsertAnimalStatus(int animalID, string statusID)
        {
            int rows = 0;

            AnimalStatus animalStatus = new AnimalStatus()
            {
                AnimalID = animalID,
                StatusID = statusID
            };
            try
            {
                _animalStatuses.Add(animalStatus);
                rows = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// Selesct fake animal statuses by AnimalID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns></returns>
        public List<string> SelectAnimalStatusesByAnimalID(int animalID)
        {
            List<string> statuses = new List<string>();

            try
            {
                foreach (AnimalStatus a in _animalStatuses)
                {
                    if (a.AnimalID == animalID)
                    {
                        statuses.Add(a.StatusID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return statuses;
        }
    }
}

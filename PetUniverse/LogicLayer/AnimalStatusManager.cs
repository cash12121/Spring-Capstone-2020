using DataAccessInterfaces;
using DataAccessLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/11/2020
    /// Approver: Michael Thompson
    /// 
    /// Manager class for animal statuses
    /// </summary>
    public class AnimalStatusManager : IAnimalStatusManager
    {
        IAnimalStatusAccessor _animalStatusAccessor;

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// no-argument constructor for this class, this is the stndard constructor
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        public AnimalStatusManager()
        {
            _animalStatusAccessor = new AnimalStatusAccessor();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// full constructor for this class, used for testing
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        public AnimalStatusManager(IAnimalStatusAccessor animalStatusAccessor)
        {
            _animalStatusAccessor = animalStatusAccessor;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// this sends an animal status to the data access layer
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="animalID"></param>
        /// <param name="statusID"></param>
        /// <returns></returns>
        public bool AddAnimalStatus(int animalID, string statusID)
        {
            bool result = false;
            try
            {
                result = 1 == _animalStatusAccessor.InsertAnimalStatus(animalID, statusID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Animal Status not added.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// this deletes an animal status from the data access layer
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="animalID"></param>
        /// <param name="statusID"></param>
        /// <returns></returns>
        public bool DeleteAnimalStatus(int animalID, string statusID)
        {
            bool result = false;
            try
            {
                result = 1 == _animalStatusAccessor.DeleteAnimalStatus(animalID, statusID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Animal Status not deleted.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// this retrieves an animal status from the data access layer
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns></returns>
        public List<string> RetrieveAnimalStatusesByAnimalID(int animalID)
        {
            try
            {
                return _animalStatusAccessor.SelectAnimalStatusesByAnimalID(animalID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Status not added.", ex);
            }
        }
    }
}

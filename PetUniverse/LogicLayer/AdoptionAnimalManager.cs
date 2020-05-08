using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/5/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Logic Layer class for Adoption Animal stuff
    /// </summary>
    public class AdoptionAnimalManager : IAdoptionAnimalManager
    {
        IAdoptionAnimalAccessor _adoptionAnimalAccessor;

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// No argument Constructor for AdoptionAnimalManager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public AdoptionAnimalManager()
        {
            _adoptionAnimalAccessor = new AdoptionAnimalAccessor();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Cunstructor used for testing purposes
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="adoptionAnimalAccessor"></param>
        public AdoptionAnimalManager(IAdoptionAnimalAccessor adoptionAnimalAccessor)
        {
            _adoptionAnimalAccessor = adoptionAnimalAccessor;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/4/2020
        /// Approver: Micheal Thompson, 4/9/2020
        /// 
        /// Deactivates an animal
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns></returns>
        public bool DeactivateAnimal(int animalID)
        {
            try
            {
                return 1 == _adoptionAnimalAccessor.DeactivateAdoptionAnimal(animalID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Animal was not deactivated.", ex);
            }
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/29/2020
        /// Approver: 
        /// 
        /// updates an animals adoptable field
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="animalID"></param>
        /// <param name="adoptable"></param>
        /// <returns></returns>
        public bool EditAnimalAdoptable(int animalID, bool adoptable)
        {
            try
            {
                return 1 == _adoptionAnimalAccessor.UpdateAnimalAdoptable(animalID, adoptable);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Database Error", ex);
            }
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Micheal Thompson, 4/9/2020
        /// 
        /// Retrieves a list of adoption animal VMs from data access layer
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<AdoptionAnimalVM> RetrieveAdoptionAnimalsByActive(bool active)
        {
            try
            {
                return _adoptionAnimalAccessor.SelectAdoptionAnimalsByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/29/2020
        /// Approver: 
        /// 
        /// Retrieves a list of adoption animals from data access layer
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <param name="adoptable"></param>
        /// <returns></returns>
        public List<Animal> RetrieveAdoptionAnimalsByActiveAndAdoptable(bool active = true, bool adoptable = true)
        {
            try
            {
                return _adoptionAnimalAccessor.SelectAdoptionAnimalsByActiveAndAdoptable(active, adoptable);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Database Error", ex);
            }
        }
    }
}

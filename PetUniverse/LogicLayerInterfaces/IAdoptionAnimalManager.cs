using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/5/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Holds the interface methods for the AdoptionAnimalManager Class
    /// </summary>
    public interface IAdoptionAnimalManager
    {

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/29/2020
        /// Approver: 
        /// 
        /// Interface to retrieve Adoption Animals by active and adoptable
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
        List<Animal> RetrieveAdoptionAnimalsByActiveAndAdoptable(bool active = true, bool adoptable = true);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Interface to retrieve Adoption Animals by active
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        List<AdoptionAnimalVM> RetrieveAdoptionAnimalsByActive(bool active);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/4/2020
        /// Approver: 
        /// 
        /// Deactivates an animal
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        bool DeactivateAnimal(int animalID);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/29/2020
        /// Approver: 
        /// 
        /// updates an animal adoptable quality
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
        bool EditAnimalAdoptable(int animalID, bool adoptable);
    }
}

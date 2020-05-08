using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/5/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This class contains Data Access fakes for data pertaining to Adoption Appointments.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public interface IAdoptionAnimalAccessor
    {
        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/5/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This class contains Data Access fakes for data pertaining to Adoption Appointments.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        List<AdoptionAnimalVM> SelectAdoptionAnimalsByActive(bool active);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/29/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// selects a list of adoptable animals from the database
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <param name="adoptable"></param>
        /// <returns></returns>
        List<Animal> SelectAdoptionAnimalsByActiveAndAdoptable(bool active, bool adoptable);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/4/2020
        /// CHECKED BY: Micheal Thompson, 4/9/2020
        /// 
        /// Deactivates an animal
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        int DeactivateAdoptionAnimal(int animalID);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/4/2020
        /// CHECKED BY: 
        /// 
        /// updates an animal as adoptable or unadoptable
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="animalID"></param>
        /// <param name="adoptable"></param>
        /// <returns></returns>
        int UpdateAnimalAdoptable(int animalID, bool adoptable);
    }
}

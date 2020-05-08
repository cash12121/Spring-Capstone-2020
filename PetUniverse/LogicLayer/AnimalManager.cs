using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// Animal manager class that has logic methods for the animal class
    /// </summary>
    public class AnimalManager : IAnimalManager
    {
        private IAnimalAccessor _animalAccessor;

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// constructor for animal manager for real data access
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public AnimalManager()
        {
            _animalAccessor = new AnimalAccessor();
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// constructor for animal manager for the fake data object
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="animalAccessor"></param>
        public AnimalManager(IAnimalAccessor animalAccessor)
        {
            _animalAccessor = animalAccessor;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// logic method that passes an animal object to the accessor method
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool AddNewAnimal(Animal animal)
        {
            bool result = true;
            try
            {
                result = _animalAccessor.InsertAnimal(animal) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Animal not added.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/13/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Daulton Schilling, 2/14/2020
        /// 
        /// logic method that uses an AnimalAccessor method to get a list of all animals
        /// that are marked as active
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of animal objects or an exception if the data wasnt found</returns>
        public List<Animal> RetrieveAnimalsByActive(bool active = true)
        {
            try
            {
                return _animalAccessor.SelectAnimalsByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// logic method that uses an AnimalAccessor method to get a list of all animals
        /// that are marked as inactive
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of animal objects or an exception if the data wasnt found</returns>
        public List<Animal> RetrieveAnimalsByInactive(bool active = false)
        {
            try
            {
                return _animalAccessor.SelectAnimalsByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/28/2020
        /// Approver: Jordan Lindo, 2/28/2020
        /// Approver: 
        /// 
        /// logic method that uses an AnimalAccessor method to get a list of all animal
        /// species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of strings or an exception if the data wasn't found</returns>
        public List<string> RetrieveAnimalSpecies()
        {
            try
            {
                return _animalAccessor.SelectAnimalSpeciesID();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Checked By: Austin Gee  
        /// 
        /// Logic method to update a Animal Profile 
        /// </summary>
        /// <remarks>
        /// Updater: Michael Thompson
        /// Updated: 4/20/2020
        /// Update: To book specifications
        /// Approver: Austin Gee
        /// </remarks>
        /// <param name="animalID"></param>
        /// <param name="profileDescription"></param>
        /// <param name="profileImageData"></param>
        /// <param name="profileImageMimeType"></param>
        /// <returns>Bool of whether or not the value was successfully updated</returns>
        public bool UpdatePetProfile(int animalID, string profileDescription, byte[] profileImageData, string profileImageMimeType)
        {
            bool result;

            try
            {
                result = _animalAccessor.UpdateAnimalProfile(animalID, profileDescription, profileImageData, profileImageMimeType);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update Failed!", ex);
            }
            return result;
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// 
        /// logic method that uses an AnimalAccessor method to get a list of all animal profiles
        /// </summary>
        /// <remarks>
        /// Updater: Michael Thompson
        /// Updated: 4/27/2020
        /// Update: To book specifications for images
        /// Approver: Austin Gee
        /// </remarks>
        /// <returns>a list of animal objects or an exception if the data was not found</returns>
        public List<Animal> RetrieveAllAnimalProfiles()
        {
            try
            {
                return _animalAccessor.SelectAllAnimnalProfiles();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/12/2020
        /// Approver: Austin Gee, 3/12/2020  
        /// 
        /// Logic method to update an Animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>Bool of whether or not the value was successfully updated</returns>
        public bool EditAnimal(Animal oldAnimal, Animal newAnimal)
        {
            try
            {
                return 1 == _animalAccessor.UpdateAnimal(oldAnimal, newAnimal);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update Failed!", ex);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Calls either the ActivateAnimal or DeactivateAnimal method based on the boolean value supplied
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="active"> Boolean value representing the value to change the active state to </param>
        /// <param name="animalID"> The primary key identifying the animal </param>
        /// <returns> Boolean value representing if the method succeeded or not. True = success. </returns>
        public bool SetAnimalActiveState(bool active, int animalID)
        {
            bool result = false;
            try
            {
                if (active)
                {
                    result = 1 == _animalAccessor.ActivateAnimal(animalID);
                }
                else
                {
                    result = 1 == _animalAccessor.DeactivateAnimal(animalID);
                }
                if (result == false)
                {
                    throw new ApplicationException("Error: Active state not changed.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed!", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Calls either the ActivateAnimal or DeactivateAnimal method based on the boolean value supplied
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="adoptable"> Boolean value representing the value to change the adoptable state to </param>
        /// <param name="animalID"> The primary key identifying the animal </param>
        /// <returns> Boolean value representing if the method succeeded or not. True = success. </returns>
        public bool SetAnimalAdoptableState(bool adoptable, int animalID)
        {
            bool result = false;
            try
            {
                if (adoptable)
                {
                    result = 1 == _animalAccessor.ActivateAdoptable(animalID);
                }
                else
                {
                    result = 1 == _animalAccessor.DeactivateAdoptable(animalID);
                }
                if (result == false)
                {
                    throw new ApplicationException("Error: Adoptable state not changed.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed!", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Calls either the ActivateAnimal or DeactivateAnimal method based on the boolean value supplied
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="housed"> Boolean value representing the value to change the Housed state to </param>
        /// <param name="animalID"> The primary key identifying the animal </param>
        /// <returns> Boolean value representing if the method succeeded or not. True = success. </returns>
        public bool SetAnimalHousedState(bool housed, int animalID)
        {
            bool result = false;
            try
            {
                if (housed)
                {
                    result = 1 == _animalAccessor.ActivateCurrentlyHoused(animalID);
                }
                else
                {
                    result = 1 == _animalAccessor.DeactivateCurrentlyHoused(animalID);
                }
                if (result == false)
                {
                    throw new ApplicationException("Error: Housed state not changed.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed!", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Gets a list of animal names
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal names</returns>
        public List<AnimalNames> RetrieveNames()
        {
            try
            {
                return _animalAccessor.GetNames();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Gets an animal by its ID number
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="ID"></param>
        /// <returns>List of animal attributes</returns>
        public List<Animal> RetrieveAnimalByAnimalID(int ID)
        {
            try
            {
                return _animalAccessor.GetAnimalByAnimalID(ID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 4/25/2020
        /// Approver: Austin Gee
        /// Gets one animal by its ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="ID"></param>
        /// <returns>1 Animal with that ID</returns>
        public Animal RetrieveOneAnimalByAnimalID(int ID)
        {
            try
            {
                return _animalAccessor.GetOneAnimalByAnimalID(ID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/13/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// logic method that passes an animal species and description to the accessor method
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="animalSpecies"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool AddNewAnimalSpecies(string animalSpecies, string description)
        {
            bool result = true;
            try
            {
                result = _animalAccessor.InsertAnimalSpecies(animalSpecies, description) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Animal not added.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// logic method that passes an animal species to the accessor method for deletion
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="animalSpeciesID"></param>
        /// <returns></returns>
        public bool DeleteAnimalSpecies(string animalSpeciesID)
        {
            bool result = true;
            try
            {
                result = _animalAccessor.DeleteAnimalSpecies(animalSpeciesID) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Animal Species not deleted", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// logic method that passes an animal species to the accessor method for update
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="oldAnimalSpeciesID"></param>
        /// <param name="newAnimalSpeciesID"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool EditAnimalSpecies(string oldAnimalSpeciesID, string newAnimalSpeciesID, string description)
        {
            try
            {
                return 1 == _animalAccessor.UpdateAnimalSpecies(oldAnimalSpeciesID, newAnimalSpeciesID, description);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update Failed!", ex);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 5/3/2020
        /// Approver: Chuck Baxter 5/5/2020
        /// 
        /// Retrieves all animals of a specific name
        /// </summary>
        /// <param name="name">The name to search</param>
        /// <param name="list">
        /// The list to iterate through. If one isn't provided
        /// a new one will be fetched
        /// </param>
        /// <returns>List of animals</returns>
        public List<Animal> RetrieveAnimalsByName(string name, List<Animal> list = null)
        {
            if (list == null)
            {
                list = RetrieveAnimalsByActive(true);
            }
            return list.Where(a => a.AnimalName.ToLower() == name.ToLower()).ToList();
        }
    }
}

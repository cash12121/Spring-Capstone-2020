using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{



    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// an interface for accessing the animal data
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public interface IAnimalAccessor
    {
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
        List<Animal> GetAnimalByAnimalID(int ID);

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
        List<AnimalNames> GetNames();

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 4/25/2020
        /// Approver: Austin Gee
        /// Approver: 
        /// Gets an animal by its ID number
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="ID"></param>
        /// <returns>Returns one animal with that ID</returns>
        Animal GetOneAnimalByAnimalID(int ID);


        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// a data access method for creating a new animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animal"></param>
        /// <returns>a 1 if successful, 0 if a failure</returns>
        int InsertAnimal(Animal animal);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/13/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Daulton Schilling, 2/14/2020
        /// 
        /// a data access method for retrieving a list of all animals that are listed as active
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of animal objects</returns>

        List<Animal> SelectAnimalsByActive(bool active = true);
        /// <summary>
        /// NAME: Michael Thompson
        /// DATE: 2/20/2020
        /// CHECKED BY: Austin Gee, 2/21/2020
        /// 
        /// Updates the animal with their forward facing description and image
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Michael Thompson 
        /// UPDATED DATE: 4/27/2020
        /// CHANGE: Updating to book specification for images
        /// Approver: Austin Gee
        /// </remarks>
        /// <param name="animalID">The animalID.</param>
        /// <param name="profileDescription">The profile description.</param>
        /// <param name="profileImageData">The profile image Data as a byte array.</param>
        /// <param name="profileImageMimeType">The file type of teh image data</param>
        /// <returns>Bool</returns>
        bool UpdateAnimalProfile(int animalID, string profileDescription, byte[] profileImageData, string profileImageMimeType);

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// Approver: 
        /// 
        /// a data access Interface for retrieving a list of all animal profiles
        /// </summary>
        /// <remarks>
        /// Updater: Michael Thompson
        /// Updated: 4/27/2020
        /// Update: Adding images to book specification
        /// Approver: Austin Gee
        /// </remarks>
        /// <returns>a list of animal objects</returns>
        List<Animal> SelectAllAnimnalProfiles();

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// a data access method for retrieving a list of all animals that are listed as inactive
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of animal objects</returns>
        List<Animal> SelectAnimalsByInactive(bool active = false);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/28/2020
        /// Approver: Jordan Lindo, 2/28/2020
        /// Approver: 
        /// 
        /// a data access method for retrieving a list of all animals species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>a list of animal species</returns>
        List<string> SelectAnimalSpeciesID();

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/12/2020
        /// Approver: Austin Gee, 3/12/2020
        /// Approver: 
        /// 
        /// a data access method for updating an animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>an int</returns>
        int UpdateAnimal(Animal oldAnimal, Animal newAnimal);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's Active state to 'true'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        int ActivateAnimal(int AnimalID);
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's Active state to 'false'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        int DeactivateAnimal(int AnimalID);


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's Adoptable state to 'true'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        int ActivateAdoptable(int AnimalID);
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's Adoptable state to 'false'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        int DeactivateAdoptable(int AnimalID);


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's CurrentlyHoused state to 'true'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        int ActivateCurrentlyHoused(int AnimalID);

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/1/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's CurrentlyHoused state to 'False'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        int DeactivateCurrentlyHoused(int AnimalID);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/13/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver:
        /// 
        /// a data access method for creating a new animal species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalSpecies"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        int InsertAnimalSpecies(string animalSpecies, string description);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver:
        /// 
        /// a data access method for deleting an animal species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalSpeciesID"></param>
        /// <returns></returns>
        int DeleteAnimalSpecies(string animalSpeciesID);

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020
        /// Approver:
        /// 
        /// a data access method for updating an animal species
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
        int UpdateAnimalSpecies(string oldAnimalSpeciesID, string newAnimalSpeciesID, string description);
    }
}

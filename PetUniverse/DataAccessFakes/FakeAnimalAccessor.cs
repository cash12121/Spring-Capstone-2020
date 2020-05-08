using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// The fake animal accessor class, uses a collection of animal objects instead of an actual database
    /// </summary>
    public class FakeAnimalAccessor : IAnimalAccessor
    {
        private List<Animal> animals;
        private List<Animal> activeAnimals;
        private List<string> species;
        private List<AnimalNames> names;
        private Animal _animal;
        private List<Animal> animalProfiles;
        private List<string> animalSpeciesList;

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// the List of animals to use in tests instead of an actual database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public FakeAnimalAccessor()
        {
            animals = new List<Animal>()
            {
                new Animal()
                {
                    AnimalID = 1,
                    AnimalName = "A",
                    Dob = DateTime.Now.Date,
                    AnimalBreed = "A",
                    ArrivalDate = DateTime.Now.Date,
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    AnimalSpeciesID = "A",
                },

                new Animal()
                {
                    AnimalID = 2,
                    AnimalName = "B",
                    Dob = DateTime.Now.Date,
                    AnimalBreed = "B",
                    ArrivalDate = DateTime.Now.Date,
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    AnimalSpeciesID = "B",
                }
            };

            animalProfiles = new List<Animal>()
            {
                new Animal()
                {
                    AnimalID = 1,
                    AnimalName = "A",
                    ProfileImageData = new byte[10],
                    ProfileImageMimeType = "JPG",
                    ProfileDescription = "sample description"
                },

                new Animal()
                {
                    AnimalID = 1,
                    AnimalName = "A",
                    ProfileImageData = new byte[10],
                    ProfileImageMimeType = "JPG",
                    ProfileDescription = "sample description"
                }
            };

            animalSpeciesList = new List<string>()
            {
                "Dog",
                "Doggo"
            };
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// The fake data access method for adding a new animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="animal"></param>
        /// <returns></returns>
        public int InsertAnimal(Animal animal)
        {
            try
            {
                animals.Add(animal);
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/13/2020
        /// Approver: Austin Gee
        /// The fake data access method for selecting all of the animal profiles
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <returns>The default list of animal profiles</returns>
        public List<Animal> SelectAllAnimnalProfiles()
        {
            return animalProfiles;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/13/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Daulton Schilling, 2/14/2020
        /// 
        /// The fake data access method for selecting all of the active animals
        /// in the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<Animal> SelectAnimalsByActive(bool active = true)
        {
            try
            {
                activeAnimals = new List<Animal>();
                foreach (Animal animal in animals)
                {
                    if (animal.Active)
                    {
                        activeAnimals.Add(animal);
                    }
                }
                return activeAnimals;
            }
            catch
            {
                // should be null if there is a failure
                activeAnimals = null;
                return activeAnimals;
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// The fake data access method for selecting all of the inactive animals
        /// in the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<Animal> SelectAnimalsByInactive(bool active = false)
        {
            try
            {
                activeAnimals = new List<Animal>();
                foreach (Animal animal in animals)
                {
                    if (!animal.Active)
                    {
                        activeAnimals.Add(animal);
                    }
                }
                return activeAnimals;
            }
            catch
            {
                // should be null if there is a failure
                activeAnimals = null;
                return activeAnimals;
            }
        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// 
        /// The fake data access method for updating the animal propfile and descriptiopn
        /// in the database
        /// </summary>
        /// <remarks>
        /// Updater: Michael Thompson
        /// Updated: 2/26/2020
        /// Update: Book specifications for images
        /// <param name="animalID">Animals ID</param>
        /// <param name="profileDescription">Animals profile description</param>
        /// <param name="profileImageData">Animals profile image in for of byte array</param>
        /// <param name="profileImageMimeType">File type of the profile image</param>
        /// <returns></returns>
        public bool UpdateAnimalProfile(int animalID, string profileDescription, byte[] profileImageData, string profileImageMimeType)
        {
            _animal = new Animal()
            {
                AnimalID = 100000,
                ProfileDescription = "This is a fake Pet profile description",
                ProfileImageData = new byte[10],
                ProfileImageMimeType = "JPG"

            };
            return true;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/28/2020
        /// Approver: Jordan Lindo, 2/28/2020
        /// Approver: 
        /// 
        /// Fake data access that returns a list of strings for animal species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param ></param>
        /// <returns>List of strings></returns>
        public List<string> SelectAnimalSpeciesID()
        {
            species = new List<string>{
                "Dog",
                "Cat"
            };
            return species;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/12/2020
        /// Approver: Austin Gee, 3/12/2020
        /// 
        /// Fake data access that returns 1 if the ids match, otherwise returns 0
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimal"></param>
        /// <param name="newAnimal"></param>
        /// <returns></returns>
        public int UpdateAnimal(Animal oldAnimal, Animal newAnimal)
        {
            foreach (Animal animal in animals)
            {
                if (animal.AnimalID == oldAnimal.AnimalID)
                {
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Dummy method that returns the result as if the real method had succeded.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver:
        /// </remarks>
        /// <param name="AnimalID">Primary key that identifies the animal</param>
        /// <returns>The number of animals that match the supplied primary key. Should either be 0 (fail) or 1 (success)</returns>
        public int ActivateAdoptable(int animalID)
        {
            int animalIndex = animals.FindIndex(a => a.AnimalID == animalID);

            Animal animal = animals[animalIndex];

            animal.Adoptable = true;

            animals[animalIndex] = animal;

            return (from a in animals
                    where a.AnimalID == animalID && a.Adoptable == true
                    select a).Count();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Dummy method that returns the result as if the real method had succeded.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> Primary key that identifies the animal </param>
        /// <returns>The number of animals that match the supplied primary key. Should either be 0 (fail) or 1 (success)</returns>
        public int ActivateAnimal(int animalID)
        {
            return (from a in animals
                    where a.AnimalID == animalID
                    select a).Count();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Dummy method that returns the result as if the real method had succeded.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> Primary key that identifies the animal </param>
        /// <returns>The number of animals that match the supplied primary key. Should either be 0 (fail) or 1 (success)</returns>
        public int ActivateCurrentlyHoused(int animalID)
        {
            return (from a in animals
                    where a.AnimalID == animalID
                    select a).Count();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Dummy method that returns the result as if the real method had succeded.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> Primary key that identifies the animal </param>
        /// <returns>The number of animals that match the supplied primary key. Should either be 0 (fail) or 1 (success)</returns>
        public int DeactivateAdoptable(int animalID)
        {
            return (from a in animals
                    where a.AnimalID == animalID
                    select a).Count();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Dummy method that returns the result as if the real method had succeded.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> Primary key that identifies the animal </param>
        /// <returns>The number of animals that match the supplied primary key. Should either be 0 (fail) or 1 (success)</returns>
        public int DeactivateAnimal(int animalID)
        {


            return (from a in animals
                    where a.AnimalID == animalID
                    select a).Count();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Dummy method that returns the result as if the real method had succeded.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> Primary key that identifies the animal </param>
        /// <returns>The number of animals that match the supplied primary key. Should either be 0 (fail) or 1 (success)</returns>
        public int DeactivateCurrentlyHoused(int animalID)
        {
            return (from a in animals
                    where a.AnimalID == animalID
                    select a).Count();
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/13/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// 
        /// Fake data access that returns a list of animal names
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param ></param>
        /// <returns>List of animal names></returns>
        public List<AnimalNames> GetNames()
        {
            try
            {
                names = new List<AnimalNames>();
                foreach (AnimalNames name_ in names)
                {
                    names.Add(name_);
                }
                return names;
            }
            catch
            {

                names = null;
                return names;
            }
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/13/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// 
        /// Fake data access that returns an animal by its ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param ></param>
        /// <returns>List of animal attributes></returns>
        public List<Animal> GetAnimalByAnimalID(int ID)
        {
            try
            {
                activeAnimals = new List<Animal>();
                foreach (Animal animal in animals)
                {
                    if (animal.AnimalID == ID)
                    {
                        activeAnimals.Add(animal);
                    }
                }
                return activeAnimals;
            }
            catch
            {
                activeAnimals = null;
                return activeAnimals;
            }
        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 4/25/2020
        /// Approver: Austin Gee
        /// The fake data access method for selecting one animal by its animalID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Animal GetOneAnimalByAnimalID(int ID)
        {
            Animal animal = new Animal();
            try
            {

                foreach (var item in animals)
                {
                    if (item.AnimalID == ID)
                    {
                        animal = item;
                    }
                }
                return animal;
            }
            catch
            {
                animal = null;
                return animal;
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020
        /// Approver:
        /// 
        /// The fake data access method for adding a new animal species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="animalSpecies"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public int InsertAnimalSpecies(string animalSpecies, string description)
        {
            try
            {
                animalSpeciesList.Add(animalSpecies);
                animalSpeciesList.Add(description);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver:
        /// 
        /// The fake data access method for deleting an animal species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="animalSpeciesID"></param>
        /// <returns></returns
        public int DeleteAnimalSpecies(string animalSpeciesID)
        {
            foreach (string species in animalSpeciesList)
            {
                if (animalSpeciesID == species)
                {
                    try
                    {
                        animalSpeciesList.Remove(species);
                        return 1;
                    }
                    catch
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver:
        /// 
        /// The fake data access method for updating an animal species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="oldAnimalSpeciesID"></param>
        /// <param name="newAnimalSpeciesID"></param>
        /// <param name="description"></param>
        /// <returns></returns
        public int UpdateAnimalSpecies(string oldAnimalSpeciesID, string newAnimalSpeciesID, string description)
        {
            foreach (string animalSpeciesID in animalSpeciesList)
            {
                if (oldAnimalSpeciesID == animalSpeciesID)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}

using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/5/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Adoption Animal Data Access fake used for testing purposes
    /// </summary>
    public class FakeAdoptionAnimalAccessor : IAdoptionAnimalAccessor
    {
        private List<AdoptionAnimalVM> _adoptionAnimalVMs;
        private List<Animal> _animals;

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Constructor for the fake accessor, creates a list of 
        /// AdoptionAnimalVMs for testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public FakeAdoptionAnimalAccessor()
        {
            _adoptionAnimalVMs = new List<AdoptionAnimalVM>()
            {
                new AdoptionAnimalVM()
                {
                    AnimalID = 000,
                    AnimalName = "Fake",
                    Dob = DateTime.Parse("10/10/2020"),
                    AnimalBreed = "Pit Bull",
                    ArrivalDate = DateTime.Parse("10/10/2020"),
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    AnimalSpeciesID = "Dog",
                    AnimalKennelID = 000,
                    AnimalKennelInfo = "Fake",
                    AnimalMedicalInfoID = 000,
                    IsSpayedorNuetered = true,
                    AdoptionApplicationID = 000,
                    CustomerID = 000,
                    UserID = 000,
                    CustomerFirstName = "Fake",
                    CustomerLastName = "Fake",
                    AnimalHandlingNotesID = 000,
                    AnimalHandlingNotes = "Fake",
                    TempermentWarning = "Fake",

                },

                new AdoptionAnimalVM()
                {
                    AnimalID = 001,
                    AnimalName = "Fake",
                    Dob = DateTime.Parse("10/10/2020"),
                    AnimalBreed = "Pit Bull",
                    ArrivalDate = DateTime.Parse("10/10/2020"),
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    AnimalSpeciesID = "Dog",
                    AnimalKennelID = 000,
                    AnimalKennelInfo = "Fake",
                    AnimalMedicalInfoID = 000,
                    IsSpayedorNuetered = true,
                    AdoptionApplicationID = 000,
                    CustomerID = 000,
                    UserID = 000,
                    CustomerFirstName = "Fake",
                    CustomerLastName = "Fake",
                    AnimalHandlingNotesID = 000,
                    AnimalHandlingNotes = "Fake",
                    TempermentWarning = "Fake",

                },

                new AdoptionAnimalVM()
                {
                    AnimalID = 002,
                    AnimalName = "Fake",
                    Dob = DateTime.Parse("10/10/2020"),
                    AnimalBreed = "Pit Bull",
                    ArrivalDate = DateTime.Parse("10/10/2020"),
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    AnimalSpeciesID = "Dog",
                    AnimalKennelID = 000,
                    AnimalKennelInfo = "Fake",
                    AnimalMedicalInfoID = 000,
                    IsSpayedorNuetered = true,
                    AdoptionApplicationID = 000,
                    CustomerID = 000,
                    UserID = 000,
                    CustomerFirstName = "Fake",
                    CustomerLastName = "Fake",
                    AnimalHandlingNotesID = 000,
                    AnimalHandlingNotes = "Fake",
                    TempermentWarning = "Fake",

                }
            };

            _animals = new List<Animal>{
                new Animal
                {
                    AnimalID = 000,
                    AnimalName = "Fake",
                    AnimalSpeciesID = "Fake",
                    Active = true,
                    Adoptable = true,
                    AnimalBreed = "Fake",
                    ArrivalDate = DateTime.Now,
                    CurrentlyHoused = true,
                    Dob = DateTime.Now.AddDays(-100),
                    ProfileDescription = "Fake",
                    ProfileImageData = new byte[1],
                    ProfileImageMimeType = "jpg"
                },
                new Animal
                {
                    AnimalID = 001,
                    AnimalName = "Fake",
                    AnimalSpeciesID = "Fake",
                    Active = true,
                    Adoptable = true,
                    AnimalBreed = "Fake",
                    ArrivalDate = DateTime.Now,
                    CurrentlyHoused = true,
                    Dob = DateTime.Now.AddDays(-100),
                    ProfileImageData = new byte[1],
                    ProfileImageMimeType = "jpg"
                },
                new Animal
                {
                    AnimalID = 002,
                    AnimalName = "Fake",
                    AnimalSpeciesID = "Fake",
                    Active = true,
                    Adoptable = true,
                    AnimalBreed = "Fake",
                    ArrivalDate = DateTime.Now,
                    CurrentlyHoused = true,
                    Dob = DateTime.Now.AddDays(-100),
                    ProfileImageData = new byte[1],
                    ProfileImageMimeType = "jpg"
                },
            };
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/4/2020
        /// Approver: Micheal Thompson, 4/9/2020
        /// 
        /// Deactivate a fake adotion animal.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns></returns>
        public int DeactivateAdoptionAnimal(int animalID)
        {
            int rows = 0;
            foreach (var item in _animals)
            {
                if (animalID == item.AnimalID)
                {
                    item.Active = false;
                    rows += 1;
                }
            }
            return rows;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Selects Animals by active
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public List<AdoptionAnimalVM> SelectAdoptionAnimalsByActive(bool active)
        {
            return (from a in _adoptionAnimalVMs
                    where a.Active == active
                    select a).ToList();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/29/2020
        /// Approver: 
        /// 
        /// Selects Animals by active and adoptable
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
        public List<Animal> SelectAdoptionAnimalsByActiveAndAdoptable(bool active, bool adoptable)
        {
            return (from a in _animals
                    where a.Active == active
                    && a.Adoptable == adoptable
                    select a).ToList();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/29/2020
        /// Approver: 
        /// 
        /// Updates animal to adoptable or unadoptable
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
        public int UpdateAnimalAdoptable(int animalID, bool adoptable)
        {
            int rows = 0;
            foreach(Animal a in _animals)
            {
                if(a.AnimalID == animalID)
                {
                    a.Adoptable = adoptable;
                    rows += 1;
                }
            }
            return rows;
        }
    }
}

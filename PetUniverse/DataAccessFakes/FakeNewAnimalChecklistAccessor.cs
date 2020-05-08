using DataAccessLayer;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver: Chuck Baxter, 2/21/2020
    /// 
    /// A class to store fake data for New Animal Checklist/
    /// </summary>
    public class FakeNewAnimalChecklistAccessor : INewAnimalChecklistAccessor
    {

        private List<NewAnimalChecklist> animals;

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// No argument constructor for holding new animal checklist records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FakeNewAnimalChecklistAccessor()
        {
            animals = new List<NewAnimalChecklist>()
            {
                new NewAnimalChecklist()
                {
                    AnimalID = 1,
                    AnimalName = "Cujo",
                    DOB = DateTime.Now,
                    AnimalSpeciesID  = "doge",
                    AnimalBreed = "No thanks",
                    ArrivalDate = DateTime.Now,
                    CurrentlyHoused = true,
                    Adoptable = false,
                    Active = true,
                    Vaccinations = "Unknown",
                    Spayed_Neutered = true,
                    MostRecentVaccinationDate = DateTime.Now,
                    AdditionalNotes = "Prefers to be called 'Randy', likes trapp music, vapes constantly",
                    TempermantWarning = "None",
                    AnimalHandlingNotes_ = "His favorite food is the McRib from Mcdonalds."
                },

                new NewAnimalChecklist()
                {
                    AnimalID = 2,
                    AnimalName = "Unknown",
                    DOB = DateTime.Now,
                    AnimalSpeciesID = "Unknown",
                    AnimalBreed = "Unknown",
                    ArrivalDate = DateTime.Now,
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    Vaccinations = "Unknown",
                    Spayed_Neutered = false,
                    MostRecentVaccinationDate = DateTime.Now,
                    AdditionalNotes = "Not sure what species it is.",
                    TempermantWarning = "Whatever you do DO NOT make eye-contact",
                    AnimalHandlingNotes_ = "Send Help"
                },

                new NewAnimalChecklist()
                {
                    AnimalID = 3,
                    AnimalName = "Snoop",
                    DOB = DateTime.Now,
                    AnimalSpeciesID = "Dog",
                    AnimalBreed = "Doggy Dog",
                    ArrivalDate = DateTime.Now,
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    Vaccinations = "Ebola",
                    Spayed_Neutered = false,
                    MostRecentVaccinationDate = DateTime.Now,
                    AdditionalNotes = "Very calm",
                    TempermantWarning = "None",
                    AnimalHandlingNotes_ = "Sleeps constantly"
                },

                new NewAnimalChecklist()
                {
                    AnimalID = 4,
                    AnimalName = "Scooby",
                    DOB = DateTime.Now,
                    AnimalSpeciesID = "Dog",
                    AnimalBreed = "Dooby doo",
                    ArrivalDate = DateTime.Now,
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    Vaccinations = "Unknown",
                    Spayed_Neutered = false,
                    MostRecentVaccinationDate = DateTime.Now,
                    AdditionalNotes = "Addiction to Scooby snacks",
                    TempermantWarning = "None",
                    AnimalHandlingNotes_ = "None"
                }
            };
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Returns a list of fake animal records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="AnimalID"></param>
        /// <Returns>
        /// Fake Animal records
        /// </Returns>
        public List<NewAnimalChecklist> GetNewAnimalChecklistByAnimalID(int AnimalID)
        {
            try
            {
                return (from b in animals
                        where b.AnimalID == AnimalID
                        select b).ToList();
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Animal with ID " + AnimalID + " not found", ex);
            }
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/28/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// Fake method to get the number of animals housed
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <Returns>
        /// int
        /// </Returns>
        public int GetNumberOfAnimals(bool active = true)
        {
            return animals.Count;
        }
    }
}


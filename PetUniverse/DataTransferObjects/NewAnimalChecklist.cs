using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver: Chuck Baxter, 2/21/2020
    /// 
    /// Data object class for New animal checklist
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public class NewAnimalChecklist
    {

        public int AnimalID { get; set; }//0

        public string AnimalName { get; set; }//1

        public DateTime DOB { get; set; }//2

        public string AnimalSpeciesID { get; set; }//3

        public string AnimalBreed { get; set; }//4

        public DateTime ArrivalDate { get; set; }//5

        public bool CurrentlyHoused { get; set; }//6

        public bool Adoptable { get; set; }//7

        public bool Active { get; set; }//8

        public string TempermantWarning { get; set; }//9

        public string AnimalHandlingNotes_ { get; set; }//10

        public string Vaccinations { get; set; }//11

        public bool Spayed_Neutered { get; set; }

        public DateTime MostRecentVaccinationDate { get; set; }

        public string AdditionalNotes { get; set; }



    }
}

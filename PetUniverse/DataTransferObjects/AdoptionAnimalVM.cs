using System.Collections.Generic;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/5/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Adoption animal VM that extends the Animal class
    /// </summary>
    public class AdoptionAnimalVM : Animal
    {
        public int AnimalKennelID { get; set; }
        public string AnimalKennelInfo { get; set; }
        public int AnimalHandlingNotesID { get; set; }
        public string AnimalHandlingNotes { get; set; }
        public string TempermentWarning { get; set; }
        public int AnimalMedicalInfoID { get; set; }
        public bool IsSpayedorNuetered { get; set; }
        public List<string> Statuses { get; set; }
        public int AdoptionApplicationID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerEmail { get; set; }
        public List<int> AppointmentIDs { get; set; }
        public int UserID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
    }
}

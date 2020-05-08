using System.Collections.Generic;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/6/202
    /// CHECKED BY: Mohamed Elamin, 02/07/2020
    /// 
    /// This is a simple data transfer object. It contains a view model that extends the User object.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class AdoptionCustomerVM : Customer
    {
        //public int CustomerID { get; set; }
        //public int AnimalID { get; set; }
        //public string CustomerAdoptionStatus { get; set; }
        //public DateTime AdoptionApplicationRecievedDate { get; set; }
        //public string AnimalName { get; set; }
        //public string AnimalBreed { get; set; }
        //public DateTime AnimalArrivalDate { get; set; }
        //public bool CurrentlyHoused { get; set; }
        //public bool Adoptable { get; set; }
        //public bool AnimalActive { get; set; }
        //public int AdoptionApplicationID { get; set; }
        //public string AnimalSpecies { get; set; }
        public List<AdoptionApplication> AdoptionApplications { get; set; }
    }
}

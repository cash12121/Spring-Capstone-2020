using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/18/2020
    /// CHECKED BY: Micheal Thompson
    /// 
    /// Data transfer object that represents ApplicationVMs
    /// data access methods
    /// </summary>
    public class ApplicationVM : Application
    {
        [Display(Name = "Animal Name")]
        public string AnimalName { get; set; }
        [Display(Name = "Animal Species")]
        public string AnimalSpeciesID { get; set; }
        [Display(Name = "Animal Breed")]
        public string AnimalBreed { get; set; }
        [Display(Name = "Active")]
        public bool AnimalActive { get; set; }
    }
}

using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// an animal data trasfer object
    /// 
    /// <remarks>
    /// Updater: Chuck Baxter
    /// Updated: 2/28/2020
    /// Update: Removed status and image location
    /// Approver: Austin Gee
    /// 
    /// Updater:
    /// Updated:
    /// Update:
    /// </summary>remarks>
    /// </summary>
    public class Animal
    {


        public int AnimalID { get; set; }
        public string AnimalName { get; set; }
        public DateTime Dob { get; set; }
        public string AnimalSpeciesID { get; set; }
        public string AnimalBreed { get; set; }
        public DateTime ArrivalDate { get; set; }
        public bool CurrentlyHoused { get; set; }
        public bool Adoptable { get; set; }
        public bool Active { get; set; }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/7/2020
        /// Approver: Austin Gee, 2/21/2020
        /// adding ProfileDescription and ProfileImage
        /// Updated: 4/24/2020
        /// By: Michael Thompson
        /// Approver: NeedsAvpproved
        /// Comment: Updating to book specifications for images
        /// </summary>
        public string ProfileDescription { get; set; }
        public byte[] ProfileImageData { get; set; }
        public string ProfileImageMimeType { get; set; }
    }
}

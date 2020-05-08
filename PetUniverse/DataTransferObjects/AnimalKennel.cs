using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/14/2020
    /// Approver: Chuck Baxter, 2/14/2020
    /// 
    /// Data transfer object for the animal kennel table
    /// </summary>
    public class AnimalKennel
    {
        public int AnimalKennelID { get; set; }
        public int AnimalID { get; set; }
        public int UserID { get; set; }
        public string AnimalKennelInfo { get; set; }
        public DateTime AnimalKennelDateIn { get; set; }
        public DateTime? AnimalKennelDateOut { get; set; }

    }
}

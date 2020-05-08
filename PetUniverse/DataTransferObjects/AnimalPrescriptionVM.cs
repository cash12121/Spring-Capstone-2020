using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 3/15/2020
    /// Approver: Carl Davis 3/19/2020
    /// 
    /// A view model for animal prescriptions
    /// </summary>
    public class AnimalPrescriptionVM : AnimalPrescription
    {
        public string AnimalName { get; set; }
        public string PrescriptionName { get; set; }
        public decimal Dosage { get; set; }
        public string Interval { get; set; }
        public string AdministrationMethod { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}

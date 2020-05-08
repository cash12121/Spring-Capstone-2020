using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class AnimalMedical
    {
        public int AnimalMedicalInfoID { get; set; }
        public string AnimalName { get; set; }
        public bool SpayedNeutered { get; set; }
        public string Vaccinations { get; set; }
        public DateTime MostRecentVaccinationDate { get; set; }
        public string AdditionalNotes { get; set; }
        public string UserFirstName { get; set; }
        public string UseLastrName { get; set; }
       
    }
}

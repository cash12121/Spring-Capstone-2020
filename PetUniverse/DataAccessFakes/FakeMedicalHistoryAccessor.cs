using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{

    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 3/13/2020
    /// Approver: Carl Davis 4/16/2020
    /// 
    /// Fake medical record class
    /// </summary>    
    public class FakeMedicalHistoryAccessor : IAnimalMedicalHistoryAccessor
    {
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: 
        /// 
        /// Fake medical history records
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private List<MedicalHistory> MH;

        public FakeMedicalHistoryAccessor()
        {
            MH = new List<MedicalHistory>()
            {
                new MedicalHistory()
                {


            AnimalID = 1,

        AnimalName = "Cujo",

        AnimalSpeciesID  = "doge",

         Vaccinations = "Unknown",

         Spayed_Neutered = true,

         MostRecentVaccinationDate = DateTime.Now,

         AdditionalNotes = "Prefers to be called 'Randy', likes trapp music, vapes constantly",

                }




            };


        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: Chuck Baxter 3/13/2020
        /// Approver: Carl Davis 4/16/2020
        /// 
        /// Fake method to get an animals medical history
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <Returns>
        /// int
        /// </Returns>
        public List<MedicalHistory> GetAnimalMedicalHistoryByAnimalID(int id)
        {
            try
            {
                return (from b in MH
                        where b.AnimalID == id
                        select b).ToList();


            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Animal with ID " + id + " not found", ex);

            }
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/18/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// 
        /// Fake method to update an animals medical history
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <Returns>
        /// int
        /// </Returns>
        public int UpdateAnimalMedicalHistory(MedicalHistory old_, MedicalHistory new_)
        {
            foreach (MedicalHistory med in MH)
            {
                if (old_ == new_)
                {
                    return 1;
                }
            }
            return 0;





        }
    }
}
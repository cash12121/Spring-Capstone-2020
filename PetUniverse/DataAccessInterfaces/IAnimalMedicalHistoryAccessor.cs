using DataTransferObjects;
using System.Collections.Generic;


namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 3/13/2020
    /// Approver: 
    /// Approver: 
    /// 
    /// An interface for AnimalMedicalHistoryAccessor
    /// </summary>
    public interface IAnimalMedicalHistoryAccessor
    {
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: Chuck Baxter 3/13/2020
        /// Approver: 
        /// 
        /// Gets an animals medical history
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="AnimalID"></param>
        /// <Returns>
        /// List<NewAnimalChecklist>
        /// </Returns>
        List<MedicalHistory> GetAnimalMedicalHistoryByAnimalID(int id);

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/18/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// 
        /// Method to update an animals medical history
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <Returns>
        /// bool
        /// </Returns>
        int UpdateAnimalMedicalHistory(MedicalHistory old_, MedicalHistory new_);


    }
}

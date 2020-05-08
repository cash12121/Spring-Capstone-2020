using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 3/13/2020
    /// Approver: Carl Davis 4/16/2020
    /// Approver: 
    /// 
    /// An interface for AnimalMedicalHistoryManager
    /// </summary>
    public interface IAnimalMedicalHistoryManager
    {
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// 
        /// Retrieves an animals medical history
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
        List<MedicalHistory> RetrieveAnimalMedicalHistoryByAnimalID(int id);

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
        /// <summary>
        int UpdateAnimalMedicalHistory(MedicalHistory old_, MedicalHistory new_);
    }
}
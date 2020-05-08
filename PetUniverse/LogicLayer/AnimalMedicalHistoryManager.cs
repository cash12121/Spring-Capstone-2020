using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 3/13/2020
    /// Approver: Carl Davis 4/16/2020
    /// 
    /// Class for accessing medical history  
    /// </summary>
    public class AnimalMedicalHistoryManager : IAnimalMedicalHistoryManager
    {

        private IAnimalMedicalHistoryAccessor _medHistoryAccessor;


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// 
        /// no argument constructor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        public AnimalMedicalHistoryManager()
        {
            _medHistoryAccessor = new AnimalMedicalHistoryAccessor();
        }
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// 
        /// constructor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        ///   /// <param name="animalMedHistoryManager"></param>
        public AnimalMedicalHistoryManager(IAnimalMedicalHistoryAccessor animalMedHistoryManager)
        {
            _medHistoryAccessor = animalMedHistoryManager;
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: Chuck Baxter 3/13/2020
        /// Approver: Carl Davis 4/16/2020
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
        public List<MedicalHistory> RetrieveAnimalMedicalHistoryByAnimalID(int id)
        {
            List<MedicalHistory> records = null;

            try
            {
                records = _medHistoryAccessor.GetAnimalMedicalHistoryByAnimalID(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("records not found", ex);
            }

            return records;
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/6/2020
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
        /// int
        /// </Returns>
        public int UpdateAnimalMedicalHistory(MedicalHistory old_, MedicalHistory new_)
        {
            int result;

            try
            {
                result = _medHistoryAccessor.UpdateAnimalMedicalHistory(old_, new_);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update Failed!", ex);
            }
            return result;
        }
    }
}

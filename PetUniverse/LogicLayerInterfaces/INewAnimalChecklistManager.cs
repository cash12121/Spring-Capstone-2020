using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver: Chuck Baxter, 2/21/2020
    /// 
    /// interface for NewAnimalChecklist
    /// </summary>
    public interface INewAnimalChecklistManager
    {
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Retrieves a new animal checklist by AnimalID
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
        List<NewAnimalChecklist> RetrieveNewAnimalChecklistByAnimalID(int AnimalID);

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/28/2020
        /// Approver: 
        /// Approver: 
        /// 
        ///  Retrieves the number of animals housed
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <Returns>
        /// int
        /// </Returns>
        int RetrieveNumberOfAnimals(bool active = true);



    }
}

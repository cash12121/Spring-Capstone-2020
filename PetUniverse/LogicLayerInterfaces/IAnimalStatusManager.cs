using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/11/2020
    /// Approver: Michael Thompson
    /// 
    /// Logic Layer Interface for Animal Status
    /// </summary>
    public interface IAnimalStatusManager
    {
        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// Interface for sending an animal status to the data access layer
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="animalID"></param>
        /// <param name="statusID"></param>
        /// <returns></returns>
        bool AddAnimalStatus(int animalID, string statusID);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// Interface for retrieveing animal statuses from the data access layer
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns></returns>
        List<string> RetrieveAnimalStatusesByAnimalID(int animalID);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// Interface for deleting an animal status from the data access layer
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="animalID"></param>
        /// <param name="statusID"></param>
        /// <returns></returns>
        bool DeleteAnimalStatus(int animalID, string statusID);
    }
}

using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2/5/2020
    /// Approver: Austin Gee, 2/7/2020
    /// This Interface that defines methods for HomeInspectorManager 
    /// </summary>
    public interface IHomeInspectorManager
    {
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// This method for getting Adoption Applications by thier status, and 
        /// return a list of the Adoption Applications.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <returns>adoption Applications list</returns>
        List<AdoptionApplication> SelectAdoptionApplicationByStatus();

    }
}

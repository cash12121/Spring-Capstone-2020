using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2/5/2020
    /// Approver: Austin Gee, 2/7/2020
    ///
    /// This interface for accessing Adoption Applications data.
    /// </summary>
    public interface IHomeInspectorAccessor
    {
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// 
        /// This method used to get Adoption Applictions if their status
        /// is In-home Inspection. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <returns>list of Adoption Applications</returns>
        List<AdoptionApplication> SelectAdoptionApplicationsByStatus();
    }
}

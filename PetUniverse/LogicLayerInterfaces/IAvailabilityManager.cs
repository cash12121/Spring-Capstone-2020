using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IAvailabilityManager
    {
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/07
        /// Approver: Kaleb Bachert 
        /// 
        /// interface method for 
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <returns></returns>
        List<EmployeeAvailability> RetrieveAllAvailabilities();
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/07
        /// Approver: Kaleb Bachert 
        /// 
        /// interface method for 
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="UserID"></param>
        /// <returns></returns>
        List<AvailabilityVM> RetrieveAvailabilityByUserID(int UserID);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/07
        /// Approver: Kaleb Bachert 
        /// 
        /// interface method for 
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="newAvailability"></param>
        /// <param name="oldAvailability"></param>
        /// <returns></returns>
        bool EditAvailability(EmployeeAvailability newAvailability, EmployeeAvailability oldAvailability);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/07
        /// Approver: Kaleb Bachert 
        /// 
        /// interface method for 
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="availabilityID"></param>
        /// <returns></returns>
        bool ActivateAvailability(int availabilityID);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/07
        /// Approver: Kaleb Bachert 
        /// 
        /// interface method for 
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="availabilityID"></param>
        /// <returns></returns>
        bool DeactivateAvailability(int availabilityID);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/07
        /// Approver: Kaleb Bachert 
        /// 
        /// method for Adding availability 
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="availability"></param>
        /// <returns></returns>
        bool AddAvailability(EmployeeAvailability availability);
    }
}

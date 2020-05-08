using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IEmployeeAvailabilityManager
    {
        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 4/2/2020
        /// Approver: Jordan Lindo
        ///
        /// Creates a new employee Availability
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// <param name="employeeAvailability"></param>
        /// <returns>Boolean value to tell if new user was created</returns>
        bool CreateNewEmployeeAvailability(EmployeeAvailability employeeAvailability);

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 4/9/2020
        /// Approver: Jordan Lindo
        /// 
        /// This method retrieve last EmployeeID
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        int RetrieveLastEmployeeID();

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 2020/04/09
        /// Approver: Jordan Lindo
        ///
        /// Interface method that gets a list of Availabilities from userID.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="employeeID"></param>
        List<EmployeeAvailability> RetrieveAvailabilitiesByEmployeeID(int employeeID);
    }
}

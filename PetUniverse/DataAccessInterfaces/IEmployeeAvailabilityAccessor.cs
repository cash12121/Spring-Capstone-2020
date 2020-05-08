using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IEmployeeAvailabilityAccessor
    {
        /// <summary>
        /// CREATOR: Lane Sandburg
        /// DATE: 4/2/2020
        /// APPROVER: Jordan Lindo
        ///
        /// Interface method signature for inserting a New Employee Availability
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="employeeAvailability">The availability the will be inserted</param>
        /// <returns>returns true if insertion of availability was successful else returns false</returns>
        bool InsertNewEmployeeAvailability(EmployeeAvailability employeeAvailability);

        /// <summary>
        /// CREATOR: Lane Sandburg
        /// DATE: 4/9/2020
        /// APPROVER: Jordan Lindo
        ///
        /// Interface method signature for  selecting the last created userID for availability insertion
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="employeeAvailability">The availability the will be inserted</param>
        /// <returns>returns true if insertion of availability was successful else returns false</returns>
        int SelectLastCreatedEmployeeID();

        /// <summary>
        /// CREATOR: Lane Sandburg
        /// DATE: 4/9/2020
        /// APPROVER: Jordan Lindo
        ///
        /// Interface method signature for  selecting the  availability of given userID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="employeeID">The employees id to select availabilites</param>
        /// <returns>returns List of availability</returns>
        List<EmployeeAvailability> SelectEmployeeAvailabilityByID(int employeeID);
    }
}

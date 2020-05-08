using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class EmployeeAvailabilityManager : IEmployeeAvailabilityManager
    {
        private IEmployeeAvailabilityAccessor _employeeAvailabilityAccessor;

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 4/2/2020
        /// Approver:Jordan Lindo
        /// 
        /// Default constructor for the availability Manager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public EmployeeAvailabilityManager()
        {
            _employeeAvailabilityAccessor = new EmployeeAvailabilityAccessor();
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 4/2/2020
        /// Approver: Jordan Lindo
        /// 
        /// Constructor for the availability Manager that takes an availabilityAccessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="employeeAvailabilityAccessor">availability Accessor that is being used</param>
        public EmployeeAvailabilityManager(IEmployeeAvailabilityAccessor employeeAvailabilityAccessor)
        {
            _employeeAvailabilityAccessor = employeeAvailabilityAccessor;
        }


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
        public bool CreateNewEmployeeAvailability(EmployeeAvailability employeeAvailability)
        {
            try
            {
                return _employeeAvailabilityAccessor.InsertNewEmployeeAvailability(employeeAvailability);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Unable to create new availability", ex); ;
            }
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 4/9/2020
        /// Approver: Jordan Lindo
        ///
        /// selects the  employee Availability for a specific user
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// <returns>userID</returns>
        public List<EmployeeAvailability> RetrieveAvailabilitiesByEmployeeID(int employeeID)
        {
            List<EmployeeAvailability> availabilities = new List<EmployeeAvailability>();

            try
            {
                availabilities = _employeeAvailabilityAccessor.SelectEmployeeAvailabilityByID(employeeID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Availabilities not found.", ex);
            }

            return availabilities;
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 4/9/2020
        /// Approver:Jordan Lindo
        ///
        /// selects the newest employee for Availability
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// <returns>userID</returns>
        public int RetrieveLastEmployeeID()
        {
            try
            {
                return _employeeAvailabilityAccessor.SelectLastCreatedEmployeeID();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Unable to select employeeID", ex); ;
            }
        }
    }
}

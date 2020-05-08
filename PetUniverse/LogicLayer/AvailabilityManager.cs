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
{ /// <summary>
  /// Creator: Chase Schulte
  /// Created: 2020/03/28
  /// Approver: Kaleb Bachert
  ///
  /// Manages requests for AvailablityAccessor and ensures whether they return data or not
  /// </summary>
    public class AvailabilityManager : IAvailabilityManager
    {
        private IAvailabilityAccessor _availabilityAccessor;
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/05
        /// Approver: Kaleb Bachert
        /// 
        /// New up an instance of ERoleAcessor()
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        public AvailabilityManager()
        {
            _availabilityAccessor = new AvailabilityAccessor();
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert
        /// 
        /// assign _availabilityAcessor to a pre-existing instance of availabilityAccessor
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleAccessor"></param>
        public AvailabilityManager(IAvailabilityAccessor eRoleAccessor)
        {
            _availabilityAccessor = eRoleAccessor;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert
        /// 
        /// method for activating availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="availabilityID"></param>
        /// <returns></returns>
        public bool ActivateAvailability(int availabilityID)
        {
            bool result = true;
            try
            {
                result = _availabilityAccessor.ActivateAvailability(availabilityID) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Availability not activated", ex);
            }
            return result;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert
        /// 
        /// method for adding availability 
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="availability"></param>
        /// <returns></returns>
        public bool AddAvailability(EmployeeAvailability availability)
        {
            bool result = true;
            try
            {
                result = _availabilityAccessor.InsertAvailability(availability) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Availability not inserted", ex);
            }
            return result;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert
        /// 
        /// method for deactivating availability 
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool DeactivateAvailability(int userID)
        {
            bool result = true;
            try
            {
                result = _availabilityAccessor.DeactivateAvailability(userID) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Availability not deactivated", ex);
            }
            return result;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert
        /// 
        /// method for retrieving all availabilites
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <returns></returns>
        public List<EmployeeAvailability> RetrieveAllAvailabilities()
        {
            try
            {
                return _availabilityAccessor.SelectAllAvailabilities();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Availabilities not found", ex);
            }
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert
        /// 
        /// method for retreiving availability by userid 
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<AvailabilityVM> RetrieveAvailabilityByUserID(int UserID)
        {
            try
            {
                return _availabilityAccessor.SelectAvailabilityByUserID(UserID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Availabilities not found", ex);
            }
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/09
        /// Approver: Kaleb Bachert
        /// 
        /// method for updating availability 
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="newAvailability"></param>
        /// <param name="oldAvailability"></param>
        /// <returns></returns>
        public bool EditAvailability(EmployeeAvailability newAvailability, EmployeeAvailability oldAvailability)
        {
            bool result = true;
            try
            {
                result = _availabilityAccessor.UpdateAvailability(newAvailability, oldAvailability) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Availability not updated", ex);
            }
            return result;
        }
    }
}

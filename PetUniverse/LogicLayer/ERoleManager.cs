using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
	/// Creator: Chase Schulte
	/// Created: 2020/02/05
	/// Approver: Kaleb Bachert
	///
	/// Manages requests for ERoleAccessor and ensures whether they return data or not
	/// </summary>
    public class ERoleManager : IERoleManager
    {
        private IERoleAccessor _eRoleAccessor;
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
        public ERoleManager()
        {
            _eRoleAccessor = new ERoleAccessor();
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/05
        /// Approver: Kaleb Bachert
        /// 
        /// assign _eRoleAccessor to a pre-existing instance of eRoleAccessor
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleAccessor"></param>
        public ERoleManager(IERoleAccessor eRoleAccessor)
        {
            _eRoleAccessor = eRoleAccessor;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/05
        /// Approver: Kaleb Bachert
        /// 
        /// Activate a Role
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public bool ActivateERole(string eRoleID)
        {
            bool result = true;
            try
            {
                result = _eRoleAccessor.ActivateERole(eRoleID) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERole not activated", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/05
        /// Approver: Kaleb Bachert
        /// 
        /// Add a Role
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRole"></param>
        /// <returns></returns>
        public bool AddERole(ERole eRole)
        {
            bool result = true;
            try
            {
                result = _eRoleAccessor.InsertERole(eRole) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERole not added", ex);
            }
            return result;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/05
        /// Approver: Kaleb Bachert
        /// 
        /// Deactivate a Role
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public bool DeactivateERole(string eRoleID)
        {
            bool result = true;
            try
            {
                result = _eRoleAccessor.DeactivateERole(eRoleID) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERole not deactivated", ex);
            }
            return result;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/05
        /// Approver: Kaleb Bachert
        /// 
        /// Delete a Role
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public bool DeleteERole(string eRoleID)
        {
            bool result = false;
            try
            {
                result = (1 == _eRoleAccessor.DeleteERole(eRoleID));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERole not removed!", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/05
        /// Approver: Kaleb Bachert
        /// 
        /// Update a Role
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="oldERole"></param>
        /// <param name="newERole"></param>
        /// <returns></returns>
        public bool EditERole(ERole oldERole, ERole newERole)
        {
            bool result = true;
            try
            {
                result = _eRoleAccessor.UpdateERole(oldERole, newERole) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERole not updated", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/05
        /// Approver: Kaleb Bachert
        /// 
        /// Retrieve all eRoles
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// /// <returns></returns>
        public List<ERole> RetrieveAllERoles()
        {
            try
            {
                return _eRoleAccessor.SelectAllERoles();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("ERoles not found", ex);
            }
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/05
        /// Approver: Kaleb Bachert
        /// 
        /// Retrieve all eRoles by their active state
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// /// <returns></returns>
        public List<ERole> RetrieveERolesByActive(bool active = true)
        {
            try
            {
                return _eRoleAccessor.SelectAllERolesByActive(active);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("ERoles not found", ex);
            }
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a method for selecting roles by departmentID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public List<ERole> RetrieveERolesByDepartmentID(string departmentID)
        {
            try
            {
                return _eRoleAccessor.SelectAllERolesByDepartment(departmentID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not found.", ex);
            }
        }
    }
}

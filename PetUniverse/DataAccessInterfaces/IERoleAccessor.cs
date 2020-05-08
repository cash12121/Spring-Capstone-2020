using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
	/// Creator: Chase Schulte
	/// Created: 2/05/2020
	/// Approver: Kaleb Bachert
	///
	/// Interface for eRoleDataAccessor
	/// </summary>
    public interface IERoleAccessor
    {

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2/05/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Interface method for inserting a ERole
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="eRole"></param>
        /// <returns></returns>
        int InsertERole(ERole eRole);

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2/05/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Interface method for selecting all ERoles
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        List<ERole> SelectAllERoles();

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2/05/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Interface method for updating a ERole
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="oldERole"></param>
        /// <param name="newERole"></param>
        /// <returns></returns>
        int UpdateERole(ERole oldERole, ERole newERole);

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2/05/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Interface method for a delete a ERole
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        int DeleteERole(string eRoleID);

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2/05/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Interface method for a deactivating a ERole
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        int DeactivateERole(string eRoleID);

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2/05/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Interface method for activating a ERole
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        int ActivateERole(string eRoleID);

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2/05/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Interface method for adding a ERole
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        List<ERole> SelectAllERolesByActive(bool active = true);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// This is a method to select all roles by department.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        List<ERole> SelectAllERolesByDepartment(string departmentID);
    }
}
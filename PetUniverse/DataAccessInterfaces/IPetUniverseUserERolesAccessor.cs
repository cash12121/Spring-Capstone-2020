using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Chase Schulte
    /// Created: 02/29/2020
    /// Approver: Jordan Lindo
    ///
    /// PetUniverseERoleAccessor return data from sql
    /// </summary>
    public interface IPetUniverseUserERolesAccessor
    {

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: Jordan Lindo
        /// 
        /// This method is used to get a specified PetUniverse User's ERoles via their ID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<string> SelectPetUniverseUserERoleByPetUniverseUser(int userID);

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: Jordan Lindo
        /// 
        /// This method is used apply an ERole into PetUniverse User's 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns></returns>
        int InsertPetUniverseUserERole(int userID, string eRoleID);

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: Jordan Lindo
        /// 
        /// This method is used to delete a PetUniverse User's ERole
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns></returns>
        int DeletePetUniverseUserERole(int userID, string eRoleID);
    }
}
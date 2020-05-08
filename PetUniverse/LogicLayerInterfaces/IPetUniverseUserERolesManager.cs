using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Chase Schulte
    /// Created: 02/29/2020
    /// Approver: Jordan Lindo
    ///
    /// Manages requests for PetUniverseERoleAccessor and ensures whether they return data or not
    /// </summary>
    public interface IPetUniverseUserERolesManager
    {
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
        bool AddPetUniverseUserERole(int userID, string eRole);
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
        List<string> RetrievePetUniverseUserERolesByPetUniverseUser(int userID);
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
        bool DeletePetUniverseUserERole(int userID, string eRoleID);
    }
}

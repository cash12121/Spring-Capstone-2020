using DataAccessInterfaces;
using DataAccessLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Chase Schulte
    /// Created: 02/29/2020
    /// Approver: Jordan Lindo
    /// 
    /// This Class holds methods for actions related to UserERoles
    /// 
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA  
    /// 
    /// </remarks>
    /// </summary>
    public class PetUniverseUserERolesManager : IPetUniverseUserERolesManager
    {
        private IPetUniverseUserERolesAccessor _petUniverseUserERolesAccessor;
        public PetUniverseUserERolesManager()
        {
            try
            {
                _petUniverseUserERolesAccessor = new PetUniverseERolesAccessor();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: Jordan Lindo
        /// 
        /// Assign a instance of IPetUniverseUserERolesAccessor to _petUniverseUserERolesAccessor
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// </summary>
        public PetUniverseUserERolesManager(IPetUniverseUserERolesAccessor petUniverseUserERolesAccessor)
        {
            _petUniverseUserERolesAccessor = petUniverseUserERolesAccessor;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: Jordan Lindo
        /// 
        /// This Method adds a user's ERole
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="eRole"></param>
        /// <returns></returns>
        public bool AddPetUniverseUserERole(int userID, string eRole)
        {
            bool result = true;
            try
            {
                result = _petUniverseUserERolesAccessor.InsertPetUniverseUserERole(userID, eRole) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERole not added", ex);
            }
            return result;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: Jordan Lindo
        /// 
        /// This Method deletes a user's ERole
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="eRoleID"></param>
        /// <returns></returns>
        public bool DeletePetUniverseUserERole(int userID, string eRoleID)
        {
            bool result = true;
            try
            {
                result = _petUniverseUserERolesAccessor.DeletePetUniverseUserERole(userID, eRoleID) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERole not deleted", ex);
            }
            return result;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 02/29/2020
        /// Approver: Jordan Lindo
        /// 
        /// This Method finds a user's ERole that are assigned to them
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<string> RetrievePetUniverseUserERolesByPetUniverseUser(int userID)
        {
            try
            {
                return _petUniverseUserERolesAccessor.SelectPetUniverseUserERoleByPetUniverseUser(userID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("ERoles not found", ex);
            }
        }
    }
}

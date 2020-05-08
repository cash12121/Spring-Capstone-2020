using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Steven Cardona
    /// Created: 02/07/2020
    /// Approver: Zach Behrensmeyer
    /// 
    /// Interface for the user accessor
    /// </summary>
    public interface IUserAccessor
    {

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/07/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Interface method signature for inserting a New User
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="petUniverseUser">The user the will be inserted</param>
        /// <returns>returns true if insertion of user was successful else returns false</returns>
        bool InsertNewUser(PetUniverseUser petUniverseUser);

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Interface method signature for selecting all active users
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>Returns a list of active users</returns>
        List<PetUniverseUser> SelectAllActivePetUniverseUsers();

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/4/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to authenticate the user and make sure they exist for login
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns>Valid User</returns>
        PetUniverseUser AuthenticateUser(string username, string passwordHash);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to get a departments users
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="email"></param>
        /// <returns>A PetUniverseUser</returns>
        PetUniverseUser getUserByEmail(string email);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to check if provided email exists
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userName"></param>
        /// <returns>bool if user exists</returns>
        bool CheckIfUserExists(string userName);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to lock out the user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userName"></param>
        /// <returns>bool if user exists</returns>
        /// <param name="userName"></param>
        /// <param name="currentDate"></param>
        /// <param name="unlockDate"></param>
        /// <returns>bool if locked</returns>
        bool LockoutUser(string userName, DateTime currentDate, DateTime unlockDate);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to unlock the user based on time
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool TimeoutUserUnlock(string userName);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to unlock the user based on time
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userName"></param>
        /// <returns>bool if user is unlocked</returns>
        DateTime getUnlockDate(string userName);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to get a departments users
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="DepartmentID"></param>
        /// <returns>Restrns list of users based on department id</returns>
        List<PetUniverseUser> GetDepartmentUsers(string DepartmentID);

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 3/17/2020
        /// Approver: Kaleb Bachert
        /// 
        /// This method is to change the status of 
        /// an employee reading Policies and Standards
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="UserID"></param>
        /// <returns>rows affected</returns>
        int ChangeUserHasReadPoliciesStandards(int UserID);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/1/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to get users based on userID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="UserID"></param>
        /// <returns>Returns a user based on ID</returns>
        PetUniverseUser getUserByUserID(int UserID);

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Interface method for update user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="originalUser"></param>
        /// <param name="updatedUser"></param>
        /// <returns></returns>
        bool UpdateUser(PetUniverseUser originalUser, PetUniverseUser updatedUser);

        /// <summary>
        /// NAME: Kaleb Bachert
        /// DATE: 4/14/2020
        /// APPROVER: Lane Sandburg
        /// 
        /// This method is used to get all users with a specified role.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// CHANGE:
        /// </remarks>
        /// <param name="roleID"></param>
        List<PetUniverseUser> SelectActiveUsersByRole(string roleID);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/24/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to update a user password
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="oldPasswordHash"></param>
        /// <param name="newPasswordHash"></param>
        /// <returns></returns>
        bool UpdatePasswordHash(int userID, string oldPasswordHash, string newPasswordHash);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/29/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to set security questions
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="Q1"></param>
        /// <param name="Q2"></param>
        /// <param name="A1"></param>
        /// <param name="A2"></param>
        /// <returns></returns>
        bool UpdateSecurityInfo(int userID, string Q1, string Q2, string A1, string A2);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/29/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to set a password after answering security questions
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="newPasswordHash"></param>
        /// <returns></returns>
        bool UpdatePasswordHashBySecurity(int userID, string newPasswordHash);
    }
}
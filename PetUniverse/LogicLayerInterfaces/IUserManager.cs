using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Steven Cardona
    /// Created: 02/10/2020
    /// Approver: Zach Behrensmeyer
    ///
    /// Interface that defines method for user manager
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Creates a new user
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// <param name="petUniverseUser"></param>
        /// <returns>Boolean value to tell if new user was created</returns>
        bool CreateNewUser(PetUniverseUser petUniverseUser);

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Retrieves a list of all active users
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        ///
        /// <returns>List of all active users</returns>
        List<PetUniverseUser> RetrieveAllActivePetUniverseUsers();

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 2/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This calls the User Authentication Data Accessor Method
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// 
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Returns Valid User Info</returns>
        PetUniverseUser AuthenticateUser(string email, string password);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager method to get users by email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        PetUniverseUser getUserByEmail(string email);

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 3/3/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager method to confirm user exists
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>        
        /// <returns>Returns Valid User Info</returns>
        bool CheckIfUserExists(string Email);

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 3/3/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager method to Lockout a user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>        
        /// <returns>Returns Valid User Info</returns>
        bool LockoutUser(string Email, DateTime currentDate, DateTime unlockDate);

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 3/3/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager method to unlock user if they haven't been
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>        
        /// <returns>Returns Valid User Info</returns>
        bool UnlockUserByTime(string Email);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager method to unlock user if they haven't been
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>        
        /// <returns>Returns Valid User Info</returns>
        DateTime fetchUnlockDate(string userName);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager method to get users from a department
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>        
        /// <returns>Returns Valid User Info</returns>
        List<PetUniverseUser> GetDepartmentUsers(string DepartmentID);

        /// <summary>
        /// Creator: Lane Sandburg  
        /// Created: 3/17/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Manager method to Change if a user has viewed policies and standards
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>        
        /// <returns>bool result of call</returns>
        bool HasReadPoliciesAndStandards(int userID);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/1/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager method to get users by UserID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="UserID"></param>
        /// <returns></returns>
        PetUniverseUser getUserByUserID(int UserID);

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/08/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// update a user profile
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// <param name="originalUser">The user before the update</param>
        /// <param name="updatedUser">The updated user information</param>
        /// <returns>Boolean value to tell if new user was created</returns>
        bool UpdateUser(PetUniverseUser originalUser, PetUniverseUser updatedUser);

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/14
        ///  APPROVER: Lane Sandburg
        ///  
        ///  Interface method for getting the Users who can work a specified shift
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="date"></param>
        /// <param name="weekDay"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="roleID"></param>
        List<PetUniverseUser> RetrieveUsersAbleToWork(DateTime date, string weekDay, DateTime startTime, DateTime endTime, string roleID);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/20/2020
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
        bool UpdatePassword(int userID, string newPassword, string oldPassword);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/20/2020
        /// Approver: Steven Cardona
        /// 
        /// Method for the Identity System
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>        
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool FindUser(string email);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/29/2020
        /// Approver: Steven Cardona
        /// 
        /// This fake method is called for the Setting security info
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

        bool UpdatePasswordHashBySecurity(int userID, string newPasswordHash);
    }
}

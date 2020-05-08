using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Steven Cardona and Zach Behrensmeyer
    /// Created: 02/07/2020
    /// Approver: Zach Behrensmeyer
    ///
    /// Class to manage uses implements the IUserManager Interface
    /// </summary>
    public class UserManager : IUserManager
    {

        private IUserAccessor _userAccessor;
        private IShiftAccessor _shiftAccessor;
        private IActiveTimeOffAccessor _activeTimeOffAccessor;
        private IAvailabilityAccessor _availabilityAccessor;

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/07/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Default constructor for the User Manager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public UserManager()
        {
            _userAccessor = new UserAccessor();
            _shiftAccessor = new ShiftAccessor();
            _activeTimeOffAccessor = new ActiveTimeOffAccessor();
            _availabilityAccessor = new AvailabilityAccessor();
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/07/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Constructor for the User Manager that takes an userAccessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userAccessor">User Accessor that is being used</param>
        public UserManager(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
            _shiftAccessor = new ShiftAccessor();
            _activeTimeOffAccessor = new ActiveTimeOffAccessor();
            _availabilityAccessor = new AvailabilityAccessor();
        }

        /// <summary>
        /// CREATOR: Kaleb Bachert
        /// DATE: 02/16/2020
        /// APPROVER: Lane Sandburg
        /// Constructor for the User Manager that takes an userAccessor, shiftAccessor, activeTimeOffAccessor and availabilityAccessor
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// UPDATE: N/A
        /// </remarks>
        /// <param name="userAccessor">User Accessor that is being used</param>
        /// <param name="shiftAccessor">Shift Accessor that is being used</param>
        /// <param name="activeTimeOffAccessor">ActiveTimeOff Accessor that is being used</param>
        /// <param name="availabilityAccessor">Availability Accessor that is being used</param>
        public UserManager(IUserAccessor userAccessor, IShiftAccessor shiftAccessor,
                           IActiveTimeOffAccessor activeTimeOffAccessor, IAvailabilityAccessor availabilityAccessor)
        {
            _userAccessor = userAccessor;
            _shiftAccessor = shiftAccessor;
            _activeTimeOffAccessor = activeTimeOffAccessor;
            _availabilityAccessor = availabilityAccessor;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/07/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Manager method to create new user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="petUniverseUser">User being created</param>
        /// <returns>Returns true if successful user creation</returns>
        public bool CreateNewUser(PetUniverseUser petUniverseUser)
        {
            try
            {
                return _userAccessor.InsertNewUser(petUniverseUser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to create new user", ex);
            }
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020/
        /// Approver: Zach Behrensmeyer
        ///
        /// Manager method to get all active users
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>Returns a list of active PetUniverseUsers</returns>
        public List<PetUniverseUser> RetrieveAllActivePetUniverseUsers()
        {
            List<PetUniverseUser> users = new List<PetUniverseUser>();

            try
            {
                users = _userAccessor.SelectAllActivePetUniverseUsers();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Users Found", ex);
            }
            return users;
        }

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 2/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This calls the User Authentication Data Accessor Method
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Returns Valid User Info</returns>
        public PetUniverseUser AuthenticateUser(string email, string password)
        {
            PetUniverseUser result = null;
            var passwordHash = hashPassword(password);
            password = null;

            try
            {
                result = _userAccessor.AuthenticateUser(email, passwordHash);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Login failed!", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 2/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method hashes the given password
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="source"></param>
        /// <returns>Hashed Password</returns>
        private string hashPassword(string source)
        {
            string result = null;

            // we need a byte array because cryptography is bits and bytes
            byte[] data;

            using (SHA256 sha256hash = SHA256.Create())
            {
                // This part hashes the input
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            // builds a new string from the result
            var s = new StringBuilder();

            // loops through bytes to build the string
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }
            result = s.ToString().ToUpper();
            return result;
        }

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
        public bool CheckIfUserExists(string Email)
        {
            bool exists;

            try
            {
                exists = _userAccessor.CheckIfUserExists(Email);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Users Found", ex);
            }
            return exists;
        }

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
        public bool LockoutUser(string Email, DateTime currentDate, DateTime unlockDate)
        {
            bool isLocked;

            try
            {
                isLocked = _userAccessor.LockoutUser(Email, currentDate, unlockDate);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Users Found", ex);
            }
            return isLocked;
        }

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
        public bool UnlockUserByTime(string Email)
        {
            bool isUnlocked;

            try
            {
                isUnlocked = _userAccessor.TimeoutUserUnlock(Email);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Users Found", ex);
            }
            return isUnlocked;
        }

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
        public DateTime fetchUnlockDate(string userName)
        {
            DateTime unlockDate;
            try
            {
                unlockDate = _userAccessor.getUnlockDate(userName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No user found", ex);
            }
            return unlockDate;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager Method to retrieve users by email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public PetUniverseUser getUserByEmail(string email)
        {
            PetUniverseUser user = new PetUniverseUser();
            try
            {
                user = _userAccessor.getUserByEmail(email);
            }
            catch (ApplicationException ax)
            {
                if (ax.Message == "User not found.")
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No user found", ex);
            }
            return user;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 04/25/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager Method to retrieve users by email that returns a boolean
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool FindUser(string email)
        {
            try
            {
                return _userAccessor.getUserByEmail(email) != null;
            }
            catch(ApplicationException ax)
            {
                if (ax.Message == "User not found.")
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Database Error", ex);
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager Method get users in a department
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public List<PetUniverseUser> GetDepartmentUsers(string DepartmentID)
        {
            List<PetUniverseUser> users = new List<PetUniverseUser>();

            try
            {
                users = _userAccessor.GetDepartmentUsers(DepartmentID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Users Found", ex);
            }
            return users;
        }

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
        public bool HasReadPoliciesAndStandards(int userID)
        {
            bool result = false;
            try
            {
                result = 1 == _userAccessor.ChangeUserHasReadPoliciesStandards(userID);

                if (result == false)
                {
                    throw new ApplicationException("User record not updated.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed!", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 04/01/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager Method get users by userID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public PetUniverseUser getUserByUserID(int UserID)
        {
            PetUniverseUser user = new PetUniverseUser();
            try
            {
                user = _userAccessor.getUserByUserID(UserID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No user found", ex);
            }
            return user;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Logic Layer method for update user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="originalUser"></param>
        /// <param name="updatedUser"></param>
        /// <returns></returns>
        public bool UpdateUser(PetUniverseUser originalUser, PetUniverseUser updatedUser)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = _userAccessor.UpdateUser(originalUser, updatedUser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update user", ex);
            }

            return isUpdated;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method will determine which Users are available to work on a specific day and time, with the appropriate role
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<PetUniverseUser> RetrieveUsersAbleToWork(DateTime date, string weekDay, DateTime startTime, DateTime endTime, string roleID)
        {
            //List of all Users with the specified Role
            List<PetUniverseUser> usersWithSpecifiedRole = new List<PetUniverseUser>();

            //List of all Shifts on the specified date
            List<ShiftVM> shiftsOnSpecifiedDay = new List<ShiftVM>();

            //List of all Users' ActiveTimeOff
            List<ActiveTimeOff> allUsersActiveTimeOff = new List<ActiveTimeOff>();

            //List of all Users' Availability records
            List<EmployeeAvailability> allUsersAvailabilities = new List<EmployeeAvailability>();

            try
            {
                usersWithSpecifiedRole = _userAccessor.SelectActiveUsersByRole(roleID);

                if (usersWithSpecifiedRole != null)
                {
                    shiftsOnSpecifiedDay = _shiftAccessor.SelectShiftsByDay(date);
                    allUsersActiveTimeOff = _activeTimeOffAccessor.SelectAllUsersActiveTimeOff();
                    allUsersAvailabilities = _availabilityAccessor.SelectAllUsersAvailability();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't get enough information. Likely a connection problem.", ex);
            }

            //List of all Users that fit the criteria for Shift replacement
            List<PetUniverseUser> acceptableReplacementUsers = new List<PetUniverseUser>();

            //Loop through all users who have the correct Role
            foreach (PetUniverseUser currentUser in usersWithSpecifiedRole)
            {
                bool userCanWorkTheShift = true;

                //Check if the User has Time Off on the specified date
                foreach (ActiveTimeOff activeTimeOff in allUsersActiveTimeOff)
                {
                    //Time Off has User's ID and specified date is between Time Off Start and End
                    if (activeTimeOff.UserID == currentUser.PUUserID && (activeTimeOff.StartDate <= date && activeTimeOff.EndDate >= date))
                    {
                        userCanWorkTheShift = false;
                        break;
                    }
                }

                //No Time Off conflicts
                if (userCanWorkTheShift)
                {
                    //Check if the User already works during the specified shift
                    foreach (ShiftVM scheduledShift in shiftsOnSpecifiedDay)
                    {
                        //Scheduled Shift has User's ID, AND scheduled StartTime is before new Shift's StartTime if the scheduled EndTime is also past new StartTime 
                        //or scheduled StartTime is equal or later than new Shift's StartTime if the schedule StartTime is also before new EndTime
                        if (scheduledShift.EmployeeWorking == currentUser.PUUserID &&
                            ((Convert.ToDateTime(scheduledShift.StartTime).TimeOfDay <= startTime.TimeOfDay && Convert.ToDateTime(scheduledShift.EndTime).TimeOfDay > startTime.TimeOfDay) ||
                            (Convert.ToDateTime(scheduledShift.StartTime).TimeOfDay >= startTime.TimeOfDay && Convert.ToDateTime(scheduledShift.StartTime).TimeOfDay < endTime.TimeOfDay)))
                        {

                            userCanWorkTheShift = false;
                            break;
                        }
                    }

                    //No Currently Scheduled Shift conflicts
                    if (userCanWorkTheShift)
                    {

                        bool userHasAvailability = false;

                        //Check if the User has Availability on the specified Week Day at the specified Time
                        foreach (EmployeeAvailability availability in allUsersAvailabilities)
                        {
                            //Availability record has User's ID and WeekDay matches and Availability StartTime is equal or before new Shift's StartTime
                            //and Availability EndTime is equal or later than new Shift's EndTime
                            if (availability.EmployeeID == currentUser.PUUserID && availability.DayOfWeek.Equals(weekDay) &&
                                ((Convert.ToDateTime(availability.StartTime).TimeOfDay <= startTime.TimeOfDay) && (Convert.ToDateTime(availability.EndTime).TimeOfDay >= endTime.TimeOfDay)))
                            {
                                userHasAvailability = true;
                                break;
                            }
                        }

                        //User does not have open availability on that day and time
                        if (!userHasAvailability)
                        {
                            userCanWorkTheShift = false;
                        }
                    }
                }
                //Finished all foreach loops for this User, Add User if they can work
                if (userCanWorkTheShift)
                {
                    acceptableReplacementUsers.Add(currentUser);
                }
            }
            return acceptableReplacementUsers;
        }

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
        public bool UpdatePassword(int userID, string newPassword, string oldPassword)
        {
            bool updated = false;

            string newPasswordHash = hashPassword(newPassword);
            string oldPasswordHash = hashPassword(oldPassword);

            try
            {
                updated = _userAccessor.UpdatePasswordHash(userID,
                    oldPasswordHash, newPasswordHash);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Password update failed.", ex);
            }
            return updated;
        }

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
        public bool UpdateSecurityInfo(int userID, string Q1, string Q2, string A1, string A2)
        {
            bool updated = false;

            try
            {
               updated = _userAccessor.UpdateSecurityInfo(userID, Q1, Q2, A1, A2);
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Password update failed.", ex);
            }
            return updated;            
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/29/2020
        /// Approver: Steven Cardona
        /// 
        /// This fake method is called for updating the password after getting the security questions right
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="newPasswordHash"></param>
        /// <returns></returns>
        public bool UpdatePasswordHashBySecurity(int userID, string newPasswordHash)
        {
            bool updated = false;

            string newpassword = hashPassword(newPasswordHash);

            try
            {
                updated = _userAccessor.UpdatePasswordHashBySecurity(userID, newpassword);
                    
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Password update failed.", ex);
            }
            return updated;
        }
    }
}
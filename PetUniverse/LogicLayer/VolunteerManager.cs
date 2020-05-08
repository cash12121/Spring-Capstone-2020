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
    /// NAME: Josh Jackson
    /// DATE: 02/07/2020
    /// Checked By: Ethan H, Gabi L
    /// This is a class file that holds the logic that passes volunteer record information from the Presentation layer to the Data Access layer
    /// </summary>
    /// <remarks>
    /// UPDATED BY: Josh Jackson
    /// UPDATE DATE: 04/16/2020
    /// WHAT WAS CHANGED: Added GetVolunteersBySkill() method
    /// </remarks>
    public class VolunteerManager : IVolunteerManager
    {
        private IVolunteerAccessor _volunteerAccessor;

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H, Gabi L
        /// this is the default constructor
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        public VolunteerManager()
        {
            _volunteerAccessor = new VolunteerAccessor();
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H, Gabi L
        /// this contructor takes an IVolunteerObject object as an argument
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="volunteerAccessor"></param>
        /// </remarks>
        public VolunteerManager(IVolunteerAccessor volunteerAccessor)
        {
            _volunteerAccessor = volunteerAccessor;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H
        /// this method passes the volunteer record data to be added to the db from the presentation layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="volunteer"></param>
        /// </remarks>
        public bool AddVolunteer(Volunteer volunteer)
        {
            bool result = true;
            try
            {
                result = _volunteerAccessor.InsertVolunteer(volunteer) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Volunteer not added", ex);
            }
            return result;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/12/2020
        /// Checked By: Timothy Lickteig
        /// this method adds skills to a volunteers list of skills
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="volunteerID"></param>
        /// <param name="skill"></param>
        /// </remarks>
        public bool AddVolunteerSkill(int volunteerID, string skill)
        {
            bool result = false;
            try
            {
                result = (1 == _volunteerAccessor.InsertOrDeleteVolunteerSkill(volunteerID, skill));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Skill not added!", ex);
            }
            return result;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/12/2020
        /// Checked By: Timothy Lickteig
        /// this method passes the volunteerID to two different methods to deactivate or reactivate a volunteers active status
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="isChecked"></param>
        /// <param name="volunteerID"></param>
        /// </remarks>
        public bool ChangeVolunteerActiveStatus(bool isChecked, int volunteerID)
        {
            bool result = false;
            try
            {
                if (isChecked)
                {
                    result = 1 == _volunteerAccessor.ActivateVolunteer(volunteerID);
                }
                else
                {
                    result = 1 == _volunteerAccessor.DeactivateVolunteer(volunteerID);
                }
                if (result == false)
                {
                    throw new ApplicationException("Employee record not updated.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed!", ex);
            }
            return result;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/12/2020
        /// Checked By: Timothy Lickteig
        /// this method removes skills from a volunteers list of skills
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="volunteerID"></param>
        /// <param name="skill"></param>
        /// </remarks>
        public bool DeleteVolunteerSkill(int volunteerID, string skill)
        {
            bool result = false;
            try
            {
                result = (1 == _volunteerAccessor.InsertOrDeleteVolunteerSkill(volunteerID, skill, delete: true));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Skill not removed!", ex);
            }
            return result;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 04/26/2020
        /// Checked By: 
        /// this method creates a foster record for a volunteer
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="volunteer"></param>
        /// <param name="newFoster"></param>
        /// </remarks>
        public bool CreateFoster(Volunteer volunteer, Foster newFoster)
        {
            bool rows = true;
            try
            {
                rows = _volunteerAccessor.CreateFoster(volunteer, newFoster) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H
        /// this method passes the skill data to the presentation layer from the data access layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        public List<string> GetAllSkills()
        {
            List<string> roles = null;

            try
            {
                roles = _volunteerAccessor.SelectAllSkills();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Roles not found", ex);
            }

            return roles;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 04/26/2020
        /// Checked By:
        /// this method gets foster data by volunteer ID
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="volunteerID"></param>
        /// </remarks>
        public Foster GetFosterDetailsByVolunteerID(int volunteerID)
        {
            try
            {
                return _volunteerAccessor.GetFosterDetailsByVolunteerID(volunteerID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/03/2020
        /// Checked By: Zoey M
        /// This method passes the first name of the searched for volunteer between presentation layer and data access layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        public List<Volunteer> GetVolunteerByFirstName(string wholeName)
        {
            try
            {
                return _volunteerAccessor.GetVolunteerByFirstName(wholeName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/14/2020
        /// Checked By: Gabi L
        /// This method passes the first and last name of the searched for volunteer between presentation layer and data access layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// </remarks>
        public List<Volunteer> GetVolunteerByName(string firstName, string lastName)
        {
            try
            {
                return _volunteerAccessor.GetVolunteerByName(firstName, lastName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 04/16/2020
        /// Checked By: 
        /// this method retrieves the list of volunteers who have a specified skill
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="skill"></param>
        /// </remarks>
        public List<Volunteer> GetVolunteersBySkill(string skill)
        {
            try
            {
                return _volunteerAccessor.GetVolunteersBySkill(skill);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 04/26/2020
        /// Checked By:
        /// this method passes the foster record data to be updated in the db from the presentation layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="foster"></param>
        /// <param name="newFoster"></param>
        /// </remarks>
        public bool UpdateFoster(Foster foster, Foster newFoster)
        {
            bool rows = true;
            try
            {
                rows = _volunteerAccessor.UpdateFoster(foster, newFoster) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/13/2020
        /// Checked By: 
        /// this method retrieves the list of skills a volunteer has by VolunteerID
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="volunteerID"></param>
        /// </remarks>
        public List<string> GetVolunteerSkillsByID(int volunteerID)
        {
            List<string> skills = null;

            try
            {
                skills = _volunteerAccessor.GetVolunteerSkillsByID(volunteerID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Skills not found", ex);
            }

            return skills;
        }

        /// <summary>
        /// Coded by Gabrielle Legrand
        /// 
        /// Checked By: Josh Jackson
        /// This is the Volunteer Manager method with logic for Retrieving the list of Volunteers by Active status
        /// 
        /// </summary>
        /// <param name="active"></param>
        /// <returns></returns>
        ///<remarks>
        /// UPDATED BY: 
        /// UPDATE DATE: 
        /// CHANGE DESCRIPTION:
        /// </remarks>

        public List<Volunteer> RetrieveVolunteerListByActive(bool active = true)
        {
            try
            {
                return _volunteerAccessor.SelectVolunteersByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/03/2020
        /// Checked By: Timothy Lickteig
        /// this method passes the volunteer record data to be updated in the db from the presentation layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="oldVolunteer"></param>
        /// <param name="newVolunteer"></param>
        /// </remarks>
        public bool UpdateVolunteer(Volunteer oldVolunteer, Volunteer newVolunteer)
        {
            bool rows = true;
            try
            {
                rows = _volunteerAccessor.UpdateVolunteer(oldVolunteer, newVolunteer) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 04/27/2020
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
        public bool FindVolunteer(string email)
        {
            try
            {
                return _volunteerAccessor.getVolunteerByEmail(email) != null;
            }
            catch (ApplicationException ax)
            {
                if (ax.Message == "Volunteer not found.")
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database Error", ex);
            }
        }

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 4/28/2020
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
        /// Created: 4/28/2020
        /// Approver: Steven Cardona
        /// 
        /// This calls the User Authentication Data Accessor Method for customers
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
        public Volunteer AuthenticateVolunteer(string email, string password)
        {
            Volunteer result = null;
            var passwordHash = hashPassword(password);
            password = null;

            try
            {
                result = _volunteerAccessor.AuthenticateVolunteer(email, passwordHash);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Login failed!", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 4/28/2020
        /// Approver: Steven Cardona
        /// 
        /// Gets Volunteer From Email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public Volunteer RetrieveVolunteerFromEmail(string email)
        {
            try
            {
                return _volunteerAccessor.getVolunteerByEmail(email);
            }
            catch (ApplicationException ax)
            {
                if (ax.Message == "Volunteer not found.")
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
                throw new ApplicationException("DatabaseError", ex);
            }
        }

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 4/28/2020
        /// Approver: Steven Cardona
        /// 
        /// Gets Volunteer ID From Email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public int RetrieveVolunteerIDFromEmail(string email)
        {
            try
            {
                return _volunteerAccessor.getVolunteerByEmail(email).VolunteerID;
            }
            catch(Exception ex)
            {
                throw new ApplicationException("DatabaseError", ex);
            }
        }
    }
}

using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Josh Jackson
    /// Created: 02/07/2020
    /// Approver: Ethan Holmes, Gabi LeGrand
    /// 
    /// This is an interface for Volunteer accessor methods
    /// </summary>
    /// <remarks>
    /// Updater: Josh Jackson
    /// Updated: 02/13/2020
    /// Updater: Added GetVolunteerByName() method definition
    /// </remarks>
    public interface IVolunteerAccessor
    {

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 02/07/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is a data access method inserting a volunteer record to the db
        /// </summary>
        /// <remarks>
        /// Updater: Josh Jackson
        /// Updated: 02/21/2020
        /// Update: Was swapping new Volunteer's email and phone number. Email in phone field phone in email field. 
        ///  cmd.Parameters.AddWithValue("@Email", volunteer.PhoneNumber); ---> cmd.Parameters.AddWithValue("@Email", volunteer.Email);
        ///  cmd.Parameters.AddWithValue("@PhoneNumber", volunteer.Email); ---> cmd.Parameters.AddWithValue("@PhoneNumber", volunteer.PhoneNumber);
        /// </remarks>
        /// <param name="volunteer"></param>
        /// <returns></returns>
        int InsertVolunteer(Volunteer volunteer);

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 02/07/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is a data access method used for getting all skills a volunteer could have from the db.
        /// to be populated in the lstUnassigned Skills listbox on the AddEditVolunteerRecord window
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <returns></returns>
        List<string> SelectAllSkills();

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 02/14/2020
        /// Approver: Gabi LeGrand
        /// 
        /// This is a data access method querying a Volunteer by first and last name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        List<Volunteer> GetVolunteerByName(string firstName, string lastName);

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 03/13/2020
        /// Approver: Timothy Lickteig
        /// 
        /// This is a data access method querying a Volunteers skills by VolunteerID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        List<string> GetVolunteerSkillsByID(int volunteerID);

        /// <summary>
        /// Creator: Gabrielle Legrand
        /// Created: 2/6/2020
        /// Approver: Josh Jackson
        /// 
        /// This Data Access function will carry out the stored procedure sp select volunteers by active
        /// by communicating directly with the databse. This will bring the list of current active vounteers
        /// to the VolunteerManager.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns> List of active volunteers to the VolunteerManager </returns>
        List<Volunteer> SelectVolunteersByActive(bool active = true);

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 03/06/2020
        /// Approver: Zoey McDonald
        /// This Data Access function updates an existing volunteer record with new values acquired from a user
        /// </summary>        
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="oldVolunteer"></param>
        /// <param name="newVolunteer"></param>
        /// <returns></returns>
        int UpdateVolunteer(Volunteer oldVolunteer, Volunteer newVolunteer);

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 03/13/2020
        /// Approver: Timothy Lickteig
        /// 
        /// This is a data access method adds or removes a volunteers skill set
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <param name="skill"></param>
        /// <param name="delete"></param>
        /// <returns></returns>
        int InsertOrDeleteVolunteerSkill(int volunteerID, string skill, bool delete = false);

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 04/26/2020
        /// Approver: 
        /// 
        /// This is a data access method creates a foster record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="volunteer"></param>
        /// <param name="newFoster"></param>
        /// <returns></returns>
        int CreateFoster(Volunteer volunteer, Foster newFoster);

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 03/06/2020
        /// Approver: Zoey McDonald
        /// 
        /// This is a data access method querying a Volunteer by first name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="wholeName"></param>
        /// <returns></returns>
        List<Volunteer> GetVolunteerByFirstName(string wholeName);

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 03/12/2020
        /// Approver: Timothy Lickteig
        /// 
        /// This is a data access method to change a volunteers active status to 1 - true
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        int ActivateVolunteer(int volunteerID);

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 03/12/2020
        /// Approver: Timothy Lickteig
        /// 
        /// This is a data access method to change a volunteers active status to 0 - false
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        int DeactivateVolunteer(int volunteerID);

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 04/16/2020
        /// Approver: 
        /// 
        /// This is a data access method gets a volunteer record by skill
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="skill"></param>
        List<Volunteer> GetVolunteersBySkill(string skill);

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 04/26/2020
        /// Approver: 
        /// 
        /// This is a data access method gets a foster record by volunteer id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        Foster GetFosterDetailsByVolunteerID(int volunteerID);

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 04/26/2020
        /// Checked By:
        /// this method passes the foster record data to be updated in the db from the logic layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="foster"></param>
        /// <param name="newFoster"></param>
        /// </remarks>
        int UpdateFoster(Foster foster, Foster newFoster);

        /// <summary>
        /// Creator: Zach Bherensmeyer
        /// Created: 4/28/2020
        /// Approver: Steven Cardona
        ///
        /// Interface method signature for selecting a volunteer by email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        Volunteer getVolunteerByEmail(string email);

        /// <summary>
        /// Creator: Zach Bherensmeyer
        /// Created: 4/28/2020
        /// Approver: Steven Cardona
        ///
        /// Interface method signature for selecting a volunteer by email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        Volunteer AuthenticateVolunteer(string username, string passwordHash);

    }
}
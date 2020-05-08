using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// NAME: Josh Jackson
    /// DATE: 02/07/2020
    /// Checked By: Ethan H, Gabi L
    /// This is a data access class used for Volunteer record - DB interactions
    /// </summary>
    /// <remarks>
    /// UPDATED BY: Josh Jackson
    /// UPDATE DATE: 02/13/2020
    /// WHAT WAS CHANGED: added GetVolunteerByName() method
    /// </remarks>
    public class VolunteerAccessor : IVolunteerAccessor
    {
        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/12/2020
        /// Checked By: Timothy Lickteig
        /// This is a data access method to change a volunteers active status to 1 - true
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        public int ActivateVolunteer(int volunteerID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_reactivate_volunteer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VolunteerID", volunteerID);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 04/26/2020
        /// Checked By: 
        /// This is a data access method create a foster record
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="volunteer"></param>
        /// <param name="newFoster"></param>
        /// <returns></returns>
        public int CreateFoster(Volunteer volunteer, Foster newFoster)
        {
            int fosterID = 0;

            var conn = DBConnection.GetConnection();

            var cmd1 = new SqlCommand("sp_insert_foster", conn);

            cmd1.CommandType = CommandType.StoredProcedure;

            cmd1.Parameters.AddWithValue("@VolunteerID", volunteer.VolunteerID);
            cmd1.Parameters.AddWithValue("@AddressLine1", newFoster.AddressLineOne);
            cmd1.Parameters.AddWithValue("@AddressLine2", newFoster.AddressLineTwo);
            cmd1.Parameters.AddWithValue("@City", newFoster.City);
            cmd1.Parameters.AddWithValue("@State", newFoster.State);
            cmd1.Parameters.AddWithValue("@Zipcode", newFoster.Zip);

            try
            {
                conn.Open();
                fosterID = Convert.ToInt32(cmd1.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return fosterID;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/12/2020
        /// Checked By: Timothy Lickteig
        /// This is a data access method to change a volunteers active status to 0 - false
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        public int DeactivateVolunteer(int volunteerID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_volunteer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VolunteerID", volunteerID);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 04/26/2020
        /// Checked By: 
        /// This is a data access method gets a foster record by volunteer id
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        public Foster GetFosterDetailsByVolunteerID(int volunteerID)
        {
            Foster foster = null;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_foster_details_by_volunteer_id");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VolunteerID", SqlDbType.Int);
            cmd.Parameters["@VolunteerID"].Value = volunteerID;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    foster = new Foster();
                    foster.FosterID = reader.GetInt32(0);
                    foster.VolunteerID = reader.GetInt32(1);
                    foster.AddressLineOne = reader.GetString(2);
                    foster.AddressLineTwo = reader.GetString(3);
                    foster.City = reader.GetString(4);
                    foster.State = reader.GetString(5);
                    foster.Zip = reader.GetString(6);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return foster;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/06/2020
        /// Checked By: Zoey M
        /// This is a data access method querying a Volunteer by first name
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="wholeName"></param>
        /// <returns></returns>
        public List<Volunteer> GetVolunteerByFirstName(string wholeName)
        {
            List<Volunteer> vol = new List<Volunteer>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_volunteer_by_first_name");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 500);
            cmd.Parameters["@FirstName"].Value = wholeName;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var volunteer = new Volunteer();
                    volunteer.VolunteerID = reader.GetInt32(0);
                    volunteer.FirstName = wholeName;
                    volunteer.LastName = reader.GetString(2);
                    volunteer.Email = reader.GetString(3);
                    volunteer.PhoneNumber = reader.GetString(4);
                    volunteer.OtherNotes = reader.GetString(5);
                    volunteer.Active = reader.GetBoolean(6);
                    vol.Add(volunteer);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vol;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/14/2020
        /// Checked By: Gabi L
        /// This is a data access method querying a Volunteer by first and last name
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public List<Volunteer> GetVolunteerByName(string firstName, string lastName)
        {
            List<Volunteer> vol = new List<Volunteer>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_volunteer_by_name");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 500);
            cmd.Parameters["@FirstName"].Value = firstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 500);
            cmd.Parameters["@LastName"].Value = lastName;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var volunteer = new Volunteer();
                    volunteer.VolunteerID = reader.GetInt32(0);
                    volunteer.FirstName = firstName;
                    volunteer.LastName = lastName;
                    volunteer.Email = reader.GetString(3);
                    volunteer.PhoneNumber = reader.GetString(4);
                    volunteer.OtherNotes = reader.GetString(5);
                    volunteer.Active = reader.GetBoolean(6);
                    vol.Add(volunteer);
                }
                else
                {
                    throw new ApplicationException("Volunteer not found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vol;
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
        /// </remarks>
        /// <param name="skill"></param>
        /// <returns></returns>
        public List<Volunteer> GetVolunteersBySkill(string skill)
        {
            List<Volunteer> vol = new List<Volunteer>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_volunteer_by_skill");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SkillId", SqlDbType.NVarChar, 500);
            cmd.Parameters["@SkillId"].Value = skill;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var volunteer = new Volunteer();
                    volunteer.VolunteerID = reader.GetInt32(0);
                    volunteer.FirstName = reader.GetString(1);
                    volunteer.LastName = reader.GetString(2);
                    volunteer.Email = reader.GetString(3);
                    volunteer.PhoneNumber = reader.GetString(4);
                    volunteer.OtherNotes = "";
                    volunteer.Active = reader.GetBoolean(6);
                    vol.Add(volunteer);
                }
                else
                {
                    throw new ApplicationException("Volunteer not found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vol;
        }


        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 04/13/2020
        /// Checked By: Timothy Lickteig
        /// This is a data access method querying a Volunteers skills by VolunteerID
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        public List<string> GetVolunteerSkillsByID(int volunteerID)
        {
            List<string> skills = new List<string>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_skills_by_volunteerID");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@VolunteerID", SqlDbType.Int);
            cmd.Parameters["@VolunteerID"].Value = volunteerID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string skill = reader.GetString(0);
                    skills.Add(skill);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return skills;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/13/2020
        /// Checked By: Timothy Lickteig
        /// This is a data access method adds or removes a volunteers skill set
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <param name="skill"></param>
        /// <param name="delete"></param>
        /// <returns></returns>
        public int InsertOrDeleteVolunteerSkill(int volunteerID, string skill, bool delete = false)
        {
            int rows = 0;

            string cmdText = delete ? "sp_delete_volunteer_skill" : "sp_insert_volunteer_skill";

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VolunteerID", volunteerID);
            cmd.Parameters.AddWithValue("@SkillID", skill);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H
        /// This is a data access method inserting a volunteer record to the db
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Josh Jackson
        /// UPDATE DATE: 02/21/2020
        /// WHAT WAS CHANGED: Was swapping new Volunteer's email and phone number. Email in phone field phone in email field. 
        ///  cmd.Parameters.AddWithValue("@Email", volunteer.PhoneNumber); ---> cmd.Parameters.AddWithValue("@Email", volunteer.Email);
        ///  cmd.Parameters.AddWithValue("@PhoneNumber", volunteer.Email); ---> cmd.Parameters.AddWithValue("@PhoneNumber", volunteer.PhoneNumber);
        ///  04/13/2020
        ///  WHAT WAS CHANGED: Created a stored procedure that gives every new volunteer a basic volunteer skill
        /// </remarks>
        /// <param name="volunteer"></param>
        /// <returns></returns>
        public int InsertVolunteer(Volunteer volunteer)
        {
            int volunteerID = 0;

            var conn = DBConnection.GetConnection();

            var cmd1 = new SqlCommand("sp_insert_volunteer", conn);

            cmd1.CommandType = CommandType.StoredProcedure;

            cmd1.Parameters.AddWithValue("@LastName", volunteer.LastName);
            cmd1.Parameters.AddWithValue("@FirstName", volunteer.FirstName);
            cmd1.Parameters.AddWithValue("@Email", volunteer.Email);
            cmd1.Parameters.AddWithValue("@PhoneNumber", volunteer.PhoneNumber);
            cmd1.Parameters.AddWithValue("@OtherNotes", volunteer.OtherNotes);

            try
            {
                conn.Open();
                volunteerID = Convert.ToInt32(cmd1.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            giveBasicVolunteer(volunteerID);
            return volunteerID;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 04/16/2020
        /// Checked By: 
        /// This is a data access method to give any new volunteer the basic volunteer skill - triggered in the InsertVolunteer method
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        private int giveBasicVolunteer(int volunteerID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd2 = new SqlCommand("sp_give_basic_volunteer", conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@VolunteerID", volunteerID);
            cmd2.Parameters.AddWithValue("@SkillID", "Basic Volunteer");
            try
            {
                conn.Open();
                rows = cmd2.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H
        /// This is a data access method used for getting all skills a volunteer could have from the db.
        /// to be populated in the lstUnassigned Skills listbox on the AddEditVolunteerRecord window
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <returns></returns>
        public List<string> SelectAllSkills()
        {
            List<string> skills = new List<string>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_all_skills");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string role = reader.GetString(0);
                    skills.Add(role);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return skills;
        }

        /// <summary>
        /// NAME: Gabrielle Legrand
        /// DATE: 2/6/2020
        /// Checked By: Josh J
        /// This Data Access function will carry out the stored procedure sp select volunteers by active
        /// by communicating directly with the databse. This will bring the list of current active vounteers
        /// to the VolunteerManager.
        /// </summary>
        /// <param name="active"></param>
        /// <returns> List of active volunteers to the VolunteerManager </returns>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>

        public List<Volunteer> SelectVolunteersByActive(bool active = true)
        {
            List<Volunteer> volunteers = new List<Volunteer>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_volunteers_by_active");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Active", SqlDbType.Bit);

            cmd.Parameters["@Active"].Value = active;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                bool rows = reader.HasRows;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var volunteer = new Volunteer();
                        volunteer.VolunteerID = reader.GetInt32(0);
                        volunteer.FirstName = reader.GetString(1);
                        volunteer.LastName = reader.GetString(2);
                        volunteer.Email = reader.GetString(3);
                        volunteer.PhoneNumber = reader.GetString(4);
                        volunteer.OtherNotes = reader.GetString(5);
                        volunteer.Active = reader.GetBoolean(6);
                        volunteers.Add(volunteer);
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return volunteers;
        }

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
        public int UpdateFoster(Foster foster, Foster newFoster)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_foster", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FosterID", foster.FosterID);

            cmd.Parameters.AddWithValue("@NewAdd1", newFoster.AddressLineOne);
            cmd.Parameters.AddWithValue("@NewAdd2", newFoster.AddressLineTwo);
            cmd.Parameters.AddWithValue("@NewCity", newFoster.City);
            cmd.Parameters.AddWithValue("@NewState", newFoster.State);
            cmd.Parameters.AddWithValue("@NewZip", newFoster.Zip);

            cmd.Parameters.AddWithValue("@OldAdd1", foster.AddressLineOne);
            cmd.Parameters.AddWithValue("@OldAdd2", foster.AddressLineTwo);
            cmd.Parameters.AddWithValue("@OldCity", foster.City);
            cmd.Parameters.AddWithValue("@OldState", foster.State);
            cmd.Parameters.AddWithValue("@OldZip", foster.Zip);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        /// <summary>
        /// NAME: Josh J
        /// DATE: 03/06/2020
        /// Checked By: Zoey M
        /// This Data Access function updates an existing volunteer record with new values acquired from a user
        /// </summary>
        /// <param name="oldVolunteer"></param>
        /// <param name="newVolunteer"></param>
        /// <returns> List of active volunteers to the VolunteerManager </returns>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>
        public int UpdateVolunteer(Volunteer oldVolunteer, Volunteer newVolunteer)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_volunteer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VolunteerID", oldVolunteer.VolunteerID);

            cmd.Parameters.AddWithValue("@NewFirstName", newVolunteer.FirstName);
            cmd.Parameters.AddWithValue("@NewLastName", newVolunteer.LastName);
            cmd.Parameters.AddWithValue("@NewPhoneNumber", newVolunteer.PhoneNumber);
            cmd.Parameters.AddWithValue("@NewEmail", newVolunteer.Email);
            cmd.Parameters.AddWithValue("@NewNotes", newVolunteer.OtherNotes);

            cmd.Parameters.AddWithValue("@OldFirstName", oldVolunteer.FirstName);
            cmd.Parameters.AddWithValue("@OldLastName", oldVolunteer.LastName);
            cmd.Parameters.AddWithValue("@OldPhoneNumber", oldVolunteer.PhoneNumber);
            cmd.Parameters.AddWithValue("@OldEmail", oldVolunteer.Email);
            cmd.Parameters.AddWithValue("@OldNotes", oldVolunteer.OtherNotes);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/28/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to authenticate the volunteer and make sure they exist for login
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public Volunteer getVolunteerByEmail(string email)
        {
            Volunteer volunteer = null;
            // connection
            var conn = DBConnection.GetConnection();
            // commands
            var cmd = new SqlCommand("sp_select_volunteer_by_email", conn);
            // command type
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@volunteerEmail", SqlDbType.NVarChar, 250);
            cmd.Parameters["@volunteerEmail"].Value = email;
            try
            {
                // open the connection
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        volunteer = new Volunteer();

                        volunteer.Email = reader.GetString(0);
                        volunteer.FirstName = reader.GetString(1);
                        volunteer.LastName = reader.GetString(2);
                        volunteer.PhoneNumber = reader.GetString(3);
                        volunteer.Active = reader.GetBoolean(4);
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw new ApplicationException("Volunteer not found.");
            }
            finally
            {
                // Close the connection 
                conn.Close();
            }
            return volunteer;
        }
        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 4/28/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This method is used to authenticate the customer and make sure they exist for login
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// CHANGE:
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public Volunteer AuthenticateVolunteer(string username, string passwordHash)
        {
            Volunteer result = null;

            //Get a connection
            var conn = DBConnection.GetConnection();

            //Call the sproc
            var cmd = new SqlCommand("sp_authenticate_volunteer");
            cmd.Connection = conn;

            //Set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            //Create the parameters
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            //Set the parameters
            cmd.Parameters["@Email"].Value = username;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            try
            {
                conn.Open();

                if (1 == Convert.ToInt32(cmd.ExecuteScalar()))
                {
                    //Check the db for the given email
                    result = getVolunteerByEmail(username);
                }
                else
                {
                    throw new ApplicationException("Volunteer not found.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

    }
}

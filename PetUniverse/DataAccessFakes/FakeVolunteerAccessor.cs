using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Josh Jackson
    /// Created: 02/07/2020
    /// Approver: Ethan Holmes, Gabi Legrand
    /// 
    /// This is a data access class used for testing, uses fake data does not communicate with a DB
    /// </summary>
    public class FakeVolunteerAccessor : IVolunteerAccessor
    {
        private List<Volunteer> volunteers = new List<Volunteer>();
        private List<Foster> fosters = new List<Foster>();

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 02/07/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is a constructor containing a list of volunteers to be used for testing purposes
        /// </summary>
        /// <remarks>
        /// Updater: Josh Jackson
        /// Updated: 02/13/2020
        /// Update: Added Fake Volunteer data to list of volunteers
        /// </remarks>
        public FakeVolunteerAccessor()
        {
            volunteers = new List<Volunteer>()
            {
                new Volunteer()
                {
                    VolunteerID = 1,
                    FirstName = "Tony",
                    LastName = "Stark",
                    Email = "ironman@gmail.com",
                    PhoneNumber = "15554443322",
                    OtherNotes = "test",
                    Active = true,
                    Skills = new List<string>() { "Dogwalker", "Groomer" }
                },

                 new Volunteer()
                 {
                     VolunteerID = 2,
                     FirstName = "Ronnie",
                     LastName = "Radke",
                     Email = "fir@gmail.com",
                     PhoneNumber = "16664206969",
                     OtherNotes = "test",
                     Active = true,
                     Skills = new List<string>() { "Dogwalker", "Groomer" }
                 },

                 new Volunteer()
                 {
                     VolunteerID = 3,
                     FirstName = "Gordon",
                     LastName = "Ramsey",
                     Email = "beefwellington@gmail.com",
                     PhoneNumber = "15556669988",
                     OtherNotes = "test",
                     Active = false,
                     Skills = new List<string>() { "Dogwalker", "Groomer" }
                 }
            };

            fosters = new List<Foster>()
            {
                new Foster()
                {
                    FosterID = 1,
                    VolunteerID = 3,
                    AddressLineOne = "22 Hell St",
                    AddressLineTwo = "#666",
                    City = "Cedar Rapids",
                    State = "IA",
                    Zip = "52403"
                }
            };
        }

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 03/12/2020
        /// Approver: Timothy Lickteig
        /// 
        /// This is a fake method used for testing setting an inactive volunteer to active
        /// the save button
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        public int ActivateVolunteer(int volunteerID)
        {
            Volunteer volunteer = null;

            //Fail immediatly if null
            if (volunteerID == null)
            {
                throw new Exception();
            }

            //Check that volunteer is in list, if so assign it, else fail
            foreach (var r in volunteers)
            {
                if (volunteerID == r.VolunteerID)
                {
                    volunteer = r;
                }
            }

            //Throw exception if volunteer isn't in list
            if (volunteer == null || volunteerID != volunteer.VolunteerID)
            {
                throw new Exception();
            }

            //Activate it
            volunteer.Active = true;

            if (volunteer.Active == true)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 04/26/2020
        /// Checked By: 
        /// 
        /// This is a data access method used for testing inserting a foster
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="volunteer"></param>
        /// <param name="newFoster"></param>
        /// <returns></returns>
        public int CreateFoster(Volunteer volunteer, Foster newFoster)
        {
            newFoster.VolunteerID = volunteer.VolunteerID;
            fosters.Add(newFoster);
            return 1;
        }

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 03/12/2020
        /// Approver: Timothy Lickteig
        /// This is a fake method used for testing setting an active volunteer to inactive
        /// the save button
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        public int DeactivateVolunteer(int volunteerID)
        {
            Volunteer volunteer = null;

            //Fail immediatly if null
            if (volunteerID == null)
            {
                throw new Exception();
            }

            //Check that volunteer is in list, if so assign it, else fail
            foreach (var r in volunteers)
            {
                if (volunteerID == r.VolunteerID)
                {
                    volunteer = r;
                }
            }

            //Throw exception if volunteer isn't in list
            if (volunteer == null || volunteerID != volunteer.VolunteerID)
            {
                throw new Exception();
            }

            //Deactivate it
            volunteer.Active = false;

            if (volunteer.Active == false)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 03/6/2020
        /// Approver: Zoey McDonald
        /// This is a data access method used for testing searching for a foster record by volunteer id
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        public Foster GetFosterDetailsByVolunteerID(int volunteerID)
        {
            return (from f in fosters
                    where f.VolunteerID == 3
                    select f).FirstOrDefault();
        }

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 03/6/2020
        /// Approver: Zoey McDonald
        /// This is a data access method used for testing searching for a Volunteer by their first name
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="wholeName"></param>
        /// <returns></returns>
        public List<Volunteer> GetVolunteerByFirstName(string wholeName)
        {
            return (from v in volunteers
                    where v.FirstName == "Tony"
                    select v).ToList();
        }

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 02/13/2020
        /// Approver: Gabi LeGrand
        /// 
        /// This is a data access method used for testing searching for a Volunteer by their first and last name
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public List<Volunteer> GetVolunteerByName(string firstName, string lastName)
        {
            return (from v in volunteers
                    where v.FirstName == "Tony"
                    where v.LastName == "Stark"
                    select v).ToList();
        }

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 04/16/2020
        /// Approver: 
        /// 
        /// This is a data access method used for testing sorting a Volunteer by their skill
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="skill"></param>
        /// <returns></returns>
        public List<Volunteer> GetVolunteersBySkill(string skill)
        {
            return (from v in volunteers
                    where v.Skills.Contains("Dogwalker")
                    select v).ToList();
        }

        //Volunteer management needs to implement this
        public List<string> GetVolunteerSkillsByID(int volunteerID)
        {
            throw new NotImplementedException();
        }

        //Volunteer management needs to implement this
        public int InsertOrDeleteVolunteerSkill(int volunteerID, string skill, bool delete = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan Holmes
        /// 
        /// This is a data access method used for testing inserting a volunteer
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="volunteer"></param>
        /// <returns></returns>
        public int InsertVolunteer(Volunteer volunteer)
        {
            volunteers.Add(volunteer);
            return 1;
        }

        /// <summary>
        /// Creator: Josh Jackson
        /// Created: 02/07/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is a data access method used for testing selecting a list of skills
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <returns></returns>
        public List<string> SelectAllSkills()
        {
            List<string> skills = new List<string>() { "Dogwalker", "Groomer" };
            return skills;
        }

        /// <summary>
        /// Creator: Gabrielle LeGrand
        /// Created: 2/6/2020
        /// Approver: Josh Jackson
        /// 
        /// This Test method selects the fake volunteers that are listed as active in the Fake Volunteer Accessor class.
        /// </summary>
        /// <param name="active"></param>
        /// <returns> SelectedVolunteers </returns>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>

        public List<Volunteer> SelectVolunteersByActive(bool active = true)
        {
            var selectedVolunteers = (from v in volunteers
                                      where v.Active == true
                                      select v).ToList();
            return selectedVolunteers;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/05/2020
        /// Checked By: Zoey McDonald
        /// 
        /// This is a fake method used for testing logic layer
        /// the save button
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="oldVolunteer"></param>
        /// <param name="newVolunteer"></param>
        /// <returns></returns>
        public int UpdateVolunteer(Volunteer oldVolunteer, Volunteer newVolunteer)
        {
            Volunteer volunteer = oldVolunteer;

            try
            {
                oldVolunteer = newVolunteer;
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 04/26/2020
        /// Checked By: 
        /// 
        /// This is a fake method used for testing updating a volunteer
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="foster"></param>
        /// <param name="newFoster"></param>
        /// <returns></returns>
        public int UpdateFoster(Foster foster, Foster newFoster)
        {
            Foster oldFoster = foster;

            try
            {
                oldFoster = newFoster;
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 04/28/2020
        /// Approver: Steven Cardona
        /// 
        /// This fake method is called to get a fake Volunteer
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public Volunteer getVolunteerByEmail(string email)
        {
            Volunteer _volunteer = new Volunteer();
            foreach (var volunteer in volunteers)
            {
                if (volunteer.Email == email)
                {
                    _volunteer = volunteer;
                    break;
                }
            }
            return _volunteer;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 04/28/2020
        /// Approver: Steven Cardona
        /// 
        /// This fake method is called to Authenticate a fake Volunteer 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public Volunteer AuthenticateVolunteer(string username, string passwordHash)
        {
            bool userName = username.Equals("j.doe@RandoGuy.com");
            bool hash = passwordHash.Equals("A7574A42198B7D7EEE2C037703A0B95558F195457908D6975E681E2055FD5EB9");

            if (userName && hash)
            {
                Volunteer volunteer = new Volunteer()
                {
                    Email = "j.doe@RandoGuy.com",
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "5632102101",
                    Active = true
                };
                return volunteer;
            }
            else
            {
                throw new ApplicationException("Invalid User");
            }
        }
    }
}


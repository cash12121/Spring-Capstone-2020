using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver:  Awaab Elamin, 2020/02/21
    /// This Class for creation a fake Adoption Applictions which will used 
    /// for testing Logic layer methodes.
    /// </summary>
    public class FakeInHomeInspectionAppointmentDecisionAccessor : IInHomeInspectionAppointmentDecisionAccessor
    {

        private List<HomeInspectorAdoptionAppointmentDecision> inHomeInspectionAppointmentDecisions = null;
        private List<AdoptionAppointmentVM> adoptionAppointmentVMs;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:  Awaab Elamin, 2020/02/21 
        /// This is a Constructor method which has fake Fake InHomeInspection Appointment Decision list. 
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        public FakeInHomeInspectionAppointmentDecisionAccessor()
        {
            inHomeInspectionAppointmentDecisions = new List<HomeInspectorAdoptionAppointmentDecision>()
            {
                new HomeInspectorAdoptionAppointmentDecision()
                {
                    AppointmentID = 100001,
                    AdoptionApplicationID = 100001,
                    AppointmentTypeID = "facilitator",
                    DateTime = DateTime.Now,
                    Notes = "These are my notes",
                    Decision = "facilitator",
                    LocationID =12033,
                    Active = true
                },

                new HomeInspectorAdoptionAppointmentDecision()
                {
                    AppointmentID = 100002,
                    AdoptionApplicationID = 100002,
                    AppointmentTypeID = "inHomeInspection",
                    DateTime = DateTime.Now,
                    Notes = "These are my notes",
                    Decision = "profiler",
                    LocationID =1000029,
                    Active = true
                },

                new HomeInspectorAdoptionAppointmentDecision()
                {
                    AppointmentID = 100003,
                    AdoptionApplicationID = 100003,
                    AppointmentTypeID = "inHomeInspection",
                    DateTime = DateTime.Now,
                    Notes = "These are my notes",
                    Decision = "profiler",
                    LocationID =1000029,
                    Active = true
                }
            };

            adoptionAppointmentVMs = new List<AdoptionAppointmentVM>()
            {
                new AdoptionAppointmentVM()
                {
                    AppointmentID = 000,
                    AdoptionApplicationID = 10000,
                    AppointmentTypeID = "Meet and Greet",
                    AppointmentDateTime = DateTime.Parse("2020-10-10"),
                    Notes = "Fake",
                    Decision = "Fake",
                    LocationID = 000,
                    AppointmentActive = true,
                    CustomerID = 000,
                    AnimalID = 000,
                    AdoptionApplicationStatus = "good",
                    AdoptionApplicationRecievedDate = DateTime.Parse("2020-10-10"),
                    LocationName = "Fake",
                    LocationAddress1 = "111 Fake st.",
                    LocationAddress2 = "Apt #3",
                    LocationCity = "Fake Town",
                    LocationState = "AA",
                    LocationZip = "00000",
                    UserID = 000,
                    CustomerFirstName = "First",
                    CustomerLastName = "Last",
                    CustomerPhoneNumber = "1234567890",
                    CustomerEmail = "Fake@fake.fake",
                    CustomerActive = true,
                    CustomerCity = "Fakesville",
                    CustomerState = "BB",
                    CustomerZipCode = "12345",
                    AnimalName = "FakeDog",
                    AnimalDob = DateTime.Parse("2020-10-10"),
                    AnimalSpeciesID = "Dog",
                    AnimalBreed = "Chihuahua",
                    AnimalArrivalDate = DateTime.Parse("2020-10-10"),
                    AnimalCurrentlyHoused = true,
                    AnimalAdoptable = true,
                    AnimalActive = true
                },

                new AdoptionAppointmentVM()
                {
                    AppointmentID = 000,
                    AdoptionApplicationID = 10001,
                    AppointmentTypeID = "Meet and Greet",
                    AppointmentDateTime = DateTime.Parse("2020-10-10"),
                    Notes = "Fake",
                    Decision = "Fake",
                    LocationID = 000,
                    AppointmentActive = true,
                    CustomerID = 000,
                    AnimalID = 000,
                    AdoptionApplicationStatus = "good",
                    AdoptionApplicationRecievedDate = DateTime.Parse("2020-10-10"),
                    LocationName = "Fake",
                    LocationAddress1 = "111 Fake st.",
                    LocationAddress2 = "Apt #3",
                    LocationCity = "Fake Town",
                    LocationState = "AA",
                    LocationZip = "00000",
                    UserID = 000,
                    CustomerFirstName = "First",
                    CustomerLastName = "Last",
                    CustomerPhoneNumber = "1234567890",
                    CustomerEmail = "Fake@fake.fake",
                    CustomerActive = true,
                    CustomerCity = "Fakesville",
                    CustomerState = "BB",
                    CustomerZipCode = "12345",
                    AnimalName = "FakeDog",
                    AnimalDob = DateTime.Parse("2020-10-10"),
                    AnimalSpeciesID = "Dog",
                    AnimalBreed = "Chihuahua",
                    AnimalArrivalDate = DateTime.Parse("2020-10-10"),
                    AnimalCurrentlyHoused = true,
                    AnimalAdoptable = true,
                    AnimalActive = true
                }
            };
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:  Awaab Elamin, 2020/02/21
        /// This is Mock Access Method for getting Customer Email By Adoption Application ID.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationId"></param>
        /// <returns>result</returns>
        public string GetCustomerEmailByAdoptionApplicationID(int adoptionApplicationId)
        {
            string userEmail = "";

            foreach (AdoptionAppointmentVM a in adoptionAppointmentVMs)
            {
                if (adoptionApplicationId == a.AdoptionApplicationID)
                {
                    userEmail = a.CustomerEmail;
                    break;
                }
            }
            return userEmail;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:  Awaab Elamin, 2020/02/21
        /// This fake method is called to get a fake list of Adoption Applications. 
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <returns>fake list of Adoption Applications</returns>
        public List<HomeInspectorAdoptionAppointmentDecision> SelectAdoptionApplicationsAappointmentsByAppointmentType()
        {
            return (from InHomeInspectionAppointmentDecision in inHomeInspectionAppointmentDecisions
                    where InHomeInspectionAppointmentDecision.AppointmentTypeID == "inHomeInspection"
                    select InHomeInspectionAppointmentDecision).ToList();
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:  Awaab Elamin, 2020/02/21
        /// This is Mock Access Method for updating Update in-Home Inspector Decision.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <param name="decision"></param>
        /// <returns>rowsEffects</returns>
        public int UpdateHomeInspectorDecision(int adoptionApplicationID, string decision)
        {
            int rowsAffected = 0;

            foreach (AdoptionAppointmentVM adoptionApplication in adoptionAppointmentVMs)
            {
                if (adoptionApplicationID == adoptionApplication.AdoptionApplicationID)
                {
                    if (decision == "approved")
                    {
                        rowsAffected = 1;
                        adoptionApplication.AdoptionApplicationStatus = "Facilitator";
                    }
                    else
                    {
                        rowsAffected = 1;
                        adoptionApplication.AdoptionApplicationStatus = "Deny";
                    }
                    break;
                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:  Awaab Elamin, 2020/02/21
        /// This fake method is called to get a fake list of Adoption Applictions. 
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="oldHomeInspectorAdoptionAppointmentDecision"></param>
        /// <param name="newHomeInspectorAdoptionAppointmentDecision"></param>
        /// <returns>result</returns>
        int IInHomeInspectionAppointmentDecisionAccessor.UpdateAppoinment(HomeInspectorAdoptionAppointmentDecision oldHomeInspectorAdoptionAppointmentDecision,
            HomeInspectorAdoptionAppointmentDecision newHomeInspectorAdoptionAppointmentDecision)
        {
            int result = 0;

            foreach (HomeInspectorAdoptionAppointmentDecision HomeInspectorAdoptionAppointmentDecision in inHomeInspectionAppointmentDecisions)
            {
                if ((HomeInspectorAdoptionAppointmentDecision.AdoptionApplicationID == oldHomeInspectorAdoptionAppointmentDecision.AdoptionApplicationID)
                    && (HomeInspectorAdoptionAppointmentDecision.AppointmentID == oldHomeInspectorAdoptionAppointmentDecision.AppointmentID)
                    && (HomeInspectorAdoptionAppointmentDecision.Decision == oldHomeInspectorAdoptionAppointmentDecision.Decision))
                {
                    HomeInspectorAdoptionAppointmentDecision.Decision = newHomeInspectorAdoptionAppointmentDecision.Decision;
                    result++;
                }
            }
            return result;
        }
    }
}

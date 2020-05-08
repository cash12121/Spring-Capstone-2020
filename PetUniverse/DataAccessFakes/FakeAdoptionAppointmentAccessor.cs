using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccessFakes
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/10/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This class contains Data Access fakes for data pertaining to Adoption Appointments.
    /// </summary>
    public class FakeAdoptionAppointmentAccessor : IAdoptionAppointmentAccessor
    {
        private List<AdoptionAppointmentVM> _adoptionAppointmentVMs;
        private List<AdoptionAppointment> _adoptionAppointments;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/10/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This is the no-argument constructor for this class. It builds a fake
        /// data accessor object to be used for testing purposes
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public FakeAdoptionAppointmentAccessor()
        {
            _adoptionAppointmentVMs = new List<AdoptionAppointmentVM>()
            {
                new AdoptionAppointmentVM()
                {
                    AppointmentID = 000,
                    AdoptionApplicationID = 000,
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

            _adoptionAppointments = new List<AdoptionAppointment>
            {
                new AdoptionAppointment
                {
                    AppointmentID = 000,
                    AdoptionApplicationID = 000,
                    AppointmentActive = true,
                    AppointmentDateTime = DateTime.Parse("7/12/1984"),
                    AppointmentTypeID = "FAKE",
                    Decision = "Fake",
                    LocationID = 000,
                    LocationName = "Fake",
                    Notes = "Fake",
                },
                new AdoptionAppointment
                {
                    AppointmentID = 001,
                    AdoptionApplicationID = 000,
                    AppointmentActive = true,
                    AppointmentDateTime = DateTime.Parse("7/12/1984"),
                    AppointmentTypeID = "FAKE",
                    Decision = "Fake",
                    LocationID = 000,
                    LocationName = "Fake",
                    Notes = "Fake",
                },
                new AdoptionAppointment
                {
                    AppointmentID = 002,
                    AdoptionApplicationID = 000,
                    AppointmentActive = true,
                    AppointmentDateTime = DateTime.Parse("7/12/1984"),
                    AppointmentTypeID = "FAKE",
                    Decision = "Fake",
                    LocationID = 000,
                    LocationName = "Fake",
                    Notes = "Fake",
                },
            };
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This method inserts a Adoption Appointment into the Fake
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionAppointment"></param>
        /// <returns></returns>
        public int InsertAdoptionAppointment(AdoptionAppointment adoptionAppointment)
        {
            int rows = 0;
            try
            {
                _adoptionAppointments.Add(adoptionAppointment);
                rows = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rows;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/5/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This method returns a fake list of Adoption customer VM's based upon AppointmentID. This method will
        /// be used exclusively for unit testing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        public AdoptionAppointmentVM SelectAdoptionAppointmentByAppointmentID(int appointmentID)
        {
            return (from a in _adoptionAppointmentVMs
                    where a.AppointmentID == appointmentID
                    select a).First();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/27/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This method returns a fake list of Adoption customer VM's based upon email. This method will
        /// be used exclusively for unit testing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<AdoptionAppointmentVM> SelectAdoptionAppointmentByCustomerEmailAndActive(string email, bool active)
        {
            return (from a in _adoptionAppointmentVMs
                    where a.CustomerEmail == email
                    && a.AppointmentActive == active
                    select a).ToList();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/29/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This method returns a fake list of Adoption customer VM's. This method will
        /// be used exclusively for unit testing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<AdoptionAppointmentVM> SelectAdoptionAppointmentsByActive(bool active)
        {
            return (from a in _adoptionAppointmentVMs
                    where a.AppointmentActive == active
                    select a).ToList();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/10/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This method returns a fake list of Adoption customer VM's. This method will
        /// be used exclusively for unit testing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <param name="appointmentTypeID"></param>
        /// <returns></returns>
        public List<AdoptionAppointmentVM> SelectAdoptionAppointmentsByActiveAndType(bool active, string appointmentTypeID)
        {
            return (from a in _adoptionAppointmentVMs
                    where a.AppointmentActive == true
                    && a.AppointmentTypeID == appointmentTypeID
                    select a).ToList();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/1/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This method updates an appointments active property.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="appointmentID"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        public int UpdateAdoptionAppointmentActive(int appointmentID, bool active)
        {
            int rows = 0;
            foreach(var a in _adoptionAppointmentVMs)
            {
                if(a.AppointmentID == appointmentID)
                {
                    a.AppointmentActive = active;
                    rows += 1;
                }
            }
            return rows;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/27/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This method updates an appointments datetime property.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="appointmentID"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public int UpdateAdoptionAppointmentDateTime(int appointmentID, DateTime dateTime)
        {
            int rows = 0;
            foreach(var a in _adoptionAppointmentVMs)
            {
                if(a.AppointmentID == appointmentID)
                {
                    a.AppointmentDateTime = dateTime;
                    rows += 1;
                }
            }
            return rows;
        }

        public int UpdateAdoptionAppopintment(AdoptionAppointment oldAppointment, AdoptionAppointment newAppointment)
        {
            int rows = 0;
            foreach(var a in _adoptionAppointments)
            {
                if (a.AppointmentID == oldAppointment.AppointmentID
                    && a.AdoptionApplicationID == oldAppointment.AdoptionApplicationID
                    && a.AppointmentActive == oldAppointment.AppointmentActive
                    && a.AppointmentDateTime == oldAppointment.AppointmentDateTime
                    && a.AppointmentTypeID == oldAppointment.AppointmentTypeID
                    && a.Decision == oldAppointment.Decision
                    && a.LocationID == oldAppointment.LocationID)
                {
                    a.AdoptionApplicationID = newAppointment.AdoptionApplicationID;
                    a.AppointmentActive = newAppointment.AppointmentActive;
                    a.AppointmentDateTime = newAppointment.AppointmentDateTime;
                    a.AppointmentTypeID = newAppointment.AppointmentTypeID;
                    a.Decision = newAppointment.Decision;
                    a.LocationID = newAppointment.LocationID;
                    rows += 1;
                }
            }
            return rows;
        }
    }
}

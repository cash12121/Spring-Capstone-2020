using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;


namespace LogicLayer
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/10/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This class contains the methods that will bring data from the database and present
    /// it to the presentation layer.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class AdoptionAppointmentManager : IAdoptionAppointmentManager
    {


        IAdoptionAppointmentAccessor _adoptionAppointmentAccessor;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/10/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This is the no-argument constructor for this class. This will be the constructor
        /// that will typically be used.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AdoptionAppointmentManager()
        {
            _adoptionAppointmentAccessor = new AdoptionAppointmentAccessor();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/10/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This is the full constructor. It will be used for unit testing purposes
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionAppointmentAccessor"></param>
        public AdoptionAppointmentManager(IAdoptionAppointmentAccessor adoptionAppointmentAccessor)
        {
            _adoptionAppointmentAccessor = adoptionAppointmentAccessor;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// passes an adoption appointment to the data acces layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionAppointment"></param>
        /// <returns></returns>
        public bool AddAdoptionAppointment(AdoptionAppointment adoptionAppointment)
        {
            bool result = false;
            try
            {
                result = 1 == _adoptionAppointmentAccessor.InsertAdoptionAppointment(adoptionAppointment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/2/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// updates an Appointment
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="oldAppointment"></param>
        /// <param name="newAppointment"></param>
        /// <returns></returns>
        public bool EditAdoptionAppointment(AdoptionAppointment oldAppointment, AdoptionAppointment newAppointment)
        {
            try
            {
                return 1 == _adoptionAppointmentAccessor.UpdateAdoptionAppopintment(oldAppointment, newAppointment);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Database Error", ex);
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/2/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// updates an Appointments active status
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
        public bool EditAdoptionAppointmentActive(int appointmentID, bool active)
        {
            try
            {
                return 1 == _adoptionAppointmentAccessor.UpdateAdoptionAppointmentActive(appointmentID, active);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Database Error", ex);
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/27/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// updates an Appointments datetime
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
        public bool EditAdoptionAppointmentDateTime(int appointmentID, DateTime dateTime)
        {
            try
            {
                return 1 == _adoptionAppointmentAccessor.UpdateAdoptionAppointmentDateTime(appointmentID, dateTime);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Database Error", ex);
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Gets an Adoption AppointmentVM by AppointmentID
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        public AdoptionAppointmentVM RetrieveAdoptionAppointmentByAppointmentID(int appointmentID)
        {
            try
            {
                return _adoptionAppointmentAccessor.SelectAdoptionAppointmentByAppointmentID(appointmentID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/29/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Gets a list Adoption AppointmentVMs by active
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public List<AdoptionAppointmentVM> RetrieveAdoptionAppointmentsByActive(bool active = true)
        {
            try
            {
                return _adoptionAppointmentAccessor.SelectAdoptionAppointmentsByActive(active);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Database Error", ex);
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/10/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This method will get a list of AdoptionAppointmentVM's from the data access layer and send
        /// them up to the presentation layer.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <returns>adoptionAppointmentVMs</returns>
        public List<AdoptionAppointmentVM> RetrieveAdoptionAppointmentsByActiveAndType(bool active, String typeID)
        {
            try
            {
                return _adoptionAppointmentAccessor.SelectAdoptionAppointmentsByActiveAndType(active = true, typeID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database Error", ex);
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/27/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This method will get a list of AdoptionAppointmentVM's from the data access layer and send
        /// them up to the presentation layer.
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
        public List<AdoptionAppointmentVM> RetrieveAdoptionAppointmentsByCustomerEmailAndActive(string email, bool active = true)
        {
            try
            {
                return _adoptionAppointmentAccessor.SelectAdoptionAppointmentByCustomerEmailAndActive(email, active);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Database Error", ex);
            }
        }
    }
}

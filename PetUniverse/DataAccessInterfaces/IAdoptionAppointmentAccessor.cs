using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 2/9/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Data Access Inteface that is used to establish interfaces for use with 
    /// Adoption Appointment Accessor Methods
    /// </summary>
    public interface IAdoptionAppointmentAccessor
    {

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/28/2020
        /// Approver: Michael Thompson
        /// 
        /// Data Access Inteface that is used to Select Adoption Appointment VMs by active
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        List<AdoptionAppointmentVM> SelectAdoptionAppointmentsByActive(bool active);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Data Access Inteface that is used to Select Adoption Appointment VMs by active and type
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="active"></param>
        /// <param name="appointmentTypeID"></param>
        /// <returns></returns>
        List<AdoptionAppointmentVM> SelectAdoptionAppointmentsByActiveAndType(bool active, string appointmentTypeID);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Data Access Inteface that is used to Select Adoption Appointment VMs by AppointmentID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        AdoptionAppointmentVM SelectAdoptionAppointmentByAppointmentID(int appointmentID);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/27/2020
        /// Approver: Michael Thompson
        /// 
        /// Data Access Inteface that is used to Select Adoption Appointment VMs by Customer email and active
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// <param name="email"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        List<AdoptionAppointmentVM> SelectAdoptionAppointmentByCustomerEmailAndActive(string email, bool active);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Michael Thompson
        /// 
        /// Data Access Inteface that is used to inser Adoption Appointments
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="adoptionAppointment"></param>
        /// <returns></returns>
        int InsertAdoptionAppointment(AdoptionAppointment adoptionAppointment);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/27/2020
        /// Approver: Michael Thompson
        /// 
        /// Data Access Inteface that is used to update an appointments datetime
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// <param name="dateTime"></param>
        /// <returns></returns>
        int UpdateAdoptionAppointmentDateTime(int appointmentID, DateTime dateTime);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 5/1/2020
        /// Approver: Michael Thompson
        /// 
        /// Data Access Inteface that is used to deactivate an appointments
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        int UpdateAdoptionAppointmentActive(int appointmentID, bool active);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 5/3/2020
        /// Approver: Michael Thompson
        /// 
        /// Data Access Inteface that is used to update an appointment
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// <param name="oldAppointment"></param>
        /// <param name="newAppointment"></param>
        /// <returns></returns>
        int UpdateAdoptionAppopintment(AdoptionAppointment oldAppointment, AdoptionAppointment newAppointment);
    }
}

using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAM Austin Gee
    /// DATE: 2/17/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This class contains the inteface methods for Adoption appointments
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public interface IAdoptionAppointmentManager
    {

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/29/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Interface for retrieveing an adoption vm by active
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        List<AdoptionAppointmentVM> RetrieveAdoptionAppointmentsByActive(bool active = true);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/5/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Interface for retrieveing an adoption vm by active and 
        /// type from the data access layer
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
        List<AdoptionAppointmentVM> RetrieveAdoptionAppointmentsByActiveAndType(bool active, string appointmentTypeID);


        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/27/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Interface for retrieveing an adoption appointment vm by active and 
        /// email from the data access layer
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
        List<AdoptionAppointmentVM> RetrieveAdoptionAppointmentsByCustomerEmailAndActive(string email, bool active = true);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/5/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Interface for retrieveing an adoption vm by Appointment ID 
        /// from the data access layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        AdoptionAppointmentVM RetrieveAdoptionAppointmentByAppointmentID(int appointmentID);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// passes an adoption appointment to the data acces layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        /// <param name="adoptionAppointment"></param>
        /// <returns></returns>
        bool AddAdoptionAppointment(AdoptionAppointment adoptionAppointment);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/27/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Interface for editing an appointments datetime
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
        bool EditAdoptionAppointmentDateTime(int appointmentID, DateTime dateTime);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/1/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Interface for editing an appointments datetime
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
        bool EditAdoptionAppointmentActive(int appointmentID, bool active);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/1/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Interface for editing an appointment
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
        bool EditAdoptionAppointment(AdoptionAppointment oldAppointment, AdoptionAppointment newAppointment);
    }
}



